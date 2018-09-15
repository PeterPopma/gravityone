using GravityOne.CustomControls;

namespace GravityOne.Forms
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            Microsoft.Xna.Framework.Graphics.BlendState blendState1 = new Microsoft.Xna.Framework.Graphics.BlendState();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxLimit = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.labelNumObjects = new System.Windows.Forms.Label();
            this.backgroundWorkerPreCalculate = new System.ComponentModel.BackgroundWorker();
            this.toolTipCaptureVideo = new System.Windows.Forms.ToolTip(this.components);
            this.gradientButtonCaptureVideo = new GravityOne.CustomControls.GradientButton();
            this.gradientPanelObjectProperties = new GravityOne.CustomControls.GradientPanel();
            this.gradientPanel25 = new GravityOne.CustomControls.GradientPanel2();
            this.gradientButtonPick = new GravityOne.CustomControls.GradientButton();
            this.labelNumberObjects = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.gradientButtonNextObject = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonPreviousObject = new GravityOne.CustomControls.GradientButton();
            this.labelObjectNumber = new System.Windows.Forms.Label();
            this.panelObjectProperties = new System.Windows.Forms.Panel();
            this.gradientPanelObjectProperties2 = new GravityOne.CustomControls.GradientPanel2();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelMass = new System.Windows.Forms.Label();
            this.labelYAcceleration = new System.Windows.Forms.Label();
            this.labelXAcceleration = new System.Windows.Forms.Label();
            this.labelAcceleration = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.labelDistanceToZero = new System.Windows.Forms.Label();
            this.labelYSpeed = new System.Windows.Forms.Label();
            this.labelXSpeed = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.gradientButtonAdjustValues = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonRemove = new GravityOne.CustomControls.GradientButton();
            this.checkBoxCenter = new System.Windows.Forms.CheckBox();
            this.labelObjectName = new System.Windows.Forms.Label();
            this.gradientPanelAdjustValues = new GravityOne.CustomControls.GradientPanel();
            this.panelInnerAdjustValues = new System.Windows.Forms.Panel();
            this.gradientPanel28 = new GravityOne.CustomControls.GradientPanel2();
            this.checkBoxAdjustTrace = new System.Windows.Forms.CheckBox();
            this.checkBoxAdjustVector = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxAdjustName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gradientButtonReady = new GravityOne.CustomControls.GradientButton();
            this.textBoxAdjustMass = new System.Windows.Forms.TextBox();
            this.textBoxAdjustYSpeed = new System.Windows.Forms.TextBox();
            this.textBoxAdjustXSpeed = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gradientPanelToolbox = new GravityOne.CustomControls.GradientPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gradientPanel211 = new GravityOne.CustomControls.GradientPanel2();
            this.gradientButtonRemoveAll = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonSave = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonLoad = new GravityOne.CustomControls.GradientButton();
            this.panelPresetObjects = new System.Windows.Forms.Panel();
            this.gradientPanel26 = new GravityOne.CustomControls.GradientPanel2();
            this.gradientButtonMoon = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonPluto = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonPlanet = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonNeptune = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonUranus = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonJupiter = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonSaturn = new GravityOne.CustomControls.GradientButton();
            this.label3 = new System.Windows.Forms.Label();
            this.gradientButtonSun = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonEarth = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonMars = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonVenus = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonMercury = new GravityOne.CustomControls.GradientButton();
            this.panelNewObject = new System.Windows.Forms.Panel();
            this.gradientPanel27 = new GravityOne.CustomControls.GradientPanel2();
            this.checkBoxCircleCCW = new System.Windows.Forms.CheckBox();
            this.checkBoxCircleHost = new System.Windows.Forms.CheckBox();
            this.label41 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.checkBoxTrace = new System.Windows.Forms.CheckBox();
            this.checkBoxVector = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxYSpeed = new System.Windows.Forms.TextBox();
            this.textBoxXSpeed = new System.Windows.Forms.TextBox();
            this.textBoxMass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxShape = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelPresetSetups = new System.Windows.Forms.Panel();
            this.gradientPanel29 = new GravityOne.CustomControls.GradientPanel2();
            this.gradientButtonPlanetSystems = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonGrid = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonGalaxy = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonCircle = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonBinary = new GravityOne.CustomControls.GradientButton();
            this.labelClickMessage = new System.Windows.Forms.Label();
            this.gradientButtonSlingshot = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonRandom = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonSolarSystem = new GravityOne.CustomControls.GradientButton();
            this.label2 = new System.Windows.Forms.Label();
            this.gradientPanel1 = new GravityOne.CustomControls.GradientPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gradientPanel21 = new GravityOne.CustomControls.GradientPanel2();
            this.labelTimePerStep = new System.Windows.Forms.Label();
            this.comboBoxCalcsUnit = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.macTrackBarSpeed = new XComponent.SliderBar.MACTrackBar();
            this.macTrackBarDelay = new XComponent.SliderBar.MACTrackBar();
            this.macTrackBarScale = new XComponent.SliderBar.MACTrackBar();
            this.panelPan = new System.Windows.Forms.Panel();
            this.gradientPanel210 = new GravityOne.CustomControls.GradientPanel2();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gradientPanel22 = new GravityOne.CustomControls.GradientPanel2();
            this.checkBoxReverse = new System.Windows.Forms.CheckBox();
            this.checkBoxShowNames = new System.Windows.Forms.CheckBox();
            this.checkBoxVectorsAll = new System.Windows.Forms.CheckBox();
            this.checkBoxTraceAll = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.gradientPanel23 = new GravityOne.CustomControls.GradientPanel2();
            this.gradientButtonPreferences = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonToggleObject = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonToggleToolbox = new GravityOne.CustomControls.GradientButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gradientPanel24 = new GravityOne.CustomControls.GradientPanel2();
            this.gradientButtonRewind = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonStep = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonStart = new GravityOne.CustomControls.GradientButton();
            this.displayXNA = new GravityOne.CustomControls.Display();
            this.macTrackBar1 = new XComponent.SliderBar.MACTrackBar();
            this.macTrackBar2 = new XComponent.SliderBar.MACTrackBar();
            this.gradientButton3 = new GravityOne.CustomControls.GradientButton();
            this.gradientButton1 = new GravityOne.CustomControls.GradientButton();
            this.gradientPanelObjectProperties.SuspendLayout();
            this.gradientPanel25.SuspendLayout();
            this.panelObjectProperties.SuspendLayout();
            this.gradientPanelObjectProperties2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gradientPanelAdjustValues.SuspendLayout();
            this.panelInnerAdjustValues.SuspendLayout();
            this.gradientPanel28.SuspendLayout();
            this.gradientPanelToolbox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gradientPanel211.SuspendLayout();
            this.panelPresetObjects.SuspendLayout();
            this.gradientPanel26.SuspendLayout();
            this.panelNewObject.SuspendLayout();
            this.gradientPanel27.SuspendLayout();
            this.panelPresetSetups.SuspendLayout();
            this.gradientPanel29.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gradientPanel21.SuspendLayout();
            this.panelPan.SuspendLayout();
            this.gradientPanel210.SuspendLayout();
            this.panel5.SuspendLayout();
            this.gradientPanel22.SuspendLayout();
            this.panel7.SuspendLayout();
            this.gradientPanel23.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gradientPanel24.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "1",
            "10",
            "100",
            "1000",
            "10000",
            "100000"});
            this.comboBox3.Location = new System.Drawing.Point(81, 52);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(93, 21);
            this.comboBox3.TabIndex = 30;
            this.comboBox3.Text = "100";
            // 
            // comboBox4
            // 
            this.comboBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Seconds",
            "Minutes",
            "Hours",
            "Days",
            "Weeks",
            "Months",
            "Years"});
            this.comboBox4.Location = new System.Drawing.Point(81, 27);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(93, 21);
            this.comboBox4.TabIndex = 29;
            this.comboBox4.Text = "Days";
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(13, 55);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(55, 13);
            this.label34.TabIndex = 28;
            this.label34.Text = "Calc/Unit:";
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(36, 31);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(34, 13);
            this.label35.TabIndex = 26;
            this.label35.Text = "Units:";
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(5, 8);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(37, 13);
            this.label36.TabIndex = 25;
            this.label36.Text = "Scale:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(109, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Speed:";
            // 
            // checkBoxLimit
            // 
            this.checkBoxLimit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxLimit.ForeColor = System.Drawing.Color.Black;
            this.checkBoxLimit.Location = new System.Drawing.Point(115, 9);
            this.checkBoxLimit.Name = "checkBoxLimit";
            this.checkBoxLimit.Size = new System.Drawing.Size(109, 17);
            this.checkBoxLimit.TabIndex = 38;
            this.checkBoxLimit.Text = "Limit Acceleration";
            this.checkBoxLimit.UseVisualStyleBackColor = false;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(111, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "# of objects:";
            // 
            // labelNumObjects
            // 
            this.labelNumObjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelNumObjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumObjects.ForeColor = System.Drawing.Color.Black;
            this.labelNumObjects.Location = new System.Drawing.Point(178, 32);
            this.labelNumObjects.Name = "labelNumObjects";
            this.labelNumObjects.Size = new System.Drawing.Size(42, 13);
            this.labelNumObjects.TabIndex = 36;
            this.labelNumObjects.Text = "xxxxxxx";
            // 
            // backgroundWorkerPreCalculate
            // 
            this.backgroundWorkerPreCalculate.WorkerReportsProgress = true;
            this.backgroundWorkerPreCalculate.WorkerSupportsCancellation = true;
            this.backgroundWorkerPreCalculate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPreCalculate_DoWork);
            // 
            // gradientButtonCaptureVideo
            // 
            this.gradientButtonCaptureVideo.Active = false;
            this.gradientButtonCaptureVideo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonCaptureVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonCaptureVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonCaptureVideo.Image = global::GravityOne.Resources.icon_camera_32;
            this.gradientButtonCaptureVideo.Location = new System.Drawing.Point(84, 50);
            this.gradientButtonCaptureVideo.Name = "gradientButtonCaptureVideo";
            this.gradientButtonCaptureVideo.Size = new System.Drawing.Size(38, 37);
            this.gradientButtonCaptureVideo.TabIndex = 86;
            this.toolTipCaptureVideo.SetToolTip(this.gradientButtonCaptureVideo, resources.GetString("gradientButtonCaptureVideo.ToolTip"));
            this.gradientButtonCaptureVideo.UseVisualStyleBackColor = false;
            this.gradientButtonCaptureVideo.Click += new System.EventHandler(this.gradientButtonCaptureVideo_Click);
            // 
            // gradientPanelObjectProperties
            // 
            this.gradientPanelObjectProperties.AllowDrop = true;
            this.gradientPanelObjectProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientPanelObjectProperties.Controls.Add(this.gradientPanel25);
            this.gradientPanelObjectProperties.Controls.Add(this.panelObjectProperties);
            this.gradientPanelObjectProperties.Location = new System.Drawing.Point(1024, 2);
            this.gradientPanelObjectProperties.Name = "gradientPanelObjectProperties";
            this.gradientPanelObjectProperties.Size = new System.Drawing.Size(253, 375);
            this.gradientPanelObjectProperties.TabIndex = 18;
            // 
            // gradientPanel25
            // 
            this.gradientPanel25.Controls.Add(this.gradientButtonPick);
            this.gradientPanel25.Controls.Add(this.labelNumberObjects);
            this.gradientPanel25.Controls.Add(this.label19);
            this.gradientPanel25.Controls.Add(this.gradientButtonNextObject);
            this.gradientPanel25.Controls.Add(this.gradientButtonPreviousObject);
            this.gradientPanel25.Controls.Add(this.labelObjectNumber);
            this.gradientPanel25.Location = new System.Drawing.Point(7, 6);
            this.gradientPanel25.Name = "gradientPanel25";
            this.gradientPanel25.Size = new System.Drawing.Size(240, 76);
            this.gradientPanel25.TabIndex = 0;
            // 
            // gradientButtonPick
            // 
            this.gradientButtonPick.Active = false;
            this.gradientButtonPick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonPick.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonPick.Location = new System.Drawing.Point(13, 8);
            this.gradientButtonPick.Name = "gradientButtonPick";
            this.gradientButtonPick.Size = new System.Drawing.Size(46, 18);
            this.gradientButtonPick.TabIndex = 98;
            this.gradientButtonPick.Text = "pick";
            this.gradientButtonPick.UseVisualStyleBackColor = false;
            this.gradientButtonPick.Click += new System.EventHandler(this.gradientButtonPick_Click);
            // 
            // labelNumberObjects
            // 
            this.labelNumberObjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelNumberObjects.Location = new System.Drawing.Point(173, 10);
            this.labelNumberObjects.Name = "labelNumberObjects";
            this.labelNumberObjects.Size = new System.Drawing.Size(13, 13);
            this.labelNumberObjects.TabIndex = 97;
            this.labelNumberObjects.Text = "0";
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label19.Location = new System.Drawing.Point(106, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 96;
            this.label19.Text = "total objects:";
            // 
            // gradientButtonNextObject
            // 
            this.gradientButtonNextObject.Active = false;
            this.gradientButtonNextObject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonNextObject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonNextObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonNextObject.Location = new System.Drawing.Point(159, 40);
            this.gradientButtonNextObject.Name = "gradientButtonNextObject";
            this.gradientButtonNextObject.Size = new System.Drawing.Size(63, 22);
            this.gradientButtonNextObject.TabIndex = 95;
            this.gradientButtonNextObject.Text = ">";
            this.gradientButtonNextObject.UseVisualStyleBackColor = false;
            this.gradientButtonNextObject.Click += new System.EventHandler(this.gradientButtonNextObject_Click);
            // 
            // gradientButtonPreviousObject
            // 
            this.gradientButtonPreviousObject.Active = false;
            this.gradientButtonPreviousObject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonPreviousObject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonPreviousObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonPreviousObject.Location = new System.Drawing.Point(13, 40);
            this.gradientButtonPreviousObject.Name = "gradientButtonPreviousObject";
            this.gradientButtonPreviousObject.Size = new System.Drawing.Size(63, 22);
            this.gradientButtonPreviousObject.TabIndex = 94;
            this.gradientButtonPreviousObject.Text = "<";
            this.gradientButtonPreviousObject.UseVisualStyleBackColor = false;
            this.gradientButtonPreviousObject.Click += new System.EventHandler(this.gradientButtonPreviousObject_Click);
            // 
            // labelObjectNumber
            // 
            this.labelObjectNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelObjectNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelObjectNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelObjectNumber.Location = new System.Drawing.Point(93, 39);
            this.labelObjectNumber.Name = "labelObjectNumber";
            this.labelObjectNumber.Size = new System.Drawing.Size(21, 24);
            this.labelObjectNumber.TabIndex = 93;
            this.labelObjectNumber.Text = "0";
            // 
            // panelObjectProperties
            // 
            this.panelObjectProperties.BackColor = System.Drawing.Color.DarkGray;
            this.panelObjectProperties.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelObjectProperties.Controls.Add(this.gradientPanelObjectProperties2);
            this.panelObjectProperties.Location = new System.Drawing.Point(5, 5);
            this.panelObjectProperties.Name = "panelObjectProperties";
            this.panelObjectProperties.Size = new System.Drawing.Size(242, 362);
            this.panelObjectProperties.TabIndex = 10;
            // 
            // gradientPanelObjectProperties2
            // 
            this.gradientPanelObjectProperties2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientPanelObjectProperties2.Controls.Add(this.panel2);
            this.gradientPanelObjectProperties2.Controls.Add(this.gradientButtonAdjustValues);
            this.gradientPanelObjectProperties2.Controls.Add(this.gradientButtonRemove);
            this.gradientPanelObjectProperties2.Controls.Add(this.checkBoxCenter);
            this.gradientPanelObjectProperties2.Controls.Add(this.labelObjectName);
            this.gradientPanelObjectProperties2.Location = new System.Drawing.Point(-6, 77);
            this.gradientPanelObjectProperties2.Name = "gradientPanelObjectProperties2";
            this.gradientPanelObjectProperties2.Size = new System.Drawing.Size(247, 284);
            this.gradientPanelObjectProperties2.TabIndex = 70;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelMass);
            this.panel2.Controls.Add(this.labelYAcceleration);
            this.panel2.Controls.Add(this.labelXAcceleration);
            this.panel2.Controls.Add(this.labelAcceleration);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.label31);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.label33);
            this.panel2.Controls.Add(this.labelDistanceToZero);
            this.panel2.Controls.Add(this.labelYSpeed);
            this.panel2.Controls.Add(this.labelXSpeed);
            this.panel2.Controls.Add(this.labelSpeed);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(13, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 177);
            this.panel2.TabIndex = 89;
            // 
            // labelMass
            // 
            this.labelMass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelMass.Location = new System.Drawing.Point(85, 151);
            this.labelMass.Name = "labelMass";
            this.labelMass.Size = new System.Drawing.Size(67, 13);
            this.labelMass.TabIndex = 85;
            this.labelMass.Text = "xxxxxxxxxxxx";
            // 
            // labelYAcceleration
            // 
            this.labelYAcceleration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelYAcceleration.Location = new System.Drawing.Point(85, 131);
            this.labelYAcceleration.Name = "labelYAcceleration";
            this.labelYAcceleration.Size = new System.Drawing.Size(67, 13);
            this.labelYAcceleration.TabIndex = 84;
            this.labelYAcceleration.Text = "xxxxxxxxxxxx";
            // 
            // labelXAcceleration
            // 
            this.labelXAcceleration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelXAcceleration.Location = new System.Drawing.Point(85, 111);
            this.labelXAcceleration.Name = "labelXAcceleration";
            this.labelXAcceleration.Size = new System.Drawing.Size(67, 13);
            this.labelXAcceleration.TabIndex = 83;
            this.labelXAcceleration.Text = "xxxxxxxxxxxx";
            // 
            // labelAcceleration
            // 
            this.labelAcceleration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelAcceleration.Location = new System.Drawing.Point(85, 90);
            this.labelAcceleration.Name = "labelAcceleration";
            this.labelAcceleration.Size = new System.Drawing.Size(67, 13);
            this.labelAcceleration.TabIndex = 82;
            this.labelAcceleration.Text = "xxxxxxxxxxxx";
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label30.Location = new System.Drawing.Point(1, 151);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(74, 13);
            this.label30.TabIndex = 81;
            this.label30.Text = "Mass (10²²kg):";
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label31.Location = new System.Drawing.Point(1, 131);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(72, 13);
            this.label31.TabIndex = 80;
            this.label31.Text = "Y-Acc. (m/s²):";
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label32.Location = new System.Drawing.Point(1, 111);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(78, 13);
            this.label32.TabIndex = 79;
            this.label32.Text = "X-Acc. (m/s²):):";
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label33.Location = new System.Drawing.Point(1, 90);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(62, 13);
            this.label33.TabIndex = 78;
            this.label33.Text = "Acc. (m/s²):";
            // 
            // labelDistanceToZero
            // 
            this.labelDistanceToZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelDistanceToZero.Location = new System.Drawing.Point(85, 69);
            this.labelDistanceToZero.Name = "labelDistanceToZero";
            this.labelDistanceToZero.Size = new System.Drawing.Size(67, 13);
            this.labelDistanceToZero.TabIndex = 77;
            this.labelDistanceToZero.Text = "xxxxxxxxxxxx";
            // 
            // labelYSpeed
            // 
            this.labelYSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelYSpeed.Location = new System.Drawing.Point(85, 49);
            this.labelYSpeed.Name = "labelYSpeed";
            this.labelYSpeed.Size = new System.Drawing.Size(67, 13);
            this.labelYSpeed.TabIndex = 76;
            this.labelYSpeed.Text = "xxxxxxxxxxxx";
            // 
            // labelXSpeed
            // 
            this.labelXSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelXSpeed.Location = new System.Drawing.Point(85, 30);
            this.labelXSpeed.Name = "labelXSpeed";
            this.labelXSpeed.Size = new System.Drawing.Size(67, 13);
            this.labelXSpeed.TabIndex = 75;
            this.labelXSpeed.Text = "xxxxxxxxxxxx";
            // 
            // labelSpeed
            // 
            this.labelSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelSpeed.Location = new System.Drawing.Point(85, 11);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(67, 13);
            this.labelSpeed.TabIndex = 74;
            this.labelSpeed.Text = "xxxxxxxxxxxx";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(1, 69);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(68, 13);
            this.label21.TabIndex = 73;
            this.label21.Text = "Distance #0:";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label17.Location = new System.Drawing.Point(1, 49);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 13);
            this.label17.TabIndex = 72;
            this.label17.Text = "Y-Speed (m/s):";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(1, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 13);
            this.label16.TabIndex = 71;
            this.label16.Text = "X-Speed (m/s):";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(1, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 70;
            this.label13.Text = "Speed (m/s):";
            // 
            // gradientButtonAdjustValues
            // 
            this.gradientButtonAdjustValues.Active = false;
            this.gradientButtonAdjustValues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonAdjustValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonAdjustValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonAdjustValues.Location = new System.Drawing.Point(130, 254);
            this.gradientButtonAdjustValues.Name = "gradientButtonAdjustValues";
            this.gradientButtonAdjustValues.Size = new System.Drawing.Size(91, 18);
            this.gradientButtonAdjustValues.TabIndex = 88;
            this.gradientButtonAdjustValues.Text = "Adjust";
            this.gradientButtonAdjustValues.UseVisualStyleBackColor = false;
            this.gradientButtonAdjustValues.Click += new System.EventHandler(this.gradientButtonAdjustValues_Click);
            // 
            // gradientButtonRemove
            // 
            this.gradientButtonRemove.Active = false;
            this.gradientButtonRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonRemove.Location = new System.Drawing.Point(23, 254);
            this.gradientButtonRemove.Name = "gradientButtonRemove";
            this.gradientButtonRemove.Size = new System.Drawing.Size(91, 18);
            this.gradientButtonRemove.TabIndex = 87;
            this.gradientButtonRemove.Text = "Remove";
            this.gradientButtonRemove.UseVisualStyleBackColor = false;
            this.gradientButtonRemove.Click += new System.EventHandler(this.gradientButtonRemove_Click);
            // 
            // checkBoxCenter
            // 
            this.checkBoxCenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxCenter.Location = new System.Drawing.Point(24, 225);
            this.checkBoxCenter.Name = "checkBoxCenter";
            this.checkBoxCenter.Size = new System.Drawing.Size(57, 17);
            this.checkBoxCenter.TabIndex = 69;
            this.checkBoxCenter.Text = "Center";
            this.checkBoxCenter.UseVisualStyleBackColor = false;
            this.checkBoxCenter.Click += new System.EventHandler(this.checkBoxCenter_Click);
            // 
            // labelObjectName
            // 
            this.labelObjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelObjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelObjectName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelObjectName.Location = new System.Drawing.Point(9, 9);
            this.labelObjectName.Name = "labelObjectName";
            this.labelObjectName.Size = new System.Drawing.Size(229, 24);
            this.labelObjectName.TabIndex = 68;
            this.labelObjectName.Text = "Earth";
            // 
            // gradientPanelAdjustValues
            // 
            this.gradientPanelAdjustValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientPanelAdjustValues.Controls.Add(this.panelInnerAdjustValues);
            this.gradientPanelAdjustValues.Location = new System.Drawing.Point(1024, 375);
            this.gradientPanelAdjustValues.Name = "gradientPanelAdjustValues";
            this.gradientPanelAdjustValues.Size = new System.Drawing.Size(256, 227);
            this.gradientPanelAdjustValues.TabIndex = 17;
            // 
            // panelInnerAdjustValues
            // 
            this.panelInnerAdjustValues.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelInnerAdjustValues.Controls.Add(this.gradientPanel28);
            this.panelInnerAdjustValues.Location = new System.Drawing.Point(5, 8);
            this.panelInnerAdjustValues.Name = "panelInnerAdjustValues";
            this.panelInnerAdjustValues.Size = new System.Drawing.Size(242, 211);
            this.panelInnerAdjustValues.TabIndex = 16;
            // 
            // gradientPanel28
            // 
            this.gradientPanel28.Controls.Add(this.checkBoxAdjustTrace);
            this.gradientPanel28.Controls.Add(this.checkBoxAdjustVector);
            this.gradientPanel28.Controls.Add(this.label22);
            this.gradientPanel28.Controls.Add(this.textBoxAdjustName);
            this.gradientPanel28.Controls.Add(this.label11);
            this.gradientPanel28.Controls.Add(this.gradientButtonReady);
            this.gradientPanel28.Controls.Add(this.textBoxAdjustMass);
            this.gradientPanel28.Controls.Add(this.textBoxAdjustYSpeed);
            this.gradientPanel28.Controls.Add(this.textBoxAdjustXSpeed);
            this.gradientPanel28.Controls.Add(this.label18);
            this.gradientPanel28.Controls.Add(this.label14);
            this.gradientPanel28.Controls.Add(this.label10);
            this.gradientPanel28.Location = new System.Drawing.Point(0, 4);
            this.gradientPanel28.Name = "gradientPanel28";
            this.gradientPanel28.Size = new System.Drawing.Size(240, 203);
            this.gradientPanel28.TabIndex = 0;
            this.gradientPanel28.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientPanel28_Paint);
            // 
            // checkBoxAdjustTrace
            // 
            this.checkBoxAdjustTrace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxAdjustTrace.Checked = true;
            this.checkBoxAdjustTrace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAdjustTrace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAdjustTrace.Location = new System.Drawing.Point(42, 138);
            this.checkBoxAdjustTrace.Name = "checkBoxAdjustTrace";
            this.checkBoxAdjustTrace.Size = new System.Drawing.Size(46, 17);
            this.checkBoxAdjustTrace.TabIndex = 109;
            this.checkBoxAdjustTrace.Text = "Trail";
            this.checkBoxAdjustTrace.UseVisualStyleBackColor = false;
            this.checkBoxAdjustTrace.CheckedChanged += new System.EventHandler(this.checkBoxAdjustTrace_CheckedChanged);
            // 
            // checkBoxAdjustVector
            // 
            this.checkBoxAdjustVector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxAdjustVector.Checked = true;
            this.checkBoxAdjustVector.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAdjustVector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAdjustVector.Location = new System.Drawing.Point(116, 138);
            this.checkBoxAdjustVector.Name = "checkBoxAdjustVector";
            this.checkBoxAdjustVector.Size = new System.Drawing.Size(57, 17);
            this.checkBoxAdjustVector.TabIndex = 108;
            this.checkBoxAdjustVector.Text = "Vector";
            this.checkBoxAdjustVector.UseVisualStyleBackColor = false;
            this.checkBoxAdjustVector.CheckedChanged += new System.EventHandler(this.checkBoxAdjustVector_CheckedChanged);
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(8, 7);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(60, 20);
            this.label22.TabIndex = 103;
            this.label22.Text = "Adjust";
            // 
            // textBoxAdjustName
            // 
            this.textBoxAdjustName.Location = new System.Drawing.Point(98, 27);
            this.textBoxAdjustName.Name = "textBoxAdjustName";
            this.textBoxAdjustName.Size = new System.Drawing.Size(95, 20);
            this.textBoxAdjustName.TabIndex = 102;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(20, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 101;
            this.label11.Text = "Name:";
            // 
            // gradientButtonReady
            // 
            this.gradientButtonReady.Active = false;
            this.gradientButtonReady.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonReady.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonReady.Location = new System.Drawing.Point(72, 170);
            this.gradientButtonReady.Name = "gradientButtonReady";
            this.gradientButtonReady.Size = new System.Drawing.Size(91, 18);
            this.gradientButtonReady.TabIndex = 89;
            this.gradientButtonReady.Text = "Update";
            this.gradientButtonReady.UseVisualStyleBackColor = false;
            this.gradientButtonReady.Click += new System.EventHandler(this.gradientButtonReady_Click);
            // 
            // textBoxAdjustMass
            // 
            this.textBoxAdjustMass.Location = new System.Drawing.Point(98, 107);
            this.textBoxAdjustMass.Name = "textBoxAdjustMass";
            this.textBoxAdjustMass.Size = new System.Drawing.Size(95, 20);
            this.textBoxAdjustMass.TabIndex = 100;
            // 
            // textBoxAdjustYSpeed
            // 
            this.textBoxAdjustYSpeed.Location = new System.Drawing.Point(98, 82);
            this.textBoxAdjustYSpeed.Name = "textBoxAdjustYSpeed";
            this.textBoxAdjustYSpeed.Size = new System.Drawing.Size(95, 20);
            this.textBoxAdjustYSpeed.TabIndex = 99;
            // 
            // textBoxAdjustXSpeed
            // 
            this.textBoxAdjustXSpeed.Location = new System.Drawing.Point(98, 54);
            this.textBoxAdjustXSpeed.Name = "textBoxAdjustXSpeed";
            this.textBoxAdjustXSpeed.Size = new System.Drawing.Size(95, 20);
            this.textBoxAdjustXSpeed.TabIndex = 98;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label18.Location = new System.Drawing.Point(21, 110);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 13);
            this.label18.TabIndex = 82;
            this.label18.Text = "Mass (10²²kg):";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(21, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 72;
            this.label14.Text = "YSpeed (m/s):";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(21, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 71;
            this.label10.Text = "XSpeed (m/s):";
            // 
            // gradientPanelToolbox
            // 
            this.gradientPanelToolbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientPanelToolbox.Controls.Add(this.panel1);
            this.gradientPanelToolbox.Controls.Add(this.panelPresetObjects);
            this.gradientPanelToolbox.Controls.Add(this.panelNewObject);
            this.gradientPanelToolbox.Controls.Add(this.panelPresetSetups);
            this.gradientPanelToolbox.Location = new System.Drawing.Point(0, 0);
            this.gradientPanelToolbox.Name = "gradientPanelToolbox";
            this.gradientPanelToolbox.Size = new System.Drawing.Size(226, 582);
            this.gradientPanelToolbox.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.gradientPanel211);
            this.panel1.Location = new System.Drawing.Point(4, 502);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 70);
            this.panel1.TabIndex = 102;
            // 
            // gradientPanel211
            // 
            this.gradientPanel211.Controls.Add(this.gradientButtonRemoveAll);
            this.gradientPanel211.Controls.Add(this.gradientButtonSave);
            this.gradientPanel211.Controls.Add(this.gradientButtonLoad);
            this.gradientPanel211.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel211.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel211.Name = "gradientPanel211";
            this.gradientPanel211.Size = new System.Drawing.Size(211, 66);
            this.gradientPanel211.TabIndex = 21;
            // 
            // gradientButtonRemoveAll
            // 
            this.gradientButtonRemoveAll.Active = false;
            this.gradientButtonRemoveAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonRemoveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonRemoveAll.Location = new System.Drawing.Point(7, 36);
            this.gradientButtonRemoveAll.Name = "gradientButtonRemoveAll";
            this.gradientButtonRemoveAll.Size = new System.Drawing.Size(197, 24);
            this.gradientButtonRemoveAll.TabIndex = 101;
            this.gradientButtonRemoveAll.Text = "Remove all objects";
            this.gradientButtonRemoveAll.UseVisualStyleBackColor = false;
            this.gradientButtonRemoveAll.Click += new System.EventHandler(this.gradientButtonRemoveAll_Click);
            // 
            // gradientButtonSave
            // 
            this.gradientButtonSave.Active = false;
            this.gradientButtonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonSave.ForeColor = System.Drawing.Color.Black;
            this.gradientButtonSave.Location = new System.Drawing.Point(108, 9);
            this.gradientButtonSave.Name = "gradientButtonSave";
            this.gradientButtonSave.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonSave.TabIndex = 100;
            this.gradientButtonSave.Text = "Save";
            this.gradientButtonSave.UseVisualStyleBackColor = false;
            this.gradientButtonSave.Click += new System.EventHandler(this.gradientButtonSave_Click);
            // 
            // gradientButtonLoad
            // 
            this.gradientButtonLoad.Active = false;
            this.gradientButtonLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonLoad.ForeColor = System.Drawing.Color.Black;
            this.gradientButtonLoad.Location = new System.Drawing.Point(7, 9);
            this.gradientButtonLoad.Name = "gradientButtonLoad";
            this.gradientButtonLoad.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonLoad.TabIndex = 99;
            this.gradientButtonLoad.Text = "Load";
            this.gradientButtonLoad.UseVisualStyleBackColor = false;
            this.gradientButtonLoad.Click += new System.EventHandler(this.gradientButtonLoad_Click);
            // 
            // panelPresetObjects
            // 
            this.panelPresetObjects.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPresetObjects.Controls.Add(this.gradientPanel26);
            this.panelPresetObjects.Location = new System.Drawing.Point(4, 179);
            this.panelPresetObjects.Name = "panelPresetObjects";
            this.panelPresetObjects.Size = new System.Drawing.Size(215, 180);
            this.panelPresetObjects.TabIndex = 17;
            // 
            // gradientPanel26
            // 
            this.gradientPanel26.Controls.Add(this.gradientButtonMoon);
            this.gradientPanel26.Controls.Add(this.gradientButtonPluto);
            this.gradientPanel26.Controls.Add(this.gradientButtonPlanet);
            this.gradientPanel26.Controls.Add(this.gradientButtonNeptune);
            this.gradientPanel26.Controls.Add(this.gradientButtonUranus);
            this.gradientPanel26.Controls.Add(this.gradientButtonJupiter);
            this.gradientPanel26.Controls.Add(this.gradientButtonSaturn);
            this.gradientPanel26.Controls.Add(this.label3);
            this.gradientPanel26.Controls.Add(this.gradientButtonSun);
            this.gradientPanel26.Controls.Add(this.gradientButtonEarth);
            this.gradientPanel26.Controls.Add(this.gradientButtonMars);
            this.gradientPanel26.Controls.Add(this.gradientButtonVenus);
            this.gradientPanel26.Controls.Add(this.gradientButtonMercury);
            this.gradientPanel26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel26.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel26.Name = "gradientPanel26";
            this.gradientPanel26.Size = new System.Drawing.Size(211, 176);
            this.gradientPanel26.TabIndex = 13;
            // 
            // gradientButtonMoon
            // 
            this.gradientButtonMoon.Active = false;
            this.gradientButtonMoon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonMoon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonMoon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonMoon.Location = new System.Drawing.Point(108, 50);
            this.gradientButtonMoon.Name = "gradientButtonMoon";
            this.gradientButtonMoon.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonMoon.TabIndex = 103;
            this.gradientButtonMoon.Text = "Moon";
            this.gradientButtonMoon.UseVisualStyleBackColor = false;
            this.gradientButtonMoon.Click += new System.EventHandler(this.gradientButtonMoon_Click);
            // 
            // gradientButtonPluto
            // 
            this.gradientButtonPluto.Active = false;
            this.gradientButtonPluto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonPluto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonPluto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonPluto.Location = new System.Drawing.Point(108, 150);
            this.gradientButtonPluto.Name = "gradientButtonPluto";
            this.gradientButtonPluto.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonPluto.TabIndex = 101;
            this.gradientButtonPluto.Text = "Pluto";
            this.gradientButtonPluto.UseVisualStyleBackColor = false;
            this.gradientButtonPluto.Click += new System.EventHandler(this.gradientButtonPluto_Click);
            // 
            // gradientButtonPlanet
            // 
            this.gradientButtonPlanet.Active = false;
            this.gradientButtonPlanet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonPlanet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonPlanet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonPlanet.Location = new System.Drawing.Point(7, 25);
            this.gradientButtonPlanet.Name = "gradientButtonPlanet";
            this.gradientButtonPlanet.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonPlanet.TabIndex = 102;
            this.gradientButtonPlanet.Text = "Planet";
            this.gradientButtonPlanet.UseVisualStyleBackColor = false;
            this.gradientButtonPlanet.Click += new System.EventHandler(this.gradientButtonPlanet_Click);
            // 
            // gradientButtonNeptune
            // 
            this.gradientButtonNeptune.Active = false;
            this.gradientButtonNeptune.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonNeptune.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonNeptune.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonNeptune.Location = new System.Drawing.Point(7, 150);
            this.gradientButtonNeptune.Name = "gradientButtonNeptune";
            this.gradientButtonNeptune.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonNeptune.TabIndex = 100;
            this.gradientButtonNeptune.Text = "Neptune";
            this.gradientButtonNeptune.UseVisualStyleBackColor = false;
            this.gradientButtonNeptune.Click += new System.EventHandler(this.gradientButtonNeptune_Click);
            // 
            // gradientButtonUranus
            // 
            this.gradientButtonUranus.Active = false;
            this.gradientButtonUranus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonUranus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonUranus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonUranus.Location = new System.Drawing.Point(108, 125);
            this.gradientButtonUranus.Name = "gradientButtonUranus";
            this.gradientButtonUranus.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonUranus.TabIndex = 99;
            this.gradientButtonUranus.Text = "Uranus";
            this.gradientButtonUranus.UseVisualStyleBackColor = false;
            this.gradientButtonUranus.Click += new System.EventHandler(this.gradientButtonUranus_Click);
            // 
            // gradientButtonJupiter
            // 
            this.gradientButtonJupiter.Active = false;
            this.gradientButtonJupiter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonJupiter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonJupiter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonJupiter.Location = new System.Drawing.Point(7, 125);
            this.gradientButtonJupiter.Name = "gradientButtonJupiter";
            this.gradientButtonJupiter.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonJupiter.TabIndex = 98;
            this.gradientButtonJupiter.Text = "Jupiter";
            this.gradientButtonJupiter.UseVisualStyleBackColor = false;
            this.gradientButtonJupiter.Click += new System.EventHandler(this.gradientButtonJupiter_Click);
            // 
            // gradientButtonSaturn
            // 
            this.gradientButtonSaturn.Active = false;
            this.gradientButtonSaturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonSaturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonSaturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonSaturn.Location = new System.Drawing.Point(108, 100);
            this.gradientButtonSaturn.Name = "gradientButtonSaturn";
            this.gradientButtonSaturn.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonSaturn.TabIndex = 97;
            this.gradientButtonSaturn.Text = "Saturn";
            this.gradientButtonSaturn.UseVisualStyleBackColor = false;
            this.gradientButtonSaturn.Click += new System.EventHandler(this.gradientButtonSaturn_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "Preset objects";
            // 
            // gradientButtonSun
            // 
            this.gradientButtonSun.Active = false;
            this.gradientButtonSun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonSun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonSun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonSun.Location = new System.Drawing.Point(7, 50);
            this.gradientButtonSun.Name = "gradientButtonSun";
            this.gradientButtonSun.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonSun.TabIndex = 89;
            this.gradientButtonSun.Text = "Sun";
            this.gradientButtonSun.UseVisualStyleBackColor = false;
            this.gradientButtonSun.Click += new System.EventHandler(this.gradientButtonSun_Click);
            // 
            // gradientButtonEarth
            // 
            this.gradientButtonEarth.Active = false;
            this.gradientButtonEarth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonEarth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonEarth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonEarth.Location = new System.Drawing.Point(108, 25);
            this.gradientButtonEarth.Name = "gradientButtonEarth";
            this.gradientButtonEarth.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonEarth.TabIndex = 96;
            this.gradientButtonEarth.Text = "Earth";
            this.gradientButtonEarth.UseVisualStyleBackColor = false;
            this.gradientButtonEarth.Click += new System.EventHandler(this.gradientButtonEarth_Click);
            // 
            // gradientButtonMars
            // 
            this.gradientButtonMars.Active = false;
            this.gradientButtonMars.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonMars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonMars.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonMars.Location = new System.Drawing.Point(7, 100);
            this.gradientButtonMars.Name = "gradientButtonMars";
            this.gradientButtonMars.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonMars.TabIndex = 91;
            this.gradientButtonMars.Text = "Mars";
            this.gradientButtonMars.UseVisualStyleBackColor = false;
            this.gradientButtonMars.Click += new System.EventHandler(this.gradientButtonMars_Click);
            // 
            // gradientButtonVenus
            // 
            this.gradientButtonVenus.Active = false;
            this.gradientButtonVenus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonVenus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonVenus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonVenus.Location = new System.Drawing.Point(108, 75);
            this.gradientButtonVenus.Name = "gradientButtonVenus";
            this.gradientButtonVenus.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonVenus.TabIndex = 90;
            this.gradientButtonVenus.Text = "Venus";
            this.gradientButtonVenus.UseVisualStyleBackColor = false;
            this.gradientButtonVenus.Click += new System.EventHandler(this.gradientButtonVenus_Click);
            // 
            // gradientButtonMercury
            // 
            this.gradientButtonMercury.Active = false;
            this.gradientButtonMercury.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonMercury.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonMercury.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonMercury.Location = new System.Drawing.Point(7, 75);
            this.gradientButtonMercury.Name = "gradientButtonMercury";
            this.gradientButtonMercury.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonMercury.TabIndex = 95;
            this.gradientButtonMercury.Text = "Mercury";
            this.gradientButtonMercury.UseVisualStyleBackColor = false;
            this.gradientButtonMercury.Click += new System.EventHandler(this.gradientButtonMercury_Click);
            // 
            // panelNewObject
            // 
            this.panelNewObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelNewObject.Controls.Add(this.gradientPanel27);
            this.panelNewObject.Location = new System.Drawing.Point(4, 3);
            this.panelNewObject.Name = "panelNewObject";
            this.panelNewObject.Size = new System.Drawing.Size(215, 171);
            this.panelNewObject.TabIndex = 16;
            // 
            // gradientPanel27
            // 
            this.gradientPanel27.Controls.Add(this.checkBoxCircleCCW);
            this.gradientPanel27.Controls.Add(this.checkBoxCircleHost);
            this.gradientPanel27.Controls.Add(this.label41);
            this.gradientPanel27.Controls.Add(this.textBoxName);
            this.gradientPanel27.Controls.Add(this.checkBoxTrace);
            this.gradientPanel27.Controls.Add(this.checkBoxVector);
            this.gradientPanel27.Controls.Add(this.label9);
            this.gradientPanel27.Controls.Add(this.label8);
            this.gradientPanel27.Controls.Add(this.label7);
            this.gradientPanel27.Controls.Add(this.textBoxYSpeed);
            this.gradientPanel27.Controls.Add(this.textBoxXSpeed);
            this.gradientPanel27.Controls.Add(this.textBoxMass);
            this.gradientPanel27.Controls.Add(this.label6);
            this.gradientPanel27.Controls.Add(this.comboBoxShape);
            this.gradientPanel27.Controls.Add(this.label4);
            this.gradientPanel27.Controls.Add(this.label1);
            this.gradientPanel27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel27.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel27.Name = "gradientPanel27";
            this.gradientPanel27.Size = new System.Drawing.Size(211, 167);
            this.gradientPanel27.TabIndex = 11;
            // 
            // checkBoxCircleCCW
            // 
            this.checkBoxCircleCCW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxCircleCCW.Checked = true;
            this.checkBoxCircleCCW.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCircleCCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCircleCCW.Location = new System.Drawing.Point(59, 149);
            this.checkBoxCircleCCW.Name = "checkBoxCircleCCW";
            this.checkBoxCircleCCW.Size = new System.Drawing.Size(51, 17);
            this.checkBoxCircleCCW.TabIndex = 111;
            this.checkBoxCircleCCW.Text = "CCW";
            this.checkBoxCircleCCW.UseVisualStyleBackColor = false;
            this.checkBoxCircleCCW.CheckedChanged += new System.EventHandler(this.checkBoxCircleCCW_CheckedChanged);
            // 
            // checkBoxCircleHost
            // 
            this.checkBoxCircleHost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxCircleHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCircleHost.Location = new System.Drawing.Point(5, 149);
            this.checkBoxCircleHost.Name = "checkBoxCircleHost";
            this.checkBoxCircleHost.Size = new System.Drawing.Size(52, 17);
            this.checkBoxCircleHost.TabIndex = 110;
            this.checkBoxCircleHost.Text = "Circle";
            this.checkBoxCircleHost.UseVisualStyleBackColor = false;
            this.checkBoxCircleHost.CheckedChanged += new System.EventHandler(this.checkBoxCircleHost_CheckedChanged);
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label41.Location = new System.Drawing.Point(11, 29);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(38, 13);
            this.label41.TabIndex = 109;
            this.label41.Text = "Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(99, 25);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(95, 20);
            this.textBoxName.TabIndex = 108;
            this.textBoxName.Text = "Object";
            // 
            // checkBoxTrace
            // 
            this.checkBoxTrace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxTrace.Checked = true;
            this.checkBoxTrace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTrace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxTrace.Location = new System.Drawing.Point(113, 149);
            this.checkBoxTrace.Name = "checkBoxTrace";
            this.checkBoxTrace.Size = new System.Drawing.Size(46, 17);
            this.checkBoxTrace.TabIndex = 107;
            this.checkBoxTrace.Text = "Trail";
            this.checkBoxTrace.UseVisualStyleBackColor = false;
            // 
            // checkBoxVector
            // 
            this.checkBoxVector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxVector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxVector.Location = new System.Drawing.Point(159, 149);
            this.checkBoxVector.Name = "checkBoxVector";
            this.checkBoxVector.Size = new System.Drawing.Size(57, 17);
            this.checkBoxVector.TabIndex = 106;
            this.checkBoxVector.Text = "Vector";
            this.checkBoxVector.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(11, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 104;
            this.label9.Text = "Y-Speed:";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(11, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 103;
            this.label8.Text = "X-Speed";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(11, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 102;
            this.label7.Text = "Mass (10²²kg):";
            // 
            // textBoxYSpeed
            // 
            this.textBoxYSpeed.Enabled = false;
            this.textBoxYSpeed.Location = new System.Drawing.Point(99, 97);
            this.textBoxYSpeed.Name = "textBoxYSpeed";
            this.textBoxYSpeed.Size = new System.Drawing.Size(95, 20);
            this.textBoxYSpeed.TabIndex = 99;
            this.textBoxYSpeed.Text = "0";
            // 
            // textBoxXSpeed
            // 
            this.textBoxXSpeed.Enabled = false;
            this.textBoxXSpeed.Location = new System.Drawing.Point(99, 72);
            this.textBoxXSpeed.Name = "textBoxXSpeed";
            this.textBoxXSpeed.Size = new System.Drawing.Size(95, 20);
            this.textBoxXSpeed.TabIndex = 98;
            this.textBoxXSpeed.Text = "0";
            // 
            // textBoxMass
            // 
            this.textBoxMass.Location = new System.Drawing.Point(99, 48);
            this.textBoxMass.Name = "textBoxMass";
            this.textBoxMass.Size = new System.Drawing.Size(95, 20);
            this.textBoxMass.TabIndex = 97;
            this.textBoxMass.Text = "1000";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(79, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 13);
            this.label6.TabIndex = 96;
            this.label6.Text = "Click in space to place it.";
            // 
            // comboBoxShape
            // 
            this.comboBoxShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxShape.FormattingEnabled = true;
            this.comboBoxShape.Items.AddRange(new object[] {
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
            "Golden Ball",
            "Point",
            "<Custom Shape>"});
            this.comboBoxShape.Location = new System.Drawing.Point(98, 122);
            this.comboBoxShape.Name = "comboBoxShape";
            this.comboBoxShape.Size = new System.Drawing.Size(96, 21);
            this.comboBoxShape.TabIndex = 95;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(11, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 94;
            this.label4.Text = "Shape:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 87;
            this.label1.Text = "New object";
            // 
            // panelPresetSetups
            // 
            this.panelPresetSetups.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPresetSetups.Controls.Add(this.gradientPanel29);
            this.panelPresetSetups.Location = new System.Drawing.Point(4, 364);
            this.panelPresetSetups.Name = "panelPresetSetups";
            this.panelPresetSetups.Size = new System.Drawing.Size(215, 131);
            this.panelPresetSetups.TabIndex = 14;
            // 
            // gradientPanel29
            // 
            this.gradientPanel29.Controls.Add(this.gradientButtonPlanetSystems);
            this.gradientPanel29.Controls.Add(this.gradientButtonGrid);
            this.gradientPanel29.Controls.Add(this.gradientButtonGalaxy);
            this.gradientPanel29.Controls.Add(this.gradientButtonCircle);
            this.gradientPanel29.Controls.Add(this.gradientButtonBinary);
            this.gradientPanel29.Controls.Add(this.labelClickMessage);
            this.gradientPanel29.Controls.Add(this.gradientButtonSlingshot);
            this.gradientPanel29.Controls.Add(this.gradientButtonRandom);
            this.gradientPanel29.Controls.Add(this.gradientButtonSolarSystem);
            this.gradientPanel29.Controls.Add(this.label2);
            this.gradientPanel29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel29.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel29.Name = "gradientPanel29";
            this.gradientPanel29.Size = new System.Drawing.Size(211, 127);
            this.gradientPanel29.TabIndex = 13;
            // 
            // gradientButtonPlanetSystems
            // 
            this.gradientButtonPlanetSystems.Active = false;
            this.gradientButtonPlanetSystems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonPlanetSystems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonPlanetSystems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonPlanetSystems.Location = new System.Drawing.Point(109, 29);
            this.gradientButtonPlanetSystems.Name = "gradientButtonPlanetSystems";
            this.gradientButtonPlanetSystems.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonPlanetSystems.TabIndex = 103;
            this.gradientButtonPlanetSystems.Text = "Planet Systems";
            this.gradientButtonPlanetSystems.UseVisualStyleBackColor = false;
            this.gradientButtonPlanetSystems.Click += new System.EventHandler(this.gradientButtonPlanetSystems_Click);
            // 
            // gradientButtonGrid
            // 
            this.gradientButtonGrid.Active = false;
            this.gradientButtonGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonGrid.Location = new System.Drawing.Point(7, 77);
            this.gradientButtonGrid.Name = "gradientButtonGrid";
            this.gradientButtonGrid.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonGrid.TabIndex = 102;
            this.gradientButtonGrid.Text = "Grid";
            this.gradientButtonGrid.UseVisualStyleBackColor = false;
            this.gradientButtonGrid.Click += new System.EventHandler(this.gradientButtonGrid_Click);
            // 
            // gradientButtonGalaxy
            // 
            this.gradientButtonGalaxy.Active = false;
            this.gradientButtonGalaxy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonGalaxy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonGalaxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonGalaxy.ForeColor = System.Drawing.Color.Black;
            this.gradientButtonGalaxy.Location = new System.Drawing.Point(109, 101);
            this.gradientButtonGalaxy.Name = "gradientButtonGalaxy";
            this.gradientButtonGalaxy.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonGalaxy.TabIndex = 100;
            this.gradientButtonGalaxy.Text = "Galaxy";
            this.gradientButtonGalaxy.UseVisualStyleBackColor = false;
            this.gradientButtonGalaxy.Click += new System.EventHandler(this.gradientButtonGalaxy_Click);
            // 
            // gradientButtonCircle
            // 
            this.gradientButtonCircle.Active = false;
            this.gradientButtonCircle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonCircle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonCircle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonCircle.ForeColor = System.Drawing.Color.Black;
            this.gradientButtonCircle.Location = new System.Drawing.Point(109, 77);
            this.gradientButtonCircle.Name = "gradientButtonCircle";
            this.gradientButtonCircle.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonCircle.TabIndex = 99;
            this.gradientButtonCircle.Text = "Circle";
            this.gradientButtonCircle.UseVisualStyleBackColor = false;
            this.gradientButtonCircle.Click += new System.EventHandler(this.gradientButtonCircle_Click);
            // 
            // gradientButtonBinary
            // 
            this.gradientButtonBinary.Active = false;
            this.gradientButtonBinary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonBinary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonBinary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonBinary.ForeColor = System.Drawing.Color.Black;
            this.gradientButtonBinary.Location = new System.Drawing.Point(7, 53);
            this.gradientButtonBinary.Name = "gradientButtonBinary";
            this.gradientButtonBinary.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonBinary.TabIndex = 97;
            this.gradientButtonBinary.Text = "Binary Systems";
            this.gradientButtonBinary.UseVisualStyleBackColor = false;
            this.gradientButtonBinary.Click += new System.EventHandler(this.gradientButtonDualStar_Click);
            // 
            // labelClickMessage
            // 
            this.labelClickMessage.BackColor = System.Drawing.Color.Black;
            this.labelClickMessage.ForeColor = System.Drawing.Color.Coral;
            this.labelClickMessage.Location = new System.Drawing.Point(96, 6);
            this.labelClickMessage.Name = "labelClickMessage";
            this.labelClickMessage.Size = new System.Drawing.Size(97, 13);
            this.labelClickMessage.TabIndex = 96;
            this.labelClickMessage.Text = "Click in the screen!";
            this.labelClickMessage.Visible = false;
            // 
            // gradientButtonSlingshot
            // 
            this.gradientButtonSlingshot.Active = false;
            this.gradientButtonSlingshot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonSlingshot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonSlingshot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonSlingshot.Location = new System.Drawing.Point(7, 101);
            this.gradientButtonSlingshot.Name = "gradientButtonSlingshot";
            this.gradientButtonSlingshot.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonSlingshot.TabIndex = 92;
            this.gradientButtonSlingshot.Text = "Grav. Slingshot";
            this.gradientButtonSlingshot.UseVisualStyleBackColor = false;
            this.gradientButtonSlingshot.Click += new System.EventHandler(this.gradientButtonSlingshot_Click);
            // 
            // gradientButtonRandom
            // 
            this.gradientButtonRandom.Active = false;
            this.gradientButtonRandom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonRandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonRandom.Location = new System.Drawing.Point(109, 53);
            this.gradientButtonRandom.Name = "gradientButtonRandom";
            this.gradientButtonRandom.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonRandom.TabIndex = 91;
            this.gradientButtonRandom.Text = "Random Objects";
            this.gradientButtonRandom.UseVisualStyleBackColor = false;
            this.gradientButtonRandom.Click += new System.EventHandler(this.gradientButtonRandom_Click);
            // 
            // gradientButtonSolarSystem
            // 
            this.gradientButtonSolarSystem.Active = false;
            this.gradientButtonSolarSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonSolarSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonSolarSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonSolarSystem.Location = new System.Drawing.Point(7, 29);
            this.gradientButtonSolarSystem.Name = "gradientButtonSolarSystem";
            this.gradientButtonSolarSystem.Size = new System.Drawing.Size(96, 18);
            this.gradientButtonSolarSystem.TabIndex = 90;
            this.gradientButtonSolarSystem.Text = "Solar System";
            this.gradientButtonSolarSystem.UseVisualStyleBackColor = false;
            this.gradientButtonSolarSystem.Click += new System.EventHandler(this.gradientButtonSolarSystem_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 88;
            this.label2.Text = "Preset systems";
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gradientPanel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientPanel1.Controls.Add(this.panel4);
            this.gradientPanel1.Controls.Add(this.panelPan);
            this.gradientPanel1.Controls.Add(this.panel5);
            this.gradientPanel1.Controls.Add(this.panel7);
            this.gradientPanel1.Controls.Add(this.panel3);
            this.gradientPanel1.Location = new System.Drawing.Point(0, 622);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1024, 106);
            this.gradientPanel1.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.gradientPanel21);
            this.panel4.Location = new System.Drawing.Point(139, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(546, 96);
            this.panel4.TabIndex = 11;
            // 
            // gradientPanel21
            // 
            this.gradientPanel21.Controls.Add(this.labelTimePerStep);
            this.gradientPanel21.Controls.Add(this.comboBoxCalcsUnit);
            this.gradientPanel21.Controls.Add(this.label40);
            this.gradientPanel21.Controls.Add(this.label12);
            this.gradientPanel21.Controls.Add(this.label20);
            this.gradientPanel21.Controls.Add(this.label38);
            this.gradientPanel21.Controls.Add(this.macTrackBarSpeed);
            this.gradientPanel21.Controls.Add(this.macTrackBarDelay);
            this.gradientPanel21.Controls.Add(this.macTrackBarScale);
            this.gradientPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel21.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel21.Name = "gradientPanel21";
            this.gradientPanel21.Size = new System.Drawing.Size(542, 92);
            this.gradientPanel21.TabIndex = 0;
            // 
            // labelTimePerStep
            // 
            this.labelTimePerStep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelTimePerStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimePerStep.ForeColor = System.Drawing.Color.Navy;
            this.labelTimePerStep.Location = new System.Drawing.Point(14, 8);
            this.labelTimePerStep.Name = "labelTimePerStep";
            this.labelTimePerStep.Size = new System.Drawing.Size(148, 22);
            this.labelTimePerStep.TabIndex = 88;
            this.labelTimePerStep.Text = "XXXX";
            // 
            // comboBoxCalcsUnit
            // 
            this.comboBoxCalcsUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCalcsUnit.FormattingEnabled = true;
            this.comboBoxCalcsUnit.Items.AddRange(new object[] {
            "Automatic",
            "Pre-Calculate",
            "1",
            "2",
            "10",
            "100",
            "500",
            "1000",
            "5000"});
            this.comboBoxCalcsUnit.Location = new System.Drawing.Point(278, 8);
            this.comboBoxCalcsUnit.Name = "comboBoxCalcsUnit";
            this.comboBoxCalcsUnit.Size = new System.Drawing.Size(94, 21);
            this.comboBoxCalcsUnit.TabIndex = 84;
            this.comboBoxCalcsUnit.SelectedIndexChanged += new System.EventHandler(this.comboBoxCalcsUnit_SelectedIndexChanged);
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label40.Location = new System.Drawing.Point(217, 11);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(55, 13);
            this.label40.TabIndex = 82;
            this.label40.Text = "Calc/Unit:";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(12, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 91;
            this.label12.Text = "Speed:";
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label20.Location = new System.Drawing.Point(387, 11);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 13);
            this.label20.TabIndex = 72;
            this.label20.Text = "Delay:";
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label38.Location = new System.Drawing.Point(12, 60);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(37, 13);
            this.label38.TabIndex = 90;
            this.label38.Text = "Scale:";
            // 
            // macTrackBarSpeed
            // 
            this.macTrackBarSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.macTrackBarSpeed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.macTrackBarSpeed.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macTrackBarSpeed.ForeColor = System.Drawing.Color.Black;
            this.macTrackBarSpeed.IndentHeight = 6;
            this.macTrackBarSpeed.Location = new System.Drawing.Point(55, 25);
            this.macTrackBarSpeed.Maximum = 1000;
            this.macTrackBarSpeed.Minimum = 1;
            this.macTrackBarSpeed.Name = "macTrackBarSpeed";
            this.macTrackBarSpeed.Size = new System.Drawing.Size(470, 30);
            this.macTrackBarSpeed.TabIndex = 89;
            this.macTrackBarSpeed.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.macTrackBarSpeed.TickColor = System.Drawing.Color.Transparent;
            this.macTrackBarSpeed.TickHeight = 1;
            this.macTrackBarSpeed.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.macTrackBarSpeed.TrackerSize = new System.Drawing.Size(16, 16);
            this.macTrackBarSpeed.TrackLineColor = System.Drawing.Color.Black;
            this.macTrackBarSpeed.TrackLineHeight = 3;
            this.macTrackBarSpeed.Value = 50;
            this.macTrackBarSpeed.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.macTrackBarSpeed_ValueChanged);
            // 
            // macTrackBarDelay
            // 
            this.macTrackBarDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.macTrackBarDelay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.macTrackBarDelay.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macTrackBarDelay.ForeColor = System.Drawing.Color.Black;
            this.macTrackBarDelay.IndentHeight = 6;
            this.macTrackBarDelay.Location = new System.Drawing.Point(422, 1);
            this.macTrackBarDelay.Maximum = 6;
            this.macTrackBarDelay.Minimum = 0;
            this.macTrackBarDelay.Name = "macTrackBarDelay";
            this.macTrackBarDelay.Size = new System.Drawing.Size(103, 33);
            this.macTrackBarDelay.TabIndex = 74;
            this.macTrackBarDelay.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.macTrackBarDelay.TickColor = System.Drawing.Color.Black;
            this.macTrackBarDelay.TickHeight = 4;
            this.macTrackBarDelay.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.macTrackBarDelay.TrackerSize = new System.Drawing.Size(16, 16);
            this.macTrackBarDelay.TrackLineColor = System.Drawing.Color.Black;
            this.macTrackBarDelay.TrackLineHeight = 3;
            this.macTrackBarDelay.Value = 0;
            this.macTrackBarDelay.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.macTrackBarDelay_ValueChanged);
            // 
            // macTrackBarScale
            // 
            this.macTrackBarScale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.macTrackBarScale.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.macTrackBarScale.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macTrackBarScale.ForeColor = System.Drawing.Color.Black;
            this.macTrackBarScale.IndentHeight = 6;
            this.macTrackBarScale.Location = new System.Drawing.Point(55, 55);
            this.macTrackBarScale.Maximum = 400;
            this.macTrackBarScale.Minimum = 1;
            this.macTrackBarScale.Name = "macTrackBarScale";
            this.macTrackBarScale.Size = new System.Drawing.Size(470, 30);
            this.macTrackBarScale.TabIndex = 77;
            this.macTrackBarScale.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.macTrackBarScale.TickColor = System.Drawing.Color.Transparent;
            this.macTrackBarScale.TickHeight = 1;
            this.macTrackBarScale.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.macTrackBarScale.TrackerSize = new System.Drawing.Size(16, 16);
            this.macTrackBarScale.TrackLineColor = System.Drawing.Color.Black;
            this.macTrackBarScale.TrackLineHeight = 3;
            this.macTrackBarScale.Value = 50;
            this.macTrackBarScale.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.macTrackBarScale_ValueChanged);
            // 
            // panelPan
            // 
            this.panelPan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPan.Controls.Add(this.gradientPanel210);
            this.panelPan.Location = new System.Drawing.Point(916, 3);
            this.panelPan.Name = "panelPan";
            this.panelPan.Size = new System.Drawing.Size(103, 96);
            this.panelPan.TabIndex = 10;
            // 
            // gradientPanel210
            // 
            this.gradientPanel210.Controls.Add(this.buttonLeft);
            this.gradientPanel210.Controls.Add(this.buttonRight);
            this.gradientPanel210.Controls.Add(this.buttonDown);
            this.gradientPanel210.Controls.Add(this.buttonUp);
            this.gradientPanel210.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel210.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel210.Name = "gradientPanel210";
            this.gradientPanel210.Size = new System.Drawing.Size(99, 92);
            this.gradientPanel210.TabIndex = 4;
            // 
            // buttonLeft
            // 
            this.buttonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonLeft.Image = global::GravityOne.Resources.arrowleft;
            this.buttonLeft.Location = new System.Drawing.Point(0, 31);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(34, 34);
            this.buttonLeft.TabIndex = 3;
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonLeft_MouseDown);
            this.buttonLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonLeft_MouseUp);
            // 
            // buttonRight
            // 
            this.buttonRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonRight.Image = global::GravityOne.Resources.arrowright;
            this.buttonRight.Location = new System.Drawing.Point(66, 31);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(34, 34);
            this.buttonRight.TabIndex = 2;
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRight_MouseDown);
            this.buttonRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonRight_MouseUp);
            // 
            // buttonDown
            // 
            this.buttonDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonDown.Image = global::GravityOne.Resources.arrowdown;
            this.buttonDown.Location = new System.Drawing.Point(32, 53);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(34, 34);
            this.buttonDown.TabIndex = 1;
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonDown_MouseDown);
            this.buttonDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonDown_MouseUp);
            // 
            // buttonUp
            // 
            this.buttonUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonUp.Image = global::GravityOne.Resources.arrowup;
            this.buttonUp.Location = new System.Drawing.Point(32, 8);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(34, 34);
            this.buttonUp.TabIndex = 0;
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonUp_MouseDown);
            this.buttonUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonUp_MouseUp);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkGray;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.gradientPanel22);
            this.panel5.Location = new System.Drawing.Point(813, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(97, 96);
            this.panel5.TabIndex = 7;
            // 
            // gradientPanel22
            // 
            this.gradientPanel22.Controls.Add(this.checkBoxReverse);
            this.gradientPanel22.Controls.Add(this.checkBoxShowNames);
            this.gradientPanel22.Controls.Add(this.checkBoxVectorsAll);
            this.gradientPanel22.Controls.Add(this.checkBoxTraceAll);
            this.gradientPanel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel22.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel22.Name = "gradientPanel22";
            this.gradientPanel22.Size = new System.Drawing.Size(93, 92);
            this.gradientPanel22.TabIndex = 10;
            // 
            // checkBoxReverse
            // 
            this.checkBoxReverse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxReverse.Checked = true;
            this.checkBoxReverse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxReverse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxReverse.Location = new System.Drawing.Point(5, 50);
            this.checkBoxReverse.Name = "checkBoxReverse";
            this.checkBoxReverse.Size = new System.Drawing.Size(66, 17);
            this.checkBoxReverse.TabIndex = 30;
            this.checkBoxReverse.Text = "Reverse";
            this.checkBoxReverse.UseVisualStyleBackColor = false;
            this.checkBoxReverse.CheckedChanged += new System.EventHandler(this.checkBoxReverse_CheckedChanged);
            // 
            // checkBoxShowNames
            // 
            this.checkBoxShowNames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxShowNames.Checked = true;
            this.checkBoxShowNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxShowNames.Location = new System.Drawing.Point(5, 70);
            this.checkBoxShowNames.Name = "checkBoxShowNames";
            this.checkBoxShowNames.Size = new System.Drawing.Size(87, 17);
            this.checkBoxShowNames.TabIndex = 29;
            this.checkBoxShowNames.Text = "Show names";
            this.checkBoxShowNames.UseVisualStyleBackColor = false;
            this.checkBoxShowNames.CheckedChanged += new System.EventHandler(this.checkBoxShowNames_CheckedChanged);
            // 
            // checkBoxVectorsAll
            // 
            this.checkBoxVectorsAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxVectorsAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxVectorsAll.Location = new System.Drawing.Point(5, 28);
            this.checkBoxVectorsAll.Name = "checkBoxVectorsAll";
            this.checkBoxVectorsAll.Size = new System.Drawing.Size(75, 17);
            this.checkBoxVectorsAll.TabIndex = 25;
            this.checkBoxVectorsAll.Text = "Vectors all";
            this.checkBoxVectorsAll.UseVisualStyleBackColor = false;
            this.checkBoxVectorsAll.CheckedChanged += new System.EventHandler(this.checkBoxVectorsAll_CheckedChanged);
            // 
            // checkBoxTraceAll
            // 
            this.checkBoxTraceAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxTraceAll.Checked = true;
            this.checkBoxTraceAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTraceAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxTraceAll.Location = new System.Drawing.Point(5, 7);
            this.checkBoxTraceAll.Name = "checkBoxTraceAll";
            this.checkBoxTraceAll.Size = new System.Drawing.Size(64, 17);
            this.checkBoxTraceAll.TabIndex = 24;
            this.checkBoxTraceAll.Text = "Trails all";
            this.checkBoxTraceAll.UseVisualStyleBackColor = false;
            this.checkBoxTraceAll.CheckedChanged += new System.EventHandler(this.checkBoxTraceAll_CheckedChanged);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DarkGray;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.gradientPanel23);
            this.panel7.Location = new System.Drawing.Point(689, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(120, 97);
            this.panel7.TabIndex = 6;
            // 
            // gradientPanel23
            // 
            this.gradientPanel23.Controls.Add(this.gradientButtonPreferences);
            this.gradientPanel23.Controls.Add(this.gradientButtonToggleObject);
            this.gradientPanel23.Controls.Add(this.gradientButtonToggleToolbox);
            this.gradientPanel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel23.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel23.Name = "gradientPanel23";
            this.gradientPanel23.Size = new System.Drawing.Size(116, 93);
            this.gradientPanel23.TabIndex = 12;
            // 
            // gradientButtonPreferences
            // 
            this.gradientButtonPreferences.Active = false;
            this.gradientButtonPreferences.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonPreferences.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonPreferences.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonPreferences.Location = new System.Drawing.Point(8, 63);
            this.gradientButtonPreferences.Name = "gradientButtonPreferences";
            this.gradientButtonPreferences.Size = new System.Drawing.Size(102, 25);
            this.gradientButtonPreferences.TabIndex = 44;
            this.gradientButtonPreferences.Text = "preferences";
            this.gradientButtonPreferences.UseVisualStyleBackColor = false;
            this.gradientButtonPreferences.Click += new System.EventHandler(this.gradientButtonPreferences_Click);
            // 
            // gradientButtonToggleObject
            // 
            this.gradientButtonToggleObject.Active = true;
            this.gradientButtonToggleObject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonToggleObject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonToggleObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonToggleObject.Location = new System.Drawing.Point(8, 34);
            this.gradientButtonToggleObject.Name = "gradientButtonToggleObject";
            this.gradientButtonToggleObject.Size = new System.Drawing.Size(102, 25);
            this.gradientButtonToggleObject.TabIndex = 43;
            this.gradientButtonToggleObject.Text = "object properties";
            this.gradientButtonToggleObject.UseVisualStyleBackColor = false;
            this.gradientButtonToggleObject.Click += new System.EventHandler(this.gradientButtonToggleObject_Click);
            // 
            // gradientButtonToggleToolbox
            // 
            this.gradientButtonToggleToolbox.Active = true;
            this.gradientButtonToggleToolbox.BackColor = System.Drawing.Color.Black;
            this.gradientButtonToggleToolbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonToggleToolbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonToggleToolbox.Location = new System.Drawing.Point(8, 5);
            this.gradientButtonToggleToolbox.Name = "gradientButtonToggleToolbox";
            this.gradientButtonToggleToolbox.Size = new System.Drawing.Size(102, 25);
            this.gradientButtonToggleToolbox.TabIndex = 41;
            this.gradientButtonToggleToolbox.Text = "editor";
            this.gradientButtonToggleToolbox.UseVisualStyleBackColor = false;
            this.gradientButtonToggleToolbox.Click += new System.EventHandler(this.gradientButtonToggleToolbox_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.gradientPanel24);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(130, 97);
            this.panel3.TabIndex = 5;
            // 
            // gradientPanel24
            // 
            this.gradientPanel24.Controls.Add(this.gradientButtonCaptureVideo);
            this.gradientPanel24.Controls.Add(this.gradientButtonRewind);
            this.gradientPanel24.Controls.Add(this.gradientButtonStep);
            this.gradientPanel24.Controls.Add(this.gradientButtonStart);
            this.gradientPanel24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel24.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel24.Name = "gradientPanel24";
            this.gradientPanel24.Size = new System.Drawing.Size(126, 93);
            this.gradientPanel24.TabIndex = 27;
            // 
            // gradientButtonRewind
            // 
            this.gradientButtonRewind.Active = false;
            this.gradientButtonRewind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonRewind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonRewind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonRewind.Image = global::GravityOne.Resources.icon_rewind_32;
            this.gradientButtonRewind.Location = new System.Drawing.Point(8, 50);
            this.gradientButtonRewind.Name = "gradientButtonRewind";
            this.gradientButtonRewind.Size = new System.Drawing.Size(70, 37);
            this.gradientButtonRewind.TabIndex = 85;
            this.gradientButtonRewind.UseVisualStyleBackColor = false;
            this.gradientButtonRewind.Click += new System.EventHandler(this.gradientButtonRewind_Click);
            // 
            // gradientButtonStep
            // 
            this.gradientButtonStep.Active = false;
            this.gradientButtonStep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonStep.Image = ((System.Drawing.Image)(resources.GetObject("gradientButtonStep.Image")));
            this.gradientButtonStep.Location = new System.Drawing.Point(84, 7);
            this.gradientButtonStep.Name = "gradientButtonStep";
            this.gradientButtonStep.Size = new System.Drawing.Size(38, 37);
            this.gradientButtonStep.TabIndex = 43;
            this.gradientButtonStep.UseVisualStyleBackColor = false;
            this.gradientButtonStep.Click += new System.EventHandler(this.gradientButtonStep_Click);
            // 
            // gradientButtonStart
            // 
            this.gradientButtonStart.Active = false;
            this.gradientButtonStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("gradientButtonStart.Image")));
            this.gradientButtonStart.Location = new System.Drawing.Point(8, 7);
            this.gradientButtonStart.Name = "gradientButtonStart";
            this.gradientButtonStart.Size = new System.Drawing.Size(70, 37);
            this.gradientButtonStart.TabIndex = 42;
            this.gradientButtonStart.UseVisualStyleBackColor = false;
            this.gradientButtonStart.Click += new System.EventHandler(this.gradientButtonStart_Click);
            // 
            // displayXNA
            // 
            this.displayXNA.BackgroundIndex = 0;
            blendState1.AlphaBlendFunction = Microsoft.Xna.Framework.Graphics.BlendFunction.Add;
            blendState1.AlphaDestinationBlend = Microsoft.Xna.Framework.Graphics.Blend.InverseSourceAlpha;
            blendState1.AlphaSourceBlend = Microsoft.Xna.Framework.Graphics.Blend.One;
            blendState1.ColorBlendFunction = Microsoft.Xna.Framework.Graphics.BlendFunction.Add;
            blendState1.ColorDestinationBlend = Microsoft.Xna.Framework.Graphics.Blend.InverseSourceAlpha;
            blendState1.ColorSourceBlend = Microsoft.Xna.Framework.Graphics.Blend.One;
            blendState1.ColorWriteChannels = ((Microsoft.Xna.Framework.Graphics.ColorWriteChannels)((((Microsoft.Xna.Framework.Graphics.ColorWriteChannels.Red | Microsoft.Xna.Framework.Graphics.ColorWriteChannels.Green) 
            | Microsoft.Xna.Framework.Graphics.ColorWriteChannels.Blue) 
            | Microsoft.Xna.Framework.Graphics.ColorWriteChannels.Alpha)));
            blendState1.ColorWriteChannels1 = ((Microsoft.Xna.Framework.Graphics.ColorWriteChannels)((((Microsoft.Xna.Framework.Graphics.ColorWriteChannels.Red | Microsoft.Xna.Framework.Graphics.ColorWriteChannels.Green) 
            | Microsoft.Xna.Framework.Graphics.ColorWriteChannels.Blue) 
            | Microsoft.Xna.Framework.Graphics.ColorWriteChannels.Alpha)));
            blendState1.ColorWriteChannels2 = ((Microsoft.Xna.Framework.Graphics.ColorWriteChannels)((((Microsoft.Xna.Framework.Graphics.ColorWriteChannels.Red | Microsoft.Xna.Framework.Graphics.ColorWriteChannels.Green) 
            | Microsoft.Xna.Framework.Graphics.ColorWriteChannels.Blue) 
            | Microsoft.Xna.Framework.Graphics.ColorWriteChannels.Alpha)));
            blendState1.ColorWriteChannels3 = ((Microsoft.Xna.Framework.Graphics.ColorWriteChannels)((((Microsoft.Xna.Framework.Graphics.ColorWriteChannels.Red | Microsoft.Xna.Framework.Graphics.ColorWriteChannels.Green) 
            | Microsoft.Xna.Framework.Graphics.ColorWriteChannels.Blue) 
            | Microsoft.Xna.Framework.Graphics.ColorWriteChannels.Alpha)));
            blendState1.IndependentBlendEnable = false;
            blendState1.MultiSampleMask = -1;
            blendState1.Name = "BlendState.AlphaBlend";
            blendState1.Tag = null;
            this.displayXNA.BlendState = blendState1;
            this.displayXNA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayXNA.Location = new System.Drawing.Point(0, 0);
            this.displayXNA.Name = "displayXNA";
            this.displayXNA.ParentForm = null;
            this.displayXNA.RecordingVideo = false;
            this.displayXNA.Reverse = false;
            this.displayXNA.SecondsPerStep = ((long)(1));
            this.displayXNA.ShowAsDots = false;
            this.displayXNA.ShowNames = true;
            this.displayXNA.ShowScale = true;
            this.displayXNA.ShowTrailsAll = true;
            this.displayXNA.ShowVectorsAll = false;
            this.displayXNA.SimulationRunning = false;
            this.displayXNA.SimulationStepping = false;
            this.displayXNA.SimulationTime = new System.DateTime(((long)(0)));
            this.displayXNA.SimulationTime1 = new System.DateTime(((long)(0)));
            this.displayXNA.SimulationTimeLarge = ((long)(0));
            this.displayXNA.Size = new System.Drawing.Size(1277, 728);
            this.displayXNA.TabIndex = 0;
            this.displayXNA.Text = "display1";
            this.displayXNA.TextureArrow = null;
            this.displayXNA.TextureAsteroid = null;
            this.displayXNA.TextureBackground = null;
            this.displayXNA.TextureEarth = null;
            this.displayXNA.TextureGoldenBall = null;
            this.displayXNA.TextureJupiter = null;
            this.displayXNA.TextureLargeDot = null;
            this.displayXNA.TextureMars = null;
            this.displayXNA.TextureMercury = null;
            this.displayXNA.TextureMetalBall = null;
            this.displayXNA.TextureMoon = null;
            this.displayXNA.TextureNeptune = null;
            this.displayXNA.TexturePlanet = null;
            this.displayXNA.TexturePluto = null;
            this.displayXNA.TextureRedBall = null;
            this.displayXNA.TextureSaturn = null;
            this.displayXNA.TextureSmallDot = null;
            this.displayXNA.TextureSun = null;
            this.displayXNA.TextureTrace = null;
            this.displayXNA.TextureUranus = null;
            this.displayXNA.TextureVector = null;
            this.displayXNA.TextureVenus = null;
            this.displayXNA.VideoCaptureCompression = null;
            this.displayXNA.VideoCaptureFPS = 60;
            this.displayXNA.MouseClick += new System.Windows.Forms.MouseEventHandler(this.displayXNA_Click);
            this.displayXNA.MouseMove += new System.Windows.Forms.MouseEventHandler(this.displayXNA_MouseMove);
            // 
            // macTrackBar1
            // 
            this.macTrackBar1.BackColor = System.Drawing.Color.Transparent;
            this.macTrackBar1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.macTrackBar1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macTrackBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.macTrackBar1.IndentHeight = 6;
            this.macTrackBar1.Location = new System.Drawing.Point(42, 1);
            this.macTrackBar1.Maximum = 10;
            this.macTrackBar1.Minimum = 0;
            this.macTrackBar1.Name = "macTrackBar1";
            this.macTrackBar1.Size = new System.Drawing.Size(181, 29);
            this.macTrackBar1.TabIndex = 31;
            this.macTrackBar1.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.macTrackBar1.TickColor = System.Drawing.Color.Black;
            this.macTrackBar1.TickHeight = 4;
            this.macTrackBar1.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.macTrackBar1.TrackerSize = new System.Drawing.Size(12, 12);
            this.macTrackBar1.TrackLineColor = System.Drawing.Color.Black;
            this.macTrackBar1.TrackLineHeight = 5;
            this.macTrackBar1.Value = 0;
            // 
            // macTrackBar2
            // 
            this.macTrackBar2.BackColor = System.Drawing.Color.Transparent;
            this.macTrackBar2.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.macTrackBar2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macTrackBar2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.macTrackBar2.IndentHeight = 6;
            this.macTrackBar2.Location = new System.Drawing.Point(151, 48);
            this.macTrackBar2.Maximum = 5;
            this.macTrackBar2.Minimum = 0;
            this.macTrackBar2.Name = "macTrackBar2";
            this.macTrackBar2.Size = new System.Drawing.Size(112, 29);
            this.macTrackBar2.TabIndex = 33;
            this.macTrackBar2.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.macTrackBar2.TickColor = System.Drawing.Color.Black;
            this.macTrackBar2.TickHeight = 4;
            this.macTrackBar2.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.macTrackBar2.TrackerSize = new System.Drawing.Size(12, 12);
            this.macTrackBar2.TrackLineColor = System.Drawing.Color.Black;
            this.macTrackBar2.TrackLineHeight = 5;
            this.macTrackBar2.Value = 0;
            // 
            // gradientButton3
            // 
            this.gradientButton3.Active = false;
            this.gradientButton3.Location = new System.Drawing.Point(0, 0);
            this.gradientButton3.Name = "gradientButton3";
            this.gradientButton3.Size = new System.Drawing.Size(75, 23);
            this.gradientButton3.TabIndex = 0;
            // 
            // gradientButton1
            // 
            this.gradientButton1.Active = false;
            this.gradientButton1.Location = new System.Drawing.Point(0, 0);
            this.gradientButton1.Name = "gradientButton1";
            this.gradientButton1.Size = new System.Drawing.Size(75, 23);
            this.gradientButton1.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 728);
            this.Controls.Add(this.gradientPanelObjectProperties);
            this.Controls.Add(this.gradientPanelAdjustValues);
            this.Controls.Add(this.gradientPanelToolbox);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.displayXNA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Gravity One v1.4 - by Peter Popma 2017 - p_popma@hotmail.com";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.gradientPanelObjectProperties.ResumeLayout(false);
            this.gradientPanel25.ResumeLayout(false);
            this.panelObjectProperties.ResumeLayout(false);
            this.gradientPanelObjectProperties2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gradientPanelAdjustValues.ResumeLayout(false);
            this.panelInnerAdjustValues.ResumeLayout(false);
            this.gradientPanel28.ResumeLayout(false);
            this.gradientPanel28.PerformLayout();
            this.gradientPanelToolbox.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gradientPanel211.ResumeLayout(false);
            this.panelPresetObjects.ResumeLayout(false);
            this.gradientPanel26.ResumeLayout(false);
            this.panelNewObject.ResumeLayout(false);
            this.gradientPanel27.ResumeLayout(false);
            this.gradientPanel27.PerformLayout();
            this.panelPresetSetups.ResumeLayout(false);
            this.gradientPanel29.ResumeLayout(false);
            this.gradientPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.gradientPanel21.ResumeLayout(false);
            this.gradientPanel21.PerformLayout();
            this.panelPan.ResumeLayout(false);
            this.gradientPanel210.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.gradientPanel22.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.gradientPanel23.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.gradientPanel24.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CustomControls.GradientPanel gradientPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private XComponent.SliderBar.MACTrackBar macTrackBar1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private CustomControls.GradientPanel2 gradientPanel22;
        private System.Windows.Forms.CheckBox checkBoxVectorsAll;
        private System.Windows.Forms.Panel panel7;
        private CustomControls.GradientPanel2 gradientPanel23;
        private CustomControls.GradientPanel2 gradientPanel24;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxLimit;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelNumObjects;
        private XComponent.SliderBar.MACTrackBar macTrackBar2;
        private CustomControls.Display displayXNA;
        private CustomControls.GradientButton gradientButton1;
        private CustomControls.GradientButton gradientButtonToggleToolbox;
        private CustomControls.GradientButton gradientButton3;
        private CustomControls.GradientPanel gradientPanelToolbox;
        private System.Windows.Forms.Panel panelPresetObjects;
        private CustomControls.GradientPanel2 gradientPanel26;
        private CustomControls.GradientButton gradientButtonMercury;
        private CustomControls.GradientButton gradientButtonMars;
        private CustomControls.GradientButton gradientButtonVenus;
        private CustomControls.GradientButton gradientButtonSun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelNewObject;
        private CustomControls.GradientPanel2 gradientPanel27;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelPresetSetups;
        private CustomControls.GradientPanel2 gradientPanel29;
        private CustomControls.GradientButton gradientButtonSlingshot;
        private CustomControls.GradientButton gradientButtonSolarSystem;
        private System.Windows.Forms.Label label2;
        private CustomControls.GradientButton gradientButtonPluto;
        private CustomControls.GradientButton gradientButtonNeptune;
        private CustomControls.GradientButton gradientButtonUranus;
        private CustomControls.GradientButton gradientButtonJupiter;
        private CustomControls.GradientButton gradientButtonSaturn;
        private CustomControls.GradientButton gradientButtonEarth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private CustomControls.GradientPanel gradientPanelAdjustValues;
        private System.Windows.Forms.Panel panelInnerAdjustValues;
        private CustomControls.GradientPanel2 gradientPanel28;
        private CustomControls.GradientButton gradientButtonReady;
        private System.Windows.Forms.TextBox textBoxAdjustMass;
        private System.Windows.Forms.TextBox textBoxAdjustYSpeed;
        private System.Windows.Forms.TextBox textBoxAdjustXSpeed;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label20;
        private CustomControls.GradientButton gradientButtonStart;
        private XComponent.SliderBar.MACTrackBar macTrackBarDelay;
        private System.Windows.Forms.Label label41;
        internal System.Windows.Forms.TextBox textBoxMass;
        internal System.Windows.Forms.TextBox textBoxName;
        internal System.Windows.Forms.ComboBox comboBoxShape;
        internal System.Windows.Forms.TextBox textBoxYSpeed;
        internal System.Windows.Forms.TextBox textBoxXSpeed;
        internal System.Windows.Forms.CheckBox checkBoxTrace;
        internal System.Windows.Forms.CheckBox checkBoxVector;
        private CustomControls.GradientButton gradientButtonPlanet;
        private CustomControls.GradientButton gradientButtonMoon;
        private System.Windows.Forms.Panel panelPan;
        private System.Windows.Forms.TextBox textBoxAdjustName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panelObjectProperties;
        internal CustomControls.GradientButton gradientButtonToggleObject;
        internal CustomControls.GradientPanel gradientPanelObjectProperties;
        private CustomControls.GradientPanel2 gradientPanel210;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private CustomControls.GradientPanel2 gradientPanel25;
        private CustomControls.GradientButton gradientButtonNextObject;
        private CustomControls.GradientButton gradientButtonPreviousObject;
        private System.Windows.Forms.Label labelObjectNumber;
        private CustomControls.GradientPanel2 gradientPanelObjectProperties2;
        private CustomControls.GradientButton gradientButtonAdjustValues;
        private CustomControls.GradientButton gradientButtonRemove;
        private System.Windows.Forms.Label labelMass;
        private System.Windows.Forms.Label labelYAcceleration;
        private System.Windows.Forms.Label labelXAcceleration;
        private System.Windows.Forms.Label labelAcceleration;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label labelDistanceToZero;
        private System.Windows.Forms.Label labelYSpeed;
        internal System.Windows.Forms.Label labelXSpeed;
        public System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBoxCenter;
        private System.Windows.Forms.Label labelObjectName;
        private System.Windows.Forms.Label labelNumberObjects;
        private System.Windows.Forms.Label label19;
        internal System.Windows.Forms.CheckBox checkBoxAdjustTrace;
        internal System.Windows.Forms.CheckBox checkBoxAdjustVector;
        internal CustomControls.GradientButton gradientButtonPreferences;
        private System.Windows.Forms.Panel panel1;
        private GradientPanel2 gradientPanel211;
        private GradientButton gradientButtonRemoveAll;
        private GradientButton gradientButtonSave;
        private GradientButton gradientButtonLoad;
        private System.Windows.Forms.Label label40;
        internal System.Windows.Forms.CheckBox checkBoxCircleHost;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPreCalculate;
        internal System.Windows.Forms.ComboBox comboBoxCalcsUnit;
        internal System.Windows.Forms.CheckBox checkBoxCircleCCW;
        internal System.Windows.Forms.CheckBox checkBoxShowNames;
        internal GradientButton gradientButtonGalaxy;
        internal System.Windows.Forms.CheckBox checkBoxTraceAll;
        internal System.Windows.Forms.Label labelClickMessage;
        internal System.Windows.Forms.CheckBox checkBoxReverse;
        internal GradientButton gradientButtonRandom;
        private System.Windows.Forms.Panel panel2;
        internal GradientButton gradientButtonGrid;
        internal GradientButton gradientButtonStep;
        internal GradientButton gradientButtonRewind;
        private GradientButton gradientButtonPick;
        internal GradientButton gradientButtonCaptureVideo;
        internal GradientButton gradientButtonBinary;
        private System.Windows.Forms.ToolTip toolTipCaptureVideo;
        internal GradientButton gradientButtonPlanetSystems;
        internal GradientButton gradientButtonCircle;
        private System.Windows.Forms.Panel panel4;
        private GradientPanel2 gradientPanel21;
        private System.Windows.Forms.Label label38;
        internal XComponent.SliderBar.MACTrackBar macTrackBarSpeed;
        private System.Windows.Forms.Label labelTimePerStep;
        internal XComponent.SliderBar.MACTrackBar macTrackBarScale;
        private System.Windows.Forms.Label label12;

        public Display DisplayXNA
        {
            get
            {
                return displayXNA;
            }

            set
            {
                displayXNA = value;
            }
        }
    }
}