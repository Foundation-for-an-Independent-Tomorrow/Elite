using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elite.Data
{
    class DataHandler
    {
        public static readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EliteDB"].ConnectionString;
        private static readonly SqlConnection c = new SqlConnection(ConnectionString);


        #region Get Methods

        // Gets an ID for new records creation
        public static int GetID(string id, string table)
        {
            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();
            SqlCommand cmd = new SqlCommand("sp_Get_ID", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            cmd.Parameters.Add(new SqlParameter("@TableName", table));

            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                if (rdr[0] == DBNull.Value)
                {
                    return 0;
                }
                return Convert.ToInt32(rdr[0]);
            }
            rdr.Close();
            c.Close();
            return 0;
        }

        public static Client Get_Client_By_ClientID(int clientID)
        {
            Client client;

            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();
            SqlCommand cmd = new SqlCommand("sp_Get_Existing_Client_By_ClientID", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@sp_ClientID", clientID));

            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                client = new Client(Convert.ToInt32(rdr[0]), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), Convert.ToDateTime(rdr[5]), Convert.ToInt32(rdr[6]));
                return client;
            }
            rdr.Close();
            c.Close();
            return null;
        }

        public static List<KeyValuePair<string, object>> Get_Client_Info_By_ClientID(int clientID)
        {
            var clientInfoList = new List<KeyValuePair<string, object>>();
            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();
            SqlCommand cmd_ClientInfo = new SqlCommand("sp_Get_Client_Info_By_ClientID", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd_ClientInfo.Parameters.Add(new SqlParameter("@sp_ClientID", clientID));

            SqlDataReader rdr = cmd_ClientInfo.ExecuteReader();

            try
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    clientInfoList.Add(new KeyValuePair<string, object>("Email", rdr[0]));
                    clientInfoList.Add(new KeyValuePair<string, object>("DOB", rdr[1]));
                    clientInfoList.Add(new KeyValuePair<string, object>("Age", rdr[2]));
                    clientInfoList.Add(new KeyValuePair<string, object>("ParticipationCat", rdr[3]));
                    clientInfoList.Add(new KeyValuePair<string, object>("Address1", rdr[4]));
                    clientInfoList.Add(new KeyValuePair<string, object>("Address2", rdr[5]));
                    clientInfoList.Add(new KeyValuePair<string, object>("City", rdr[6]));
                    clientInfoList.Add(new KeyValuePair<string, object>("USState", rdr[7]));
                    clientInfoList.Add(new KeyValuePair<string, object>("ZIP", rdr[8]));
                    clientInfoList.Add(new KeyValuePair<string, object>("PrimaryPhone", rdr[9]));
                    clientInfoList.Add(new KeyValuePair<string, object>("SecondaryPhone", rdr[10]));
                    clientInfoList.Add(new KeyValuePair<string, object>("EmergencayContact", rdr[11]));
                    clientInfoList.Add(new KeyValuePair<string, object>("EmercengyPhone", rdr[12]));
                    clientInfoList.Add(new KeyValuePair<string, object>("NVResident", rdr[13]));
                    clientInfoList.Add(new KeyValuePair<string, object>("Adult", rdr[14]));
                    clientInfoList.Add(new KeyValuePair<string, object>("USWork", rdr[15]));
                    clientInfoList.Add(new KeyValuePair<string, object>("USVeteran", rdr[16]));
                    clientInfoList.Add(new KeyValuePair<string, object>("UnemploymentBenefit", rdr[17]));
                    clientInfoList.Add(new KeyValuePair<string, object>("SelectiveRegistered", rdr[18]));
                    clientInfoList.Add(new KeyValuePair<string, object>("ReferredBy", rdr[19]));
                    clientInfoList.Add(new KeyValuePair<string, object>("PriorApplicant", rdr[20]));
                    clientInfoList.Add(new KeyValuePair<string, object>("Gender", rdr[21]));
                    clientInfoList.Add(new KeyValuePair<string, object>("Ethnicity", rdr[22]));
                    clientInfoList.Add(new KeyValuePair<string, object>("MaritalStatus", rdr[23]));
                    clientInfoList.Add(new KeyValuePair<string, object>("PublicAssist", rdr[24]));
                    clientInfoList.Add(new KeyValuePair<string, object>("NumberofDependants", rdr[25]));
                    clientInfoList.Add(new KeyValuePair<string, object>("NumberinHousehold", rdr[26]));
                    clientInfoList.Add(new KeyValuePair<string, object>("HighestEducation", rdr[27]));
                    clientInfoList.Add(new KeyValuePair<string, object>("IsDisabled", rdr[28]));
                    clientInfoList.Add(new KeyValuePair<string, object>("Conviction", rdr[29]));
                    clientInfoList.Add(new KeyValuePair<string, object>("ClientID", rdr[30]));
                    clientInfoList.Add(new KeyValuePair<string, object>("ClientinfoID", rdr[31]));
                }
                else
                {
                    //MessageBox.Show("No Client Information found with the ClientID: " + clientID, "Please try again");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                c.Close();
            }
            return clientInfoList;
        }

        //Josiah 6/23/2022
        public static List<KeyValuePair<string, object>> Get_Criminal_History_By_ClientID(int clientID)
        {
            var criminalHistoryList = new List<KeyValuePair<string, object>>();
            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();
            SqlCommand cmd_CriminalHistory = new SqlCommand("sp_Get_CriminalHistory_By_ClientID", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd_CriminalHistory.Parameters.Add(new SqlParameter("@sp_ClientID", clientID));

            SqlDataReader rdr = cmd_CriminalHistory.ExecuteReader();

            try
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    criminalHistoryList.Add(new KeyValuePair<string, object>("OffenceCategory", rdr[0]));
                    criminalHistoryList.Add(new KeyValuePair<string, object>("OffenceType", rdr[1]));
                    criminalHistoryList.Add(new KeyValuePair<string, object>("ConvictionYear", rdr[2]));
                    criminalHistoryList.Add(new KeyValuePair<string, object>("ClientID", rdr[3]));
                }
                else
                {
                    //MessageBox.Show("No Criminal History found with the ClientID: " + clientID, "Please try again");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                c.Close();
            }
            return criminalHistoryList;

        }

        //Josiah 6/23/2022
        public static List<KeyValuePair<string, object>> Get_Debt_By_ClientID(int clientID)
        {
            var debtList = new List<KeyValuePair<string, object>>();
            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();
            SqlCommand cmd_Debt = new SqlCommand("sp_Get_Debt_By_ClientID", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd_Debt.Parameters.Add(new SqlParameter("@sp_ClientID", clientID));

            SqlDataReader rdr = cmd_Debt.ExecuteReader();

            try
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    debtList.Add(new KeyValuePair<string, object>("DebtType", rdr[0]));
                    debtList.Add(new KeyValuePair<string, object>("DebtRepay", rdr[1]));
                    debtList.Add(new KeyValuePair<string, object>("AmountOwed", rdr[2]));
                    debtList.Add(new KeyValuePair<string, object>("TotalDebt", rdr[3]));
                    debtList.Add(new KeyValuePair<string, object>("ClientID", rdr[4]));
                }
                else
                {
                    //MessageBox.Show("No Debt found with the ClientID: " + clientID, "Please try again");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                c.Close();
            }
            return debtList;

        }

        //Josiah 6/23/2022
        public static List<KeyValuePair<string, object>> Get_Dependants_By_ClientID(int clientID)
        {
            var dependantsList = new List<KeyValuePair<string, object>>();
            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();
            SqlCommand cmd_Dependants = new SqlCommand("sp_Get_Dependants_By_ClientID", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd_Dependants.Parameters.Add(new SqlParameter("@sp_ClientID", clientID));

            SqlDataReader rdr = cmd_Dependants.ExecuteReader();

            try
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    dependantsList.Add(new KeyValuePair<string, object>("Relationship", rdr[0]));
                    dependantsList.Add(new KeyValuePair<string, object>("isDependant", rdr[1]));
                    dependantsList.Add(new KeyValuePair<string, object>("ClientID", rdr[2]));

                }
                else
                {
                    //MessageBox.Show("No Dependants found with the ClientID: " + clientID, "Please try again");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                c.Close();
            }
            return dependantsList;

        }

        //Josiah 6/23/2022
        public static List<KeyValuePair<string, object>> Get_Expenses_By_ClientID(int clientID)
        {
            var expensesList = new List<KeyValuePair<string, object>>();
            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();
            SqlCommand cmd_Expenses = new SqlCommand("sp_Get_Expenses_By_ClientID", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd_Expenses.Parameters.Add(new SqlParameter("@sp_ClientID", clientID));

            SqlDataReader rdr = cmd_Expenses.ExecuteReader();

            try
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    expensesList.Add(new KeyValuePair<string, object>("RentAmount", rdr[0]));
                    expensesList.Add(new KeyValuePair<string, object>("Utilities", rdr[1]));
                    expensesList.Add(new KeyValuePair<string, object>("CellPhone", rdr[2]));
                    expensesList.Add(new KeyValuePair<string, object>("Groceries", rdr[3]));
                    expensesList.Add(new KeyValuePair<string, object>("CarPayment", rdr[4]));
                    expensesList.Add(new KeyValuePair<string, object>("CarInsurance", rdr[5]));
                    expensesList.Add(new KeyValuePair<string, object>("Gasoline", rdr[6]));
                    expensesList.Add(new KeyValuePair<string, object>("Busfare", rdr[7]));
                    expensesList.Add(new KeyValuePair<string, object>("ChildCare", rdr[8]));
                    expensesList.Add(new KeyValuePair<string, object>("ChildSupportOut", rdr[9]));
                    expensesList.Add(new KeyValuePair<string, object>("Cable", rdr[10]));
                    expensesList.Add(new KeyValuePair<string, object>("PersonalHygene", rdr[11]));
                    expensesList.Add(new KeyValuePair<string, object>("Clothing", rdr[12]));
                    expensesList.Add(new KeyValuePair<string, object>("Medical", rdr[13]));
                    expensesList.Add(new KeyValuePair<string, object>("ClientID", rdr[14]));

                }
                else
                {
                    //MessageBox.Show("No Expenses found with the ClientID: " + clientID, "Please try again");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                c.Close();
            }
            return expensesList;

        }

        //Josiah 6/23/2022
        public static List<KeyValuePair<string, object>> Get_Income_By_ClientID(int clientID)
        {
            var incomeList = new List<KeyValuePair<string, object>>();
            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();
            SqlCommand cmd_Income = new SqlCommand("sp_Get_Income_By_ClientID", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd_Income.Parameters.Add(new SqlParameter("@sp_ClientID", clientID));

            SqlDataReader rdr = cmd_Income.ExecuteReader();

            try
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    incomeList.Add(new KeyValuePair<string, object>("HouseholdIncome", rdr[0]));
                    incomeList.Add(new KeyValuePair<string, object>("EmploymentIncome", rdr[1]));
                    incomeList.Add(new KeyValuePair<string, object>("SSDI", rdr[2]));
                    incomeList.Add(new KeyValuePair<string, object>("Pension", rdr[3]));
                    incomeList.Add(new KeyValuePair<string, object>("ChildSupportIn", rdr[4]));
                    incomeList.Add(new KeyValuePair<string, object>("Alimoney", rdr[5]));
                    incomeList.Add(new KeyValuePair<string, object>("OtherIncome", rdr[6]));
                    incomeList.Add(new KeyValuePair<string, object>("ClienID", rdr[7]));

                }
                else
                {
                    //MessageBox.Show("No Income found with the ClientID: " + clientID, "Please try again");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                c.Close();
            }
            return incomeList;

        }

        //Josiah 6/27/2022
        public static List<KeyValuePair<string, object>> Get_JobReady_By_ClientID(int clientID)
        {
            var jobReadyList = new List<KeyValuePair<string, object>>();
            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();
            SqlCommand cmd_Income = new SqlCommand("sp_Get_JobReady_By_ClientID", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd_Income.Parameters.Add(new SqlParameter("@sp_ClientID", clientID));

            SqlDataReader rdr = cmd_Income.ExecuteReader();

            try
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    jobReadyList.Add(new KeyValuePair<string, object>("StartDate", rdr[0]));
                    jobReadyList.Add(new KeyValuePair<string, object>("EndDate", rdr[1]));
                    jobReadyList.Add(new KeyValuePair<string, object>("ClientID", rdr[2]));

                }
                else
                {
                    //MessageBox.Show("No Job Ready found with the ClientID: " + clientID, "Please try again");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                c.Close();
            }
            return jobReadyList;

        }

        //Josiah 6/27/2022
        public static List<KeyValuePair<string, object>> Get_NewEmployment_By_ClientID(int clientID)
        {
            var newEmploymentList = new List<KeyValuePair<string, object>>();
            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();
            SqlCommand cmd_Income = new SqlCommand("sp_Get_NewEmployment_By_ClientID", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd_Income.Parameters.Add(new SqlParameter("@sp_ClientID", clientID));

            SqlDataReader rdr = cmd_Income.ExecuteReader();

            try
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    newEmploymentList.Add(new KeyValuePair<string, object>("BuinessName", rdr[0]));
                    newEmploymentList.Add(new KeyValuePair<string, object>("Address1", rdr[1]));
                    newEmploymentList.Add(new KeyValuePair<string, object>("Address2", rdr[2]));
                    newEmploymentList.Add(new KeyValuePair<string, object>("City", rdr[3]));
                    newEmploymentList.Add(new KeyValuePair<string, object>("State", rdr[4]));
                    newEmploymentList.Add(new KeyValuePair<string, object>("Zip", rdr[5]));
                    newEmploymentList.Add(new KeyValuePair<string, object>("BusinessPhone", rdr[6]));
                    newEmploymentList.Add(new KeyValuePair<string, object>("StartDate", rdr[7]));
                    newEmploymentList.Add(new KeyValuePair<string, object>("EndDate", rdr[8]));
                    newEmploymentList.Add(new KeyValuePair<string, object>("HourlyWage", rdr[9]));
                    newEmploymentList.Add(new KeyValuePair<string, object>("HoursPerWeek", rdr[10]));
                    newEmploymentList.Add(new KeyValuePair<string, object>("DescriptionOfDuties", rdr[11]));
                    newEmploymentList.Add(new KeyValuePair<string, object>("ReasonForLeavingPrevJob", rdr[12]));
                    newEmploymentList.Add(new KeyValuePair<string, object>("ClientID", rdr[13]));
                }
                else
                {
                    //MessageBox.Show("No New Employment found with the ClientID: " + clientID, "Please try again");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                c.Close();
            }
            return newEmploymentList;

        }

        //Josiah 6/27/2022
        public static List<KeyValuePair<string, object>> Get_Outcomes_By_ClientID(int clientID)
        {
            var outcomesList = new List<KeyValuePair<string, object>>();
            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();
            SqlCommand cmd_Income = new SqlCommand("sp_Get_Outcomes_By_ClientID", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd_Income.Parameters.Add(new SqlParameter("@sp_ClientID", clientID));

            SqlDataReader rdr = cmd_Income.ExecuteReader();

            try
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    outcomesList.Add(new KeyValuePair<string, object>("EmployerSector", rdr[0]));
                    outcomesList.Add(new KeyValuePair<string, object>("JobTitle", rdr[1]));
                    outcomesList.Add(new KeyValuePair<string, object>("EmployedthroguhtFit", rdr[2]));
                    outcomesList.Add(new KeyValuePair<string, object>("HireDate", rdr[3]));
                    outcomesList.Add(new KeyValuePair<string, object>("StartingSalary", rdr[4]));
                    outcomesList.Add(new KeyValuePair<string, object>("EligibleForHealthInsurance", rdr[5]));
                    outcomesList.Add(new KeyValuePair<string, object>("EligibleForOtherBenefits", rdr[6]));
                    outcomesList.Add(new KeyValuePair<string, object>("ParticipantSatisfied", rdr[7]));
                    outcomesList.Add(new KeyValuePair<string, object>("Enrolled", rdr[8]));
                    outcomesList.Add(new KeyValuePair<string, object>("ClientID", rdr[9]));
                    outcomesList.Add(new KeyValuePair<string, object>("CredentialAchieved", rdr[10]));
                }
                else
                {
                    //MessageBox.Show("No Outcomes found with the ClientID: " + clientID, "Please try again");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                c.Close();
            }
            return outcomesList;

        }

        //Josiah 6/27/2022
        public static List<KeyValuePair<string, object>> Get_PublicAssitance_By_ClientID(int clientID)
        {
            var publicAssitanceList = new List<KeyValuePair<string, object>>();
            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();
            SqlCommand cmd_Income = new SqlCommand("sp_Get_PublicAssitance_By_ClientID", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd_Income.Parameters.Add(new SqlParameter("@sp_ClientID", clientID));

            SqlDataReader rdr = cmd_Income.ExecuteReader();

            try
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    publicAssitanceList.Add(new KeyValuePair<string, object>("UnemploymentBenefit", rdr[0]));
                    publicAssitanceList.Add(new KeyValuePair<string, object>("SSI", rdr[1]));
                    publicAssitanceList.Add(new KeyValuePair<string, object>("TANF", rdr[2]));
                    publicAssitanceList.Add(new KeyValuePair<string, object>("SNAP", rdr[3]));
                    publicAssitanceList.Add(new KeyValuePair<string, object>("WIC", rdr[4]));
                    publicAssitanceList.Add(new KeyValuePair<string, object>("RentalAssist", rdr[5]));
                    publicAssitanceList.Add(new KeyValuePair<string, object>("UtilityAssist", rdr[6]));
                    publicAssitanceList.Add(new KeyValuePair<string, object>("FamilySupport", rdr[7]));
                    publicAssitanceList.Add(new KeyValuePair<string, object>("ClientID", rdr[8]));
                }
                else
                {
                    //MessageBox.Show("No Public Assitance found with the ClientID: " + clientID, "Please try again");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                c.Close();
            }
            return publicAssitanceList;

        }

        //Josiah 6/27/2022
        public static List<KeyValuePair<string, object>> Get_REI_By_ClientID(int clientID)
        {
            var REIList = new List<KeyValuePair<string, object>>();
            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();
            SqlCommand cmd_Income = new SqlCommand("sp_Get_REI_By_ClientID", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd_Income.Parameters.Add(new SqlParameter("@sp_ClientID", clientID));

            SqlDataReader rdr = cmd_Income.ExecuteReader();

            try
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    REIList.Add(new KeyValuePair<string, object>("StartDate", rdr[0]));
                    REIList.Add(new KeyValuePair<string, object>("EndDate", rdr[1]));
                    REIList.Add(new KeyValuePair<string, object>("Enrolled", rdr[2]));
                    REIList.Add(new KeyValuePair<string, object>("ClientID", rdr[3]));
                }
                else
                {
                    //MessageBox.Show("No REI found with the ClientID: " + clientID, "Please try again");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                c.Close();
            }
            return REIList;

        }


        #endregion

        #region Validation Methods

        public static bool IsUserAdmin(string userName)
        {
            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();
            SqlCommand cmd = new SqlCommand("sp_CheckAdminStatus", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@spUSERNAME", userName));

            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                if (rdr[0] == DBNull.Value)
                {
                    return false;
                }
                if (Convert.ToInt32(rdr[2]) == 1)
                {
                    return true;
                }
            }
            rdr.Close();
            c.Close();
            return false;
        }

        public static bool ClientExists(string fName, string lName, string lastFour)
        {
            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();
            SqlCommand cmd = new SqlCommand("sp_Search_Clients_By_LastName", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@FIRSTNAME", fName));
            cmd.Parameters.Add(new SqlParameter("@LASTNAME", lName));
            cmd.Parameters.Add(new SqlParameter("@SOCIAL", lastFour));

            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                if (rdr[0] == DBNull.Value || Convert.ToInt32(rdr[0]) == 0)
                {
                    return false;
                }
                if (Convert.ToInt32(rdr[0]) > 0)
                {
                    return true;
                }
            }
            rdr.Close();
            c.Close();
            return false;
        }

        #endregion

        #region Create Methods

        public static void Create_New_Client(int clientId, DateTime createdDate, int cmId, string firstName, string lastName, char middle_initial, string ssn)
        {
            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();
            SqlCommand cmd = new SqlCommand("sp_Create_New_Client", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@sp_CLIENTID", clientId));
            cmd.Parameters.Add(new SqlParameter("@sp_CREATEDDATE", createdDate));
            cmd.Parameters.Add(new SqlParameter("@sp_CMID", cmId));
            cmd.Parameters.Add(new SqlParameter("@sp_FIRSTNAME", firstName));
            cmd.Parameters.Add(new SqlParameter("@sp_LASTNAME", lastName));
            cmd.Parameters.Add(new SqlParameter("@sp_MIDDLEINITIAL", middle_initial));
            cmd.Parameters.Add(new SqlParameter("@sp_SOCIAL", ssn));

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was a problem adding the new client. Please screenshot this error message and send it to the IT Department:\n\n{ex.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                c.Close();
            }
        }

        public static void Create_New_Client_No_MI(int clientId, DateTime createdDate, int cmId, string firstName, string lastName, string ssn)
        {
            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();
            SqlCommand cmd = new SqlCommand("sp_Create_New_Client_No_MI", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@sp_CLIENTID", clientId));
            cmd.Parameters.Add(new SqlParameter("@sp_CREATEDDATE", createdDate));
            cmd.Parameters.Add(new SqlParameter("@sp_CMID", cmId));
            cmd.Parameters.Add(new SqlParameter("@sp_FIRSTNAME", firstName));
            cmd.Parameters.Add(new SqlParameter("@sp_LASTNAME", lastName));
            cmd.Parameters.Add(new SqlParameter("@sp_SOCIAL", ssn));

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was a problem adding the new client. Please screenshot this error message and send it to the IT Department:\n\n{ex.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                c.Close();
            }
        }

        #endregion

        #region Search Methods
        public static DataTable Client_SearchByCMID_Fill(int cmID)
        {
            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();

            SqlCommand cmd = new SqlCommand("sp_Search_Clients_By_CMID", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@CMID", cmID));

            SqlDataAdapter da = new SqlDataAdapter
            {
                SelectCommand = cmd
            };

            DataTable dt = new DataTable();
            da.Fill(dt);
            c.Close();
            return dt;
        }

        public static DataTable Client_SearchByLastName_Fill(string Client_LastName)
        {
            if (c.State.ToString() == "Open")
            {
                c.Close();
            }
            c.Open();

            SqlCommand cmd = new SqlCommand("sp_Search_Clients_By_LastName", c)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@LastName", Client_LastName));

            SqlDataAdapter da = new SqlDataAdapter
            {
                SelectCommand = cmd
            };

            DataTable dt = new DataTable();
            da.Fill(dt);
            c.Close();
            return dt;
        }

        #endregion
    }
}
