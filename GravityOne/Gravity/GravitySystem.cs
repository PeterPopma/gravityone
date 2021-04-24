using GravityOne.BarnesHut;
using GravityOne.SpaceObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GravityOne.Gravity
{
    class GravitySystem
    {
        int minimumTextureSize = 11;

        List<GravityObject> gravityObjects = new List<GravityObject>();
        int objectIndex = -1;
        int centerIndex = -1;
        int targetFrameRate = 40;       // target FPS
        long scale = 100;      // 1m = METERS_PER_PIXEL*[scale]m
        long offsetX;        // offset in SCREEN coordinates
        long offsetY;        // offset in SCREEN coordinates
        long targetOffsetX;        // target offset in SCREEN coordinates
        long targetOffsetY;        // target offset in SCREEN coordinates
        long originalOffsetX;        // original offset in SCREEN coordinates
        long originalOffsetY;        // original offset in SCREEN coordinates
        const int SCROLL_STEPS = 20;
        int currentScrollStep = 0;
        int viewportWidth;
        int viewportHeight;
        double timeNeedForOneCalculation;
        long calculationTime = 0;
        int calculationsPerStepSetting = -1;
        int calculationsPerStepActual = 100;
        int frameNumberPlay = 0;
        bool isFirstFrame = true;
        double gravitationalConstant = 667408000000;        // in 10^-22 m^3 s^−2 kg^−1
        double accelerationLimit = 0.0000000001;
        public const float METERS_PER_PIXEL = 100000;        // at scale 1: 1000 pixels = 100000 km
        public const uint TIME_GALAXY_INCREASE_FACTOR = 125000;
        internal List<GravityObject> GravityObjects { get => gravityObjects; set => gravityObjects = value; }
        int numVisibleObjects;          // this is the number of gravity objects minus the Solar System objects
        int visibleObjectsIndex = 1;    // this is the display-index of the currently selected object; it is (and should) only used with the [next] and [previous] buttons
        double secondsSolarSystem;
        double secondsGalaxy;
        bool simulationRunning;

        // Pre-calculation
        Object2D[][] calculation;
        Vector[] calculationInitialSpeeds;              // The initial speed of the objects. Used a a base for object properties.
        Vector[] calculationCurrentSpeeds;              // The current speed used for color coding and showing as property
        Vector[] calculationCurrentAccelerations;       // The current acceleration used for color coding and showing as property
        int preCalculationTime = 20;        // Timespan (seconds) of precalculated period
        int calculationsPerStepPrecalculatedGalaxy = 1;
        int calculationsPerStepPrecalculatedSolar = 100;
        int frameNumberCalc = 1;         // Total number of calculated frames. Frame 0 is the unmodified starting situation.
        long calculationSecondsPerFrame;
        private bool isCalculating = false;
        private bool isRecording = false;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPreCalculate;

        // Barnes-Hut approximation
        QuadTree quadTree = new QuadTree();
        bool useBarnesHut = true;

        // used for color coding galaxies
        double minSpeed;
        double maxSpeed;
        double minAcceleration;
        double maxAcceleration;
        double speedRange = 0;
        double accelerationRange = 0;

        Message message = new Message();
        GravityUtils gravityUtils;

        public GravitySystem(int viewportWidth_, int viewportHeight_)
        {
            ViewportWidth = viewportWidth_;
            ViewportHeight = viewportHeight_;
            gravityUtils = new GravityUtils(this);
        }

        public int NumPrecalculatedFrames()
        {
            return preCalculationTime * targetFrameRate;
        }

        public void SelectObjectAtMousePointer(double x, double y)
        {
            objectIndex = gravityUtils.FindClosestObject(x, y);
            visibleObjectsIndex = GetVisibleObjectIndex();
        }

        public void ObtainMinMaxValues()
        {
            minSpeed = double.MaxValue;
            maxSpeed = double.MinValue;
            minAcceleration = double.MaxValue;
            maxAcceleration = double.MinValue;
            for (int k = 0; k < GravityObjects.Count; k++)
            {
                GravityObject o = GravityObjects[k];

                if (o.Speed < minSpeed)
                {
                    minSpeed = o.Speed;
                }
                if (o.Speed > maxSpeed)
                {
                    maxSpeed = o.Speed;
                }
                if (o.Acceleration < minAcceleration)
                {
                    minAcceleration = o.Acceleration;
                }
                if (o.Acceleration > maxAcceleration)
                {
                    maxAcceleration = o.Acceleration;
                }
            }
            if (CalculationInitialSpeeds != null)
            {
                foreach (Vector speed in CalculationInitialSpeeds)
                {
                    if (speed.Magnitude < minSpeed)
                    {
                        minSpeed = speed.Magnitude;
                    }
                    if (speed.Magnitude > maxSpeed)
                    {
                        maxSpeed = speed.Magnitude;
                    }
                }
            }
            if (CalculationCurrentSpeeds != null)
            {
                foreach (Vector speed in CalculationCurrentSpeeds)
                {
                    if (speed.Magnitude < minSpeed)
                    {
                        minSpeed = speed.Magnitude;
                    }
                    if (speed.Magnitude > maxSpeed)
                    {
                        maxSpeed = speed.Magnitude;
                    }
                }
            }
            if (CalculationCurrentAccelerations != null)
            {
                foreach (Vector acceleration in CalculationCurrentAccelerations)
                {
                    if (acceleration.Magnitude < minAcceleration)
                    {
                        minAcceleration = acceleration.Magnitude;
                    }
                    if (acceleration.Magnitude > maxSpeed)
                    {
                        maxAcceleration = acceleration.Magnitude;
                    }
                }
            }

            speedRange = maxSpeed - minSpeed;
            accelerationRange = maxAcceleration - minAcceleration;
        }

        public long OffsetY
        {
            get
            {
                return offsetY;
            }

            set
            {
                offsetY = value;
            }
        }

        public long OffsetX
        {
            get
            {
                return offsetX;
            }

            set
            {
                offsetX = value;
            }
        }

        public long Scale
        {
            get
            {
                return scale;
            }

            set
            {
                scale = value;
            }
        }

        public int ObjectIndex
        {
            get
            {
                return objectIndex;
            }

            set
            {
                objectIndex = value;
            }
        }

        public int CenterIndex
        {
            get
            {
                return centerIndex;
            }

            set
            {
                centerIndex = value;
            }
        }

        public int CalculationsPerStepSetting
        {
            get
            {
                return calculationsPerStepSetting;
            }

            set
            {
                calculationsPerStepSetting = value;
            }
        }

        public int CalculationsPerStepActual
        {
            get
            {
                return calculationsPerStepActual;
            }

            set
            {
                calculationsPerStepActual = value;
            }
        }

        public int TargetFrameRate
        {
            get
            {
                return targetFrameRate;
            }

            set
            {
                targetFrameRate = value;
            }
        }

        public int PreCalculationTime
        {
            get
            {
                return preCalculationTime;
            }

            set
            {
                preCalculationTime = value;
            }
        }

        internal Object2D[][] Calculation
        {
            get
            {
                return calculation;
            }

            set
            {
                calculation = value;
            }
        }

        public int FrameNumberPlay
        {
            get
            {
                return frameNumberPlay;
            }

            set
            {
                frameNumberPlay = value;
            }
        }

        public int CalculationsPerStepPrecalculatedGalaxy
        {
            get
            {
                return calculationsPerStepPrecalculatedGalaxy;
            }

            set
            {
                calculationsPerStepPrecalculatedGalaxy = value;
            }
        }

        public int FrameNumberCalc
        {
            get
            {
                return frameNumberCalc;
            }

            set
            {
                frameNumberCalc = value;
            }
        }

        public bool IsCalculating
        {
            get
            {
                return isCalculating;
            }

            set
            {
                isCalculating = value;
            }
        }

        public BackgroundWorker BackgroundWorkerPreCalculate
        {
            get
            {
                return backgroundWorkerPreCalculate;
            }

            set
            {
                backgroundWorkerPreCalculate = value;
            }
        }

        public double GravitationalConstant
        {
            get
            {
                return gravitationalConstant;
            }

            set
            {
                gravitationalConstant = quadTree.GravitationalConstant = value;
            }
        }

        public double MinSpeed
        {
            get
            {
                return minSpeed;
            }

            set
            {
                minSpeed = value;
            }
        }

        public double MaxSpeed
        {
            get
            {
                return maxSpeed;
            }

            set
            {
                maxSpeed = value;
            }
        }

        public double MinAcceleration
        {
            get
            {
                return minAcceleration;
            }

            set
            {
                minAcceleration = value;
            }
        }

        public double MaxAcceleration
        {
            get
            {
                return maxAcceleration;
            }

            set
            {
                maxAcceleration = value;
            }
        }

        public double SpeedRange
        {
            get
            {
                return speedRange;
            }

            set
            {
                speedRange = value;
            }
        }

        public double AccelerationRange
        {
            get
            {
                return accelerationRange;
            }

            set
            {
                accelerationRange = value;
            }
        }

        internal QuadTree QuadTree
        {
            get
            {
                return quadTree;
            }

            set
            {
                quadTree = value;
            }
        }

        public bool UseBarnesHut
        {
            get
            {
                return useBarnesHut;
            }

            set
            {
                useBarnesHut = value;
            }
        }

        public long CalculationSecondsPerFrame
        {
            get
            {
                return calculationSecondsPerFrame;
            }

            set
            {
                calculationSecondsPerFrame = value;
            }
        }

        internal Vector[] CalculationInitialSpeeds
        {
            get
            {
                return calculationInitialSpeeds;
            }

            set
            {
                calculationInitialSpeeds = value;
            }
        }

        internal Vector[] CalculationCurrentSpeeds
        {
            get
            {
                return calculationCurrentSpeeds;
            }

            set
            {
                calculationCurrentSpeeds = value;
            }
        }

        internal Vector[] CalculationCurrentAccelerations
        {
            get
            {
                return calculationCurrentAccelerations;
            }

            set
            {
                calculationCurrentAccelerations = value;
            }
        }

        public int MinimumTextureSize
        {
            get
            {
                return minimumTextureSize;
            }

            set
            {
                minimumTextureSize = value;
            }
        }

        public double AccelerationLimit
        {
            get
            {
                return accelerationLimit;
            }

            set
            {
                accelerationLimit = value;
            }
        }

        internal Message Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public int NumVisibleObjects { get => numVisibleObjects; set => numVisibleObjects = value; }
        public int VisibleObjectsIndex { get => visibleObjectsIndex; set => visibleObjectsIndex = value; }
        public int ViewportWidth { get => viewportWidth; set => viewportWidth = value; }
        public int ViewportHeight { get => viewportHeight; set => viewportHeight = value; }
        public int CalculationsPerStepPrecalculatedSolar { get => calculationsPerStepPrecalculatedSolar; set => calculationsPerStepPrecalculatedSolar = value; }
        public bool IsRecording { get => isRecording; set => isRecording = value; }
        public long CalculationTime { get => calculationTime; set => calculationTime = value; }
        public long TargetOffsetX { get => targetOffsetX; set => targetOffsetX = value; }
        public long TargetOffsetY { get => targetOffsetY; set => targetOffsetY = value; }
        public bool SimulationRunning { get => simulationRunning; set => simulationRunning = value; }

        public void DetermineTimeNeededForOneCalculation(GraphicsDevice dev)
        {
            Random rnd = new Random();
            Texture2D textureTest = new Texture2D(dev, 1, 1);
            Color[] az = Enumerable.Range(0, 1).Select(i => new Color(255, 255, 255, 100)).ToArray();
            textureTest.SetData(az);
            const int NUM_SAMPLE_OBJECTS = 1000;

            calculationsPerStepActual = 1;
            GravityObjects.Clear();
            double randDouble;
            for (int k = 0; k < NUM_SAMPLE_OBJECTS; k++)
            {
                randDouble = rnd.NextDouble();
                GravityObjects.Add(new GravityObject("testobject" + k.ToString(), (randDouble - .5) * 198900.0, (randDouble - .5 * 3844000000000000000), (randDouble - .5) * 3844000000000000000, randDouble - .5 * 20000, randDouble - .5 * 20000, textureTest, Color.White, true, 100, true));
            }

            Stopwatch stopwatch = Stopwatch.StartNew();     // creates and start the instance of Stopwatch
            CalculateStep(1234);
            stopwatch.Stop();

            double EXTRA_TIME_FACTOR = 1.4;
            timeNeedForOneCalculation = EXTRA_TIME_FACTOR * stopwatch.ElapsedMilliseconds / (double)(NUM_SAMPLE_OBJECTS * (NUM_SAMPLE_OBJECTS - 1));
            GravityObjects.Clear();
        }

        // Determines the number of steps that fit within one frame
        // Needs to be called:
        // - when number of objects changes 
        // - when calculationsPerStepSetting changes 
        public void DetermineCalculationsPerStepActual()
        {
            calculationsPerStepActual = calculationsPerStepSetting;
            if (calculationsPerStepSetting == -1)
            {
                if (GravityObjects.Count > 1)       // with one object, time will still be zero
                {
                    double totalTimeNeeded = timeNeedForOneCalculation * GravityObjects.Count * (GravityObjects.Count - 1) * (targetFrameRate / 1000.0);        // time is in millisec, so divide targetFrameRate by 1000 to get "Frames per millisecond"
                    calculationsPerStepActual = (int)(1 / totalTimeNeeded);
                    if (calculationsPerStepActual == 0)
                    {
                        calculationsPerStepActual = 1;
                    }
                }
                else
                {
                    calculationsPerStepActual = 1;
                }
            }
        }

        private void ReverseAllSpeeds()
        {
            foreach (GravityObject o in GravityObjects)
            {
                o.XSpeed = -o.XSpeed;
                o.YSpeed = -o.YSpeed;
            }
        }

        // Make steps to move to a certain simulation time
        public void MoveToDate(DateTime sourceDate, DateTime targetDate)
        {
            TimeSpan diff = targetDate.Subtract(sourceDate);
            if (diff.TotalDays < 0)
            {
                ReverseAllSpeeds();
            }

            int OldcalculationsPerStepActual = calculationsPerStepActual;
            calculationsPerStepActual = 10;    // precision suitable for solar systems
            long timeUnits = (long)diff.TotalSeconds / 100;     // get there in 100 steps;
            for (int k = 0; k < 100; k++)
            {
                CalculateStep(Math.Abs(timeUnits));
            }

            if (diff.TotalDays < 0)
            {
                ReverseAllSpeeds();
            }
            calculationsPerStepActual = OldcalculationsPerStepActual;
        }

        double AngleObjects(GravityObject myObject, GravityObject otherObject)
        {
            return Math.Atan2(otherObject.Y - myObject.Y, otherObject.X - myObject.X);
        }

        private double CalculateObjectAcceleration(double x_difference, double y_difference, GravityObject myObject, GravityObject otherObject)
        {
            double square_radius = Math.Pow(x_difference, 2) + Math.Pow(y_difference, 2);
            if (square_radius == 0)
            {
                // objects exactly on top of each other (or the same object!); bail out to prevent division by zero
                return 0;
            }

            double tmp_acceleration = otherObject.Mass / square_radius;
            double secondsInCalculation;
            if (myObject.SolarSystem == null)
            {
                secondsInCalculation = secondsGalaxy;
            }
            else
            {
                secondsInCalculation = secondsSolarSystem;
            }

            // limit the acceleration to prevent objects very close to each other to get insane accelerations.
            if (tmp_acceleration > AccelerationLimit / secondsInCalculation)
            {
                // moons should be allowed to orbit their host, so don't limit acceleration perpendicular to movement
                double angleSpeedAcceleration = myObject.SpeedAngle - AngleObjects(myObject, otherObject);
                double relevantPortion = Math.Abs(Math.Cos(angleSpeedAcceleration));

                if (tmp_acceleration * relevantPortion > (AccelerationLimit / secondsInCalculation))
                {
                    Message.Text = "Acceleration of object has been limited, because it is too close to another object.";
                    tmp_acceleration = (AccelerationLimit / secondsInCalculation) / relevantPortion;
                }
            }

            return tmp_acceleration;
        }

        private Object2D CalculateObjectAcceleration(GravityObject myObject, int startPosition)
        {
            Object2D acceleration = new Object2D();

            for (int l = startPosition; l < GravityObjects.Count; l++)
            {
                GravityObject otherObject = GravityObjects[l];
                if (otherObject != myObject && ((myObject.SolarSystem == null && otherObject.SolarSystem == null) || (myObject.SolarSystem == otherObject.SolarSystem)))    // only objects of the same type
                {
                    double x_difference = otherObject.X - myObject.X;
                    double y_difference = otherObject.Y - myObject.Y;
                    double tmp_acceleration = CalculateObjectAcceleration(x_difference, y_difference, myObject, otherObject);

                    // divide acceleration in X and Y component
                    double angle = Math.Atan2(y_difference, x_difference);      // angle with positive X axis
                    acceleration.X += Math.Cos(angle) * tmp_acceleration;
                    acceleration.Y += Math.Sin(angle) * tmp_acceleration;
                }
            }

            return acceleration;
        }

        public void CalculateStep(long timeUnits, bool makeStep = true)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();     // create and start the instance of Stopwatch

            double actualSecondsPerStep;
            secondsSolarSystem = (double)timeUnits / calculationsPerStepActual;
            secondsGalaxy = secondsSolarSystem * TIME_GALAXY_INCREASE_FACTOR;

            //            LogValuesRealtimeBegin(calculationsPerStepActual);

            for (int i = 0; i < calculationsPerStepActual; i++)
            {
                for (int k = 0; k < GravityObjects.Count; k++)
                {
                    GravityObject myObject = GravityObjects[k];
                    Object2D acceleration = CalculateObjectAcceleration(myObject, 0);

                    myObject.XAcceleration = acceleration.X;
                    myObject.YAcceleration = acceleration.Y;
                }

                // make a step using the new acceleration
                if (makeStep)
                {
                    for (int k = 0; k < GravityObjects.Count; k++)
                    {
                        GravityObject myObject = GravityObjects[k];

                        myObject.XAcceleration *= gravitationalConstant;
                        myObject.YAcceleration *= gravitationalConstant;

                        if (myObject.SolarSystem == null)
                        {
                            actualSecondsPerStep = secondsGalaxy;       // galaxy timing for the solar systems inside the galaxy
                        }
                        else
                        {
                            actualSecondsPerStep = secondsSolarSystem;
                        }

                        if (myObject.IsActive)
                        {
                            myObject.X += myObject.XSpeed * actualSecondsPerStep + 0.5 * myObject.XAcceleration * Math.Pow(actualSecondsPerStep, 2);
                            myObject.XSpeed += myObject.XAcceleration * actualSecondsPerStep;     // make movement using old speed first
                            myObject.Y += myObject.YSpeed * actualSecondsPerStep + 0.5 * myObject.YAcceleration * Math.Pow(actualSecondsPerStep, 2);
                            myObject.YSpeed += myObject.YAcceleration * actualSecondsPerStep;
                        }
                    }
                }
            }

            //            LogValuesRealtime(calculationsPerStepActual);

            foreach (GravityObject myObject in GravityObjects)
            {
                // update traces
                if (myObject.Trace)
                {
                    foreach (Trace trace in myObject.GetTraces())
                    {
                        if (trace != null)      // it happens..
                        {
                            trace.UpdateFrame();
                        }
                    }

                    myObject.AddTrace(myObject.X, myObject.Y);
                }
            }

            stopwatch.Stop();
            CalculationTime = stopwatch.ElapsedMilliseconds;
        }

        [ConditionalAttribute("DEBUG")]
        private void LogValuesRealtimeBegin(int calculationsPerStepActual)
        {
            if (!isFirstFrame)
            {
                return;
            }
            using (StreamWriter sr = new StreamWriter("logvaluesrealtime_begin" + calculationsPerStepActual.ToString() + ".txt"))
            {
                sr.WriteLine("calculationsPerStepActual: " + calculationsPerStepActual.ToString());
                sr.WriteLine("framenumber: 0");
                for (int k = 0; k < GravityObjects.Count; k++)
                {
                    sr.WriteLine("Objectnumber: " + k.ToString());
                    sr.WriteLine("X: " + GravityObjects[k].X.ToString());
                    sr.WriteLine("Y: " + GravityObjects[k].Y.ToString());
                    sr.WriteLine("XSpeed: " + GravityObjects[k].XSpeed.ToString());
                    sr.WriteLine("YSpeed: " + GravityObjects[k].YSpeed.ToString());
                    sr.WriteLine("-------------------");
                }

                sr.WriteLine("-------------------");
            }
        }

        [ConditionalAttribute("DEBUG")]
        private void LogValuesRealtime(int calculationsPerStepActual)
        {
            if (isFirstFrame)
            {
                isFirstFrame = false;
            }
            else
            {
                return;
            }
            using (StreamWriter sr = new StreamWriter("logvaluesrealtime" + calculationsPerStepActual.ToString() + ".txt"))
            {
                sr.WriteLine("framenumber: 1");
                for (int k = 0; k < GravityObjects.Count; k++)
                {
                    sr.WriteLine("Objectnumber: " + k.ToString());
                    sr.WriteLine("X: " + GravityObjects[k].X.ToString());
                    sr.WriteLine("Y: " + GravityObjects[k].Y.ToString());
                    sr.WriteLine("XSpeed: " + GravityObjects[k].XSpeed.ToString());
                    sr.WriteLine("YSpeed: " + GravityObjects[k].YSpeed.ToString());
                    sr.WriteLine("-------------------");
                }

                sr.WriteLine("-------------------");
            }
        }

        // at scale 1: 1000 pixels = 100,000 km -> 1 pixel = 100,000 m 
        public double ScreenToRealCoordinateX(double screen_x)
        {
            return (screen_x + OffsetX) * METERS_PER_PIXEL * scale;       // screen coords -> adjust offset (is not to scale yet) -> scale 
        }

        public double ScreenToRealCoordinateY(double screen_y)
        {
            return (screen_y + OffsetY) * METERS_PER_PIXEL * scale;       // screen coords -> adjust offset (is not to scale yet) -> scale 
        }

        public int RealtoScreenCoordinateX(double realX)
        {
            return (int)((realX / (METERS_PER_PIXEL * scale)) - OffsetX);              // scale -> adjust offset (is not to scale) -> screen coords
        }

        public int RealtoScreenCoordinateY(double realY)
        {
            return (int)((realY / (METERS_PER_PIXEL * scale)) - OffsetY);              // scale -> adjust offset (is not to scale) -> screen coords
        }

        public long ScaleCoordinateX(double realX, long newScale)
        {
            return (long)(realX / (METERS_PER_PIXEL * newScale));              // scale -> adjust offset (is not to scale) -> screen coords
        }

        public long ScaleCoordinateY(double realY, long newScale)
        {
            return (long)(realY / (METERS_PER_PIXEL * newScale));              // scale -> adjust offset (is not to scale) -> screen coords
        }

        // used to keep the center the same when zooming in/out with no object centered
        public void AdjustOffsetToNewScale(long newScale)
        {
            double realCenterX = ScreenToRealCoordinateX((ViewportWidth / 2));
            double realCenterY = ScreenToRealCoordinateY((ViewportHeight / 2));

            OffsetX = ScaleCoordinateX(realCenterX, newScale) - (ViewportWidth / 2);
            OffsetY = ScaleCoordinateY(realCenterY, newScale) - (ViewportHeight / 2);
        }

        public void ScrollToCenterImmediately()
        {
            currentScrollStep = 0;
            OffsetX = (long)((GravityObjects[centerIndex].AbsolutePositionX()) / (METERS_PER_PIXEL * scale)) - (ViewportWidth / 2);
            OffsetY = (long)((GravityObjects[centerIndex].AbsolutePositionY()) / (METERS_PER_PIXEL * scale)) - (ViewportHeight / 2);
        }

        private void ScrollToCenterSlowly()
        {
            // x always from -6 .. 6
            double x = -6 + 12 * ((SCROLL_STEPS-currentScrollStep) / (float)SCROLL_STEPS);
            double percentage = 1 / (1+Math.Exp(-x));
            OffsetX = (long)(percentage * targetOffsetX + (1 - percentage) * originalOffsetX);
            OffsetY = (long)(percentage * targetOffsetY + (1 - percentage) * originalOffsetY);
            currentScrollStep--;
            if(currentScrollStep==0)        // just to make sure we are really there (rounding errors)
            {
                OffsetX = (long)((GravityObjects[centerIndex].AbsolutePositionX()) / (METERS_PER_PIXEL * scale)) - (ViewportWidth / 2);
                OffsetY = (long)((GravityObjects[centerIndex].AbsolutePositionY()) / (METERS_PER_PIXEL * scale)) - (ViewportHeight / 2);
            }
        }

        public void CenterOnObject()
        {
            if (centerIndex > -1)
            {
                if (currentScrollStep==0)
                {
                    // Check if we need to scroll
                    if(offsetX != (long)((GravityObjects[centerIndex].AbsolutePositionX()) / (METERS_PER_PIXEL * scale)) - (ViewportWidth / 2)
                        || offsetY != (long)((GravityObjects[centerIndex].AbsolutePositionY()) / (METERS_PER_PIXEL * scale)) - (ViewportHeight / 2))
                    {
                        originalOffsetX = OffsetX;
                        originalOffsetY = OffsetY;
                        targetOffsetX = (long)((GravityObjects[centerIndex].AbsolutePositionX()) / (METERS_PER_PIXEL * scale)) - (ViewportWidth / 2);
                        targetOffsetY = (long)((GravityObjects[centerIndex].AbsolutePositionY()) / (METERS_PER_PIXEL * scale)) - (ViewportHeight / 2);
                        if (simulationRunning || simulationRunning)      // when the simulation is running, we don't want the animation
                        {
                            ScrollToCenterImmediately();
                        }
                        else
                        {
                            currentScrollStep = SCROLL_STEPS;
                        }
                    }
                }
                else
                {
                    ScrollToCenterSlowly();
                }
            }
        }

        public double MetersToPixels(double meter)
        {
            return meter / (METERS_PER_PIXEL * scale);
        }

        public double PixelsToMeters(double pixel)
        {
            return pixel * (METERS_PER_PIXEL * scale);
        }

        public GravityObject AddObject(string name_, double mass_, double x_, double y_, double xSpeed_, double ySpeed_, Texture2D texture_, bool trace_, bool vector_, bool scaleObject_ = true, double rotationSpeed_ = 0)
        {
            Color color_ = Color.White;
            return AddObject(name_, mass_, x_, y_, xSpeed_, ySpeed_, texture_, color_, trace_, vector_, scaleObject_, rotationSpeed_);
        }

        // Adds an object. If it is near another object, they will be part of a new "solar system" object.
        // @param insertBefore  is used to keep the sun on top of the planets and moons
        public GravityObject AddObject(string name_, double mass_, double x_, double y_, double xSpeed_, double ySpeed_, Texture2D texture_, Color color_, bool trace_, bool vector_, bool scaleObject_ = true, double rotationSpeed_ = 0, bool mayAddToSolarSystem = true)
        {
            if (GravityObjects.Count == 0)     // center the first object
            {
                centerIndex = 0;
            }
            GravityObject newObject = new GravityObject(name_, mass_, x_, y_, xSpeed_, ySpeed_, texture_, color_, trace_, scale, vector_, scaleObject_, rotationSpeed_);
            numVisibleObjects++;
            if (mayAddToSolarSystem)
            {
                AddToSolarSystem(newObject);
            }
            GravityObjects.Add(newObject);

            DetermineCalculationsPerStepActual();

            ScaleObject(newObject);

            return newObject;
        }

        // Returns a unique (numbered) name for a solar system
        public string FindUniqueSolarsystemName(string name)
        {
            string result = name;
            int count = 1;
            while (GravityObjects.Exists(item => item.SolarSystem != null && item.SolarSystem.Name == result))
            {
                count++;
                result = name + count.ToString();
            }

            return result;
        }

        private GravityObject FindCloseObject(GravityObject newObject)
        {
            foreach (GravityObject myObject in GravityObjects)
            {
                // Proxima centauri <-> Alpha centauri = 1986810000000000 m
                // an object closer than 2000000000000000 m means that it is the same solar system
                // 2000000000000000 m squared = 4000000000000000000000000000000
                if (Math.Pow(myObject.AbsolutePositionX()-newObject.X, 2)+ Math.Pow(myObject.AbsolutePositionY() - newObject.Y, 2) < 4000000000000000000000000000000.0)
                {
                    return myObject;
                }
            }

            return null;
        }

        private void AddToSolarSystem(GravityObject newObject)
        {
            GravityObject closeObject = FindCloseObject(newObject);
            if(closeObject!=null)
            {
                if(closeObject.SolarSystem==null)
                {
                    GravityObject solarSystem = new GravityObject(FindUniqueSolarsystemName("SolarSystem"), closeObject.X, closeObject.Y, closeObject.Mass);
                    GravityObjects.Add(solarSystem);
                    closeObject.SolarSystem = solarSystem;
                    // Set the position of the Solar System. Note that Center of Mass would maybe be better, but it's a hassle to update it every time a planet is added.
                    closeObject.SolarSystem.X = closeObject.X;
                    closeObject.SolarSystem.Y = closeObject.Y;
                    // Make the planet position relative to the solar system
                    closeObject.X = 0;
                    closeObject.Y = 0;
                }
                // Make new object position relative to the solar system center
                newObject.X -= closeObject.SolarSystem.X;
                newObject.Y -= closeObject.SolarSystem.Y;

                closeObject.SolarSystem.AddObject(newObject);
            }
        }

        void AdjustSolarSystemPositions(GravityObject solarSystem, double x_adjust, double y_adjust)
        {
            foreach (GravityObject myObject in GravityObjects)
            {
                if(myObject.SolarSystem==solarSystem)
                {
                    myObject.X += x_adjust;
                    myObject.Y += y_adjust;
                }
            }
        }

        // Find the object that had the most gravitational pull on X, Y
        public GravityObject findBestHost(GravityObject newObject)
        {
            GravityObject hostObject = null;
            double greatest_pull = 0;
            foreach (GravityObject thisObject in GravityObjects)
            {
                double pull = thisObject.Mass / (Math.Pow(newObject.X - thisObject.X, 2) + Math.Pow(newObject.Y - thisObject.Y, 2));
                if (!newObject.Equals(thisObject) && newObject.SolarSystem==thisObject.SolarSystem && (hostObject == null || pull > greatest_pull))
                {
                    greatest_pull = pull;
                    hostObject = thisObject;
                }
            }

            return hostObject;
        }


        public GravityObject PreviousObject()
        {
            VisibleObjectsIndex--;
            if (VisibleObjectsIndex < 1)
            {
                VisibleObjectsIndex = CountVisibleObjects();
            }

            do
            {
                objectIndex--;
                if (objectIndex < 0)
                {
                    objectIndex = GravityObjects.Count - 1;
                }
            } while (GravityObjects[objectIndex].NumObjects > 0);     // skip solar systems

            return GravityObjects[objectIndex];
        }


        public GravityObject NextObject()
        {
            VisibleObjectsIndex++;
            if (VisibleObjectsIndex > CountVisibleObjects())
            {
                VisibleObjectsIndex = 1;
            }

            do
            {
                objectIndex++;
                if (objectIndex >= GravityObjects.Count)
                {
                    objectIndex = 0;
                }
            } while (GravityObjects[objectIndex].NumObjects > 0);     // skip solar systems

            return GravityObjects[objectIndex];
        }


        public GravityObject PreviousGalaxyObject()
        {
            GravityObject startObject = GravityObjects[objectIndex];
            GravityObject previousObject;
            do
            {
                VisibleObjectsIndex--;
                if (VisibleObjectsIndex < 1)
                {
                    VisibleObjectsIndex = CountVisibleObjects();
                }

                previousObject = GravityObjects[objectIndex];
                do
                {
                    objectIndex--;
                    if (objectIndex < 0)
                    {
                        objectIndex = GravityObjects.Count - 1;
                    }
                } while (GravityObjects[objectIndex].NumObjects > 0);     // skip solar systems 
                // Continue until we find a galaxy object or solar system object with another solar system
            } while (GravityObjects[objectIndex].SolarSystem != null && GravityObjects[objectIndex].SolarSystem.Equals(previousObject.SolarSystem) && !GravityObjects[objectIndex].Equals(startObject));

            return GravityObjects[objectIndex];
        }


        public GravityObject NextGalaxyObject()
        {
            GravityObject startObject = GravityObjects[objectIndex];
            GravityObject previousObject;
            do
            {
                VisibleObjectsIndex++;
                if (VisibleObjectsIndex > CountVisibleObjects())
                {
                    VisibleObjectsIndex = 1;
                }

                previousObject = GravityObjects[objectIndex];
                do
                {
                    objectIndex++;
                    if (objectIndex >= GravityObjects.Count)
                    {
                        objectIndex = 0;
                    }
                } while (GravityObjects[objectIndex].NumObjects > 0);     // skip solar systems 
                // Continue until we find a galaxy object or solar system object with another solar system
            } while (GravityObjects[objectIndex].SolarSystem!=null && GravityObjects[objectIndex].SolarSystem.Equals(previousObject.SolarSystem) && !GravityObjects[objectIndex].Equals(startObject));

            return GravityObjects[objectIndex];
        }

        public int GetVisibleObjectIndex()
        {
            visibleObjectsIndex = 1;
            for(int k=0; k<objectIndex; k++)
            {
                if(GravityObjects[k].NumObjects==0)      // skip Solar Systems
                {
                    visibleObjectsIndex++;
                }
            }

            return visibleObjectsIndex;
        }

        public int CountVisibleObjects()
        {
            return GravityObjects.Count(item => item.NumObjects == 0);
        }

        public GravityObject CurrentObject()
        {
            return GravityObjects[objectIndex];
        }

        public bool IsCurrentObjectedCenter()
        {
            return objectIndex == centerIndex;
        }

        public void ScaleCurrentObject()
        {
            ScaleObject(GravityObjects[objectIndex]);
        }

        // Sets the internal scale of the object, based on the current scale of the system
        public void ScaleObject(GravityObject o)
        {
            float scale_ = 7.368f + (Scale / 1000.0f);        // increase divide value to have bigger textures at higher scales
            if (Scale < 33)
            {
                scale_ = 1 + (Scale / 5.0f);        // increase divide value to have bigger textures at higher scales
            }
            if (o.ScaleTexture)
            {
                if (o.Texture.Width < minimumTextureSize)
                {
                    return;       // scaling not possible
                }
                if (o.Texture.Width / scale_ < minimumTextureSize)
                {
                    scale_ = o.Texture.Width / minimumTextureSize;
                }
                if (o.Texture.Height / scale_ < minimumTextureSize)
                {
                    scale_ = o.Texture.Height / minimumTextureSize;
                }
                o.ScaledTextureWidth = (int)(o.Texture.Width / scale_);
                o.ScaledTextureHeight = (int)(o.Texture.Height / scale_);
            }
        }

        public void ScaleObjects()
        {
            foreach (GravityObject o in GravityObjects)
            {
                ScaleObject(o);
            }
        }

        public double DistanceCurrentObjectZeroObject()
        {
            return Math.Sqrt(Math.Pow(GravityObjects[0].X - GravityObjects[objectIndex].X, 2) + Math.Pow(GravityObjects[0].Y - GravityObjects[objectIndex].Y, 2)) / 1000;
        }

        public void StabilizeObjectsSpeeds(int startPosition, bool rotateCounterClockWise)
        {
            double TotalMass = 0;
            double centerMassX = 0;
            double centerMassY = 0;
            secondsSolarSystem = (double)CalculationSecondsPerFrame / calculationsPerStepActual;
            secondsGalaxy = secondsSolarSystem * TIME_GALAXY_INCREASE_FACTOR;

            // // STEP 1: determine center of mass
            for (int k = startPosition; k < GravityObjects.Count; k++)
            {
                GravityObject o = GravityObjects[k];
                centerMassX = (centerMassX * TotalMass + o.X * o.Mass) / (o.Mass + TotalMass);
                centerMassY = (centerMassY * TotalMass + o.Y * o.Mass) / (o.Mass + TotalMass);
                TotalMass += o.Mass;
            }

            for (int k = startPosition; k < GravityObjects.Count; k++)
            {
                GravityObject myObject = GravityObjects[k];

                // Skip solar system objects (they are already moved by their parent object)
                if(myObject.SolarSystem!=null)
                {
                    continue;
                }

                // STEP 2: determine force acting on object
                Object2D acceleration = CalculateObjectAcceleration(GravityObjects[k], startPosition);

                acceleration.X *= gravitationalConstant;        // note: this the acceleration per second, so we don't need to take into account the secondsPerStep
                acceleration.Y *= gravitationalConstant;        // note: this the acceleration per second, so we don't need to take into account the secondsPerStep

                // not strictly necessary, but now we have the accelerations, we might as well set it..
                myObject.XAcceleration = acceleration.X;
                myObject.YAcceleration = acceleration.Y;

                double angle_center_of_mass = Math.Atan2(centerMassY - myObject.Y, centerMassX - myObject.X);      // angle with positive X axis

                // STEP 3: determine force proportional in direction of center of mass (the force can be pointing at another direction than the center of mass)
                //                double angle_force = Math.Atan2(acceleration.Y, acceleration.X);      // angle with positive X axis
                //                double angle_difference = MathHelper.WrapAngle((float)(angle_force - angle_center_of_mass));
                //                double centripetal_force = acceleration * Math.Abs(Math.Sin(angle_difference));

                // STEP 4: set the speed at 90 degrees with center of mass
                double radius = Math.Sqrt(Math.Pow(centerMassX - myObject.X, 2) + Math.Pow(centerMassY - myObject.Y, 2));
                double EscapeVelocity = Math.Sqrt(/*centripetal_force*/Math.Sqrt(Math.Pow(acceleration.X, 2) + Math.Pow(acceleration.Y, 2)) * radius);

                angle_center_of_mass -= (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
                if (rotateCounterClockWise)
                {
                    angle_center_of_mass -= Math.PI;       // rotate 180 an extra degrees
                }
                Vector speed = new Vector();
                myObject.XSpeed = Math.Cos(angle_center_of_mass) * EscapeVelocity;
                myObject.YSpeed = Math.Sin(angle_center_of_mass) * EscapeVelocity;
            }

        }

        public Vector CalculateSpeedByHost(GravityObject myObject)
        {
            Vector speed = new Vector();
            GravityObject hostObject = findBestHost(myObject);
            if(hostObject == null)      // no host (yet); use zero speed
            {
                return speed;
            }
            double radius = Math.Sqrt(Math.Pow(hostObject.X - myObject.X, 2) + Math.Pow(hostObject.Y - myObject.Y, 2));
            double EscapeVelocity = Math.Sqrt((gravitationalConstant * hostObject.Mass) / radius);

            double angle = Math.Atan2(hostObject.Y - myObject.Y, hostObject.X - myObject.X);
            angle -= (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
            speed.X = Math.Cos(angle) * EscapeVelocity;
            speed.Y = Math.Sin(angle) * EscapeVelocity;

            return speed;
        }

        public void SetSpeedByHost(GravityObject myObject)
        {
            Vector speed = CalculateSpeedByHost(myObject);
            myObject.SetSpeed(speed);
        }

        [ConditionalAttribute("DEBUG")]
        private void LogValues(int calculationsPerStepNeededPower)
        {
            using (StreamWriter sr = new StreamWriter("logvalues" + Math.Pow(10, calculationsPerStepNeededPower) + ".txt"))
            {
                for (frameNumberCalc = 0; frameNumberCalc <= NumPrecalculatedFrames(); frameNumberCalc++)
                {
                    sr.WriteLine("Framenumber: " + frameNumberCalc.ToString());
                    for (int k = 0; k < GravityObjects.Count; k++)
                    {
                        sr.WriteLine("Objectnumber: " + k.ToString());
                        sr.WriteLine("X: " + Calculation[frameNumberCalc][k].X.ToString());
                        sr.WriteLine("Y: " + Calculation[frameNumberCalc][k].Y.ToString());
                        sr.WriteLine("-------------------");
                    }

                    sr.WriteLine("-------------------");
                }

            }
        }


        public void PreCalculate(BackgroundWorker backgroundWorkerPreCalculate, DoWorkEventArgs e)
        {
            while (FrameNumberCalc <= NumPrecalculatedFrames() && GravityObjects.Count > 1)
            {
                if (CalculateFrame(backgroundWorkerPreCalculate, e))
                {
                    return;
                }
                FrameNumberCalc++;
            }
            for (int k = 0; k < GravityObjects.Count; k++)
            {
                CalculationCurrentSpeeds[k].X = CalculationInitialSpeeds[k].X;
                CalculationCurrentSpeeds[k].Y = CalculationInitialSpeeds[k].Y;
            }
            //                LogValues(calculationsPerStepNeededPower);
        }

        public List<GravityObject> GetSolarSystems()
        {
            List<GravityObject> solarSystems = new List<GravityObject>();
            foreach(GravityObject o in GravityObjects)
            {
                if (o.NumObjects > 0)
                    solarSystems.Add(o);
            }

            return solarSystems;
        }

        public bool CalculateFrame(BackgroundWorker backgroundWorkerPreCalculate, DoWorkEventArgs e) 
        {
            // reset position to previous frame; we are making a new calculation for this frame only
            for (int k = 0; k < GravityObjects.Count; k++)
            {
                Calculation[frameNumberCalc][k].X = Calculation[frameNumberCalc - 1][k].X;
                Calculation[frameNumberCalc][k].Y = Calculation[frameNumberCalc - 1][k].Y;
            }

            // First handle all galaxy objects
            for (int i = 0; i < calculationsPerStepPrecalculatedGalaxy; i++)
            {
                if (UseBarnesHut)
                {
                    if (GravityObjects.Count > 0)
                    {
                        QuadTree.SecondsInCalculation = secondsGalaxy;
                        QuadTree.Create(Calculation, GravityObjects, frameNumberCalc, backgroundWorkerPreCalculate, e, message);
                        QuadTree.CalculateValues(Calculation, CalculationCurrentAccelerations, frameNumberCalc, backgroundWorkerPreCalculate, e, AccelerationLimit, message);
                    }
                }
                else
                {
                    try
                    {
                        for (int myObjectNumber = 0; myObjectNumber < GravityObjects.Count; myObjectNumber++)
                        {
                            if (GravityObjects[myObjectNumber].SolarSystem != null)
                            {
                                CalculateFrameObject(myObjectNumber);
                                if (backgroundWorkerPreCalculate.CancellationPending)
                                {
                                    // Set the e.Cancel flag so that the WorkerCompleted event
                                    // knows that the process was cancelled.
                                    e.Cancel = true;
                                    return true;
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Exception at CalculateFrame(): " + ex.Message);
                    }
                }

                // make a step using the new acceleration
                MakeStepPrecalculated(false);
            }

            // Second handle all solar system objects
            for (int i = 0; i < calculationsPerStepPrecalculatedSolar; i++)
            {
                try
                {
                    for (int myObjectNumber = 0; myObjectNumber < GravityObjects.Count; myObjectNumber++)
                    {
                        if (GravityObjects[myObjectNumber].SolarSystem != null)
                        {
                            CalculateFrameObject(myObjectNumber);
                            if (backgroundWorkerPreCalculate.CancellationPending)
                            {
                                // Set the e.Cancel flag so that the WorkerCompleted event
                                // knows that the process was cancelled.
                                e.Cancel = true;
                                return true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception at CalculateFrame(): " + ex.Message);
                }

                // make a step using the new acceleration
                MakeStepPrecalculated(true);
            }

            return false;
        }

        private void MakeStepPrecalculated(bool solarSystem)
        {
            double secondsPerStep = solarSystem ? (double)CalculationSecondsPerFrame / calculationsPerStepPrecalculatedSolar : (double)CalculationSecondsPerFrame * TIME_GALAXY_INCREASE_FACTOR / calculationsPerStepPrecalculatedGalaxy;
            for (int k = 0; k < GravityObjects.Count; k++)
            {
                if ((solarSystem && GravityObjects[k].SolarSystem != null) || (!solarSystem && GravityObjects[k].SolarSystem == null))
                {
                    Object2D myCalculation = Calculation[frameNumberCalc][k];

                    if (GravityObjects[k].IsActive)
                    {
                        myCalculation.X += CalculationCurrentSpeeds[k].X * secondsPerStep + 0.5 * CalculationCurrentAccelerations[k].X * Math.Pow(secondsPerStep, 2);
                        myCalculation.Y += CalculationCurrentSpeeds[k].Y * secondsPerStep + 0.5 * CalculationCurrentAccelerations[k].Y * Math.Pow(secondsPerStep, 2);
                        CalculationCurrentSpeeds[k].X += CalculationCurrentAccelerations[k].X * secondsPerStep;
                        CalculationCurrentSpeeds[k].Y += CalculationCurrentAccelerations[k].Y * secondsPerStep;
                        //                    Debug.Write("Object: " + k + "acc. X: " + CalculationCurrentAccelerations[k].X + " acc. Y:" + CalculationCurrentAccelerations[k].Y + "\r\n");
                    }
                }
            }
        }

        private void CalculateFrameObject(int myObjectNumber)
        {
            Object2D myCalculation = Calculation[frameNumberCalc][myObjectNumber];      // Start with old value
            double acceleration_x = 0;
            double acceleration_y = 0;
            for (int otherObjectNumber = 0; otherObjectNumber < GravityObjects.Count; otherObjectNumber++)
            {
                // exclude own object (may be not neccesary because distance radius is checked later on)
                if (otherObjectNumber != myObjectNumber && ((GravityObjects[myObjectNumber].SolarSystem == null && GravityObjects[otherObjectNumber].SolarSystem == null) || (GravityObjects[myObjectNumber].SolarSystem == GravityObjects[otherObjectNumber].SolarSystem)))    // only objects of the same type
                {
                    Object2D otherCalculation = Calculation[frameNumberCalc][otherObjectNumber];

                    double x_difference = otherCalculation.X - myCalculation.X;
                    double y_difference = otherCalculation.Y - myCalculation.Y;

                    double acceleration = CalculateObjectAcceleration(x_difference, y_difference, GravityObjects[myObjectNumber], GravityObjects[otherObjectNumber]);

                    // divide acceleration in X and Y component
                    double angle = Math.Atan2(y_difference, x_difference);      // angle with positive X axis
                    acceleration_x += Math.Cos(angle) * acceleration;
                    acceleration_y += Math.Sin(angle) * acceleration;
                }
            }

            acceleration_x *= gravitationalConstant;
            acceleration_y *= gravitationalConstant;

            //                        double accelerationAngle = Math.Atan2(acceleration_y, acceleration_x);

            CalculationCurrentAccelerations[myObjectNumber].X = acceleration_x;
            CalculationCurrentAccelerations[myObjectNumber].Y = acceleration_y;
        }

        public void DisplayFrame()
        {
            for (int k = 0; k < Calculation[0].Length; k++)
            {
                GravityObject myObject = GravityObjects[k];
                myObject.X = Calculation[frameNumberPlay][k].X;
                myObject.Y = Calculation[frameNumberPlay][k].Y;
            }
        }

        // Return true if last reached frame (to rewind)
        public bool PlayOneFrame()
        {
            if( Calculation==null || Calculation[0].Length<GravityObjects.Count)
            {
                return false;    // There can be just one object added while the Calculation array had not been expanded yet.
            }

            for (int k = 0; k < Calculation[0].Length; k++)     
            {

                GravityObject myObject = GravityObjects[k];
                myObject.X = Calculation[frameNumberPlay][k].X;
                myObject.Y = Calculation[frameNumberPlay][k].Y;
                // Because speeds and accelerations are not stored for performance reasons, they need to be reverse engineered
                if (frameNumberPlay > 0)
                {
                    myObject.XSpeed = (myObject.X - Calculation[frameNumberPlay - 1][k].X) / CalculationSecondsPerFrame;
                    myObject.YSpeed = (myObject.Y - Calculation[frameNumberPlay - 1][k].Y) / CalculationSecondsPerFrame;
                }
                else
                {
                    myObject.XSpeed = CalculationInitialSpeeds[k].X;
                    myObject.YSpeed = CalculationInitialSpeeds[k].Y;
                }

                if (frameNumberPlay < NumPrecalculatedFrames() - 1)
                {
                    myObject.XAcceleration = ((Calculation[frameNumberPlay + 1][k].X - Calculation[frameNumberPlay][k].X) / CalculationSecondsPerFrame - myObject.XSpeed) / CalculationSecondsPerFrame;
                    myObject.YAcceleration = ((Calculation[frameNumberPlay + 1][k].Y - Calculation[frameNumberPlay][k].Y) / CalculationSecondsPerFrame - myObject.YSpeed) / CalculationSecondsPerFrame;
                }
            }

            foreach (GravityObject myObject in GravityObjects)
            {
                // update traces
                if (myObject.Trace)
                {
                    foreach (Trace trace in myObject.GetTraces())
                    {
                        if (trace != null)      // it happens..
                        {
                            trace.UpdateFrame();
                        }
                    }

                    myObject.AddTrace(myObject.X, myObject.Y);
                }
            }

            frameNumberPlay++;
            if(frameNumberPlay>=NumPrecalculatedFrames())        // Rewind to beginning
            {
                return true;
            }

            return false;
        }

        // Called when calculation needs to start from the beginning:
        //  - when the record button is pressed (and there is no running calculation)
        //  - when a recording is loaded
        //  - when the number of objects changes
        //  - when precalculation settings change (preferences or speed)
        //  - when an objects is updated
        public void InitCalculation()
        {
            StopCalculation();

            Calculation = new Object2D[NumPrecalculatedFrames() + 1][];         // one extra for begin situation
            for (int frame = 0; frame <= NumPrecalculatedFrames(); frame++)
            {
                Calculation[frame] = new Object2D[GravityObjects.Count];
                
                // Disable when using structs:
                for (int objectnumber = 0; objectnumber < GravityObjects.Count; objectnumber++)
                {
                    Calculation[frame][objectnumber] = new Object2D();
                }
                
            }
            CalculationInitialSpeeds = new Vector[GravityObjects.Count];
            CalculationCurrentSpeeds = new Vector[GravityObjects.Count];
            CalculationCurrentAccelerations = new Vector[GravityObjects.Count];
            for (int objectnumber = 0; objectnumber < GravityObjects.Count; objectnumber++)
            {
                Calculation[0][objectnumber].X = GravityObjects[objectnumber].X;
                Calculation[0][objectnumber].Y = GravityObjects[objectnumber].Y;
                CalculationInitialSpeeds[objectnumber] = new Vector();
                CalculationCurrentSpeeds[objectnumber] = new Vector();
                CalculationCurrentAccelerations[objectnumber] = new Vector();
                CalculationInitialSpeeds[objectnumber].X = CalculationCurrentSpeeds[objectnumber].X = GravityObjects[objectnumber].XSpeed;
                CalculationInitialSpeeds[objectnumber].Y = CalculationCurrentSpeeds[objectnumber].Y = GravityObjects[objectnumber].YSpeed;
            }
            QuadTree.DetermineBoundingBox(GravityObjects);
            frameNumberCalc = 1;         // Frame 0 is the unmodified starting situation
            frameNumberPlay = 0;

            StartCalculation();
        }

        // Called when a running calculation needs to be stopped:
        //  - when the number of objects changes (first stop, then change objects, then resume with initcalculation())
        //  - when the "stop recording" button is pressed
        //  - when a recording is saved
        //  - whenever initcalculation() is called (to make sure the are no running calculations)
        public void StopCalculation()
        {
            if (IsCalculating)
            {
                if (backgroundWorkerPreCalculate.IsBusy)
                {
                    backgroundWorkerPreCalculate.CancelAsync();
                }

                System.Threading.Thread.Sleep(1000);        // Give the calculations some time to finish
            }
        }

        // Called when a calculation needs to be resumed:
        //  - after loading a recording
        //  - after saving a recording (it was stopped to write a current recording)
        //  - when the "start recording" button is pressed
        //  - whenever initcalculation() is called (to resume recording when that was the case before)
        public void StartCalculation()
        {
            if (!IsCalculating && IsRecording && frameNumberCalc < NumPrecalculatedFrames())
            {
                IsCalculating = true;
                backgroundWorkerPreCalculate = new BackgroundWorker();
                backgroundWorkerPreCalculate.WorkerReportsProgress = true;
                backgroundWorkerPreCalculate.WorkerSupportsCancellation = true;
                backgroundWorkerPreCalculate.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerPreCalculate_DoWork);

                backgroundWorkerPreCalculate.RunWorkerAsync();
            }
        }

        private void backgroundWorkerPreCalculate_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                PreCalculate(backgroundWorkerPreCalculate, e);
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }
            finally
            {
                IsCalculating = false;
            }
        }

        public Calculation[][] ResizeArray<Calculation>(Calculation[][] original, int rows) where Calculation : new()
        {
            var newArray = new Calculation[rows][];
            for (int i = 0; i < rows; i++)
            {
                newArray[i] = new Calculation[original[0].Length];
                for (int j = 0; j < original[0].Length; j++)
                {
                    newArray[i][j] = new Calculation();
                    if (i < original.Length)
                    {
                        newArray[i][j] = original[i][j];
                    }
                }
            }

            return newArray;
        }

        public void AdjustNumberOfCalculations(int newPreCalculationTime)
        {
            int newNumPrecalculatedFrames = newPreCalculationTime * targetFrameRate;

            if (calculation!=null && newNumPrecalculatedFrames != NumPrecalculatedFrames())
            {
                calculation = ResizeArray<Object2D>(calculation, newNumPrecalculatedFrames + 1);
            }

            if (frameNumberCalc >= newNumPrecalculatedFrames)
            {
                frameNumberCalc = newNumPrecalculatedFrames - 1;
            }
            if (frameNumberPlay >= newNumPrecalculatedFrames)
            {
                frameNumberPlay = newNumPrecalculatedFrames - 1;
            }

            preCalculationTime = newPreCalculationTime;

            CalculationsPerStepPrecalculatedGalaxy = 1;   // This makes sure the pre-calculation job will run to add the new frames
        }

        // converts a solar mass to 10^22 kg
        public double SolarMassToKg(double solarMass)
        {
            return solarMass * 198900000.0;
        }

        // converts a jupiter mass to 10^22 kg
        public double JupiterMassToKg(double jupiterMass)
        {
            return jupiterMass * 189813;
        }
        
        // converts an earth mass to 10^22 kg
        public double EarthMassToKg(double earthMass)
        {
            return earthMass * 597.22;
        }


        public double LightYearsToMeters(double lightyears)
        {
            return lightyears * 9461000000000000;
        }

        public double AUToMeters(double au)
        {
            return au * 149597870700;
        }

        public List<GravityObject> getSolarSystemObjects(GravityObject solarSystem)
        {
            List<GravityObject> objects = new List<GravityObject>();
            foreach (GravityObject o in GravityObjects)
            {
                if (o.SolarSystem!=null && o.SolarSystem.Equals(solarSystem))
                {
                    objects.Add(o);
                }
            }

            return objects;
        }

        class NameValue
        {
            string name;
            double value;

            public NameValue(string name, double value)
            {
                this.Name = name;
                this.Value = value;
            }

            public string Name { get => name; set => name = value; }
            public double Value { get => value; set => this.value = value; }
        }

        public object[] GetCurrentObjectInfluencedBy()
        {
            List<NameValue> influenceList = new List<NameValue>();

            for (int l = 0; l < GravityObjects.Count; l++)
            {
                GravityObject otherObject = GravityObjects[l];
                if (otherObject != CurrentObject() && ((CurrentObject().SolarSystem == null && otherObject.SolarSystem == null) || (CurrentObject().SolarSystem == otherObject.SolarSystem)))    // only objects of the same type
                {
                    double x_difference = otherObject.X - CurrentObject().X;
                    double y_difference = otherObject.Y - CurrentObject().Y;
                    double tmp_acceleration = CalculateObjectAcceleration(x_difference, y_difference, CurrentObject(), otherObject);
                    influenceList.Add(new NameValue(otherObject.Name, tmp_acceleration));
                }
            }
            // sort
            influenceList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            List<string> items = new List<string>();
            foreach(NameValue item in influenceList.Take(8))
            {
                items.Add(item.Name + " : " + string.Format("{0:G5}", item.Value));
            }

            return items.ToArray();
        }

    }
}
