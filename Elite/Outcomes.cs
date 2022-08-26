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
    public partial class Outcomes : Form
    {
        Client ex_Client;
        List<KeyValuePair<string, object>> outcomesList;
        public Outcomes()
        {
            InitializeComponent();
            ex_Client = Client.SelectedClient;
            outcomesList = Data.DataHandler.Get_Outcomes_By_ClientID(ex_Client.ClientID);
            Fill_Outcomes();
        }

        //Josiah 6/27/2022
        public void Fill_Outcomes()
        {
            if (outcomesList != null)
            {
                rjTxt_EmployerSector.Texts = outcomesList.First(kvp => kvp.Key == "EmployerSector").Value.ToString();
                rjTxt_JobTitle.Texts = outcomesList.First(kvp => kvp.Key == "JobTitle").Value.ToString();
                rjTButton_EmployedthroughFit.Checked = !outcomesList.First(kvp => kvp.Key == "EmployedthroughFit").Value.Equals(false);
                rjDPicker_HireDate.Value = (DateTime)outcomesList.First(kvp => kvp.Key == "HireDate").Value;
                rjTxt_StartingSalary.Texts = outcomesList.First(kvp => kvp.Key == "StartingSalary").Value.ToString();
                rjTButton_EligibleForHealthInsurance.Checked = !outcomesList.First(kvp => kvp.Key == "EligibleForHealthInsurance").Value.Equals(false);
                rjTButton_EligibleForOtherBenefits.Checked = !outcomesList.First(kvp => kvp.Key == "EligibleForOtherBenefits").Value.Equals(false);
                rjTButton_ParticipantSatisfied.Checked = !outcomesList.First(kvp => kvp.Key == "ParticipantSatisfied").Value.Equals(false);
                rjTButton_Enrolled.Checked = !outcomesList.First(kvp => kvp.Key == "Enrolled").Value.Equals(false);
                rjTButton_CredentialAchieved.Checked = !outcomesList.First(kvp => kvp.Key == "CredentialAchieved").Value.Equals(false);
            }
        }
    }
}
