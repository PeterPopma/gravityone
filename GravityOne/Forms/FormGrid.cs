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
    public partial class FormGrid : Form
    {
        private FormMain myParent = null;

        public FormGrid()
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
            numericUpDownMass.Value = Convert.ToDecimal(MyParent.DisplayXNA.PresetObjects.Grid.Mass);
            numericUpDownSpacing.Value = Convert.ToDecimal(MyParent.DisplayXNA.PresetObjects.Grid.Spacing);
            numericUpDownColumns.Value = Convert.ToDecimal(MyParent.DisplayXNA.PresetObjects.Grid.XAmount);
            numericUpDownRows.Value = Convert.ToDecimal(MyParent.DisplayXNA.PresetObjects.Grid.YAmount);
            numericUpDownRotations.Value = Convert.ToDecimal(MyParent.DisplayXNA.PresetObjects.Grid.Rotations);
            comboBoxShape.SelectedIndex = comboBoxShape.FindString(MyParent.DisplayXNA.PresetObjects.Grid.Texture.Name);
            comboBoxSpacingUnits.SelectedIndex = comboBoxSpacingUnits.FindString(MyParent.DisplayXNA.PresetObjects.Grid.SpacingUnits);
            numericUpDownXSpeed.Value = Convert.ToDecimal(myParent.DisplayXNA.PresetObjects.Grid.XSpeed);
            numericUpDownYSpeed.Value = Convert.ToDecimal(myParent.DisplayXNA.PresetObjects.Grid.YSpeed);
        }

        private void gradientButtonCreate_Click(object sender, EventArgs e)
        {
            FormMain.PlacingObject = PlacingObject_.Grid;
            MyParent.gradientButtonGrid.ForeColor = Color.Coral;
            MyParent.DisplayXNA.ShowClickMessage = true;
            this.Cursor = Cursors.Hand;
            MyParent.DisplayXNA.PresetObjects.Grid.Mass = Convert.ToInt32(numericUpDownMass.Value);
            MyParent.DisplayXNA.PresetObjects.Grid.Spacing = Convert.ToInt32(numericUpDownSpacing.Value);
            MyParent.DisplayXNA.PresetObjects.Grid.XAmount = Convert.ToInt32(numericUpDownColumns.Value);
            MyParent.DisplayXNA.PresetObjects.Grid.YAmount = Convert.ToInt32(numericUpDownRows.Value);
            MyParent.DisplayXNA.PresetObjects.Grid.Rotations = Convert.ToDouble(numericUpDownRotations.Value);
            MyParent.DisplayXNA.PresetObjects.Grid.Texture = MyParent.DisplayXNA.GetTextureByName(comboBoxShape.Text);
            MyParent.DisplayXNA.PresetObjects.Grid.SpacingUnits = comboBoxSpacingUnits.Text;
            myParent.DisplayXNA.PresetObjects.Grid.XSpeed = (double)numericUpDownXSpeed.Value;
            myParent.DisplayXNA.PresetObjects.Grid.YSpeed = (double)numericUpDownYSpeed.Value;
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
