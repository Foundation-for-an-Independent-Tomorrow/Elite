﻿using System;
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
        List<KeyValuePair<string, object>> debtList;
        List<KeyValuePair<string, object>> dependantsList;
        List<KeyValuePair<string, object>> jobReadyList;
        List<KeyValuePair<string, object>> publicAssitanceList;
        List<KeyValuePair<string, object>> REIList;
        private Existing_Client_Dashboard ecd = null;
        public Existing_Client_Information(Form main)
        {
            ecd = main as Existing_Client_Dashboard;
            InitializeComponent();
            ex_Client = Client.SelectedClient;
            clientInfoList = Data.DataHandler.Get_Client_Info_By_ClientID(ex_Client.ClientID);
            debtList = Data.DataHandler.Get_Debt_By_ClientID(ex_Client.ClientID);
            dependantsList = Data.DataHandler.Get_Dependants_By_ClientID(ex_Client.ClientID);
            jobReadyList = Data.DataHandler.Get_JobReady_By_ClientID(ex_Client.ClientID);
            publicAssitanceList = Data.DataHandler.Get_PublicAssitance_By_ClientID(ex_Client.ClientID);
            REIList = Data.DataHandler.Get_REI_By_ClientID(ex_Client.ClientID);
            SetStateComboBox();
            Fill_Client_Info();
            Fill_Debt();
            Fill_Dependants();
            Fill_JobReady();
            Fill_PublicAssitance();
            Fill_REI();
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
                rjTxt_Email.Texts = clientInfoList.First(kvp => kvp.Key == "Email").Value.ToString();
                rjTxt_Age.Texts = clientInfoList.First(kvp => kvp.Key == "Age").Value.ToString();
                rjTxt_PrimaryPhone.Texts = clientInfoList.First(kvp => kvp.Key == "PrimaryPhone").Value.ToString();
                rjDPicker_DOB.Value = (DateTime)clientInfoList.First(kvp => kvp.Key == "DOB").Value;
                rjTxt_SecondaryPhone.Texts = clientInfoList.First(kvp => kvp.Key == "SecondaryPhone").Value.ToString();
                rjTxt_EmergencayContact.Texts = clientInfoList.First(kvp => kvp.Key == "EmergencayContact").Value.ToString();
                rjTxt_EmercengyPhone.Texts = clientInfoList.First(kvp => kvp.Key == "EmercengyPhone").Value.ToString();
                rjTButton_NVResident.Checked = !clientInfoList.First(kvp => kvp.Key == "NVResident").Value.Equals(false);
                rjTButton_Adult.Checked = !clientInfoList.First(kvp => kvp.Key == "Adult").Value.Equals(false);
                rjTButton_UsWork.Checked = !clientInfoList.First(kvp => kvp.Key == "USWork").Value.Equals(false);
                rjTButton_USVeteran.Checked = !clientInfoList.First(kvp => kvp.Key == "USVeteran").Value.Equals(false);
                rjTButton_UnemploymentBenefit.Checked = !clientInfoList.First(kvp => kvp.Key == "UnemploymentBenefit").Value.Equals(false);
                rjTButton_SelectiveRegistered.Checked = !clientInfoList.First(kvp => kvp.Key == "SelectiveRegistered").Value.Equals(false);
                rjTxt_ReferredBy.Texts = clientInfoList.First(kvp => kvp.Key == "ReferredBy").Value.ToString();
                rjTButton_PriorApplicant.Checked = !clientInfoList.First(kvp => kvp.Key == "PriorApplicant").Value.Equals(false);
                rjCBox_Gender.SelectedItem = clientInfoList.First(kvp => kvp.Key == "Gender").Value.ToString();
                rjTxt_MaritalStatus.Texts = clientInfoList.First(kvp => kvp.Key == "MaritalStatus").Value.ToString();
                rjTButton_PublicAssist.Checked = !clientInfoList.First(kvp => kvp.Key == "PublicAssist").Value.Equals(false);
                rjTxt_NumberofDependants.Texts = clientInfoList.First(kvp => kvp.Key == "NumberofDependants").Value.ToString();
                rjTxt_NumberinHousehold.Texts = clientInfoList.First(kvp => kvp.Key == "NumberinHousehold").Value.ToString();
                rjTxt_HighestEducation.Texts = clientInfoList.First(kvp => kvp.Key == "HighestEducation").Value.ToString();
                rjTButton_IsDisabled.Checked = !clientInfoList.First(kvp => kvp.Key == "IsDisabled").Value.Equals(false);
                rjTButton_Conviction.Checked = !clientInfoList.First(kvp => kvp.Key == "Conviction").Value.Equals(false);

            }
        }

        //Josiah 6/23/2022
        public void Fill_Debt()
        {
            if (debtList != null)
            {
                rjCBox_DebtType.SelectedItem = debtList.First(kvp => kvp.Key == "DebtType").Value.ToString();
                rjTxt_DebtRepay.Texts = debtList.First(kvp => kvp.Key == "DebtRepay").Value.ToString();
                rjTxt_AmountOwed.Texts = debtList.First(kvp => kvp.Key == "AmountOwed").Value.ToString();
                rjTxt_TotalDebt.Texts = debtList.First(kvp => kvp.Key == "TotalDebt").Value.ToString();
            }
        }

        //Josiah 6/23/2022
        public void Fill_Dependants()
        {
            if (dependantsList != null)
            {
                rjTButton_IsDependant.Checked = dependantsList.First(kvp => kvp.Key == "Relationship").Value.Equals(false);
                rjCBox_Relationship.Texts = dependantsList.First(kvp => kvp.Key == "isDependant").Value.ToString();
            }
        }

        //Josiah 6/27/2022
        public void Fill_JobReady()
        {
            if (jobReadyList != null)
            {
                
            }
        }
        
        //Josiah 6/27/2022
        public void Fill_PublicAssitance()
        {
            if (publicAssitanceList != null)
            {

            }
        }

        //Josiah 6/27/2022
        public void Fill_REI()
        {
            if (REIList != null)
            {

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

        private void rjTxt_EmergencayContact__TextChanged(object sender, EventArgs e)
        {
        }

        private void yesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void rjTButton_Conviction_CheckStateChanged(object sender, EventArgs e)
        {
        }

        private void Existing_Client_Information_Load(object sender, EventArgs e)
        {

        }
    }
}
