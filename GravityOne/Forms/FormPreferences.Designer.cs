namespace GravityOne.Forms
{
    partial class FormPreferences
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
            this.folderBrowserDialogSaveDir = new System.Windows.Forms.FolderBrowserDialog();
            this.gradientPanel21 = new GravityOne.CustomControls.GradientPanel2();
            this.gradientButtonCancel = new GravityOne.CustomControls.GradientButton();
            this.label23 = new System.Windows.Forms.Label();
            this.dateTimePickerCurrentTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCurrentDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPrecalcTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFrameRate = new System.Windows.Forms.TextBox();
            this.gradientButtonSave = new GravityOne.CustomControls.GradientButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDownVideoFPS = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.comboBoxCaptureCompression = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownAccelerationLimit = new System.Windows.Forms.NumericUpDown();
            this.checkBoxPrecalcAutoIncrease = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDownMinimumTextureSize = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.numericUpDownBarnesHutTreshold = new System.Windows.Forms.NumericUpDown();
            this.checkBoxUseBarnesHut = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxBlendMode = new System.Windows.Forms.ComboBox();
            this.comboBoxBackground = new System.Windows.Forms.ComboBox();
            this.checkBoxCompressRecordings = new System.Windows.Forms.CheckBox();
            this.gradientButtonNow = new GravityOne.CustomControls.GradientButton();
            this.textBoxSaveDir = new System.Windows.Forms.TextBox();
            this.numericUpDownGravitationalConstant = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownPrecalculationIncrease = new System.Windows.Forms.NumericUpDown();
            this.gradientButtonResetToDefaults = new GravityOne.CustomControls.GradientButton();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSaveDir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxRandomColor = new System.Windows.Forms.CheckBox();
            this.radioButtonCross = new System.Windows.Forms.RadioButton();
            this.checkBoxRandomSize = new System.Windows.Forms.CheckBox();
            this.comboBoxColorCoding = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.numericUpDownAlpha = new System.Windows.Forms.NumericUpDown();
            this.radioButtonRound = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDownPixelSize = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.radioButtonSquare = new System.Windows.Forms.RadioButton();
            this.checkBoxAllDots = new System.Windows.Forms.CheckBox();
            this.checkBoxShowScale = new System.Windows.Forms.CheckBox();
            this.gradientPanel21.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVideoFPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAccelerationLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinimumTextureSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBarnesHutTreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGravitationalConstant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecalculationIncrease)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPixelSize)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel21
            // 
            this.gradientPanel21.Controls.Add(this.gradientButtonCancel);
            this.gradientPanel21.Controls.Add(this.label23);
            this.gradientPanel21.Controls.Add(this.dateTimePickerCurrentTime);
            this.gradientPanel21.Controls.Add(this.dateTimePickerCurrentDate);
            this.gradientPanel21.Controls.Add(this.label4);
            this.gradientPanel21.Controls.Add(this.label3);
            this.gradientPanel21.Controls.Add(this.textBoxPrecalcTime);
            this.gradientPanel21.Controls.Add(this.label2);
            this.gradientPanel21.Controls.Add(this.label1);
            this.gradientPanel21.Controls.Add(this.textBoxFrameRate);
            this.gradientPanel21.Controls.Add(this.gradientButtonSave);
            this.gradientPanel21.Controls.Add(this.panel1);
            this.gradientPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel21.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel21.Name = "gradientPanel21";
            this.gradientPanel21.Size = new System.Drawing.Size(717, 583);
            this.gradientPanel21.TabIndex = 51;
            this.gradientPanel21.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientPanel21_Paint);
            // 
            // gradientButtonCancel
            // 
            this.gradientButtonCancel.Active = false;
            this.gradientButtonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonCancel.Location = new System.Drawing.Point(439, 537);
            this.gradientButtonCancel.Name = "gradientButtonCancel";
            this.gradientButtonCancel.Size = new System.Drawing.Size(127, 32);
            this.gradientButtonCancel.TabIndex = 50;
            this.gradientButtonCancel.Text = "Cancel";
            this.gradientButtonCancel.UseVisualStyleBackColor = false;
            this.gradientButtonCancel.Click += new System.EventHandler(this.gradientButtonCancel_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = false;
            this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label23.Location = new System.Drawing.Point(126, 136);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(68, 13);
            this.label23.TabIndex = 83;
            this.label23.Text = "Background:";
            // 
            // dateTimePickerCurrentTime
            // 
            this.dateTimePickerCurrentTime.CustomFormat = "";
            this.dateTimePickerCurrentTime.Location = new System.Drawing.Point(327, 31);
            this.dateTimePickerCurrentTime.Name = "dateTimePickerCurrentTime";
            this.dateTimePickerCurrentTime.Size = new System.Drawing.Size(79, 20);
            this.dateTimePickerCurrentTime.TabIndex = 60;
            // 
            // dateTimePickerCurrentDate
            // 
            this.dateTimePickerCurrentDate.CustomFormat = "";
            this.dateTimePickerCurrentDate.Location = new System.Drawing.Point(210, 31);
            this.dateTimePickerCurrentDate.Name = "dateTimePickerCurrentDate";
            this.dateTimePickerCurrentDate.Size = new System.Drawing.Size(113, 20);
            this.dateTimePickerCurrentDate.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = false;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(65, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "Simulation start date+time:";
            // 
            // label3
            // 
            this.label3.AutoSize = false;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(59, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Directory saved recordings:";
            // 
            // textBoxPrecalcTime
            // 
            this.textBoxPrecalcTime.Location = new System.Drawing.Point(210, 80);
            this.textBoxPrecalcTime.Name = "textBoxPrecalcTime";
            this.textBoxPrecalcTime.Size = new System.Drawing.Size(78, 20);
            this.textBoxPrecalcTime.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = false;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(18, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Length Precalculated Sequence (s):";
            // 
            // label1
            // 
            this.label1.AutoSize = false;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(42, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Target framerate (frames/sec,):";
            // 
            // textBoxFrameRate
            // 
            this.textBoxFrameRate.Location = new System.Drawing.Point(210, 56);
            this.textBoxFrameRate.Name = "textBoxFrameRate";
            this.textBoxFrameRate.Size = new System.Drawing.Size(78, 20);
            this.textBoxFrameRate.TabIndex = 50;
            // 
            // gradientButtonSave
            // 
            this.gradientButtonSave.Active = false;
            this.gradientButtonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonSave.Location = new System.Drawing.Point(111, 539);
            this.gradientButtonSave.Name = "gradientButtonSave";
            this.gradientButtonSave.Size = new System.Drawing.Size(127, 32);
            this.gradientButtonSave.TabIndex = 49;
            this.gradientButtonSave.Text = "Save";
            this.gradientButtonSave.UseVisualStyleBackColor = false;
            this.gradientButtonSave.Click += new System.EventHandler(this.gradientButtonSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.checkBoxShowScale);
            this.panel1.Controls.Add(this.checkBoxAllDots);
            this.panel1.Controls.Add(this.numericUpDownVideoFPS);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.comboBoxCaptureCompression);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.numericUpDownAccelerationLimit);
            this.panel1.Controls.Add(this.checkBoxPrecalcAutoIncrease);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.numericUpDownMinimumTextureSize);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.numericUpDownBarnesHutTreshold);
            this.panel1.Controls.Add(this.checkBoxUseBarnesHut);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.comboBoxBlendMode);
            this.panel1.Controls.Add(this.comboBoxBackground);
            this.panel1.Controls.Add(this.checkBoxCompressRecordings);
            this.panel1.Controls.Add(this.gradientButtonNow);
            this.panel1.Controls.Add(this.textBoxSaveDir);
            this.panel1.Controls.Add(this.numericUpDownGravitationalConstant);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.numericUpDownPrecalculationIncrease);
            this.panel1.Controls.Add(this.gradientButtonResetToDefaults);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.buttonSaveDir);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(11, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 505);
            this.panel1.TabIndex = 84;
            // 
            // numericUpDownVideoFPS
            // 
            this.numericUpDownVideoFPS.Location = new System.Drawing.Point(595, 469);
            this.numericUpDownVideoFPS.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numericUpDownVideoFPS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownVideoFPS.Name = "numericUpDownVideoFPS";
            this.numericUpDownVideoFPS.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownVideoFPS.TabIndex = 150;
            this.numericUpDownVideoFPS.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.AutoSize = false;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label20.Location = new System.Drawing.Point(506, 473);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(86, 13);
            this.label20.TabIndex = 149;
            this.label20.Text = "Frames/Second:";
            // 
            // label19
            // 
            this.label19.AutoSize = false;
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label19.Location = new System.Drawing.Point(196, 472);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 13);
            this.label19.TabIndex = 148;
            this.label19.Text = "Compression:";
            // 
            // comboBoxCaptureCompression
            // 
            this.comboBoxCaptureCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCaptureCompression.FormattingEnabled = true;
            this.comboBoxCaptureCompression.Items.AddRange(new object[] {
            "[none]",
            "Space 1",
            "Space 2",
            "Space 3",
            "Space 4",
            "Space 5"});
            this.comboBoxCaptureCompression.Location = new System.Drawing.Point(269, 469);
            this.comboBoxCaptureCompression.Name = "comboBoxCaptureCompression";
            this.comboBoxCaptureCompression.Size = new System.Drawing.Size(219, 21);
            this.comboBoxCaptureCompression.TabIndex = 85;
            // 
            // label18
            // 
            this.label18.AutoSize = false;
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label18.Location = new System.Drawing.Point(103, 472);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 13);
            this.label18.TabIndex = 146;
            this.label18.Text = "Video capture:";
            // 
            // label14
            // 
            this.label14.AutoSize = false;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(323, 269);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 145;
            this.label14.Text = "m.s⁻²";
            // 
            // label6
            // 
            this.label6.AutoSize = false;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(90, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 144;
            this.label6.Text = "Acceleration limit:";
            // 
            // numericUpDownAccelerationLimit
            // 
            this.numericUpDownAccelerationLimit.DecimalPlaces = 15;
            this.numericUpDownAccelerationLimit.Increment = new decimal(new int[] {
            1,
            0,
            0,
            655360});
            this.numericUpDownAccelerationLimit.Location = new System.Drawing.Point(198, 266);
            this.numericUpDownAccelerationLimit.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownAccelerationLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            983040});
            this.numericUpDownAccelerationLimit.Name = "numericUpDownAccelerationLimit";
            this.numericUpDownAccelerationLimit.Size = new System.Drawing.Size(123, 20);
            this.numericUpDownAccelerationLimit.TabIndex = 143;
            this.numericUpDownAccelerationLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            655360});
            // 
            // checkBoxPrecalcAutoIncrease
            // 
            this.checkBoxPrecalcAutoIncrease.AutoSize = false;
            this.checkBoxPrecalcAutoIncrease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxPrecalcAutoIncrease.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxPrecalcAutoIncrease.Checked = true;
            this.checkBoxPrecalcAutoIncrease.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPrecalcAutoIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPrecalcAutoIncrease.Location = new System.Drawing.Point(30, 210);
            this.checkBoxPrecalcAutoIncrease.Name = "checkBoxPrecalcAutoIncrease";
            this.checkBoxPrecalcAutoIncrease.Padding = new System.Windows.Forms.Padding(0, 0, 4, 3);
            this.checkBoxPrecalcAutoIncrease.Size = new System.Drawing.Size(186, 20);
            this.checkBoxPrecalcAutoIncrease.TabIndex = 142;
            this.checkBoxPrecalcAutoIncrease.Text = "Pre-Calculation auto increase:     ";
            this.checkBoxPrecalcAutoIncrease.UseVisualStyleBackColor = false;
            this.checkBoxPrecalcAutoIncrease.CheckedChanged += new System.EventHandler(this.checkBoxPrecalcAutoIncrease_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = false;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(229, 212);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 141;
            this.label13.Text = "Increase factor:";
            // 
            // label12
            // 
            this.label12.AutoSize = false;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(71, 182);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 13);
            this.label12.TabIndex = 140;
            this.label12.Text = "Minimum size planets:";
            // 
            // numericUpDownMinimumTextureSize
            // 
            this.numericUpDownMinimumTextureSize.Location = new System.Drawing.Point(198, 179);
            this.numericUpDownMinimumTextureSize.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownMinimumTextureSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMinimumTextureSize.Name = "numericUpDownMinimumTextureSize";
            this.numericUpDownMinimumTextureSize.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownMinimumTextureSize.TabIndex = 139;
            this.numericUpDownMinimumTextureSize.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = false;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label17.Location = new System.Drawing.Point(224, 318);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(121, 13);
            this.label17.TabIndex = 138;
            this.label17.Text = "Treshold (higher=faster):";
            // 
            // numericUpDownBarnesHutTreshold
            // 
            this.numericUpDownBarnesHutTreshold.DecimalPlaces = 2;
            this.numericUpDownBarnesHutTreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownBarnesHutTreshold.Location = new System.Drawing.Point(349, 315);
            this.numericUpDownBarnesHutTreshold.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownBarnesHutTreshold.Name = "numericUpDownBarnesHutTreshold";
            this.numericUpDownBarnesHutTreshold.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownBarnesHutTreshold.TabIndex = 137;
            this.numericUpDownBarnesHutTreshold.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // checkBoxUseBarnesHut
            // 
            this.checkBoxUseBarnesHut.AutoSize = false;
            this.checkBoxUseBarnesHut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxUseBarnesHut.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxUseBarnesHut.Checked = true;
            this.checkBoxUseBarnesHut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseBarnesHut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxUseBarnesHut.Location = new System.Drawing.Point(26, 318);
            this.checkBoxUseBarnesHut.Name = "checkBoxUseBarnesHut";
            this.checkBoxUseBarnesHut.Padding = new System.Windows.Forms.Padding(0, 0, 4, 3);
            this.checkBoxUseBarnesHut.Size = new System.Drawing.Size(191, 20);
            this.checkBoxUseBarnesHut.TabIndex = 136;
            this.checkBoxUseBarnesHut.Text = "Use Barnes-Hut approximation:     ";
            this.checkBoxUseBarnesHut.UseVisualStyleBackColor = false;
            this.checkBoxUseBarnesHut.CheckedChanged += new System.EventHandler(this.checkBoxUseBarnesHut_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = false;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(102, 395);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 135;
            this.label9.Text = "Custom shape:";
            // 
            // comboBoxBlendMode
            // 
            this.comboBoxBlendMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBlendMode.FormattingEnabled = true;
            this.comboBoxBlendMode.Items.AddRange(new object[] {
            "Transparent",
            "Opaque"});
            this.comboBoxBlendMode.Location = new System.Drawing.Point(197, 149);
            this.comboBoxBlendMode.Name = "comboBoxBlendMode";
            this.comboBoxBlendMode.Size = new System.Drawing.Size(165, 21);
            this.comboBoxBlendMode.TabIndex = 133;
            // 
            // comboBoxBackground
            // 
            this.comboBoxBackground.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBackground.FormattingEnabled = true;
            this.comboBoxBackground.Items.AddRange(new object[] {
            "[none]",
            "Space 1",
            "Space 2",
            "Space 3",
            "Space 4",
            "Space 5"});
            this.comboBoxBackground.Location = new System.Drawing.Point(197, 122);
            this.comboBoxBackground.Name = "comboBoxBackground";
            this.comboBoxBackground.Size = new System.Drawing.Size(165, 21);
            this.comboBoxBackground.TabIndex = 82;
            // 
            // checkBoxCompressRecordings
            // 
            this.checkBoxCompressRecordings.AutoSize = false;
            this.checkBoxCompressRecordings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxCompressRecordings.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxCompressRecordings.Checked = true;
            this.checkBoxCompressRecordings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCompressRecordings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCompressRecordings.Location = new System.Drawing.Point(66, 293);
            this.checkBoxCompressRecordings.Name = "checkBoxCompressRecordings";
            this.checkBoxCompressRecordings.Padding = new System.Windows.Forms.Padding(0, 0, 4, 3);
            this.checkBoxCompressRecordings.Size = new System.Drawing.Size(151, 20);
            this.checkBoxCompressRecordings.TabIndex = 132;
            this.checkBoxCompressRecordings.Text = "Compress Recordings:     ";
            this.checkBoxCompressRecordings.UseVisualStyleBackColor = false;
            // 
            // gradientButtonNow
            // 
            this.gradientButtonNow.Active = false;
            this.gradientButtonNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonNow.Location = new System.Drawing.Point(407, 21);
            this.gradientButtonNow.Name = "gradientButtonNow";
            this.gradientButtonNow.Size = new System.Drawing.Size(51, 20);
            this.gradientButtonNow.TabIndex = 131;
            this.gradientButtonNow.Text = "Now";
            this.gradientButtonNow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gradientButtonNow.UseVisualStyleBackColor = false;
            this.gradientButtonNow.Click += new System.EventHandler(this.gradientButtonNow_Click);
            // 
            // textBoxSaveDir
            // 
            this.textBoxSaveDir.Location = new System.Drawing.Point(197, 96);
            this.textBoxSaveDir.Name = "textBoxSaveDir";
            this.textBoxSaveDir.Size = new System.Drawing.Size(368, 20);
            this.textBoxSaveDir.TabIndex = 55;
            // 
            // numericUpDownGravitationalConstant
            // 
            this.numericUpDownGravitationalConstant.Increment = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numericUpDownGravitationalConstant.Location = new System.Drawing.Point(198, 239);
            this.numericUpDownGravitationalConstant.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.numericUpDownGravitationalConstant.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownGravitationalConstant.Name = "numericUpDownGravitationalConstant";
            this.numericUpDownGravitationalConstant.Size = new System.Drawing.Size(123, 20);
            this.numericUpDownGravitationalConstant.TabIndex = 128;
            this.numericUpDownGravitationalConstant.Value = new decimal(new int[] {
            1688069120,
            155,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = false;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(320, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 127;
            this.label8.Text = "× 10⁻²² m³ kg⁻¹ s⁻²";
            // 
            // label7
            // 
            this.label7.AutoSize = false;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(68, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 126;
            this.label7.Text = "Gravitational constant:";
            // 
            // numericUpDownPrecalculationIncrease
            // 
            this.numericUpDownPrecalculationIncrease.Location = new System.Drawing.Point(314, 209);
            this.numericUpDownPrecalculationIncrease.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownPrecalculationIncrease.Name = "numericUpDownPrecalculationIncrease";
            this.numericUpDownPrecalculationIncrease.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownPrecalculationIncrease.TabIndex = 124;
            this.numericUpDownPrecalculationIncrease.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // gradientButtonResetToDefaults
            // 
            this.gradientButtonResetToDefaults.Active = false;
            this.gradientButtonResetToDefaults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonResetToDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonResetToDefaults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonResetToDefaults.Location = new System.Drawing.Point(560, 7);
            this.gradientButtonResetToDefaults.Name = "gradientButtonResetToDefaults";
            this.gradientButtonResetToDefaults.Size = new System.Drawing.Size(113, 20);
            this.gradientButtonResetToDefaults.TabIndex = 87;
            this.gradientButtonResetToDefaults.Text = "reset to defaults";
            this.gradientButtonResetToDefaults.UseVisualStyleBackColor = false;
            this.gradientButtonResetToDefaults.Click += new System.EventHandler(this.gradientButtonResetToDefaults_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = false;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(77, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 84;
            this.label5.Text = "Objects appearance:";
            // 
            // buttonSaveDir
            // 
            this.buttonSaveDir.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveDir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSaveDir.Location = new System.Drawing.Point(564, 96);
            this.buttonSaveDir.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveDir.Name = "buttonSaveDir";
            this.buttonSaveDir.Size = new System.Drawing.Size(37, 20);
            this.buttonSaveDir.TabIndex = 0;
            this.buttonSaveDir.Text = "...";
            this.buttonSaveDir.UseVisualStyleBackColor = true;
            this.buttonSaveDir.Click += new System.EventHandler(this.buttonSaveDir_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.checkBoxRandomColor);
            this.panel2.Controls.Add(this.radioButtonCross);
            this.panel2.Controls.Add(this.checkBoxRandomSize);
            this.panel2.Controls.Add(this.comboBoxColorCoding);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.numericUpDownAlpha);
            this.panel2.Controls.Add(this.radioButtonRound);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.numericUpDownPixelSize);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.radioButtonSquare);
            this.panel2.Location = new System.Drawing.Point(196, 389);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(477, 70);
            this.panel2.TabIndex = 134;
            // 
            // checkBoxRandomColor
            // 
            this.checkBoxRandomColor.AutoSize = false;
            this.checkBoxRandomColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxRandomColor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxRandomColor.Checked = true;
            this.checkBoxRandomColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRandomColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRandomColor.Location = new System.Drawing.Point(136, 43);
            this.checkBoxRandomColor.Name = "checkBoxRandomColor";
            this.checkBoxRandomColor.Padding = new System.Windows.Forms.Padding(0, 0, 4, 3);
            this.checkBoxRandomColor.Size = new System.Drawing.Size(99, 20);
            this.checkBoxRandomColor.TabIndex = 152;
            this.checkBoxRandomColor.Text = "Random color:";
            this.checkBoxRandomColor.UseVisualStyleBackColor = false;
            // 
            // radioButtonCross
            // 
            this.radioButtonCross.AutoSize = false;
            this.radioButtonCross.Location = new System.Drawing.Point(60, 44);
            this.radioButtonCross.Name = "radioButtonCross";
            this.radioButtonCross.Size = new System.Drawing.Size(50, 17);
            this.radioButtonCross.TabIndex = 151;
            this.radioButtonCross.TabStop = true;
            this.radioButtonCross.Text = "cross";
            this.radioButtonCross.UseVisualStyleBackColor = true;
            // 
            // checkBoxRandomSize
            // 
            this.checkBoxRandomSize.AutoSize = false;
            this.checkBoxRandomSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxRandomSize.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxRandomSize.Checked = true;
            this.checkBoxRandomSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRandomSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRandomSize.Location = new System.Drawing.Point(141, 8);
            this.checkBoxRandomSize.Name = "checkBoxRandomSize";
            this.checkBoxRandomSize.Padding = new System.Windows.Forms.Padding(0, 0, 4, 3);
            this.checkBoxRandomSize.Size = new System.Drawing.Size(94, 20);
            this.checkBoxRandomSize.TabIndex = 150;
            this.checkBoxRandomSize.Text = "Random size:";
            this.checkBoxRandomSize.UseVisualStyleBackColor = false;
            this.checkBoxRandomSize.CheckedChanged += new System.EventHandler(this.checkBoxRandomSize_CheckedChanged);
            // 
            // comboBoxColorCoding
            // 
            this.comboBoxColorCoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColorCoding.FormattingEnabled = true;
            this.comboBoxColorCoding.Items.AddRange(new object[] {
            "None",
            "Speed 1",
            "Speed 2",
            "Speed 3",
            "Force 1",
            "Force 2",
            "Force 3"});
            this.comboBoxColorCoding.Location = new System.Drawing.Point(352, 41);
            this.comboBoxColorCoding.Name = "comboBoxColorCoding";
            this.comboBoxColorCoding.Size = new System.Drawing.Size(108, 21);
            this.comboBoxColorCoding.TabIndex = 149;
            this.comboBoxColorCoding.SelectedIndexChanged += new System.EventHandler(this.comboBoxColorCoding_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = false;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(272, 44);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 13);
            this.label16.TabIndex = 148;
            this.label16.Text = "Color coding:";
            // 
            // label15
            // 
            this.label15.AutoSize = false;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(369, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 147;
            this.label15.Text = "Alpha:";
            // 
            // numericUpDownAlpha
            // 
            this.numericUpDownAlpha.Location = new System.Drawing.Point(411, 6);
            this.numericUpDownAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownAlpha.Name = "numericUpDownAlpha";
            this.numericUpDownAlpha.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownAlpha.TabIndex = 143;
            this.numericUpDownAlpha.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // radioButtonRound
            // 
            this.radioButtonRound.AutoSize = false;
            this.radioButtonRound.Location = new System.Drawing.Point(60, 2);
            this.radioButtonRound.Name = "radioButtonRound";
            this.radioButtonRound.Size = new System.Drawing.Size(52, 17);
            this.radioButtonRound.TabIndex = 139;
            this.radioButtonRound.TabStop = true;
            this.radioButtonRound.Text = "round";
            this.radioButtonRound.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = false;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(248, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 136;
            this.label10.Text = "Fixed size:";
            // 
            // numericUpDownPixelSize
            // 
            this.numericUpDownPixelSize.Location = new System.Drawing.Point(307, 6);
            this.numericUpDownPixelSize.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDownPixelSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPixelSize.Name = "numericUpDownPixelSize";
            this.numericUpDownPixelSize.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownPixelSize.TabIndex = 129;
            this.numericUpDownPixelSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = false;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(12, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 137;
            this.label11.Text = "Shape:";
            // 
            // radioButtonSquare
            // 
            this.radioButtonSquare.AutoSize = false;
            this.radioButtonSquare.Location = new System.Drawing.Point(60, 23);
            this.radioButtonSquare.Name = "radioButtonSquare";
            this.radioButtonSquare.Size = new System.Drawing.Size(57, 17);
            this.radioButtonSquare.TabIndex = 138;
            this.radioButtonSquare.TabStop = true;
            this.radioButtonSquare.Text = "square";
            this.radioButtonSquare.UseVisualStyleBackColor = true;
            // 
            // checkBoxAllDots
            // 
            this.checkBoxAllDots.AutoSize = false;
            this.checkBoxAllDots.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxAllDots.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAllDots.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAllDots.Location = new System.Drawing.Point(47, 342);
            this.checkBoxAllDots.Name = "checkBoxAllDots";
            this.checkBoxAllDots.Size = new System.Drawing.Size(166, 17);
            this.checkBoxAllDots.TabIndex = 151;
            this.checkBoxAllDots.Text = "Show all objects as points:     ";
            this.checkBoxAllDots.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAllDots.UseVisualStyleBackColor = false;
            this.checkBoxAllDots.CheckedChanged += new System.EventHandler(this.checkBoxAllDots_CheckedChanged);
            // 
            // checkBoxShowScale
            // 
            this.checkBoxShowScale.AutoSize = false;
            this.checkBoxShowScale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxShowScale.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxShowScale.Checked = true;
            this.checkBoxShowScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxShowScale.Location = new System.Drawing.Point(93, 366);
            this.checkBoxShowScale.Name = "checkBoxShowScale";
            this.checkBoxShowScale.Size = new System.Drawing.Size(120, 17);
            this.checkBoxShowScale.TabIndex = 152;
            this.checkBoxShowScale.Text = "Show scale bar:      ";
            this.checkBoxShowScale.UseVisualStyleBackColor = false;
            // 
            // FormPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 583);
            this.Controls.Add(this.gradientPanel21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPreferences";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preferences";
            this.gradientPanel21.ResumeLayout(false);
            this.gradientPanel21.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVideoFPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAccelerationLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinimumTextureSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBarnesHutTreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGravitationalConstant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecalculationIncrease)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPixelSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.GradientButton gradientButtonCancel;
        internal CustomControls.GradientButton gradientButtonSave;
        private CustomControls.GradientPanel2 gradientPanel21;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox textBoxSaveDir;
        internal System.Windows.Forms.TextBox textBoxPrecalcTime;
        internal System.Windows.Forms.TextBox textBoxFrameRate;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DateTimePicker dateTimePickerCurrentDate;
        internal System.Windows.Forms.DateTimePicker dateTimePickerCurrentTime;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.ComboBox comboBoxBackground;
        private System.Windows.Forms.Button buttonSaveDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogSaveDir;
        private System.Windows.Forms.Label label5;
        internal CustomControls.GradientButton gradientButtonResetToDefaults;
        internal System.Windows.Forms.NumericUpDown numericUpDownPrecalculationIncrease;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.NumericUpDown numericUpDownGravitationalConstant;
        internal System.Windows.Forms.NumericUpDown numericUpDownPixelSize;
        internal CustomControls.GradientButton gradientButtonNow;
        internal System.Windows.Forms.CheckBox checkBoxCompressRecordings;
        internal System.Windows.Forms.ComboBox comboBoxBlendMode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton radioButtonRound;
        private System.Windows.Forms.RadioButton radioButtonSquare;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.NumericUpDown numericUpDownAlpha;
        internal System.Windows.Forms.ComboBox comboBoxColorCoding;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        internal System.Windows.Forms.NumericUpDown numericUpDownBarnesHutTreshold;
        internal System.Windows.Forms.CheckBox checkBoxUseBarnesHut;
        internal System.Windows.Forms.CheckBox checkBoxRandomSize;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.NumericUpDown numericUpDownMinimumTextureSize;
        internal System.Windows.Forms.CheckBox checkBoxPrecalcAutoIncrease;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton radioButtonCross;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.NumericUpDown numericUpDownAccelerationLimit;
        internal System.Windows.Forms.CheckBox checkBoxRandomColor;
        internal System.Windows.Forms.ComboBox comboBoxCaptureCompression;
        private System.Windows.Forms.Label label18;
        internal System.Windows.Forms.NumericUpDown numericUpDownVideoFPS;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox checkBoxAllDots;
        private System.Windows.Forms.CheckBox checkBoxShowScale;
    }
}