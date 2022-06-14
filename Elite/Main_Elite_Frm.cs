using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elite
{
    public partial class Main_Elite_Frm : Form
    {
        public int _selectedClient;

        public Main_Elite_Frm()
        {
            InitializeComponent();
            Fill_CM_ComboBox();
        }

        public void Fill_CM_ComboBox()
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
                c.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an error loading the list of Case Managers: " + ex.Message);
            }
        }

        private void Main_Elite_Frm_Load(object sender, EventArgs e)
        {

        }

        private void BTN_Search_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TXT_Client_Search_By_LastName.Text))
            {
                int id = Convert.ToInt32(CBox_CMs.SelectedValue);
                DataTable clientSearch = Data.DataHandler.Client_SearchByCMID_Fill(id);
                DGV_Client_Search.DataSource = clientSearch;
                DGV_Client_Search.Update();
                DGV_Client_Search.Refresh();
            }
            else
            {
                DataTable clientSearch = Data.DataHandler.Client_SearchByLastName_Fill(TXT_Client_Search_By_LastName.Text);
                DGV_Client_Search.DataSource = clientSearch;
                DGV_Client_Search.Update();
                DGV_Client_Search.Refresh();
            }

            //Lambda function used to more easily clear fields
            Action<Control.ControlCollection> ClearFields = null;

            ClearFields = (controls) =>
            {
                foreach (Control option in controls)
                    if (option is TextBox)
                        (option as TextBox).Clear();
                    //else if (option is ComboBox)
                    //    (option as ComboBox).SelectedIndex = -1;
                    else
                        ClearFields(option.Controls);
            };

            ClearFields(Controls);
        }

        private void DGV_Client_Search_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectedClient = DGV_Client_Search.CurrentCell.RowIndex;
            Client.SelectedClient = Data.DataHandler.Get_Client_By_ClientID((int)DGV_Client_Search.Rows[_selectedClient].Cells[0].Value);
            if (Client.SelectedClient == null)
            {
                MessageBox.Show("There was a problem getting the client information.", "Oh No!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Existing_Client_Information ECI_Frm = new Existing_Client_Information();
                ECI_Frm.Show();
            }
        }
    }
}
