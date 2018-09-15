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
    public partial class FormPlanetSystems : Form
    {
        private FormMain myParent = null;

        public FormPlanetSystems()
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

        private void gradientButtonCreate_Click(object sender, EventArgs e)
        {
            myParent.gradientButtonPlanetSystems.ForeColor = Color.Coral;
            myParent.labelClickMessage.Visible = true;
            this.Cursor = Cursors.Hand;
            if (radioButtonSolarMoons.Checked)
            {
                FormMain.PlacingObject = 13;
            }
            if (radioButtonPlanetMoon.Checked)
            {
                FormMain.PlacingObject = 1;
                myParent.macTrackBarScale.Value = 379;
            }
            if (radioButtonSunPlanet.Checked)
            {
                FormMain.PlacingObject = 4;
                myParent.macTrackBarScale.Value = 300;
            }
            if (radioButtonSunPlanetMoon.Checked)
            {
                FormMain.PlacingObject = 3;
                myParent.macTrackBarScale.Value = 299;
            }
            if (radioButtonMoonMoon.Checked)
            {
                FormMain.PlacingObject = 6;
                myParent.macTrackBarScale.Value = 287;
            }

            Close();
        }
    }
}
