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
    public partial class New_Employment : Form
    {
        Client ex_Client;
        List<KeyValuePair<string, object>> newEmploymentList;
        public New_Employment()
        {
            InitializeComponent();
            ex_Client = Client.SelectedClient;
            newEmploymentList = Data.DataHandler.Get_NewEmployment_By_ClientID(ex_Client.ClientID);
            Fill_NewEmployment();
        }
        //Josiah 6/27/2022
        public void Fill_NewEmployment()
        {
            if (newEmploymentList != null)
            {
                rjTxt_BusinessName.Texts = newEmploymentList.First(kvp => kvp.Key == "BusinessName").Value.ToString();
                rjTxt_Address1.Texts = newEmploymentList.First(kvp => kvp.Key == "Address1").Value.ToString();
                rjTxt_Address2.Texts = newEmploymentList.First(kvp => kvp.Key == "Address2").Value.ToString();
                rjTxt_City.Texts = newEmploymentList.First(kvp => kvp.Key == "City").Value.ToString();
                rjCBox_State.SelectedItem = newEmploymentList.First(kvp => kvp.Key == "Sate").Value.ToString();
                rjTxt_Zip.Texts = newEmploymentList.First(kvp => kvp.Key == "Zip").Value.ToString();
                rjTxt_BusinessPhone.Texts = newEmploymentList.First(kvp => kvp.Key == "BusinessPhone").Value.ToString();                rjCBox_State.SelectedItem = newEmploymentList.First(kvp => kvp.Key == "Sate").Value.ToString();
                rjDPicker_StartDate.Value = (DateTime)newEmploymentList.First(kvp => kvp.Key == "StartDate").Value;
                rjDPicker_EndDate.Value = (DateTime)newEmploymentList.First(kvp => kvp.Key == "EndDate").Value;
                rjTxt_HourlyWage.Texts = newEmploymentList.First(kvp => kvp.Key == "HourlyWage").Value.ToString();
                rjTxt_HoursPerWeek.Texts = newEmploymentList.First(kvp => kvp.Key == "HoursPerWeek").Value.ToString();
                rjTxt_DescriptionOfDuties.Texts = newEmploymentList.First(kvp => kvp.Key == "DescriptionOfDuties").Value.ToString();
                rjTxt_ReasonForLeavingPrevJob.Texts = newEmploymentList.First(kvp => kvp.Key == "ReasonForLeavingPrevJob").Value.ToString();
            }
        }
    }
}
