using Microsoft.Win32;
using Microsoft.Xna.Framework.Graphics;
using SharpAvi.Codecs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GravityOne.Forms
{
    public partial class FormMain : Form
    {
        private static System.Windows.Forms.Timer updateScreenTimer;
        private static System.Timers.Timer panTimer;
        private static int placingObject = 0;
        private static int Interval = 1;
        private static int IntervalCounter = 0;
        private static int PanDirection = 0;
        private string originalXSpeed;
        private string originalYSpeed;
        private string saveDir = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "Recordings";
        private bool compressRecordings;

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

        public static int PlacingObject
        {
            get
            {
                return placingObject;
            }

            set
            {
                placingObject = value;
            }
        }

        public FormMain()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            comboBoxShape.SelectedItem = "Planet";
            gradientPanelObjectProperties.Visible = false;
            gradientPanelAdjustValues.Visible = false;
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
                displayXNA.GravitySystem.PreCalculationIncreaseFactor = Convert.ToInt32(key.GetValue("PreCalculationIncreaseFactor", 10));
                saveDir = (key.GetValue("SaveDir")==null? "" : key.GetValue("SaveDir").ToString());
                if (saveDir.Length==0)
                {
                    saveDir = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "Recordings";
                    System.IO.Directory.CreateDirectory(saveDir);       // create if not exists
                }
                displayXNA.setBackground(Convert.ToInt32(key.GetValue("Background", 2)));
                displayXNA.ShowAsDots = Convert.ToBoolean(key.GetValue("ShowAsDots", false));
                displayXNA.ShowNames = Convert.ToBoolean(key.GetValue("ShowNames", true));
                displayXNA.ShowScale = Convert.ToBoolean(key.GetValue("ShowScale", true));
                displayXNA.Reverse = Convert.ToBoolean(key.GetValue("Reverse", false));
                displayXNA.ShowTrailsAll = Convert.ToBoolean(key.GetValue("AllTrails", true));
                displayXNA.ShowVectorsAll = Convert.ToBoolean(key.GetValue("AllVectors", false));
//                displayXNA.BlendState = ConvertToBlendState(key.GetValue("TextureMode").ToString());
                displayXNA.SmallDot.PixelSize = Convert.ToInt32(key.GetValue("CustomShapePixelSize", 5));
                displayXNA.SmallDot.Type = Convert.ToInt32(key.GetValue("CustomShapeType", 0));
                displayXNA.SmallDot.Alpha = Convert.ToInt32(key.GetValue("CustomShapeAlpha", 120));
                //                displayXNA.SmallDot.ColorCoding = Convert.ToInt32(key.GetValue("CustomShapeColorCoding"));
                displayXNA.SmallDot.RandomSize = Convert.ToBoolean(key.GetValue("CustomShapeRandomSize"));
                displayXNA.SmallDot.RandomColor = Convert.ToBoolean(key.GetValue("CustomShapeRandomColor"));
                displayXNA.GravitySystem.GravitationalConstant = Convert.ToInt64(key.GetValue("GravitationalConstant", 667408000000));
                displayXNA.Galaxy.TotalMass = Convert.ToInt64(key.GetValue("GalaxyMass", 12000));
                displayXNA.Galaxy.BlackHoleMass = Convert.ToInt64(key.GetValue("GalaxyBlackHoleMass", 4100000));
                displayXNA.Galaxy.CrossSection = Convert.ToInt32(key.GetValue("GalaxyCrossSection", 1700));
                displayXNA.Galaxy.HasBlackHole = Convert.ToBoolean(key.GetValue("GalaxyHasBlackHole", true));
                displayXNA.Galaxy.HasSpiral = Convert.ToBoolean(key.GetValue("GalaxySpiral", true));
                displayXNA.Galaxy.HasEllipse = Convert.ToBoolean(key.GetValue("GalaxyEllipse", true));
                displayXNA.Galaxy.NumberOfObjects = Convert.ToInt32(key.GetValue("GalaxyNumberOfObjects", 6000));
                displayXNA.Galaxy.RotateCCW = Convert.ToBoolean(key.GetValue("GalaxyRotateCCW", true));
                displayXNA.Galaxy.RotationPeriod = Convert.ToInt32(key.GetValue("GalaxyRotationPeriod", 360));
                displayXNA.Galaxy.VelocityIncreaseFactor = Convert.ToDouble(key.GetValue("GalaxyVelocityIncreaseFactor", 0.2));
                displayXNA.Galaxy.NumberOfArms = Convert.ToInt32(key.GetValue("GalaxySpiralArms", 2));
                displayXNA.Galaxy.ArmLength = Convert.ToDouble(key.GetValue("GalaxySpiralArmLength", 1.4));
                displayXNA.Galaxy.HasBar = Convert.ToBoolean(key.GetValue("GalaxyHasBar", true));
                displayXNA.Galaxy.EllipseRatio = Convert.ToDouble(key.GetValue("GalaxyEllipseRatio", 0.5));
                displayXNA.Galaxy.EllipseSizePercentage = Convert.ToInt32(key.GetValue("GalaxyEllipseSizePercentage", 50));
                displayXNA.Galaxy.EllipseObjectsPercentage = Convert.ToInt32(key.GetValue("GalaxyEllipseObjectsPercentage", 30));
                displayXNA.Galaxy.EllipseBlurriness = Convert.ToInt32(key.GetValue("GalaxyEllipseBlurriness", 50));
                displayXNA.Galaxy.SpiralBlurriness = Convert.ToInt32(key.GetValue("GalaxySpiralBlurriness", 50));
                displayXNA.Galaxy.BarPercentage = Convert.ToInt32(key.GetValue("GalaxyBarPercentage", 20));
                displayXNA.Galaxy.MassVariation = Convert.ToInt32(key.GetValue("GalaxyMassVariation", 20));
                displayXNA.Galaxy.AddSolarSystem = Convert.ToBoolean(key.GetValue("GalaxyAddSolarSystem", false));
                displayXNA.Galaxy.CalculateStableSpeed = Convert.ToBoolean(key.GetValue("GalaxyCalculateStableSpeed", false));
                displayXNA.Galaxy.XSpeed = Convert.ToDouble(key.GetValue("GalaxyXSpeed", 0));
                displayXNA.Galaxy.YSpeed = Convert.ToDouble(key.GetValue("GalaxyYSpeed", 0));
                displayXNA.GravitySystem.QuadTree.Treshold = Convert.ToDouble(key.GetValue("BarnesHutTreshold", 0.5));
                displayXNA.GravitySystem.UseBarnesHut = Convert.ToBoolean(key.GetValue("UseBarnesHut", true));
                displayXNA.GravitySystem.MinimumTextureSize = Convert.ToInt32(key.GetValue("MinimumTextureSize", 11));
                displayXNA.GravitySystem.PrecalcAutoIncrease = Convert.ToBoolean(key.GetValue("PrecalcAutoIncrease", false));
                displayXNA.GravitySystem.AccelerationLimit = Convert.ToDouble(key.GetValue("AccelerationLimit", 0.0000000001));
                displayXNA.VideoCaptureCompression = key.GetValue("VideoCapturecompression", "none").ToString();
                displayXNA.VideoCaptureFPS = Convert.ToInt32(key.GetValue("VideoCaptureFPS", 60));

                displayXNA.initSmallDot(displayXNA.SmallDot.PixelSize, Microsoft.Xna.Framework.Color.White);    // needs to be before any calls to getTextureByName()

                displayXNA.Grid.Mass = Convert.ToDouble(key.GetValue("GridMass", 20000));
                displayXNA.Grid.Rotations = Convert.ToDouble(key.GetValue("GridRotations", 0));
                displayXNA.Grid.Spacing = Convert.ToDouble(key.GetValue("GridSpacing", 50));
                displayXNA.Grid.SpacingUnits = key.GetValue("GridSpacingUnits", "pixels").ToString();
                displayXNA.Grid.Texture = DisplayXNA.getTextureByName(key.GetValue("GridTexture", "<Custom Shape>").ToString());
                displayXNA.Grid.XAmount = Convert.ToDouble(key.GetValue("GridXAmount", 20));
                displayXNA.Grid.YAmount = Convert.ToDouble(key.GetValue("GridYAmount", 20));
                displayXNA.Grid.XSpeed = Convert.ToDouble(key.GetValue("GridXSpeed", 0));
                displayXNA.Grid.YSpeed = Convert.ToDouble(key.GetValue("GridYSpeed", 0));

                displayXNA.Circle.Mass = Convert.ToDouble(key.GetValue("CircleMass", 20000));
                displayXNA.Circle.Rotations = Convert.ToDouble(key.GetValue("CircleRotations", 0));
                displayXNA.Circle.Spacing = Convert.ToDouble(key.GetValue("CircleSpacing", 50));
                displayXNA.Circle.SpacingUnits = key.GetValue("CircleSpacingUnits", "pixels").ToString();
                displayXNA.Circle.Texture = DisplayXNA.getTextureByName(key.GetValue("CircleTexture", "<Custom Shape>").ToString());
                displayXNA.Circle.NumObjectsRadius = Convert.ToDouble(key.GetValue("CircleNumberOfObjectsRadius", 20));
                displayXNA.Circle.XSpeed = Convert.ToDouble(key.GetValue("CircleXSpeed", 0));
                displayXNA.Circle.YSpeed = Convert.ToDouble(key.GetValue("CircleYSpeed", 0));

                displayXNA.RandomObjects.Mass = Convert.ToInt64(key.GetValue("RandomMass", 5000000));
                displayXNA.RandomObjects.NumberOfObjects = Convert.ToInt32(key.GetValue("RandomNumberOfObjects", 200));
                displayXNA.RandomObjects.Texture = DisplayXNA.getTextureByName(key.GetValue("RandomTexture", "<Custom Shape>").ToString());
                displayXNA.RandomObjects.Area = Convert.ToUInt64(key.GetValue("RandomArea", 1000));
                displayXNA.RandomObjects.AreaUnits = key.GetValue("RandomAreaUnits", "pixels").ToString();
                displayXNA.RandomObjects.Speed = Convert.ToInt32(key.GetValue("RandomSpeed", 0));
                displayXNA.RandomObjects.SpeedRandomness = Convert.ToInt32(key.GetValue("RandomSpeedRandomness", 0));

                SetControls();
            }
            else     // default values
            {
                ResetToDefaults();
                displayXNA.initSmallDot(displayXNA.SmallDot.PixelSize, Microsoft.Xna.Framework.Color.White);
            }
        }

        private void SaveSettings()
        {
            // Create or get existing subkey
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Peter Popma\\GravityOne");

            key.SetValue("FrameRate", DisplayXNA.GravitySystem.TargetFrameRate);
            key.SetValue("PrecalcTime", DisplayXNA.GravitySystem.PreCalculationTime);
            key.SetValue("PreCalculationIncreaseFactor", DisplayXNA.GravitySystem.PreCalculationIncreaseFactor);
            key.SetValue("SaveDir", SaveDir);
            key.SetValue("CompressRecordings", compressRecordings);
            key.SetValue("Background", DisplayXNA.BackgroundIndex);
            key.SetValue("ShowNames", DisplayXNA.ShowNames);
            key.SetValue("ShowScale", DisplayXNA.ShowScale);
            key.SetValue("ShowAsDots", DisplayXNA.ShowAsDots);
            key.SetValue("Reverse", DisplayXNA.Reverse);
            key.SetValue("AllTrails", checkBoxTraceAll.Checked);
            key.SetValue("AllVectors", checkBoxVectorsAll.Checked);
// not saved            key.SetValue("TextureMode", displayXNA.BlendState.ToString());
            key.SetValue("CustomShapePixelSize", DisplayXNA.SmallDot.PixelSize);
            key.SetValue("CustomShapeType", DisplayXNA.SmallDot.Type);
            key.SetValue("CustomShapeAlpha", DisplayXNA.SmallDot.Alpha);
// not saved            key.SetValue("CustomShapeColorCoding", DisplayXNA.SmallDot.ColorCoding);
            key.SetValue("CustomShapeRandomSize", DisplayXNA.SmallDot.RandomSize);
            key.SetValue("CustomShapeRandomColor", DisplayXNA.SmallDot.RandomColor);
            key.SetValue("GravitationalConstant", DisplayXNA.GravitySystem.GravitationalConstant);
            key.SetValue("GalaxyMass", DisplayXNA.Galaxy.TotalMass);
            key.SetValue("GalaxyBlackHoleMass", DisplayXNA.Galaxy.BlackHoleMass);
            key.SetValue("GalaxyCrossSection", DisplayXNA.Galaxy.CrossSection);
            key.SetValue("GalaxyHasBlackHole", DisplayXNA.Galaxy.HasBlackHole);
            key.SetValue("GalaxySpiral", DisplayXNA.Galaxy.HasSpiral);
            key.SetValue("GalaxyEllipse", DisplayXNA.Galaxy.HasEllipse);
            key.SetValue("GalaxyNumberOfObjects", DisplayXNA.Galaxy.NumberOfObjects);
            key.SetValue("GalaxyRotateCCW", DisplayXNA.Galaxy.RotateCCW);
            key.SetValue("GalaxyRotationPeriod", DisplayXNA.Galaxy.RotationPeriod);
            key.SetValue("GalaxyVelocityIncreaseFactor", Convert.ToDecimal(DisplayXNA.Galaxy.VelocityIncreaseFactor));
            key.SetValue("GalaxySpiralArms", DisplayXNA.Galaxy.NumberOfArms);
            key.SetValue("GalaxySpiralArmLength", DisplayXNA.Galaxy.ArmLength);
            key.SetValue("GalaxyHasBar", DisplayXNA.Galaxy.HasBar);
            key.SetValue("GalaxyEllipseRatio", DisplayXNA.Galaxy.EllipseRatio);
            key.SetValue("GalaxyEllipseSizePercentage", DisplayXNA.Galaxy.EllipseSizePercentage);
            key.SetValue("GalaxyEllipseObjectsPercentage", DisplayXNA.Galaxy.EllipseObjectsPercentage);
            key.SetValue("GalaxyBarPercentage", DisplayXNA.Galaxy.BarPercentage);
            key.SetValue("GalaxyEllipseBlurriness", DisplayXNA.Galaxy.EllipseBlurriness);
            key.SetValue("GalaxySpiralBlurriness", DisplayXNA.Galaxy.SpiralBlurriness);
            key.SetValue("GalaxyMassVariation", DisplayXNA.Galaxy.MassVariation);
            key.SetValue("GalaxyAddSolarSystem", DisplayXNA.Galaxy.AddSolarSystem);
            key.SetValue("GalaxyCalculateStableSpeed", displayXNA.Galaxy.CalculateStableSpeed);
            key.SetValue("GalaxyXSpeed", displayXNA.Galaxy.XSpeed);
            key.SetValue("GalaxyYSpeed", displayXNA.Galaxy.YSpeed);
            key.SetValue("BarnesHutTreshold", displayXNA.GravitySystem.QuadTree.Treshold);
            key.SetValue("UseBarnesHut", displayXNA.GravitySystem.UseBarnesHut);
            key.SetValue("MinimumTextureSize", displayXNA.GravitySystem.MinimumTextureSize);
            key.SetValue("PrecalcAutoIncrease", displayXNA.GravitySystem.PrecalcAutoIncrease);
            key.SetValue("AccelerationLimit", displayXNA.GravitySystem.AccelerationLimit);
            key.SetValue("VideoCaptureCompression", displayXNA.VideoCaptureCompression);
            key.SetValue("VideoCaptureFPS", displayXNA.VideoCaptureFPS);
            key.SetValue("GridMass", displayXNA.Grid.Mass);
            key.SetValue("GridRotations", displayXNA.Grid.Rotations);
            key.SetValue("GridSpacing", displayXNA.Grid.Spacing);
            key.SetValue("GridSpacingUnits", displayXNA.Grid.SpacingUnits);
            key.SetValue("GridTexture", displayXNA.Grid.Texture.Name);
            key.SetValue("GridXAmount", displayXNA.Grid.XAmount);
            key.SetValue("GridYAmount", displayXNA.Grid.YAmount);
            key.SetValue("GridXSpeed", displayXNA.Grid.XSpeed);
            key.SetValue("GridYSpeed", displayXNA.Grid.YSpeed);
            key.SetValue("CircleMass", displayXNA.Circle.Mass);
            key.SetValue("CircleRotations", displayXNA.Circle.Rotations);
            key.SetValue("CircleSpacing", displayXNA.Circle.Spacing);
            key.SetValue("CircleSpacingUnits", displayXNA.Circle.SpacingUnits);
            key.SetValue("CircleTexture", displayXNA.Circle.Texture.Name);
            key.SetValue("CircleNumberOfObjectsRadius", displayXNA.Circle.NumObjectsRadius);
            key.SetValue("CircleXSpeed", displayXNA.Circle.XSpeed);
            key.SetValue("CircleYSpeed", displayXNA.Circle.YSpeed);
            key.SetValue("RandomMass", displayXNA.RandomObjects.Mass);
            key.SetValue("RandomNumberOfObjects", displayXNA.RandomObjects.NumberOfObjects);
            key.SetValue("RandomTexture", displayXNA.RandomObjects.Texture.Name);
            key.SetValue("RandomArea", displayXNA.RandomObjects.Area);
            key.SetValue("RandomAreaUnits", displayXNA.RandomObjects.AreaUnits);
            key.SetValue("RandomSpeed", displayXNA.RandomObjects.Speed);
            key.SetValue("RandomSpeedRandomness", displayXNA.RandomObjects.SpeedRandomness);
            displayXNA.RandomObjects.Area = Convert.ToUInt64(key.GetValue("RandomArea", 1000));
            displayXNA.RandomObjects.AreaUnits = key.GetValue("RandomAreaUnits", "pixels").ToString();
            displayXNA.RandomObjects.Speed = Convert.ToInt32(key.GetValue("RandomSpeed", 0));
            displayXNA.RandomObjects.SpeedRandomness = Convert.ToInt32(key.GetValue("RandomSpeedRandomness", 0));

        }

        public void SetControls()
        {
            checkBoxShowNames.Checked = displayXNA.ShowNames;
            checkBoxReverse.Checked = displayXNA.Reverse;
            checkBoxTraceAll.Checked = displayXNA.ShowTrailsAll;
            checkBoxVectorsAll.Checked = displayXNA.ShowVectorsAll;
        }

        public void PresetToLargeStableGalaxy()
        {
            comboBoxUnits.SelectedIndex = comboBoxUnits.FindStringExact("100.000 years");
            displayXNA.Galaxy.TotalMass = 1200000000;       // 0.8–1.5×10^12 for Milky Way
            displayXNA.Galaxy.BlackHoleMass = 4100000;
            displayXNA.Galaxy.CrossSection = 1700000000;
            displayXNA.Galaxy.HasBlackHole = true;
            displayXNA.Galaxy.HasSpiral = true;
            displayXNA.Galaxy.HasEllipse = true;
            displayXNA.Galaxy.NumberOfObjects = 10000;
            displayXNA.Galaxy.RotateCCW = true;
            displayXNA.Galaxy.RotationPeriod = 10000000;
            displayXNA.Galaxy.VelocityIncreaseFactor = 0.1;
            displayXNA.Galaxy.EllipseRatio = 0.5;
            displayXNA.Galaxy.EllipseSizePercentage = 50;
            displayXNA.Galaxy.EllipseObjectsPercentage = 30;
            displayXNA.Galaxy.NumberOfArms = 2;
            displayXNA.Galaxy.ArmLength = 1.1;
            displayXNA.Galaxy.HasBar = true;
            displayXNA.Galaxy.BarPercentage = 20;
            displayXNA.Galaxy.EllipseBlurriness = 50;
            displayXNA.Galaxy.SpiralBlurriness = 50;
            displayXNA.Galaxy.MassVariation = 40;
            displayXNA.Galaxy.AddSolarSystem = false;
            displayXNA.Galaxy.CalculateStableSpeed = false;
            displayXNA.Galaxy.XSpeed = 0;
            displayXNA.Galaxy.YSpeed = 0;
        }

        public void PresetToMilkyWay()
        {
            comboBoxUnits.SelectedIndex = comboBoxUnits.FindStringExact("100.000 years");
            displayXNA.Galaxy.TotalMass = 1200000000;       // 0.8–1.5×10^12 for Milky Way
            displayXNA.Galaxy.BlackHoleMass = 4100000;
            displayXNA.Galaxy.CrossSection = 1700000000;
            displayXNA.Galaxy.HasBlackHole = true;
            displayXNA.Galaxy.HasSpiral = true;
            displayXNA.Galaxy.HasEllipse = true;
            displayXNA.Galaxy.NumberOfObjects = 10000;
            displayXNA.Galaxy.RotateCCW = true;
            displayXNA.Galaxy.RotationPeriod = 360000000;
            displayXNA.Galaxy.VelocityIncreaseFactor = 0.2;
            displayXNA.Galaxy.EllipseRatio = 0.5;
            displayXNA.Galaxy.EllipseSizePercentage = 50;
            displayXNA.Galaxy.EllipseObjectsPercentage = 30;
            displayXNA.Galaxy.NumberOfArms = 2;
            displayXNA.Galaxy.ArmLength = 1.1;
            displayXNA.Galaxy.HasBar = true;
            displayXNA.Galaxy.BarPercentage = 20;
            displayXNA.Galaxy.EllipseBlurriness = 50;
            displayXNA.Galaxy.SpiralBlurriness = 50;
            displayXNA.Galaxy.MassVariation = 40;
            displayXNA.Galaxy.AddSolarSystem = false;
            displayXNA.Galaxy.CalculateStableSpeed = false;
            displayXNA.Galaxy.XSpeed = 0;
            displayXNA.Galaxy.YSpeed = 0;
        }

        public void PresetToSmallGalaxy()
        {
            comboBoxUnits.SelectedIndex = comboBoxUnits.FindStringExact("Decades");
            displayXNA.Galaxy.NumberOfObjects = 5000;        // 1 star actually represents 40000000 stars
            displayXNA.Galaxy.TotalMass = 30;                // 1200000000/40000000
            displayXNA.Galaxy.BlackHoleMass = 4100000;
            displayXNA.Galaxy.CrossSection = 42;             // 1700000000/40000000
            displayXNA.Galaxy.HasBlackHole = false;
            displayXNA.Galaxy.HasSpiral = true;
            displayXNA.Galaxy.HasEllipse = false;
            displayXNA.Galaxy.RotateCCW = true;
            displayXNA.Galaxy.RotationPeriod = 3600;
            displayXNA.Galaxy.VelocityIncreaseFactor = 0;
            displayXNA.Galaxy.EllipseRatio = 0.5;
            displayXNA.Galaxy.EllipseSizePercentage = 50;
            displayXNA.Galaxy.EllipseObjectsPercentage = 30;
            displayXNA.Galaxy.NumberOfArms = 2;
            displayXNA.Galaxy.ArmLength = 1.1;
            displayXNA.Galaxy.HasBar = true;
            displayXNA.Galaxy.BarPercentage = 20;
            displayXNA.Galaxy.EllipseBlurriness = 50;
            displayXNA.Galaxy.SpiralBlurriness = 30;
            displayXNA.Galaxy.MassVariation = 20;
            displayXNA.Galaxy.AddSolarSystem = false;
            displayXNA.Galaxy.CalculateStableSpeed = false;
            displayXNA.Galaxy.XSpeed = 0;
            displayXNA.Galaxy.YSpeed = 0;
        }

        public void PresetToEllipse()
        {
            comboBoxUnits.SelectedIndex = comboBoxUnits.FindStringExact("Millennia");
            displayXNA.Galaxy.CrossSection = 42000;
            displayXNA.Galaxy.NumberOfObjects = 10000;       
            displayXNA.Galaxy.TotalMass = 6000000;             
            displayXNA.Galaxy.BlackHoleMass = 4100000;
            displayXNA.Galaxy.RotationPeriod = 100000;
            displayXNA.Galaxy.HasBlackHole = false;
            displayXNA.Galaxy.HasSpiral = false;
            displayXNA.Galaxy.HasEllipse = true;
            displayXNA.Galaxy.RotateCCW = true;
            displayXNA.Galaxy.VelocityIncreaseFactor = 0.2;
            displayXNA.Galaxy.EllipseRatio = 0.5;
            displayXNA.Galaxy.EllipseSizePercentage = 50;
            displayXNA.Galaxy.EllipseObjectsPercentage = 30;
            displayXNA.Galaxy.NumberOfArms = 2;
            displayXNA.Galaxy.ArmLength = 1.1;
            displayXNA.Galaxy.HasBar = true;
            displayXNA.Galaxy.BarPercentage = 20;
            displayXNA.Galaxy.EllipseBlurriness = 50;
            displayXNA.Galaxy.SpiralBlurriness = 30;
            displayXNA.Galaxy.MassVariation = 20;
            displayXNA.Galaxy.AddSolarSystem = false;
            displayXNA.Galaxy.CalculateStableSpeed = false;
            displayXNA.Galaxy.XSpeed = 0;
            displayXNA.Galaxy.YSpeed = 0;
        }
        public void PresetToSpiral()
        {
            comboBoxUnits.SelectedIndex = comboBoxUnits.FindStringExact("Millennia");
            displayXNA.Galaxy.CrossSection = 3000000;
            displayXNA.Galaxy.NumberOfObjects = 10000;
            displayXNA.Galaxy.TotalMass = 1500000000;
            displayXNA.Galaxy.BlackHoleMass = 4100000;
            displayXNA.Galaxy.RotationPeriod = 400000;
            displayXNA.Galaxy.HasBlackHole = true;
            displayXNA.Galaxy.HasSpiral = true;
            displayXNA.Galaxy.HasEllipse = true;
            displayXNA.Galaxy.RotateCCW = true;
            displayXNA.Galaxy.VelocityIncreaseFactor = 0.0;
            displayXNA.Galaxy.EllipseRatio = 0.5;
            displayXNA.Galaxy.EllipseSizePercentage = 50;
            displayXNA.Galaxy.EllipseObjectsPercentage = 30;
            displayXNA.Galaxy.NumberOfArms = 2;
            displayXNA.Galaxy.ArmLength = 1.4;
            displayXNA.Galaxy.HasBar = true;
            displayXNA.Galaxy.BarPercentage = 20;
            displayXNA.Galaxy.EllipseBlurriness = 50;
            displayXNA.Galaxy.SpiralBlurriness = 30;
            displayXNA.Galaxy.MassVariation = 20;
            displayXNA.Galaxy.AddSolarSystem = false;
            displayXNA.Galaxy.CalculateStableSpeed = false;
            displayXNA.Galaxy.XSpeed = 0;
            displayXNA.Galaxy.YSpeed = 0;
        }
        public void PresetToSmallEllipse()
        {
            comboBoxUnits.SelectedIndex = comboBoxUnits.FindStringExact("Millennia");
            displayXNA.Galaxy.CrossSection = 500000;
            displayXNA.Galaxy.NumberOfObjects = 1500;
            displayXNA.Galaxy.TotalMass = 80000000;
            displayXNA.Galaxy.BlackHoleMass = 4100000;
            displayXNA.Galaxy.RotationPeriod = 200000;
            displayXNA.Galaxy.HasBlackHole = false;
            displayXNA.Galaxy.HasSpiral = false;
            displayXNA.Galaxy.HasEllipse = true;
            displayXNA.Galaxy.RotateCCW = true;
            displayXNA.Galaxy.VelocityIncreaseFactor = 0.0;
            displayXNA.Galaxy.EllipseRatio = 0.5;
            displayXNA.Galaxy.EllipseSizePercentage = 50;
            displayXNA.Galaxy.EllipseObjectsPercentage = 30;
            displayXNA.Galaxy.NumberOfArms = 2;
            displayXNA.Galaxy.ArmLength = 1.1;
            displayXNA.Galaxy.HasBar = true;
            displayXNA.Galaxy.BarPercentage = 20;
            displayXNA.Galaxy.EllipseBlurriness = 30;
            displayXNA.Galaxy.SpiralBlurriness = 30;
            displayXNA.Galaxy.MassVariation = 20;
            displayXNA.Galaxy.AddSolarSystem = false;
            displayXNA.Galaxy.CalculateStableSpeed = false;
            displayXNA.Galaxy.XSpeed = 0;
            displayXNA.Galaxy.YSpeed = 0;
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
            displayXNA.GravitySystem.PreCalculationIncreaseFactor = 10;
            displayXNA.setBackground(2);
            displayXNA.ShowAsDots = false;
            displayXNA.ShowNames = true;
            displayXNA.ShowScale = true;
            displayXNA.SetAllTraces(true);
            displayXNA.SetAllVectors(false);
            displayXNA.setReverse(false);
            displayXNA.BlendState = BlendState.AlphaBlend;
            displayXNA.SmallDot.PixelSize = 3;
            displayXNA.SmallDot.Alpha = 120;
            displayXNA.SmallDot.Type = 1;
            displayXNA.SmallDot.ColorCoding = 0;
            displayXNA.SmallDot.RandomSize = true;
            displayXNA.SmallDot.RandomColor = false;
            displayXNA.GravitySystem.GravitationalConstant = 667408000000;
            displayXNA.GravitySystem.UseBarnesHut = true;
            displayXNA.GravitySystem.QuadTree.Treshold = 0.5;
            displayXNA.GravitySystem.MinimumTextureSize = 11;
            displayXNA.GravitySystem.PrecalcAutoIncrease = false;
            displayXNA.GravitySystem.AccelerationLimit = 0.0000000001;
            displayXNA.VideoCaptureCompression = "(none)";
            displayXNA.VideoCaptureFPS= 60;
            displayXNA.Grid.Mass = 20000;
            displayXNA.Grid.Rotations = 0;
            displayXNA.Grid.Spacing = 50;
            displayXNA.Grid.SpacingUnits = "pixels";
            displayXNA.Grid.Texture = DisplayXNA.getTextureByName("<Custom Shape>");
            displayXNA.Grid.XAmount = 20;
            displayXNA.Grid.YAmount = 20;
            displayXNA.Grid.XSpeed = 0;
            displayXNA.Grid.YSpeed = 0;
            displayXNA.Circle.Mass = 20000;
            displayXNA.Circle.Rotations = 0;
            displayXNA.Circle.Spacing = 50;
            displayXNA.Circle.SpacingUnits = "pixels";
            displayXNA.Circle.Texture = DisplayXNA.getTextureByName("<Custom Shape>");
            displayXNA.Circle.NumObjectsRadius = 20;
            displayXNA.Circle.XSpeed = 0;
            displayXNA.Circle.YSpeed = 0;
            displayXNA.RandomObjects.Mass = 5000000;
            displayXNA.RandomObjects.NumberOfObjects = 200;
            displayXNA.RandomObjects.Texture = DisplayXNA.getTextureByName("<Custom Shape>");
            displayXNA.RandomObjects.Area = 1000;
            displayXNA.RandomObjects.AreaUnits = "pixels";
            displayXNA.RandomObjects.Speed = 0;
            displayXNA.RandomObjects.SpeedRandomness = 0;

            PresetToMilkyWay();
        }

        private void SetupTimers()
        {
            // Create a timer with a 10 msec interval.
            updateScreenTimer = new System.Windows.Forms.Timer();
            updateScreenTimer.Interval = 10;
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
            if(IntervalCounter%Interval==0)
            {
//                IntervalCounter = 0;
                displayXNA.UpdateFrame();
            }
            displayXNA.UpdateScreen();
            if (IntervalCounter%10==0)
            {
                UpdateObjectValues();
            }

        }

        private void OnTimedEventPan(Object source, System.Timers.ElapsedEventArgs e)
        {
            switch(PanDirection)
            {
                case 0:
                    displayXNA.GravitySystem.OffsetY -= 10;
                    break;
                case 1:
                    displayXNA.GravitySystem.OffsetX += 10;
                    break;
                case 2:
                    displayXNA.GravitySystem.OffsetY += 10;
                    break;
                case 3:
                    displayXNA.GravitySystem.OffsetX -= 10;
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

        private void PlaceSolarSystem(double x, double y, bool addJWST=false)
        {
            displayXNA.CreateSolarSystem(x, y, addJWST);

            if (gradientPanelObjectProperties.Visible == false)    // display properties panel
            {
                gradientButtonToggleObject.Active = true;
                gradientPanelObjectProperties.Visible = true;
            }
        }

        private void PlaceSolarSystemMoons(double x, double y, bool addJWST = false)
        {
            displayXNA.CreateSolarSystemMoons(x, y);

            if (gradientPanelObjectProperties.Visible == false)    // display properties panel
            {
                gradientButtonToggleObject.Active = true;
                gradientPanelObjectProperties.Visible = true;
            }
        }

        private void displayXNA_Click(object sender, MouseEventArgs e)
        {
            if (PlacingObject == 16)       // pick object
            {
                gradientButtonPick.ForeColor = Color.Black;
                displayXNA.GravitySystem.SelectObjectAtMousePointer(e.X, e.Y);
                PlacingObject = 0;
                Cursor = Cursors.Arrow;
                labelClickMessage.Visible = false;
                UpdateObjectProperties();
                Refresh();
                return;
            }

            // temp disable calculations so that there are no out of range exceptions (and galaxies can be placed faster)
            bool wasCalculating = displayXNA.GravitySystem.IsCalculating;
            displayXNA.GravitySystem.StopCalculation();

            if (gradientPanelObjectProperties.Visible == false)    // display properties panel
            {
                gradientButtonToggleObject.Active = true;
                gradientPanelObjectProperties.Visible = true;
            }
            if (PlacingObject > 0)
            {
                if (PlacingObject == 1)
                {
                    gradientButtonPlanetSystems.ForeColor = Color.Black;
                    displayXNA.CreatePlanetMoon(e.X, e.Y);
                }
                else if (PlacingObject == 2)
                {
                    gradientButtonSolarSystem.ForeColor = Color.Black;
                    PlaceSolarSystem(e.X, e.Y);
                }
                else if (PlacingObject == 3)
                {
                    gradientButtonPlanetSystems.ForeColor = Color.Black;
                    displayXNA.CreateSunPlanetMoon(e.X, e.Y);
                }
                else if (PlacingObject == 4)
                {
                    gradientButtonPlanetSystems.ForeColor = Color.Black;
                    displayXNA.CreateSunPlanet(e.X, e.Y);
                }
                else if (PlacingObject == 5)
                {
                    gradientButtonSlingshot.ForeColor = Color.Black;
                    displayXNA.CreateSlingShot(e.X, e.Y);
                }
                else if (PlacingObject == 6)
                {
                    gradientButtonPlanetSystems.ForeColor = Color.Black;
                    displayXNA.CreateMoonMoon(e.X, e.Y);
                }
                else if (PlacingObject == 7)
                {
                    gradientButtonBinary.ForeColor = Color.Black;
                    displayXNA.CreateDualStar(e.X, e.Y);
                }
                else if (PlacingObject == 8)
                {
                    gradientButtonBinary.ForeColor = Color.Black;
                    displayXNA.CreateDualStar2(e.X, e.Y);
                }
                else if (PlacingObject == 9)
                {
                    gradientButtonRandom.ForeColor = Color.Black;
                    displayXNA.CreateRandom(e.X, e.Y);
                }
                else if (PlacingObject == 10)
                {
                    gradientButtonGrid.ForeColor = Color.Black;
                    displayXNA.CreateGrid(e.X, e.Y);
                }
                else if (PlacingObject == 11)
                {
                    gradientButtonBinary.ForeColor = Color.Black;
                    displayXNA.CreateDualStar3(e.X, e.Y);
                }
                else if (PlacingObject == 12)
                {
                    gradientButtonBinary.ForeColor = Color.Black;
                    displayXNA.CreateTripleStar(e.X, e.Y);
                }
                else if (PlacingObject == 13)
                {
                    gradientButtonPlanetSystems.ForeColor = Color.Black;
                    PlaceSolarSystemMoons(e.X, e.Y);
                }
                else if (PlacingObject == 14)
                {
                    gradientButtonGalaxy.ForeColor = Color.Black;
                    displayXNA.CreateGalaxy(e.X, e.Y);
                    gradientButtonToggleObject.Active = false;
                    if (!displayXNA.Galaxy.AddSolarSystem)
                    {
                        gradientPanelObjectProperties.Visible = false;
                    }
                }
                else if (PlacingObject == 15)
                {
                    gradientButtonCircle.ForeColor = Color.Black;
                    displayXNA.CreateCircle(e.X, e.Y);
                }

                PlacingObject = 0;
                Cursor = Cursors.Arrow;
                labelClickMessage.Visible = false;
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
                displayXNA.AddGravityObject(e.X, e.Y, checkBoxCircleHost.Checked, checkBoxCircleCCW.Checked);
                displayXNA.GravitySystem.ObjectIndex = displayXNA.GravitySystem.GravityObjects.Count - 1;
                // create new unique name for next object
                textBoxName.Text = displayXNA.FindFreeName("Object");
            }
            labelNumberObjects.Text = displayXNA.GravitySystem.GravityObjects.Count.ToString();
            UpdateObjectProperties();
            Refresh();

            if (wasCalculating || displayXNA.GravitySystem.CalculationsPerStepPrecalculated>1 || comboBoxCalcsUnit.SelectedItem.ToString().Equals("Pre-Calculate"))
            {
                displayXNA.GravitySystem.InitCalculation();
                displayXNA.GravitySystem.StartCalculation();
            }
        }

        private void gradientButtonReady_Click(object sender, EventArgs e)
        {
            if (!originalXSpeed.Equals(textBoxAdjustXSpeed.Text))       // only change speed if values were modified
            {
                displayXNA.GravitySystem.CurrentObject().XSpeed = Convert.ToDouble(textBoxAdjustXSpeed.Text);
            }
            if (!originalXSpeed.Equals(textBoxAdjustXSpeed.Text))       // only change speed if values were modified
            {
                displayXNA.GravitySystem.CurrentObject().YSpeed = Convert.ToDouble(textBoxAdjustYSpeed.Text);
            }
            displayXNA.GravitySystem.CurrentObject().Mass = Convert.ToDouble(textBoxAdjustMass.Text);
            displayXNA.GravitySystem.CurrentObject().Name = textBoxAdjustName.Text;
            checkBoxAdjustTrace.Checked = displayXNA.GravitySystem.CurrentObject().Trace;
            checkBoxAdjustVector.Checked = displayXNA.GravitySystem.CurrentObject().Vector;
            UpdateObjectProperties();
            displayXNA.GravitySystem.ResetCalculations();
        }

        private void gradientButtonAdjustValues_Click(object sender, EventArgs e)
        {
            if (gradientButtonAdjustValues.Active)
            {
                gradientPanelAdjustValues.Visible = false;
                gradientButtonAdjustValues.Active = false;
            }
            else
            {
                UpdateAdjustValues();
                gradientPanelAdjustValues.Visible = true;
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
            textBoxName.Text = displayXNA.FindFreeName("Planet");
            comboBoxShape.Text = "Planet";
        }

        private void gradientButtonEarth_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "597.2";
            textBoxName.Text = displayXNA.FindFreeName("Earth");
            comboBoxShape.Text = "Earth";
        }

        private void gradientButtonSun_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "198900000";
            textBoxName.Text = displayXNA.FindFreeName("Sun");
            comboBoxShape.Text = "Sun";
        }

        private void gradientButtonMoon_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "7.342";
            textBoxName.Text = displayXNA.FindFreeName("Moon");
            comboBoxShape.Text = "Moon";
        }

        private void gradientButtonMercury_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "32.85";
            textBoxName.Text = displayXNA.FindFreeName("Mercury");
            comboBoxShape.Text = "Mercury";
        }

        private void gradientButtonVenus_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "486.7";
            textBoxName.Text = displayXNA.FindFreeName("Venus");
            comboBoxShape.Text = "Venus";
        }

        private void gradientButtonMars_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "63.9";
            textBoxName.Text = displayXNA.FindFreeName("Mars");
            comboBoxShape.Text = "Mars";
        }

        private void gradientButtonSaturn_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "56830";
            textBoxName.Text = displayXNA.FindFreeName("Saturn");
            comboBoxShape.Text = "Saturn";
        }

        private void gradientButtonJupiter_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "189800";
            textBoxName.Text = displayXNA.FindFreeName("Jupiter");
            comboBoxShape.Text = "Jupiter";
        }

        private void gradientButtonUranus_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "8681";
            textBoxName.Text = displayXNA.FindFreeName("Uranus");
            comboBoxShape.Text = "Uranus";
        }

        private void gradientButtonNeptune_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "10240";
            textBoxName.Text = displayXNA.FindFreeName("Neptune");
            comboBoxShape.Text = "Neptune";
        }

        private void gradientButtonPluto_Click(object sender, EventArgs e)
        {
            textBoxMass.Text = "1.31";
            textBoxName.Text = displayXNA.FindFreeName("Pluto");
            comboBoxShape.Text = "Pluto";
        }

        public void UpdateObjectProperties()
        {
            if(displayXNA.GravitySystem.ObjectIndex==-1)        // nothing to display
            {
                gradientPanelObjectProperties.Visible = false;
                gradientButtonAdjustValues.Active = false;
                gradientPanelAdjustValues.Visible = false;
                gradientButtonToggleObject.Active = false;
                Refresh();
                return;
            }
            labelObjectNumber.Text = (displayXNA.GravitySystem.ObjectIndex + 1).ToString();
            labelNumberObjects.Text = displayXNA.GravitySystem.GravityObjects.Count.ToString();
            if (displayXNA.GravitySystem.GravityObjects.Count==0 || displayXNA.GravitySystem.ObjectIndex == -1)
            {
                // no objects!
                gradientPanelObjectProperties.Visible = false;
                gradientButtonAdjustValues.Active = false;
                gradientPanelAdjustValues.Visible = false;
                return;
            }
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
                labelDistanceToZero.Text = displayXNA.GravitySystem.DistanceCurrentObjectZeroObject().ToString("0.##");
            }
        }

        private void gradientButtonAdjustValues_Click_1(object sender, EventArgs e)
        {
            if (gradientButtonAdjustValues.Active)
            {
                gradientPanelAdjustValues.Visible = false;
                gradientButtonAdjustValues.Active = false;
            }
            else
            {
                gradientPanelAdjustValues.Visible = true;
                gradientButtonAdjustValues.Active = true;
            }
        }

        private void gradientButtonToggleObject_Click(object sender, EventArgs e)
        {
            if (gradientButtonToggleObject.Active)
            {
                gradientPanelObjectProperties.Visible = false;
                gradientButtonAdjustValues.Active = false;
                gradientPanelAdjustValues.Visible = false;
                gradientButtonToggleObject.Active = false;
            }
            else if (displayXNA.GravitySystem.GravityObjects.Count>0)
            {
                if (displayXNA.GravitySystem.ObjectIndex == -1)
                {
                    displayXNA.GravitySystem.ObjectIndex = 0;
                    UpdateObjectProperties();
                }
                gradientPanelObjectProperties.Visible = true;
                gradientButtonToggleObject.Active = true;
            }
        }

        private void gradientPanel28_Paint(object sender, PaintEventArgs e)
        {

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
            displayXNA.GravitySystem.GravityObjects.RemoveAt(displayXNA.GravitySystem.ObjectIndex);
            if (displayXNA.GravitySystem.ObjectIndex >= displayXNA.GravitySystem.GravityObjects.Count)     // removing last item
            {
                displayXNA.GravitySystem.ObjectIndex--;
            }
            UpdateObjectProperties();
            displayXNA.GravitySystem.ResetCalculations();
            displayXNA.GravitySystem.DetermineCalculationsPerStepActual();
        }

        private void macTrackBarSpeed_ValueChanged(object sender, decimal value)
        {
            if (value.Equals(0))
            {
                Interval = 200;
            }
            else if (value.Equals(1))
            {
                Interval = 100;
            }
            else if (value.Equals(2))
            {
                Interval = 50;
            }
            else if (value.Equals(3))
            {
                Interval = 20;
            }
            else if (value.Equals(4))
            {
                Interval = 10;
            }
            else if (value.Equals(5))
            {
                Interval = 5;
            }
            else if (value.Equals(6))
            {
                Interval = 1;
            }
        }

        private void gradientButtonStart_Click(object sender, EventArgs e)
        {
            if (displayXNA.SimulationRunning)
            {
                displayXNA.SimulationRunning = false;
                gradientButtonStart.Image = Resources.icon_play_32;
            } else
            {
                displayXNA.SimulationRunning = true;
                displayXNA.GravitySystem.ObtainMinMaxValues();
                gradientButtonStart.Image = Resources.icon_pause_32;
            }
        }

        private void comboBoxCalcsUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCalcsUnit.SelectedItem.ToString().Equals("Pre-Calculate"))
            {
                gradientButtonRewind.Visible = true;
                gradientButtonStep.Left = 134;
                gradientButtonCaptureVideo.Left = 179;
                gradientButtonStart.Left = 5;
                displayXNA.GravitySystem.CalculationsPerStepSetting = -2;
                if (!displayXNA.GravitySystem.IsCalculating && (displayXNA.GravitySystem.CalculationsPerStepPrecalculated == 1 || displayXNA.GravitySystem.PrecalcAutoIncrease))        // start up calculations
                {
                    displayXNA.GravitySystem.InitCalculation();
                    displayXNA.GravitySystem.StartCalculation();
                }
                else
                {
                    displayXNA.GravitySystem.StartCalculation();       // resume if paused
                }
            }
            else
            {
                displayXNA.GravitySystem.StopCalculation();    // Pause calculation if running
                gradientButtonRewind.Visible = false;
                gradientButtonStep.Left = 100;
                gradientButtonCaptureVideo.Left = 153;
                gradientButtonStart.Left = 17;
                if (comboBoxCalcsUnit.SelectedItem.ToString().Equals("Automatic"))
                {
                    displayXNA.GravitySystem.CalculationsPerStepSetting = -1;
                }
                else
                {
                    int value = Convert.ToInt32(comboBoxCalcsUnit.SelectedItem);
                    displayXNA.GravitySystem.CalculationsPerStepSetting = value;
                }
            }
            displayXNA.GravitySystem.DetermineCalculationsPerStepActual();      // adjust calculations per step that is displayed during simulation
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
            displayXNA.SimulationRunning = false;
            displayXNA.SimulationStepping = true;
        }


        private void gradientButtonSolarSystem_Click(object sender, EventArgs e)
        {
            if (PlacingObject == 0)
            {
                PlacingObject = 2;
                labelClickMessage.Visible = true;
                gradientButtonSolarSystem.ForeColor = Color.Coral;
                this.Cursor = Cursors.Hand;
                comboBoxUnits.SelectedItem = "Days";
            }
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
            FormSplashScreen sp = new FormSplashScreen();
            sp.ShowDialog();
            LoadSettings();
            displayXNA.GravitySystem.DetermineTimeNeedForOneCalculation(displayXNA.GraphicsDevice);     // needed for DetermineCalculationsPerStepActual() 
            displayXNA.GravitySystem.BackgroundWorkerPreCalculate = backgroundWorkerPreCalculate;
            comboBoxCalcsUnit.SelectedIndex = 0;        // 2000
            comboBoxUnits.SelectedItem = "Days";        // days
            PlaceSolarSystem(0, 0, true);
            UpdateObjectProperties();
            macTrackBarScale.Value = 295;        // scale for solar system view
        }

        private void gradientButtonNextObject_Click(object sender, EventArgs e)
        {
            displayXNA.GravitySystem.NextObject();
            UpdateObjectProperties();
            UpdateAdjustValues();
        }

        private void gradientButtonPreviousObject_Click(object sender, EventArgs e)
        {
            displayXNA.GravitySystem.PreviousObject();
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
            if (PlacingObject == 0)
            {
                PlacingObject = 5;
                gradientButtonSlingshot.ForeColor = Color.Coral;
                labelClickMessage.Visible = true;
                this.Cursor = Cursors.Hand;
                macTrackBarScale.Value = 294;
                comboBoxUnits.SelectedItem = "Days";
            }
        }

        private void gradientButtonDualStar_Click(object sender, EventArgs e)
        {
            if (PlacingObject == 0)
            {
                FormBinary frmBinary = new FormBinary();
                frmBinary.MyParent = this;
                frmBinary.ShowDialog();
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
            frmLoadSave.textBoxCalcsDone.Text = displayXNA.GravitySystem.FrameNumberCalc.ToString() + "/" + displayXNA.GravitySystem.NumPrecalculatedFrames().ToString() + " (" + displayXNA.GravitySystem.CalculationsPerStepPrecalculated.ToString() + ")";
            frmLoadSave.labelBusy.Text = "Saving..";
            frmLoadSave.panelBusy.Visible = false;
            frmLoadSave.EnumerateRecordings();
            frmLoadSave.ShowDialog();
        }

        private void gradientButtonRemoveAll_Click(object sender, EventArgs e)
        {
            bool wasRunning = displayXNA.SimulationRunning;
            displayXNA.SimulationRunning = false;
            bool wasCalculating = displayXNA.GravitySystem.IsCalculating;
            displayXNA.GravitySystem.StopCalculation();
            displayXNA.Rewind();
            displayXNA.GravitySystem.CenterIndex = -1;
            displayXNA.GravitySystem.GravityObjects.Clear();
            displayXNA.GravitySystem.DetermineCalculationsPerStepActual();
            displayXNA.GravitySystem.ObjectIndex = -1;
//            displayXNA.SimulationTime = new DateTime(2017, 1, 1, 0, 0, 0);
            labelNumberObjects.Text = displayXNA.GravitySystem.GravityObjects.Count.ToString();
            gradientPanelObjectProperties.Visible = false;
            gradientButtonToggleObject.Active = false;
            gradientButtonAdjustValues.Active = false;
            gradientPanelAdjustValues.Visible = false;
            if(wasRunning)
            {
                displayXNA.SimulationRunning = true;
            }
            displayXNA.GravitySystem.ResetCalculations(wasCalculating);
        }

        private void macTrackBarScale_ValueChanged(object sender, decimal value)
        {
            int scale = 401 - macTrackBarScale.Value;
            Scale(scale);
        }

        private void Scale(long scale)
        {
            // diameter milky way = 1.7 x 10^18 km = 1700 qdn. km -> 1 pixel = 1700 tln. km
            // at scale 1 one pixel = 1000 km 
            // so at scale 2000000000000 one pixel = 2000 tln. km

            // log(200000000000000) / log(400) = 5.496
            // at scale 400 power=5.496, at scale 1 power=1
            // so 5.496-1 / 399 = 0.01223
            //            scale = (long)Math.Pow(scale, scale * 0.01223145991950297188008550399077);
            scale = (long)Math.Pow(scale, scale * 0.0128);
            if (displayXNA.GravitySystem.CenterIndex == -1)
            {
                displayXNA.GravitySystem.AdjustOffsetToNewScale(scale);
            }
            displayXNA.GravitySystem.Scale = scale;
            displayXNA.GravitySystem.ScaleObjects();
        }

        private double FindInverseXToPower0_0128X(double x)
        {
            double lowerValue = 0, upperValue = 400;
            double testValue = 200;
            double testResult;
            do
            {
                testResult = Math.Pow(testValue, testValue * 0.0128);
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
            double inverse_scale = FindInverseXToPower0_0128X(metersPerPixel);

            return 401 - (int)inverse_scale;
        }

        private void comboBoxUnits_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (comboBoxUnits.SelectedItem.ToString())
            {
                case "Seconds":
                    displayXNA.TimeUnitsPerStep = 1;
                    break;
                case "Minutes":
                    displayXNA.TimeUnitsPerStep = 60;
                    break;
                case "2 Minutes":
                    displayXNA.TimeUnitsPerStep = 120;
                    break;
                case "Hours":
                    displayXNA.TimeUnitsPerStep = 3600;
                    break;
                case "2 Hours":
                    displayXNA.TimeUnitsPerStep = 7200;
                    break;
                case "8 Hours":
                    displayXNA.TimeUnitsPerStep = 28800;
                    break;
                case "Days":
                    displayXNA.TimeUnitsPerStep = 86400;
                    break;
                case "Weeks":
                    displayXNA.TimeUnitsPerStep = 604800;
                    break;
                case "Months":
                    displayXNA.TimeUnitsPerStep = 2629846;
                    break;
                case "Years":
                    displayXNA.TimeUnitsPerStep = 31558150;
                    break;
                case "Decades":
                    displayXNA.TimeUnitsPerStep = 315581500;
                    break;
                case "Centuries":
                    displayXNA.TimeUnitsPerStep = 3155815000;
                    break;
                case "Millennia":
                    displayXNA.TimeUnitsPerStep = 31558150000;
                    break;
                case "10 Millennia":
                    displayXNA.TimeUnitsPerStep = 315581500000;
                    break;
                case "100.000 Years":
                    displayXNA.TimeUnitsPerStep = 3155815000000;
                    break;
                case "1/2 Million Years":
                    displayXNA.TimeUnitsPerStep = 15779075000000;
                    break;
                case "Million Years":
                    displayXNA.TimeUnitsPerStep = 31558150000000;
                    break;
                case "2 Million Years":
                    displayXNA.TimeUnitsPerStep = 63116300000000;
                    break;
            }

            displayXNA.GravitySystem.CalculationSecondsPerFrame = displayXNA.TimeUnitsPerStep;
            displayXNA.GravitySystem.ResetCalculations();
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

        private void backgroundWorkerPreCalculate_DoWork(object sender, DoWorkEventArgs e)
        {
            try {
                displayXNA.GravitySystem.PreCalculate(backgroundWorkerPreCalculate, e);
            }
            catch(Exception er)
            {
                Console.WriteLine(er.Message);
            }
            displayXNA.GravitySystem.IsCalculating = false;
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
                PlacingObject = 16;
                gradientButtonPick.ForeColor = Color.Coral;
                labelClickMessage.Visible = true;
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
            }
        }

    }
}
