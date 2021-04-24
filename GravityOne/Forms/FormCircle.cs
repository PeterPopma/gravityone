using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GravityOne.Forms
{
    public partial class FormCircle : Form
    {
        public FormCircle()
        {
            InitializeComponent();
        }

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

        public void Initialize()
        {
            numericUpDownMass.Value = Convert.ToDecimal(MyParent.DisplayXNA.PresetObjects.Circle.Mass);
            numericUpDownSpacing.Value = Convert.ToDecimal(MyParent.DisplayXNA.PresetObjects.Circle.Spacing);
            numericUpDownNumObjectsRadius.Value = Convert.ToDecimal(MyParent.DisplayXNA.PresetObjects.Circle.NumObjectsRadius);
            numericUpDownRotations.Value = Convert.ToDecimal(MyParent.DisplayXNA.PresetObjects.Circle.Rotations);
            comboBoxShape.SelectedIndex = comboBoxShape.FindString(MyParent.DisplayXNA.PresetObjects.Circle.Texture.Name);
            comboBoxSpacingUnits.SelectedIndex = comboBoxSpacingUnits.FindString(MyParent.DisplayXNA.PresetObjects.Circle.SpacingUnits);
            numericUpDownXSpeed.Value = Convert.ToDecimal(myParent.DisplayXNA.PresetObjects.Circle.XSpeed);
            numericUpDownYSpeed.Value = Convert.ToDecimal(myParent.DisplayXNA.PresetObjects.Circle.YSpeed);
        }

        private void gradientButtonCreate_Click(object sender, EventArgs e)
        {
            FormMain.PlacingObject = PlacingObject_.Circle;
            MyParent.gradientButtonCircle.ForeColor = Color.Coral;
            myParent.DisplayXNA.ShowClickMessage = true;
            this.Cursor = Cursors.Hand;
            MyParent.DisplayXNA.PresetObjects.Circle.Mass = Convert.ToDouble(numericUpDownMass.Value);
            MyParent.DisplayXNA.PresetObjects.Circle.Spacing = Convert.ToDouble(numericUpDownSpacing.Value);
            MyParent.DisplayXNA.PresetObjects.Circle.NumObjectsRadius = Convert.ToInt32(numericUpDownNumObjectsRadius.Value);
            MyParent.DisplayXNA.PresetObjects.Circle.Rotations = Convert.ToDouble(numericUpDownRotations.Value);
            MyParent.DisplayXNA.PresetObjects.Circle.Texture = MyParent.DisplayXNA.GetTextureByName(comboBoxShape.Text);
            MyParent.DisplayXNA.PresetObjects.Circle.SpacingUnits = comboBoxSpacingUnits.Text;
            myParent.DisplayXNA.PresetObjects.Circle.XSpeed = (double)numericUpDownXSpeed.Value;
            myParent.DisplayXNA.PresetObjects.Circle.YSpeed = (double)numericUpDownYSpeed.Value;

            Close();
        }

        private void comboBoxSpacingUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSpacingUnits.Text.Equals("pixels"))
            {
                numericUpDownSpacing.Maximum = 10000;
            }
            else
            {
                numericUpDownSpacing.Maximum = 9999999999999999999;
            }
        }

    }
}
