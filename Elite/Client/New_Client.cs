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
    public partial class New_Client : Form
    {
        public DateTime appDate;
        public int NewClient_Initial_CMID;
        public int NewClientID;
        Form _dash;
        public New_Client(Form dash)
        {
            InitializeComponent();
            _dash = dash;
            BTN_Cancel.Click += (s, e) => Close();
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

        private void BTN_Create_Client_Click(object sender, EventArgs e)
        {
            appDate = DateTime.Today;
            NewClient_Initial_CMID = 33;
            NewClientID = Data.DataHandler.GetID("ClientID", "Clients") + 1;

            bool ISValid = Input_Validation();

            if(ISValid == true)
            {
                if (Data.DataHandler.ClientExists(TXT_Client_FName.Text, TXT_Client_LName.Text, TXT_Client_LastFour.Text) == false)
                {
                    string MI;

                    if (String.IsNullOrEmpty(TXT_Client_MInitial.Text))
                    {
                        MI = " ";
                    }
                    else
                    {
                        MI = TXT_Client_MInitial.Text;
                    }
                    Data.DataHandler.Create_New_Client(NewClientID, appDate, NewClient_Initial_CMID, TXT_Client_FName.Text, TXT_Client_LName.Text,
                            Convert.ToChar(MI), TXT_Client_LastFour.Text);
                }
                else
                {
                    MessageBox.Show("The client already exists in the database. Try running a search for them instead.","Failure Adding new Client",MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }

            //Lambda function used to more easily clear fields
            Action<Control.ControlCollection> ClearFields = null;

            ClearFields = (controls) =>
            {
                foreach (Control option in controls)
                    if (option is TextBox)
                        (option as TextBox).Clear();
                    else
                        ClearFields(option.Controls);
            };

            ClearFields(Controls);

            // The following is for validation testing purposes.
            //MessageBox.Show($"The length of the middle initial text is: {TXT_Client_MInitial.Text.Length}. " +
            //    $"\nThe length of the last 4 text is: {TXT_Client_LastFour.Text.Length}. " +
            //    $"\nThe new client ID is: {NewClientID}. " +
            //    $"\nThe new client CMID is: {NewClient_Initial_CMID}." +
            //    $"\nThe Created date is: {appDate.ToShortDateString()}." +
            //    $"\nThe validity of the input is: {ISValid}." +
            //    $"\nThe result of if the last 4 are all digits is: {TXT_Client_LastFour.Text.All(char.IsDigit)}", "Printout");

        }

        public bool Input_Validation()
        {
            if (String.IsNullOrEmpty(TXT_Client_FName.Text))
            {
                MessageBox.Show("The First Name can not be blank.", "Incorrect!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(TXT_Client_FName.Text, "[^a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter valid information for " + Lbl_Client_FName.Text, "Incorrect!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(TXT_Client_LName.Text))
            {
                MessageBox.Show("The Last Name can not be blank.", "Incorrect!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(TXT_Client_LName.Text, "[^a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter valid information for " + Lbl_Client_LName.Text, "Incorrect!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (TXT_Client_MInitial.Text.Length > 1)
            {
                MessageBox.Show("The middle initial should either be empty, or contain only a single letter.", "Incorrect!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(TXT_Client_MInitial.Text, "[^a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter valid information for " + Lbl_Client_MInitial.Text, "Incorrect!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (TXT_Client_LastFour.Text.Length != 4)
            {
                MessageBox.Show("The last 4 should be no more and no less that 4 digits.", "Incorrect!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (!TXT_Client_LastFour.Text.All(char.IsDigit))
            {
                MessageBox.Show("Please enter valid information for " + Lbl_LastFour.Text, "Incorrect!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void New_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            _dash.WindowState = FormWindowState.Normal;
        }
    }
}
