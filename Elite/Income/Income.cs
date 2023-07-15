using Elite.Data;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
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
        private decimal hourlyToMonthlyIncome;
        private decimal _income;
        private decimal _ssdi;
        private decimal _pension;
        private decimal _childIn;
        private decimal _alimonyIn;
        private decimal _otherIn;
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
                Rj_Hourly_Salary_Toggle.Checked = !incomeList.First(kvp => kvp.Key == "PaidHourly").Value.Equals(false);
                rjTxt_HouseholdIncome.Texts = incomeList.First(kvp => kvp.Key == "HouseholdIncome").Value.ToString();
                if (Rj_Hourly_Salary_Toggle.Checked)
                {
                    hourly = 1;
                    TXT_Hourly_Wage.Texts = incomeList.First(kvp => kvp.Key == "EmploymentIncome").Value.ToString();
                }
                else
                {
                    hourly = 0;
                    rjTxt_EmploymentIncome.Texts = incomeList.First(kvp => kvp.Key == "EmploymentIncome").Value.ToString();
                }
                rjTxt_SSDI.Texts = incomeList.First(kvp => kvp.Key == "SSDI").Value.ToString();
                rjTxt_Pension.Texts = incomeList.First(kvp => kvp.Key == "Pension").Value.ToString();
                rjTxt_ChildSupportIn.Texts = incomeList.First(kvp => kvp.Key == "ChildSupportIn").Value.ToString();
                rjTxt_Alimoney.Texts = incomeList.First(kvp => kvp.Key == "AlimonyIn").Value.ToString();
                rjTxt_OtherIncome.Texts = incomeList.First(kvp => kvp.Key == "OtherIncome").Value.ToString();
                rjTButton_EmployedthroughFit.Checked = !incomeList.First(kvp => kvp.Key == "EmployedThroughFit").Value.Equals(false);      
            }
            else
            {
                IncomeId = DataHandler.GetID("IncomeID", "Income") + 1;
            }
        }

        private void BTN_Client_Income_update_Click(object sender, EventArgs e)
        {
            ConvertToDec();
            empThroughFIT = rjTButton_EmployedthroughFit.Checked == true ? 1 : 0;
            DataHandler.Update_Income(IncomeId, decimal.Parse(rjTxt_HouseholdIncome.Texts), _income, _ssdi, _pension, _childIn, _alimonyIn, _otherIn, empThroughFIT, hourly, ex_Client.ClientID);
            
            ex_Client.IncomeUpdated = true;
        }

        private void Rj_Hourly_Salary_Toggle_CheckedChanged(object sender, EventArgs e)
        {
            if(Rj_Hourly_Salary_Toggle.Checked)
            {
                hourly = 1;
                Lbl_Hourly_Wage.Visible = true;
                TXT_Hourly_Wage.Visible = true;
                RBWeekly.Visible = true;
                RBWeekly.Checked = true;
                RB_Monthly.Visible = false;
                Lbl_EmploymentIncome.Visible = false;
                rjTxt_EmploymentIncome.Visible=false;
                rjTxt_HouseholdIncome.Texts = HHIncomeAmount.ToString();
            }
            else
            {
                hourly = 0;
                Lbl_Hourly_Wage.Visible = false;
                TXT_Hourly_Wage.Visible = false;
                RBWeekly.Visible = false;
                RB_Monthly.Visible = true;
                Lbl_EmploymentIncome.Visible = true;
                rjTxt_EmploymentIncome.Visible = true;
                RB_Monthly.Checked = true;
                rjTxt_HouseholdIncome.Texts = HHIncomeAmount.ToString();
            }
        }

        private void ConvertToDec()
        {
            switch (hourly)
            {
                case 0:
                    if (string.IsNullOrEmpty(rjTxt_EmploymentIncome.Texts))
                    {
                        _income = 0m;
                    }
                    else
                    {
                        _income = decimal.Floor(decimal.Parse(rjTxt_EmploymentIncome.Texts));
                    }
                    break;
                case 1:
                    if (string.IsNullOrEmpty(TXT_Hourly_Wage.Texts))
                    {
                        _income = 0m;
                    }
                    else
                    {
                        _income = decimal.Floor(decimal.Parse(TXT_Hourly_Wage.Texts));
                    }
                    break;
            }
            if (string.IsNullOrEmpty(rjTxt_SSDI.Texts))
            {
                _ssdi = 0m;
            }
            else
            {
                _ssdi = decimal.Floor(decimal.Parse(rjTxt_SSDI.Texts));
            }

            if (string.IsNullOrEmpty(rjTxt_Pension.Texts))
            {
                _pension = 0m;
            }
            else
            {
                _pension = decimal.Floor(decimal.Parse(rjTxt_Pension.Texts));
            }

            if (string.IsNullOrEmpty(rjTxt_ChildSupportIn.Texts))
            {
                _childIn = 0m;
            }
            else
            {
                _childIn = decimal.Floor(decimal.Parse(rjTxt_ChildSupportIn.Texts));
            }

            if (string.IsNullOrEmpty(rjTxt_Alimoney.Texts))
            {
                _alimonyIn = 0m;
            }
            else
            {
                _alimonyIn = decimal.Floor(decimal.Parse(rjTxt_Alimoney.Texts));
            }

            if (string.IsNullOrEmpty(rjTxt_OtherIncome.Texts))
            {
                _otherIn = 0m;
            }
            else
            {
                _otherIn = decimal.Floor(decimal.Parse(rjTxt_OtherIncome.Texts));
            }
        }

        private void Income_TextChanged(object sender, EventArgs e)
        {
            ConvertToDec();
            if (RBWeekly.Checked)
            {
                hourlyToMonthlyIncome = ((_income * 40) * 52) / 12;
            }
            else if (RB_Bi_Weekly.Checked && Rj_Hourly_Salary_Toggle.Checked)
            {
                hourlyToMonthlyIncome = ((_income * 80) * 26) / 12;
            }
            else if(RB_Bi_Weekly.Checked && !Rj_Hourly_Salary_Toggle.Checked)
            {
                hourlyToMonthlyIncome = (_income * 26) / 12;
            }
            else
            {
                hourlyToMonthlyIncome = _income;
            }
            HHIncomeAmount = hourlyToMonthlyIncome + _ssdi + _pension + _childIn + _alimonyIn + _otherIn;
            rjTxt_HouseholdIncome.Texts = HHIncomeAmount.ToString();
        }
    }
}
