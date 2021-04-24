namespace GravityOne.Forms
{
    partial class FormSolarSystems
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
            this.comboBoxSolarSystems = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gradientPanel22 = new GravityOne.CustomControls.GradientPanel2();
            this.textBoxYSpeed = new System.Windows.Forms.TextBox();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.labelYPos = new System.Windows.Forms.Label();
            this.labelXPos = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelNumObjects = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelMass = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxXSpeed = new System.Windows.Forms.TextBox();
            this.gradientButtonUpdate = new GravityOne.CustomControls.GradientButton();
            this.gradientButtonClose = new GravityOne.CustomControls.GradientButton();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxObjects = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gradientPanel21.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gradientPanel22.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel21
            // 
            this.gradientPanel21.Controls.Add(this.comboBoxSolarSystems);
            this.gradientPanel21.Controls.Add(this.panel1);
            this.gradientPanel21.Controls.Add(this.gradientButtonClose);
            this.gradientPanel21.Controls.Add(this.label2);
            this.gradientPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel21.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel21.Name = "gradientPanel21";
            this.gradientPanel21.Size = new System.Drawing.Size(482, 430);
            this.gradientPanel21.TabIndex = 152;
            // 
            // comboBoxSolarSystems
            // 
            this.comboBoxSolarSystems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSolarSystems.FormattingEnabled = true;
            this.comboBoxSolarSystems.Location = new System.Drawing.Point(92, 13);
            this.comboBoxSolarSystems.Name = "comboBoxSolarSystems";
            this.comboBoxSolarSystems.Size = new System.Drawing.Size(263, 21);
            this.comboBoxSolarSystems.TabIndex = 155;
            this.comboBoxSolarSystems.SelectedIndexChanged += new System.EventHandler(this.comboBoxSolarSystems_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.gradientPanel22);
            this.panel1.Location = new System.Drawing.Point(15, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 314);
            this.panel1.TabIndex = 154;
            // 
            // gradientPanel22
            // 
            this.gradientPanel22.Controls.Add(this.label7);
            this.gradientPanel22.Controls.Add(this.comboBoxObjects);
            this.gradientPanel22.Controls.Add(this.textBoxYSpeed);
            this.gradientPanel22.Controls.Add(this.checkBoxActive);
            this.gradientPanel22.Controls.Add(this.labelYPos);
            this.gradientPanel22.Controls.Add(this.labelXPos);
            this.gradientPanel22.Controls.Add(this.label6);
            this.gradientPanel22.Controls.Add(this.label5);
            this.gradientPanel22.Controls.Add(this.textBoxName);
            this.gradientPanel22.Controls.Add(this.labelNumObjects);
            this.gradientPanel22.Controls.Add(this.label4);
            this.gradientPanel22.Controls.Add(this.labelMass);
            this.gradientPanel22.Controls.Add(this.label3);
            this.gradientPanel22.Controls.Add(this.label1);
            this.gradientPanel22.Controls.Add(this.label10);
            this.gradientPanel22.Controls.Add(this.label14);
            this.gradientPanel22.Controls.Add(this.textBoxXSpeed);
            this.gradientPanel22.Controls.Add(this.gradientButtonUpdate);
            this.gradientPanel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel22.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel22.Name = "gradientPanel22";
            this.gradientPanel22.Size = new System.Drawing.Size(447, 310);
            this.gradientPanel22.TabIndex = 159;
            // 
            // textBoxYSpeed
            // 
            this.textBoxYSpeed.Location = new System.Drawing.Point(190, 210);
            this.textBoxYSpeed.Name = "textBoxYSpeed";
            this.textBoxYSpeed.Size = new System.Drawing.Size(156, 20);
            this.textBoxYSpeed.TabIndex = 157;
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxActive.Location = new System.Drawing.Point(10, 241);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(195, 17);
            this.checkBoxActive.TabIndex = 168;
            this.checkBoxActive.Text = "Calculate gravity (as galaxy object)  ";
            this.checkBoxActive.UseVisualStyleBackColor = false;
            // 
            // labelYPos
            // 
            this.labelYPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelYPos.Location = new System.Drawing.Point(188, 126);
            this.labelYPos.Name = "labelYPos";
            this.labelYPos.Size = new System.Drawing.Size(156, 13);
            this.labelYPos.TabIndex = 167;
            this.labelYPos.Text = "xxxx";
            // 
            // labelXPos
            // 
            this.labelXPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelXPos.Location = new System.Drawing.Point(187, 102);
            this.labelXPos.Name = "labelXPos";
            this.labelXPos.Size = new System.Drawing.Size(156, 13);
            this.labelXPos.TabIndex = 166;
            this.labelXPos.Text = "xxxx";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(10, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 11);
            this.label6.TabIndex = 165;
            this.label6.Text = "Y-Position:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(10, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 164;
            this.label5.Text = "X-Position:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(190, 153);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(156, 20);
            this.textBoxName.TabIndex = 152;
            // 
            // labelNumObjects
            // 
            this.labelNumObjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelNumObjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumObjects.Location = new System.Drawing.Point(189, 18);
            this.labelNumObjects.Name = "labelNumObjects";
            this.labelNumObjects.Size = new System.Drawing.Size(76, 20);
            this.labelNumObjects.TabIndex = 163;
            this.labelNumObjects.Text = "xxxx";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 162;
            this.label4.Text = "Number of objects:";
            // 
            // labelMass
            // 
            this.labelMass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelMass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMass.Location = new System.Drawing.Point(188, 76);
            this.labelMass.Name = "labelMass";
            this.labelMass.Size = new System.Drawing.Size(76, 20);
            this.labelMass.TabIndex = 161;
            this.labelMass.Text = "xxxx";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 160;
            this.label3.Text = "Total Mass (10²²kg):";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(10, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 159;
            this.label1.Text = "YSpeed (m/s):";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(10, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 158;
            this.label10.Text = "XSpeed (m/s):";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(10, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 157;
            this.label14.Text = "Name:";
            // 
            // textBoxXSpeed
            // 
            this.textBoxXSpeed.Location = new System.Drawing.Point(190, 182);
            this.textBoxXSpeed.Name = "textBoxXSpeed";
            this.textBoxXSpeed.Size = new System.Drawing.Size(156, 20);
            this.textBoxXSpeed.TabIndex = 153;
            // 
            // gradientButtonUpdate
            // 
            this.gradientButtonUpdate.Active = false;
            this.gradientButtonUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonUpdate.Location = new System.Drawing.Point(179, 271);
            this.gradientButtonUpdate.Name = "gradientButtonUpdate";
            this.gradientButtonUpdate.Size = new System.Drawing.Size(91, 21);
            this.gradientButtonUpdate.TabIndex = 154;
            this.gradientButtonUpdate.Text = "Update";
            this.gradientButtonUpdate.UseVisualStyleBackColor = false;
            this.gradientButtonUpdate.Click += new System.EventHandler(this.gradientButtonUpdate_Click);
            // 
            // gradientButtonClose
            // 
            this.gradientButtonClose.Active = false;
            this.gradientButtonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gradientButtonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientButtonClose.Location = new System.Drawing.Point(180, 381);
            this.gradientButtonClose.Name = "gradientButtonClose";
            this.gradientButtonClose.Size = new System.Drawing.Size(127, 32);
            this.gradientButtonClose.TabIndex = 148;
            this.gradientButtonClose.Text = "Close";
            this.gradientButtonClose.UseVisualStyleBackColor = false;
            this.gradientButtonClose.Click += new System.EventHandler(this.gradientButtonClose_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 156;
            this.label2.Text = "Solar System:";
            // 
            // comboBoxObjects
            // 
            this.comboBoxObjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxObjects.FormattingEnabled = true;
            this.comboBoxObjects.Location = new System.Drawing.Point(189, 44);
            this.comboBoxObjects.Name = "comboBoxObjects";
            this.comboBoxObjects.Size = new System.Drawing.Size(229, 21);
            this.comboBoxObjects.TabIndex = 169;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 20);
            this.label7.TabIndex = 170;
            this.label7.Text = "Objects:";
            // 
            // FormSolarSystems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 430);
            this.Controls.Add(this.gradientPanel21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSolarSystems";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solar Systems";
            this.gradientPanel21.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gradientPanel22.ResumeLayout(false);
            this.gradientPanel22.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.GradientPanel2 gradientPanel21;
        private System.Windows.Forms.TextBox textBoxXSpeed;
        private System.Windows.Forms.TextBox textBoxName;
        internal CustomControls.GradientButton gradientButtonClose;
        private System.Windows.Forms.Panel panel1;
        private CustomControls.GradientButton gradientButtonUpdate;
        private System.Windows.Forms.TextBox textBoxYSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSolarSystems;
        private CustomControls.GradientPanel2 gradientPanel22;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelMass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelNumObjects;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelYPos;
        private System.Windows.Forms.Label labelXPos;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxObjects;
    }
}