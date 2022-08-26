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
    public partial class Criminal_History : Form
    {
        Client ex_Client;
        List<KeyValuePair<string, object>> criminalHistoryList;
        public Criminal_History()
        {
            InitializeComponent();
            ex_Client = Client.SelectedClient;
            criminalHistoryList = Data.DataHandler.Get_Criminal_History_By_ClientID(ex_Client.ClientID);
            Fill_Crimal_History();
        }

        //Josiah 6/23/2022
        public void Fill_Crimal_History()
        {
            if (criminalHistoryList != null)
            {
                rjCBox_OffenceCategory.SelectedItem = criminalHistoryList.First(kvp => kvp.Key == "OffenceCategory").Value.ToString();
                rjCBox_OffenceType.SelectedItem = criminalHistoryList.First(kvp => kvp.Key == "OffenceType").Value.ToString();
                rjTxt_ConvictionYear.Texts = criminalHistoryList.First(kvp => kvp.Key == "NumberinHousehold").Value.ToString();

            }
        }
    }
}
