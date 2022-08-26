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
    public partial class Expenses : Form
    {
        Client ex_Client;
        List<KeyValuePair<string, object>> expensesList;
        public Expenses()
        {
            InitializeComponent();
            ex_Client = Client.SelectedClient;
            expensesList = Data.DataHandler.Get_Expenses_By_ClientID(ex_Client.ClientID);
            Fill_Expenses();
        }

        //Josiah 6/23/2022
        public void Fill_Expenses()
        {
            if (expensesList != null)
            {
                rjTxt_RentAmount.Texts = expensesList.First(kvp => kvp.Key == "RentAmount").Value.ToString();
                rjTxt_Utilities.Texts = expensesList.First(kvp => kvp.Key == "Utilities").Value.ToString();
                rjTxt_CellPhone.Texts = expensesList.First(kvp => kvp.Key == "CellPhone").Value.ToString();
                rjTxt_Groceries.Texts = expensesList.First(kvp => kvp.Key == "Groceries").Value.ToString();
                rjTxt_CarPayment.Texts = expensesList.First(kvp => kvp.Key == "CarPayment").Value.ToString();
                rjTxt_CarInsurance.Texts = expensesList.First(kvp => kvp.Key == "CarInsurance").Value.ToString();
                rjTxt_Gasoline.Texts = expensesList.First(kvp => kvp.Key == "Gasoline").Value.ToString();
                rjTxt_Busfare.Texts = expensesList.First(kvp => kvp.Key == "Busfare").Value.ToString();
                rjTxt_ChildCare.Texts = expensesList.First(kvp => kvp.Key == "ChildCare").Value.ToString();
                rjTxt_ChildSupportOut.Texts = expensesList.First(kvp => kvp.Key == "ChildSupportOut").Value.ToString();
                rjTxt_Cable.Texts = expensesList.First(kvp => kvp.Key == "Cable").Value.ToString();
                rjTxt_PersonalHygene.Texts = expensesList.First(kvp => kvp.Key == "PersonalHygene").Value.ToString();
                rjTxt_Clothing.Texts = expensesList.First(kvp => kvp.Key == "Clothing").Value.ToString();
                rjTxt_Medical.Texts = expensesList.First(kvp => kvp.Key == "Medical").Value.ToString();
                       }
        }
    }
}
