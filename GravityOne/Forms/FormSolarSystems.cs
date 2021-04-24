using GravityOne.Gravity;
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
    public partial class FormSolarSystems : Form
    {
        private FormMain myParent = null;

        private GravityObject selectedSolarSystem;
        private List<GravityObject> solarSystems;

        public FormSolarSystems()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            solarSystems = myParent.DisplayXNA.GravitySystem.GetSolarSystems();
            comboBoxSolarSystems.Items.AddRange(solarSystems.Select(o => o.Name).ToArray());
            comboBoxSolarSystems.SelectedIndex = 0;
        }

        public FormMain MyParent { get => myParent; set => myParent = value; }

        private void gradientButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxSolarSystems_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSolarSystem = solarSystems[comboBoxSolarSystems.SelectedIndex];
            textBoxName.Text = selectedSolarSystem.Name;
            labelXPos.Text = selectedSolarSystem.X.ToString();
            labelYPos.Text = selectedSolarSystem.Y.ToString();
            textBoxXSpeed.Text = selectedSolarSystem.XSpeed.ToString();
            textBoxYSpeed.Text = selectedSolarSystem.YSpeed.ToString();
            labelMass.Text = selectedSolarSystem.Mass.ToString();
            labelNumObjects.Text = selectedSolarSystem.NumObjects.ToString();
            checkBoxActive.Checked = selectedSolarSystem.IsActive;
            comboBoxObjects.Items.Clear();
            comboBoxObjects.Items.AddRange(myParent.DisplayXNA.GravitySystem.getSolarSystemObjects(selectedSolarSystem).Select(o => o.Name).ToArray());
            comboBoxObjects.SelectedIndex = 0;
        }

        private void gradientButtonUpdate_Click(object sender, EventArgs e)
        {
            selectedSolarSystem.Name = textBoxName.Text;
            selectedSolarSystem.XSpeed = Convert.ToDouble(textBoxXSpeed.Text);
            selectedSolarSystem.YSpeed = Convert.ToDouble(textBoxYSpeed.Text);
            myParent.UpdateObjectValues();
            comboBoxSolarSystems.Items[comboBoxSolarSystems.SelectedIndex] = selectedSolarSystem.Name;
            selectedSolarSystem.IsActive = checkBoxActive.Checked;
        }
    }
}
