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
    public partial class FormSplashScreen : Form
    {
        private static System.Windows.Forms.Timer splashTimer;

        public FormSplashScreen()
        {
            // Create a timer with a 4000 msec interval.
            splashTimer = new System.Windows.Forms.Timer();
            splashTimer.Interval = 5000;
            splashTimer.Tick += new EventHandler(splashTimer_Tick);
            splashTimer.Start();

            InitializeComponent();
        }

        private void splashTimer_Tick(object sender, EventArgs e)
        {
           splashTimer.Stop();
           this.Close();
        }

        private void FormSplashScreen_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = this.DisplayRectangle;
            rect.X += 2;
            rect.Y += 2;
            rect.Height -= 6;
            rect.Width -= 6;
            e.Graphics.DrawRectangle(new Pen(Color.Gray, 1), rect);
        }
    }
}
