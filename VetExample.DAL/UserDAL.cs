using System;
using System.Data;
using System.Data.SqlClient;
using VetExample.Common;
using VetExample.DAL.Base;
using VetExample.Entities;

namespace VetExample.DAL
{
    public class UserDAL : BaseDAL
    {
        #region Getter
        public User Login(string usrname, string password)
        {
            DataSet ds = new DataSet();
            User loggedUser = null;
            try
            {
                if (string.IsNullOrEmpty(usrname) || string.IsNullOrEmpty(password))
                {
                    return loggedUser;
                }
                using (SqlConnection con = new SqlConnection(CommonData.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("USER_LOGIN_PR_S", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = usrname;
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            loggedUser = ReadUserDataRow(ds.Tables[0].Rows[0]);
                        }
                        return loggedUser;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static User ReadUserDataRow(DataRow dataRow)
        {
            try
            {
                User userEntity = new User();

                userEntity.USER_ID_PK = (int)dataRow["USER_ID_PK"];
                userEntity.USER_NAME = dataRow["USER_NAME"].ToString().Trim();
                userEntity.USER_SURNAME = dataRow["USER_SURNAME"].ToString().Trim();
                userEntity.USER_USERNAME = dataRow["USER_USERNAME"].ToString().Trim();
                userEntity.SetSystemData(dataRow);
                userEntity.ResetTransactionState();

                return userEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
