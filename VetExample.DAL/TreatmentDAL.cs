using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using VetExample.Common;
using VetExample.DAL.Base;
using VetExample.Entities;
using VetExample.Entities.Base;

namespace VetExample.DAL
{
    public class TreatmentDAL : BaseDAL
    {
        #region Getter
        /// <summary>
        /// Select the Treatment type from the database. It retrieve information in jSon format
        /// </summary>
        /// <param name="justValid">just not deleted value</param>
        /// <returns>List of TreatmentType</returns>
        public static List<TreatmentType> GetTreatmentTypes(bool justValid = true)
        {
            SqlConnection con = new SqlConnection(CommonData.connectionString);
            List<TreatmentType> treatmentTypes = new List<TreatmentType>();
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("GetTreatmentTypes", con))
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
                                treatmentTypes = ReadTreatmentTypeFromJson(sb.ToString());
                            }
                        }
                        return treatmentTypes;
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// It deserializes the jSon string retrived from database in a List<TreatmentType> form. 
        /// It resets the state of all the object in list to set it at view state
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private static List<TreatmentType> ReadTreatmentTypeFromJson(string source)
        {
            List<TreatmentType> treatTypes = null;
            if (source != null && source.Length > 0)
            {
                treatTypes = JsonConvert.DeserializeObject<List<TreatmentType>>(source);
                if (treatTypes != null && treatTypes.Count > 0)
                {
                    ResetTransactionStateList(treatTypes);
                }
            }
            return treatTypes;
        }
        #endregion
        #region Setter
        #region Treatment
        public bool UpdateTreatment(Treatment obj2Upd, SqlConnection conn, SqlTransaction tran = null)
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
                    cmd.Connection = connessione;
                }
                else {
                    connessione = conn;
                    cmd.Connection = connessione;
                }
                cmd.CommandText = "TREATMENT_PR_U";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@TREA_ANIM_ID_PK_P", SqlDbType.Int)).Value = obj2Upd.TREA_ANIM_ID_PK;
                cmd.Parameters.Add(new SqlParameter("@TREA_TRET_ID_PK_P", SqlDbType.Int)).Value = obj2Upd.TREA_TRET_ID_PK;
                cmd.Parameters.Add(new SqlParameter("@TREA_TREATDATE_PK_P", SqlDbType.DateTime)).Value = obj2Upd.TREA_TREATDATE_PK;
                cmd.Parameters.Add(new SqlParameter("@TREA_NOTE_P", SqlDbType.NVarChar)).Value = obj2Upd.TREA_NOTE;
                //to add the lastModifiedBy, deletedDate, validityStartDate, validityEndDate parameter without write code
                AddSystemParameter(cmd.Parameters, obj2Upd, new SystemFields[] { SystemFields.lastModifiedBy, SystemFields.deletedDate, SystemFields.validityStartDate, SystemFields.validityEndDate });

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
                    throw new Exception(string.Format(Properties.Resources.exDataUpdateFailed, "Treatment"));
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
        public bool InsertTreatment(Treatment obj2Add, SqlConnection conn, SqlTransaction tran = null)
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
                obj2Add.TREA_ANIM_ID_PK = obj2Add.animal.ANIM_ID_PK;

                cmd.CommandText = "TREATMENT_PR_I";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@TREA_ANIM_ID_PK_P", SqlDbType.Int)).Value = obj2Add.TREA_ANIM_ID_PK;
                cmd.Parameters.Add(new SqlParameter("@TREA_TRET_ID_PK_P", SqlDbType.Int)).Value = obj2Add.TREA_TRET_ID_PK;
                cmd.Parameters.Add(new SqlParameter("@TREA_TREATDATE_PK_P", SqlDbType.DateTime)).Value = obj2Add.TREA_TREATDATE_PK;
                cmd.Parameters.Add(new SqlParameter("@TREA_PERFORMEDBY_P", SqlDbType.Int)).Value = CommonData.userLogged.USER_ID_PK;
                cmd.Parameters.Add(new SqlParameter("@TREA_NOTE_P", SqlDbType.NVarChar)).Value = obj2Add.TREA_NOTE == null ? (object)DBNull.Value : obj2Add.TREA_NOTE;
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
                    throw new Exception(string.Format(Properties.Resources.exDataEntryFailed, "Treatment"));
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
        /// Persist avery change in the list of treatments. The change action depends on the single object state (insert, update, delete, restore)
        /// </summary>
        /// <param name="treatments">List of the treatments to persist</param>
        /// <param name="animal">Animal that receives the treatments</param>
        /// <param name="conn">Connection to use for transaction</param>
        /// <param name="tran">transaction to use for persist data</param>
        /// <returns></returns>
        internal bool UpdateTreatmentList(List<Treatment> treatments, Animal animal, SqlConnection conn = null, SqlTransaction tran = null)
        {
            bool Bret = true;
            SqlConnection connessione = null;
            SqlTransaction oTrans = null;

            if (conn == null)
            {
                connessione = new SqlConnection();
                connessione.ConnectionString = CommonData.connectionString;
                connessione.Open();
                oTrans = connessione.BeginTransaction();
            }
            else {
                connessione = conn;
                oTrans = tran;
            }
            try
            {
                foreach (Treatment treat in treatments)
                {
                    switch (treat.CurrentState)
                    {
                        case ObjectState.insert:
                            treat.animal = new Animal(animal.ANIM_ID_PK, animal.ANIM_CUST_ID, false);
                            Bret = Bret & InsertTreatment(treat, connessione, oTrans);
                            break;
                        case ObjectState.edit:
                            Bret = Bret & UpdateTreatment(treat, connessione, oTrans);
                            break;
                        case ObjectState.delete:
                            if (treat.deletedDate == null) treat.deletedDate = DateTime.Now;
                            Bret = Bret & UpdateTreatment(treat, connessione, oTrans);
                            break;
                    }
                }
                if (conn == null & oTrans != null)
                {
                    oTrans.Commit();
                }
                return Bret;
            }
            catch (Exception ex)
            {
                if (conn == null & oTrans != null)
                {
                    oTrans.Rollback();
                }
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
        #endregion
        #region Treatment Type
        public bool InsertTreatmentType(TreatmentType obj2Add)
        {
            bool Bret = false;
            SqlConnection connessione = new SqlConnection(CommonData.connectionString);

            try
            {
                connessione.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connessione;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TREATMENTTYPE_PR_I";
                cmd.Parameters.Add(new SqlParameter("@TRET_DESCRIPTION_P", SqlDbType.NVarChar)).Value = obj2Add.TRET_DESCRIPTION;
                cmd.Parameters.Add(new SqlParameter("@TRET_ID_PK_P", SqlDbType.Int)).Direction = ParameterDirection.Output;
                //to add the lastModifiedBy, validityStartDate, validityEndDate parameter without write code
                base.AddSystemParameter(cmd.Parameters, obj2Add, new SystemFields[]{
                                    SystemFields.lastModifiedBy, SystemFields.validityStartDate,SystemFields.validityEndDate
                                });

                cmd.ExecuteNonQuery();
                Bret = true;
                if (!Bret)
                {
                    throw new Exception(string.Format(Properties.Resources.exDataEntryFailed, "Treatment type"));
                }
                obj2Add.TRET_ID_PK = int.Parse(cmd.Parameters["@TRET_ID_PK_P"].Value.ToString());
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
        public bool UpdateTreatmentType(TreatmentType obj2Upd)
        {
            bool Bret = false;
            SqlConnection connessione = new SqlConnection(CommonData.connectionString);

            try
            {
                connessione.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connessione;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TREATMENTTYPE_PR_U";
                cmd.Parameters.Add(new SqlParameter("@TRET_DESCRIPTION_P", SqlDbType.NVarChar)).Value = obj2Upd.TRET_DESCRIPTION;
                cmd.Parameters.Add(new SqlParameter("@TRET_ID_PK_P", SqlDbType.Int)).Value = obj2Upd.TRET_ID_PK;
                //to add the lastModifiedBy, validityStartDate, validityEndDate parameter without write code
                base.AddSystemParameter(cmd.Parameters, obj2Upd, new SystemFields[]{
                                    SystemFields.lastModifiedBy, SystemFields.validityStartDate,SystemFields.validityEndDate
                                });

                cmd.ExecuteNonQuery();
                Bret = true;
                if (!Bret)
                {
                    throw new Exception(string.Format(Properties.Resources.exDataUpdateFailed, "Treatment type"));
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
        public bool RestoreTreatmentType(TreatmentType obj2Res)
        {
            bool Bret = false;
            SqlConnection connessione = new SqlConnection(CommonData.connectionString);

            try
            {
                connessione.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connessione;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TREATMENTTYPE_PR_R";
                cmd.Parameters.Add(new SqlParameter("@TRET_ID_PK_P", SqlDbType.Int)).Value = obj2Res.TRET_ID_PK;
                //to add the lastModifiedBy parameter without write code
                base.AddSystemParameter(cmd.Parameters, obj2Res, new SystemFields[]{
                                    SystemFields.lastModifiedBy
                                });

                cmd.ExecuteNonQuery();
                Bret = true;
                if (!Bret)
                {
                    throw new Exception(string.Format(Properties.Resources.exDataRestoreFailed, "Treatment type"));
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
        public bool DeleteTreatmentType(TreatmentType obj2Del)
        {
            bool Bret = false;
            SqlConnection connessione = new SqlConnection(CommonData.connectionString);

            try
            {
                connessione.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connessione;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TREATMENTTYPE_PR_D";
                cmd.Parameters.Add(new SqlParameter("@TRET_ID_PK_P", SqlDbType.Int)).Value = obj2Del.TRET_ID_PK;
                //to add the lastModifiedBy parameter without write code
                base.AddSystemParameter(cmd.Parameters, obj2Del, new SystemFields[]{
                                    SystemFields.lastModifiedBy
                                });

                cmd.ExecuteNonQuery();
                Bret = true;
                if (!Bret)
                {
                    throw new Exception(string.Format(Properties.Resources.exDataDeleteFailed, "Treatment type"));
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
        #endregion
    }
}