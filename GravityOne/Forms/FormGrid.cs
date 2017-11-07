﻿using System;
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
            numericUpDownMass.Value = Convert.ToDecimal(MyParent.DisplayXNA.Grid.Mass);
            numericUpDownSpacing.Value = Convert.ToDecimal(MyParent.DisplayXNA.Grid.Spacing);
            numericUpDownColumns.Value = Convert.ToDecimal(MyParent.DisplayXNA.Grid.XAmount);
            numericUpDownRows.Value = Convert.ToDecimal(MyParent.DisplayXNA.Grid.YAmount);
            numericUpDownRotations.Value = Convert.ToDecimal(MyParent.DisplayXNA.Grid.Rotations);
            comboBoxShape.SelectedIndex = comboBoxShape.FindString(MyParent.DisplayXNA.Grid.Texture.Name);
            comboBoxSpacingUnits.SelectedIndex = comboBoxSpacingUnits.FindString(MyParent.DisplayXNA.Grid.SpacingUnits);
            numericUpDownXSpeed.Value = Convert.ToDecimal(myParent.DisplayXNA.Grid.XSpeed);
            numericUpDownYSpeed.Value = Convert.ToDecimal(myParent.DisplayXNA.Grid.YSpeed);
        }

        private void gradientButtonCreate_Click(object sender, EventArgs e)
        {
            FormMain.PlacingObject = 10;
            MyParent.gradientButtonGrid.ForeColor = Color.Coral;
            MyParent.labelClickMessage.Visible = true;
            this.Cursor = Cursors.Hand;
            MyParent.DisplayXNA.Grid.Mass = Convert.ToInt32(numericUpDownMass.Value);
            MyParent.DisplayXNA.Grid.Spacing = Convert.ToInt32(numericUpDownSpacing.Value);
            MyParent.DisplayXNA.Grid.XAmount = Convert.ToInt32(numericUpDownColumns.Value);
            MyParent.DisplayXNA.Grid.YAmount = Convert.ToInt32(numericUpDownRows.Value);
            MyParent.DisplayXNA.Grid.Rotations = Convert.ToDouble(numericUpDownRotations.Value);
            MyParent.DisplayXNA.Grid.Texture = MyParent.DisplayXNA.getTextureByName(comboBoxShape.Text);
            MyParent.DisplayXNA.Grid.SpacingUnits = comboBoxSpacingUnits.Text;
            myParent.DisplayXNA.Grid.XSpeed = (double)numericUpDownXSpeed.Value;
            myParent.DisplayXNA.Grid.YSpeed = (double)numericUpDownYSpeed.Value;
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
