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
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gradientButtonMoonMoon = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonSunPlanetMoon = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonPlanetSun = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonPlanetMoon = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonNeighbourhood = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonSolarSystemMoons = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonSolarSystem = new GravityOne.CustomControls.GradientButton();
            this.gradientPanel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel21
            // 
            this.gradientPanel21.Controls.Add(this.pictureBoxPreview);
            this.gradientPanel21.Controls.Add(this.panel1);
            this.gradientPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel21.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel21.Name = "gradientPanel21";
            this.gradientPanel21.Size = new System.Drawing.Size(762, 394);
            this.gradientPanel21.TabIndex = 151;
            this.gradientPanel21.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gradientPanel21_MouseMove);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBoxPreview.Location = new System.Drawing.Point(396, 34);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxPreview.TabIndex = 155;
            this.pictureBoxPreview.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.gradientButtonMoonMoon);
            this.panel1.Controls.Add(this.gradientButtonSunPlanetMoon);
            this.panel1.Controls.Add(this.gradientButtonPlanetSun);
            this.panel1.Controls.Add(this.gradientButtonPlanetMoon);
            this.panel1.Controls.Add(this.gradientButtonNeighbourhood);
            this.panel1.Controls.Add(this.gradientButtonSolarSystemMoons);
            this.panel1.Controls.Add(this.gradientButtonSolarSystem);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 368);
            this.panel1.TabIndex = 154;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // gradientButtonMoonMoon
            // 
            this.gradientButtonMoonMoon.Active = false;
            this.gradientButtonMoonMoon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonMoonMoon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonMoonMoon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonMoonMoon.Location = new System.Drawing.Point(13, 320);
            this.gradientButtonMoonMoon.Name = "gradientButtonMoonMoon";
            this.gradientButtonMoonMoon.Size = new System.Drawing.Size(291, 32);
            this.gradientButtonMoonMoon.TabIndex = 155;
            this.gradientButtonMoonMoon.Text = "A moon orbiting a moon";
            this.gradientButtonMoonMoon.UseVisualStyleBackColor = false;
            this.gradientButtonMoonMoon.Click += new System.EventHandler(this.gradientButton7_Click);
            this.gradientButtonMoonMoon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gradientButton7_MouseMove);
            // 
            // gradientButtonSunPlanetMoon
            // 
            this.gradientButtonSunPlanetMoon.Active = false;
            this.gradientButtonSunPlanetMoon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonSunPlanetMoon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonSunPlanetMoon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonSunPlanetMoon.Location = new System.Drawing.Point(13, 270);
            this.gradientButtonSunPlanetMoon.Name = "gradientButtonSunPlanetMoon";
            this.gradientButtonSunPlanetMoon.Size = new System.Drawing.Size(291, 32);
            this.gradientButtonSunPlanetMoon.TabIndex = 154;
            this.gradientButtonSunPlanetMoon.Text = "A sun, planet and moon";
            this.gradientButtonSunPlanetMoon.UseVisualStyleBackColor = false;
            this.gradientButtonSunPlanetMoon.Click += new System.EventHandler(this.gradientButton2_Click);
            this.gradientButtonSunPlanetMoon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gradientButton2_MouseMove);
            // 
            // gradientButtonPlanetSun
            // 
            this.gradientButtonPlanetSun.Active = false;
            this.gradientButtonPlanetSun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonPlanetSun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonPlanetSun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonPlanetSun.Location = new System.Drawing.Point(13, 220);
            this.gradientButtonPlanetSun.Name = "gradientButtonPlanetSun";
            this.gradientButtonPlanetSun.Size = new System.Drawing.Size(291, 32);
            this.gradientButtonPlanetSun.TabIndex = 153;
            this.gradientButtonPlanetSun.Text = "Planet orbiting a sun";
            this.gradientButtonPlanetSun.UseVisualStyleBackColor = false;
            this.gradientButtonPlanetSun.Click += new System.EventHandler(this.gradientButtonPlanetSun_Click);
            this.gradientButtonPlanetSun.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gradientButtonPlanetSun_MouseMove);
            // 
            // gradientButtonPlanetMoon
            // 
            this.gradientButtonPlanetMoon.Active = false;
            this.gradientButtonPlanetMoon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonPlanetMoon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonPlanetMoon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonPlanetMoon.Location = new System.Drawing.Point(13, 170);
            this.gradientButtonPlanetMoon.Name = "gradientButtonPlanetMoon";
            this.gradientButtonPlanetMoon.Size = new System.Drawing.Size(291, 32);
            this.gradientButtonPlanetMoon.TabIndex = 152;
            this.gradientButtonPlanetMoon.Text = "Moon orbiting a planet";
            this.gradientButtonPlanetMoon.UseVisualStyleBackColor = false;
            this.gradientButtonPlanetMoon.Click += new System.EventHandler(this.gradientButtonPlanetMoon_Click);
            this.gradientButtonPlanetMoon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gradientButtonPlanetMoon_MouseMove);
            // 
            // gradientButtonNeighbourhood
            // 
            this.gradientButtonNeighbourhood.Active = false;
            this.gradientButtonNeighbourhood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonNeighbourhood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonNeighbourhood.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonNeighbourhood.Location = new System.Drawing.Point(13, 120);
            this.gradientButtonNeighbourhood.Name = "gradientButtonNeighbourhood";
            this.gradientButtonNeighbourhood.Size = new System.Drawing.Size(291, 32);
            this.gradientButtonNeighbourhood.TabIndex = 151;
            this.gradientButtonNeighbourhood.Text = "Our galactic neighbourhood";
            this.gradientButtonNeighbourhood.UseVisualStyleBackColor = false;
            this.gradientButtonNeighbourhood.Click += new System.EventHandler(this.gradientButtonNeighbourhood_Click);
            this.gradientButtonNeighbourhood.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gradientButtonNeighbourhood_MouseMove);
            // 
            // gradientButtonSolarSystemMoons
            // 
            this.gradientButtonSolarSystemMoons.Active = false;
            this.gradientButtonSolarSystemMoons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonSolarSystemMoons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonSolarSystemMoons.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonSolarSystemMoons.Location = new System.Drawing.Point(13, 70);
            this.gradientButtonSolarSystemMoons.Name = "gradientButtonSolarSystemMoons";
            this.gradientButtonSolarSystemMoons.Size = new System.Drawing.Size(291, 32);
            this.gradientButtonSolarSystemMoons.TabIndex = 150;
            this.gradientButtonSolarSystemMoons.Text = "Solar System with all major moons";
            this.gradientButtonSolarSystemMoons.UseVisualStyleBackColor = false;
            this.gradientButtonSolarSystemMoons.Click += new System.EventHandler(this.gradientButtonSolarSystemMoons_Click_1);
            this.gradientButtonSolarSystemMoons.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gradientButtonSolarSystemMoons_MouseMove);
            // 
            // gradientButtonSolarSystem
            // 
            this.gradientButtonSolarSystem.Active = false;
            this.gradientButtonSolarSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonSolarSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonSolarSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonSolarSystem.Location = new System.Drawing.Point(13, 20);
            this.gradientButtonSolarSystem.Name = "gradientButtonSolarSystem";
            this.gradientButtonSolarSystem.Size = new System.Drawing.Size(291, 32);
            this.gradientButtonSolarSystem.TabIndex = 149;
            this.gradientButtonSolarSystem.Text = "Solar System";
            this.gradientButtonSolarSystem.UseVisualStyleBackColor = false;
            this.gradientButtonSolarSystem.Click += new System.EventHandler(this.gradientButtonSolarSystem_Click);
            this.gradientButtonSolarSystem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gradientButtonSolarSystem_MouseMove);
            // 
            // FormPlanetSystems
            // 
            this.ClientSize = new System.Drawing.Size(762, 394);
            this.Controls.Add(this.gradientPanel21);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPlanetSystems";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create solar system";
            this.gradientPanel21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CustomControls.GradientPanel2 gradientPanel21;
        private System.Windows.Forms.Panel panel1;
        internal CustomControls.GradientButton gradientButtonMoonMoon;
        internal CustomControls.GradientButton gradientButtonSunPlanetMoon;
        internal CustomControls.GradientButton gradientButtonPlanetSun;
        internal CustomControls.GradientButton gradientButtonPlanetMoon;
        internal CustomControls.GradientButton gradientButtonNeighbourhood;
        internal CustomControls.GradientButton gradientButtonSolarSystemMoons;
        internal CustomControls.GradientButton gradientButtonSolarSystem;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
    }
}