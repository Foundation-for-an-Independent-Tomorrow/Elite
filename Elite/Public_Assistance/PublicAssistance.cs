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
        private Existing_Client_Dashboard ecd = null;
        public PublicAssistance(Form main)
        {
            ecd = main as Existing_Client_Dashboard;
            InitializeComponent();
            ex_Client = Client.SelectedClient;
            publicAssitanceList = Data.DataHandler.Get_PublicAssitance_By_ClientID(ex_Client.ClientID);
            Fill_PublicAssitance();
        }
        public void Fill_PublicAssitance()
        {
            if (publicAssitanceList != null)
            {
                rjTxt_UnemploymentBenefit.Texts = publicAssitanceList.First(kvp => kvp.Key == "UnemploymentBenefit").Value.ToString();
                rjTxt_SSI.Texts = publicAssitanceList.First(kvp => kvp.Key == "SSI").Value.ToString();
                rjTxt_TANF.Texts = publicAssitanceList.First(kvp => kvp.Key == "TANF").Value.ToString();
                rjTxt_SANP.Texts = publicAssitanceList.First(kvp => kvp.Key == "SNAP").Value.ToString();
                rjTxt_WIC.Texts = publicAssitanceList.First(kvp => kvp.Key == "WIC").Value.ToString();
                rjTxt_RentalAssist.Texts = publicAssitanceList.First(kvp => kvp.Key == "RentalAssist").Value.ToString();
                rjTxt_UtilityAssist.Texts = publicAssitanceList.First(kvp => kvp.Key == "UtilityAssist").Value.ToString();
                rjTxt_FamilySupport.Texts = publicAssitanceList.First(kvp => kvp.Key == "FamilySupport").Value.ToString();
                rjTogBut_RentFree.Checked = !publicAssitanceList.First(kvp => kvp.Key == "RentFreeHousing").Value.Equals(false);
                rjTogBut_CostFree.Checked = !publicAssitanceList.First(kvp => kvp.Key == "CostFreeFood").Value.Equals(false);
            }
        }

        private void PublicAssitance_Load(object sender, EventArgs e)
        {

        }
    }
}
