using Elite.Data;

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
        private int IncomeId;
        private decimal HHIncomeAmount;
        private int empThroughFIT;
        private int hourly;
        private decimal hWage;
        private decimal salary;
        private decimal hourlyToMonthlyIncome;
        private Existing_Client_Dashboard ecd = null;
        public Income(Form main)
        {
            ecd = main as Existing_Client_Dashboard;
            InitializeComponent();
            ex_Client = Client.SelectedClient;
            incomeList = DataHandler.Get_Income_By_ClientID(ex_Client.ClientID);
            this.ecd.Public_Assistance_Visability = ex_Client.PacMan;
            Fill_Income();
        }
        //Josiah 6/23/2022
        public void Fill_Income()
        {
            if (incomeList != null)
            {
                IncomeId = int.Parse(incomeList.First(kvp => kvp.Key == "IncomeID").Value.ToString());
                rjTxt_HouseholdIncome.Texts = decimal.Parse(incomeList.First(kvp => kvp.Key == "HouseholdIncome").Value.ToString()).ToString("n2");
                rjTxt_EmploymentIncome.Texts = decimal.Parse(incomeList.First(kvp => kvp.Key == "EmploymentIncome").Value.ToString()).ToString("n2");
                hWage = GetHourlyWage(decimal.Parse(rjTxt_EmploymentIncome.Texts));
                salary = hWage * 100;
                rjTxt_SSDI.Texts = decimal.Parse(incomeList.First(kvp => kvp.Key == "SSDI").Value.ToString()).ToString("n2");
                rjTxt_Pension.Texts = decimal.Parse(incomeList.First(kvp => kvp.Key == "Pension").Value.ToString()).ToString("n2");
                rjTxt_ChildSupportIn.Texts = decimal.Parse(incomeList.First(kvp => kvp.Key == "ChildSupportIn").Value.ToString()).ToString("n2");
                rjTxt_Alimoney.Texts = decimal.Parse(incomeList.First(kvp => kvp.Key == "AlimonyIn").Value.ToString()).ToString("n2");
                rjTxt_OtherIncome.Texts = decimal.Parse(incomeList.First(kvp => kvp.Key == "OtherIncome").Value.ToString()).ToString("n2");
                rjTButton_EmployedthroughFit.Checked = !incomeList.First(kvp => kvp.Key == "EmployedThroughFit").Value.Equals(false);
                Rj_Hourly_Salary_Toggle.Checked = !incomeList.First(kvp => kvp.Key == "PaidHourly").Value.Equals(false);      
            }
            else
            {
                IncomeId = DataHandler.GetID("IncomeID", "Income") + 1;
            }
        }

        private void Income_Refresh()
        {
            //Lambda function used to more easily clear fields
            Action<Control.ControlCollection> ClearFields = null;

            ClearFields = (controls) =>
            {
                foreach (Control option in controls)
                    if (option is TextBox)
                        (option as TextBox).Clear();
                    else if (option is CheckBox)
                        (option as CheckBox).Checked = false;
                    else
                        ClearFields(option.Controls);
            };

            ClearFields(Controls);

            Fill_Income();
        }

        private decimal GetHourlyWage(decimal wage)
        {
            decimal hourlyWage = 0;
            if (wage.ToString().Length > 4) 
            {
                hourlyWage = wage / 100;
            }
            return hourlyWage;
        }

        private void BTN_Client_Income_update_Click(object sender, EventArgs e)
        {

            empThroughFIT = rjTButton_EmployedthroughFit.Checked == true ? 1 : 0;
            DataHandler.Update_Income(IncomeId, HHIncomeAmount, decimal.Parse(rjTxt_EmploymentIncome.Texts), decimal.Parse(rjTxt_SSDI.Texts), decimal.Parse(rjTxt_Pension.Texts), decimal.Parse(rjTxt_ChildSupportIn.Texts), decimal.Parse(rjTxt_Alimoney.Texts), decimal.Parse(rjTxt_OtherIncome.Texts), empThroughFIT, hourly, ex_Client.ClientID);
            
            ex_Client.IncomeUpdated = true;
            Income_Refresh();
        }

        private void Rj_Hourly_Salary_Toggle_CheckedChanged(object sender, EventArgs e)
        {
            if(Rj_Hourly_Salary_Toggle.Checked)
            {
                hourly = 1;
                rjTxt_EmploymentIncome.Texts = hWage.ToString("n2");
                hourlyToMonthlyIncome = ((hWage * 40) * 52) / 12;
                HHIncomeAmount = (hourlyToMonthlyIncome + decimal.Parse(rjTxt_SSDI.Texts) + decimal.Parse(rjTxt_Pension.Texts) + decimal.Parse(rjTxt_ChildSupportIn.Texts) + decimal.Parse(rjTxt_Alimoney.Texts) + decimal.Parse(rjTxt_OtherIncome.Texts));
                rjTxt_HouseholdIncome.Texts = HHIncomeAmount.ToString("n2");
            }
            else
            {
                hourly = 0;
                rjTxt_EmploymentIncome.Texts = salary.ToString("n2");
                HHIncomeAmount = (decimal.Parse(rjTxt_EmploymentIncome.Texts) + decimal.Parse(rjTxt_SSDI.Texts) + decimal.Parse(rjTxt_Pension.Texts) + decimal.Parse(rjTxt_ChildSupportIn.Texts) + decimal.Parse(rjTxt_Alimoney.Texts) + decimal.Parse(rjTxt_OtherIncome.Texts));
                rjTxt_HouseholdIncome.Texts = HHIncomeAmount.ToString("n2");
            }
        }
    }
}
