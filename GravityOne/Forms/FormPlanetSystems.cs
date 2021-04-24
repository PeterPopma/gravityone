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

        private void gradientButtonSolarSystem_Click(object sender, EventArgs e)
        {
            myParent.gradientButtonPlanetSystems.ForeColor = Color.Coral;
            myParent.DisplayXNA.ShowClickMessage = true;
            this.Cursor = Cursors.Hand;
            FormMain.PlacingObject = PlacingObject_.SolarSystem;
            Close();
        }

        private void gradientButtonSolarSystemMoons_Click_1(object sender, EventArgs e)
        {
            myParent.gradientButtonPlanetSystems.ForeColor = Color.Coral;
            myParent.DisplayXNA.ShowClickMessage = true;
            this.Cursor = Cursors.Hand;
            FormMain.PlacingObject = PlacingObject_.SolarSystemMoons;
            Close();
        }

        private void gradientButtonPlanetMoon_Click(object sender, EventArgs e)
        {
            myParent.gradientButtonPlanetSystems.ForeColor = Color.Coral;
            myParent.DisplayXNA.ShowClickMessage = true;
            this.Cursor = Cursors.Hand;
            FormMain.PlacingObject = PlacingObject_.PlanetMoon;
            Close();
        }

        private void gradientButtonPlanetSun_Click(object sender, EventArgs e)
        {
            myParent.gradientButtonPlanetSystems.ForeColor = Color.Coral;
            myParent.DisplayXNA.ShowClickMessage = true;
            this.Cursor = Cursors.Hand;
            FormMain.PlacingObject = PlacingObject_.SunPlanet;
            Close();
        }

        private void gradientButtonNeighbourhood_Click(object sender, EventArgs e)
        {
            myParent.gradientButtonPlanetSystems.ForeColor = Color.Coral;
            myParent.DisplayXNA.ShowClickMessage = true;
            this.Cursor = Cursors.Hand;
            FormMain.PlacingObject = PlacingObject_.Neighbourhood;
            Close();
        }

        private void gradientButton7_Click(object sender, EventArgs e)
        {
            myParent.gradientButtonPlanetSystems.ForeColor = Color.Coral;
            myParent.DisplayXNA.ShowClickMessage = true;
            this.Cursor = Cursors.Hand;
            FormMain.PlacingObject = PlacingObject_.MoonMoon;
            Close();
        }

        private void gradientButton2_Click(object sender, EventArgs e)
        {
            myParent.gradientButtonPlanetSystems.ForeColor = Color.Coral;
            myParent.DisplayXNA.ShowClickMessage = true;
            this.Cursor = Cursors.Hand;
            FormMain.PlacingObject = PlacingObject_.SunPlanetMoon;
            Close();
        }

        private void gradientButtonSolarSystem_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxPreview.Image = Resources.example_solarsystem;
        }

        private void gradientPanel21_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxPreview.Image = null;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void gradientButtonSolarSystemMoons_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxPreview.Image = Resources.example_solarsystemmoons;
        }

        private void gradientButtonNeighbourhood_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxPreview.Image = Resources.example_neighbourhood;
        }

        private void gradientButtonPlanetMoon_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxPreview.Image = Resources.example_planetmoon;
        }

        private void gradientButtonPlanetSun_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxPreview.Image = Resources.example_planetsun;
        }

        private void gradientButton2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxPreview.Image = Resources.sunplanetmoon;
        }

        private void gradientButton7_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxPreview.Image = Resources.moonmoon;
        }
    }
}
