﻿using System;
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
            numericUpDownMass.Value = Convert.ToDecimal(MyParent.DisplayXNA.Circle.Mass);
            numericUpDownSpacing.Value = Convert.ToDecimal(MyParent.DisplayXNA.Circle.Spacing);
            numericUpDownNumObjectsRadius.Value = Convert.ToDecimal(MyParent.DisplayXNA.Circle.NumObjectsRadius);
            numericUpDownRotations.Value = Convert.ToDecimal(MyParent.DisplayXNA.Circle.Rotations);
            comboBoxShape.SelectedIndex = comboBoxShape.FindString(MyParent.DisplayXNA.Circle.Texture.Name);
            comboBoxSpacingUnits.SelectedIndex = comboBoxSpacingUnits.FindString(MyParent.DisplayXNA.Circle.SpacingUnits);
            numericUpDownXSpeed.Value = Convert.ToDecimal(myParent.DisplayXNA.Circle.XSpeed);
            numericUpDownYSpeed.Value = Convert.ToDecimal(myParent.DisplayXNA.Circle.YSpeed);
        }

        private void gradientButtonCreate_Click(object sender, EventArgs e)
        {
            FormMain.PlacingObject = 15;
            MyParent.gradientButtonCircle.ForeColor = Color.Coral;
            MyParent.labelClickMessage.Visible = true;
            this.Cursor = Cursors.Hand;
            MyParent.DisplayXNA.Circle.Mass = Convert.ToInt32(numericUpDownMass.Value);
            MyParent.DisplayXNA.Circle.Spacing = Convert.ToInt32(numericUpDownSpacing.Value);
            MyParent.DisplayXNA.Circle.NumObjectsRadius = Convert.ToInt32(numericUpDownNumObjectsRadius.Value);
            MyParent.DisplayXNA.Circle.Rotations = Convert.ToDouble(numericUpDownRotations.Value);
            MyParent.DisplayXNA.Circle.Texture = MyParent.DisplayXNA.getTextureByName(comboBoxShape.Text);
            MyParent.DisplayXNA.Circle.SpacingUnits = comboBoxSpacingUnits.Text;
            myParent.DisplayXNA.Circle.XSpeed = (double)numericUpDownXSpeed.Value;
            myParent.DisplayXNA.Circle.YSpeed = (double)numericUpDownYSpeed.Value;

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

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}