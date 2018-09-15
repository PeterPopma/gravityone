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
            myParent.labelClickMessage.Visible = true;
            this.Cursor = Cursors.Hand;
            if (radioButtonBinary1.Checked)
            {
                FormMain.PlacingObject = 7;
                myParent.macTrackBarScale.Value = 292;
                myParent.SetSpeed(60 * 60 * 2);
            }
            if (radioButtonBinary2.Checked)
            {
                FormMain.PlacingObject = 8;
                myParent.macTrackBarScale.Value = 297;
                myParent.SetSpeed(60 * 60 * 24);
            }
            if (radioButtonBinary2.Checked)
            {
                FormMain.PlacingObject = 11;
                myParent.macTrackBarScale.Value = 294;
                myParent.SetSpeed(60 * 60 * 8);
            }
            if (radioButtonTriple.Checked)
            {
                FormMain.PlacingObject = 12;
                myParent.macTrackBarScale.Value = 294;
                myParent.SetSpeed(60 * 60 * 8);
            }

            Close();
        }
    }
}
