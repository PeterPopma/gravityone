namespace GravityOne.Forms
{
    partial class FormRandom
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
            this.numericUpDownSpeedRandomness = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSpeed = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownNumberOfObjects = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxAreaUnits = new System.Windows.Forms.ComboBox();
            this.numericUpDownArea = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gradientButtonCreate = new GravityOne.CustomControls.GradientButton();
            this.comboBoxShape = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownMass = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.gradientPanel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeedRandomness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMass)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel21
            // 
            this.gradientPanel21.Controls.Add(this.numericUpDownSpeedRandomness);
            this.gradientPanel21.Controls.Add(this.numericUpDownSpeed);
            this.gradientPanel21.Controls.Add(this.label4);
            this.gradientPanel21.Controls.Add(this.numericUpDownNumberOfObjects);
            this.gradientPanel21.Controls.Add(this.label2);
            this.gradientPanel21.Controls.Add(this.comboBoxAreaUnits);
            this.gradientPanel21.Controls.Add(this.numericUpDownArea);
            this.gradientPanel21.Controls.Add(this.label3);
            this.gradientPanel21.Controls.Add(this.label5);
            this.gradientPanel21.Controls.Add(this.gradientButtonCreate);
            this.gradientPanel21.Controls.Add(this.comboBoxShape);
            this.gradientPanel21.Controls.Add(this.label7);
            this.gradientPanel21.Controls.Add(this.numericUpDownMass);
            this.gradientPanel21.Controls.Add(this.label1);
            this.gradientPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel21.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel21.Name = "gradientPanel21";
            this.gradientPanel21.Size = new System.Drawing.Size(415, 276);
            this.gradientPanel21.TabIndex = 144;
            // 
            // numericUpDownSpeedRandomness
            // 
            this.numericUpDownSpeedRandomness.Location = new System.Drawing.Point(133, 135);
            this.numericUpDownSpeedRandomness.Name = "numericUpDownSpeedRandomness";
            this.numericUpDownSpeedRandomness.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownSpeedRandomness.TabIndex = 164;
            // 
            // numericUpDownSpeed
            // 
            this.numericUpDownSpeed.Location = new System.Drawing.Point(133, 105);
            this.numericUpDownSpeed.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownSpeed.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numericUpDownSpeed.Name = "numericUpDownSpeed";
            this.numericUpDownSpeed.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownSpeed.TabIndex = 163;
            this.numericUpDownSpeed.Value = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(10, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 162;
            this.label4.Text = "Speed randomness (%):";
            // 
            // numericUpDownNumberOfObjects
            // 
            this.numericUpDownNumberOfObjects.Location = new System.Drawing.Point(133, 19);
            this.numericUpDownNumberOfObjects.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDownNumberOfObjects.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNumberOfObjects.Name = "numericUpDownNumberOfObjects";
            this.numericUpDownNumberOfObjects.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownNumberOfObjects.TabIndex = 142;
            this.numericUpDownNumberOfObjects.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(20, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 161;
            this.label2.Text = "Average speed (m/s):";
            // 
            // comboBoxAreaUnits
            // 
            this.comboBoxAreaUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAreaUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAreaUnits.FormattingEnabled = true;
            this.comboBoxAreaUnits.Items.AddRange(new object[] {
            "pixels",
            "million km."});
            this.comboBoxAreaUnits.Location = new System.Drawing.Point(281, 75);
            this.comboBoxAreaUnits.Name = "comboBoxAreaUnits";
            this.comboBoxAreaUnits.Size = new System.Drawing.Size(73, 21);
            this.comboBoxAreaUnits.TabIndex = 160;
            this.comboBoxAreaUnits.SelectedIndexChanged += new System.EventHandler(this.comboBoxAreaUnits_SelectedIndexChanged);
            // 
            // numericUpDownArea
            // 
            this.numericUpDownArea.Location = new System.Drawing.Point(133, 75);
            this.numericUpDownArea.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.numericUpDownArea.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownArea.Name = "numericUpDownArea";
            this.numericUpDownArea.Size = new System.Drawing.Size(142, 20);
            this.numericUpDownArea.TabIndex = 159;
            this.numericUpDownArea.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(89, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 158;
            this.label3.Text = "Area:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(74, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 157;
            this.label5.Text = "Texture:";
            // 
            // gradientButtonCreate
            // 
            this.gradientButtonCreate.Active = false;
            this.gradientButtonCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonCreate.Location = new System.Drawing.Point(131, 225);
            this.gradientButtonCreate.Name = "gradientButtonCreate";
            this.gradientButtonCreate.Size = new System.Drawing.Size(125, 32);
            this.gradientButtonCreate.TabIndex = 87;
            this.gradientButtonCreate.Text = "Create";
            this.gradientButtonCreate.UseVisualStyleBackColor = false;
            this.gradientButtonCreate.Click += new System.EventHandler(this.gradientButtonCreate_Click);
            // 
            // comboBoxShape
            // 
            this.comboBoxShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxShape.FormattingEnabled = true;
            this.comboBoxShape.Items.AddRange(new object[] {
            "<Custom Shape>",
            "Point",
            "Planet",
            "Earth",
            "Sun",
            "Moon",
            "Mercury",
            "Venus",
            "Mars",
            "Jupiter",
            "Saturn",
            "Uranus",
            "Neptune",
            "Pluto",
            "Asteroid",
            "Red Ball",
            "Metal Ball",
            "Golden Ball"});
            this.comboBoxShape.Location = new System.Drawing.Point(133, 166);
            this.comboBoxShape.Name = "comboBoxShape";
            this.comboBoxShape.Size = new System.Drawing.Size(137, 21);
            this.comboBoxShape.TabIndex = 156;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(53, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 145;
            this.label7.Text = "Mass (10²²kg):";
            // 
            // numericUpDownMass
            // 
            this.numericUpDownMass.Location = new System.Drawing.Point(133, 45);
            this.numericUpDownMass.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownMass.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMass.Name = "numericUpDownMass";
            this.numericUpDownMass.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownMass.TabIndex = 143;
            this.numericUpDownMass.Value = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(33, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Number of objects:";
            // 
            // FormRandom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 276);
            this.Controls.Add(this.gradientPanel21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRandom";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Random objects";
            this.gradientPanel21.ResumeLayout(false);
            this.gradientPanel21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeedRandomness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal CustomControls.GradientButton gradientButtonCreate;
        internal System.Windows.Forms.NumericUpDown numericUpDownNumberOfObjects;
        private CustomControls.GradientPanel2 gradientPanel21;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.NumericUpDown numericUpDownMass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox comboBoxShape;
        internal System.Windows.Forms.ComboBox comboBoxAreaUnits;
        internal System.Windows.Forms.NumericUpDown numericUpDownArea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.NumericUpDown numericUpDownSpeedRandomness;
        internal System.Windows.Forms.NumericUpDown numericUpDownSpeed;
        private System.Windows.Forms.Label label4;
    }
}