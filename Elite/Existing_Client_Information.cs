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
    public partial class Existing_Client_Information : Form
    {
        Client ex_Client;
        public Existing_Client_Information()
        {
            InitializeComponent();
            ex_Client = Client.SelectedClient;
            Fill_Client_Info();
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

        private void Dashboard_MouseUp(object sender, MouseEventArgs e) => dragging = false;

        #endregion Movable Window

        public void Fill_Client_Info()
        {
            rjTextBox2.Texts = ex_Client.FirstName;
            rjTextBox3.Texts = ex_Client.MiddleInitial;
            rjTextBox4.Texts = ex_Client.LastName;
            rjTextBox5.Texts = ex_Client.Social;
            rjDatePicker1.Value = ex_Client.AppDate;
            rjDatePicker1.Enabled = false;
        }

        #region Button Click Events

        private void BTN_Close_Click(object sender, EventArgs e) => Close();

        private void BTN_FRM_CLOSE_Click(object sender, EventArgs e) => Close();

        #endregion
    }
}
