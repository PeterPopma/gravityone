using GravityOne.SpaceObjects;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GravityOne.Forms
{
    public partial class FormGalaxy : Form
    {
        private FormMain myParent = null;

        public FormMain MyParent
        {
            get
            {
                return myParent;
            }

            set
            {
                myParent = value;
            }
        }

        public FormGalaxy()
        {
            InitializeComponent();
        }

        private void gradientButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxBlackHole_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownBlackHoleMass.Enabled = checkBoxBlackHole.Checked;
        }

        public void Initialize()
        {
            numericUpDownMass.Value = myParent.DisplayXNA.PresetObjects.Galaxy.TotalMass;
            numericUpDownBlackHoleMass.Value = myParent.DisplayXNA.PresetObjects.Galaxy.BlackHoleMass;
            numericUpDownCrossSection.Value = myParent.DisplayXNA.PresetObjects.Galaxy.CrossSection;
            checkBoxBlackHole.Checked = myParent.DisplayXNA.PresetObjects.Galaxy.HasBlackHole;
            checkBoxSpiral.Checked = myParent.DisplayXNA.PresetObjects.Galaxy.HasSpiral;
            checkBoxElliptical.Checked = myParent.DisplayXNA.PresetObjects.Galaxy.HasEllipse;
            numericUpDownNumberOfObjects.Value = myParent.DisplayXNA.PresetObjects.Galaxy.NumberOfObjects;
            checkBoxCounterClockwise.Checked = myParent.DisplayXNA.PresetObjects.Galaxy.RotateCCW;
            numericUpDownRotationPeriod.Value = myParent.DisplayXNA.PresetObjects.Galaxy.RotationPeriod;
            numericUpDownVelocityIncreaseFactor.Value = Convert.ToDecimal(myParent.DisplayXNA.PresetObjects.Galaxy.VelocityIncreaseFactor);
            numericUpDownNumberOfArms.Value = myParent.DisplayXNA.PresetObjects.Galaxy.NumberOfArms;
            numericUpDownArmLength.Value = Convert.ToDecimal(myParent.DisplayXNA.PresetObjects.Galaxy.ArmLength);
            checkBoxBar.Checked = myParent.DisplayXNA.PresetObjects.Galaxy.HasBar;
            numericUpDownEllipseRatio.Value = Convert.ToDecimal(myParent.DisplayXNA.PresetObjects.Galaxy.EllipseRatio);
            numericUpDownEllipseSizePercentage.Value = myParent.DisplayXNA.PresetObjects.Galaxy.EllipseSizePercentage;
            numericUpDownEllipseObjectsPercentage.Value = myParent.DisplayXNA.PresetObjects.Galaxy.EllipseObjectsPercentage;
            numericUpDownBarPercentage.Value = myParent.DisplayXNA.PresetObjects.Galaxy.BarPercentage;
            numericUpDownEllipseBlurriness.Value = myParent.DisplayXNA.PresetObjects.Galaxy.EllipseBlurriness;
            numericUpDownSpiralBlurriness.Value = myParent.DisplayXNA.PresetObjects.Galaxy.SpiralBlurriness;
            numericUpDownMassVariation.Value = Convert.ToDecimal(myParent.DisplayXNA.PresetObjects.Galaxy.MassVariation);
            checkBoxAddSolarSystem.Checked = myParent.DisplayXNA.PresetObjects.Galaxy.AddSolarSystem;
            checkBoxCalculateStableSpeed.Checked = myParent.DisplayXNA.PresetObjects.Galaxy.CalculateStableSpeed;
            numericUpDownXSpeed.Value = Convert.ToDecimal(myParent.DisplayXNA.PresetObjects.Galaxy.XSpeed);
            numericUpDownYSpeed.Value = Convert.ToDecimal(myParent.DisplayXNA.PresetObjects.Galaxy.YSpeed);
            numericUpDownRotationPeriod.Enabled = numericUpDownVelocityIncreaseFactor.Enabled = !checkBoxCalculateStableSpeed.Checked;
            comboBoxColor.SelectedIndex = 0;

            UpdateBarControls();
        }

        private void gradientButtonCreate_Click(object sender, EventArgs e)
        {
            FormMain.PlacingObject = 14;
            myParent.labelClickMessage.Visible = true;
            myParent.gradientButtonGalaxy.ForeColor = Color.Coral;
            this.Cursor = Cursors.Hand;
/*            if (myParent.DisplayXNA.TimeUnitsPerStep < 315581500000)
            {
                myParent.comboBoxUnits.SelectedIndex = myParent.comboBoxUnits.FindStringExact("100.000 years");
            }*/
            myParent.DisplayXNA.BlendState = BlendState.Additive;
            myParent.checkBoxShowNames.Checked = false;
            myParent.checkBoxTraceAll.Checked = false;
//            if(numericUpDownNumberOfObjects.Value>=1000)
            {
                myParent.comboBoxCalcsUnit.SelectedItem = "Pre-Calculate";
            }
            //        myParent.DisplayXNA.BackgroundIndex = 0;
            myParent.DisplayXNA.PresetObjects.Galaxy.TotalMass = (long)numericUpDownMass.Value;
            myParent.DisplayXNA.PresetObjects.Galaxy.BlackHoleMass = (long)numericUpDownBlackHoleMass.Value;
            myParent.DisplayXNA.PresetObjects.Galaxy.CrossSection = (int)numericUpDownCrossSection.Value;
            myParent.DisplayXNA.PresetObjects.Galaxy.HasBlackHole = checkBoxBlackHole.Checked;
            myParent.DisplayXNA.PresetObjects.Galaxy.HasSpiral = checkBoxSpiral.Checked;
            myParent.DisplayXNA.PresetObjects.Galaxy.HasEllipse = checkBoxElliptical.Checked;
            myParent.DisplayXNA.PresetObjects.Galaxy.NumberOfObjects = (int)numericUpDownNumberOfObjects.Value;
            myParent.DisplayXNA.PresetObjects.Galaxy.RotateCCW = checkBoxCounterClockwise.Checked;
            myParent.DisplayXNA.PresetObjects.Galaxy.RotationPeriod = (int)numericUpDownRotationPeriod.Value;
            myParent.DisplayXNA.PresetObjects.Galaxy.VelocityIncreaseFactor = (double)numericUpDownVelocityIncreaseFactor.Value;
            myParent.DisplayXNA.PresetObjects.Galaxy.NumberOfArms = (int)numericUpDownNumberOfArms.Value;
            myParent.DisplayXNA.PresetObjects.Galaxy.ArmLength = (double)numericUpDownArmLength.Value;
            myParent.DisplayXNA.PresetObjects.Galaxy.BarPercentage = (int)numericUpDownBarPercentage.Value;
            myParent.DisplayXNA.PresetObjects.Galaxy.HasBar = checkBoxBar.Checked;
            myParent.DisplayXNA.PresetObjects.Galaxy.EllipseRatio = (double)numericUpDownEllipseRatio.Value;
            myParent.DisplayXNA.PresetObjects.Galaxy.EllipseSizePercentage = (int)numericUpDownEllipseSizePercentage.Value;
            myParent.DisplayXNA.PresetObjects.Galaxy.EllipseObjectsPercentage = (int)numericUpDownEllipseObjectsPercentage.Value;
            myParent.DisplayXNA.PresetObjects.Galaxy.EllipseBlurriness = (int)numericUpDownEllipseBlurriness.Value;
            myParent.DisplayXNA.PresetObjects.Galaxy.SpiralBlurriness = (int)numericUpDownSpiralBlurriness.Value;
            myParent.DisplayXNA.PresetObjects.Galaxy.MassVariation = (double)numericUpDownMassVariation.Value;
            myParent.DisplayXNA.PresetObjects.Galaxy.AddSolarSystem = checkBoxAddSolarSystem.Checked;
            myParent.DisplayXNA.PresetObjects.Galaxy.CalculateStableSpeed = checkBoxCalculateStableSpeed.Checked;
            myParent.DisplayXNA.PresetObjects.Galaxy.XSpeed = (double)numericUpDownXSpeed.Value;
            myParent.DisplayXNA.PresetObjects.Galaxy.YSpeed = (double)numericUpDownYSpeed.Value;
            myParent.DisplayXNA.PresetObjects.Galaxy.Color = Microsoft.Xna.Framework.Color.White;
            if (comboBoxColor.SelectedIndex==1)
            {
                myParent.DisplayXNA.PresetObjects.Galaxy.Color = Microsoft.Xna.Framework.Color.Red;
            }
            if (comboBoxColor.SelectedIndex == 2)
            {
                myParent.DisplayXNA.PresetObjects.Galaxy.Color = Microsoft.Xna.Framework.Color.Green;
            }
            if (comboBoxColor.SelectedIndex == 3)
            {
                myParent.DisplayXNA.PresetObjects.Galaxy.Color = Microsoft.Xna.Framework.Color.Blue;
            }
            if (comboBoxColor.SelectedIndex == 4)
            {
                myParent.DisplayXNA.PresetObjects.Galaxy.Color = Microsoft.Xna.Framework.Color.Yellow;
            }

            // Set the Scale so that the new galaxy fits in 2 times
            myParent.macTrackBarScale.Value = myParent.CalcScaleBarValueFromMlnMetersPerPixel((myParent.DisplayXNA.PresetObjects.Galaxy.CrossSection*2000000.0)/myParent.DisplayXNA.Height);
            //            myParent.macTrackBarScale.Value = 22;//13;

            myParent.DisplayXNA.BlendState = BlendState.Additive;       // looks better on galaxies
            Close();
        }

        private void checkBoxElliptical_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxElliptical.Checked==false)      
            {
                checkBoxSpiral.Checked = true;      // always one shape must be active
                numericUpDownEllipseRatio.Enabled = false;
                numericUpDownEllipseSizePercentage.Enabled = false;
                numericUpDownEllipseBlurriness.Enabled = false;
                numericUpDownEllipseObjectsPercentage.Enabled = false;
            }
            else
            {
                numericUpDownEllipseRatio.Enabled = true;
                numericUpDownEllipseSizePercentage.Enabled = true;
                numericUpDownEllipseBlurriness.Enabled = true;
                numericUpDownEllipseObjectsPercentage.Enabled = true;
            }


        }

        private void checkBoxSpiral_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSpiral.Checked == false)
            {
                checkBoxElliptical.Checked = true;      // always one shape must be active
                numericUpDownNumberOfArms.Enabled = false;
                numericUpDownArmLength.Enabled = false;
                checkBoxBar.Enabled = false;
                numericUpDownBarPercentage.Enabled = false;
                numericUpDownEllipseSizePercentage.Enabled = false;
                numericUpDownEllipseObjectsPercentage.Enabled = false;
                numericUpDownSpiralBlurriness.Enabled = false;
                checkBoxAddSolarSystem.Enabled = false;
            }
            else
            {
                numericUpDownNumberOfArms.Enabled = true;
                numericUpDownArmLength.Enabled = true;
                checkBoxBar.Enabled = true;
                numericUpDownBarPercentage.Enabled = true;
                numericUpDownEllipseSizePercentage.Enabled = true;
                numericUpDownEllipseObjectsPercentage.Enabled = true;
                numericUpDownSpiralBlurriness.Enabled = true;
                checkBoxAddSolarSystem.Enabled = true;
                UpdateBarControls();
            }
        }

        public void UpdateBarControls()
        {
            if (checkBoxSpiral.Checked && numericUpDownNumberOfArms.Value == 2)
            {
                checkBoxBar.Enabled = true;
                numericUpDownBarPercentage.Enabled = true;
            }
            else
            {
                checkBoxBar.Enabled = false;
                numericUpDownBarPercentage.Enabled = false;
            }
        }


        private void numericUpDownNumberOfArms_ValueChanged(object sender, EventArgs e)
        {
            UpdateBarControls();
        }

        private void checkBoxCalculateStableSpeed_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownRotationPeriod.Enabled = numericUpDownVelocityIncreaseFactor.Enabled = !checkBoxCalculateStableSpeed.Checked;
        }

        private void comboBoxPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxPreset.SelectedIndex==0)
            {
                myParent.PresetToMilkyWay();
            }
            if (comboBoxPreset.SelectedIndex == 1)
            {
                myParent.PresetToSmallGalaxy();
            }
            if (comboBoxPreset.SelectedIndex == 2)
            {
                myParent.PresetToEllipse();
            }
            if (comboBoxPreset.SelectedIndex == 3)
            {
                myParent.PresetToSpiral();
            }
            if (comboBoxPreset.SelectedIndex == 4)
            {
                myParent.PresetToSmallEllipse();
            }
            if (comboBoxPreset.SelectedIndex == 4)
            {
                myParent.PresetToLargeStableGalaxy();
            }

            Initialize();
        }

    }
}
