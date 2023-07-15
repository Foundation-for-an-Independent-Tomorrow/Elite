using Elite.Data;

using Microsoft.IdentityModel.Tokens;

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
        int ClientInfoID;
        int pAssist = 0;
        int _convict = 0;
        DateTime _defaultDate = new(year:2005, month:7, day:1);
        const double daysPerYear = 365.24;
        int iYears = 0;
        int age;
        public static bool pacMAN;
        private Existing_Client_Dashboard ecd = null;
        public Existing_Client_Information(Form main)
        {
            ecd = main as Existing_Client_Dashboard;
            InitializeComponent();
            ex_Client = Client.SelectedClient;
            clientInfoList = Data.DataHandler.Get_Client_Info_By_ClientID(ex_Client.ClientID);
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
                ClientInfoID = int.Parse(clientInfoList.First(kvp => kvp.Key == "ClientinfoID").Value.ToString());
                rjTxt_Email.Texts = clientInfoList.First(kvp => kvp.Key == "Email").Value.ToString();
                
                rjTxt_PrimaryPhone.Texts = clientInfoList.First(kvp => kvp.Key == "PrimaryPhone").Value.ToString();

                if (String.IsNullOrEmpty(clientInfoList.First(kvp => kvp.Key == "DOB").Value.ToString()))
                {
                    rjDPicker_DOB.Value = _defaultDate;
                    iYears = (int)(Get_Elapsed_Days(rjDPicker_DOB.Value) / daysPerYear);
                }
                else
                {
                    rjDPicker_DOB.Value = (DateTime)clientInfoList.First(kvp => kvp.Key == "DOB").Value;
                    iYears = (int)(Get_Elapsed_Days((DateTime)clientInfoList.First(kvp => kvp.Key == "DOB").Value) / daysPerYear);
                }                    
                age = iYears;
                rjTxt_Age.Texts = iYears.ToString();                
                rjTButton_PublicAssist.Checked = !clientInfoList.First(kvp => kvp.Key == "PublicAssist").Value.Equals(false);
                rjTButton_Conviction.Checked = !clientInfoList.First(kvp => kvp.Key == "Conviction").Value.Equals(false);
            }
            else
            {
                ClientInfoID = DataHandler.GetID("ClientinfoID", "ClientInfo") + 1;
                rjDPicker_DOB.Value = _defaultDate;
                iYears = (int)(Get_Elapsed_Days(rjDPicker_DOB.Value) / daysPerYear);
                age = iYears;
                rjTxt_Age.Texts = age.ToString();
            }
        }

        public int Get_Elapsed_Days(DateTime pastDate)
        {
            return (DateTime.Now - pastDate).Days;
        }

        public bool Input_Validation()
        {
            if (String.IsNullOrEmpty(rjTxt_fName.Texts))
            {
                MessageBox.Show("The First Name can not be blank.", "Incorrect!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(rjTxt_fName.Texts, "[^a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter valid information for " + Lbl_Client_fName.Text, "Incorrect!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(rjTxt_lName.Texts))
            {
                MessageBox.Show("The Last Name can not be blank.", "Incorrect!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(rjTxt_lName.Texts, "[^a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter valid information for " + Lbl_lName.Text, "Incorrect!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rjTxt_mInitial.Texts.Length > 1)
            {
                MessageBox.Show("The middle initial should either be empty, or contain only a single letter.", "Incorrect!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(rjTxt_mInitial.Texts, "[^a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter valid information for " + Lbl_MInitial.Text, "Incorrect!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rjTxt_Last_Four.Texts.Length != 4)
            {
                MessageBox.Show("The last 4 should be no more and no less that 4 digits.", "Incorrect!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (!rjTxt_Last_Four.Texts.All(char.IsDigit))
            {
                MessageBox.Show("Please enter valid information for " + Lbl_Last_Four.Text, "Incorrect!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        //Josiah 6/23/2022 - The following methods are no longer relevent.
        //public void Fill_Debt()
        //{
        //    if (debtList != null)
        //    {
        //        rjCBox_DebtType.SelectedItem = debtList.First(kvp => kvp.Key == "DebtType").Value.ToString();
        //        rjTxt_DebtRepay.Texts = debtList.First(kvp => kvp.Key == "DebtRepay").Value.ToString();
        //        rjTxt_AmountOwed.Texts = debtList.First(kvp => kvp.Key == "AmountOwed").Value.ToString();
        //        rjTxt_TotalDebt.Texts = debtList.First(kvp => kvp.Key == "TotalDebt").Value.ToString();
        //    }
        //}

        ////Josiah 6/23/2022
        //public void Fill_Dependants()
        //{
        //    if (dependantsList != null)
        //    {
        //        rjTButton_IsDependant.Checked = dependantsList.First(kvp => kvp.Key == "Relationship").Value.Equals(false);
        //        rjCBox_Relationship.Texts = dependantsList.First(kvp => kvp.Key == "isDependant").Value.ToString();
        //    }
        //}

        ////Josiah 6/27/2022
        //public void Fill_JobReady()
        //{
        //    if (jobReadyList != null)
        //    {

        //    }
        //}

        ////Josiah 6/27/2022
        //public void Fill_PublicAssitance()
        //{
        //    if (publicAssitanceList != null)
        //    {

        //    }
        //}

        //Josiah 6/27/2022
        //public void Fill_REI()
        //{
        //    if (REIList != null)
        //    {

        //    }
        //}

        #region Button Click Events

        private void BTN_Close_Click(object sender, EventArgs e) => Close();

        private void BTN_FRM_CLOSE_Click(object sender, EventArgs e) => Close();

        private void BTN_ClientInfo_Update_Click(object sender, EventArgs e)
        {
            bool ISValid = Input_Validation();

            if (rjTButton_PublicAssist.Checked)
            {
                pAssist = 1;
            }

            if (rjTButton_Conviction.Checked)
            {
                _convict = 1;
            }

            if (ISValid)
            {
                char? MI;

                if (String.IsNullOrEmpty(rjTxt_mInitial.Texts))
                {
                    MI = null;
                }
                else
                {
                    MI = Convert.ToChar(rjTxt_mInitial.Texts);
                }

                DataHandler.Update_Client_Info((int)ex_Client.ClientID, (int)CBox_CMs.SelectedValue, rjTxt_fName.Texts, rjTxt_lName.Texts, MI, rjTxt_Last_Four.Texts, ClientInfoID, rjTxt_Email.Texts,rjDPicker_DOB.Value, age, rjTxt_PrimaryPhone.Texts,pAssist, _convict);
            }
        }

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

        private void Existing_Client_Information_Load(object sender, EventArgs e)
        {

        }

        private void rjTButton_PublicAssist_CheckedChanged(object sender, EventArgs e)
        {
            this.ecd.Public_Assistance_Visability = rjTButton_PublicAssist.Checked;
            ex_Client.PacMan = rjTButton_PublicAssist.Checked;
        }        
    }
}
