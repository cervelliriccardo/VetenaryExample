using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using VetExample.Common;
using VetExample.Entities.Base;

namespace VetExample.DAL.Base
{
    public enum SystemFields
    {
        validityStartDate,
        validityEndDate,
        lastModifiedBy,
        lastModifiedDate,
        deletedDate
    }

    public class BaseDAL
    {
        /// <summary>
        /// Reset the entities's status of the list. Recursively resets all the objects and lists of content objects
        /// </summary>
        /// <param name="objectList">List of object to reset</param>
        /// <remarks></remarks>
        static internal void ResetTransactionStateList(IEnumerable<IBaseEntity> objectList)
        {
            if (objectList != null)
            {
                foreach (IBaseEntity obj in objectList)
                {
                    obj.ResetTransactionState();
                    PropertyInfo[] properties = (PropertyInfo[])obj.GetType().GetRuntimeProperties();
                    foreach (PropertyInfo property in properties)
                    {
                        if ((typeof(string) != property.PropertyType) && typeof(System.Collections.IEnumerable).IsAssignableFrom(property.PropertyType))
                        {
                            ResetTransactionStateList((IEnumerable<IBaseEntity>)property.GetValue(obj));
                        }
                        else if ((typeof(string) != property.PropertyType) && typeof(IBaseEntity).IsAssignableFrom(property.PropertyType) && property.GetValue(obj) != null)
                        {
                            ((IBaseEntity)property.GetValue(obj)).ResetTransactionState();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// This procedure adds the parameter for the common field at the sql command. It is used to pass value to SqlServer stored procedure
        /// </summary>
        /// <param name="sqlParameterCollection">the parameters list where add parameters to</param>
        /// <param name="obj2Add">the object implementing the IBaseEntity interface that contains the value to add</param>
        /// <param name="sysFieldsToAdd">List of the parameter type to be added</param>
        protected void AddSystemParameter(SqlParameterCollection sqlParameterCollection, IBaseEntity obj2Add, SystemFields[] sysFieldsToAdd)
        {
            foreach (SystemFields field in sysFieldsToAdd)
            {
                switch (field)
                {
                    case SystemFields.lastModifiedDate:
                        sqlParameterCollection.Add(new SqlParameter("@" + obj2Add.TablePrefix + "_LASTMODIFIEDDATE_P", SqlDbType.DateTime)).Value = obj2Add.lastModifiedDate.HasValue ? obj2Add.lastModifiedDate : (object)DBNull.Value;
                        break;
                    case SystemFields.deletedDate:
                        sqlParameterCollection.Add(new SqlParameter("@" + obj2Add.TablePrefix + "_DELETEDDATE_P", SqlDbType.DateTime)).Value = obj2Add.deletedDate.HasValue ? obj2Add.deletedDate : (object)DBNull.Value;
                        break;
                    case SystemFields.validityEndDate:
                        sqlParameterCollection.Add(new SqlParameter("@" + obj2Add.TablePrefix + "_VALIDITYENDDATE_P", SqlDbType.DateTime)).Value = obj2Add.validityEndDate.HasValue ? obj2Add.validityEndDate : (object)DBNull.Value;
                        break;
                    case SystemFields.validityStartDate:
                        sqlParameterCollection.Add(new SqlParameter("@" + obj2Add.TablePrefix + "_VALIDITYSTARTDATE_P", SqlDbType.DateTime)).Value = obj2Add.validityStartDate.HasValue ? obj2Add.validityStartDate : (object)DBNull.Value;
                        break;
                    case SystemFields.lastModifiedBy:
                        sqlParameterCollection.Add(new SqlParameter("@" + obj2Add.TablePrefix + "_LASTMODIFIEDBY_P", SqlDbType.Int)).Value = CommonData.userLogged.USER_ID_PK;
                        break;
                }
            }
        }
    }
}
