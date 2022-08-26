using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// Josiah Made his page on 6/30/2022
namespace Elite
{
    public partial class PublicAssistance : Form
    {
        Client ex_Client;
        List<KeyValuePair<string, object>> publicAssitanceList;
        public PublicAssistance()
        {
            InitializeComponent();
            ex_Client = Client.SelectedClient;
            publicAssitanceList = Data.DataHandler.Get_PublicAssitance_By_ClientID(ex_Client.ClientID);
            Fill_PublicAssitance();
        }
        public void Fill_PublicAssitance()
        {
            if (publicAssitanceList != null)
            {
                //rjTxt_HouseholdIncome.Texts = publicAssitanceList.First(kvp => kvp.Key == "HouseholdIncome").Value.ToString();
                //rjTxt_EmploymentIncome.Texts = publicAssitanceList.First(kvp => kvp.Key == "EmploymentIncome").Value.ToString();
                

            }
        }

        private void PublicAssitance_Load(object sender, EventArgs e)
        {

        }
    }
}
