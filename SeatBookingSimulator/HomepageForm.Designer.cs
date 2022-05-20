namespace SeatBookingSimulator
{
    partial class HomepageForm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.modesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.safeDistancingModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.safeDistancingAndSmartModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1089, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // modesToolStripMenuItem
            // 
            this.modesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalModeToolStripMenuItem,
            this.safeDistancingModeToolStripMenuItem,
            this.safeDistancingAndSmartModeToolStripMenuItem});
            this.modesToolStripMenuItem.Name = "modesToolStripMenuItem";
            this.modesToolStripMenuItem.Size = new System.Drawing.Size(83, 29);
            this.modesToolStripMenuItem.Text = "Modes";
            // 
            // normalModeToolStripMenuItem
            // 
            this.normalModeToolStripMenuItem.Name = "normalModeToolStripMenuItem";
            this.normalModeToolStripMenuItem.Size = new System.Drawing.Size(375, 34);
            this.normalModeToolStripMenuItem.Text = "Normal Mode";
            this.normalModeToolStripMenuItem.Click += new System.EventHandler(this.normalModeToolStripMenuItem_Click);
            // 
            // safeDistancingModeToolStripMenuItem
            // 
            this.safeDistancingModeToolStripMenuItem.Name = "safeDistancingModeToolStripMenuItem";
            this.safeDistancingModeToolStripMenuItem.Size = new System.Drawing.Size(375, 34);
            this.safeDistancingModeToolStripMenuItem.Text = "Safe Distancing Mode";
            this.safeDistancingModeToolStripMenuItem.Click += new System.EventHandler(this.safeDistancingModeToolStripMenuItem_Click);
            // 
            // safeDistancingAndSmartModeToolStripMenuItem
            // 
            this.safeDistancingAndSmartModeToolStripMenuItem.Name = "safeDistancingAndSmartModeToolStripMenuItem";
            this.safeDistancingAndSmartModeToolStripMenuItem.Size = new System.Drawing.Size(375, 34);
            this.safeDistancingAndSmartModeToolStripMenuItem.Text = "Safe Distancing and Smart Mode";
            this.safeDistancingAndSmartModeToolStripMenuItem.Click += new System.EventHandler(this.safeDistancingAndSmartModeToolStripMenuItem_Click);
            // 
            // HomepageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 652);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HomepageForm";
            this.Text = "Booking Simulation Home Page";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem safeDistancingModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem safeDistancingAndSmartModeToolStripMenuItem;
    }
}