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
        const float SCALE_POSITION_X = 240;
        const float SCALE_WIDTH = 1000;
        const float SCALE_POSITION_Y = 40;
        const int ONE_YEAR_IN_SECONDS = 60 * 60 * 24 * 365;

        int backgroundIndex = 0;
        Boolean showNames = true;
        Boolean showScale = true;
        Boolean showForce = false;
        Boolean showSpeed = false;
        Boolean showTrailsAll = true;
        Boolean showVectorsAll = false;
        Texture2D textureBackground;
        Texture2D textureCustomShape;
        Texture2D textureGasGiant;
        Texture2D textureGreyDot;
        Texture2D textureRedDot;
        Texture2D textureVector;
        Texture2D textureArrow;
        Texture2D textureTrace;
        List<Texture2D> objectTextures;
        Texture2D textureSmallCircle;
        SpriteFont fontNormal;
        SpriteFont fontSmall;
        SpriteFont fontLindsey;
        Texture2D textureLine;     //base for the line texture
        Rectangle rectVector;
        bool simulationStepping = false;
        bool recordingVideo = false;
        long simulationTime;                // time in seconds, since 1 january 0001
        bool reverse = false;
        BlendState blendState = BlendState.AlphaBlend;
        ScreenRecorder screenRecorder;
        private string videoCaptureCompression;
        int videoCaptureFPS = 60;
        CustomShape customShape = new CustomShape();
        Random rnd = new Random();
        bool showGrid = false;
        bool useGalaxyTiming;       // Indicates whether galaxy time should be displayed instead of solarsystem time
        int colorScheme;
        bool showClickMessage;

        ContentManager contentManager;
        long secondsPerStepSolarSystem = 1;

        Double scaleBeamLength;
        long scaleFactor;
        int scaleNumber;
        string scaleTextMax;
        int arrowColorStrength;
        bool arrowStrengthUp;

        int scrollWheelValue, lastScrollWheelValue;

        // Input state.
        KeyboardState currentKeyboardState;
        GamePadState currentGamePadState;

        KeyboardState lastKeyboardState;
        GamePadState lastGamePadState;
        System.Drawing.Point lastMousePosition;
        FormMain parentForm;

        SpriteBatch spriteBatch;
        GravitySystem gravitySystem;
        PresetObjects presetObjects;

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

        public long SecondsPerStepSolarSystem
        {
            get
            {
                return secondsPerStepSolarSystem;
            }

            set
            {
                secondsPerStepSolarSystem = value;
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

        public bool ShowForce
        {
            get
            {
                return showForce;
            }

            set
            {
                showForce = value;
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

        public Texture2D TextureBackground { get => textureBackground; set => textureBackground = value; }
        public Texture2D TextureCustomShape { get => textureCustomShape; set => textureCustomShape = value; }
        internal PresetObjects PresetObjects { get => presetObjects; set => presetObjects = value; }
        internal CustomShape CustomShape { get => customShape; set => customShape = value; }
        public FormMain ParentForm { get => parentForm; set => parentForm = value; }
        public bool ShowGrid { get => showGrid; set => showGrid = value; }
        public Texture2D TextureGasGiant { get => textureGasGiant; set => textureGasGiant = value; }
        public Texture2D TextureGreyDot { get => textureGreyDot; set => textureGreyDot = value; }
        public Texture2D TextureRedDot { get => textureRedDot; set => textureRedDot = value; }
        public long SimulationTime { get => simulationTime; set => simulationTime = value; }
        public bool UseGalaxyTiming { get => useGalaxyTiming; set => useGalaxyTiming = value; }
        public bool ShowSpeed { get => showSpeed; set => showSpeed = value; }
        public int ColorScheme { get => colorScheme; set => colorScheme = value; }
        public List<Texture2D> ObjectTextures { get => objectTextures; set => objectTextures = value; }
        public Texture2D TextureVector { get => TextureVector1; set => TextureVector1 = value; }
        public Texture2D TextureVector1 { get => textureVector; set => textureVector = value; }
        public Texture2D TextureArrow { get => textureArrow; set => textureArrow = value; }
        public bool ShowClickMessage { get => showClickMessage; set => showClickMessage = value; }

        public void initCustomShape(int dotSize, Color myColor)
        {
            myColor.A = (byte)CustomShape.Alpha;
            if (dotSize < 3 || CustomShape.Type == 0)
            {
                TextureCustomShape = new Texture2D(GraphicsDevice, dotSize, dotSize);
                if (CustomShape.RandomColor)
                {
                    int color = rnd.Next(0, 6);
                    myColor.R = (color < 2 || color == 4) ? (byte)0 : (byte)255;
                    myColor.G = (color > 0 && color < 4) ? (byte)0 : (byte)255;
                    myColor.B = (color > 2) ? (byte)0 : (byte)255;
                }
                Color[] az = Enumerable.Range(0, dotSize * dotSize).Select(i => myColor).ToArray();
                TextureCustomShape.SetData(az);
            }
            else if (CustomShape.Type == 1)
            {
                TextureCustomShape = contentManager.Load<Texture2D>("smalldot" + dotSize);
                TextureCustomShape = createTextureFromResource(TextureCustomShape, myColor);
            }
            else
            {
                TextureCustomShape = contentManager.Load<Texture2D>("cross" + dotSize);
                TextureCustomShape = createTextureFromResource(TextureCustomShape, myColor);
            }
            TextureCustomShape.Name = "<Custom Shape>";
        }

        private void setColor(Texture2D texture, Color myColor)
        {
            int width = texture.Width;
            int height = texture.Height;
            Color[] data = new Color[width * height];
            texture.GetData<Color>(data, 0, data.Length);
            for (int k = 0; k < width * height; k++)
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
                    if (CustomShape.RandomColor)
                    {
                        newData[k] = new Color();
                        newData[k].A = (byte)CustomShape.Alpha;
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

        public void updateCustomShapes(int startPosition = 0)
        {
            for (int k = startPosition; k < gravitySystem.GravityObjects.Count; k++)
            {
                GravityObject o = gravitySystem.GravityObjects[k];
                if (o.NumObjects == 0 && o.Texture != null /* solar system object */ && o.Texture.Name.Equals("<Custom Shape>"))
                {
                    int dotSize = CustomShape.PixelSize;
                    if (CustomShape.RandomSize)
                    {
                        dotSize = rnd.Next(3, 11);
                    }
                    initCustomShape(dotSize, o.Color);

                    o.Texture = TextureCustomShape;
                    o.ScaledTextureHeight = TextureCustomShape.Height;
                    o.ScaledTextureWidth = TextureCustomShape.Width;
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
        public string FindUniqueObjectName(string name)
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

        private void LoadTexture(string name, string fileName)
        {
            Texture2D texture = contentManager.Load<Texture2D>(fileName);
            texture.Name = name;
            objectTextures.Add(texture);
        }

        public Object[] GetAllTextureNames()
        {
            List<Object> objects = new List<Object>();
            foreach (Texture2D texture in objectTextures) {
                objects.Add(texture.Name);
            }
            return objects.ToArray();
        }

        protected override void Initialize()
        {
            gravitySystem = new GravitySystem(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            PresetObjects = new PresetObjects(this);

            SimulationTime = DateTime.Now.Ticks / 10000000;

            ParentForm = (this.Parent as FormMain);
            //                        contentManager = new ContentManager(Services);
            //                        contentManager.RootDirectory = "Content";
            contentManager = new ResourceContentManager(Services, Resources.ResourceManager);
            // LET OP! Content dir wordt niet meer gebruikt. Als je resources wilt toevoegen moet je dit in de resourcemanager doen.
            // Je moet daar dan de .XNB files toevoegen
            // Deze kun je genereren door de uitgecommentarieerde contentmanager terug te zetten, of de XNAContentCompiler of de monogame pipeline te gebruiken.

            // Load the background content. 
            objectTextures = new List<Texture2D>();
            LoadTexture("Mercury", "mercury");
            LoadTexture("Sun", "sun");
            LoadTexture("Venus", "venus");
            LoadTexture("Earth", "earth");
            LoadTexture("Moon", "moon");
            LoadTexture("Mars", "mars");
            LoadTexture("Jupiter", "jupiter");
            LoadTexture("Saturn", "saturn");
            LoadTexture("Neptune", "neptune");
            LoadTexture("Uranus", "uranus");
            LoadTexture("Pluto", "pluto");
            LoadTexture("Planet", "planet");
            LoadTexture("Gas Giant", "gasgiant");
            LoadTexture("Asteroid", "asteroid");
            LoadTexture("Red Dwarf", "starreddwarf_m");
            LoadTexture("Brown Dwarf", "starbrowndwarf");
            LoadTexture("Yellow Dwarf", "staryellowdwarf_f");
            LoadTexture("White Dwarf", "starwhitedwarf_a");
            LoadTexture("Blue Giant", "starbluegiant_ob");
            LoadTexture("Red giant", "starredgiant");
            LoadTexture("Red Supergiant", "starredsupergiant_k");
            LoadTexture("Red Ball", "ball");
            LoadTexture("Metal Ball", "metalball");
            LoadTexture("Golden Ball", "goldenball");
            LoadTexture("Point", "largedot");
            // TextureCustomShape is created seperately because it is frequently used.
            TextureCustomShape = new Texture2D(GraphicsDevice, CustomShape.PixelSize, CustomShape.PixelSize);
            TextureCustomShape.Name = "<Custom Shape>";
            objectTextures.Add(TextureCustomShape);

            TextureArrow = contentManager.Load<Texture2D>("arrow");
            TextureArrow.Name = "Arrow";
            TextureVector = contentManager.Load<Texture2D>("vector");
            TextureVector.Name = "Vector";

            textureSmallCircle = contentManager.Load<Texture2D>("smalldot9");
            rectVector = new Rectangle(0, 0, TextureVector.Width, TextureVector.Height);
            fontLindsey = contentManager.Load<SpriteFont>("font_lindsey");
            fontNormal = contentManager.Load<SpriteFont>("font_segoeuimono");
            fontSmall = contentManager.Load<SpriteFont>("font_small");

            textureTrace = contentManager.Load<Texture2D>("cross3");   // new Texture2D(GraphicsDevice, 2, 2);
                                                                       //            Color[] az = Enumerable.Range(0, 4).Select(i => new Color(255, 255, 255, 100)).ToArray();
                                                                       //            TextureTrace.SetData(az);

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
                    TextureBackground = contentManager.Load<Texture2D>("space");
                    break;
                case 2:
                    TextureBackground = contentManager.Load<Texture2D>("space2");
                    break;
                case 3:
                    TextureBackground = contentManager.Load<Texture2D>("space3");
                    break;
                case 4:
                    TextureBackground = contentManager.Load<Texture2D>("space4");
                    break;
                case 5:
                    TextureBackground = contentManager.Load<Texture2D>("space5");
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
                if (isTrue == false)
                {
                    // remove all traces
                    o.GetTraces().Clear();
                }
            }
        }

        public Texture2D GetTextureByName(string text)
        {
            return ObjectTextures.Find(x => x.Name.Equals(text));
        }

        public void AddGravityObject(double X, double Y, bool circleHost = false, bool circleHostCCW = false)
        {
            Texture2D texture = GetTextureByName(ParentForm.comboBoxTexture.Text);

            double xSpeed = Convert.ToDouble(ParentForm.textBoxXSpeed.Text);
            double ySpeed = Convert.ToDouble(ParentForm.textBoxYSpeed.Text);

            GravityObject newObject = gravitySystem.AddObject(ParentForm.textBoxName.Text,
                Convert.ToDouble(ParentForm.textBoxMass.Text),
                X, Y, xSpeed, ySpeed,
                texture, ParentForm.checkBoxTrace.Checked, ParentForm.checkBoxVector.Checked);
//            gravitySystem.ScaleObject(newObject);
            if ((circleHost || circleHostCCW) && gravitySystem.GravityObjects.Count > 1)
            {
                Vector speed = gravitySystem.CalculateSpeedByHost(newObject);
                newObject.XSpeed = speed.X;
                newObject.YSpeed = speed.Y;
                if (circleHostCCW)
                {
                    newObject.XSpeed = -speed.X;
                    newObject.YSpeed = -speed.Y;
                }
            }

            // perform 1 calculation to show right vectors
            gravitySystem.CalculateStep(1, false);
        }


        void DrawLine(SpriteBatch sb, Vector2 start, Vector2 end, int width)
        {
            DrawLine(sb, start, end, width, Color.White);
        }

        void DrawLine(SpriteBatch sb, Vector2 start, Vector2 end, int width, Color color)
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
                color, //colour of line
                angle,     //angle of line (calulated above)
                new Vector2(0, 0), // point in line about which to rotate
                SpriteEffects.None,
                0);

        }

        public void AdjustScale()
        {
            // at scale 1, one pixel = 100 km
            // -> End of scale text = SCALE_WIDTH * 100 km = 100,000 km
            // we want maximum SCALE_WIDTH pixels and minimum 100 pixels
            scaleBeamLength = (SCALE_WIDTH / gravitySystem.Scale);
            scaleFactor = 1;
            scaleNumber = 0;
            while (scaleBeamLength < 200)
            {
                scaleNumber++;
                scaleFactor *= 5;
                scaleBeamLength = (SCALE_WIDTH * scaleFactor / (gravitySystem.Scale));
                if (scaleBeamLength < 500)
                {
                    scaleNumber++;
                    scaleFactor *= 2;
                    scaleBeamLength = (SCALE_WIDTH * scaleFactor / (gravitySystem.Scale));
                }
            }

            scaleTextMax = scaleFactor + "00,000 km";
            if (scaleFactor >= 10)
            {
                scaleTextMax = (scaleFactor / 10).ToString() + " mln. km";
            }
            if (scaleFactor >= 10000)
            {
                scaleTextMax = (scaleFactor / 10000).ToString() + " bln. km";
            }
            if (scaleFactor >= 10000000)
            {
                scaleTextMax = (scaleFactor / 10000000).ToString() + " tln. km";
            }
            if (scaleFactor >= 10000000000)
            {
                scaleTextMax = (scaleFactor / 10000000000).ToString() + " qdn. km";
            }

            if(GravitySystem.CenterIndex > -1)
                GravitySystem.ScrollToCenterImmediately();
        }

        private double CalcPercentage(GravityObject o)
        {
            double percentage = 0;
            if (showSpeed && gravitySystem.SpeedRange > 0)
            {
                percentage = (o.Speed - gravitySystem.MinSpeed) / gravitySystem.SpeedRange;
            }
            else if (showForce && gravitySystem.AccelerationRange > 0)
            {
                percentage = (o.Acceleration - gravitySystem.MinAcceleration) / gravitySystem.AccelerationRange;
            }
            if (percentage > 1)  // range is not 100% accurate for speed reasons
            {
                percentage = 1;
            }

            return percentage;
        }

        private Color DetermineColor(double percentage)
        {
            int color1, color2, color3;
            if (ColorScheme == 0)        // range is not 100% accurate for speed reasons
            {
                // percent 0 : white 255,255,255
                if (percentage < 20)
                {
                    color1 = color2 = color3 = (int)(255 - (percentage * 6.4));
                }
                // percent 20 : grey 128,128,128
                else if (percentage < 50)
                {
                    color1 = (int)(128 - ((percentage - 20) * 4.26));
                    color2 = (int)(127 + ((percentage - 20) * 4.26));
                    color3 = (int)(128 - ((percentage - 20) * 4.26));
                }
                // percent 50 : green 0,255,0
                else if (percentage < 80)
                {
                    color1 = (int)((percentage - 50) * 8.52);
                    color2 = 255;
                    color3 = 0;
                }
                // percent 80 : yellow 255,255,0
                else
                {
                    color1 = 255;
                    color2 = (int)(255 - ((percentage - 80) * 12.75));
                    color3 = 0;
                }
                // percent 100 : red 255,0,0
            }
            else if (ColorScheme == 1)
            {
                color1 = (Convert.ToInt32(percentage * 2)) % 255;
                color2 = (255 - Convert.ToInt32(percentage * 4)) % 255;
                color3 = Convert.ToInt32(percentage * 1) % 255;
            }
            else if (ColorScheme == 2)
            {
                color1 = (Convert.ToInt32(percentage * 2)) % 255;
                color2 = (127 + Convert.ToInt32(percentage * 3)) % 255;
                color3 = Math.Abs((255 - Convert.ToInt32(percentage * 3)) % 255);
            }
            else
            {
                color1 = (Convert.ToInt32(percentage * 2)) % 255;
                color2 = Convert.ToInt32(percentage * 1) % 255;
                color3 = (255 - Convert.ToInt32(percentage * 2)) % 255; 
            }
            return new Color(color1, color2, color3);
        }


        override protected void Draw()
        {
            GraphicsDevice.Clear(Color.Black);

            try
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

                // Draw background
                Rectangle rect;
                if (BackgroundIndex > 0)
                {
                    rect = new Rectangle(0, 0, Width, Height);
                    spriteBatch.Draw(TextureBackground, rect, Color.White);
                }

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
                                    double screen_x = gravitySystem.RealtoScreenCoordinateX(trace.X + o.SolarSystemPositionX());
                                    double screen_y = gravitySystem.RealtoScreenCoordinateY(trace.Y + o.SolarSystemPositionY());
                                    if (screen_x > -GraphicsDevice.Viewport.Width && screen_x < 2 * GraphicsDevice.Viewport.Width
                                        && screen_y > -GraphicsDevice.Viewport.Height && screen_y < 2 * GraphicsDevice.Viewport.Height)
                                    {
                                        spriteBatch.Draw(textureTrace, new Rectangle(Convert.ToInt32(screen_x), Convert.ToInt32(screen_y), textureTrace.Width, textureTrace.Height), trace.Color);
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

                for (int k = gravitySystem.GravityObjects.Count - 1; k >= 0; k--)     // go through the objects in reverse order, so that the sun will be in front of planets (when zooming out)
                {
                    GravityObject o = gravitySystem.GravityObjects[k];

                    if (o.NumObjects > 0)
                        continue;               // skip solar system objects

                    double screen_x = gravitySystem.RealtoScreenCoordinateX(o.AbsolutePositionX());
                    double screen_y = gravitySystem.RealtoScreenCoordinateY(o.AbsolutePositionY());

                    // Vector
                    if (o.Vector)
                    {
                        if (screen_x > -GraphicsDevice.Viewport.Width && screen_x < 2 * GraphicsDevice.Viewport.Width
                            && screen_y > -GraphicsDevice.Viewport.Height && screen_y < 2 * GraphicsDevice.Viewport.Height)
                        {
                            spriteBatch.Draw(TextureVector, new Rectangle(Convert.ToInt32(screen_x), Convert.ToInt32(screen_y), TextureVector.Width, TextureVector.Height), null, Color.White, (float)o.AccelerationAngle, new Vector2(0, TextureVector.Height / 2), SpriteEffects.None, 0f);
                        }
                    }

                    spriteBatch.End();
                    spriteBatch.Begin(SpriteSortMode.Deferred, blendState);

                    // Object
                    try
                    {
                        if (screen_x > -GraphicsDevice.Viewport.Width && screen_x < 2 * GraphicsDevice.Viewport.Width
                            && screen_y > -GraphicsDevice.Viewport.Height && screen_y < 2 * GraphicsDevice.Viewport.Height)
                        {
                            /* For displaying color scheme gradient..
                            for(int x=0; x<=100; x++)
                            {
                                rect = new Rectangle(500+x, 500, 1, 30);
                                Color color = DetermineColor(x);
                                Texture2D texture = new Texture2D(GraphicsDevice, 1, 1);
                                Color[] data = { new Color(255, 255, 255, 255) }; 
                                texture.SetData(data);
                                spriteBatch.Draw(texture, rect, color);
                            }
                            */
                            if (showForce || showSpeed)
                            {
                                rect = new Rectangle(Convert.ToInt32(screen_x - textureSmallCircle.Width / 2), Convert.ToInt32(screen_y - textureSmallCircle.Height / 2), textureSmallCircle.Width, textureSmallCircle.Height);
                                Color color = Color.Red; // DetermineColor(CalcPercentage(o));
                                spriteBatch.Draw(textureSmallCircle, rect, color);
                            }
                            else
                            {
                                rect = new Rectangle(Convert.ToInt32(screen_x - o.ScaledTextureWidth / 2), Convert.ToInt32(screen_y - o.ScaledTextureHeight / 2), o.ScaledTextureWidth, o.ScaledTextureHeight);
                                if (o.Texture.Name.Equals("<Custom Shape>"))
                                {
                                    spriteBatch.Draw(o.Texture, rect, new Color(255, 255, 255, 255));
                                }
                                else
                                {
                                    // future                                   if (o.RotationMode.Equals(RotationMode_.None))
                                    // future                                    {
                                    spriteBatch.Draw(o.Texture, rect, Color.White);
                                    // future                                    }
                                    // future                                   else
                                    // future                                   {
                                    // future                                       spriteBatch.Draw(o.Texture, new Rectangle(Convert.ToInt32(screen_x), Convert.ToInt32(screen_y), o.Texture.Width, o.Texture.Height), null, Color.White, (float)o.Angle, new Vector2(o.Texture.Width / 2, o.Texture.Height / 2), SpriteEffects.None, 0f);
                                    // future                                   }
                                }
                            }
                        }
                    }
                    catch (OverflowException)
                    {
                        gravitySystem.GravityObjects.Remove(o);
                    }

                    spriteBatch.End();
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

                    // Object name
                    if (showNames)
                    {
                        if (gravitySystem.Scale < 30)
                            spriteBatch.DrawString(fontNormal, o.Name, new Vector2((float)(screen_x + o.ScaledTextureWidth / 2), (float)(screen_y + o.ScaledTextureHeight / 2)), Color.LightGray);
                        else
                            spriteBatch.DrawString(fontSmall, o.Name, new Vector2((float)(screen_x + o.ScaledTextureWidth / 2), (float)(screen_y + o.ScaledTextureHeight / 2)), Color.LightGray);
                    }

                }

                // Grid display
                if (showGrid)
                {
                    // scalefactor 1-50000000000000  -> Log(scalefactor) 0-32.5
                    double step = SCALE_WIDTH * scaleFactor / gravitySystem.Scale / 8.0;
                    double x = -(gravitySystem.OffsetX % step);
                    double y = -(gravitySystem.OffsetY % step);
                    int value = scaleNumber % 2 * 255;
                    Color color = new Color(value / 2, (255 - value) / 2, 100);

                    while (x < gravitySystem.ViewportWidth)
                    {
                        DrawLine(spriteBatch, new Vector2((float)x, 0), new Vector2((float)x, gravitySystem.ViewportHeight), 1, color);
                        x += step;
                    }
                    while (y < gravitySystem.ViewportWidth)
                    {
                        DrawLine(spriteBatch, new Vector2(0, (float)y), new Vector2(gravitySystem.ViewportWidth, (float)y), 1, color);
                        y += step;
                    }

                    x = -(gravitySystem.OffsetX) % (20 * step);
                    y = -(gravitySystem.OffsetY) % (20 * step);
                    value = (scaleNumber+1) % 2 * 255;
                    color = new Color(value / 2, (255 - value) / 2, 100);
                    while (x < gravitySystem.ViewportWidth)
                    {
                        DrawLine(spriteBatch, new Vector2((float)x, 0), new Vector2((float)x, gravitySystem.ViewportHeight), 1, color);
                        DrawLine(spriteBatch, new Vector2((float)x + 1, 0), new Vector2((float)x + 1, gravitySystem.ViewportHeight), 1, color);
                        DrawLine(spriteBatch, new Vector2((float)x + 2, 0), new Vector2((float)x + 2, gravitySystem.ViewportHeight), 1, color);
                        x += step * 20.0;
                    }
                    while (y < gravitySystem.ViewportWidth)
                    {
                        DrawLine(spriteBatch, new Vector2(0, (float)y), new Vector2(gravitySystem.ViewportWidth, (float)y), 1, color);
                        DrawLine(spriteBatch, new Vector2(0, (float)y + 1), new Vector2(gravitySystem.ViewportWidth, (float)y + 1), 1, color);
                        DrawLine(spriteBatch, new Vector2(0, (float)y + 2), new Vector2(gravitySystem.ViewportWidth, (float)y + 2), 1, color);
                        y += step * 20.0;
                    }
                }

                // Scale display
                if (showScale)
                {
                    DrawLine(spriteBatch, new Vector2(SCALE_POSITION_X, SCALE_POSITION_Y), new Vector2(SCALE_POSITION_X + SCALE_WIDTH * scaleFactor / gravitySystem.Scale, SCALE_POSITION_Y), 3);
                    DrawLine(spriteBatch, new Vector2(SCALE_POSITION_X, SCALE_POSITION_Y), new Vector2(SCALE_POSITION_X, SCALE_POSITION_Y - 10), 2);
                    DrawLine(spriteBatch, new Vector2(SCALE_POSITION_X - 2 + SCALE_WIDTH * scaleFactor / gravitySystem.Scale, SCALE_POSITION_Y), new Vector2(SCALE_POSITION_X - 2 + SCALE_WIDTH * scaleFactor / gravitySystem.Scale, SCALE_POSITION_Y - 10), 2);
                    spriteBatch.DrawString(fontLindsey, "0", new Vector2(SCALE_POSITION_X, SCALE_POSITION_Y), Color.White);
                    spriteBatch.DrawString(fontLindsey, scaleTextMax, new Vector2(SCALE_POSITION_X + SCALE_WIDTH * scaleFactor / gravitySystem.Scale, SCALE_POSITION_Y), Color.White);
                }

                if (gravitySystem.Message.Time > 0)
                {
                    gravitySystem.Message.Time--;
                    spriteBatch.DrawString(fontSmall, gravitySystem.Message.Text, new Vector2(20, GraphicsDevice.Viewport.Height - 330), Color.LightSalmon);
                }

                spriteBatch.DrawString(fontSmall, "framerate: " + parentForm.FrameRate.ToString(), new Vector2(20, GraphicsDevice.Viewport.Height - 3000), Color.LightGray);

                // Calculations per step
                if (gravitySystem.IsCalculating)
                {
                    string text = "calculating frame: " + gravitySystem.FrameNumberCalc + "/" + gravitySystem.NumPrecalculatedFrames();
                    spriteBatch.DrawString(fontSmall, text, new Vector2(20, GraphicsDevice.Viewport.Height - 270), Color.LightGray);
                }
                if (gravitySystem.FrameNumberCalc > 1)       // we have at least one calculated frame
                {
                    string text = "playing frame: " + gravitySystem.FrameNumberPlay + "/" + gravitySystem.NumPrecalculatedFrames();
                    spriteBatch.DrawString(fontSmall, text, new Vector2(20, GraphicsDevice.Viewport.Height - 240), Color.LightGray);
                }
                else
                {
                    spriteBatch.DrawString(fontSmall, "calculations/step: " + gravitySystem.CalculationsPerStepActual.ToString(), new Vector2(20, GraphicsDevice.Viewport.Height - 240), Color.LightGray);
                }

                // Simulation time
                long secondsPerStep = secondsPerStepSolarSystem;
                if (UseGalaxyTiming)
                {
                    secondsPerStep *= GravitySystem.TIME_GALAXY_INCREASE_FACTOR;
                }

                if (secondsPerStep <= ONE_YEAR_IN_SECONDS)
                {
                    spriteBatch.DrawString(fontNormal, new DateTime(SimulationTime * 10000000).ToString("MM/dd/yyyy HH:mm"), new Vector2(20, GraphicsDevice.Viewport.Height - 210), Color.White);
                }
                else
                {
                    spriteBatch.DrawString(fontNormal, "Year: " + string.Format("{0:n0}", SimulationTime / ONE_YEAR_IN_SECONDS), new Vector2(20, GraphicsDevice.Viewport.Height - 210), Color.White);
                }

                spriteBatch.DrawString(fontSmall, "XOffset: " + GravitySystem.OffsetX + ", YOffset: " + GravitySystem.OffsetY, new Vector2(GraphicsDevice.Viewport.Width - 400, GraphicsDevice.Viewport.Height - 130), Color.White);
                spriteBatch.DrawString(fontSmall, "Scale: " + GravitySystem.Scale, new Vector2(GraphicsDevice.Viewport.Width - 400, GraphicsDevice.Viewport.Height - 100), Color.White);
                if (ShowClickMessage)
                {
                    spriteBatch.DrawString(fontLindsey, "Click anywhere in the Screen ", new Vector2((GraphicsDevice.Viewport.Width / 2) - 300, 180), new Color(arrowColorStrength, 0, 0));
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
                if (gravitySystem.ObjectIndex != -1 && ParentForm.gradientPanelObjectProperties.Visible)
                {
                    try
                    {
                        int screen_x = gravitySystem.RealtoScreenCoordinateX(gravitySystem.CurrentObject().AbsolutePositionX());
                        int screen_y = gravitySystem.RealtoScreenCoordinateY(gravitySystem.CurrentObject().AbsolutePositionY());
                        if (screen_x > -GraphicsDevice.Viewport.Width && screen_x < 2 * GraphicsDevice.Viewport.Width
                            && screen_y > -GraphicsDevice.Viewport.Height && screen_y < 2 * GraphicsDevice.Viewport.Height)
                        {
                            if (arrowStrengthUp)
                            {
                                arrowColorStrength += 4;
                                if (arrowColorStrength >= 255)
                                {
                                    arrowStrengthUp = false;
                                }
                            }
                            else
                            {
                                arrowColorStrength -= 4;
                                if (arrowColorStrength < 100)
                                {
                                    arrowStrengthUp = true;
                                }
                            }
                            rect = new Rectangle(screen_x - gravitySystem.CurrentObject().ScaledTextureWidth / 2 - 64 - 6 + (arrowColorStrength / 40), screen_y - 14, TextureArrow.Width, TextureArrow.Height);
                            spriteBatch.Draw(TextureArrow, rect, new Color(arrowColorStrength, arrowColorStrength, arrowColorStrength));
                        }
                    }
                    catch (OverflowException)
                    {
                    }
                }

                spriteBatch.End();

            }
            catch (System.NullReferenceException e)
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
            SimulationTime -= (secondsPerStepSolarSystem * GravitySystem.FrameNumberPlay);

            GravitySystem.FrameNumberPlay = 0;
            foreach (GravityObject o in gravitySystem.GravityObjects)
            {
                // remove all traces
                o.GetTraces().Clear();
            }
        }

        public void UpdateFrame()
        {
            if (gravitySystem.SimulationRunning)
            {
                if (gravitySystem.FrameNumberCalc > 1)      // we have at least one calculated frame
                {
                    if (gravitySystem.PlayOneFrame() || gravitySystem.FrameNumberPlay > gravitySystem.FrameNumberCalc)
                    {
                        // back to beginning of replay
                        Rewind();
                    }
                }
                else
                {
                    gravitySystem.CalculateStep(secondsPerStepSolarSystem);
                }

                if (reverse)
                {
                    SimulationTime -= (secondsPerStepSolarSystem);
                }
                else
                {
                    SimulationTime += (secondsPerStepSolarSystem);
                }
            }
            // Adjust to center of object if object is centered
            GravitySystem.CenterOnObject();

            if (SimulationStepping)
            {
                gravitySystem.SimulationRunning = false;
                SimulationStepping = false;
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
                if (codec.Name.Equals(ParentForm.DisplayXNA.VideoCaptureCompression))
                {
                    usedCodec = codec.Codec;
                }
            }

            screenRecorder = new ScreenRecorder(ParentForm, fileName, usedCodec, VideoCaptureFPS);
            recordingVideo = true;
        }

        public void StopRecording()
        {
            recordingVideo = false;
            screenRecorder.Dispose();
        }
    }
}
