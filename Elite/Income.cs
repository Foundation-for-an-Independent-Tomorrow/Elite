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
    public partial class Income : Form
    {
        Client ex_Client;
        List<KeyValuePair<string, object>> incomeList;
        private Existing_Client_Dashboard ecd = null;
        public Income(Form main)
        {
            ecd = main as Existing_Client_Dashboard;
            InitializeComponent();
            ex_Client = Client.SelectedClient;
            incomeList = Data.DataHandler.Get_Income_By_ClientID(ex_Client.ClientID);
            Fill_Income();
        }
        //Josiah 6/23/2022
        public void Fill_Income()
        {
            if (incomeList != null)
            {
                rjTxt_HouseholdIncome.Texts = incomeList.First(kvp => kvp.Key == "HouseholdIncome").Value.ToString();
                rjTxt_EmploymentIncome.Texts = incomeList.First(kvp => kvp.Key == "EmploymentIncome").Value.ToString();
                rjTxt_SSDI.Texts = incomeList.First(kvp => kvp.Key == "SSDI").Value.ToString();
                rjTxt_ChildSupportIn.Texts = incomeList.First(kvp => kvp.Key == "ChildSupportIn").Value.ToString();
                rjTxt_Alimoney.Texts = incomeList.First(kvp => kvp.Key == "Alimoney").Value.ToString();
                rjTxt_OtherIncome.Texts = incomeList.First(kvp => kvp.Key == "OtherIncome").Value.ToString();
                rjTButton_EmployedthroughFit.Checked = !incomeList.First(kvp => kvp.Key == "EmployedThroughFit").Value.Equals(false);
                Rj_Hourly_Salary_Toggle.Checked = !incomeList.First(kvp => kvp.Key == "PaidHourly").Value.Equals(false);

            }
        }
    }
}
