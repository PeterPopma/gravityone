using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using GravityOne.Forms;
using GravityOne.Gravity;
using GravityOne.SpaceObjects;
using SharpAvi;
using SharpAvi.Codecs;
using System.Threading;

namespace GravityOne.CustomControls
{
    public class Display : WinFormsGraphicsDevice.GraphicsDeviceControl
    {
        int backgroundIndex = 0;
        Boolean showNames = true;
        Boolean showScale = true;
        Boolean showAsDots = false;
        Boolean showTrailsAll = true;
        Boolean showVectorsAll = false;
        Texture2D textureBackground;
        Texture2D textureMercury;
        Texture2D textureSun;
        Texture2D textureVenus;
        Texture2D textureEarth;
        Texture2D textureMoon;
        Texture2D textureMars;
        Texture2D textureJupiter;
        Texture2D textureSaturn;
        Texture2D textureNeptune;
        Texture2D textureUranus;
        Texture2D texturePluto;
        Texture2D texturePlanet;
        Texture2D textureRedBall;
        Texture2D textureMetalBall;
        Texture2D textureGoldenBall;
        Texture2D textureArrow;
        Texture2D textureVector;
        Texture2D textureTrace;
        Texture2D textureSmallDot;
        Texture2D textureLargeDot;
        Texture2D textureAsteroid;
        SpriteFont fontNormal;
        SpriteFont fontSmall;
        SpriteFont fontLindsey;
        Texture2D textureLine;     //base for the line texture
        Rectangle rectVector;
        bool simulationRunning = false;
        bool simulationStepping = false;
        bool recordingVideo = false;
        DateTime simulationTime;
        long simulationTimeLarge;
        bool reverse = false;
        BlendState blendState = BlendState.AlphaBlend;
        Galaxy galaxy = new Galaxy();
        RandomObjects randomObjects = new RandomObjects();
        private bool _hasDeviate;
        private double _storedDeviate;
        Random rnd = new Random();
        SmallDot smallDot = new SmallDot();
        Grid grid = new Grid();
        Circle circle = new Circle();
        ScreenRecorder screenRecorder;
        private string videoCaptureCompression;
        int videoCaptureFPS = 60;

        ContentManager contentManager;
        long timeUnitsPerStep = 1;

        int scrollWheelValue, lastScrollWheelValue;
        GravitySystem gravitySystem;

        // Input state.
        KeyboardState currentKeyboardState;
        GamePadState currentGamePadState;

        KeyboardState lastKeyboardState;
        GamePadState lastGamePadState;
        System.Drawing.Point lastMousePosition;
        FormMain parentForm;

        SpriteBatch spriteBatch;

        internal GravitySystem GravitySystem
        {
            get
            {
                return gravitySystem;
            }

            set
            {
                gravitySystem = value;
            }
        }

        public bool ShowScale
        {
            get
            {
                return showScale;
            }

            set
            {
                showScale = value;
            }
        }

        public long TimeUnitsPerStep
        {
            get
            {
                return timeUnitsPerStep;
            }

            set
            {
                timeUnitsPerStep = value;
            }
        }

        public bool SimulationRunning
        {
            get
            {
                return simulationRunning;
            }

            set
            {
                simulationRunning = value;
            }
        }

        public bool SimulationStepping
        {
            get
            {
                return simulationStepping;
            }

            set
            {
                simulationStepping = value;
            }
        }

        public bool ShowAsDots
        {
            get
            {
                return showAsDots;
            }

            set
            {
               showAsDots = value;
            }
        }

        public DateTime SimulationTime
        {
            get
            {
                return simulationTime;
            }

            set
            {
                simulationTime = value;
            }
        }

        public long SimulationTimeLarge
        {
            get
            {
                return simulationTimeLarge;
            }

            set
            {
                simulationTimeLarge = value;
            }
        }

        public int BackgroundIndex
        {
            get
            {
                return backgroundIndex;
            }

            set
            {
                backgroundIndex = value;
            }
        }

        public bool ShowNames
        {
            get
            {
                return showNames;
            }

            set
            {
                showNames = value;
            }
        }

        public bool Reverse
        {
            get
            {
                return reverse;
            }

            set
            {
                reverse = value;
            }
        }

        public BlendState BlendState
        {
            get
            {
                return blendState;
            }

            set
            {
                blendState = value;
            }
        }

        internal Galaxy Galaxy
        {
            get
            {
                return galaxy;
            }

            set
            {
                galaxy = value;
            }
        }

        public bool ShowTrailsAll
        {
            get
            {
                return showTrailsAll;
            }

            set
            {
                showTrailsAll = value;
            }
        }

        public bool ShowVectorsAll
        {
            get
            {
                return showVectorsAll;
            }

            set
            {
                showVectorsAll = value;
            }
        }

        internal RandomObjects RandomObjects
        {
            get
            {
                return randomObjects;
            }

            set
            {
                randomObjects = value;
            }
        }

        internal SmallDot SmallDot
        {
            get
            {
                return smallDot;
            }

            set
            {
                smallDot = value;
            }
        }

        public bool RecordingVideo
        {
            get
            {
                return recordingVideo;
            }

            set
            {
                recordingVideo = value;
            }
        }

        public int VideoCaptureFPS
        {
            get
            {
                return videoCaptureFPS;
            }

            set
            {
                videoCaptureFPS = value;
            }
        }

        public string VideoCaptureCompression
        {
            get
            {
                return videoCaptureCompression;
            }

            set
            {
                videoCaptureCompression = value;
            }
        }

        internal Grid Grid
        {
            get
            {
                return grid;
            }

            set
            {
                grid = value;
            }
        }

        internal Circle Circle
        {
            get
            {
                return circle;
            }

            set
            {
                circle = value;
            }
        }

        public void initSmallDot(int dotSize, Color myColor)
        {
            myColor.A = (byte)SmallDot.Alpha;
            if (dotSize < 3 || SmallDot.Type == 0)
            {
                textureSmallDot = new Texture2D(GraphicsDevice, dotSize, dotSize);
                if(smallDot.RandomColor)
                {
                    int color = rnd.Next(0, 6);
                    myColor.R = (color < 2 || color == 4) ? (byte)0 : (byte)255;
                    myColor.G = (color > 0 && color < 4) ? (byte)0 : (byte)255;
                    myColor.B = (color > 2) ? (byte)0 : (byte)255;
                }
                Color[] az = Enumerable.Range(0, dotSize * dotSize).Select(i => myColor).ToArray();
                textureSmallDot.SetData(az);
            }
            else if(SmallDot.Type == 1)
            {
                textureSmallDot = contentManager.Load<Texture2D>("smalldot"+ dotSize);
                textureSmallDot = createTextureFromResource(textureSmallDot, myColor);
            }
            else
            {
                textureSmallDot = contentManager.Load<Texture2D>("cross" + dotSize);
                textureSmallDot = createTextureFromResource(textureSmallDot, myColor);
            }
            textureSmallDot.Name = "<Custom Shape>";
        }

        private void setColor(Texture2D texture, Color myColor)
        {
            int width = texture.Width;
            int height = texture.Height;
            Color[] data = new Color[width * height];
            texture.GetData<Color>(data, 0, data.Length);
            for (int k=0; k<width*height; k++)
            {
                if (data[k].R > 10 || data[k].G > 10 || data[k].B > 10)     // pixel is part of the shape
                {
                    data[k].R = myColor.R;
                    data[k].G = myColor.G;
                    data[k].B = myColor.B;
                }
                data[k].A = myColor.A;
            }
            texture.SetData(data);
        }

        private Texture2D createTextureFromResource(Texture2D texture, Color myColor)
        {
            int width = texture.Width;
            int height = texture.Height;
            Color[] data = new Color[width * height];
            texture.GetData<Color>(data, 0, data.Length);
            Color[] newData = new Color[width * height];
            int color = rnd.Next(0, 6);
            for (int k = 0; k < width * height; k++)
            {
                if (data[k].R > 10 || data[k].G > 10 || data[k].B > 10)     // pixel is part of the shape
                {
                    if (smallDot.RandomColor)
                    {
                        newData[k] = new Color();
                        newData[k].A = (byte)SmallDot.Alpha;
                        newData[k].R = (color < 2 || color == 4) ? (byte)0 : (byte)data[k].R;
                        newData[k].G = (color > 0 && color < 4) ? (byte)0 : (byte)data[k].G;
                        newData[k].B = (color > 2) ? (byte)0 : (byte)data[k].B;
                    }
                    else
                    {
                        newData[k] = myColor;
                    }
                }
            }
            Texture2D newTexture = new Texture2D(GraphicsDevice, width, height);
            newTexture.SetData(newData);

            return newTexture;
        }

        public void updateSmallDots(int startPosition=0)
        {
            for (int k=startPosition; k < gravitySystem.GravityObjects.Count; k++)
            {
                GravityObject o = gravitySystem.GravityObjects[k];
                if (o.Texture.Name.Equals("<Custom Shape>"))
                {
                    int dotSize = SmallDot.PixelSize;
                    if (smallDot.RandomSize)
                    {
                        dotSize = rnd.Next(3, 11);
                    }
                    initSmallDot(dotSize, o.Color);

                    o.Texture = textureSmallDot;
                    o.ScaledTextureHeight = textureSmallDot.Height;
                    o.ScaledTextureWidth = textureSmallDot.Width;
                }
            }
        }

        private void MouseWheelHandler(object sender, MouseEventArgs e)
        {
            scrollWheelValue += e.Delta;
        }

        public void setReverse(bool reverse_)
        {
            if (reverse != reverse_)
            {
                foreach (GravityObject o in GravitySystem.GravityObjects)
                {
                    o.XSpeed = -o.XSpeed;
                    o.YSpeed = -o.YSpeed;
                }
            }
            reverse = reverse_;
        }

        // Returns a unique (numbered) name of a given text
        public string FindFreeName(string name)
        {
            string result = name;
            int count = 1;
            while (gravitySystem.GravityObjects.Exists(item => item.Name == result))
            {
                count++;
                result = name + count.ToString();
            }

            return result;
        }

        protected override void Initialize()
        {
            simulationTime = DateTime.Now;
            simulationTimeLarge = simulationTime.Year;

            gravitySystem = new GravitySystem(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            parentForm = (this.Parent as FormMain);
//                        contentManager = new ContentManager(Services);
//                        contentManager.RootDirectory = "Content";
            contentManager = new ResourceContentManager(Services, Resources.ResourceManager);
            // LET OP! Content dir wordt niet meer gebruikt. Als je resources wilt toevoegen moet je dit in de resourcemanager doen.
            // Je moet daar dan de .XNB files toevoegen
            // Deze kun je genereren door de uitgecommentarieerde contentmanager terug te zetten, of de XNAContentCompiler te gebruiken.

            // Load the background content. 
            textureMercury = contentManager.Load<Texture2D>("mercury");
            textureMercury.Name = "Mercury";
            textureSun = contentManager.Load<Texture2D>("sun");
            textureSun.Name = "Sun";
            textureVenus = contentManager.Load<Texture2D>("venus");
            textureVenus.Name = "Venus";
            textureEarth = contentManager.Load<Texture2D>("earth");
            textureEarth.Name = "Earth";
            textureMoon = contentManager.Load<Texture2D>("moon");
            textureMoon.Name = "Moon";
            textureMars = contentManager.Load<Texture2D>("mars");
            textureMars.Name = "Mars";
            textureJupiter = contentManager.Load<Texture2D>("jupiter");
            textureJupiter.Name = "Jupiter";
            textureSaturn = contentManager.Load<Texture2D>("saturn");
            textureSaturn.Name = "Saturn";
            textureNeptune = contentManager.Load<Texture2D>("neptune");
            textureNeptune.Name = "Neptune";
            textureUranus = contentManager.Load<Texture2D>("uranus");
            textureUranus.Name = "Uranus";
            texturePluto = contentManager.Load<Texture2D>("pluto");
            texturePluto.Name = "Pluto";
            textureRedBall = contentManager.Load<Texture2D>("ball");
            textureRedBall.Name = "Red Ball";
            textureMetalBall = contentManager.Load<Texture2D>("metalball");
            textureMetalBall.Name = "Metal Ball";
            textureGoldenBall = contentManager.Load<Texture2D>("goldenball");
            textureGoldenBall.Name = "Golden Ball";
            texturePlanet = contentManager.Load<Texture2D>("planet");
            texturePlanet.Name = "Planet";
            textureArrow = contentManager.Load<Texture2D>("arrow");
            textureArrow.Name = "Arrow";
            textureVector = contentManager.Load<Texture2D>("vector");
            textureVector.Name = "Vector";
            textureLargeDot = contentManager.Load<Texture2D>("largedot");
            textureLargeDot.Name = "Point";
            textureAsteroid = contentManager.Load<Texture2D>("asteroid");
            textureAsteroid.Name = "Asteroid";
            rectVector = new Rectangle(0, 0, textureVector.Width, textureVector.Height);
            fontLindsey = contentManager.Load<SpriteFont>("font_lindsey");
            fontNormal = contentManager.Load<SpriteFont>("font_segoeuimono");
            fontSmall = contentManager.Load<SpriteFont>("font_small");
            textureSmallDot = new Texture2D(GraphicsDevice, SmallDot.PixelSize, SmallDot.PixelSize);

            textureTrace = new Texture2D(GraphicsDevice, 2, 2);
            Color[] az = Enumerable.Range(0, 4).Select(i => new Color(255, 255, 255, 100)).ToArray();
            textureTrace.SetData(az);

            // create 1x1 texture for line drawing
            textureLine = new Texture2D(GraphicsDevice, 1, 1);
            textureLine.SetData<Color>(
                new Color[] { Color.White });// fill the texture with white


            this.MouseWheel += new MouseEventHandler(MouseWheelHandler);
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        public void setBackground(int backgroundIndex_)
        {
            backgroundIndex = backgroundIndex_;
            switch (backgroundIndex)
            {
                case 1:
                    textureBackground = contentManager.Load<Texture2D>("space");
                    break;
                case 2:
                    textureBackground = contentManager.Load<Texture2D>("space2");
                    break;
                case 3:
                    textureBackground = contentManager.Load<Texture2D>("space3");
                    break;
                case 4:
                    textureBackground = contentManager.Load<Texture2D>("space4");
                    break;
                case 5:
                    textureBackground = contentManager.Load<Texture2D>("space5");
                    break;
            }
        }

        public void SetAllVectors(bool isTrue)
        {
            showVectorsAll = isTrue;
            foreach (GravityObject o in gravitySystem.GravityObjects)
            {
                o.Vector = isTrue;
            }
        }

        public void SetAllTraces(bool isTrue)
        {
            showTrailsAll = isTrue;
            foreach (GravityObject o in gravitySystem.GravityObjects)
            {
                o.Trace = isTrue;
                if (isTrue==false)
                {
                    // remove all traces
                    o.GetTraces().Clear();
                }
            }
        }

        public void CreateSlingShot(int x, int y)
        {
            Random rnd = new Random();

            gravitySystem.AddObject("Planet", 25000000.0f, x, y, 10000, 0, texturePlanet, false, false);

            for (int k = 0; k < 8; k++)
            {
                gravitySystem.AddObject("Object " + (k*2+1).ToString(), 1.0f, x - 800 - k*120, y-10 - Math.Pow(k,2)*3, 25000, 0, textureMetalBall, true, true);
                gravitySystem.AddObject("Object " + (k*2+2).ToString(), 1.0f, x - 800 - k*120, y+10 + Math.Pow(k,2)*3, 25000, 0, textureMetalBall, true, true);
            }

            gravitySystem.ObjectIndex = 0;
            gravitySystem.CenterIndex = 0;     // center on first object

            gravitySystem.ScaleObjects();       // scale has changed by this setup
        }

        public void CreateGrid(int x_, int y_)
        {
            int startPosition = gravitySystem.GravityObjects.Count;
            double gridSpacingMeters = grid.Spacing * 1000000000;    // default million km.
            if (Grid.SpacingUnits.Equals("pixels"))
            {
                gridSpacingMeters = gravitySystem.PixelsToMeters(grid.Spacing);
            }
            double xCenter = gravitySystem.ScreenToRealCoordinateX(x_);
            double yCenter = gravitySystem.ScreenToRealCoordinateY(y_);
            int count = 0;
            for (double y = yCenter - (gridSpacingMeters * Grid.YAmount) * 0.5; y < yCenter + (gridSpacingMeters * Grid.YAmount) * 0.5; y+= gridSpacingMeters)
            {
                for (double x = xCenter - (gridSpacingMeters * Grid.XAmount) * 0.5; x < xCenter + (gridSpacingMeters * Grid.XAmount) * 0.5; x+= gridSpacingMeters)
                {
                    count++;
                    if (grid.Rotations == 0)
                    {
                        gravitySystem.AddObjectRealPosition("Grid object " + count, Grid.Mass, x, y, 0, 0, Grid.Texture, false, false);
                    }
                    else
                    {
                        double angleWithCenter = Math.Atan2(y - yCenter, x - xCenter);
                        angleWithCenter += (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
                        double distanceFromCenter = Math.Sqrt(Math.Pow(x - xCenter, 2) + Math.Pow(y - yCenter, 2));
                        double distancePerYear = distanceFromCenter * Math.PI * 2.0 * grid.Rotations;
                        double orbitalVelocity = distancePerYear / (24*60*60*365);
                        double XSpeed = Math.Cos(angleWithCenter) * orbitalVelocity;
                        double YSpeed = Math.Sin(angleWithCenter) * orbitalVelocity;
                        gravitySystem.AddObjectRealPosition("Grid object " + count, Grid.Mass, x, y, XSpeed, YSpeed, Grid.Texture, false, false);
                    }
                }
            }

            if (grid.XSpeed != 0)
            {
                for (int k = startPosition; k < gravitySystem.GravityObjects.Count; k++)
                {
                    gravitySystem.GravityObjects[k].XSpeed += grid.XSpeed;
                }
            }
            if (grid.YSpeed != 0)
            {
                for (int k = startPosition; k < gravitySystem.GravityObjects.Count; k++)
                {
                    gravitySystem.GravityObjects[k].YSpeed += grid.YSpeed;
                }
            }

            gravitySystem.ObjectIndex = 0;
            gravitySystem.CenterIndex = -1;     // no center object
        }

        public void CreateCircle(int x_, int y_)
        {
            int startPosition = gravitySystem.GravityObjects.Count;
            double circleSpacingMeters = circle.Spacing * 1000000000;    // default million km.
            if (Circle.SpacingUnits.Equals("pixels"))
            {
                circleSpacingMeters = gravitySystem.PixelsToMeters(circle.Spacing);
            }
            double xCenter = gravitySystem.ScreenToRealCoordinateX(x_);
            double yCenter = gravitySystem.ScreenToRealCoordinateY(y_);
            int count = 0;
            double maxDistance = circleSpacingMeters * Circle.NumObjectsRadius;
            for (double y = yCenter - (circleSpacingMeters * Circle.NumObjectsRadius); y <= yCenter + (circleSpacingMeters * Circle.NumObjectsRadius); y += circleSpacingMeters)
            {
                for (double x = xCenter - (circleSpacingMeters * Circle.NumObjectsRadius); x <= xCenter + (circleSpacingMeters * Circle.NumObjectsRadius); x += circleSpacingMeters)
                {
                    double distanceFromCenter = Math.Sqrt(Math.Pow(x - xCenter, 2) + Math.Pow(y - yCenter, 2));
                    count++;
                    if (distanceFromCenter < maxDistance)
                    {
                        if (circle.Rotations == 0)
                        {
                            gravitySystem.AddObjectRealPosition("Circle object " + count, Circle.Mass, x, y, 0, 0, Circle.Texture, false, false);
                        }
                        else
                        {
                            double angleWithCenter = Math.Atan2(y - yCenter, x - xCenter);
                            angleWithCenter += (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
                            double distancePerYear = distanceFromCenter * Math.PI * 2.0 * circle.Rotations;
                            double orbitalVelocity = distancePerYear / (24 * 60 * 60 * 365);
                            double XSpeed = Math.Cos(angleWithCenter) * orbitalVelocity;
                            double YSpeed = Math.Sin(angleWithCenter) * orbitalVelocity;
                            gravitySystem.AddObjectRealPosition("Circle object " + count, Circle.Mass, x, y, XSpeed, YSpeed, Circle.Texture, false, false);
                        }
                    }
                }
            }

            if (Circle.XSpeed != 0)
            {
                for (int k = startPosition; k < gravitySystem.GravityObjects.Count; k++)
                {
                    gravitySystem.GravityObjects[k].XSpeed += Circle.XSpeed;
                }
            }
            if (Circle.YSpeed != 0)
            {
                for (int k = startPosition; k < gravitySystem.GravityObjects.Count; k++)
                {
                    gravitySystem.GravityObjects[k].YSpeed += Circle.YSpeed;
                }
            }

            gravitySystem.ObjectIndex = 0;
            gravitySystem.CenterIndex = -1;     // no center object
        }


        public void CreateRandom(int x, int y)
        {
            Random rnd = new Random();
            double areaMeters = Convert.ToDouble(randomObjects.Area * 1000000000);    // default million km.
            if (randomObjects.AreaUnits.Equals("pixels"))
            {
                areaMeters = gravitySystem.PixelsToMeters(randomObjects.Area);
            }

            for (int k = 0; k < randomObjects.NumberOfObjects; k++)
            {
                double x_adjustPercentage = (rnd.Next(0, 2000) - 1000) / 2000.0;
                double y_adjustPercentage = (rnd.Next(0, 2000) - 1000) / 2000.0;
                double x_speed = 0;
                double y_speed = 0;
                if (randomObjects.Speed > 0)
                {
                    double direction = (rnd.Next(0, 10000) * 2 * Math.PI) / 10000.0;
                    x_speed = randomObjects.Speed * Math.Cos(direction);
                    y_speed = randomObjects.Speed * Math.Sin(direction);
                    if (randomObjects.SpeedRandomness > 0)
                    {
                        double adjustSpeedPercentage = 100 - randomObjects.SpeedRandomness + (2 * randomObjects.SpeedRandomness * rnd.Next(0, 10000) / 10000.0);
                        x_speed *= (adjustSpeedPercentage / 100);
                        adjustSpeedPercentage = 100 - randomObjects.SpeedRandomness + (2 * randomObjects.SpeedRandomness * rnd.Next(0, 10000) / 10000.0);
                        y_speed *= (adjustSpeedPercentage / 100);
                    }
                }
                gravitySystem.AddObjectRealPosition("Random object " + k.ToString(), randomObjects.Mass, x + (x_adjustPercentage * areaMeters), y + (y_adjustPercentage * areaMeters), x_speed, y_speed, randomObjects.Texture, false, false);
            }

            gravitySystem.ObjectIndex = 0;
            gravitySystem.CenterIndex = -1;     // no center object

            gravitySystem.ScaleObjects();       // scale has changed by this setup
        }


        /// <summary>
        /// Obtains normally (Gaussian) distributed random numbers, using the Box-Muller
        /// transformation.  This transformation takes two uniformly distributed deviates
        /// within the unit circle, and transforms them into two independently
        /// distributed normal deviates.
        /// </summary>
        /// <param name="sigma">The standard deviation of the distribution.  Default is one.</param>
        /// <param name="mu">The mean of the distribution.  Default is zero.</param>
        /// <returns></returns>
        public double CalculateDeviation(double sigma = 1, double mu = 0)
        {
            if (sigma <= 0)
                throw new ArgumentOutOfRangeException("sigma", "Must be greater than zero.");

            if (_hasDeviate)
            {
                _hasDeviate = false;
                return _storedDeviate * sigma + mu;
            }

            double v1, v2, rSquared;
            do
            {
                // two random values between -1.0 and 1.0
                v1 = 2 * rnd.NextDouble() - 1;
                v2 = 2 * rnd.NextDouble() - 1;
                rSquared = v1 * v1 + v2 * v2;
                // ensure within the unit circle
            } while (rSquared >= 1 || rSquared == 0);

            // calculate polar tranformation for each deviate
            var polar = Math.Sqrt(-2 * Math.Log(rSquared) / rSquared);
            // store first deviate
            _storedDeviate = v2 * polar;
            _hasDeviate = true;
            // return second deviate
            return v1 * polar * sigma + mu;
        }

        public void CreateGalaxy(int x_screen, int y_screen)
        {
            double x_real = gravitySystem.ScreenToRealCoordinateX(x_screen);
            double y_real = gravitySystem.ScreenToRealCoordinateY(y_screen);
            int startPosition = gravitySystem.GravityObjects.Count;
            int minMass = (int)(1000 - 1000 * galaxy.MassVariation / 100.0);
            int maxMass = (int)(1000 + 1000 * galaxy.MassVariation / 100.0);
            double averageMass = (galaxy.TotalMass / (double)galaxy.NumberOfObjects) * 1000;
            if (galaxy.HasBlackHole)
            {
                gravitySystem.AddObjectRealPosition("Black Hole", (long)galaxy.BlackHoleMass * 198910000, x_real, y_real, 0, 0, textureLargeDot, false, false);
            }

//            double max_radius = gravitySystem.MetersToPixels((galaxy.CrossSection / 2) * 1000000000000.0);
            double max_radius = (galaxy.CrossSection / 2.0) * 1000000000000.0;
            double outer_speed = 2 * Math.PI * (galaxy.CrossSection / 2.0) * 100000.0 / (galaxy.RotationPeriod * 3.1558150);  // in m/s (removed 7 zeroes from years and bln. km.)
            // speed of solar system should be about 2.2 X 10^5 meters per second
            // accelleration of solar system should be about  1.9 X 10^-10 meter per squared second
            int objectNumber = 0;

            if (galaxy.HasEllipse)
            {
                int numberOfObjects = galaxy.NumberOfObjects;
                if (galaxy.HasSpiral)        // percentage of objects is lost to spiral
                {
                    numberOfObjects = (int)(numberOfObjects * ((galaxy.EllipseObjectsPercentage) / 100.0));
                }
                for (int k = 0; k < numberOfObjects; k++)
                {
                    double angle = rnd.Next(0, 36000) / 100.0;
                    double mass = (double)(rnd.Next(minMass, maxMass)) * 198910000;
                    mass *= averageMass;
                    int random = rnd.Next(0, 1000);
                    random = (int)Math.Pow(random, 2);        // 0.. 1000000
                    double normal_deviation = CalculateDeviation(1);
                    double fuzzy_deviation = rnd.Next(-1000, 1000) / 1000.0;
                    double deviation = ((normal_deviation * (100-galaxy.EllipseBlurriness)) + (fuzzy_deviation * galaxy.EllipseBlurriness)) / 100.0;
                    double actual_radius = Math.Abs(deviation * max_radius * (galaxy.EllipseSizePercentage / 100.0));      // Math.Pow(minus,..) gives a NaN..
                    // for linear increase: speed = outer_speed * (actual_radius/max_radius)
                    // for ^2 increase: speed = (max_radius/actual_radius)^2 * outer_speed * (actual_radius/max_radius)
                    // -> increase: speed = (max_radius/actual_radius)^galaxy.VelocityIncreaseFactor * outer_speed * (actual_radius/max_radius)
                    double velocity = 0;
                    if (actual_radius>0)
                    {
                        velocity = Math.Pow((max_radius / actual_radius), galaxy.VelocityIncreaseFactor) * outer_speed * (actual_radius / max_radius);
                    }

                    // randomize velocity +/- 10%
                    velocity *= 0.9 + rnd.Next(0, 200) / 1000.0;

                    double direction_angle = angle - (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
                    Vector speed = new Vector();
                    speed.X = Math.Cos(direction_angle) * velocity;
                    speed.Y = Math.Sin(direction_angle) * velocity;

                    if (!galaxy.RotateCCW)
                    {
                        speed.X = -speed.X;
                        speed.Y = -speed.Y;
                    }
                    objectNumber++;
                    gravitySystem.AddObjectRealPosition("Star " + objectNumber, mass, x_real + actual_radius * Math.Cos(angle), y_real + actual_radius * galaxy.EllipseRatio * Math.Sin(angle), speed.X, speed.Y, textureSmallDot, galaxy.Color, false, false, false);
                }
            }

            if (galaxy.HasSpiral)
            {
                int numberOfObjects = galaxy.NumberOfObjects;
                if (galaxy.HasEllipse)        // percentage of objects is lost to ellipse
                {
                    numberOfObjects = (int)(numberOfObjects * ((100 - galaxy.EllipseObjectsPercentage) / 100.0));
                }
                numberOfObjects /= galaxy.NumberOfArms;
                double init_angle = 0;
                double angle_increase = 2 * Math.PI / galaxy.NumberOfArms;
                bool SolarSystemAdded = false;
                for (int spiral = 0; spiral < galaxy.NumberOfArms; spiral++)
                {
                    double current_angle = init_angle;
                    for (double radius = 0; radius < max_radius; radius += max_radius / numberOfObjects)
                    {
                        double mass = (double)(rnd.Next(minMass, maxMass)) * 198910000;
                        mass *= averageMass;
                        bool isBar = galaxy.HasBar && galaxy.NumberOfArms == 2 && ((radius / max_radius) * 100 < galaxy.BarPercentage);
                        if (!isBar)
                        {
                            if (galaxy.RotateCCW)
                            {
                                current_angle += (galaxy.ArmLength * 2 * Math.PI) / numberOfObjects;    // make ArmLength full circles
                            }
                            else
                            {
                                current_angle -= (galaxy.ArmLength * 2 * Math.PI) / numberOfObjects;    // make ArmLength full circles
                            }
                        }
                        double deviation = 1 + (CalculateDeviation(galaxy.SpiralBlurriness * (1 - ((radius / max_radius) / 1.2)))/200.0); // more deviation at center
//                        double deviation = CalculateDeviation(galaxy.EllipseBlurriness) / (2 * galaxy.EllipseBlurriness);
                        double actual_radius = Math.Abs(deviation * radius);      // Math.Pow(minus,..) gives a NaN..

                        double adjust_x = Math.Cos(current_angle) * actual_radius;
                        double adjust_y = Math.Sin(current_angle) * actual_radius;

                        // for linear increase: speed = outer_speed * (actual_radius/max_radius)
                        // for ^2 increase: speed = (max_radius/actual_radius)^2 * outer_speed * (actual_radius/max_radius)
                        // -> increase: speed = (max_radius/actual_radius)^galaxy.VelocityIncreaseFactor * outer_speed * (actual_radius/max_radius)
                        double velocity = 0;
                        if (actual_radius > 0)
                        {
                            velocity = Math.Pow((max_radius / actual_radius), galaxy.VelocityIncreaseFactor) * outer_speed * (actual_radius / max_radius);
                        }
                        double direction_angle = current_angle - (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
                        Vector speed = new Vector();
                        speed.X = Math.Cos(direction_angle) * velocity;
                        speed.Y = Math.Sin(direction_angle) * velocity;

                        if (!galaxy.RotateCCW)
                        {
                            speed.X = -speed.X;
                            speed.Y = -speed.Y;
                        }

                        objectNumber++;
                        if (objectNumber <= galaxy.NumberOfObjects)       // neccessary because of rounding issues
                        {
                            if (!isBar)
                            {
                                if (galaxy.AddSolarSystem && !SolarSystemAdded && spiral == galaxy.NumberOfArms - 1 && ((radius / max_radius) > 0.75))     // add solar system in last spiral at 75%
                                {
                                    SolarSystemAdded = true;
                                    CreateSolarSystemInGalaxy(x_real + actual_radius * Math.Cos(current_angle), y_real + actual_radius * Math.Sin(current_angle), speed.X, speed.Y);
                                    gravitySystem.AddObjectRealPosition("Alpha Centauri", mass, x_real + actual_radius * Math.Cos(current_angle), y_real + actual_radius * Math.Sin(current_angle), speed.X, speed.Y, textureSmallDot, galaxy.Color, false, false, false);      // 40 trillion m away
                                }
                                else
                                {
                                    gravitySystem.AddObjectRealPosition("Star " + objectNumber, mass, x_real + actual_radius * Math.Cos(current_angle), y_real + actual_radius * Math.Sin(current_angle), speed.X, speed.Y, textureSmallDot, galaxy.Color, false, false, false);
                                }
                            }
                            else
                            {
                                deviation = CalculateDeviation(galaxy.SpiralBlurriness * (1 - ((radius / max_radius) / 1.2))) / 1500.0;  // more deviation at center
                                gravitySystem.AddObjectRealPosition("Star " + objectNumber, mass, x_real + actual_radius * 0.85 /*prevent too long bar */ * Math.Cos(current_angle), y_real + (deviation * max_radius), speed.X, speed.Y, textureSmallDot, galaxy.Color, false, false, false);
                            }
                        }
                    }

                    init_angle += angle_increase;
                }
            }

            if (!galaxy.AddSolarSystem)
            {
                gravitySystem.ObjectIndex = -1;     // no object selected
                parentForm.gradientPanelObjectProperties.Visible = false;
            }

            gravitySystem.CenterIndex = -1;     // no center object
            gravitySystem.ScaleObjects();       // scale has changed by this setup
            updateSmallDots(startPosition);      // We need to set the color of each star on "random color" mode seperately

            if (galaxy.CalculateStableSpeed)
            {
                Refresh();
                gravitySystem.StabilizeObjectsSpeeds(startPosition, galaxy.RotateCCW);
            }
            if (galaxy.XSpeed != 0)
            {
                for (int k = startPosition; k < gravitySystem.GravityObjects.Count; k++)
                {
                    gravitySystem.GravityObjects[k].XSpeed += galaxy.XSpeed;
                }
            }
            if (galaxy.YSpeed != 0)
            {
                for (int k = startPosition; k < gravitySystem.GravityObjects.Count; k++)
                {
                    gravitySystem.GravityObjects[k].YSpeed += galaxy.YSpeed;
                }
            }
        }


        public void CreateSunPlanetMoon(int x, int y)
        {
            gravitySystem.AddObject("Sun", 100000000.0, x, y, -10, -80, textureSun, false, false);
            gravitySystem.AddObject("Planet", 1000000.0, x + 350, y, 0, 25000, textureEarth, true, false);
            gravitySystem.AddObject("Moon", 10.0, x + 370, y, 0, 32950, textureMoon, true, false);     // +4100
            if (gravitySystem.GravityObjects.Count == 3)      // no objects before this setup; select sun, center on sun
            {
                gravitySystem.ObjectIndex = 0;       // sun
                gravitySystem.CenterIndex = 0;
            }
            gravitySystem.ScaleObjects();       // scale has changed by this setup
        }

        public void CreateMoonMoon(int x, int y)
        {
            gravitySystem.AddObject("Sun", 1000000000000.0, x, y, -50, -100, textureSun, false, false);
            gravitySystem.AddObject("Planet", 20000000000.0, x + 500, y, 0, 1220000, textureEarth, true, false);
            gravitySystem.AddObject("Moon", 5000000000.0, x + 525, y, 0, 2080000, textureMoon, true, false);     // +4100
            gravitySystem.AddObject("Moon of a moon", 1.0, x + 526, y, 0, 4080000, textureAsteroid, true, false);     // +4100
            if (gravitySystem.GravityObjects.Count == 4)      // no objects before this setup; select sun, center on sun
            {
                gravitySystem.ObjectIndex = 0;          // sun
                gravitySystem.CenterIndex = 1;          // planet
            }
            parentForm.macTrackBarScale.Value = 327;

            gravitySystem.ScaleObjects();       // scale has changed by this setup
        }
      

        public void CreateSunPlanet(int x, int y)
        {
            gravitySystem.AddObject("Sun", 100000000.0, x, y, 0, -5, textureSun, false, false);
            gravitySystem.AddObject("Planet", 500.0, x + 350, y, 0, 25000, texturePlanet, true, false);
            if (gravitySystem.GravityObjects.Count == 2)      // no objects before this setup; select planet, center on sun
            {
                gravitySystem.ObjectIndex = 1;       // planet
                gravitySystem.CenterIndex = 0;       // sun
            }
            gravitySystem.ScaleObjects();       // scale has changed by this setup
        }

        public void CreatePlanetMoon(int x, int y)
        {
            gravitySystem.AddObject("Planet", 1000.0, x, y, 0, -5, textureEarth, true, false);
            gravitySystem.AddObject("Moon", 5.0, x + 300, y, 0, 1100, textureMoon, true, false);
            if (gravitySystem.GravityObjects.Count == 2)      // no objects before this setup; select planet, center on planet
            {
                gravitySystem.ObjectIndex = 0;       // planet
                gravitySystem.CenterIndex = 0;
            }
            gravitySystem.ScaleObjects();       // scale has changed by this setup
        }

        public void CreateDualStar(double x, double y)
        {
            gravitySystem.AddObject("Sun 1", 4000000000.0, x - 390, y - 10, 0, 44000, textureSun, true, false);
            gravitySystem.AddObject("Sun 2", 4000000000.0, x + 390, y + 10, 0, -44000, textureSun, true, false);
            gravitySystem.AddObject("Planet 1", 1000.0, x + 415, y + 10, 0, -500000, texturePlanet, true, false);
            gravitySystem.AddObject("Planet 2", 1000.0, x - 415, y - 10, 0, 500000, texturePlanet, true, false);
            if (gravitySystem.GravityObjects.Count == 4)      // no objects before this setup; select planet, no center object
            {
                gravitySystem.ObjectIndex = 1;       // planet
                gravitySystem.CenterIndex = -1;
            }
            gravitySystem.ScaleObjects();
        }

        public void CreateDualStar2(double x, double y)
        {
            gravitySystem.AddObject("Sun 1", 198900000.0, x - 150, y-10, 0, 20000, textureSun, true, false);
            gravitySystem.AddObject("Sun 2", 198900000.0, x + 150, y+10, 0, -20000, textureSun, true, false);
            gravitySystem.AddObject("Planet", 597.2, x + 400, y - 50, 0, 40000, texturePlanet, true, false);
            if (gravitySystem.GravityObjects.Count == 3)      // no objects before this setup; select planet, no center object
            {
                gravitySystem.ObjectIndex = 2;       // planet
                gravitySystem.CenterIndex = -1;
            }
            gravitySystem.ScaleObjects();
        }

        public void CreateDualStar3(double x, double y)
        {
            gravitySystem.AddObject("Sun 1", 2000000000.0, x - 390, y, 0, 24900, textureSun, true, false);
            gravitySystem.AddObject("Sun 2", 2000000000.0, x + 390, y, 0, -24900, textureSun, true, false);
            gravitySystem.AddObject("Planet", 100.0, x + 450, y + 10, 0, -190000, texturePlanet, true, false);
            if (gravitySystem.GravityObjects.Count == 3)      // no objects before this setup; select planet, no center object
            {
                gravitySystem.ObjectIndex = 1;       // planet
                gravitySystem.CenterIndex = -1;
            }
            gravitySystem.ScaleObjects();
        }

        public void CreateTripleStar(double x, double y)
        {
            double radius = 390;
            double speed = 64000;
            double mass = 2400000000.0f;
            double angle = 0.0f;
            double speed_angle = angle + (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
            double XSpeed = Math.Cos(speed_angle) * speed;
            double YSpeed = Math.Sin(speed_angle) * speed;
            gravitySystem.AddObject("Sun 1", mass, Math.Cos(angle) * radius + x, Math.Sin(angle) * radius + y, XSpeed, YSpeed, textureSun, true, false);
            gravitySystem.AddObject("Planet 1", 1000.0, Math.Cos(angle) * radius + x + 30, Math.Sin(angle) * radius + y, XSpeed, YSpeed + 330000, texturePlanet, true, false);
            angle = Math.PI / 1.5;       // 120 degrees
            speed_angle = angle + (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
            XSpeed = Math.Cos(speed_angle) * speed;
            YSpeed = Math.Sin(speed_angle) * speed;
            gravitySystem.AddObject("Sun 2", mass, Math.Cos(angle) * radius + x, Math.Sin(angle) * radius + y, XSpeed, YSpeed, textureSun, true, false);
            angle = Math.PI / 0.75;       // 240 degrees
            speed_angle = angle + (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
            XSpeed = Math.Cos(speed_angle) * speed;
            YSpeed = Math.Sin(speed_angle) * speed;
            gravitySystem.AddObject("Sun 3", mass, Math.Cos(angle) * radius + x, Math.Sin(angle) * radius + y, XSpeed, YSpeed, textureSun, true, false);
//            if (gravitySystem.GetGravityObjects().Count == 4)      // no objects before this setup
            {
                gravitySystem.ObjectIndex = 0;       // sun 1
                gravitySystem.CenterIndex = -1;
            }
            gravitySystem.ScaleObjects();
        }

        public void CreateSolarSystemInGalaxy(double x, double y, double GalaxySpeedX, double GalaxySpeedY)
        {
            PositionSpeed posSpeed = CalculatePositionSpeed(49, -104, -47400, 57900000000);
            gravitySystem.AddObjectRealPosition("Mercury", 32.85, posSpeed.X + x, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed, textureMercury, false, false);

            posSpeed = CalculatePositionSpeed(-111, -131, -35000, 108200000000);
            gravitySystem.AddObjectRealPosition("Venus", 486.7, posSpeed.X + x, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed, textureVenus, false, false);

            posSpeed = CalculatePositionSpeed(42, -228, -29800, 149600000000);
            gravitySystem.AddObjectRealPosition("Earth", 597.2, posSpeed.X + x, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed, textureEarth, false, false);

            // for simplicity, the moon is placed at its mean distance from the earth, with added its orbital velocity
            gravitySystem.AddObjectRealPosition("Moon", 7.342, posSpeed.X + x + 385000000, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed + 1022, textureMoon, false, false);

            posSpeed = CalculatePositionSpeed(-275, -81, -24100, 227900000000);
            gravitySystem.AddObjectRealPosition("Mars", 63.9, posSpeed.X + x, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed, textureMars, false, false);

            posSpeed = CalculatePositionSpeed(340, 66, -13100, 778600000000);
            gravitySystem.AddObjectRealPosition("Jupiter", 189800.0, posSpeed.X + x, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed, textureJupiter, false, false);

            posSpeed = CalculatePositionSpeed(76, 396, -9700, 1433500000000);
            gravitySystem.AddObjectRealPosition("Saturn", 56830.0, posSpeed.X + x, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed, textureSaturn, false, false);

            posSpeed = CalculatePositionSpeed(-422, -181, -6800, 2872500000000);
            gravitySystem.AddObjectRealPosition("Uranus", 8681.0, posSpeed.X + x, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed, textureUranus, false, false);

            posSpeed = CalculatePositionSpeed(-487, 168, -5400, 4495100000000);
            gravitySystem.AddObjectRealPosition("Neptune", 10240.0, posSpeed.X + x, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed, textureNeptune, false, false);

            posSpeed = CalculatePositionSpeed(-159, 522, -4700, 5906400000000);       // 5906400000000 = 984 pixels at scale 50;
            gravitySystem.AddObjectRealPosition("Pluto", 1.31, posSpeed.X + x, posSpeed.Y + y, GalaxySpeedX + posSpeed.XSpeed, GalaxySpeedY + posSpeed.YSpeed, texturePluto, false, false);

            gravitySystem.AddObjectRealPosition("Sun", 198900000.0, x, y, GalaxySpeedX, GalaxySpeedY, textureSun, false, false);

            gravitySystem.ObjectIndex = gravitySystem.GravityObjects.FindIndex(a => a.Name == "Earth");

            gravitySystem.MinimumTextureSize = 1;
        }

        public void CreateSolarSystem(double x, double y, bool AddJWST = false)
        {
            x = gravitySystem.ScreenToRealCoordinateX(x);
            y = gravitySystem.ScreenToRealCoordinateY(y);

            gravitySystem.AddObjectRealPosition("Sun", 198900000.0, x, y, 0, 0, textureSun, true, false);

            PositionSpeed posSpeed = CalculatePositionSpeed(49, -104, -47400, 57900000000);
            gravitySystem.AddObjectRealPosition("Mercury", 32.85, posSpeed.X+x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, textureMercury, true, false);

            posSpeed = CalculatePositionSpeed(-111, -131, -35000, 108200000000);
            gravitySystem.AddObjectRealPosition("Venus", 486.7, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, textureVenus, true, false);

            posSpeed = CalculatePositionSpeed(42, -228, -29800, 149600000000);
            gravitySystem.AddObjectRealPosition("Earth", 597.2, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, textureEarth, true, false);

            // for simplicity, the moon is placed at its mean distance from the earth, with added its orbital velocity
            gravitySystem.AddObjectRealPosition("Moon", 7.342, posSpeed.X + x + 385000000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 1022, textureMoon, true, false);

            /* at the moment not accurate enough
            if (AddJWST)    // add James Webb Space Telescope at L2 point
            {
                posSpeed = CalculatePositionSpeed(42, -228, 1.00 * (2 * Math.PI * (149600000000 + 1500000000)) / 31556926.0, 149600000000 + 1500000000);
                GravitySystem.AddObjectRealPosition("James Webb Telescope",
                    0.00000000065,
                    posSpeed.X + x, posSpeed.Y + y,
                    posSpeed.XSpeed, posSpeed.YSpeed,   
                    textureLargeDot, true, false);        
            }
            */

            posSpeed = CalculatePositionSpeed(-275, -81, -24100, 227900000000);
            gravitySystem.AddObjectRealPosition("Mars", 63.9, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, textureMars, true, false);

            posSpeed = CalculatePositionSpeed(340, 66, -13100, 778600000000);
            gravitySystem.AddObjectRealPosition("Jupiter", 189800.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, textureJupiter, true, false);

            posSpeed = CalculatePositionSpeed(76, 396, -9700, 1433500000000);
            gravitySystem.AddObjectRealPosition("Saturn", 56830.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, textureSaturn, true, false);

            posSpeed = CalculatePositionSpeed(-422, -181, -6800, 2872500000000);
            gravitySystem.AddObjectRealPosition("Uranus", 8681.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, textureUranus, true, false);

            posSpeed = CalculatePositionSpeed(-487, 168, -5400, 4495100000000); 
            gravitySystem.AddObjectRealPosition("Neptune", 10240.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, textureNeptune, true, false);

            posSpeed = CalculatePositionSpeed(-159, 522, -4700, 5906400000000);       // 5906400000000 = 984 pixels at scale 50;
            gravitySystem.AddObjectRealPosition("Pluto", 1.31, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, texturePluto, true, false);

            if (gravitySystem.GravityObjects.Count == 11)      // no objects before this setup; select sun, center on sun
            {
                gravitySystem.ObjectIndex = 3;       // earth
                gravitySystem.CenterIndex = 0;       // sun
            }

            gravitySystem.ScaleObjects();
        }

        public void CreateSolarSystemMoons(double x, double y)
        {
            x = gravitySystem.ScreenToRealCoordinateX(x);
            y = gravitySystem.ScreenToRealCoordinateY(y);

            gravitySystem.AddObjectRealPosition("Sun", 198900000.0, x, y, 0, 0, textureSun, true, false);

            PositionSpeed posSpeed = CalculatePositionSpeed(49, -104, -47400, 57900000000);
            gravitySystem.AddObjectRealPosition("Mercury", 32.85, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, textureMercury, true, false);

            posSpeed = CalculatePositionSpeed(-111, -131, -35000, 108200000000);
            gravitySystem.AddObjectRealPosition("Venus", 486.7, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, textureVenus, true, false);

            posSpeed = CalculatePositionSpeed(42, -228, -29800, 149600000000);
            gravitySystem.AddObjectRealPosition("Earth", 597.2, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, textureEarth, true, false);

            // for simplicity, the moon is placed at its mean distance from the earth, with added its orbital velocity
            gravitySystem.AddObjectRealPosition("Moon", 7.342, posSpeed.X + x + 385000000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 1022, textureMoon, true, false);

            posSpeed = CalculatePositionSpeed(-275, -81, -24100, 227900000000);
            gravitySystem.AddObjectRealPosition("Mars", 63.90000000, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, textureMars, true, false);

            gravitySystem.AddObjectRealPosition("Phobos", 0.0000010659, posSpeed.X + x + 9377000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 2138, textureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Deimos", 0.0000001471, posSpeed.X + x - 23436000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 1351, textureAsteroid, true, false);

            posSpeed = CalculatePositionSpeed(0, 1, -17905, 419000000000);
            gravitySystem.AddObjectRealPosition("Ceres", 0.09393, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, textureAsteroid, true, false);

            posSpeed = CalculatePositionSpeed(340, 66, -13100, 778600000000);
            gravitySystem.AddObjectRealPosition("Jupiter", 189800.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, textureJupiter, true, false);

            gravitySystem.AddObjectRealPosition("Io", 8.9319, posSpeed.X + x + 421700000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 17334, textureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Europa", 4.8, posSpeed.X + x - 671034000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 13740, textureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Ganymede", 14.819, posSpeed.X + x + 1070412000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 10880, textureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Callisto", 10.759, posSpeed.X + x - 1882709000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 8204, textureAsteroid, true, false);

            posSpeed = CalculatePositionSpeed(76, 396, -9700, 1433500000000);
            gravitySystem.AddObjectRealPosition("Saturn", 56830.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, textureSaturn, true, false);

            gravitySystem.AddObjectRealPosition("Dione", 0.11, posSpeed.X + x + 377396000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 10030, textureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Rhea", 0.23, posSpeed.X + x + 527108000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed + 8480, textureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Titan", 13.5, posSpeed.X + x - 1221870000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 5570, textureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Iapetus", 0.18, posSpeed.X + x - 3560820000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 3260, textureAsteroid, true, false);

            posSpeed = CalculatePositionSpeed(-422, -181, -6800, 2872500000000);
            gravitySystem.AddObjectRealPosition("Uranus", 8681.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, textureUranus, true, false);

            gravitySystem.AddObjectRealPosition("Miranda", 0.00659, posSpeed.X + x - 377396000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 6660, textureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Ariel", 0.1353, posSpeed.X + x - 191020000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 5510, textureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Umbriel", 0.1172, posSpeed.X + x - 266300000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 4670, textureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Titania", 0.3527, posSpeed.X + x - 435910000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 3640, textureAsteroid, true, false);
            gravitySystem.AddObjectRealPosition("Oberon", 0.3014, posSpeed.X + x - 583520000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 3150, textureAsteroid, true, false);

            posSpeed = CalculatePositionSpeed(-487, 168, -5400, 4495100000000);
            gravitySystem.AddObjectRealPosition("Neptune", 10240.0, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, textureNeptune, true, false);

            gravitySystem.AddObjectRealPosition("Triton", 2.1408, posSpeed.X + x - 354759000, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed - 4390, textureAsteroid, true, false);

            posSpeed = CalculatePositionSpeed(-159, 522, -4700, 5906400000000);       // 5906400000000 = 984 pixels at scale 50;
            gravitySystem.AddObjectRealPosition("Pluto", 1.31, posSpeed.X + x, posSpeed.Y + y, posSpeed.XSpeed, posSpeed.YSpeed, texturePluto, true, false);

//            if (gravitySystem.GetGravityObjects().Count == 11)      // no objects before this setup; select sun, center on sun
            {
                gravitySystem.ObjectIndex = 3;       // earth
                gravitySystem.CenterIndex = 0;       // sun
            }

            gravitySystem.ScaleObjects();
        }

        private PositionSpeed CalculatePositionSpeed(double x, double y, double orbitalVelocity, double radius)
        {
            PositionSpeed posSpeed = new PositionSpeed();
            double angle = Math.Atan2(y, x);

            // ----- adjustment for position compared to 1/1/2017
            TimeSpan diff = simulationTime.Subtract(new DateTime(2017,1,1));
            // Calculate how many radians/s the planet is moving. orbitalVelocity in m/s, radius in m
            double radiansPerSecond = orbitalVelocity / radius;
            angle += diff.TotalSeconds* radiansPerSecond;
            // --------------------------------------------------

            posSpeed.X = Math.Cos(angle) * radius;
            posSpeed.Y = Math.Sin(angle) * radius;
            angle += (0.5 * Math.PI);       // rotate 90 degrees to obtain the angle of movement
            posSpeed.XSpeed = Math.Cos(angle) * orbitalVelocity;
            posSpeed.YSpeed = Math.Sin(angle) * orbitalVelocity;

            return posSpeed;
        }

        public Texture2D getTextureByName(string text)
        {
            Texture2D texture = null;

            switch (text)
            {
                case "Planet":
                    texture = texturePlanet;
                    break;
                case "Earth":
                    texture = textureEarth;
                    break;
                case "Sun":
                    texture = textureSun;
                    break;
                case "Moon":
                    texture = textureMoon;
                    break;
                case "Mercury":
                    texture = textureMercury;
                    break;
                case "Venus":
                    texture = textureVenus;
                    break;
                case "Mars":
                    texture = textureMars;
                    break;
                case "Jupiter":
                    texture = textureJupiter;
                    break;
                case "Saturn":
                    texture = textureSaturn;
                    break;
                case "Uranus":
                    texture = textureUranus;
                    break;
                case "Neptune":
                    texture = textureNeptune;
                    break;
                case "Pluto":
                    texture = texturePluto;
                    break;
                case "Red Ball":
                    texture = textureRedBall;
                    break;
                case "Metal Ball":
                    texture = textureMetalBall;
                    break;
                case "Golden Ball":
                    texture = textureGoldenBall;
                    break;
                case "Point":
                case "Large Dot":
                    texture = textureLargeDot;
                    break;
                case "<Custom Shape>":
                    texture = textureSmallDot;
                    break;
                case "Asteroid":
                    texture = textureAsteroid;
                    break;
            }

            return texture;
        }

        public void AddGravityObject(int X, int Y, bool circleHost=false, bool circleHostCCW = false)
        {
            Texture2D texture = getTextureByName(parentForm.comboBoxShape.Text);

            double xSpeed = Convert.ToDouble(parentForm.textBoxXSpeed.Text);
            double ySpeed = Convert.ToDouble(parentForm.textBoxYSpeed.Text);

            if ((circleHost || circleHostCCW) && gravitySystem.GravityObjects.Count>0)
            {
                GravityObject hostObject = gravitySystem.findBestHost(X, Y);
                Vector speed = gravitySystem.calcSpeedFromHost(hostObject, X, Y, Convert.ToDouble(parentForm.textBoxMass.Text));
                xSpeed = speed.X;
                ySpeed = speed.Y;
                if(circleHostCCW)
                {
                    xSpeed = -xSpeed;
                    ySpeed = -ySpeed;
                }
            }


            gravitySystem.AddObject(parentForm.textBoxName.Text, 
                Convert.ToDouble(parentForm.textBoxMass.Text),
                X, Y, xSpeed, ySpeed,
                texture, parentForm.checkBoxTrace.Checked, parentForm.checkBoxVector.Checked);

            // perform calculation to show right vectors
            gravitySystem.CalculateStep(1/*timeUnitsPerStep*/, false);
        }
        

        void DrawLine(SpriteBatch sb, Vector2 start, Vector2 end, int width)
        {
            Vector2 edge = end - start;
            // calculate angle to rotate line
            float angle =
                (float)Math.Atan2(edge.Y, edge.X);


            sb.Draw(textureLine,
                new Rectangle(// rectangle defines shape of line and position of start of line
                    (int)start.X,
                    (int)start.Y,
                    (int)edge.Length(), //sb will strech the texture to fill this rectangle
                    width), //width of line, change this to make thicker line
                null,
                Color.White, //colour of line
                angle,     //angle of line (calulated above)
                new Vector2(0, 0), // point in line about which to rotate
                SpriteEffects.None,
                0);

        }

        override protected void Draw()
        {
            GraphicsDevice.Clear(Color.Black);

            try {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

                // Draw background
                Rectangle rect;
                if (BackgroundIndex>0)
                {
                    rect = new Rectangle(0, 0, Width, Height);
                    spriteBatch.Draw(textureBackground, rect, Color.White);
                }

                // Adjust to center of object if object is centered
                GravitySystem.CenterOnObject();

                // Traces
                foreach (GravityObject o in gravitySystem.GravityObjects)
                {
                    if (o.Trace)
                    {
                        for (int i = 0; i < o.GetTraces().Count; i++)
                        {
                            Trace trace = o.GetTraces()[i];
                            if (trace.isAlive())
                            {
                                try
                                {
                                    int screen_x = gravitySystem.RealtoScreenCoordinateX(trace.X);
                                    int screen_y = gravitySystem.RealtoScreenCoordinateY(trace.Y);
                                    if (screen_x > -GraphicsDevice.Viewport.Width && screen_x < 2 * GraphicsDevice.Viewport.Width
                                        && screen_y > -GraphicsDevice.Viewport.Height && screen_y < 2 * GraphicsDevice.Viewport.Height)
                                    {
                                        spriteBatch.Draw(textureTrace, new Rectangle(screen_x, screen_y, textureTrace.Width, textureTrace.Height), trace.Color);
                                    }
                                }
                                catch (OverflowException)
                                {
                                    o.GetTraces().RemoveAt(i);
                                }

                            }
                            else
                            {
                                o.GetTraces().RemoveAt(i);
                            }
                        }
                    }
                }

                foreach (GravityObject o in gravitySystem.GravityObjects)
                {
                    double screen_x = gravitySystem.RealtoScreenCoordinateX(o.X);
                    double screen_y = gravitySystem.RealtoScreenCoordinateY(o.Y);

                    // Vector
                    if (o.Vector)
                    {
                        if (screen_x > -GraphicsDevice.Viewport.Width && screen_x < 2 * GraphicsDevice.Viewport.Width
                            && screen_y > -GraphicsDevice.Viewport.Height && screen_y < 2 * GraphicsDevice.Viewport.Height)
                        {
                            spriteBatch.Draw(textureVector, new Rectangle(Convert.ToInt32(screen_x), Convert.ToInt32(screen_y), textureVector.Width, textureVector.Height), null, Color.White, (float)o.AccelerationAngle, new Vector2(0, textureVector.Height / 2), SpriteEffects.None, 0f);
//                            spriteBatch.Draw(textureVector, new Rectangle(Convert.ToInt32(screen_x), Convert.ToInt32(screen_y), textureVector.Width, textureVector.Height), null, Color.Red, (float)o.SpeedAngle, new Vector2(0, textureVector.Height / 2), SpriteEffects.None, 0f);
//                            spriteBatch.DrawString(fontSmall, o.Acceleration.ToString(), new Vector2((float)screen_x, (float)screen_y), Color.LightGray);
                        }
                    }

                    spriteBatch.End();
                    spriteBatch.Begin(SpriteSortMode.Deferred, blendState);

                    // Object
                    try {
                        if (screen_x > -GraphicsDevice.Viewport.Width && screen_x < 2 * GraphicsDevice.Viewport.Width
                            && screen_y > -GraphicsDevice.Viewport.Height && screen_y < 2 * GraphicsDevice.Viewport.Height)
                        {

                            if (!showAsDots)
                            {
                                rect = new Rectangle(Convert.ToInt32(screen_x - o.ScaledTextureWidth / 2), Convert.ToInt32(screen_y - o.ScaledTextureHeight / 2), o.ScaledTextureWidth, o.ScaledTextureHeight);
                                double percentage = 0;
                                if (smallDot.ColorCoding > 0 && smallDot.ColorCoding < 4 && gravitySystem.SpeedRange > 0)
                                {
                                    percentage = (o.Speed - gravitySystem.MinSpeed) / gravitySystem.SpeedRange;
                                }
                                else if (smallDot.ColorCoding > 3 && gravitySystem.AccelerationRange > 0)
                                {
                                    percentage = (o.Acceleration - gravitySystem.MinAcceleration) / gravitySystem.AccelerationRange;
                                }
                                if (percentage > 1)  // range is not 100% accurate for speed reasons
                                {
                                    percentage = 1;
                                }
                                
                                if (smallDot.ColorCoding==1 || smallDot.ColorCoding == 4)        // range is not 100% accurate for speed reasons
                                {
                                    int color = Convert.ToInt32(percentage * 255);
                                    int color2 = 127 + Convert.ToInt32(percentage * 128);
                                    int color3 = 255 - Convert.ToInt32(percentage * 255);
                                    spriteBatch.Draw(o.Texture, rect, new Color(color, color2, color3, 255));
                                }
                                else if (smallDot.ColorCoding == 2 || smallDot.ColorCoding == 5)
                                {
                                    int color = Convert.ToInt32(percentage * 255);
                                    int color2 = 255 - Convert.ToInt32(percentage * 255);
                                    int color3 = Convert.ToInt32(percentage * 512) % 255;
                                    spriteBatch.Draw(o.Texture, rect, new Color(color, color2, color3, 255));
                                }
                                else if (smallDot.ColorCoding == 3 || smallDot.ColorCoding == 6)
                                {
                                    int color = 100 + Convert.ToInt32(percentage * 155);
                                    int color2 = Convert.ToInt32(percentage * 255);
                                    int color3 = 2 * Convert.ToInt32(percentage * 255);
                                    spriteBatch.Draw(o.Texture, rect, new Color(color, color2, color3, 255));
                                }
                                else
                                {
                                    spriteBatch.Draw(o.Texture, rect, Color.White);
                                }

                            }
                            else
                            {
                                rect = new Rectangle(Convert.ToInt32(screen_x - textureLargeDot.Width / 2), Convert.ToInt32(screen_y - textureLargeDot.Height / 2), textureLargeDot.Width, textureLargeDot.Height);
                                spriteBatch.Draw(textureLargeDot, rect, Color.White);
                            }
                        }
                    } catch (OverflowException)
                    {
                        gravitySystem.GravityObjects.Remove(o);
                    }

                    spriteBatch.End();
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

                    // Object name
                    if (showNames)
                    {
                        spriteBatch.DrawString(fontSmall, o.Name, new Vector2((float)(screen_x + o.ScaledTextureWidth / 2), (float)(screen_y + o.ScaledTextureHeight / 2)), Color.LightGray);
                    }

                }

                // Scale display
                if (showScale)
                {
                    // at scale 1, one pixel = 1000 km
                    // we want maximum 1000 pixels and minimum 100 pixels
                    Double beamLength = (1000.0 / gravitySystem.Scale);
                    long factor = 1;
                    while (beamLength < 100)
                    {
                        factor *= 10;
                        beamLength = (1000.0 * factor / (gravitySystem.Scale));
                    }

                    DrawLine(spriteBatch, new Vector2(900, GraphicsDevice.Viewport.Height - 80), new Vector2(900 + 900 * factor / gravitySystem.Scale, GraphicsDevice.Viewport.Height - 80), 3);
                    DrawLine(spriteBatch, new Vector2(900, GraphicsDevice.Viewport.Height - 80), new Vector2(900, GraphicsDevice.Viewport.Height - 90), 2);
                    DrawLine(spriteBatch, new Vector2(898 + 900 * factor / gravitySystem.Scale, GraphicsDevice.Viewport.Height - 80), new Vector2(898 + 900 * factor / gravitySystem.Scale, GraphicsDevice.Viewport.Height - 90), 2);
                    spriteBatch.DrawString(fontLindsey, "0", new Vector2(900, GraphicsDevice.Viewport.Height - 80), Color.White);
                    string maxScaleText = factor.ToString() + " mln. km";
                    if (factor >= 1000)
                    {
                        maxScaleText = (factor / 1000).ToString() + " bln. km";
                    }
                    if (factor >= 1000000)
                    {
                        maxScaleText = (factor / 1000000).ToString() + " tln. km";
                    }
                    if (factor >= 1000000000)
                    {
                        maxScaleText = (factor / 1000000000).ToString() + " qdn. km";
                    }
                    spriteBatch.DrawString(fontLindsey, maxScaleText, new Vector2(GraphicsDevice.Viewport.Width - 1040 + 900 * factor / gravitySystem.Scale, GraphicsDevice.Viewport.Height - 80), Color.White);
                }

                // Simulation time
                if (timeUnitsPerStep <= 31558150)
                {
                    spriteBatch.DrawString(fontNormal, simulationTime.ToString("MM/dd/yyyy HH:mm"), new Vector2(20, GraphicsDevice.Viewport.Height - 140), Color.White);
                }
                else
                {
                    spriteBatch.DrawString(fontNormal, "Year: " + string.Format("{0:n0}",simulationTimeLarge), new Vector2(20, GraphicsDevice.Viewport.Height - 140), Color.White);
                }

                // Calculations per step
                if (GravitySystem.CalculationsPerStepSetting == -2)
                {
                    if (gravitySystem.IsCalculating)
                    {
                        string text = "calculating frame: " + gravitySystem.FrameNumberCalc + "/" + gravitySystem.NumPrecalculatedFrames();
                        if (gravitySystem.CalculationsPerStepPrecalculated > 1)
                        {
                            text += " (" + gravitySystem.CalculationsPerStepPrecalculated + " steps/frame)";
                        }
                        spriteBatch.DrawString(fontSmall, text, new Vector2(20, GraphicsDevice.Viewport.Height - 200), Color.LightGray);
                    }
                }
                else
                {
                    spriteBatch.DrawString(fontSmall, "calculations/step: " + gravitySystem.CalculationsPerStepActual.ToString(), new Vector2(20, GraphicsDevice.Viewport.Height - 200), Color.LightGray);
                }
                if (gravitySystem.CalculationsPerStepSetting == -2)
                {
                    spriteBatch.DrawString(fontSmall, "playing frame: " + gravitySystem.FrameNumberPlay, new Vector2(20, GraphicsDevice.Viewport.Height - 170), Color.LightGray);
                }

                if(gravitySystem.Message.Time >0)
                {
                    gravitySystem.Message.Time--;
                    spriteBatch.DrawString(fontSmall, gravitySystem.Message.Text, new Vector2(20, GraphicsDevice.Viewport.Height - 230), Color.LightSalmon);
                }


                /*                  
                                if (!gravitySystem.IsCalculating && gravitySystem.GravityObjects.Count>0)
                                {
                                    gravitySystem.InitCalculation();
                                    gravitySystem.QuadTree.DetermineBoundingBox(gravitySystem.GravityObjects);
                                    gravitySystem.QuadTree.Create(gravitySystem.Calculation, gravitySystem.GravityObjects, gravitySystem.FrameNumberPlay);

                                    if (gravitySystem.ObjectIndex != -1 && parentForm.gradientPanelObjectProperties.Visible)
                                    {
                                        gravitySystem.QuadTree.DrawUsedInternalNodes(spriteBatch, textureTrace, gravitySystem.CurrentObject(), gravitySystem.Scale, gravitySystem.OffsetX, gravitySystem.OffsetY, fontSmall);
                                    }
                                    else
                                    {
                                        gravitySystem.QuadTree.DrawQuadrants(spriteBatch, textureTrace, gravitySystem.Scale, gravitySystem.OffsetX, gravitySystem.OffsetY, fontSmall);
                                    }
                                }
                */

                // Arrow 
                if (gravitySystem.ObjectIndex != -1 && parentForm.gradientPanelObjectProperties.Visible)
                {
                    try
                    {
                        int real_x = gravitySystem.RealtoScreenCoordinateX(gravitySystem.CurrentObject().X);
                        int real_y = gravitySystem.RealtoScreenCoordinateY(gravitySystem.CurrentObject().Y);
                        if (real_x > -GraphicsDevice.Viewport.Width && real_x < 2 * GraphicsDevice.Viewport.Width
                            && real_y > -GraphicsDevice.Viewport.Height && real_y < 2 * GraphicsDevice.Viewport.Height)
                        {
                            rect = new Rectangle(real_x - gravitySystem.CurrentObject().ScaledTextureWidth / 2 - 64, real_y - 14, textureArrow.Width, textureArrow.Height);
                            spriteBatch.Draw(textureArrow, rect, Color.White);
                        }
                    }
                    catch (OverflowException)
                    {
                    }
                }

                spriteBatch.End();

            } catch (System.NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                if (e.Message.Equals("Begin cannot be called again until End had been succesfully called."))
                {
                    spriteBatch.End();
                }
            }
        }

        public void Rewind()
        {
            if (timeUnitsPerStep < 31558151)
            {
                simulationTime = simulationTime.AddSeconds(-timeUnitsPerStep * GravitySystem.FrameNumberPlay);
            }
            else
            {
                simulationTimeLarge -= (timeUnitsPerStep * GravitySystem.FrameNumberPlay / 31558150);
            }
            GravitySystem.FrameNumberPlay = 0;
            foreach (GravityObject o in gravitySystem.GravityObjects) 
            {
                // remove all traces
                o.GetTraces().Clear();
            }
        }

        public void UpdateFrame()
        {
            if (simulationRunning || SimulationStepping)
            {
                SimulationStepping = false;
                if (gravitySystem.CalculationsPerStepSetting != -2)
                {
                    gravitySystem.CalculateStep(timeUnitsPerStep);
                } else
                {
                    if (gravitySystem.PlayOneFrame() || (gravitySystem.CalculationsPerStepPrecalculated==1 && gravitySystem.FrameNumberCalc<=gravitySystem.FrameNumberPlay))
                    {
                        // back to beginning of replay
                        Rewind();
                    }
                }

                if (timeUnitsPerStep<31558151) {
                    try
                    {
                        if (reverse)
                        {
                            simulationTime = simulationTime.AddSeconds(-timeUnitsPerStep);
                        }
                        else
                        {
                            simulationTime = simulationTime.AddSeconds(timeUnitsPerStep);
                        }
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        simulationTime = DateTime.Now;
                    }
                }
                else
                {
                    if (reverse)
                    {
                        simulationTimeLarge -= (timeUnitsPerStep / 31558150);
                    }
                    else
                    {
                        simulationTimeLarge += (timeUnitsPerStep / 31558150);
                    }
                }

            }
            if (recordingVideo)
            {
                screenRecorder.RecordOneFrame();
                Thread.Sleep(25);        // Wait a bit to make sure video has been streamed
            }

            HandleInput();
            //Invalidate();
        }

        public void UpdateScreen()
        {
            Invalidate();
        }
        
        /// <summary>
        /// Handles input for quitting the game and cycling
        /// through the different particle effects.
        /// </summary>
        void HandleInput()
        {
            lastKeyboardState = currentKeyboardState;
            lastGamePadState = currentGamePadState;
            lastMousePosition = MousePosition;
            lastScrollWheelValue = scrollWheelValue;

            currentKeyboardState = Keyboard.GetState();
            currentGamePadState = GamePad.GetState(PlayerIndex.One);
        }

        public void StartRecording(string fileName)
        {
            var usedCodec = KnownFourCCs.Codecs.Uncompressed;
            foreach (var codec in Mpeg4VideoEncoderVcm.GetAvailableCodecs())
            {
                if(codec.Name.Equals(parentForm.DisplayXNA.VideoCaptureCompression))
                {
                    usedCodec = codec.Codec;
                }
            }

            screenRecorder = new ScreenRecorder(parentForm, fileName, usedCodec, VideoCaptureFPS);
            recordingVideo = true;
        }

        public void StopRecording()
        {
            recordingVideo = false;
            screenRecorder.Dispose();
        }
    }
}
