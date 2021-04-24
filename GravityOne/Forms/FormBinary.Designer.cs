namespace GravityOne.Forms
{
    partial class FormBinary
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonTriple = new System.Windows.Forms.RadioButton();
            this.radioButtonBinaryOnePlanetHopping = new System.Windows.Forms.RadioButton();
            this.radioButtonBinaryOnePlanetStable = new System.Windows.Forms.RadioButton();
            this.radioButtonBinaryTwoPlanets = new System.Windows.Forms.RadioButton();
            this.gradientButtonCreate = new GravityOne.CustomControls.GradientButton();
            this.gradientPanel21 = new GravityOne.CustomControls.GradientPanel2();
            this.panel1.SuspendLayout();
            this.gradientPanel21.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.radioButtonTriple);
            this.panel1.Controls.Add(this.radioButtonBinaryOnePlanetHopping);
            this.panel1.Controls.Add(this.radioButtonBinaryOnePlanetStable);
            this.panel1.Controls.Add(this.radioButtonBinaryTwoPlanets);
            this.panel1.Location = new System.Drawing.Point(36, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 135);
            this.panel1.TabIndex = 0;
            // 
            // radioButtonTriple
            // 
            this.radioButtonTriple.Location = new System.Drawing.Point(24, 91);
            this.radioButtonTriple.Name = "radioButtonTriple";
            this.radioButtonTriple.Size = new System.Drawing.Size(192, 17);
            this.radioButtonTriple.TabIndex = 5;
            this.radioButtonTriple.Text = "triple system, 1 planet orbiting 1 star";
            this.radioButtonTriple.UseVisualStyleBackColor = true;
            // 
            // radioButtonBinaryOnePlanetHopping
            // 
            this.radioButtonBinaryOnePlanetHopping.Location = new System.Drawing.Point(24, 64);
            this.radioButtonBinaryOnePlanetHopping.Name = "radioButtonBinaryOnePlanetHopping";
            this.radioButtonBinaryOnePlanetHopping.Size = new System.Drawing.Size(184, 17);
            this.radioButtonBinaryOnePlanetHopping.TabIndex = 4;
            this.radioButtonBinaryOnePlanetHopping.Text = "1 planet orbiting each star in turns";
            this.radioButtonBinaryOnePlanetHopping.UseVisualStyleBackColor = true;
            // 
            // radioButtonBinaryOnePlanetStable
            // 
            this.radioButtonBinaryOnePlanetStable.Location = new System.Drawing.Point(24, 39);
            this.radioButtonBinaryOnePlanetStable.Name = "radioButtonBinaryOnePlanetStable";
            this.radioButtonBinaryOnePlanetStable.Size = new System.Drawing.Size(149, 17);
            this.radioButtonBinaryOnePlanetStable.TabIndex = 3;
            this.radioButtonBinaryOnePlanetStable.Text = "1 planet orbiting both stars";
            this.radioButtonBinaryOnePlanetStable.UseVisualStyleBackColor = true;
            // 
            // radioButtonBinaryTwoPlanets
            // 
            this.radioButtonBinaryTwoPlanets.Checked = true;
            this.radioButtonBinaryTwoPlanets.Location = new System.Drawing.Point(24, 13);
            this.radioButtonBinaryTwoPlanets.Name = "radioButtonBinaryTwoPlanets";
            this.radioButtonBinaryTwoPlanets.Size = new System.Drawing.Size(112, 17);
            this.radioButtonBinaryTwoPlanets.TabIndex = 2;
            this.radioButtonBinaryTwoPlanets.TabStop = true;
            this.radioButtonBinaryTwoPlanets.Text = "both stars 1 planet";
            this.radioButtonBinaryTwoPlanets.UseVisualStyleBackColor = true;
            // 
            // gradientButtonCreate
            // 
            this.gradientButtonCreate.Active = false;
            this.gradientButtonCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonCreate.Location = new System.Drawing.Point(82, 146);
            this.gradientButtonCreate.Name = "gradientButtonCreate";
            this.gradientButtonCreate.Size = new System.Drawing.Size(127, 32);
            this.gradientButtonCreate.TabIndex = 148;
            this.gradientButtonCreate.Text = "Create";
            this.gradientButtonCreate.UseVisualStyleBackColor = false;
            this.gradientButtonCreate.Click += new System.EventHandler(this.gradientButtonCreate_Click);
            // 
            // gradientPanel21
            // 
            this.gradientPanel21.Controls.Add(this.gradientButtonCreate);
            this.gradientPanel21.Controls.Add(this.panel1);
            this.gradientPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel21.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel21.Name = "gradientPanel21";
            this.gradientPanel21.Size = new System.Drawing.Size(284, 193);
            this.gradientPanel21.TabIndex = 149;
            // 
            // FormBinary
            // 
            this.ClientSize = new System.Drawing.Size(284, 193);
            this.Controls.Add(this.gradientPanel21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBinary";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Binary System";
            this.panel1.ResumeLayout(false);
            this.gradientPanel21.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonBinaryOnePlanetHopping;
        private System.Windows.Forms.RadioButton radioButtonBinaryOnePlanetStable;
        private System.Windows.Forms.RadioButton radioButtonBinaryTwoPlanets;
        internal CustomControls.GradientButton gradientButtonCreate;
        private CustomControls.GradientPanel2 gradientPanel21;
        private System.Windows.Forms.RadioButton radioButtonTriple;
    }
}