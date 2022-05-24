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
            // 
            // textBoxNumOfRow
            // 
            this.textBoxNumOfRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNumOfRow.Location = new System.Drawing.Point(252, 95);
            this.textBoxNumOfRow.Multiline = true;
            this.textBoxNumOfRow.Name = "textBoxNumOfRow";
            this.textBoxNumOfRow.Size = new System.Drawing.Size(166, 45);
            this.textBoxNumOfRow.TabIndex = 46;
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
            // 
            // buttonPersonD
            // 
            this.buttonPersonD.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonPersonD.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPersonD.Location = new System.Drawing.Point(21, 442);
            this.buttonPersonD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPersonD.Name = "buttonPersonD";
            this.buttonPersonD.Size = new System.Drawing.Size(414, 39);
            this.buttonPersonD.TabIndex = 54;
            this.buttonPersonD.Text = "Person D Booking";
            this.buttonPersonD.UseVisualStyleBackColor = false;
            // 
            // buttonPersonA
            // 
            this.buttonPersonA.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonPersonA.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPersonA.Location = new System.Drawing.Point(20, 295);
            this.buttonPersonA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPersonA.Name = "buttonPersonA";
            this.buttonPersonA.Size = new System.Drawing.Size(414, 39);
            this.buttonPersonA.TabIndex = 53;
            this.buttonPersonA.Text = "Person A Booking";
            this.buttonPersonA.UseVisualStyleBackColor = false;
            // 
            // buttonPersonB
            // 
            this.buttonPersonB.BackColor = System.Drawing.Color.SandyBrown;
            this.buttonPersonB.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPersonB.Location = new System.Drawing.Point(20, 344);
            this.buttonPersonB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPersonB.Name = "buttonPersonB";
            this.buttonPersonB.Size = new System.Drawing.Size(414, 39);
            this.buttonPersonB.TabIndex = 52;
            this.buttonPersonB.Text = "Person B Booking";
            this.buttonPersonB.UseVisualStyleBackColor = false;
            // 
            // buttonPersonC
            // 
            this.buttonPersonC.BackColor = System.Drawing.Color.LightPink;
            this.buttonPersonC.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPersonC.Location = new System.Drawing.Point(21, 393);
            this.buttonPersonC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPersonC.Name = "buttonPersonC";
            this.buttonPersonC.Size = new System.Drawing.Size(414, 39);
            this.buttonPersonC.TabIndex = 51;
            this.buttonPersonC.Text = "Person C Booking";
            this.buttonPersonC.UseVisualStyleBackColor = false;
            // 
            // buttonResetSimulation
            // 
            this.buttonResetSimulation.BackColor = System.Drawing.Color.IndianRed;
            this.buttonResetSimulation.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonResetSimulation.Location = new System.Drawing.Point(21, 585);
            this.buttonResetSimulation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonResetSimulation.Name = "buttonResetSimulation";
            this.buttonResetSimulation.Size = new System.Drawing.Size(414, 39);
            this.buttonResetSimulation.TabIndex = 57;
            this.buttonResetSimulation.Text = "Reset simulation";
            this.buttonResetSimulation.UseVisualStyleBackColor = false;
            // 
            // labelMessage
            // 
            this.labelMessage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMessage.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMessage.Location = new System.Drawing.Point(21, 677);
            this.labelMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(414, 138);
            this.labelMessage.TabIndex = 56;
            // 
            // SafeDistancingAndSmartModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1609, 1140);
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
    }
}