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
    static class GravitySystem
    {
        static int minimumTextureSize = 11;

        static List<GravityObject> gravityObjects = new List<GravityObject>();
        static int objectIndex = -1;
        static int centerIndex = -1;
        static int targetFrameRate = 40;       // target FPS
        static long scale = 50;      // 1m = 1,000,000*[scale]m
        static long offsetX;        // offset in SCREEN coordinates
        static long offsetY;        // offset in SCREEN coordinates
        static int viewportWidth;
        static int viewportHeight;
        static double timeNeedForOneCalculation;
        static long calculationTime;
        static int calculationsPerStepSetting = 10000;
        static int calculationsPerStepActual = 100;
        static int frameNumberPlay = 0;
        static bool isFirstFrame = true;
        static double gravitationalConstant = 667408000000;
        static double accelerationLimit = 0.0000000001;

        // Pre-calculation
        static Calculation[][] calculation;
        static Vector[] calculationInitialSpeeds;
        static Vector[] calculationCurrentSpeeds;
        static Vector[] calculationCurrentAccelerations;
        static int preCalculationTime = 20;        // Timespan (seconds) of precalculated period (this period is pre-calculated with increasing precision over time)
        static int calculationsPerStepPrecalculated = 1;
        static int preCalculationIncreaseFactor = 10;
        static int frameNumberCalc = 1;         // Frame 0 is the unmodified starting situation
        static long calculationSecondsPerFrame;
        static bool isCalculating = false;
        static private System.ComponentModel.BackgroundWorker backgroundWorkerPreCalculate;
        static bool precalcAutoIncrease = false;

        // Barnes-Hut approximation
        static QuadTree quadTree = new QuadTree();
        static bool useBarnesHut = true;

        // used for color coding galaxies
        static double minSpeed;
        static double maxSpeed;
        static double minAcceleration;
        static double maxAcceleration;
        static double speedRange = 0;
        static double accelerationRange = 0;

        static Message message = new Message();

        static public int NumPrecalculatedFrames()
        {
            return preCalculationTime * targetFrameRate;
        }

        static public void SelectObjectAtMousePointer(int x, int y)
        {
            objectIndex = FindClosestObject(ScreenToRealCoordinateX(x), ScreenToRealCoordinateY(y));
        }

        static private int FindClosestObject(double x, double y)
        {
            int closestObjectIndex = -1;
            double closestDistance = double.MaxValue;
            for (int k = 0; k < gravityObjects.Count; k++)
            {
                GravityObject o = gravityObjects[k];
                double distance = Math.Sqrt(Math.Pow((o.X - x), 2) + Math.Pow((o.Y - y), 2));
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestObjectIndex = k;
                }
            }

            return closestObjectIndex;
        }

        static public void ObtainMinMaxValues()
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

        static public long OffsetY
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

        static public long OffsetX
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

        static public long Scale
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

        static public int ObjectIndex
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

        static public int CenterIndex
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

        static public int CalculationsPerStepSetting
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

        static public int CalculationsPerStepActual
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

        static public int TargetFrameRate
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

        static public int PreCalculationTime
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

        static internal Calculation[][] Calculation
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

        static public int FrameNumberPlay
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

        static public int CalculationsPerStepPrecalculated
        {
            get
            {
                return calculationsPerStepPrecalculated;
            }

            set
            {
                calculationsPerStepPrecalculated = value;
            }
        }

        static public int FrameNumberCalc
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

        static public bool IsCalculating
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

        static public BackgroundWorker BackgroundWorkerPreCalculate
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

        static public int PreCalculationIncreaseFactor
        {
            get
            {
                return preCalculationIncreaseFactor;
            }

            set
            {
                preCalculationIncreaseFactor = value;
            }
        }

        static public double GravitationalConstant
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

        static public double MinSpeed
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

        static public double MaxSpeed
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

        static public double MinAcceleration
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

        static public double MaxAcceleration
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

        static public double SpeedRange
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

        static public double AccelerationRange
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

        static internal QuadTree QuadTree
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

        static public bool UseBarnesHut
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

        static public long CalculationSecondsPerFrame
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

        static internal List<GravityObject> GravityObjects
        {
            get
            {
                return gravityObjects;
            }

            set
            {
                gravityObjects = value;
            }
        }

        static internal Vector[] CalculationInitialSpeeds
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

        static internal Vector[] CalculationCurrentSpeeds
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

        static internal Vector[] CalculationCurrentAccelerations
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

        static public int MinimumTextureSize
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

        static public bool PrecalcAutoIncrease
        {
            get
            {
                return precalcAutoIncrease;
            }

            set
            {
                precalcAutoIncrease = value;
            }
        }

        static public double AccelerationLimit
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

        static internal Message Message
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

        static public void DetermineTimeNeedForOneCalculation(GraphicsDevice dev)
        {
            Random rnd = new Random();
            Texture2D textureTest = new Texture2D(dev, 1, 1);
            Color[] az = Enumerable.Range(0, 1).Select(i => new Color(255, 255, 255, 100)).ToArray();
            textureTest.SetData(az);

            Stopwatch stopwatch = Stopwatch.StartNew();     //creates and start the instance of Stopwatch

            for (int k = 0; k < 100000; k++)
            {
                GravityObject myObject = new GravityObject("testobject1", rnd.NextDouble() - .5 * 20000, rnd.NextDouble() - .5 * 20000, rnd.NextDouble() - .5 * 20000, rnd.NextDouble() - .5 * 20000, rnd.NextDouble() - .5 * 20000, textureTest, Color.White, true, 100, true);
                double acceleration_x = 0;
                double acceleration_y = 0;
                GravityObject otherObject = new GravityObject("testobject2", rnd.NextDouble() - .5 * 20000, rnd.NextDouble() - .5 * 20000, rnd.NextDouble() - .5 * 20000, rnd.NextDouble() - .5 * 20000, rnd.NextDouble() - .5 * 20000, textureTest, Color.White, true, 100, true);
                if (3 != 4)
                {
                    double x_difference = otherObject.X - myObject.X;
                    double y_difference = otherObject.Y - myObject.Y;
                    double square_radius = Math.Pow(x_difference, 2) + Math.Pow(y_difference, 2);
                    if (square_radius == 0)
                    {
                        // objects exactly on top of each other; bail out to prevent division by zero
                        continue;
                    }
                    double acceleration = otherObject.Mass / square_radius;

                    // cap on acceleration
                    double capacity = AccelerationLimit / 10000000;
                    if (acceleration > capacity)
                    {
                        acceleration = capacity;
                    }
                    if (acceleration < -capacity)
                    {
                        acceleration = -capacity;
                    }

                    // divide acceleration in X and Y component
                    double angle = Math.Atan2(y_difference, x_difference);      // angle with positive X axis
                    acceleration_x += Math.Cos(angle) * acceleration;
                    acceleration_y += Math.Sin(angle) * acceleration;
                }
            }

            stopwatch.Stop();
            timeNeedForOneCalculation = stopwatch.ElapsedMilliseconds / 100000.0;
        }

        static public void DetermineCalculationsPerStepActual()
        {
            calculationsPerStepActual = calculationsPerStepSetting;
            if (calculationsPerStepSetting == -1)
            {
                if (GravityObjects.Count > 1)       // with one object, time will still be zero
                {
                    double totalTimeNeeded = timeNeedForOneCalculation * GravityObjects.Count * (GravityObjects.Count - 1) * targetFrameRate / 1000.0;        // time is in millisec, so divide targetFrameRate by 1000
                    calculationsPerStepActual = (int)(1 / totalTimeNeeded);
                    if (calculationsPerStepActual == 0)
                    {
                        calculationsPerStepActual = 1;
                    }
                }
                else
                {
                    calculationsPerStepActual = 0;
                }
            }
        }

        static private void ReverseAllSpeeds()
        {
            foreach (GravityObject o in GravityObjects)
            {
                o.XSpeed = -o.XSpeed;
                o.YSpeed = -o.YSpeed;
            }
        }

        // Make steps to move to a certain simulation time
        static public void MoveToDate(DateTime sourceDate, DateTime targetDate)
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



        static public void CalculateStep(long timeUnits, bool makeStep = true)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();     //creates and start the instance of Stopwatch

            double secondsPerStep = (double)timeUnits / calculationsPerStepActual;

            //            LogValuesRealtimeBegin(calculationsPerStepActual);

            for (int i = 0; i < calculationsPerStepActual; i++)
            {
                for (int k = 0; k < GravityObjects.Count; k++)
                {
                    GravityObject myObject = GravityObjects[k];
                    double acceleration_x = 0;
                    double acceleration_y = 0;
                    for (int l = 0; l < GravityObjects.Count; l++)
                    {
                        if (l != k)
                        {
                            GravityObject otherObject = GravityObjects[l];
                            double x_difference = otherObject.X - myObject.X;
                            double y_difference = otherObject.Y - myObject.Y;
                            double square_radius = Math.Pow(x_difference, 2) + Math.Pow(y_difference, 2);
                            if (square_radius == 0)
                            {
                                // objects exactly on top of each other; bail out to prevent division by zero
                                continue;
                            }
                            double acceleration = otherObject.Mass / square_radius;

                            // cap on acceleration
                            double capacity = AccelerationLimit / secondsPerStep;
                            if (acceleration > capacity)
                            {
                                Message.Text = "Acceleration of object has been limited, because it is to close to another object.";
                                acceleration = capacity;
                            }


                            // limit the speed to stay within the escape velocity. It could be that it can escape its host, but only with extra gravity from other objects than its host.
                            //                            double escape_velocity_sq = (2 * gravitationalConstant * otherObject.Mass) / Math.Sqrt(square_radius);
                            //                            double relative_velocity_sq = Math.Pow(myObject.XSpeed - otherObject.XSpeed, 2) + Math.Pow(myObject.YSpeed - otherObject.YSpeed, 2);

                            // divide acceleration in X and Y component
                            double angle = Math.Atan2(y_difference, x_difference);      // angle with positive X axis
                            acceleration_x += Math.Cos(angle) * acceleration;
                            acceleration_y += Math.Sin(angle) * acceleration;
                            /*
                                                        if (relative_velocity_sq < escape_velocity_sq)          // object was within escape velocity, so should stay so
                                                        {
                                                            double new_x_speed = extra_acceleration_x * secondsPerStep;
                                                            double new_y_speed = extra_acceleration_y * secondsPerStep;
                                                            double new_position_x = myObject.X + (new_x_speed + myObject.XSpeed) * secondsPerStep + 0.5 * extra_acceleration_x * Math.Pow(secondsPerStep, 2);
                                                            double new_position_y = myObject.Y + (new_y_speed + myObject.YSpeed) * secondsPerStep + 0.5 * extra_acceleration_y * Math.Pow(secondsPerStep, 2);
                                                            double new_square_radius = Math.Pow(otherObject.X - new_position_x, 2) + Math.Pow(otherObject.Y - new_position_y, 2);
                                                            double new_escape_velocity_sq = (2 * gravitationalConstant * otherObject.Mass) / Math.Sqrt(new_square_radius);
                                                            double new_relative_velocity_sq = Math.Pow(myObject.XSpeed - otherObject.XSpeed, 2) + Math.Pow(myObject.YSpeed - otherObject.YSpeed, 2);
                                                            if (new_relative_velocity_sq > new_escape_velocity_sq)   // object is no longer within escape velocity
                                                            {
                                                                // TODO
                                                            }
                                                        }
                            */
                        }
                    }

                    acceleration_x *= gravitationalConstant;        // note: this is purely the force of gravity, so we don't need to take into account the secondsPerStep at this moment
                    acceleration_y *= gravitationalConstant;        // note: this is purely the force of gravity, so we don't need to take into account the secondsPerStep at this moment

                    /*                    double AngleDifference = Math.Abs(accelerationAngle - myObject.AccelerationAngle) % (2*Math.PI);
                                        if (AngleDifference > Math.PI)
                                            AngleDifference = (2 * Math.PI) - AngleDifference;

                                        if (AngleDifference > .5 * Math.PI && makeStep)        // more than 90 degrees difference since last measurement..
                                        {
                                            // ..this means the object could have moved past another object and the next measurement is just passed the object, closer than last time.
                                            // now the new acceleration can never be higher than the previous one.
                                            if (myObject.XAcceleration!=0 && Math.Abs(acceleration_x) > Math.Abs(myObject.XAcceleration))
                                            {
                                                if (acceleration_x > 0)
                                                {
                                                    acceleration_x = Math.Abs(myObject.XAcceleration);
                                                }
                                                else
                                                {
                                                    acceleration_x = -Math.Abs(myObject.XAcceleration);
                                                }
                                            }
                                            if (myObject.YAcceleration != 0 && Math.Abs(acceleration_y) > Math.Abs(myObject.YAcceleration))
                                            {
                                                if (acceleration_y > 0)
                                                {
                                                    acceleration_y = Math.Abs(myObject.YAcceleration);
                                                }
                                                else
                                                {
                                                    acceleration_y = -Math.Abs(myObject.YAcceleration);
                                                }
                                            }
                                        }
                    */
                    /*
                                         // cap on acceleration
                                        double cap = 100 / secondsPerStep;
                                        if (acceleration_x > cap)
                                        {
                    //                        acceleration_y *= (cap / acceleration_x);   // y must also shrink to maintain the same direction of accelleration
                                            acceleration_x = cap;
                                        }
                                        if (acceleration_x < -cap)
                                        {
                    //                        acceleration_y *= (cap / acceleration_x);   // y must also shrink to maintain the same direction of accelleration
                                            acceleration_x = -cap;
                                        }
                                        if (acceleration_y > cap)
                                        {
                    //                        acceleration_y *= (cap / acceleration_y);   // x must also shrink to maintain the same direction of accelleration
                                            acceleration_y = cap;
                                        }
                                        if (acceleration_y < -cap)
                                        {
                    //                        acceleration_y *= (cap / acceleration_y);   // x must also shrink to maintain the same direction of accelleration
                                            acceleration_y = -cap;
                                        }
                      */
                    myObject.XAcceleration = acceleration_x;
                    myObject.YAcceleration = acceleration_y;
                }

                // make a step using the new acceleration
                if (makeStep)
                {
                    for (int k = 0; k < GravityObjects.Count; k++)
                    {
                        GravityObject myObject = GravityObjects[k];

                        myObject.X += myObject.XSpeed * secondsPerStep + 0.5 * myObject.XAcceleration * Math.Pow(secondsPerStep, 2);
                        myObject.XSpeed += myObject.XAcceleration * secondsPerStep;     // make movement using old speed first
                        myObject.Y += myObject.YSpeed * secondsPerStep + 0.5 * myObject.YAcceleration * Math.Pow(secondsPerStep, 2);
                        myObject.YSpeed += myObject.YAcceleration * secondsPerStep;
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
            calculationTime = stopwatch.ElapsedMilliseconds;
        }

        [ConditionalAttribute("DEBUG")]
        static private void LogValuesRealtimeBegin(int calculationsPerStepActual)
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
        static private void LogValuesRealtime(int calculationsPerStepActual)
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

        // at scale 1, one pixel = 1000 km 
        static public double ScreenToRealCoordinateX(double screen_x)
        {
            return (screen_x + offsetX) * 1000000.0 * scale;       // screen coords -> adjust offset (is not to scale yet) -> scale 
        }

        static public double ScreenToRealCoordinateY(double screen_y)
        {
            return (screen_y + offsetY) * 1000000.0 * scale;       // screen coords -> adjust offset (is not to scale yet) -> scale 
        }

        static public int RealtoScreenCoordinateX(double realX)
        {
            return (int)((realX / (1000000.0 * scale)) - offsetX);              // scale -> adjust offset (is not to scale) -> screen coords
        }

        static public int RealtoScreenCoordinateY(double realY)
        {
            return (int)((realY / (1000000.0 * scale)) - offsetY);              // scale -> adjust offset (is not to scale) -> screen coords
        }

        static public long ScaleCoordinateX(double realX, long newScale)
        {
            return (long)(realX / (1000000.0 * newScale));              // scale -> adjust offset (is not to scale) -> screen coords
        }

        static public long ScaleCoordinateY(double realY, long newScale)
        {
            return (long)(realY / (1000000.0 * newScale));              // scale -> adjust offset (is not to scale) -> screen coords
        }

        // used to keep the center the same when zooming in/out with no object centered
        static public void AdjustOffsetToNewScale(long newScale)
        {
            double realCenterX = ScreenToRealCoordinateX((viewportWidth / 2));
            double realCenterY = ScreenToRealCoordinateY((viewportHeight / 2));

            offsetX = ScaleCoordinateX(realCenterX, newScale) - (viewportWidth / 2);
            offsetY = ScaleCoordinateY(realCenterY, newScale) - (viewportHeight / 2);
        }

        static public void CenterOnObject()
        {
            if (centerIndex > -1)
            {
                offsetX = (long)((GravityObjects[centerIndex].X) / (1000000.0 * scale)) - (viewportWidth / 2);
                offsetY = (long)((GravityObjects[centerIndex].Y) / (1000000.0 * scale)) - (viewportHeight / 2);
            }
        }

        static public double MetersToPixels(double meter)
        {
            return meter / (1000000.0 * scale);
        }

        static public double PixelsToMeters(double pixel)
        {
            return pixel * (1000000.0 * scale);
        }

        static public void AddObject(string name_, double mass_, double x_, double y_, double xSpeed_, double ySpeed_, Texture2D texture_, bool trace_, bool vector_, bool scaleObject_ = true)
        {
            AddObjectRealPosition(name_, mass_, ScreenToRealCoordinateX(x_), ScreenToRealCoordinateY(y_), xSpeed_, ySpeed_, texture_, trace_, vector_, scaleObject_);
        }
        static public void AddObjectRealPosition(string name_, double mass_, double x_, double y_, double xSpeed_, double ySpeed_, Texture2D texture_, bool trace_, bool vector_, bool scaleObject_ = true)
        {
            Color color_ = Color.White;
            AddObjectRealPosition(name_, mass_, x_, y_, xSpeed_, ySpeed_, texture_, color_, trace_, vector_, scaleObject_);
        }

        static public void AddObjectRealPosition(string name_, double mass_, double x_, double y_, double xSpeed_, double ySpeed_, Texture2D texture_, Color color_, bool trace_, bool vector_, bool scaleObject_ = true)
        {
            if (GravityObjects.Count == 0)     // center the first object
            {
                centerIndex = 0;
            }
            GravityObjects.Add(new GravityObject(name_, mass_, x_, y_, xSpeed_, ySpeed_, texture_, color_, trace_, scale, vector_, scaleObject_));
            DetermineCalculationsPerStepActual();
        }

        // Find the object that had the most gravitational pull on X, Y
        static public GravityObject findBestHost(double X, double Y)
        {
            double x = ScreenToRealCoordinateX(X);
            double y = ScreenToRealCoordinateY(Y);
            GravityObject hostObject = null;
            double greatest_pull = 0;
            foreach (GravityObject myObject in GravityObjects)
            {
                double pull = myObject.Mass / (Math.Pow(x - myObject.X, 2) + Math.Pow(y - myObject.Y, 2));
                if (hostObject == null || pull > greatest_pull)
                {
                    greatest_pull = pull;
                    hostObject = myObject;
                }
            }

            return hostObject;
        }

        static public GravityObject NextObject()
        {
            objectIndex++;
            if (objectIndex >= GravityObjects.Count)
            {
                objectIndex = 0;
            }
            return GravityObjects[objectIndex];
        }

        static public GravityObject PreviousObject()
        {
            objectIndex--;
            if (objectIndex < 0)
            {
                objectIndex = GravityObjects.Count - 1;
            }
            return GravityObjects[objectIndex];
        }

        static public GravityObject CurrentObject()
        {
            return GravityObjects[objectIndex];
        }

        static public bool IsCurrentObjectedCenter()
        {
            return objectIndex == centerIndex;
        }

        static public void ScaleObjects()
        {
            foreach (GravityObject o in GravityObjects)
            {
                if (o.ScaleTexture)
                {
                    float scale_ = 1 + (Scale / 100.0f);
                    if (o.Texture.Width < minimumTextureSize)
                    {
                        continue;       // scaling not possible
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
        }

        static public double DistanceCurrentObjectZeroObject()
        {
            return Math.Sqrt(Math.Pow(GravityObjects[0].X - GravityObjects[objectIndex].X, 2) + Math.Pow(GravityObjects[0].Y - GravityObjects[objectIndex].Y, 2)) / 1000;
        }

        static public void StabilizeObjectsSpeeds(int startPosition, bool rotateCounterClockWise)
        {
            double TotalMass = 0;
            double centerMassX = 0;
            double centerMassY = 0;

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

                // STEP 2: determine force acting on object
                double acceleration_x = 0;
                double acceleration_y = 0;
                for (int l = startPosition; l < GravityObjects.Count; l++)
                {
                    if (l != k)
                    {
                        GravityObject otherObject = GravityObjects[l];
                        double x_difference = otherObject.X - myObject.X;
                        double y_difference = otherObject.Y - myObject.Y;
                        double square_radius = Math.Pow(x_difference, 2) + Math.Pow(y_difference, 2);
                        if (square_radius == 0)
                        {
                            // objects exactly on top of each other; bail out to prevent division by zero
                            continue;
                        }
                        double tmp_acceleration = otherObject.Mass / square_radius;
                        // cap on acceleration
                        double limit = AccelerationLimit / ((double)CalculationSecondsPerFrame / CalculationsPerStepPrecalculated);
                        if (tmp_acceleration > limit)
                        {
                            Message.Text = "Acceleration of object has been limited, because it is to close to another object.";
                            tmp_acceleration = limit;
                        }

                        double angle = Math.Atan2(y_difference, x_difference);      // angle with positive X axis
                        acceleration_x += Math.Cos(angle) * tmp_acceleration;
                        acceleration_y += Math.Sin(angle) * tmp_acceleration;
                    }
                }

                double angle_force = Math.Atan2(acceleration_y, acceleration_x);      // angle with positive X axis
                acceleration_x *= gravitationalConstant;        // note: this is purely the force of gravity, so we don't need to take into account the secondsPerStep at this moment
                acceleration_y *= gravitationalConstant;        // note: this is purely the force of gravity, so we don't need to take into account the secondsPerStep at this moment

                // not neccesary, but now we have the accelerations, we might as well set it..
                myObject.XAcceleration = acceleration_x;
                myObject.YAcceleration = acceleration_y;

                double angle_center_of_mass = Math.Atan2(centerMassY - myObject.Y, centerMassX - myObject.X);      // angle with positive X axis
                double acceleration = Math.Sqrt(Math.Pow(acceleration_x, 2) + Math.Pow(acceleration_y, 2));

                // STEP 3: determine force proportional in direction of center of mass (the force can be pointing at another direction than the center of mass)
                //                double angle_difference = MathHelper.WrapAngle((float)(angle_force - angle_center_of_mass));
                //                double centripetal_force = acceleration * Math.Abs(Math.Sin(angle_difference));

                // STEP 4: set the speed at 90 degrees with center of mass
                double radius = Math.Sqrt(Math.Pow(centerMassX - myObject.X, 2) + Math.Pow(centerMassY - myObject.Y, 2));
                double EscapeVelocity = Math.Sqrt(/*centripetal_force*/acceleration * radius);

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

        static public Vector calcSpeedFromHost(GravityObject hostObject, double X, double Y, double Mass)
        {
            double x = ScreenToRealCoordinateX(X);
            double y = ScreenToRealCoordinateY(Y);

            double radius = Math.Sqrt(Math.Pow(hostObject.X - x, 2) + Math.Pow(hostObject.Y - y, 2));
            double EscapeVelocity = Math.Sqrt((gravitationalConstant * hostObject.Mass) / radius);

            double angle = Math.Atan2(hostObject.Y - y, hostObject.X - x);
            angle -= (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
            Vector speed = new Vector();
            speed.X = Math.Cos(angle) * EscapeVelocity;
            speed.Y = Math.Sin(angle) * EscapeVelocity;

            return speed;
        }

        [ConditionalAttribute("DEBUG")]
        static private void LogValues(int calculationsPerStepNeededPower)
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

        static public void PreCalculate(BackgroundWorker backgroundWorkerPreCalculate, DoWorkEventArgs e)
        {
            while (CalculationsPerStepPrecalculated == 1 || precalcAutoIncrease)
            {
                while (frameNumberCalc <= NumPrecalculatedFrames())
                {
                    if (CalculateFrame(backgroundWorkerPreCalculate, e))
                    {
                        return;
                    }
                    if (GravityObjects.Count > 1)
                    {
                        frameNumberCalc++;
                    }
                    else
                    {
                        if (backgroundWorkerPreCalculate.CancellationPending)
                        {
                            // Set the e.Cancel flag so that the WorkerCompleted event
                            // knows that the process was cancelled.
                            e.Cancel = true;
                            return;
                        }
                    }
                }
                frameNumberCalc = 1;            // Frame 0 is the unmodified starting situation
                for (int k = 0; k < GravityObjects.Count; k++)
                {
                    CalculationCurrentSpeeds[k].X = CalculationInitialSpeeds[k].X;
                    CalculationCurrentSpeeds[k].Y = CalculationInitialSpeeds[k].Y;
                }
                //                LogValues(calculationsPerStepNeededPower);
                CalculationsPerStepPrecalculated *= preCalculationIncreaseFactor;
            }
        }

        static public bool CalculateFrame(BackgroundWorker backgroundWorkerPreCalculate, DoWorkEventArgs e) 
        {
            double secondsPerStep = QuadTree.SecondsPerStep = (double)CalculationSecondsPerFrame / CalculationsPerStepPrecalculated;

            // reset position to previous frame; we are making a new calculation for this frame only
            for (int k = 0; k < GravityObjects.Count; k++)
            {
                Calculation[frameNumberCalc][k].X = Calculation[frameNumberCalc - 1][k].X;
                Calculation[frameNumberCalc][k].Y = Calculation[frameNumberCalc - 1][k].Y;
            }

            for (int i = 0; i < CalculationsPerStepPrecalculated; i++)
            {
                if (UseBarnesHut)
                {
                    if (GravityObjects.Count > 0)
                    {
                        QuadTree.Create(Calculation, GravityObjects, frameNumberCalc, backgroundWorkerPreCalculate, e, message);
                        QuadTree.CalculateValues(Calculation, CalculationCurrentAccelerations, frameNumberCalc, backgroundWorkerPreCalculate, e, AccelerationLimit, message);
                    }

                    if (backgroundWorkerPreCalculate.CancellationPending)
                    {
                        // Set the e.Cancel flag so that the WorkerCompleted event
                        // knows that the process was cancelled.
                        e.Cancel = true;
                        return true;
                    }
                }
                else
                {
                    try
                    {
                        for (int k = 0; k < GravityObjects.Count; k++)
                        {
                            Calculation myCalculation = Calculation[frameNumberCalc][k];      // Start with old value
                            double acceleration_x = 0;
                            double acceleration_y = 0;
                            for (int l = 0; l < GravityObjects.Count; l++)
                            {
                                //                            if (l != k)
                                //                            {
                                Calculation otherCalculation = Calculation[frameNumberCalc][l];
                                double x_difference = otherCalculation.X - myCalculation.X;
                                double y_difference = otherCalculation.Y - myCalculation.Y;
                                double square_radius = Math.Pow(x_difference, 2) + Math.Pow(y_difference, 2);
                                if (square_radius == 0)
                                {
                                    // objects exactly on top of each other (or the object itself!); bail out to prevent division by zero
                                    continue;
                                }

                                double acceleration = GravityObjects[l].Mass / square_radius;

                                // cap on acceleration
                                double limit = AccelerationLimit / secondsPerStep;
                                if (acceleration > limit)
                                {
                                    Message.Text = "Acceleration of object has been limited, because it is to close to another object.";
                                    acceleration = limit;
                                }


                                // divide acceleration in X and Y component
                                double angle = Math.Atan2(y_difference, x_difference);      // angle with positive X axis
                                acceleration_x += Math.Cos(angle) * acceleration;
                                acceleration_y += Math.Sin(angle) * acceleration;
                                //                            }
                            }

                            if (backgroundWorkerPreCalculate.CancellationPending)
                            {
                                // Set the e.Cancel flag so that the WorkerCompleted event
                                // knows that the process was cancelled.
                                e.Cancel = true;
                                return true;
                            }

                            acceleration_x *= gravitationalConstant;
                            acceleration_y *= gravitationalConstant;

                            //                        double accelerationAngle = Math.Atan2(acceleration_y, acceleration_x);

                            CalculationCurrentAccelerations[k].X = acceleration_x;
                            CalculationCurrentAccelerations[k].Y = acceleration_y;
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Exception at CalculateFrame(): " + ex.Message);
                    }
                }

                // make a step using the new acceleration
                for (int k = 0; k < GravityObjects.Count; k++)
                {
                    Calculation myCalculation = Calculation[frameNumberCalc][k];
                    myCalculation.X += CalculationCurrentSpeeds[k].X * secondsPerStep + 0.5 * CalculationCurrentAccelerations[k].X * Math.Pow(secondsPerStep, 2);
                    myCalculation.Y += CalculationCurrentSpeeds[k].Y * secondsPerStep + 0.5 * CalculationCurrentAccelerations[k].Y * Math.Pow(secondsPerStep, 2);
                    CalculationCurrentSpeeds[k].X += CalculationCurrentAccelerations[k].X * secondsPerStep;
                    CalculationCurrentSpeeds[k].Y += CalculationCurrentAccelerations[k].Y * secondsPerStep;
                    //                    Debug.Write("Object: " + k + "acc. X: " + CalculationCurrentAccelerations[k].X + " acc. Y:" + CalculationCurrentAccelerations[k].Y + "\r\n");
                }
            }

            return false;
        }

        static public void DisplayFrame()
        {
            for (int k = 0; k < Calculation[0].Length; k++)
            {
                GravityObject myObject = GravityObjects[k];
                myObject.X = Calculation[frameNumberPlay][k].X;
                myObject.Y = Calculation[frameNumberPlay][k].Y;
            }
        }

        // Return true if last reached frame (to rewind)
        static public bool PlayOneFrame()
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
                // Because speeds and accelerations are not stored for performance reasons, they need to be re-calculated
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

        static public void InitCalculation()
        {
            Calculation = new Calculation[NumPrecalculatedFrames() + 1][];
            for (int frame = 0; frame <= NumPrecalculatedFrames(); frame++)
            {
                Calculation[frame] = new Calculation[GravityObjects.Count];
                
                // Disable when using structs:
                for (int objectnumber = 0; objectnumber < GravityObjects.Count; objectnumber++)
                {
                    Calculation[frame][objectnumber] = new Calculation();
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
            CalculationsPerStepPrecalculated = 1;
            frameNumberCalc = 1;         // Frame 0 is the unmodified starting situation
            frameNumberPlay = 0;
        }

        static public void ResetCalculations(bool ForceStart=false)
        {
            if (IsCalculating || CalculationsPerStepPrecalculated > 1 || ForceStart)
            {
                StopCalculation();
                InitCalculation();
                StartCalculation();
            }
        }

        static public void StopCalculation()
        {
            if(IsCalculating)
            {
                if (backgroundWorkerPreCalculate.IsBusy)
                {
                    backgroundWorkerPreCalculate.CancelAsync();
                //    Thread.Sleep(2000);
//                    backgroundWorkerPreCalculate.Dispose();
                    /*                    int retries = 0;
                                        while (backgroundWorkerPreCalculate.IsBusy && retries < 25)       // Thread could still be busy; wait for it to finish
                                        {
                                            //                        Application.DoEvents();
                    //                        backgroundWorkerPreCalculate.
                                            Thread.Sleep(1000);
                                            retries++;
                                        }
                                        if(retries>1)
                                        {
                                            MessageBox.Show("Retries:" + retries);
                                        }
                                        */
/*                    while (IsCalculating)
                    {
                        Thread.Sleep(1000);
                    }
                    int pp = 0;
                    */
                }
            }
        }

        static private void backgroundWorkerPreCalculate_DoWork(object sender, DoWorkEventArgs e)
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

        static public void StartCalculation()
        {
            if (!IsCalculating)
            {
                IsCalculating = true;
                backgroundWorkerPreCalculate = new BackgroundWorker();
                backgroundWorkerPreCalculate.WorkerReportsProgress = true;
                backgroundWorkerPreCalculate.WorkerSupportsCancellation = true;
                backgroundWorkerPreCalculate.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerPreCalculate_DoWork);

                backgroundWorkerPreCalculate.RunWorkerAsync();

                /*
                while (backgroundWorkerPreCalculate.IsBusy)       // Old thread could still be busy; wait for it to finish
                {
                    Application.DoEvents();
                }
                if (!backgroundWorkerPreCalculate.IsBusy)
                {
                    backgroundWorkerPreCalculate.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("Thread stil busy!");
                }*/
            }
        }

        static public Calculation[][] ResizeArray<Calculation>(Calculation[][] original, int rows) where Calculation : new()
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

        static public void AdjustNumberOfCalculations(int newPreCalculationTime)
        {
            int newNumPrecalculatedFrames = newPreCalculationTime * targetFrameRate;

            if (calculation!=null && newNumPrecalculatedFrames != NumPrecalculatedFrames())
            {
                calculation = ResizeArray<Calculation>(calculation, newNumPrecalculatedFrames + 1);
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

            CalculationsPerStepPrecalculated = 1;   // This makes sure the pre-calculation job will run to add the new frames
        }

    }
}
