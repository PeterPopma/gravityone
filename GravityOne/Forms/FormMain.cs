using GravityOne.Gravity;
using Microsoft.Win32;
using Microsoft.Xna.Framework.Graphics;
using SharpAvi.Codecs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GravityOne.Forms
{
    enum PlacingObject_
    {
        None, Pick, PlanetMoon, SolarSystem, SunPlanetMoon, SunPlanet, SlingShot, MoonMoon, TripleStar, SolarSystemMoons,
        Neighbourhood, Circle, Galaxy, BinaryOnePlanetStable, BinaryTwoPlanets, BinaryOnePlanetHopping, Random, Grid,
        ShapeCircle, ShapeBar, ShapeBiasedBar, ShapeTriangle, ShapeSquare
    }

    public partial class FormMain : Form
    {
        private static System.Windows.Forms.Timer updateScreenTimer;
        private static System.Timers.Timer panTimer;
        private static int IntervalCounter = 0;
        private static int PanDirection = 0;
        private static int currentSpeedbarValue = -1;
        private static PlacingObject_ placingObject;
        private string originalXSpeed;
        private string originalYSpeed;
        private string saveDir = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "Recordings";
        private bool compressRecordings;
        private int frameRate = 50;
        const long SECONDS_PER_DAY = 86400;
        const long SECONDS_PER_YEAR = SECONDS_PER_DAY * 365;
        const long SECONDS_PER_DECADE = SECONDS_PER_YEAR * 10;
        const long SECONDS_PER_MILLENIUM = SECONDS_PER_YEAR * 1000;
        const long SECONDS_PER_100000_YEARS = SECONDS_PER_MILLENIUM * 100;
        const double SCALEPOWER = 0.00361445075499040250883138060853;
        const int OBJECTPROPERTIES_HEIGHT_COLLAPSED = 580;
        const int OBJECTPROPERTIES_HEIGHT = 812;

        public string SaveDir
        {
            get
            {
                return saveDir;
            }

            set
            {
                saveDir = value;
            }
        }

        public bool CompressRecordings
        {
            get
            {
                return compressRecordings;
            }

            set
            {
                compressRecordings = value;
            }
        }

        public int FrameRate { get => frameRate; set => frameRate = value; }
        internal static PlacingObject_ PlacingObject { get => placingObject; set => placingObject = value; }

        public FormMain()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            gradientPanelObjectProperties.Visible = false;
            gradientPanelObjectProperties.Height = OBJECTPROPERTIES_HEIGHT_COLLAPSED;
            SetupTimers();
            DisplayXNA.Width = this.Width;
            DisplayXNA.Height = this.Height;
        }

        public BlendState ConvertToBlendState(string blendState)
        {
            if (blendState.Equals("Transparent"))
            {
                return BlendState.Additive;
            }
            if (blendState.Equals("Opaque"))
            {
                return BlendState.AlphaBlend;
            }
            if (blendState.Equals("BlendState.Additive"))
            {
                return BlendState.Additive;
            }
            if (blendState.Equals("BlendState.AlphaBlend"))
            {
                return BlendState.AlphaBlend;
            }

            return BlendState.Opaque;
        }

        private void LoadSettings()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Peter Popma\\GravityOne");
            if (key != null)
            {
                compressRecordings = Convert.ToBoolean(key.GetValue("CompressRecordings", true));
                displayXNA.GravitySystem.TargetFrameRate = Convert.ToInt32(key.GetValue("FrameRate", 25));
                displayXNA.GravitySystem.PreCalculationTime = Convert.ToInt32(key.GetValue("PrecalcTime", 20));
                displayXNA.GravitySystem.CalculationsPerStepSetting = Convert.ToInt32(key.GetValue("CalculationsPerStepSetting", -1));
                displayXNA.GravitySystem.DetermineCalculationsPerStepActual();      // calculation per step setting changed
                displayXNA.GravitySystem.CalculationsPerStepPrecalculatedGalaxy = Convert.ToInt32(key.GetValue("CalculationsPerStepPrecalculatedGalaxy", 1));
                displayXNA.GravitySystem.CalculationsPerStepPrecalculatedSolar = Convert.ToInt32(key.GetValue("CalculationsPerStepPrecalculatedSolar", 100));

                saveDir = (key.GetValue("SaveDir")==null? "" : key.GetValue("SaveDir").ToString());
                if (saveDir.Length==0)
                {
                    saveDir = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "Recordings";
                    System.IO.Directory.CreateDirectory(saveDir);       // create if not exists
                }
                displayXNA.setBackground(Convert.ToInt32(key.GetValue("Background", 2)));
                displayXNA.ShowForce = Convert.ToBoolean(key.GetValue("ShowForce", false));
                displayXNA.ShowNames = Convert.ToBoolean(key.GetValue("ShowNames", true));
                displayXNA.ShowScale = Convert.ToBoolean(key.GetValue("ShowScale", true));
                displayXNA.ShowGrid = Convert.ToBoolean(key.GetValue("ShowGrid", false));
                displayXNA.Reverse = Convert.ToBoolean(key.GetValue("Reverse", false));
                displayXNA.ShowTrailsAll = Convert.ToBoolean(key.GetValue("AllTrails", true));
                displayXNA.ShowVectorsAll = Convert.ToBoolean(key.GetValue("AllVectors", false));
                // not saved            displayXNA.BlendState = ConvertToBlendState(key.GetValue("TextureMode").ToString());

                displayXNA.CustomShape.Type = Convert.ToInt32(key.GetValue("CustomShapeType", 0));
                displayXNA.CustomShape.Alpha = Convert.ToInt32(key.GetValue("CustomShapeAlpha", 120));
                displayXNA.CustomShape.TextToSize(key.GetValue("CustomShapeSize", "5").ToString());
                displayXNA.CustomShape.TextToColor(key.GetValue("CustomShapeColor", "White").ToString());
                displayXNA.CustomShape.UpdateExisting = Convert.ToBoolean(key.GetValue("CustomShapeUpdateExisting", false));

                displayXNA.GravitySystem.GravitationalConstant = Convert.ToInt64(key.GetValue("GravitationalConstant", 667408000000));
                DisplayXNA.PresetObjects.Galaxy.TotalMass = Convert.ToInt64(key.GetValue("GalaxyMass", 12000));
                DisplayXNA.PresetObjects.Galaxy.BlackHoleMass = Convert.ToInt64(key.GetValue("GalaxyBlackHoleMass", 4100000));
                DisplayXNA.PresetObjects.Galaxy.CrossSection = Convert.ToInt32(key.GetValue("GalaxyCrossSection", 1700));
                DisplayXNA.PresetObjects.Galaxy.HasBlackHole = Convert.ToBoolean(key.GetValue("GalaxyHasBlackHole", true));
                DisplayXNA.PresetObjects.Galaxy.HasSpiral = Convert.ToBoolean(key.GetValue("GalaxySpiral", true));
                DisplayXNA.PresetObjects.Galaxy.HasEllipse = Convert.ToBoolean(key.GetValue("GalaxyEllipse", true));
                DisplayXNA.PresetObjects.Galaxy.NumberOfObjects = Convert.ToInt32(key.GetValue("GalaxyNumberOfObjects", 6000));
                DisplayXNA.PresetObjects.Galaxy.RotateCCW = Convert.ToBoolean(key.GetValue("GalaxyRotateCCW", true));
                DisplayXNA.PresetObjects.Galaxy.RotationPeriod = Convert.ToInt32(key.GetValue("GalaxyRotationPeriod", 360));
                DisplayXNA.PresetObjects.Galaxy.VelocityIncreaseFactor = Convert.ToDouble(key.GetValue("GalaxyVelocityIncreaseFactor", 0.2));
                DisplayXNA.PresetObjects.Galaxy.NumberOfArms = Convert.ToInt32(key.GetValue("GalaxySpiralArms", 2));
                DisplayXNA.PresetObjects.Galaxy.ArmLength = Convert.ToDouble(key.GetValue("GalaxySpiralArmLength", 1.4));
                DisplayXNA.PresetObjects.Galaxy.HasBar = Convert.ToBoolean(key.GetValue("GalaxyHasBar", true));
                DisplayXNA.PresetObjects.Galaxy.EllipseRatio = Convert.ToDouble(key.GetValue("GalaxyEllipseRatio", 0.5));
                DisplayXNA.PresetObjects.Galaxy.EllipseSizePercentage = Convert.ToInt32(key.GetValue("GalaxyEllipseSizePercentage", 50));
                DisplayXNA.PresetObjects.Galaxy.EllipseObjectsPercentage = Convert.ToInt32(key.GetValue("GalaxyEllipseObjectsPercentage", 30));
                DisplayXNA.PresetObjects.Galaxy.EllipseBlurriness = Convert.ToInt32(key.GetValue("GalaxyEllipseBlurriness", 50));
                DisplayXNA.PresetObjects.Galaxy.SpiralBlurriness = Convert.ToInt32(key.GetValue("GalaxySpiralBlurriness", 50));
                DisplayXNA.PresetObjects.Galaxy.BarPercentage = Convert.ToInt32(key.GetValue("GalaxyBarPercentage", 20));
                DisplayXNA.PresetObjects.Galaxy.MassVariation = Convert.ToInt32(key.GetValue("GalaxyMassVariation", 20));
                DisplayXNA.PresetObjects.Galaxy.AddSolarSystem = Convert.ToBoolean(key.GetValue("GalaxyAddSolarSystem", false));
                DisplayXNA.PresetObjects.Galaxy.CalculateStableSpeed = Convert.ToBoolean(key.GetValue("GalaxyCalculateStableSpeed", false));
                DisplayXNA.PresetObjects.Galaxy.XSpeed = Convert.ToDouble(key.GetValue("GalaxyXSpeed", 0));
                DisplayXNA.PresetObjects.Galaxy.YSpeed = Convert.ToDouble(key.GetValue("GalaxyYSpeed", 0));
                displayXNA.GravitySystem.QuadTree.Treshold = Convert.ToDouble(key.GetValue("BarnesHutTreshold", 0.5));
                displayXNA.GravitySystem.UseBarnesHut = Convert.ToBoolean(key.GetValue("UseBarnesHut", true));
                displayXNA.GravitySystem.MinimumTextureSize = Convert.ToInt32(key.GetValue("MinimumTextureSize", 11));
                displayXNA.GravitySystem.AccelerationLimit = Convert.ToDouble(key.GetValue("AccelerationLimit", 0.0000000001));
                displayXNA.VideoCaptureCompression = key.GetValue("VideoCapturecompression", "none").ToString();
                displayXNA.VideoCaptureFPS = Convert.ToInt32(key.GetValue("VideoCaptureFPS", 60));

                displayXNA.initCustomShape(displayXNA.CustomShape.PixelSize, Microsoft.Xna.Framework.Color.White);    // needs to be before any calls to getTextureByName()

                displayXNA.PresetObjects.Grid.Mass = Convert.ToDouble(key.GetValue("GridMass", 20000));
                displayXNA.PresetObjects.Grid.Rotations = Convert.ToDouble(key.GetValue("GridRotations", 0));
                displayXNA.PresetObjects.Grid.Spacing = Convert.ToDouble(key.GetValue("GridSpacing", 50));
                displayXNA.PresetObjects.Grid.SpacingUnits = key.GetValue("GridSpacingUnits", "pixels").ToString();
                displayXNA.PresetObjects.Grid.Texture = DisplayXNA.GetTextureByName(key.GetValue("GridTexture", "<Custom Shape>").ToString());
                displayXNA.PresetObjects.Grid.XAmount = Convert.ToDouble(key.GetValue("GridXAmount", 20));
                displayXNA.PresetObjects.Grid.YAmount = Convert.ToDouble(key.GetValue("GridYAmount", 20));
                displayXNA.PresetObjects.Grid.XSpeed = Convert.ToDouble(key.GetValue("GridXSpeed", 0));
                displayXNA.PresetObjects.Grid.YSpeed = Convert.ToDouble(key.GetValue("GridYSpeed", 0));

                displayXNA.PresetObjects.Circle.Mass = Convert.ToDouble(key.GetValue("CircleMass", 20000));
                displayXNA.PresetObjects.Circle.Rotations = Convert.ToDouble(key.GetValue("CircleRotations", 0));
                displayXNA.PresetObjects.Circle.Spacing = Convert.ToDouble(key.GetValue("CircleSpacing", 50));
                displayXNA.PresetObjects.Circle.SpacingUnits = key.GetValue("CircleSpacingUnits", "pixels").ToString();
                displayXNA.PresetObjects.Circle.Texture = DisplayXNA.GetTextureByName(key.GetValue("CircleTexture", "<Custom Shape>").ToString());
                displayXNA.PresetObjects.Circle.NumObjectsRadius = Convert.ToDouble(key.GetValue("CircleNumberOfObjectsRadius", 20));
                displayXNA.PresetObjects.Circle.XSpeed = Convert.ToDouble(key.GetValue("CircleXSpeed", 0));
                displayXNA.PresetObjects.Circle.YSpeed = Convert.ToDouble(key.GetValue("CircleYSpeed", 0));

                displayXNA.PresetObjects.RandomObjects.Mass = Convert.ToInt64(key.GetValue("RandomMass", 5000000));
                displayXNA.PresetObjects.RandomObjects.NumberOfObjects = Convert.ToInt32(key.GetValue("RandomNumberOfObjects", 200));
                displayXNA.PresetObjects.RandomObjects.Texture = DisplayXNA.GetTextureByName(key.GetValue("RandomTexture", "<Custom Shape>").ToString());
                displayXNA.PresetObjects.RandomObjects.Area = Convert.ToUInt64(key.GetValue("RandomArea", 1000));
                displayXNA.PresetObjects.RandomObjects.AreaUnits = key.GetValue("RandomAreaUnits", "pixels").ToString();
                displayXNA.PresetObjects.RandomObjects.Speed = Convert.ToInt32(key.GetValue("RandomSpeed", 0));
                displayXNA.PresetObjects.RandomObjects.SpeedRandomness = Convert.ToInt32(key.GetValue("RandomSpeedRandomness", 0));

                SetControls();
            }
            else     // default values
            {
                ResetToDefaults();
                displayXNA.initCustomShape(displayXNA.CustomShape.PixelSize, Microsoft.Xna.Framework.Color.White);
            }
        }

        private void SaveSettings()
        {
            // Create or get existing subkey
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Peter Popma\\GravityOne");

            key.SetValue("FrameRate", DisplayXNA.GravitySystem.TargetFrameRate);
            key.SetValue("PrecalcTime", DisplayXNA.GravitySystem.PreCalculationTime);
            key.SetValue("CalculationsPerStepSetting", displayXNA.GravitySystem.CalculationsPerStepSetting);
            key.SetValue("CalculationsPerStepPrecalculatedGalaxy", displayXNA.GravitySystem.CalculationsPerStepPrecalculatedGalaxy);
            key.SetValue("CalculationsPerStepPrecalculatedSolar", displayXNA.GravitySystem.CalculationsPerStepPrecalculatedSolar);
            key.SetValue("SaveDir", SaveDir);
            key.SetValue("CompressRecordings", compressRecordings);
            key.SetValue("Background", DisplayXNA.BackgroundIndex);
            key.SetValue("ShowNames", DisplayXNA.ShowNames);
            key.SetValue("ShowScale", DisplayXNA.ShowScale);
            key.SetValue("ShowGrid", DisplayXNA.ShowGrid);
            key.SetValue("ShowAsDots", DisplayXNA.ShowForce);
            key.SetValue("Reverse", DisplayXNA.Reverse);
            key.SetValue("AllTrails", checkBoxTraceAll.Checked);
            key.SetValue("AllVectors", checkBoxVectorsAll.Checked);
            // not saved            key.SetValue("TextureMode", displayXNA.BlendState.ToString());
            key.SetValue("CustomShapeType", DisplayXNA.CustomShape.Type);
            key.SetValue("CustomShapeAlpha", DisplayXNA.CustomShape.Alpha);
            key.SetValue("CustomShapeSize", DisplayXNA.CustomShape.SizeToText());
            key.SetValue("CustomShapeColor", DisplayXNA.CustomShape.ColorToText());
            key.SetValue("CustomShapeUpdateExisting", DisplayXNA.CustomShape.UpdateExisting);
            key.SetValue("GravitationalConstant", DisplayXNA.GravitySystem.GravitationalConstant);
            key.SetValue("GalaxyMass", DisplayXNA.PresetObjects.Galaxy.TotalMass);
            key.SetValue("GalaxyBlackHoleMass", DisplayXNA.PresetObjects.Galaxy.BlackHoleMass);
            key.SetValue("GalaxyCrossSection", DisplayXNA.PresetObjects.Galaxy.CrossSection);
            key.SetValue("GalaxyHasBlackHole", DisplayXNA.PresetObjects.Galaxy.HasBlackHole);
            key.SetValue("GalaxySpiral", DisplayXNA.PresetObjects.Galaxy.HasSpiral);
            key.SetValue("GalaxyEllipse", DisplayXNA.PresetObjects.Galaxy.HasEllipse);
            key.SetValue("GalaxyNumberOfObjects", DisplayXNA.PresetObjects.Galaxy.NumberOfObjects);
            key.SetValue("GalaxyRotateCCW", DisplayXNA.PresetObjects.Galaxy.RotateCCW);
            key.SetValue("GalaxyRotationPeriod", DisplayXNA.PresetObjects.Galaxy.RotationPeriod);
            key.SetValue("GalaxyVelocityIncreaseFactor", Convert.ToDecimal(DisplayXNA.PresetObjects.Galaxy.VelocityIncreaseFactor));
            key.SetValue("GalaxySpiralArms", DisplayXNA.PresetObjects.Galaxy.NumberOfArms);
            key.SetValue("GalaxySpiralArmLength", DisplayXNA.PresetObjects.Galaxy.ArmLength);
            key.SetValue("GalaxyHasBar", DisplayXNA.PresetObjects.Galaxy.HasBar);
            key.SetValue("GalaxyEllipseRatio", DisplayXNA.PresetObjects.Galaxy.EllipseRatio);
            key.SetValue("GalaxyEllipseSizePercentage", DisplayXNA.PresetObjects.Galaxy.EllipseSizePercentage);
            key.SetValue("GalaxyEllipseObjectsPercentage", DisplayXNA.PresetObjects.Galaxy.EllipseObjectsPercentage);
            key.SetValue("GalaxyBarPercentage", DisplayXNA.PresetObjects.Galaxy.BarPercentage);
            key.SetValue("GalaxyEllipseBlurriness", DisplayXNA.PresetObjects.Galaxy.EllipseBlurriness);
            key.SetValue("GalaxySpiralBlurriness", DisplayXNA.PresetObjects.Galaxy.SpiralBlurriness);
            key.SetValue("GalaxyMassVariation", DisplayXNA.PresetObjects.Galaxy.MassVariation);
            key.SetValue("GalaxyAddSolarSystem", DisplayXNA.PresetObjects.Galaxy.AddSolarSystem);
            key.SetValue("GalaxyCalculateStableSpeed", DisplayXNA.PresetObjects.Galaxy.CalculateStableSpeed);
            key.SetValue("GalaxyXSpeed", DisplayXNA.PresetObjects.Galaxy.XSpeed);
            key.SetValue("GalaxyYSpeed", DisplayXNA.PresetObjects.Galaxy.YSpeed);
            key.SetValue("BarnesHutTreshold", displayXNA.GravitySystem.QuadTree.Treshold);
            key.SetValue("UseBarnesHut", displayXNA.GravitySystem.UseBarnesHut);
            key.SetValue("MinimumTextureSize", displayXNA.GravitySystem.MinimumTextureSize);
            key.SetValue("AccelerationLimit", displayXNA.GravitySystem.AccelerationLimit);
            key.SetValue("VideoCaptureCompression", displayXNA.VideoCaptureCompression);
            key.SetValue("VideoCaptureFPS", displayXNA.VideoCaptureFPS);
            key.SetValue("GridMass", DisplayXNA.PresetObjects.Grid.Mass);
            key.SetValue("GridRotations", DisplayXNA.PresetObjects.Grid.Rotations);
            key.SetValue("GridSpacing", DisplayXNA.PresetObjects.Grid.Spacing);
            key.SetValue("GridSpacingUnits", DisplayXNA.PresetObjects.Grid.SpacingUnits);
            key.SetValue("GridTexture", DisplayXNA.PresetObjects.Grid.Texture.Name);
            key.SetValue("GridXAmount", DisplayXNA.PresetObjects.Grid.XAmount);
            key.SetValue("GridYAmount", DisplayXNA.PresetObjects.Grid.YAmount);
            key.SetValue("GridXSpeed", DisplayXNA.PresetObjects.Grid.XSpeed);
            key.SetValue("GridYSpeed", DisplayXNA.PresetObjects.Grid.YSpeed);
            key.SetValue("CircleMass", DisplayXNA.PresetObjects.Circle.Mass);
            key.SetValue("CircleRotations", DisplayXNA.PresetObjects.Circle.Rotations);
            key.SetValue("CircleSpacing", DisplayXNA.PresetObjects.Circle.Spacing);
            key.SetValue("CircleSpacingUnits", DisplayXNA.PresetObjects.Circle.SpacingUnits);
            key.SetValue("CircleTexture", DisplayXNA.PresetObjects.Circle.Texture.Name);
            key.SetValue("CircleNumberOfObjectsRadius", DisplayXNA.PresetObjects.Circle.NumObjectsRadius);
            key.SetValue("CircleXSpeed", DisplayXNA.PresetObjects.Circle.XSpeed);
            key.SetValue("CircleYSpeed", DisplayXNA.PresetObjects.Circle.YSpeed);
            key.SetValue("RandomMass", DisplayXNA.PresetObjects.RandomObjects.Mass);
            key.SetValue("RandomNumberOfObjects", DisplayXNA.PresetObjects.RandomObjects.NumberOfObjects);
            key.SetValue("RandomTexture", DisplayXNA.PresetObjects.RandomObjects.Texture.Name);
            key.SetValue("RandomArea", DisplayXNA.PresetObjects.RandomObjects.Area);
            key.SetValue("RandomAreaUnits", DisplayXNA.PresetObjects.RandomObjects.AreaUnits);
            key.SetValue("RandomSpeed", DisplayXNA.PresetObjects.RandomObjects.Speed);
            key.SetValue("RandomSpeedRandomness", DisplayXNA.PresetObjects.RandomObjects.SpeedRandomness);
            DisplayXNA.PresetObjects.RandomObjects.Area = Convert.ToUInt64(key.GetValue("RandomArea", 1000));
            DisplayXNA.PresetObjects.RandomObjects.AreaUnits = key.GetValue("RandomAreaUnits", "pixels").ToString();
            DisplayXNA.PresetObjects.RandomObjects.Speed = Convert.ToInt32(key.GetValue("RandomSpeed", 0));
            DisplayXNA.PresetObjects.RandomObjects.SpeedRandomness = Convert.ToInt32(key.GetValue("RandomSpeedRandomness", 0));
        }

        public void SetControls()
        {
            checkBoxShowNames.Checked = displayXNA.ShowNames;
            checkBoxReverse.Checked = displayXNA.Reverse;
            checkBoxTraceAll.Checked = displayXNA.ShowTrailsAll;
            checkBoxVectorsAll.Checked = displayXNA.ShowVectorsAll;
            checkBoxShowGrid.Checked = displayXNA.ShowGrid;
        }

        public void ResetToDefaults()
        {
            saveDir = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "Recordings";
            try
            {
                System.IO.Directory.CreateDirectory(saveDir);       // create if not exists
            }
            catch(System.UnauthorizedAccessException e)
            {
                Console.WriteLine("Exception caught: {0}", e);
            }
            compressRecordings = true;
            displayXNA.GravitySystem.TargetFrameRate = 25;
            displayXNA.GravitySystem.PreCalculationTime = 20;
            displayXNA.GravitySystem.CalculationsPerStepSetting = -1;
            displayXNA.GravitySystem.CalculationsPerStepPrecalculatedGalaxy = 1;
            displayXNA.GravitySystem.CalculationsPerStepPrecalculatedSolar = 100;
            displayXNA.setBackground(2);
            displayXNA.ShowForce = false;
            displayXNA.ShowNames = true;
            displayXNA.ShowScale = true;
            displayXNA.ShowGrid = false;
            displayXNA.SetAllTraces(true);
            displayXNA.SetAllVectors(false);
            displayXNA.setReverse(false);
            displayXNA.BlendState = BlendState.AlphaBlend;
            displayXNA.ColorScheme = 0;
            displayXNA.CustomShape.TextToColor("White");
            displayXNA.CustomShape.TextToSize("5");
            displayXNA.CustomShape.Alpha = 120;
            displayXNA.CustomShape.Type = 1;
            displayXNA.CustomShape.UpdateExisting = false;
            displayXNA.GravitySystem.GravitationalConstant = 667408000000;
            displayXNA.GravitySystem.UseBarnesHut = true;
            displayXNA.GravitySystem.QuadTree.Treshold = 0.5;
            displayXNA.GravitySystem.MinimumTextureSize = 11;
            displayXNA.GravitySystem.AccelerationLimit = 0.00000001;
            displayXNA.VideoCaptureCompression = "(none)";
            displayXNA.VideoCaptureFPS= 60;
            DisplayXNA.PresetObjects.Grid.Mass = 20000;
            DisplayXNA.PresetObjects.Grid.Rotations = 0;
            DisplayXNA.PresetObjects.Grid.Spacing = 50;
            DisplayXNA.PresetObjects.Grid.SpacingUnits = "pixels";
            DisplayXNA.PresetObjects.Grid.Texture = DisplayXNA.GetTextureByName("<Custom Shape>");
            DisplayXNA.PresetObjects.Grid.XAmount = 20;
            DisplayXNA.PresetObjects.Grid.YAmount = 20;
            DisplayXNA.PresetObjects.Grid.XSpeed = 0;
            DisplayXNA.PresetObjects.Grid.YSpeed = 0;
            DisplayXNA.PresetObjects.Circle.Mass = 20000;
            DisplayXNA.PresetObjects.Circle.Rotations = 0;
            DisplayXNA.PresetObjects.Circle.Spacing = 50;
            DisplayXNA.PresetObjects.Circle.SpacingUnits = "pixels";
            DisplayXNA.PresetObjects.Circle.Texture = DisplayXNA.GetTextureByName("<Custom Shape>");
            DisplayXNA.PresetObjects.Circle.NumObjectsRadius = 20;
            DisplayXNA.PresetObjects.Circle.XSpeed = 0;
            DisplayXNA.PresetObjects.Circle.YSpeed = 0;
            DisplayXNA.PresetObjects.RandomObjects.Mass = 5000000;
            DisplayXNA.PresetObjects.RandomObjects.NumberOfObjects = 200;
            DisplayXNA.PresetObjects.RandomObjects.Texture = DisplayXNA.GetTextureByName("<Custom Shape>");
            DisplayXNA.PresetObjects.RandomObjects.Area = 1000;
            DisplayXNA.PresetObjects.RandomObjects.AreaUnits = "pixels";
            DisplayXNA.PresetObjects.RandomObjects.Speed = 0;
            DisplayXNA.PresetObjects.RandomObjects.SpeedRandomness = 0;
            DisplayXNA.PresetObjects.PresetToMilkyWay();
        }

        private void SetupTimers()
        {
            // Create a timer for screen updates.
            updateScreenTimer = new System.Windows.Forms.Timer();
            updateScreenTimer.Interval = 1000 / FrameRate;
            updateScreenTimer.Tick += new EventHandler(OnTimedEventUpdateScreen);
            updateScreenTimer.Start();

            // Create a timer with a 10 msec interval.
            panTimer = new System.Timers.Timer(10);
            panTimer.Elapsed += OnTimedEventPan;
            panTimer.AutoReset = true;
            panTimer.Enabled = false;

        }

        private void OnTimedEventUpdateScreen(object sender, EventArgs eArgs)
        {
            IntervalCounter++;
            displayXNA.UpdateFrame();

            displayXNA.UpdateScreen();
            if (IntervalCounter % 20 == 0)
            {
                UpdateObjectValues();
            }

            if (IntervalCounter % 150 == 0 && displayXNA.GravitySystem.FrameNumberCalc < 2)     // Adjust framerate only in real-time mode
            {
                // Adjust framerate if needed
                if (displayXNA.GravitySystem.CalculationTime > 0 /*(1000 / FrameRate)*/)
                {
                    int oldFrameRate = FrameRate;
                    FrameRate = Convert.ToInt32(1000 / (displayXNA.GravitySystem.CalculationTime * 1.1));
                    if(FrameRate<1)
                    {
                        FrameRate = 1;
                    }
                    if (FrameRate < oldFrameRate * 0.8 || FrameRate > oldFrameRate * 1.2)
                    {
                        UpdateSecondsPerStep();
                    }
                }
            }

            // Check if calculation job has ended
            if (gradientButtonRecord.Active && displayXNA.GravitySystem.FrameNumberCalc > displayXNA.GravitySystem.NumPrecalculatedFrames())
            {
                gradientButtonRecord.Active = false;
                gradientButtonRecord.Image = Resources.icon_record_32;
                displayXNA.GravitySystem.IsRecording = false;
            }
        }

        private void OnTimedEventPan(Object source, System.Timers.ElapsedEventArgs e)
        {
            switch(PanDirection)
            {
                case 0:
                    displayXNA.GravitySystem.OffsetY -= 16;
                    break;
                case 1:
                    displayXNA.GravitySystem.OffsetX += 16;
                    break;
                case 2:
                    displayXNA.GravitySystem.OffsetY += 16;
                    break;
                case 3:
                    displayXNA.GravitySystem.OffsetX -= 16;
                    break;

            }
            displayXNA.UpdateScreen();
        }

        private void displayXNA_MouseMove(object sender, MouseEventArgs e)
        {
            Update();
        }

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop the timer
            updateScreenTimer.Enabled = false;

            SaveSettings();
        }

        private void PlaceSolarSystem(double x, double y)
        {
            displayXNA.PresetObjects.CreateSolarSystem(x, y);

            if (gradientPanelObjectProperties.Visible == false)    // display properties panel
            {
                gradientButtonToggleObject.Active = true;
                gradientPanelObjectProperties.Visible = true;
            }
        }

        private void PlaceSolarSystemMoons(double x, double y, bool addJWST = false)
        {
            displayXNA.PresetObjects.CreateSolarSystemMoons(x, y);

            if (gradientPanelObjectProperties.Visible == false)    // display properties panel
            {
                gradientButtonToggleObject.Active = true;
                gradientPanelObjectProperties.Visible = true;
            }
        }

        private void displayXNA_Click(object sender, MouseEventArgs e)
        {
            double x_real = displayXNA.GravitySystem.ScreenToRealCoordinateX(e.X);
            double y_real = displayXNA.GravitySystem.ScreenToRealCoordinateY(e.Y);
            Cursor = Cursors.Arrow;

            if (PlacingObject.Equals(PlacingObject_.Pick))       // pick object
            {
                gradientButtonPick.ForeColor = Color.Black;
                displayXNA.GravitySystem.SelectObjectAtMousePointer(x_real, y_real);
                PlacingObject = PlacingObject_.None;
                displayXNA.ShowClickMessage = false;
                UpdateObjectProperties();
                Refresh();
                return;
            }

            if (displayXNA.GravitySystem.IsCalculating)
            {
                DialogResult result = MessageBox.Show("There is a recording running. Adding an object will restart it. Do you want this?", "Recording in progress", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            
            // Stop calculation, so that there are no out of range exceptions (and galaxies can be placed faster)
            displayXNA.GravitySystem.StopCalculation();


            if (gradientPanelObjectProperties.Visible == false)    // display properties panel
            {
                gradientButtonToggleObject.Active = true;
                gradientPanelObjectProperties.Visible = true;
            }
            if (!PlacingObject.Equals(PlacingObject_.None))
            {
                switch (PlacingObject)
                {
                    case PlacingObject_.PlanetMoon:
                       gradientButtonPlanetSystems.ForeColor = Color.Black;
                       displayXNA.PresetObjects.CreatePlanetMoon(x_real, y_real);
                       break;
                    case PlacingObject_.SolarSystem:
                        gradientButtonPlanetSystems.ForeColor = Color.Black;
                        PlaceSolarSystem(x_real, y_real);
                       break;
                    case PlacingObject_.SunPlanetMoon:
                        gradientButtonPlanetSystems.ForeColor = Color.Black;
                        displayXNA.PresetObjects.CreateSunPlanetMoon(x_real, y_real);
                        break;
                    case PlacingObject_.SunPlanet:
                        gradientButtonPlanetSystems.ForeColor = Color.Black;
                        displayXNA.PresetObjects.CreateSunPlanet(x_real, y_real);
                        break;
                    case PlacingObject_.SlingShot:
                        gradientButtonSlingshot.ForeColor = Color.Black;
                        displayXNA.PresetObjects.CreateSlingShot(x_real, y_real);
                        break;
                    case PlacingObject_.MoonMoon:
                        gradientButtonPlanetSystems.ForeColor = Color.Black;
                        displayXNA.PresetObjects.CreateMoonMoon(x_real, y_real);
                        break;
                    case PlacingObject_.BinaryTwoPlanets:
                        gradientButtonBinary.ForeColor = Color.Black;
                        displayXNA.PresetObjects.CreateBinaryTwoPlanets(x_real, y_real);
                        break;
                    case PlacingObject_.BinaryOnePlanetStable:
                        gradientButtonBinary.ForeColor = Color.Black;
                        displayXNA.PresetObjects.CreateBinaryOnePlanetStable(x_real, y_real);
                        break;
                    case PlacingObject_.Random:
                        gradientButtonRandom.ForeColor = Color.Black;
                        displayXNA.PresetObjects.CreateRandom(x_real, y_real);
                        break;
                    case PlacingObject_.Grid:
                        gradientButtonGrid.ForeColor = Color.Black;
                        displayXNA.PresetObjects.CreateGrid(x_real, y_real);
                        DisplayXNA.updateCustomShapes();
                        break;
                    case PlacingObject_.BinaryOnePlanetHopping:
                        gradientButtonBinary.ForeColor = Color.Black;
                        displayXNA.PresetObjects.CreateBinaryOnePlanetHopping(x_real, y_real);
                        break;
                    case PlacingObject_.TripleStar:
                        gradientButtonBinary.ForeColor = Color.Black;
                        displayXNA.PresetObjects.CreateTripleStar(x_real, y_real);
                        break;
                    case PlacingObject_.SolarSystemMoons:
                        gradientButtonPlanetSystems.ForeColor = Color.Black;
                        PlaceSolarSystemMoons(x_real, y_real);
                        break;
                    case PlacingObject_.Galaxy:
                        gradientButtonGalaxy.ForeColor = Color.Black;
                        Cursor = Cursors.WaitCursor;
                        Refresh();
                        int startPosition = displayXNA.GravitySystem.GravityObjects.Count;
                        displayXNA.PresetObjects.CreateGalaxy(x_real, y_real, startPosition);
                        if (!displayXNA.PresetObjects.Galaxy.AddSolarSystem)
                        {
                            displayXNA.GravitySystem.ObjectIndex = -1;     // no object selected
                            displayXNA.ParentForm.gradientPanelObjectProperties.Visible = false;
                        }

                        displayXNA.GravitySystem.CenterIndex = -1;     // no center object
                        displayXNA.GravitySystem.ScaleObjects();       // scale has changed by this setup
                        displayXNA.updateCustomShapes(startPosition);      // We need to set the color of each star on "random color" mode seperately

                        gradientButtonToggleObject.Active = false;
                        if (!displayXNA.PresetObjects.Galaxy.AddSolarSystem)
                        {
                            gradientPanelObjectProperties.Visible = false;
                        }

                        // when placing a galaxy, we want to start recording
                        StartRecording();

                        break;
                    case PlacingObject_.Circle:
                        gradientButtonCircle.ForeColor = Color.Black;
                        displayXNA.PresetObjects.CreateCircle(x_real, y_real);
                        break;
                    case PlacingObject_.Neighbourhood:
                        gradientButtonPlanetSystems.ForeColor = Color.Black;
                        displayXNA.PresetObjects.CreateNeighbourhood(x_real, y_real);
                        break;
                }

                PlacingObject = PlacingObject_.None;
                displayXNA.ShowClickMessage = false;
            }
            else
            {

                try
                {
                    Convert.ToDouble(textBoxXSpeed.Text);
                }
                catch (Exception)
                {
                    textBoxXSpeed.Text = "0";
                }
                try
                {
                    Convert.ToDouble(textBoxYSpeed.Text);
                }
                catch (Exception)
                {
                    textBoxYSpeed.Text = "0";
                }
                try
                {
                    Convert.ToDouble(textBoxMass.Text);
                }
                catch (Exception)
                {
                    textBoxMass.Text = "0";
                }
                displayXNA.AddGravityObject(x_real, y_real, checkBoxCircleHost.Checked, checkBoxCircleCCW.Checked);
                // select the added object
                displayXNA.GravitySystem.ObjectIndex = displayXNA.GravitySystem.GravityObjects.Count - 1;
                displayXNA.GravitySystem.VisibleObjectsIndex = displayXNA.GravitySystem.CountVisibleObjects();
                // create new unique name for next object
                textBoxName.Text = displayXNA.FindUniqueObjectName("Object");
            }
            UpdateObjectProperties();
            Refresh();

            displayXNA.GravitySystem.InitCalculation();
        }

        private void gradientButtonUpdateObject_Click(object sender, EventArgs e)
        {
            if (!originalXSpeed.Equals(textBoxAdjustXSpeed.Text))       // only change speed if values were modified
            {
                displayXNA.GravitySystem.CurrentObject().XSpeed = Convert.ToDouble(textBoxAdjustXSpeed.Text);
            }
            if (!originalXSpeed.Equals(textBoxAdjustXSpeed.Text))       // only change speed if values were modified
            {
                displayXNA.GravitySystem.CurrentObject().YSpeed = Convert.ToDouble(textBoxAdjustYSpeed.Text);
            }
            Texture2D texture = displayXNA.GetTextureByName(comboBoxAdjustShape.Text);

            displayXNA.GravitySystem.CurrentObject().Texture = texture;
            displayXNA.GravitySystem.ScaleCurrentObject();
            displayXNA.GravitySystem.CurrentObject().Mass = Convert.ToDouble(textBoxAdjustMass.Text);
            displayXNA.GravitySystem.CurrentObject().Name = textBoxAdjustName.Text;
            displayXNA.GravitySystem.CurrentObject().IsActive = checkBoxActive.Checked;
            displayXNA.GravitySystem.CurrentObject().Trace = checkBoxAdjustTrace.Checked;
            displayXNA.GravitySystem.CurrentObject().Vector = checkBoxAdjustVector.Checked;
            UpdateObjectProperties();
            displayXNA.GravitySystem.InitCalculation();
        }

        private void gradientButtonAdjustValues_Click(object sender, EventArgs e)
        {
            if (gradientButtonAdjustValues.Active)
            {
                gradientPanelObjectProperties.Height = OBJECTPROPERTIES_HEIGHT_COLLAPSED;
                gradientButtonAdjustValues.Active = false;
            }
            else
            {
                UpdateAdjustValues();
                gradientPanelObjectProperties.Height = OBJECTPROPERTIES_HEIGHT;
                gradientButtonAdjustValues.Active = true;
            }
        }

        private void UpdateAdjustValues()
        {
            originalXSpeed = textBoxAdjustXSpeed.Text = displayXNA.GravitySystem.CurrentObject().XSpeed.ToString("0.##");
            originalYSpeed = textBoxAdjustYSpeed.Text = displayXNA.GravitySystem.CurrentObject().YSpeed.ToString("0.##");
            textBoxAdjustMass.Text = displayXNA.GravitySystem.CurrentObject().Mass.ToString("0.##");
            textBoxAdjustName.Text = displayXNA.GravitySystem.CurrentObject().Name;
            checkBoxAdjustTrace.Checked = displayXNA.GravitySystem.CurrentObject().Trace;
            checkBoxAdjustVector.Checked = displayXNA.GravitySystem.CurrentObject().Vector;
            checkBoxActive.Checked = displayXNA.GravitySystem.CurrentObject().IsActive;
            comboBoxAdjustShape.SelectedIndex = comboBoxAdjustShape.FindString(displayXNA.GravitySystem.CurrentObject().Texture.Name);
        }

        private void gradientButtonToggleToolbox_Click(object sender, EventArgs e)
        {
            if (gradientButtonToggleToolbox.Active)
            {
                gradientPanelToolbox.Visible = false;
                gradientButtonToggleToolbox.Active = false;
            }
            else
            {
                gradientPanelToolbox.Visible = true;
                gradientButtonToggleToolbox.Active = true;
            }
        }

        private void gradientButtonPlanet_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "1000";
            textBoxName.Text = displayXNA.FindUniqueObjectName("Planet");
            comboBoxTexture.Text = "Planet";
        }

        private void gradientButtonEarth_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "597.2";
            textBoxName.Text = displayXNA.FindUniqueObjectName("Earth");
            comboBoxTexture.Text = "Earth";
        }

        private void gradientButtonSun_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "198900000";
            textBoxName.Text = displayXNA.FindUniqueObjectName("Sun");
            comboBoxTexture.Text = "Sun";
        }

        private void gradientButtonMoon_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "7.342";
            textBoxName.Text = displayXNA.FindUniqueObjectName("Moon");
            comboBoxTexture.Text = "Moon";
        }

        private void gradientButtonMercury_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "32.85";
            textBoxName.Text = displayXNA.FindUniqueObjectName("Mercury");
            comboBoxTexture.Text = "Mercury";
        }

        private void gradientButtonVenus_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "486.7";
            textBoxName.Text = displayXNA.FindUniqueObjectName("Venus");
            comboBoxTexture.Text = "Venus";
        }

        private void gradientButtonMars_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "63.9";
            textBoxName.Text = displayXNA.FindUniqueObjectName("Mars");
            comboBoxTexture.Text = "Mars";
        }

        private void gradientButtonSaturn_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "56830";
            textBoxName.Text = displayXNA.FindUniqueObjectName("Saturn");
            comboBoxTexture.Text = "Saturn";
        }

        private void gradientButtonJupiter_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "189800";
            textBoxName.Text = displayXNA.FindUniqueObjectName("Jupiter");
            comboBoxTexture.Text = "Jupiter";
        }

        private void gradientButtonUranus_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "8681";
            textBoxName.Text = displayXNA.FindUniqueObjectName("Uranus");
            comboBoxTexture.Text = "Uranus";
        }

        private void gradientButtonNeptune_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "10240";
            textBoxName.Text = displayXNA.FindUniqueObjectName("Neptune");
            comboBoxTexture.Text = "Neptune";
        }

        private void gradientButtonPluto_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "1.31";
            textBoxName.Text = displayXNA.FindUniqueObjectName("Pluto");
            comboBoxTexture.Text = "Pluto";
        }

        public void UpdateObjectProperties()
        {
            if (displayXNA.GravitySystem.GetSolarSystems().Count > 0)
            {
                gradientButtonSolarSystems.Enabled = true;
            }

            if (displayXNA.GravitySystem.GravityObjects.Count > 0)
            {
                gradientButtonToggleObject.Enabled = true;
            }
            else
            {
                gradientButtonToggleObject.Enabled = false;
            }
            if (displayXNA.GravitySystem.GravityObjects.Count == 0 || displayXNA.GravitySystem.ObjectIndex==-1)        // nothing to display
            {
                gradientPanelObjectProperties.Visible = false;
                gradientPanelObjectProperties.Height = OBJECTPROPERTIES_HEIGHT_COLLAPSED;
                gradientButtonAdjustValues.Active = false;
                gradientButtonToggleObject.Active = false;
                Refresh();
                return;
            }
            labelObjectNumber.Text = (displayXNA.GravitySystem.VisibleObjectsIndex).ToString();
            labelNumberObjects.Text = displayXNA.GravitySystem.CountVisibleObjects().ToString();
            checkBoxCenter.Checked = displayXNA.GravitySystem.IsCurrentObjectedCenter();
            labelObjectName.Text = displayXNA.GravitySystem.CurrentObject().Name;
            labelMass.Text = displayXNA.GravitySystem.CurrentObject().Mass.ToString("G10");
            UpdateObjectValues();
        }

        public void UpdateObjectValues()
        {
            if (displayXNA.GravitySystem.ObjectIndex>-1 && displayXNA.GravitySystem.ObjectIndex<displayXNA.GravitySystem.GravityObjects.Count)
            {
                labelSpeed.Text = displayXNA.GravitySystem.CurrentObject().Speed.ToString("0.##");
                labelXSpeed.Text = displayXNA.GravitySystem.CurrentObject().XSpeed.ToString("0.##");
                labelYSpeed.Text = displayXNA.GravitySystem.CurrentObject().YSpeed.ToString("0.##");
                labelAcceleration.Text = displayXNA.GravitySystem.CurrentObject().Acceleration.ToString("G5", CultureInfo.InvariantCulture);
                labelXAcceleration.Text = displayXNA.GravitySystem.CurrentObject().XAcceleration.ToString("0.#################");
                labelYAcceleration.Text = displayXNA.GravitySystem.CurrentObject().YAcceleration.ToString("0.#################");
                labelDistanceToSun.Text = displayXNA.GravitySystem.DistanceCurrentObjectZeroObject().ToString("0.##");
                labelSolarSystem.Text = displayXNA.GravitySystem.CurrentObject().SolarSystem!=null? displayXNA.GravitySystem.CurrentObject().SolarSystem.Name : "";
                labelShape.Text = displayXNA.GravitySystem.CurrentObject().Texture.Name;
                listBoxInfluenced.Items.Clear();
                listBoxInfluenced.Items.AddRange(displayXNA.GravitySystem.GetCurrentObjectInfluencedBy());
                
            }
        }

        private void gradientButtonToggleObject_Click(object sender, EventArgs e)
        {
            if (gradientButtonToggleObject.Active)
            {
                gradientPanelObjectProperties.Visible = false;
                gradientPanelObjectProperties.Height = 445;
                gradientButtonAdjustValues.Active = false;
                gradientButtonToggleObject.Active = false;
            }
            else if (displayXNA.GravitySystem.GravityObjects.Count>0)
            {
                if (displayXNA.GravitySystem.ObjectIndex == -1)
                {
                    displayXNA.GravitySystem.ObjectIndex = 0;
                    displayXNA.GravitySystem.VisibleObjectsIndex = 1;
                    UpdateObjectProperties();
                }
                gradientPanelObjectProperties.Visible = true;
                gradientButtonToggleObject.Active = true;
            }
        }


        private void checkBoxCenter_Click(object sender, EventArgs e)
        {
            if (checkBoxCenter.Checked)
            {
                displayXNA.GravitySystem.CenterIndex = displayXNA.GravitySystem.ObjectIndex;
            }
            else
            {
                displayXNA.GravitySystem.CenterIndex = -1;
            }
        }

        private void gradientButtonRemove_Click(object sender, EventArgs e)
        {
            displayXNA.GravitySystem.StopCalculation();
            if (displayXNA.GravitySystem.CurrentObject().SolarSystem != null)
            {
                if (displayXNA.GravitySystem.CurrentObject().SolarSystem.RemoveObject(displayXNA.GravitySystem.CurrentObject()))
                {
                    displayXNA.GravitySystem.GravityObjects.Remove(displayXNA.GravitySystem.CurrentObject().SolarSystem);
                }
            }
            displayXNA.GravitySystem.GravityObjects.RemoveAt(displayXNA.GravitySystem.ObjectIndex);
            displayXNA.GravitySystem.NumVisibleObjects--;
            if (displayXNA.GravitySystem.ObjectIndex >= displayXNA.GravitySystem.GravityObjects.Count)     // removing last item
            {
                displayXNA.GravitySystem.ObjectIndex--;
                displayXNA.GravitySystem.VisibleObjectsIndex--;
            }
            UpdateObjectProperties();
            displayXNA.GravitySystem.InitCalculation();
            displayXNA.GravitySystem.DetermineCalculationsPerStepActual();
        }

        private void gradientButtonStart_Click(object sender, EventArgs e)
        {
            if (displayXNA.GravitySystem.SimulationRunning)
            {
                displayXNA.GravitySystem.SimulationRunning = false;
                gradientButtonStart.Image = Resources.icon_play_32;
            } else
            {
                displayXNA.GravitySystem.SimulationRunning = true;
                displayXNA.GravitySystem.ObtainMinMaxValues();
                gradientButtonStart.Image = Resources.icon_pause_32;
            }
        }

        private void buttonUp_MouseDown(object sender, MouseEventArgs e)
        {
            displayXNA.GravitySystem.CenterIndex = -1;
            checkBoxCenter.Checked = false;
            PanDirection = 0;
            panTimer.Enabled = true;
        }

        private void buttonRight_MouseDown(object sender, MouseEventArgs e)
        {
            displayXNA.GravitySystem.CenterIndex = -1;
            checkBoxCenter.Checked = false;
            PanDirection = 1;
            panTimer.Enabled = true;
        }

        private void buttonDown_MouseDown(object sender, MouseEventArgs e)
        {
            displayXNA.GravitySystem.CenterIndex = -1;
            checkBoxCenter.Checked = false;
            PanDirection = 2;
            panTimer.Enabled = true;
        }

        private void buttonLeft_MouseDown(object sender, MouseEventArgs e)
        {
            displayXNA.GravitySystem.CenterIndex = -1;
            checkBoxCenter.Checked = false;
            PanDirection = 3;
            panTimer.Enabled = true;
        }

        private void buttonUp_MouseUp(object sender, MouseEventArgs e)
        {
            panTimer.Enabled = false;
        }

        private void buttonRight_MouseUp(object sender, MouseEventArgs e)
        {
            panTimer.Enabled = false;
        }

        private void buttonLeft_MouseUp(object sender, MouseEventArgs e)
        {
            panTimer.Enabled = false;
        }

        private void buttonDown_MouseUp(object sender, MouseEventArgs e)
        {
            panTimer.Enabled = false;
        }

        private void gradientButtonStep_Click(object sender, EventArgs e)
        {
            gradientButtonStart.Text = "Start";
            gradientButtonStart.Image = Resources.icon_play_32;
            displayXNA.GravitySystem.SimulationRunning = true;
            displayXNA.SimulationStepping = true;
        }

        private void checkBoxVectorsAll_CheckedChanged(object sender, EventArgs e)
        {
            displayXNA.SetAllVectors(checkBoxVectorsAll.Checked);
        }

        private void checkBoxTraceAll_CheckedChanged(object sender, EventArgs e)
        {
            displayXNA.SetAllTraces(checkBoxTraceAll.Checked);            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            comboBoxTexture.Items.Clear();
            comboBoxTexture.Items.AddRange(displayXNA.GetAllTextureNames());
            comboBoxTexture.SelectedItem = "Planet";
            comboBoxAdjustShape.Items.Clear();
            comboBoxAdjustShape.Items.AddRange(displayXNA.GetAllTextureNames());

            displayXNA.GravitySystem.DetermineTimeNeededForOneCalculation(displayXNA.GraphicsDevice);     // needed for DetermineCalculationsPerStepActual() 
            LoadSettings();
            macTrackBarScale.Value = 813;        // scale for solar system view

            FormSplashScreen sp = new FormSplashScreen();
            sp.ShowDialog();

            displayXNA.GravitySystem.BackgroundWorkerPreCalculate = backgroundWorkerPreCalculate;
            
            PlaceSolarSystem(0, 0);
            SetSpeed();
            // Set the property to all added solar objects
            displayXNA.SetAllVectors(checkBoxVectorsAll.Checked);
            displayXNA.SetAllTraces(checkBoxTraceAll.Checked);
            displayXNA.setReverse(checkBoxReverse.Checked);
            // perform 1 calculation to show right vectors
            displayXNA.GravitySystem.CalculateStep(1, false);

            displayXNA.GravitySystem.ObjectIndex = 0;
            displayXNA.GravitySystem.VisibleObjectsIndex = 1;
            UpdateObjectProperties();
        }

        private void gradientButtonNextObject_Click(object sender, EventArgs e)
        {
            displayXNA.GravitySystem.NextObject();
            if (checkBoxCenter.Checked)
            {
                displayXNA.GravitySystem.CenterIndex = displayXNA.GravitySystem.ObjectIndex;
            }
            UpdateObjectProperties();
            UpdateAdjustValues();
        }

        private void gradientButtonPreviousObject_Click(object sender, EventArgs e)
        {
            displayXNA.GravitySystem.PreviousObject();
            if (checkBoxCenter.Checked)
            {
                displayXNA.GravitySystem.CenterIndex = displayXNA.GravitySystem.ObjectIndex;
            }
            UpdateObjectProperties();
            UpdateAdjustValues();
        }

        private void checkBoxAdjustTrace_CheckedChanged(object sender, EventArgs e)
        {
            displayXNA.GravitySystem.CurrentObject().Trace = checkBoxAdjustTrace.Checked;
        }

        private void checkBoxAdjustVector_CheckedChanged(object sender, EventArgs e)
        {
            displayXNA.GravitySystem.CurrentObject().Vector = checkBoxAdjustVector.Checked;
        }

        private void gradientButtonSlingshot_Click(object sender, EventArgs e)
        {
            if (PlacingObject.Equals(PlacingObject_.None))
            {
                PlacingObject = PlacingObject_.SlingShot;
                gradientButtonSlingshot.ForeColor = Color.Coral;
                displayXNA.ShowClickMessage = true;
                Cursor = Cursors.Hand;
                macTrackBarScale.Value = 294;
                // TODO : set scale?
            }
        }

        private void gradientButtonDualStar_Click(object sender, EventArgs e)
        {
            if (PlacingObject == 0)
            {
                FormBinary frmBinary = new FormBinary();
                frmBinary.MyParent = this;
                frmBinary.ShowDialog();
                Cursor = Cursors.Hand;
            }
        }

        private void gradientButtonPreferences_Click(object sender, EventArgs e)
        {
            FormPreferences frmPreferences = new FormPreferences();
            frmPreferences.MyParent = this;
            frmPreferences.Initialize();
            frmPreferences.ShowDialog();
        }

        private void gradientButtonLoad_Click(object sender, EventArgs e)
        {
            FormLoadSave frmLoadSave = new FormLoadSave();
            frmLoadSave.MyParent = this;
            frmLoadSave.Text = "Load";
            frmLoadSave.gradientButtonLoadSave.Text = "Load";
            frmLoadSave.gradientButtonDelete.Visible = false;
            frmLoadSave.listBoxRecordings.Enabled = true;
            frmLoadSave.textBoxName.Enabled = false;
            frmLoadSave.EnumerateRecordings();
            frmLoadSave.labelBusy.Text = "Loading..";
            frmLoadSave.panelBusy.Visible = false;
            frmLoadSave.ShowDialog();
        }

        private void gradientButtonSave_Click(object sender, EventArgs e)
        {
            FormLoadSave frmLoadSave = new FormLoadSave();
            frmLoadSave.MyParent = this;
            frmLoadSave.Text = "Save";
            frmLoadSave.gradientButtonLoadSave.Text = "Save";
            frmLoadSave.gradientButtonDelete.Visible = false;
            frmLoadSave.textBoxName.Enabled = true;
            frmLoadSave.textBoxDate.Text = string.Format("{0:dd/MM/yy H:mm}", DateTime.Now);
            frmLoadSave.textBoxNumberOfObjects.Text = displayXNA.GravitySystem.GravityObjects.Count.ToString();
            frmLoadSave.textBoxCalcsDone.Text = displayXNA.GravitySystem.FrameNumberCalc.ToString() + "/" + displayXNA.GravitySystem.NumPrecalculatedFrames().ToString() + " (" + displayXNA.GravitySystem.CalculationsPerStepPrecalculatedGalaxy.ToString() + ")";
            frmLoadSave.labelBusy.Text = "Saving..";
            frmLoadSave.panelBusy.Visible = false;
            frmLoadSave.EnumerateRecordings();
            frmLoadSave.ShowDialog();
        }

        private void gradientButtonRemoveAll_Click(object sender, EventArgs e)
        {
            bool wasRunning = displayXNA.GravitySystem.SimulationRunning;
            displayXNA.GravitySystem.SimulationRunning = false;
            bool wasCalculating = displayXNA.GravitySystem.IsCalculating;
            displayXNA.GravitySystem.StopCalculation();
            displayXNA.Rewind();
            displayXNA.GravitySystem.CenterIndex = -1;
            displayXNA.GravitySystem.GravityObjects.Clear();
            displayXNA.GravitySystem.NumVisibleObjects = 0;
            displayXNA.GravitySystem.DetermineCalculationsPerStepActual();
            displayXNA.GravitySystem.ObjectIndex = -1;
//            displayXNA.SimulationTime = new DateTime(2017, 1, 1, 0, 0, 0);
            if(wasRunning)
            {
                displayXNA.GravitySystem.SimulationRunning = true;
            }
            displayXNA.GravitySystem.InitCalculation();
            gradientButtonSolarSystems.Enabled = false;
            UpdateObjectProperties();
        }
                
        private void AdjustScale(long scale)
        {
            // largest scale: diameter milky way = 1.7 x 10^18 km = 1700 qdn. km
            // We want that to be 1/8 of the screen = 250 pixels 
            // so 1 pixel = 6800 tln. km
            //
            // at scale 1, one pixel = 100 km 
            // so at scale 68,000,000,000,000 one pixel = 6800 tln. km

            // log(68,000,000,000,000) / log(1000) = 4.6104929723474183745846362630176
            // at scale 1000 power=4.61, at scale 1 power=1
            // so 4.51-1 / 999 = 0.00361445075499040250883138060853
            // scale = (long)Math.Pow(scale, (1-scale) + (scale * 0.00361445075499040250883138060853));
            // SCALEPOWER = 0.00361445075499040250883138060853
            scale = (long)Math.Pow(scale, (1 - SCALEPOWER) + scale * SCALEPOWER);
            if (displayXNA.GravitySystem.CenterIndex == -1)
            {
                displayXNA.GravitySystem.AdjustOffsetToNewScale(scale);
            }
            displayXNA.GravitySystem.Scale = scale;
            displayXNA.GravitySystem.ScaleObjects();
            displayXNA.AdjustScale();
            UpdateSpeedDisplay();
        }

        private double FindInverseXToPower_SCALEPOWER_X(double x)
        {
            double lowerValue = 0, upperValue = 1000;
            double testValue = 500;
            double testResult;
            do
            {
                testResult = Math.Pow(testValue, testValue * SCALEPOWER);
                if(testResult<x)
                {
                    lowerValue = testValue;
                }
                if (testResult>x)
                {
                    upperValue = testValue;
                }
                testValue = (lowerValue + upperValue) / 2;
            } while ((int)lowerValue!=(int)upperValue);


            return testValue;
        }

        public int CalcScaleBarValueFromMlnMetersPerPixel(double metersPerPixel)
        {
            double inverse_scale = FindInverseXToPower_SCALEPOWER_X(metersPerPixel);

            return 1001 - (int)inverse_scale;
        }

        string TimeUnitsPerSecond(long secondsPerSecond)
        {
            secondsPerSecond *= FrameRate;
            if (secondsPerSecond >= 31558150000000)
            {
                return string.Format("{0:0.#} million years", secondsPerSecond / 31558150000000.0);
            }
            if (secondsPerSecond >= SECONDS_PER_YEAR)
            {
                return string.Format("{0:0.#} years", secondsPerSecond / (float)SECONDS_PER_YEAR);
            }
            if (secondsPerSecond >= SECONDS_PER_DAY)
            {
                return string.Format("{0:0.#} days", secondsPerSecond / (float)SECONDS_PER_DAY);
            }
            if (secondsPerSecond >= 3600)
            {
                return string.Format("{0:0.#} hours", secondsPerSecond / 3600.0);
            }
            if (secondsPerSecond >= 60)
            {
                return string.Format("{0:0.#} minutes", secondsPerSecond / 60.0);
            }

            return string.Format("{0} seconds", secondsPerSecond);
        }

        private void gradientButtonGalaxy_Click(object sender, EventArgs e)
        {
            if (PlacingObject == 0)
            {
                FormGalaxy frmGalaxy = new FormGalaxy();
                frmGalaxy.MyParent = this;
                frmGalaxy.Initialize();
                frmGalaxy.ShowDialog();
            }
        }

        private void checkBoxCircleHost_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCircleHost.Checked)
            {
                checkBoxCircleCCW.Checked = false;
                textBoxXSpeed.Enabled = false;
                textBoxYSpeed.Enabled = false;
            }
            else
            {
                textBoxXSpeed.Enabled = true;
                textBoxYSpeed.Enabled = true;
            }
        }

        private void checkBoxShowNames_CheckedChanged(object sender, EventArgs e)
        {
            displayXNA.ShowNames = checkBoxShowNames.Checked;
        }

        private void checkBoxCircleCCW_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCircleCCW.Checked)
            {
                checkBoxCircleHost.Checked = false;
                textBoxXSpeed.Enabled = false;
                textBoxYSpeed.Enabled = false;
            }
            else
            {
                textBoxXSpeed.Enabled = true;
                textBoxYSpeed.Enabled = true;
            }
        }

        private void checkBoxReverse_CheckedChanged(object sender, EventArgs e)
        {
            displayXNA.setReverse(checkBoxReverse.Checked);
        }

        private void gradientButtonRandom_Click(object sender, EventArgs e)
        {
            if (PlacingObject == 0)
            {
                FormRandom frmRandom = new FormRandom();
                frmRandom.MyParent = this;
                frmRandom.Initialize();
                frmRandom.ShowDialog();
                Cursor = Cursors.Hand;
            }
        }

        private void gradientButtonGrid_Click(object sender, EventArgs e)
        {
            if (PlacingObject == 0)
            {
                FormGrid frmGrid = new FormGrid();
                frmGrid.MyParent = this;
                frmGrid.Initialize();
                frmGrid.ShowDialog();
                Cursor = Cursors.Hand;
            }
        }

        private void gradientButtonRewind_Click(object sender, EventArgs e)
        {
            displayXNA.Rewind();
            displayXNA.GravitySystem.DisplayFrame();
        }

        private void gradientButtonPick_Click(object sender, EventArgs e)
        {
            if (PlacingObject == 0)
            {
                PlacingObject = PlacingObject_.Pick;
                gradientButtonPick.ForeColor = Color.Coral;
                displayXNA.ShowClickMessage = true;
                this.Cursor = Cursors.Hand;
            }
        }

        private void gradientButtonCaptureVideo_Click(object sender, EventArgs e)
        {
            if (gradientButtonCaptureVideo.Active)
            {
                displayXNA.StopRecording();
                gradientButtonCaptureVideo.Active = false;
                displayXNA.GravitySystem.Message.Text = "Saved video as \"" +saveDir + "\\VideoCapture.avi\"";
            }
            else
            {
                displayXNA.StartRecording(saveDir+"\\VideoCapture.avi");
                gradientButtonCaptureVideo.Active = true;
            }
            gradientButtonCaptureVideo.Invalidate();
        }

        private void gradientButtonPlanetSystems_Click(object sender, EventArgs e)
        {
            if (PlacingObject == 0)
            {
                FormPlanetSystems frmPlanetSystems = new FormPlanetSystems();
                frmPlanetSystems.MyParent = this;
                frmPlanetSystems.ShowDialog();
                Cursor = Cursors.Hand;
            } 
        }

        private void gradientButtonCircle_Click(object sender, EventArgs e)
        {
            if (PlacingObject == 0)
            {
                FormCircle frmCircle = new FormCircle();
                frmCircle.MyParent = this;
                frmCircle.Initialize();
                frmCircle.ShowDialog();
                Cursor = Cursors.Hand;
            }
        }

        private void macTrackBarScale_ValueChanged(object sender, decimal value)
        {
            int scale = 1001 - macTrackBarScale.Value;
            AdjustScale(scale);
        }

        public void SetSpeed()
        {
            if (macTrackBarSpeed.Value != currentSpeedbarValue)
            {
                if (displayXNA.GravitySystem.IsCalculating)
                {
                    DialogResult result = MessageBox.Show("There is a calculation running. Changing the speed will restart it. Do you want this?", "Recording in progress", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        macTrackBarSpeed.Value = currentSpeedbarValue;
                        return;
                    }
                }

                currentSpeedbarValue = macTrackBarSpeed.Value;

                UpdateSecondsPerStep();
            }
        }

        private void UpdateSecondsPerStep()
        {
            // Calculate seconds depending on slider value
            // speed: 1 - 1000
            // for solar systems: 86,400 - 50,000,000 secondspersecond
            // (= 1,728 - 630,720 secondsperstep
            // (for galaxies times TIME_GALAXY_INCREASE_FACTOR)
            displayXNA.SecondsPerStepSolarSystem = 1200 + (currentSpeedbarValue * 3000);

            displayXNA.GravitySystem.CalculationSecondsPerFrame = displayXNA.SecondsPerStepSolarSystem;
            displayXNA.GravitySystem.InitCalculation();

            UpdateSpeedDisplay();
        }

        private void UpdateSpeedDisplay()
        {
            displayXNA.UseGalaxyTiming = displayXNA.GravitySystem.Scale >= 10000000;

            if (displayXNA.UseGalaxyTiming)       // galaxy mode
            {
                labelTimePerStep.Text = "1 sec. = " + TimeUnitsPerSecond(displayXNA.SecondsPerStepSolarSystem * GravitySystem.TIME_GALAXY_INCREASE_FACTOR);
            }
            else                       // solar system mode     
            {
                labelTimePerStep.Text = "1 sec. = " + TimeUnitsPerSecond(displayXNA.SecondsPerStepSolarSystem);
            }
        }

        private void gradientButtonSolarSystems_Click(object sender, EventArgs e)
        {
            FormSolarSystems frmSolarSystems = new FormSolarSystems();
            frmSolarSystems.MyParent = this;
            frmSolarSystems.Initialize();
            frmSolarSystems.ShowDialog();
        }

        private void checkBoxShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            displayXNA.ShowGrid = checkBoxShowGrid.Checked;
        }

        private void gradientButtonNextGalaxyObject_Click(object sender, EventArgs e)
        {
            displayXNA.GravitySystem.NextGalaxyObject();
            if (checkBoxCenter.Checked)
            {
                displayXNA.GravitySystem.CenterIndex = displayXNA.GravitySystem.ObjectIndex;
            }
            UpdateObjectProperties();
            UpdateAdjustValues();
        }

        private void gradientButtonPreviousGalaxyObject_Click(object sender, EventArgs e)
        {
            displayXNA.GravitySystem.PreviousGalaxyObject();
            if (checkBoxCenter.Checked)
            {
                displayXNA.GravitySystem.CenterIndex = displayXNA.GravitySystem.ObjectIndex;
            }
            UpdateObjectProperties();
            UpdateAdjustValues();
        }

        private void macTrackBarSpeed_MouseUp(object sender, MouseEventArgs e)
        {
            SetSpeed();
        }

        private void gradientButtonRecord_Click(object sender, EventArgs e)
        {
            if (displayXNA.GravitySystem.IsCalculating)
            {
                StopRecording();
            }
            else
            {
                StartRecording();
            }
        }

        public void StopRecording()
        {
            gradientButtonRecord.Active = false;
            gradientButtonRecord.Image = Resources.icon_record_32;
            displayXNA.GravitySystem.IsRecording = false;
            // Cancel running calculation thread
            displayXNA.GravitySystem.StopCalculation();
        }

        public void StartRecording()
        {
            FrameRate = displayXNA.GravitySystem.TargetFrameRate;       // Reset the framerate, because we will use pre-calculation
            if (displayXNA.GravitySystem.FrameNumberCalc<2)      // No frames recorded yet
            {
                displayXNA.GravitySystem.InitCalculation();
            }
            if(displayXNA.GravitySystem.FrameNumberCalc < displayXNA.GravitySystem.NumPrecalculatedFrames())
            {
                gradientButtonRecord.Active = true;
                gradientButtonRecord.Image = Resources.icon_recording_32;
                gradientButtonRewind.Enabled = true;
                displayXNA.GravitySystem.IsRecording = true;
                displayXNA.GravitySystem.StartCalculation();       // start (resume if paused)
            }
        }

        private void displayXNA_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxShowForce_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowForce.Checked)
            {
                checkBoxShowSpeeds.Checked = false;
                displayXNA.ShowForce = true;
                displayXNA.ShowSpeed = false;
            }
            else
            {
                displayXNA.ShowForce = false;
            }
        }

        private void checkBoxShowSpeeds_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowSpeeds.Checked)
            {
                checkBoxShowForce.Checked = false;
                displayXNA.ShowSpeed = true;
                displayXNA.ShowForce = false;
            }
            else
            {
                displayXNA.ShowSpeed = false;
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            gradientPanelMain.Top = this.Height - 38 - gradientPanelMain.Height;
            gradientPanelObjectProperties.Left = this.Width - 16 - gradientPanelObjectProperties.Width;
        }

    }
}

