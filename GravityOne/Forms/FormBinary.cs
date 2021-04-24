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
    public partial class FormBinary : Form
    {
        private FormMain myParent = null;

        public FormBinary()
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
            myParent.gradientButtonBinary.ForeColor = Color.Coral;
            myParent.DisplayXNA.ShowClickMessage = true;
            this.Cursor = Cursors.Hand;
            if (radioButtonBinaryTwoPlanets.Checked)
            {
                FormMain.PlacingObject = PlacingObject_.BinaryTwoPlanets;
            }
            if (radioButtonBinaryOnePlanetStable.Checked)
            {
                FormMain.PlacingObject = PlacingObject_.BinaryOnePlanetStable;
            }
            if (radioButtonBinaryOnePlanetHopping.Checked)
            {
                FormMain.PlacingObject = PlacingObject_.BinaryOnePlanetHopping;
            }
            if (radioButtonTriple.Checked)
            {
                FormMain.PlacingObject = PlacingObject_.TripleStar;
            }

            Close();
        }
    }
}
