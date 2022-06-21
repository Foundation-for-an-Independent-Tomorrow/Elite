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
    public partial class Existing_Client_Information : Form
    {
        Client ex_Client;
        List<KeyValuePair<string, object>> clientInfoList;
        public Existing_Client_Information()
        {
            InitializeComponent();
            ex_Client = Client.SelectedClient;
            clientInfoList = Data.DataHandler.Get_Client_Info_By_ClientID(ex_Client.ClientID);
            SetStateComboBox();
            Fill_Client_Info();
            Lbl_ClientInfo_ClientName.Text = $"Client Information for {ex_Client.FirstName} {ex_Client.LastName}";
            CBox_CMs.Height = 34;
            Fill_CM_ComboBox(ex_Client.CMID);
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
            rjTxt_fName.Texts = ex_Client.FirstName;
            rjTxt_mInitial.Texts = ex_Client.MiddleInitial;
            rjTxt_lName.Texts = ex_Client.LastName;
            rjTxt_Last_Four.Texts = ex_Client.Social;
            rjDPicker.Value = ex_Client.AppDate;
            rjDPicker.Enabled = false;
            if (clientInfoList != null) 
            { 
                rjTxt_Address1.Texts = clientInfoList.First(kvp => kvp.Key == "Address1").Value.ToString();
                rjTxt_Address2.Texts = clientInfoList.First(kvp => kvp.Key == "Address2").Value.ToString();
                rjTxt_City.Texts = clientInfoList.First(kvp => kvp.Key == "City").Value.ToString();
                rjCBox_State.SelectedItem = clientInfoList.First(kvp => kvp.Key == "USState").Value.ToString();
                rjTxt_Zip.Texts = clientInfoList.First(kvp => kvp.Key == "ZIP").Value.ToString();
            }
        }

        #region Button Click Events

        private void BTN_Close_Click(object sender, EventArgs e) => Close();

        private void BTN_FRM_CLOSE_Click(object sender, EventArgs e) => Close();

        #endregion

        public void Fill_CM_ComboBox(int cmID)
        {
            SqlConnection c = new SqlConnection(Data.DataHandler.ConnectionString);
            c.Open();
            try
            {
                //string CM_Query = "SELECT CMID, CONCAT(FirstName, ' ', LastName) AS 'Name', Login, Active FROM CaseManagers;";
                SqlCommand cmd = new SqlCommand("sp_Get_CM_List", c)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };

                DataSet ds = new DataSet();
                da.Fill(ds, "CMs");
                CBox_CMs.DisplayMember = "Name";
                CBox_CMs.ValueMember = "CMID";
                CBox_CMs.DataSource = ds.Tables["CMs"];
                DataRowView dataRowView = CBox_CMs.SelectedItem as DataRowView;
                CBox_CMs.SelectedValue = cmID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error loading the list of Case Managers: " + ex.Message);
            }
            c.Close();
        }

        public void SetStateComboBox()
        {
            rjCBox_State.Items.AddRange(new object[] {
                "NV", "AK", "AL", "AZ", "AR", "CA", "CO", "CT", "DE", "FL",
                "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME",
                "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NH", "NJ", 
                "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", 
                "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"
            });
        }

        public void ToggleOn_Off(object sender, EventArgs e)
        {
        }
    }
}
