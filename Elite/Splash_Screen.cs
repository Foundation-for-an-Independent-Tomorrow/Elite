using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elite
{
    public partial class Splash_Screen : Form
    {
        public Splash_Screen()
        {
            InitializeComponent();
            progressBar1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 4;
            label1.Text = progressBar1.Value.ToString() + "%";

            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                Elite_Dashboard elite_Dashboard = new Elite_Dashboard();
                elite_Dashboard.Show();
                this.Hide();
            }
        }
    }
}
