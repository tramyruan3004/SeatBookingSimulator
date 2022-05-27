namespace SeatBookingSimulator
{
    partial class SafeDistancingAndSmartModeForm
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
            this.panelSeats = new System.Windows.Forms.Panel();
            this.textBoxSeatPerRow = new System.Windows.Forms.TextBox();
            this.textBoxNumOfRow = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonGenerateSeats = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonEndSimulation = new System.Windows.Forms.Button();
            this.buttonPersonD = new System.Windows.Forms.Button();
            this.buttonPersonA = new System.Windows.Forms.Button();
            this.buttonPersonB = new System.Windows.Forms.Button();
            this.buttonPersonC = new System.Windows.Forms.Button();
            this.buttonResetSimulation = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.manualEditor = new System.Windows.Forms.GroupBox();
            this.buttonDisableAll = new System.Windows.Forms.Button();
            this.buttonEnableAll = new System.Windows.Forms.Button();
            this.radioButtonDisable = new System.Windows.Forms.RadioButton();
            this.radioButtonEnable = new System.Windows.Forms.RadioButton();
            this.buttonManualMode = new System.Windows.Forms.Button();
            this.manualEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSeats
            // 
            this.panelSeats.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelSeats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSeats.Location = new System.Drawing.Point(482, 27);
            this.panelSeats.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSeats.Name = "panelSeats";
            this.panelSeats.Size = new System.Drawing.Size(1142, 1086);
            this.panelSeats.TabIndex = 50;
            // 
            // textBoxSeatPerRow
            // 
            this.textBoxSeatPerRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSeatPerRow.Location = new System.Drawing.Point(252, 148);
            this.textBoxSeatPerRow.Multiline = true;
            this.textBoxSeatPerRow.Name = "textBoxSeatPerRow";
            this.textBoxSeatPerRow.Size = new System.Drawing.Size(166, 45);
            this.textBoxSeatPerRow.TabIndex = 47;
            this.textBoxSeatPerRow.TextChanged += new System.EventHandler(this.textBoxSeatPerRow_TextChanged);
            // 
            // textBoxNumOfRow
            // 
            this.textBoxNumOfRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNumOfRow.Location = new System.Drawing.Point(252, 95);
            this.textBoxNumOfRow.Multiline = true;
            this.textBoxNumOfRow.Name = "textBoxNumOfRow";
            this.textBoxNumOfRow.Size = new System.Drawing.Size(166, 45);
            this.textBoxNumOfRow.TabIndex = 46;
            this.textBoxNumOfRow.TextChanged += new System.EventHandler(this.textBoxNumOfRow_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(45, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 30);
            this.label2.TabIndex = 43;
            this.label2.Text = "Seats per row";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(45, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 30);
            this.label1.TabIndex = 42;
            this.label1.Text = "Number of rows";
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonLoad.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonLoad.Location = new System.Drawing.Point(244, 38);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(191, 44);
            this.buttonLoad.TabIndex = 41;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonGenerateSeats
            // 
            this.buttonGenerateSeats.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonGenerateSeats.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonGenerateSeats.Location = new System.Drawing.Point(21, 217);
            this.buttonGenerateSeats.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonGenerateSeats.Name = "buttonGenerateSeats";
            this.buttonGenerateSeats.Size = new System.Drawing.Size(414, 39);
            this.buttonGenerateSeats.TabIndex = 40;
            this.buttonGenerateSeats.Text = "Setup Cinema Seat Layout";
            this.buttonGenerateSeats.UseVisualStyleBackColor = false;
            this.buttonGenerateSeats.Click += new System.EventHandler(this.buttonGenerateSeats_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSave.Location = new System.Drawing.Point(31, 37);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(191, 44);
            this.buttonSave.TabIndex = 39;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonEndSimulation
            // 
            this.buttonEndSimulation.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonEndSimulation.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonEndSimulation.Location = new System.Drawing.Point(20, 525);
            this.buttonEndSimulation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonEndSimulation.Name = "buttonEndSimulation";
            this.buttonEndSimulation.Size = new System.Drawing.Size(414, 39);
            this.buttonEndSimulation.TabIndex = 55;
            this.buttonEndSimulation.Text = "End simulation";
            this.buttonEndSimulation.UseVisualStyleBackColor = false;
            this.buttonEndSimulation.Click += new System.EventHandler(this.buttonEndSimulation_Click);
            // 
            // buttonPersonD
            // 
            this.buttonPersonD.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonPersonD.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPersonD.Location = new System.Drawing.Point(21, 444);
            this.buttonPersonD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPersonD.Name = "buttonPersonD";
            this.buttonPersonD.Size = new System.Drawing.Size(414, 39);
            this.buttonPersonD.TabIndex = 54;
            this.buttonPersonD.Text = "Person D Booking";
            this.buttonPersonD.UseVisualStyleBackColor = false;
            this.buttonPersonD.Click += new System.EventHandler(this.buttonPersonD_Click);
            // 
            // buttonPersonA
            // 
            this.buttonPersonA.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonPersonA.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPersonA.Location = new System.Drawing.Point(20, 297);
            this.buttonPersonA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPersonA.Name = "buttonPersonA";
            this.buttonPersonA.Size = new System.Drawing.Size(414, 39);
            this.buttonPersonA.TabIndex = 53;
            this.buttonPersonA.Text = "Person A Booking";
            this.buttonPersonA.UseVisualStyleBackColor = false;
            this.buttonPersonA.Click += new System.EventHandler(this.buttonPersonA_Click);
            // 
            // buttonPersonB
            // 
            this.buttonPersonB.BackColor = System.Drawing.Color.SandyBrown;
            this.buttonPersonB.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPersonB.Location = new System.Drawing.Point(20, 346);
            this.buttonPersonB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPersonB.Name = "buttonPersonB";
            this.buttonPersonB.Size = new System.Drawing.Size(414, 39);
            this.buttonPersonB.TabIndex = 52;
            this.buttonPersonB.Text = "Person B Booking";
            this.buttonPersonB.UseVisualStyleBackColor = false;
            this.buttonPersonB.Click += new System.EventHandler(this.buttonPersonB_Click);
            // 
            // buttonPersonC
            // 
            this.buttonPersonC.BackColor = System.Drawing.Color.LightPink;
            this.buttonPersonC.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPersonC.Location = new System.Drawing.Point(21, 395);
            this.buttonPersonC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPersonC.Name = "buttonPersonC";
            this.buttonPersonC.Size = new System.Drawing.Size(414, 39);
            this.buttonPersonC.TabIndex = 51;
            this.buttonPersonC.Text = "Person C Booking";
            this.buttonPersonC.UseVisualStyleBackColor = false;
            this.buttonPersonC.Click += new System.EventHandler(this.buttonPersonC_Click);
            // 
            // buttonResetSimulation
            // 
            this.buttonResetSimulation.BackColor = System.Drawing.Color.IndianRed;
            this.buttonResetSimulation.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonResetSimulation.Location = new System.Drawing.Point(20, 853);
            this.buttonResetSimulation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonResetSimulation.Name = "buttonResetSimulation";
            this.buttonResetSimulation.Size = new System.Drawing.Size(414, 39);
            this.buttonResetSimulation.TabIndex = 57;
            this.buttonResetSimulation.Text = "Reset simulation";
            this.buttonResetSimulation.UseVisualStyleBackColor = false;
            this.buttonResetSimulation.Click += new System.EventHandler(this.buttonResetSimulation_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMessage.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMessage.Location = new System.Drawing.Point(20, 945);
            this.labelMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(414, 168);
            this.labelMessage.TabIndex = 56;
            // 
            // manualEditor
            // 
            this.manualEditor.Controls.Add(this.buttonDisableAll);
            this.manualEditor.Controls.Add(this.buttonEnableAll);
            this.manualEditor.Controls.Add(this.radioButtonDisable);
            this.manualEditor.Controls.Add(this.radioButtonEnable);
            this.manualEditor.Controls.Add(this.buttonManualMode);
            this.manualEditor.Location = new System.Drawing.Point(21, 600);
            this.manualEditor.Name = "manualEditor";
            this.manualEditor.Size = new System.Drawing.Size(414, 201);
            this.manualEditor.TabIndex = 58;
            this.manualEditor.TabStop = false;
            this.manualEditor.Text = "Manual Editor";
            // 
            // buttonDisableAll
            // 
            this.buttonDisableAll.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonDisableAll.Enabled = false;
            this.buttonDisableAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDisableAll.Location = new System.Drawing.Point(126, 150);
            this.buttonDisableAll.Name = "buttonDisableAll";
            this.buttonDisableAll.Size = new System.Drawing.Size(157, 34);
            this.buttonDisableAll.TabIndex = 24;
            this.buttonDisableAll.Text = "Disable All";
            this.buttonDisableAll.UseVisualStyleBackColor = false;
            this.buttonDisableAll.Click += new System.EventHandler(this.buttonDisableAll_Click);
            // 
            // buttonEnableAll
            // 
            this.buttonEnableAll.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonEnableAll.Enabled = false;
            this.buttonEnableAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonEnableAll.Location = new System.Drawing.Point(126, 108);
            this.buttonEnableAll.Name = "buttonEnableAll";
            this.buttonEnableAll.Size = new System.Drawing.Size(157, 34);
            this.buttonEnableAll.TabIndex = 23;
            this.buttonEnableAll.Text = "Enable all";
            this.buttonEnableAll.UseVisualStyleBackColor = false;
            this.buttonEnableAll.Click += new System.EventHandler(this.buttonEnableAll_Click);
            // 
            // radioButtonDisable
            // 
            this.radioButtonDisable.AccessibleName = "";
            this.radioButtonDisable.AutoSize = true;
            this.radioButtonDisable.Enabled = false;
            this.radioButtonDisable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radioButtonDisable.Location = new System.Drawing.Point(223, 71);
            this.radioButtonDisable.Name = "radioButtonDisable";
            this.radioButtonDisable.Size = new System.Drawing.Size(99, 29);
            this.radioButtonDisable.TabIndex = 22;
            this.radioButtonDisable.TabStop = true;
            this.radioButtonDisable.Text = "Disable";
            this.radioButtonDisable.UseVisualStyleBackColor = true;
            // 
            // radioButtonEnable
            // 
            this.radioButtonEnable.AccessibleName = "";
            this.radioButtonEnable.AutoSize = true;
            this.radioButtonEnable.Enabled = false;
            this.radioButtonEnable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radioButtonEnable.Location = new System.Drawing.Point(79, 71);
            this.radioButtonEnable.Name = "radioButtonEnable";
            this.radioButtonEnable.Size = new System.Drawing.Size(94, 29);
            this.radioButtonEnable.TabIndex = 21;
            this.radioButtonEnable.TabStop = true;
            this.radioButtonEnable.Text = "Enable";
            this.radioButtonEnable.UseVisualStyleBackColor = true;
            // 
            // buttonManualMode
            // 
            this.buttonManualMode.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonManualMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonManualMode.Location = new System.Drawing.Point(78, 31);
            this.buttonManualMode.Name = "buttonManualMode";
            this.buttonManualMode.Size = new System.Drawing.Size(265, 34);
            this.buttonManualMode.TabIndex = 0;
            this.buttonManualMode.Text = "Enter Edit Mode";
            this.buttonManualMode.UseVisualStyleBackColor = false;
            this.buttonManualMode.Click += new System.EventHandler(this.buttonManualMode_Click);
            // 
            // SafeDistancingAndSmartModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1609, 1140);
            this.Controls.Add(this.manualEditor);
            this.Controls.Add(this.buttonResetSimulation);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonEndSimulation);
            this.Controls.Add(this.buttonPersonD);
            this.Controls.Add(this.buttonPersonA);
            this.Controls.Add(this.buttonPersonB);
            this.Controls.Add(this.buttonPersonC);
            this.Controls.Add(this.panelSeats);
            this.Controls.Add(this.textBoxSeatPerRow);
            this.Controls.Add(this.textBoxNumOfRow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonGenerateSeats);
            this.Controls.Add(this.buttonSave);
            this.Name = "SafeDistancingAndSmartModeForm";
            this.Text = "Safe Distancing And Smart Mode";
            this.Load += new System.EventHandler(this.SafeDistancingAndSmartModeForm_Load);
            this.manualEditor.ResumeLayout(false);
            this.manualEditor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSeats;
        private System.Windows.Forms.TextBox textBoxSeatPerRow;
        private System.Windows.Forms.TextBox textBoxNumOfRow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonGenerateSeats;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonEndSimulation;
        private System.Windows.Forms.Button buttonPersonD;
        private System.Windows.Forms.Button buttonPersonA;
        private System.Windows.Forms.Button buttonPersonB;
        private System.Windows.Forms.Button buttonPersonC;
        private System.Windows.Forms.Button buttonResetSimulation;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.GroupBox manualEditor;
        private System.Windows.Forms.Button buttonDisableAll;
        private System.Windows.Forms.Button buttonEnableAll;
        private System.Windows.Forms.RadioButton radioButtonDisable;
        private System.Windows.Forms.RadioButton radioButtonEnable;
        private System.Windows.Forms.Button buttonManualMode;
    }
}