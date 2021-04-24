using Microsoft.Win32;
using Microsoft.Xna.Framework.Graphics;
using SharpAvi;
using SharpAvi.Codecs;
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
    public partial class FormPreferences : Form
    {
        private FormMain myParent = null;
        private DateTime initialSimulationTime;


        public FormPreferences()
        {
            InitializeComponent();
        }

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

        private void gradientButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Initialize()
        {
            textBoxFrameRate.Text = myParent.DisplayXNA.GravitySystem.TargetFrameRate.ToString();
            textBoxSaveDir.Text = myParent.SaveDir;
            textBoxPrecalcTime.Text = myParent.DisplayXNA.GravitySystem.PreCalculationTime.ToString();
            dateTimePickerCurrentDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerCurrentDate.CustomFormat = "dd/MM/yyyy";
            dateTimePickerCurrentDate.Value = new DateTime(myParent.DisplayXNA.SimulationTime * 10000000);
            dateTimePickerCurrentTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerCurrentTime.CustomFormat = "HH:mm";
            dateTimePickerCurrentTime.ShowUpDown = true;
            dateTimePickerCurrentTime.Value = new DateTime(myParent.DisplayXNA.SimulationTime * 10000000);
            comboBoxBackground.SelectedIndex = myParent.DisplayXNA.BackgroundIndex;
            
            if(myParent.DisplayXNA.BlendState.Equals(BlendState.Additive))
            {
                comboBoxBlendMode.SelectedIndex = 0;
            }
            else
            {
                comboBoxBlendMode.SelectedIndex = 1;
            }
            numericUpDownGravitationalConstant.Value = Convert.ToDecimal(myParent.DisplayXNA.GravitySystem.GravitationalConstant);
            numericUpDownAccelerationLimit.Value = Convert.ToDecimal(myParent.DisplayXNA.GravitySystem.AccelerationLimit);
            checkBoxCompressRecordings.Checked = myParent.CompressRecordings;
            comboBoxSize.SelectedItem = myParent.DisplayXNA.CustomShape.SizeToText();
            comboBoxColor.SelectedItem = myParent.DisplayXNA.CustomShape.ColorToText();
            checkBoxChangeAllExisting.Checked = myParent.DisplayXNA.CustomShape.UpdateExisting;

            if (myParent.DisplayXNA.CustomShape.Type == 0)
                radioButtonSquare.Checked = true;
            if (myParent.DisplayXNA.CustomShape.Type == 1)
                radioButtonRound.Checked = true;
            if (myParent.DisplayXNA.CustomShape.Type == 2)
                radioButtonCross.Checked = true;

            if (myParent.DisplayXNA.GravitySystem.CalculationsPerStepSetting == -1)
            {
                comboBoxRealtimeCalcs.SelectedItem = "Automatic";

            }
            else
            {
                comboBoxRealtimeCalcs.SelectedItem = myParent.DisplayXNA.GravitySystem.CalculationsPerStepSetting.ToString();
            }

            numericUpDownAlpha.Value = myParent.DisplayXNA.CustomShape.Alpha;
            comboBoxColorCoding.SelectedIndex = myParent.DisplayXNA.ColorScheme;
            numericUpDownBarnesHutTreshold.Value = Convert.ToDecimal(myParent.DisplayXNA.GravitySystem.QuadTree.Treshold);
            checkBoxUseBarnesHut.Checked = myParent.DisplayXNA.GravitySystem.UseBarnesHut;
            numericUpDownMinimumTextureSize.Value = myParent.DisplayXNA.GravitySystem.MinimumTextureSize;
            initialSimulationTime = dateTimePickerCurrentDate.Value;
            numericUpDownPreCalcGalaxy.Value = myParent.DisplayXNA.GravitySystem.CalculationsPerStepPrecalculatedGalaxy;
            numericUpDownPrecalcSolar.Value= myParent.DisplayXNA.GravitySystem.CalculationsPerStepPrecalculatedSolar;

            var codecs = new List<CodecInfo>();
            codecs.Add(new CodecInfo(KnownFourCCs.Codecs.Uncompressed, "(none)"));
            codecs.AddRange(Mpeg4VideoEncoderVcm.GetAvailableCodecs());
            comboBoxCaptureCompression.Items.Clear();
            foreach (var codec in codecs)
            {
                comboBoxCaptureCompression.Items.Add(codec.Name);
            }
            comboBoxCaptureCompression.Text = myParent.DisplayXNA.VideoCaptureCompression;
            if(comboBoxCaptureCompression.SelectedIndex==-1)
            {
                comboBoxCaptureCompression.SelectedIndex = 0;
            }
            numericUpDownVideoFPS.Value = myParent.DisplayXNA.VideoCaptureFPS;
            checkBoxShowScale.Checked = myParent.DisplayXNA.ShowScale;
        }

        private void gradientButtonSave_Click(object sender, EventArgs e)
        {
            bool resetCalculations = false;

            if (myParent.DisplayXNA.GravitySystem.TargetFrameRate != Convert.ToInt32(textBoxFrameRate.Text))
            {
                myParent.DisplayXNA.GravitySystem.TargetFrameRate = Convert.ToInt32(textBoxFrameRate.Text);
                resetCalculations = true;
            }

            if (!numericUpDownGravitationalConstant.Value.ToString().Equals(myParent.DisplayXNA.GravitySystem.GravitationalConstant.ToString()))
            {
                resetCalculations = true;
            }

            if (!numericUpDownAccelerationLimit.Value.ToString(".000000000000000").Equals(myParent.DisplayXNA.GravitySystem.AccelerationLimit.ToString(".000000000000000")))
            {
                resetCalculations = true;
            }

            if (comboBoxRealtimeCalcs.SelectedItem.ToString().Equals("Automatic"))
            {
                myParent.DisplayXNA.GravitySystem.CalculationsPerStepSetting = -1;
            }
            else
            {
                int value = Convert.ToInt32(comboBoxRealtimeCalcs.SelectedItem);
                myParent.DisplayXNA.GravitySystem.CalculationsPerStepSetting = value;
            }

            if (Convert.ToInt32(textBoxPrecalcTime.Text) != myParent.DisplayXNA.GravitySystem.PreCalculationTime)
            {
                myParent.DisplayXNA.GravitySystem.AdjustNumberOfCalculations(Convert.ToInt32(textBoxPrecalcTime.Text));
            }

            if (!dateTimePickerCurrentDate.Value.Equals(initialSimulationTime))        // Only set time if changed (it messes up time in pre-calculated mode)
            {
                DateTime newDate = dateTimePickerCurrentDate.Value.Date + dateTimePickerCurrentTime.Value.TimeOfDay;
                myParent.DisplayXNA.SimulationTime = newDate.Ticks / 10000000;
            }
            myParent.DisplayXNA.BlendState = myParent.ConvertToBlendState(comboBoxBlendMode.Text);
            myParent.DisplayXNA.setBackground(comboBoxBackground.SelectedIndex);

            if (radioButtonSquare.Checked)
                myParent.DisplayXNA.CustomShape.Type = 0;
            if (radioButtonRound.Checked)
                myParent.DisplayXNA.CustomShape.Type = 1;
            if (radioButtonCross.Checked)
                myParent.DisplayXNA.CustomShape.Type = 2;
            myParent.DisplayXNA.CustomShape.Alpha = Convert.ToInt32(numericUpDownAlpha.Value);
            myParent.DisplayXNA.ColorScheme = comboBoxColorCoding.SelectedIndex;
            myParent.DisplayXNA.CustomShape.TextToSize(comboBoxSize.SelectedItem.ToString());
            myParent.DisplayXNA.CustomShape.TextToColor(comboBoxColor.SelectedItem.ToString());
            myParent.DisplayXNA.GravitySystem.CalculationsPerStepPrecalculatedGalaxy = Convert.ToInt32(numericUpDownPreCalcGalaxy.Value);
            myParent.DisplayXNA.GravitySystem.CalculationsPerStepPrecalculatedSolar = Convert.ToInt32(numericUpDownPrecalcSolar.Value); 

            myParent.DisplayXNA.GravitySystem.GravitationalConstant = Convert.ToInt64(numericUpDownGravitationalConstant.Value);
            myParent.DisplayXNA.GravitySystem.AccelerationLimit = Convert.ToDouble(numericUpDownAccelerationLimit.Value);
            if (!myParent.DisplayXNA.GravitySystem.UseBarnesHut && checkBoxUseBarnesHut.Checked)
            {
                myParent.DisplayXNA.GravitySystem.QuadTree.DetermineBoundingBox(myParent.DisplayXNA.GravitySystem.GravityObjects);
            }
            myParent.DisplayXNA.GravitySystem.UseBarnesHut = checkBoxUseBarnesHut.Checked;
            myParent.DisplayXNA.GravitySystem.QuadTree.Treshold = Convert.ToDouble(numericUpDownBarnesHutTreshold.Value);
            myParent.DisplayXNA.GravitySystem.MinimumTextureSize = Convert.ToInt32(numericUpDownMinimumTextureSize.Value);

            myParent.SaveDir = textBoxSaveDir.Text;
            myParent.CompressRecordings = checkBoxCompressRecordings.Checked;
            myParent.DisplayXNA.VideoCaptureCompression = comboBoxCaptureCompression.Text;
            myParent.DisplayXNA.VideoCaptureFPS = Convert.ToInt32(numericUpDownVideoFPS.Value);
            myParent.DisplayXNA.ShowScale = checkBoxShowScale.Checked;

            myParent.DisplayXNA.CustomShape.UpdateExisting = checkBoxChangeAllExisting.Checked;
            if (myParent.DisplayXNA.CustomShape.UpdateExisting)
            {
                myParent.DisplayXNA.updateCustomShapes();
            }

            if (resetCalculations)
            {
                myParent.DisplayXNA.GravitySystem.InitCalculation();
            }

            myParent.DisplayXNA.GravitySystem.DetermineCalculationsPerStepActual();

            Close();
        }

        private void buttonSaveDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogSaveDir.ShowDialog() == DialogResult.OK)
            {
                textBoxSaveDir.Text = folderBrowserDialogSaveDir.SelectedPath;
            }
        }

        private void gradientButtonResetToDefaults_Click(object sender, EventArgs e)
        {
            myParent.ResetToDefaults();
            myParent.SetControls();
            Initialize();
        }

        private void gradientButtonNow_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            dateTimePickerCurrentDate.Value = now;
            dateTimePickerCurrentTime.Value = now;
        }

        private void checkBoxUseBarnesHut_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownBarnesHutTreshold.Enabled = checkBoxUseBarnesHut.Checked;
        }

        private void comboBoxColorCoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            myParent.DisplayXNA.GravitySystem.ObtainMinMaxValues();
        }

        private void colorSelector1_SelectedIndexChanged(object sender, EventArgs e)
        {
            myParent.DisplayXNA.GravitySystem.ObtainMinMaxValues();
        }

        private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
