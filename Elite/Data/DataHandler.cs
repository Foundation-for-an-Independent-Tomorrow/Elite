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
