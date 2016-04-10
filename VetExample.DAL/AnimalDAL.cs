using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VetExample.Common;
using VetExample.DAL.Base;
using VetExample.Entities;
using VetExample.Entities.Base;

namespace VetExample.DAL
{
    public class AnimalDAL : BaseDAL
    {
        #region Getter
        /// <summary>
        /// Select the animal type from the database. It retrieve information in jSon format
        /// </summary>
        /// <param name="justValid">just not deleted value</param>
        /// <returns>List of AnimalType</returns>
        public static List<AnimalType> GetAnimalTypes(bool justValid = true)
        {
            SqlConnection con = new SqlConnection(CommonData.connectionString);
            List<AnimalType> animalTypes = new List<AnimalType>();
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("GetAnimalTypes", con))
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
                                animalTypes = ReadAnimalTypeFromJson(sb.ToString());
                            }
                        }
                        return animalTypes;
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
        /// It deserializes the jSon string retrived from database in a List<AnimalType> form. 
        /// It resets the state of all the object in list to set it at view state
        /// </summary>
        /// <param name="source">jSon string</param>
        /// <returns>List of AnimalType structure</returns>
        public static List<AnimalType> ReadAnimalTypeFromJson(string source)
        {
            List<AnimalType> animTypes = null;
            if (source != null && source.Length > 0)
            {
                animTypes = JsonConvert.DeserializeObject<List<AnimalType>>(source);
                if (animTypes != null && animTypes.Count > 0)
                {
                    ResetTransactionStateList(animTypes);
                }
            }
            return animTypes;
        }
        #endregion
        #region Setter
        #region Animal
        public bool InsertAnimal(Animal obj2Add, SqlConnection conn = null, SqlTransaction tran = null)
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

                obj2Add.ANIM_CUST_ID = obj2Add.customer.CUST_ID_PK;

                cmd.CommandText = "ANIMAL_PR_I";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ANIM_CUST_ID_P", SqlDbType.Int)).Value = obj2Add.ANIM_CUST_ID;
                cmd.Parameters.Add(new SqlParameter("@ANIM_NAME_P", SqlDbType.NVarChar)).Value = obj2Add.ANIM_NAME;
                cmd.Parameters.Add(new SqlParameter("@ANIM_ANMT_ID_P", SqlDbType.Int)).Value = obj2Add.ANIM_ANMT_ID;
                cmd.Parameters.Add(new SqlParameter("@ANIM_BIRTHDATE_P", SqlDbType.DateTime)).Value = obj2Add.ANIM_BIRTHDATE.HasValue ? obj2Add.ANIM_BIRTHDATE : (object)DBNull.Value;
                cmd.Parameters.Add(new SqlParameter("@ANIM_ID_PK_P", SqlDbType.Int)).Direction = ParameterDirection.Output;
                //to add the lastModifiedBy, validityStartDate, validityEndDate parameter without write code
                base.AddSystemParameter(cmd.Parameters, obj2Add, new SystemFields[] { SystemFields.lastModifiedBy, SystemFields.validityStartDate, SystemFields.validityEndDate });

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
                    throw new Exception(string.Format(Properties.Resources.exDataEntryFailed, "Animal"));
                obj2Add.ANIM_ID_PK = int.Parse(cmd.Parameters["@ANIM_ID_PK_P"].Value.ToString());
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
        public bool UpdateAnimal(Animal obj2Upd, SqlConnection conn = null, SqlTransaction tran = null)
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
                cmd.CommandText = "ANIMAL_PR_U";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ANIM_ID_PK_P", SqlDbType.Int)).Value = obj2Upd.ANIM_ID_PK;
                cmd.Parameters.Add(new SqlParameter("@ANIM_CUST_ID_P", SqlDbType.Int)).Value = obj2Upd.ANIM_CUST_ID;
                cmd.Parameters.Add(new SqlParameter("@ANIM_NAME_P", SqlDbType.NVarChar)).Value = obj2Upd.ANIM_NAME;
                cmd.Parameters.Add(new SqlParameter("@ANIM_ANMT_ID_P", SqlDbType.Int)).Value = obj2Upd.ANIM_ANMT_ID;
                cmd.Parameters.Add(new SqlParameter("@ANIM_BIRTHDATE_P", SqlDbType.DateTime)).Value = obj2Upd.ANIM_BIRTHDATE.HasValue ? obj2Upd.ANIM_BIRTHDATE : (object)DBNull.Value;
                //to add the lastModifiedBy, validityStartDate, validityEndDate, deletedDate parameter without write code
                base.AddSystemParameter(cmd.Parameters, obj2Upd, new SystemFields[] { SystemFields.lastModifiedBy, SystemFields.validityStartDate, SystemFields.validityEndDate, SystemFields.deletedDate });

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
                    throw new Exception(string.Format(Properties.Resources.exDataUpdateFailed, "Animal"));
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
        /// Persist avery change in the list of animals. The change action depends on the single object state (insert, update, delete, restore)
        /// </summary>
        /// <param name="animals">List of the animal to persist</param>
        /// <param name="cust">Customer animal's owner</param>
        /// <param name="conn">Connection to use for transaction</param>
        /// <param name="tran">transaction to use for persist data</param>
        /// <returns></returns>
        public bool UpdateAnimalList(List<Animal> animals, Customer cust, SqlConnection conn = null, SqlTransaction tran = null)
        {
            bool Bret = true;
            SqlConnection connessione;
            SqlTransaction oTrans;

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
                foreach (Animal animal in animals)
                {
                    switch (animal.CurrentState)
                    {
                        case ObjectState.insert:
                            animal.customer = new Customer(cust.CUST_ID_PK, false);
                            Bret = Bret & InsertAnimal(animal, connessione, oTrans);
                            break;
                        case ObjectState.edit:
                            Bret = Bret & UpdateAnimal(animal, connessione, oTrans);
                            break;
                        case ObjectState.delete:
                            if (animal.deletedDate == null) animal.deletedDate = DateTime.Now;
                            Bret = Bret & UpdateAnimal(animal, connessione, oTrans);
                            break;
                    }
                    if (animal.treatments != null && animal.treatments.Count > 0)
                    {
                        //For any animals it selects the list of treatments related that have a change to pass it to the function how is dealing
                        List<Treatment> modTreatments = animal.treatments.Where(x => x.CurrentState != ObjectState.view).ToList();
                        if (modTreatments != null && modTreatments.Count > 0)
                        {
                            TreatmentDAL treatDal = new TreatmentDAL();
                            Bret = Bret & treatDal.UpdateTreatmentList(modTreatments, animal, connessione, oTrans);
                        }
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
        #region Animal Type
        public bool RestoreAnimalType(AnimalType obj2Res)
        {
            bool Bret = false;
            SqlConnection connessione = new SqlConnection(CommonData.connectionString);

            try
            {
                connessione.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connessione;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ANIMALTYPE_PR_R";
                cmd.Parameters.Add(new SqlParameter("@ANMT_ID_PK_P", SqlDbType.Int)).Value = obj2Res.ANMT_ID_PK;
                //to add the lastModifiedBy parameter without write code
                base.AddSystemParameter(cmd.Parameters, obj2Res, new SystemFields[]{
                                    SystemFields.lastModifiedBy
                                });

                cmd.ExecuteNonQuery();
                Bret = true;
                if (!Bret)
                {
                    throw new Exception(string.Format(Properties.Resources.exDataEntryFailed, "Animal type"));
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
        public bool DeleteAnimalType(AnimalType obj2Del)
        {
            bool Bret = false;
            SqlConnection connessione = new SqlConnection(CommonData.connectionString);

            try
            {
                connessione.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connessione;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ANIMALTYPE_PR_D";
                cmd.Parameters.Add(new SqlParameter("@ANMT_ID_PK_P", SqlDbType.Int)).Value = obj2Del.ANMT_ID_PK;
                //to add the lastModifiedBy parameter without write code
                base.AddSystemParameter(cmd.Parameters, obj2Del, new SystemFields[]{
                                    SystemFields.lastModifiedBy
                                });

                cmd.ExecuteNonQuery();
                Bret = true;
                if (!Bret)
                {
                    throw new Exception(string.Format(Properties.Resources.exDataDeleteFailed, "Animal type"));
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
        public bool InsertAnimalType(AnimalType obj2Add)
        {
            bool Bret = false;
            SqlConnection connessione = new SqlConnection(CommonData.connectionString);

            try
            {
                connessione.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connessione;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ANIMALTYPE_PR_I";
                cmd.Parameters.Add(new SqlParameter("@ANMT_DESCRIPTION_P", SqlDbType.NVarChar)).Value = obj2Add.ANMT_DESCRIPTION;
                cmd.Parameters.Add(new SqlParameter("@ANMT_ID_PK_P", SqlDbType.Int)).Direction = ParameterDirection.Output;
                //to add the lastModifiedBy, validityStartDate, validityEndDate parameter without write code
                base.AddSystemParameter(cmd.Parameters, obj2Add, new SystemFields[]{
                                    SystemFields.lastModifiedBy, SystemFields.validityStartDate,SystemFields.validityEndDate
                                });

                cmd.ExecuteNonQuery();
                Bret = true;
                if (!Bret)
                {
                    throw new Exception(string.Format(Properties.Resources.exDataEntryFailed, "Animal type"));
                }
                obj2Add.ANMT_ID_PK = int.Parse(cmd.Parameters["@ANMT_ID_PK_P"].Value.ToString());
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
        public bool UpdateAnimalType(AnimalType obj2Upd)
        {
            bool Bret = false;
            SqlConnection connessione = new SqlConnection(CommonData.connectionString);

            try
            {
                connessione.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connessione;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ANIMALTYPE_PR_U";
                cmd.Parameters.Add(new SqlParameter("@ANMT_DESCRIPTION_P", SqlDbType.NVarChar)).Value = obj2Upd.ANMT_DESCRIPTION;
                cmd.Parameters.Add(new SqlParameter("@ANMT_ID_PK_P", SqlDbType.Int)).Value = obj2Upd.ANMT_ID_PK;
                //to add the lastModifiedBy, validityStartDate, validityEndDate parameter without write code
                base.AddSystemParameter(cmd.Parameters, obj2Upd, new SystemFields[]{
                                    SystemFields.lastModifiedBy, SystemFields.validityStartDate,SystemFields.validityEndDate
                                });

                cmd.ExecuteNonQuery();
                Bret = true;
                if (!Bret)
                {
                    throw new Exception(string.Format(Properties.Resources.exDataUpdateFailed, "Animal type"));
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
