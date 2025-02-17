﻿using System;
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
    public partial class Elite_Dashboard : Form
    {
        public static bool isAdmin;
        public Elite_Dashboard()
        {
            InitializeComponent();
            // BTN_Close.Click += (s, e) => Application.Exit();
            LblUserName.Text = Environment.UserName;
            isAdmin = Data.DataHandler.IsUserAdmin(Environment.UserName);
            if(isAdmin == true)
            {
                BTN_Admin.Visible = true;
            }
            LblHomeScreen.Text = "Search for a Client by last name or Case manager";
            Main_Elite_Frm main_vrb = new Main_Elite_Frm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            main_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(main_vrb);
            main_vrb.Show();
            BTN_Home.Visible = false;
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
            LblLongDate.Text = DateTime.Now.DayOfWeek.ToString() + "\n" + DateTime.Now.ToShortDateString();
        }

        private void Elite_Dashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void BTN_Close_Click(object sender, EventArgs e) => Application.Exit();
        private void BTN_Exit_Click(object sender, EventArgs e) => Application.Exit();

        private void BTN_New_Client_Click(object sender, EventArgs e)
        {
            New_Client new_Client = new New_Client(this);
            new_Client.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void BTN_Admin_Click(object sender, EventArgs e)
        {
            Admin_Panel admin = new Admin_Panel(this);
            admin.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void BTN_Home_Click(object sender, EventArgs e)
        {
            this.PnlFormLoader.Controls.Clear();
            LblHomeScreen.Text = "Search for a Client by last name or Case manager";
            Main_Elite_Frm main_vrb = new Main_Elite_Frm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            main_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(main_vrb);
            main_vrb.Show();
            BTN_Home.Visible = false;
            BTN_Admin.Visible = true;
        }

        private void BTN_Minimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;
    }
}
