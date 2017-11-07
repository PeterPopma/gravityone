namespace GravityOne.Forms
{
    partial class FormCircle
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
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.numericUpDownYSpeed = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownXSpeed = new System.Windows.Forms.NumericUpDown();
            this.comboBoxSpacingUnits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxShape = new System.Windows.Forms.ComboBox();
            this.numericUpDownRotations = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownSpacing = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMass = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gradientButtonCreate = new GravityOne.CustomControls.GradientButton();
            this.numericUpDownNumObjectsRadius = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gradientPanel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumObjectsRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel21
            // 
            this.gradientPanel21.Controls.Add(this.button1);
            this.gradientPanel21.Controls.Add(this.label25);
            this.gradientPanel21.Controls.Add(this.label24);
            this.gradientPanel21.Controls.Add(this.label23);
            this.gradientPanel21.Controls.Add(this.label22);
            this.gradientPanel21.Controls.Add(this.numericUpDownYSpeed);
            this.gradientPanel21.Controls.Add(this.numericUpDownXSpeed);
            this.gradientPanel21.Controls.Add(this.comboBoxSpacingUnits);
            this.gradientPanel21.Controls.Add(this.label5);
            this.gradientPanel21.Controls.Add(this.comboBoxShape);
            this.gradientPanel21.Controls.Add(this.numericUpDownRotations);
            this.gradientPanel21.Controls.Add(this.label4);
            this.gradientPanel21.Controls.Add(this.numericUpDownSpacing);
            this.gradientPanel21.Controls.Add(this.numericUpDownMass);
            this.gradientPanel21.Controls.Add(this.label3);
            this.gradientPanel21.Controls.Add(this.label2);
            this.gradientPanel21.Controls.Add(this.gradientButtonCreate);
            this.gradientPanel21.Controls.Add(this.numericUpDownNumObjectsRadius);
            this.gradientPanel21.Controls.Add(this.label1);
            this.gradientPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel21.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel21.Name = "gradientPanel21";
            this.gradientPanel21.Size = new System.Drawing.Size(472, 306);
            this.gradientPanel21.TabIndex = 146;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label25.Location = new System.Drawing.Point(265, 205);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(25, 13);
            this.label25.TabIndex = 162;
            this.label25.Text = "m/s";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label24.Location = new System.Drawing.Point(265, 173);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(25, 13);
            this.label24.TabIndex = 161;
            this.label24.Text = "m/s";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label23.Location = new System.Drawing.Point(82, 204);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 13);
            this.label23.TabIndex = 160;
            this.label23.Text = "Vertical speed:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label22.Location = new System.Drawing.Point(71, 173);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(89, 13);
            this.label22.TabIndex = 159;
            this.label22.Text = "Horizontal speed:";
            // 
            // numericUpDownYSpeed
            // 
            this.numericUpDownYSpeed.Location = new System.Drawing.Point(164, 202);
            this.numericUpDownYSpeed.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownYSpeed.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numericUpDownYSpeed.Name = "numericUpDownYSpeed";
            this.numericUpDownYSpeed.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownYSpeed.TabIndex = 158;
            this.numericUpDownYSpeed.ThousandsSeparator = true;
            // 
            // numericUpDownXSpeed
            // 
            this.numericUpDownXSpeed.Location = new System.Drawing.Point(164, 171);
            this.numericUpDownXSpeed.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownXSpeed.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numericUpDownXSpeed.Name = "numericUpDownXSpeed";
            this.numericUpDownXSpeed.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownXSpeed.TabIndex = 157;
            this.numericUpDownXSpeed.ThousandsSeparator = true;
            // 
            // comboBoxSpacingUnits
            // 
            this.comboBoxSpacingUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpacingUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSpacingUnits.FormattingEnabled = true;
            this.comboBoxSpacingUnits.Items.AddRange(new object[] {
            "pixels",
            "million km."});
            this.comboBoxSpacingUnits.Location = new System.Drawing.Point(315, 74);
            this.comboBoxSpacingUnits.Name = "comboBoxSpacingUnits";
            this.comboBoxSpacingUnits.Size = new System.Drawing.Size(73, 21);
            this.comboBoxSpacingUnits.TabIndex = 156;
            this.comboBoxSpacingUnits.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpacingUnits_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(106, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 155;
            this.label5.Text = "Texture:";
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
            this.comboBoxShape.Location = new System.Drawing.Point(165, 136);
            this.comboBoxShape.Name = "comboBoxShape";
            this.comboBoxShape.Size = new System.Drawing.Size(137, 21);
            this.comboBoxShape.TabIndex = 154;
            // 
            // numericUpDownRotations
            // 
            this.numericUpDownRotations.DecimalPlaces = 2;
            this.numericUpDownRotations.Location = new System.Drawing.Point(165, 105);
            this.numericUpDownRotations.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownRotations.Name = "numericUpDownRotations";
            this.numericUpDownRotations.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownRotations.TabIndex = 153;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(56, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 152;
            this.label4.Text = "Rotations per year:";
            // 
            // numericUpDownSpacing
            // 
            this.numericUpDownSpacing.Location = new System.Drawing.Point(165, 74);
            this.numericUpDownSpacing.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.numericUpDownSpacing.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSpacing.Name = "numericUpDownSpacing";
            this.numericUpDownSpacing.Size = new System.Drawing.Size(144, 20);
            this.numericUpDownSpacing.TabIndex = 151;
            this.numericUpDownSpacing.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numericUpDownMass
            // 
            this.numericUpDownMass.Location = new System.Drawing.Point(165, 44);
            this.numericUpDownMass.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numericUpDownMass.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMass.Name = "numericUpDownMass";
            this.numericUpDownMass.Size = new System.Drawing.Size(144, 20);
            this.numericUpDownMass.TabIndex = 150;
            this.numericUpDownMass.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(102, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 149;
            this.label3.Text = "Spacing:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(47, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 148;
            this.label2.Text = "Object mass (10²²kg):";
            // 
            // gradientButtonCreate
            // 
            this.gradientButtonCreate.Active = false;
            this.gradientButtonCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonCreate.Location = new System.Drawing.Point(166, 251);
            this.gradientButtonCreate.Name = "gradientButtonCreate";
            this.gradientButtonCreate.Size = new System.Drawing.Size(127, 32);
            this.gradientButtonCreate.TabIndex = 147;
            this.gradientButtonCreate.Text = "Create";
            this.gradientButtonCreate.UseVisualStyleBackColor = false;
            this.gradientButtonCreate.Click += new System.EventHandler(this.gradientButtonCreate_Click);
            // 
            // numericUpDownNumObjectsRadius
            // 
            this.numericUpDownNumObjectsRadius.Location = new System.Drawing.Point(165, 13);
            this.numericUpDownNumObjectsRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownNumObjectsRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumObjectsRadius.Name = "numericUpDownNumObjectsRadius";
            this.numericUpDownNumObjectsRadius.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownNumObjectsRadius.TabIndex = 146;
            this.numericUpDownNumObjectsRadius.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(22, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Number of objects in radius:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(360, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 54);
            this.button1.TabIndex = 163;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormCircle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 306);
            this.Controls.Add(this.gradientPanel21);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCircle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create a circle of objects";
            this.gradientPanel21.ResumeLayout(false);
            this.gradientPanel21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumObjectsRadius)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.GradientPanel2 gradientPanel21;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox comboBoxShape;
        internal System.Windows.Forms.NumericUpDown numericUpDownRotations;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.NumericUpDown numericUpDownSpacing;
        internal System.Windows.Forms.NumericUpDown numericUpDownMass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal CustomControls.GradientButton gradientButtonCreate;
        internal System.Windows.Forms.NumericUpDown numericUpDownNumObjectsRadius;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox comboBoxSpacingUnits;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.NumericUpDown numericUpDownYSpeed;
        internal System.Windows.Forms.NumericUpDown numericUpDownXSpeed;
        private System.Windows.Forms.Button button1;
    }
}