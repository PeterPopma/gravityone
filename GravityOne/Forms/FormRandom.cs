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
    public partial class FormRandom : Form
    {
        private FormMain myParent = null;

        public FormRandom()
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

        public void Initialize()
        {
            numericUpDownMass.Value = Convert.ToDecimal(MyParent.DisplayXNA.RandomObjects.Mass);
            numericUpDownNumberOfObjects.Value = Convert.ToDecimal(MyParent.DisplayXNA.RandomObjects.NumberOfObjects);
            comboBoxShape.SelectedIndex = comboBoxShape.FindString(MyParent.DisplayXNA.RandomObjects.Texture.Name);
            numericUpDownArea.Value = MyParent.DisplayXNA.RandomObjects.Area;
            comboBoxAreaUnits.SelectedIndex = comboBoxAreaUnits.FindString(MyParent.DisplayXNA.RandomObjects.AreaUnits);
            numericUpDownSpeed.Value = Convert.ToInt32(MyParent.DisplayXNA.RandomObjects.Speed);
            numericUpDownSpeedRandomness.Value = Convert.ToInt32(MyParent.DisplayXNA.RandomObjects.SpeedRandomness);
        }

        private void gradientButtonCreate_Click(object sender, EventArgs e)
        {
            FormMain.PlacingObject = 9;
            myParent.gradientButtonRandom.ForeColor = Color.Coral;
            myParent.labelClickMessage.Visible = true;
            this.Cursor = Cursors.Hand;
            myParent.DisplayXNA.RandomObjects.Mass = Convert.ToInt64(numericUpDownMass.Value);
            myParent.DisplayXNA.RandomObjects.NumberOfObjects = Convert.ToInt32(numericUpDownNumberOfObjects.Value);
            MyParent.DisplayXNA.RandomObjects.Texture = MyParent.DisplayXNA.getTextureByName(comboBoxShape.Text);
            MyParent.DisplayXNA.RandomObjects.AreaUnits = comboBoxAreaUnits.Text;
            MyParent.DisplayXNA.RandomObjects.Area = Convert.ToUInt64(numericUpDownArea.Value);
            MyParent.DisplayXNA.RandomObjects.Speed = Convert.ToInt32(numericUpDownSpeed.Value);
            MyParent.DisplayXNA.RandomObjects.SpeedRandomness = Convert.ToInt32(numericUpDownSpeedRandomness.Value);

            Close();
        }

        private void comboBoxAreaUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAreaUnits.Text.Equals("pixels")) {
                numericUpDownArea.Maximum = 10000;
            } else
            {
                numericUpDownArea.Maximum = 9999999999999999999;
            }
        }
    }
}
