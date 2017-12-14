namespace GravityOne.Forms
{
    partial class FormPlanetSystems
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gradientPanel21 = new GravityOne.CustomControls.GradientPanel2();
            this.gradientButtonCreate = new GravityOne.CustomControls.GradientButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonMoonMoon = new System.Windows.Forms.RadioButton();
            this.radioButtonSunPlanetMoon = new System.Windows.Forms.RadioButton();
            this.radioButtonSunPlanet = new System.Windows.Forms.RadioButton();
            this.radioButtonPlanetMoon = new System.Windows.Forms.RadioButton();
            this.radioButtonSolarMoons = new System.Windows.Forms.RadioButton();
            this.gradientPanel21.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel21
            // 
            this.gradientPanel21.Controls.Add(this.gradientButtonCreate);
            this.gradientPanel21.Controls.Add(this.panel2);
            this.gradientPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel21.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel21.Name = "gradientPanel21";
            this.gradientPanel21.Size = new System.Drawing.Size(284, 246);
            this.gradientPanel21.TabIndex = 151;
            // 
            // gradientButtonCreate
            // 
            this.gradientButtonCreate.Active = false;
            this.gradientButtonCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonCreate.Location = new System.Drawing.Point(83, 190);
            this.gradientButtonCreate.Name = "gradientButtonCreate";
            this.gradientButtonCreate.Size = new System.Drawing.Size(127, 32);
            this.gradientButtonCreate.TabIndex = 148;
            this.gradientButtonCreate.Text = "Create";
            this.gradientButtonCreate.UseVisualStyleBackColor = false;
            this.gradientButtonCreate.Click += new System.EventHandler(this.gradientButtonCreate_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.radioButtonMoonMoon);
            this.panel2.Controls.Add(this.radioButtonSunPlanetMoon);
            this.panel2.Controls.Add(this.radioButtonSunPlanet);
            this.panel2.Controls.Add(this.radioButtonPlanetMoon);
            this.panel2.Controls.Add(this.radioButtonSolarMoons);
            this.panel2.Location = new System.Drawing.Point(33, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(219, 159);
            this.panel2.TabIndex = 0;
            // 
            // radioButtonMoonMoon
            // 
            this.radioButtonMoonMoon.AutoSize = false;
            this.radioButtonMoonMoon.Location = new System.Drawing.Point(24, 118);
            this.radioButtonMoonMoon.Name = "radioButtonMoonMoon";
            this.radioButtonMoonMoon.Size = new System.Drawing.Size(136, 17);
            this.radioButtonMoonMoon.TabIndex = 6;
            this.radioButtonMoonMoon.Text = "A moon orbiting a moon";
            this.radioButtonMoonMoon.UseVisualStyleBackColor = true;
            // 
            // radioButtonSunPlanetMoon
            // 
            this.radioButtonSunPlanetMoon.AutoSize = false;
            this.radioButtonSunPlanetMoon.Location = new System.Drawing.Point(24, 91);
            this.radioButtonSunPlanetMoon.Name = "radioButtonSunPlanetMoon";
            this.radioButtonSunPlanetMoon.Size = new System.Drawing.Size(137, 17);
            this.radioButtonSunPlanetMoon.TabIndex = 5;
            this.radioButtonSunPlanetMoon.Text = "A sun, planet and moon";
            this.radioButtonSunPlanetMoon.UseVisualStyleBackColor = true;
            // 
            // radioButtonSunPlanet
            // 
            this.radioButtonSunPlanet.AutoSize = false;
            this.radioButtonSunPlanet.Location = new System.Drawing.Point(24, 64);
            this.radioButtonSunPlanet.Name = "radioButtonSunPlanet";
            this.radioButtonSunPlanet.Size = new System.Drawing.Size(121, 17);
            this.radioButtonSunPlanet.TabIndex = 4;
            this.radioButtonSunPlanet.Text = "Planet orbiting a sun";
            this.radioButtonSunPlanet.UseVisualStyleBackColor = true;
            // 
            // radioButtonPlanetMoon
            // 
            this.radioButtonPlanetMoon.AutoSize = false;
            this.radioButtonPlanetMoon.Location = new System.Drawing.Point(24, 39);
            this.radioButtonPlanetMoon.Name = "radioButtonPlanetMoon";
            this.radioButtonPlanetMoon.Size = new System.Drawing.Size(130, 17);
            this.radioButtonPlanetMoon.TabIndex = 3;
            this.radioButtonPlanetMoon.Text = "Moon orbiting a planet";
            this.radioButtonPlanetMoon.UseVisualStyleBackColor = true;
            // 
            // radioButtonSolarMoons
            // 
            this.radioButtonSolarMoons.AutoSize = false;
            this.radioButtonSolarMoons.Checked = true;
            this.radioButtonSolarMoons.Location = new System.Drawing.Point(24, 13);
            this.radioButtonSolarMoons.Name = "radioButtonSolarMoons";
            this.radioButtonSolarMoons.Size = new System.Drawing.Size(183, 17);
            this.radioButtonSolarMoons.TabIndex = 2;
            this.radioButtonSolarMoons.TabStop = true;
            this.radioButtonSolarMoons.Text = "Solar System with all major moons";
            this.radioButtonSolarMoons.UseVisualStyleBackColor = true;
            // 
            // FormPlanetSystems
            // 
            this.ClientSize = new System.Drawing.Size(284, 246);
            this.Controls.Add(this.gradientPanel21);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPlanetSystems";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create planetary system";
            this.gradientPanel21.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private CustomControls.GradientPanel2 gradientPanel21;
        internal CustomControls.GradientButton gradientButtonCreate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButtonSunPlanetMoon;
        private System.Windows.Forms.RadioButton radioButtonSunPlanet;
        private System.Windows.Forms.RadioButton radioButtonPlanetMoon;
        private System.Windows.Forms.RadioButton radioButtonSolarMoons;
        private System.Windows.Forms.RadioButton radioButtonMoonMoon;
    }
}