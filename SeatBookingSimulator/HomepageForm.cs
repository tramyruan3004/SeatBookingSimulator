using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SeatBookingSimulator
{
    public partial class HomepageForm : Form
    {
        //class level variable
        public NormalModeForm f1 = null;
        public SafeDistancingModeForm f2 = null;
        public SafeDistancingAndSmartModeForm f3 = null;

        public HomepageForm()
        {
            InitializeComponent();
            this.normalModeToolStripMenuItem.Click += new EventHandler(normalModeToolStripMenuItem_Click);
        }

        private void normalModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f1 != null)
            {
                if (f2 != null)
                {
                    f2.Hide();
                }
                if (f3 != null)
                {
                    f3.Hide();
                }
                f1.MdiParent = this;
                f1.Show();
            }
            else
            {
                f1 = new NormalModeForm();
            }
        }

        private void safeDistancingModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f2 != null)
            {
                if (f1 != null)
                {
                    f1.Hide();
                }
                if (f3 != null)
                {
                    f3.Hide();
                }
                f2.MdiParent = this;
                f2.Show();
            }
            else
            {
                f2 = new SafeDistancingModeForm();
            }
        }

        private void safeDistancingAndSmartModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f3 != null)
            {
                if (f2 != null)
                {
                    f2.Hide();
                }
                if (f1 != null)
                {
                    f1.Hide();
                }
                f3.MdiParent = this;
                f3.Show();
            }
            else
            {
                f3 = new SafeDistancingAndSmartModeForm();
            }
        }
    }
}
