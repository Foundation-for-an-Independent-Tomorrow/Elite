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
        int pAID;
        int rentFree;
        int costFree;
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
                pAID = int.Parse(publicAssitanceList.First(kvp => kvp.Key == "PublicAssistID").Value.ToString());
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
            else
            {
                pAID = Data.DataHandler.GetID("PublicAssistID", "PublicAssistance");
            }
        }

        private void PublicAssitance_Load(object sender, EventArgs e)
        {

        }

        private void BTN_Client_Public_Assist_update_Click(object sender, EventArgs e)
        {
            ex_Client.PublicAssistUpdated = true;
            rentFree = rjTogBut_RentFree.Checked == true ? 1 : 0;
            costFree = rjTogBut_CostFree.Checked == true ? 1 : 0;
            MessageBox.Show($"The value of costFree is: {costFree}", "TEST!!!!!");
            Data.DataHandler.Update_PublicAssist(pAID, decimal.Parse(rjTxt_UnemploymentBenefit.Texts), decimal.Parse(rjTxt_SSI.Texts),decimal.Parse(rjTxt_TANF.Texts), decimal.Parse(rjTxt_SANP.Texts), decimal.Parse(rjTxt_WIC.Texts),decimal.Parse(rjTxt_RentalAssist.Texts), decimal.Parse(rjTxt_UtilityAssist.Texts), decimal.Parse(rjTxt_FamilySupport.Texts), ex_Client.ClientID, rentFree, costFree);
        }
    }
}
