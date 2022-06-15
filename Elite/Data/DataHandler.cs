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
        public static int GetID(string id, string table )
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
                    MessageBox.Show("No Client Information found with the ClientID: " + clientID, "Please try again");
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
                if(Convert.ToInt32(rdr[0]) > 0)
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
