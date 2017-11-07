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
            dateTimePickerCurrentDate.Value = myParent.DisplayXNA.SimulationTime;
            dateTimePickerCurrentTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerCurrentTime.CustomFormat = "HH:mm";
            dateTimePickerCurrentTime.ShowUpDown = true;
            dateTimePickerCurrentTime.Value = myParent.DisplayXNA.SimulationTime;
            comboBoxBackground.SelectedIndex = myParent.DisplayXNA.BackgroundIndex;
            numericUpDownPrecalculationIncrease.Value = myParent.DisplayXNA.GravitySystem.PreCalculationIncreaseFactor;
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
            numericUpDownPixelSize.Value = myParent.DisplayXNA.SmallDot.PixelSize;
            numericUpDownPixelSize.Enabled = !checkBoxRandomSize.Checked;
            checkBoxRandomSize.Checked = myParent.DisplayXNA.SmallDot.RandomSize;
            checkBoxRandomColor.Checked = myParent.DisplayXNA.SmallDot.RandomColor;

            if (myParent.DisplayXNA.SmallDot.Type == 0)
                radioButtonSquare.Checked = true;
            if (myParent.DisplayXNA.SmallDot.Type == 1)
                radioButtonRound.Checked = true;
            if (myParent.DisplayXNA.SmallDot.Type == 2)
                radioButtonCross.Checked = true;

            numericUpDownAlpha.Value = myParent.DisplayXNA.SmallDot.Alpha;
            comboBoxColorCoding.SelectedIndex = myParent.DisplayXNA.SmallDot.ColorCoding;
            numericUpDownBarnesHutTreshold.Value = Convert.ToDecimal(myParent.DisplayXNA.GravitySystem.QuadTree.Treshold);
            checkBoxUseBarnesHut.Checked = myParent.DisplayXNA.GravitySystem.UseBarnesHut;
            numericUpDownMinimumTextureSize.Value = myParent.DisplayXNA.GravitySystem.MinimumTextureSize;
            initialSimulationTime = dateTimePickerCurrentDate.Value;
            checkBoxPrecalcAutoIncrease.Checked = myParent.DisplayXNA.GravitySystem.PrecalcAutoIncrease;
            numericUpDownPrecalculationIncrease.Enabled = checkBoxPrecalcAutoIncrease.Checked;

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
            checkBoxAllDots.Checked = myParent.DisplayXNA.ShowAsDots;
            checkBoxShowScale.Checked = myParent.DisplayXNA.ShowScale;
        }

        private void gradientButtonSave_Click(object sender, EventArgs e)
        {
            bool resumeCalculations = false;
            bool resetCalculations = false;

            if (myParent.DisplayXNA.GravitySystem.TargetFrameRate != Convert.ToInt32(textBoxFrameRate.Text))
            {
                myParent.DisplayXNA.GravitySystem.TargetFrameRate = Convert.ToInt32(textBoxFrameRate.Text);
                myParent.DisplayXNA.GravitySystem.StopCalculation();
                myParent.DisplayXNA.GravitySystem.InitCalculation();
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
            
            if (Convert.ToInt32(textBoxPrecalcTime.Text) != myParent.DisplayXNA.GravitySystem.PreCalculationTime)
            {
                myParent.DisplayXNA.GravitySystem.AdjustNumberOfCalculations(Convert.ToInt32(textBoxPrecalcTime.Text));
            }

            if(checkBoxPrecalcAutoIncrease.Checked && myParent.DisplayXNA.GravitySystem.PrecalcAutoIncrease==false)
            {
                resumeCalculations = true;
            }

            if (!dateTimePickerCurrentDate.Value.Equals(initialSimulationTime))        // Only set time if changed (it messes up time in pre-calculated mode)
            {
                myParent.DisplayXNA.SimulationTime = dateTimePickerCurrentDate.Value.Date + dateTimePickerCurrentTime.Value.TimeOfDay;
                myParent.DisplayXNA.SimulationTimeLarge = myParent.DisplayXNA.SimulationTime.Year;
            }
            myParent.DisplayXNA.GravitySystem.PreCalculationIncreaseFactor = Convert.ToInt32(numericUpDownPrecalculationIncrease.Value);
            myParent.DisplayXNA.BlendState = myParent.ConvertToBlendState(comboBoxBlendMode.Text);
            myParent.DisplayXNA.setBackground(comboBoxBackground.SelectedIndex);
            myParent.DisplayXNA.SmallDot.PixelSize = Convert.ToInt32(numericUpDownPixelSize.Value);
            if (radioButtonSquare.Checked)
                myParent.DisplayXNA.SmallDot.Type = 0;
            if (radioButtonRound.Checked)
                myParent.DisplayXNA.SmallDot.Type = 1;
            if (radioButtonCross.Checked)
                myParent.DisplayXNA.SmallDot.Type = 2;
            myParent.DisplayXNA.SmallDot.Alpha = Convert.ToInt32(numericUpDownAlpha.Value);
            myParent.DisplayXNA.SmallDot.ColorCoding = comboBoxColorCoding.SelectedIndex;
            myParent.DisplayXNA.SmallDot.RandomSize = checkBoxRandomSize.Checked;
            myParent.DisplayXNA.SmallDot.RandomColor = checkBoxRandomColor.Checked;
            myParent.DisplayXNA.updateSmallDots();
            myParent.DisplayXNA.GravitySystem.GravitationalConstant = Convert.ToInt64(numericUpDownGravitationalConstant.Value);
            myParent.DisplayXNA.GravitySystem.AccelerationLimit = Convert.ToDouble(numericUpDownAccelerationLimit.Value);
            if (!myParent.DisplayXNA.GravitySystem.UseBarnesHut && checkBoxUseBarnesHut.Checked)
            {
                myParent.DisplayXNA.GravitySystem.QuadTree.DetermineBoundingBox(myParent.DisplayXNA.GravitySystem.GravityObjects);
            }
            myParent.DisplayXNA.GravitySystem.UseBarnesHut = checkBoxUseBarnesHut.Checked;
            myParent.DisplayXNA.GravitySystem.QuadTree.Treshold = Convert.ToDouble(numericUpDownBarnesHutTreshold.Value);
            myParent.DisplayXNA.GravitySystem.MinimumTextureSize = Convert.ToInt32(numericUpDownMinimumTextureSize.Value);
            myParent.DisplayXNA.GravitySystem.PrecalcAutoIncrease = checkBoxPrecalcAutoIncrease.Checked;

            myParent.SaveDir = textBoxSaveDir.Text;
            myParent.CompressRecordings = checkBoxCompressRecordings.Checked;
            myParent.DisplayXNA.VideoCaptureCompression = comboBoxCaptureCompression.Text;
            myParent.DisplayXNA.VideoCaptureFPS = Convert.ToInt32(numericUpDownVideoFPS.Value);
            myParent.DisplayXNA.ShowAsDots = checkBoxAllDots.Checked;
            myParent.DisplayXNA.ShowScale = checkBoxShowScale.Checked;

            if (resumeCalculations)
            {
                myParent.DisplayXNA.GravitySystem.StartCalculation();
            }
            if (resetCalculations)
            {
                myParent.DisplayXNA.GravitySystem.ResetCalculations();
            }

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

        private void checkBoxRandomSize_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownPixelSize.Enabled = !checkBoxRandomSize.Checked;
        }

        private void comboBoxColorCoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            myParent.DisplayXNA.GravitySystem.ObtainMinMaxValues();
        }

        private void checkBoxPrecalcAutoIncrease_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownPrecalculationIncrease.Enabled = checkBoxPrecalcAutoIncrease.Checked;
        }

        private void gradientPanel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBoxAllDots_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
