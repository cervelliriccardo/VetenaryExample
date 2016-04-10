using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VetExample.Common;
using VetExample.DAL.Base;
using VetExample.Entities;
using Newtonsoft.Json;
using System;
using System.Text;
using VetExample.Entities.Base;

namespace VetExample.DAL
{
    public class CustomerDAL : BaseDAL
    {
        #region Getter
        /// <summary>
        /// Select the customers from the database.
        /// It retrives all the relatid tables information: customers, animal end treatments
        /// It retrieve information in jSon format
        /// </summary>
        /// <param name="justValid"></param>
        /// <returns></returns>
        public static List<Customer> GetAllCustomers(bool justValid)
        {
            SqlConnection con = new SqlConnection(CommonData.connectionString);
            List<Customer> customers = new List<Customer>();
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("GetCustomersFull", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("@justValid_p", SqlDbType.Int)).Value = justValid;
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            StringBuilder sb = new StringBuilder();
                            while (reader.Read()) sb.Append(reader.GetSqlString(0).Value);

                            if (sb.Length > 0)
                            {
                                customers = ReadCustomersFromJson(sb.ToString());
                            }
                        }
                        return customers;
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// It deserializes the jSon string retrived from database in a List<Customer> form. 
        /// It resets the state of all the object in list to set it at view state
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<Customer> ReadCustomersFromJson(string source)
        {
            List<Customer> customers = null;
            if (source != null && source.Length > 0)
            {
                customers = JsonConvert.DeserializeObject<List<Customer>>(source);
                if (customers != null && customers.Count > 0)
                {
                    ResetTransactionStateList(customers);
                }
            }
            return customers;
        }
        #endregion
        #region Setter
        public bool InsertCustomer(Customer obj2Add, SqlConnection conn = null, SqlTransaction tran = null)
        {
            bool Bret = false;
            SqlConnection connessione = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                if (conn == null)
                {
                    connessione = new SqlConnection();
                    connessione.ConnectionString = CommonData.connectionString;
                    connessione.Open();
                }
                else {
                    connessione = conn;
                }
                cmd.Connection = connessione;
                cmd.CommandText = "CUSTOMER_PR_I";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CUST_NAME_P", SqlDbType.NVarChar)).Value = obj2Add.CUST_NAME;
                cmd.Parameters.Add(new SqlParameter("@CUST_SURMANE_P", SqlDbType.NVarChar)).Value = obj2Add.CUST_SURMANE;
                cmd.Parameters.Add(new SqlParameter("@CUST_TEL_NUM_P", SqlDbType.NVarChar)).Value = obj2Add.CUST_TEL_NUM;
                cmd.Parameters.Add(new SqlParameter("@CUST_ID_PK_P", SqlDbType.Int)).Direction = ParameterDirection.Output;
                //to add the lastModifiedBy, validityStartDate, validityEndDate parameter without write code
                AddSystemParameter(cmd.Parameters, obj2Add, new SystemFields[] { SystemFields.lastModifiedBy, SystemFields.validityStartDate, SystemFields.validityEndDate });

                if (tran == null)
                {
                    cmd.ExecuteNonQuery();
                    Bret = true;
                }
                else {
                    cmd.Transaction = tran;
                    cmd.ExecuteNonQuery();
                    Bret = true;
                }
                if (!Bret)
                {
                    throw new Exception(string.Format(Properties.Resources.exDataEntryFailed, "Customer"));
                }
                obj2Add.CUST_ID_PK = int.Parse(cmd.Parameters["@CUST_ID_PK_P"].Value.ToString());

                return Bret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn == null)
                {
                    connessione.Close();
                }
            }
        }
        /// <summary>
        /// It inserts a new customer and, eventually, all the added animals and treatments related
        /// </summary>
        /// <param name="obj2Add">the customer to be added</param>
        /// <returns></returns>
        public bool InsertCustomerFull(Customer obj2Add)
        {
            CustomerDAL custDal = new CustomerDAL();
            bool Bret = true;
            SqlConnection connessione = new SqlConnection(CommonData.connectionString);
            SqlTransaction oTrans = null;
            try
            {
                connessione.ConnectionString = CommonData.connectionString;
                connessione.Open();
                oTrans = connessione.BeginTransaction();
                Bret = custDal.InsertCustomer(obj2Add, connessione, oTrans);
                //If the new customers has a list of animals added simultaneously i pass this list to the function how is dealing
                if (obj2Add.animals != null && obj2Add.animals.Count > 0)
                {
                    AnimalDAL animalDal = new AnimalDAL();
                    Bret = Bret & animalDal.UpdateAnimalList(obj2Add.animals, obj2Add, connessione, oTrans);
                }
                if (Bret)
                {
                    oTrans.Commit();
                }
                else {
                    oTrans.Rollback();
                }
                return Bret;
            }
            catch (Exception ex)
            {
                if (oTrans != null)
                {
                    oTrans.Rollback();
                }
                throw ex;
            }
            finally
            {
                connessione.Close();
            }
        }
        public bool UpdateCustomer(Customer obj2Upd, SqlConnection conn = null, SqlTransaction tran = null)
        {
            bool Bret = false;
            SqlConnection connessione = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                if (conn == null)
                {
                    connessione = new SqlConnection();
                    connessione.ConnectionString = CommonData.connectionString;
                    connessione.Open();
                }
                else {
                    connessione = conn;
                }
                cmd.Connection = connessione;
                cmd.CommandText = "CUSTOMER_PR_U";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CUST_ID_PK_P", SqlDbType.Int)).Value = obj2Upd.CUST_ID_PK;
                cmd.Parameters.Add(new SqlParameter("@CUST_NAME_P", SqlDbType.NVarChar)).Value = obj2Upd.CUST_NAME;
                cmd.Parameters.Add(new SqlParameter("@CUST_SURMANE_P", SqlDbType.NVarChar)).Value = obj2Upd.CUST_SURMANE;
                cmd.Parameters.Add(new SqlParameter("@CUST_TEL_NUM_P", SqlDbType.NVarChar)).Value = obj2Upd.CUST_TEL_NUM;
                //to add the lastModifiedBy, validityStartDate, validityEndDate parameter without write code
                base.AddSystemParameter(cmd.Parameters, obj2Upd, new SystemFields[]{
                                    SystemFields.lastModifiedBy,
                                    SystemFields.validityStartDate,
                                    SystemFields.validityEndDate
                                });

                if (tran == null)
                {
                    cmd.ExecuteNonQuery();
                    Bret = true;
                }
                else {
                    cmd.Transaction = tran;
                    cmd.ExecuteNonQuery();
                    Bret = true;
                }
                if (!Bret)
                {
                    throw new Exception(string.Format(Properties.Resources.exDataUpdateFailed, "Customer"));
                }
                return Bret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn == null)
                {
                    connessione.Close();
                }
            }
        }
        /// <summary>
        /// It update a customer and, eventually, all the added or updated animals and treatments related
        /// </summary>
        /// <param name="obj2Upd"></param>
        /// <returns></returns>
        public bool UpdateCustomerFull(Customer obj2Upd)
        {
            CustomerDAL custDal = new CustomerDAL();
            bool Bret = true;
            SqlConnection connessione = new SqlConnection(CommonData.connectionString);
            SqlTransaction oTrans = null;
            try
            {
                connessione.Open();
                oTrans = connessione.BeginTransaction();
                if (obj2Upd.CurrentState != ObjectState.view)
                {
                    Bret = UpdateCustomer(obj2Upd, connessione, oTrans);
                }
                //If the customers has a list of animals, even if unchanged, i pass this list to the function how is dealing, because they could have treatments changed
                if (obj2Upd.animals != null && obj2Upd.animals.Count > 0)
                {
                    AnimalDAL animalDal = new AnimalDAL();
                    Bret = Bret & animalDal.UpdateAnimalList(obj2Upd.animals, obj2Upd, connessione, oTrans);
                }
                if (Bret)
                {
                    oTrans.Commit();
                }
                else {
                    oTrans.Rollback();
                }
                return Bret;
            }
            catch (Exception ex)
            {
                if (oTrans != null)
                {
                    oTrans.Rollback();
                }
                throw ex;
            }
            finally
            {
                connessione.Close();
            }
        }
        public bool RestoreCustomer(Customer obj2Res)
        {
            bool Bret = false;
            SqlConnection connessione = new SqlConnection(CommonData.connectionString);

            try
            {
                connessione.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connessione;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CUSTOMER_PR_R";
                cmd.Parameters.Add(new SqlParameter("@CUST_ID_PK_P", SqlDbType.Int)).Value = obj2Res.CUST_ID_PK;
                //to add the lastModifiedBy parameter without write code
                base.AddSystemParameter(cmd.Parameters, obj2Res, new SystemFields[]{
                                    SystemFields.lastModifiedBy
                                });

                cmd.ExecuteNonQuery();
                Bret = true;
                if (!Bret)
                {
                    throw new Exception(string.Format(Properties.Resources.exDataRestoreFailed, "Customer"));
                }
                return Bret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connessione.Close();
            }
        }
        public bool DeleteCustomer(Customer obj2Del)
        {
            bool Bret = false;
            SqlConnection connessione = new SqlConnection(CommonData.connectionString);

            try
            {
                connessione.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connessione;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CUSTOMER_PR_D";
                cmd.Parameters.Add(new SqlParameter("@CUST_ID_PK_P", SqlDbType.Int)).Value = obj2Del.CUST_ID_PK;
                //to add the lastModifiedBy parameter without write code
                base.AddSystemParameter(cmd.Parameters, obj2Del, new SystemFields[]{
                                    SystemFields.lastModifiedBy
                                });

                cmd.ExecuteNonQuery();
                Bret = true;
                if (!Bret)
                {
                    throw new Exception(string.Format(Properties.Resources.exDataDeleteFailed, "Customer"));
                }
                return Bret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connessione.Close();
            }
        }
        #endregion
    }
}
