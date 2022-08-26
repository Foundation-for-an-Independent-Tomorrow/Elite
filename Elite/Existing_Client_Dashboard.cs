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
    public partial class Existing_Client_Dashboard : Form
    {
        public Existing_Client_Dashboard()
        {
            InitializeComponent();
            LblUserName.Text = Environment.UserName;
            LblHomeScreen.Text = "Client Information";
            Existing_Client_Information eci_vrb = new Existing_Client_Information(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            eci_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(eci_vrb);
            eci_vrb.Show();
        }

        #region Movable Window

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Dashboard_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Dashboard_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Dashboard_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        #endregion Movable Window

        private void timer1_Tick(object sender, EventArgs e)
        {
            LblCurrentRunningTime.Text = DateTime.Now.ToLongTimeString();
            LblLongDate.Text = DateTime.Now.ToLongDateString();
        }

        private void Existing_Client_Dashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void BTN_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTN_Minimize_Click(object sender, EventArgs e)
        {

        }

        public bool Crim_Hist_Visability
        {
            get { return BTN_Client_Criminal_History.Visible; }
            set { BTN_Client_Criminal_History.Visible = value; }
        }

        private void BTN_Client_Criminal_History_Click(object sender, EventArgs e)
        {

        }
    }
}
