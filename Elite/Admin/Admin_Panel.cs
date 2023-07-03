using Elite.Data;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elite
{
    public partial class Admin_Panel : Form
    {
        Form _dash;
        public Admin_Panel(Form dash)
        {
            InitializeComponent();
            Fill_Admin_View();
            Fill_CM_View();
            _dash = dash;
            BTN_Cancel.Click += (s, e) => Close();
        }

        public void Fill_Admin_View()
        {
            try
            {                
                DGV_Admin.DataSource = DataHandler.Get_Admin_List();
                DGV_Admin.Update();
                DGV_Admin.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error loading the list of Admins: " + ex.Message);
            }
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

        public void Fill_CM_View() 
        {
            try
            {
                DGV_CaseManagers.DataSource = DataHandler.Get_CM_List();
                DGV_CaseManagers.Update();
                DGV_CaseManagers.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an error loading the list of Case Managers: " + ex.Message);
            }

        }

        private void Admin_Panel_FormClosing(object sender, FormClosingEventArgs e)
        {
           _dash.WindowState = FormWindowState.Normal;
        }
    }
}
