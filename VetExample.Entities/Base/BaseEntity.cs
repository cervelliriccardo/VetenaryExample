using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace VetExample.Entities.Base
{
    /// <summary>
    /// Enumeration for the object state
    /// </summary>
    public enum ObjectState
    {
        view,
        insert,
        edit,
        delete
    }
    /// <summary>
    /// The abstract class used as base for the classes that realize the entity data model.
    /// It extends MyEntityBase to Notify Property Changing and Changed
    /// It implements IEditableObject to manage transaction and datasource objects
    /// It implements IBaseEntity for have access to common fields and functionality for all the entity in the model
    /// It provides events for PropertyChanging and PropertyChanged
    /// </summary>
    /// <typeparam name="T">Is the class type of the structure for data encapsulation. 
    /// IT MAY EXTENDS OR NOT THE ABSTRACT CLASS BaseEntityData that has the common field  
    /// validityStartDate
    /// validityEndDate
    /// lastModifiedBy
    /// lastModifiedDate
    /// deletedDate
    /// lastModifiedByUser
    /// If the database's table has all or some of this fields, T extends BaseEntityData otherwise it doesn't extend it</typeparam>
    public abstract class BaseEntity<T> : IEditableObject, INotifyPropertyChanged, INotifyPropertyChanging
        , IBaseEntity where T : new()
    {
        #region LocalMembers
        //Prefix of the database tables name to uniquely identify the tables in the database
        private string _tablePrefix;
        //current state of the entity
        private ObjectState _currentState = ObjectState.view;
        //structure instance for data encapsulation
        internal T entData;
        //structure instance for backing up data before change
        private T BackupData;
        //the object is in transaction?
        private bool _inTxn = false;
        [Category("ClassEvent")]
        [Description("Notify property changed")]
        public event PropertyChangedEventHandler PropertyChanged;

        [Category("ClassEvent")]
        [Description("Notify property changeding")]
        public event PropertyChangingEventHandler PropertyChanging;
        #endregion
        #region Constructor
        /// <summary>
        /// Entity constructor. The object could be created in view or insert mode. By default a new object is created in insert mode
        /// </summary>
        /// <param name="tablePrefix">Prefix of the database table</param>
        /// <param name="ins">insert mode, default true</param>
        public BaseEntity(string tablePrefix, bool ins = true)
        {
            if (tablePrefix.Length != 4)
                throw new ArgumentException("prefissoTab legth must be 4!");
            _tablePrefix = tablePrefix;
            entData = new T();
            if (ins)
            {
                this.CurrentState = ObjectState.insert;
            }
        }
        #endregion
        #region Proprietà di sistema
        /// <summary>
        /// In Base entity class i couldn't know if generics T extends or less BaseEntityData, 
        /// so i provided the property that uses reflection to read the value of the validityStartDate field if present, 
        /// otherwise it returns null
        /// </summary>
        public System.DateTime? validityStartDate
        {
            get
            {
                if (typeof(T).BaseType == typeof(BaseEntityData))
                {
                    FieldInfo fld = typeof(T).GetField("_validityStartDate", BindingFlags.Instance | BindingFlags.NonPublic);
                    return (fld.GetValue(entData) as DateTime?);
                }
                else {
                    return null;
                }
            }
            set
            {
                if (typeof(T).BaseType == typeof(BaseEntityData))
                {
                    //OnPropertyChanging(new PropertyChangingEventArgs("validityStartDate"));
                    OnPropertyChanging();
                    FieldInfo fld = typeof(T).GetField("_validityStartDate", BindingFlags.Instance | BindingFlags.NonPublic);
                    fld.SetValue(entData, value);
                    OnPropertyChangedWidthStatus();
                }
                else {
                }
            }
        }
        /// <summary>
        /// In Base entity class i couldn't know if generics T extends or less BaseEntityData, 
        /// so i provided the property that uses reflection to read the value of the validityEndDate field if present, 
        /// otherwise it returns null
        /// </summary>
        public System.DateTime? validityEndDate
        {
            get
            {
                if (typeof(T).BaseType == typeof(BaseEntityData))
                {
                    FieldInfo fld = typeof(T).GetField("_validityEndDate", BindingFlags.Instance | BindingFlags.NonPublic);
                    return (fld.GetValue(entData) as DateTime?);
                }
                else {
                    return null;
                }
            }
            set
            {
                if (typeof(T).BaseType == typeof(BaseEntityData))
                {
                    OnPropertyChanging();
                    FieldInfo fld = typeof(T).GetField("_validityEndDate", BindingFlags.Instance | BindingFlags.NonPublic);
                    fld.SetValue(entData, value);
                    OnPropertyChangedWidthStatus();

                }
                else {
                }
            }
        }
        /// <summary>
        /// In Base entity class i couldn't know if generics T extends or less BaseEntityData, 
        /// so i provided the property that uses reflection to read the value of the lastModifiedBy field if present, 
        /// otherwise it returns null
        /// </summary>
        public int? lastModifiedBy
        {
            get
            {
                if (typeof(T).BaseType == typeof(BaseEntityData))
                {
                    FieldInfo fld = typeof(T).GetField("_lastModifiedBy", BindingFlags.Instance | BindingFlags.NonPublic);
                    return (fld.GetValue(entData) as int?);

                }
                else {
                    return null;
                }
            }
            set
            {
                if (typeof(T).BaseType == typeof(BaseEntityData))
                {
                    FieldInfo fld = typeof(T).GetField("_lastModifiedBy", BindingFlags.Instance | BindingFlags.NonPublic);
                    fld.SetValue(entData, value);
                }
                else {
                }
            }
        }
        /// <summary>
        /// In Base entity class i couldn't know if generics T extends or less BaseEntityData, 
        /// so i provided the property that uses reflection to read the value of the lastModifiedDate field if present, 
        /// otherwise it returns null
        /// </summary>
        public System.DateTime? lastModifiedDate
        {
            get
            {
                if (typeof(T).BaseType == typeof(BaseEntityData))
                {
                    FieldInfo fld = typeof(T).GetField("_lastModifiedDate", BindingFlags.Instance | BindingFlags.NonPublic);
                    return (fld.GetValue(entData) as DateTime?);
                }
                else {
                    return null;
                }
            }
            set
            {
                if (typeof(T).BaseType == typeof(BaseEntityData))
                {
                    FieldInfo fld = typeof(T).GetField("_lastModifiedDate", BindingFlags.Instance | BindingFlags.NonPublic);
                    fld.SetValue(entData, value);
                }
                else {
                }
            }
        }
        /// <summary>
        /// In Base entity class i couldn't know if generics T extends or less BaseEntityData, 
        /// so i provided the property that uses reflection to read the value of the deletedDate field if present, 
        /// otherwise it returns null
        /// </summary>
        public System.DateTime? deletedDate
        {
            get
            {
                if (typeof(T).BaseType == typeof(BaseEntityData))
                {
                    FieldInfo fld = typeof(T).GetField("_deletedDate", BindingFlags.Instance | BindingFlags.NonPublic);
                    return (fld.GetValue(entData) as DateTime?);
                }
                else {
                    return null;
                }
            }
            set
            {
                if (typeof(T).BaseType == typeof(BaseEntityData))
                {
                    OnPropertyChanging();
                    FieldInfo fld = typeof(T).GetField("_deletedDate", BindingFlags.Instance | BindingFlags.NonPublic);
                    fld.SetValue(entData, value);
                    OnPropertyChangedWidthStatus();

                }
                else {
                }
            }
        }
        /// <summary>
        /// In Base entity class i couldn't know if generics T extends or less BaseEntityData, 
        /// so i provided the property that uses reflection to read the value of the lastModifiedByUser field if present, 
        /// otherwise it returns null
        /// </summary>
        public User lastModifiedByUser
        {
            get
            {
                if (typeof(T).BaseType == typeof(BaseEntityData))
                {
                    FieldInfo fld = typeof(T).GetField("_lastModifiedByUser", BindingFlags.Instance | BindingFlags.NonPublic);
                    return (User)fld.GetValue(entData);
                }
                else {
                    return null;
                }
            }
            set
            {
                if (typeof(T).BaseType == typeof(BaseEntityData))
                {
                    OnPropertyChanging();
                    FieldInfo fld = typeof(T).GetField("_lastModifiedByUser", BindingFlags.Instance | BindingFlags.NonPublic);
                    fld.SetValue(entData, value);
                    OnPropertyChangedWidthStatus();
                }
                else {
                }
            }
        }
        #endregion
        #region Bind dati di sistema
        /// <summary>
        /// Populates the standard fields for record system management: Start Date validity, validity End Date, LastModifiedBy, LastModifiedDate, deletedDate
        /// </summary>
        /// <param name="dr">The DataRow from which to read the values</param>
        /// <remarks></remarks>
        public void SetSystemData(DataRow dr)
        {
            SetSystemData(dr, "");
        }

        /// <summary>
        /// Populates the standard fields for record system management: Start Date validity, validity End Date, LastModifiedBy, LastModifiedDate, deletedDate. It adds to the standard name a suffix to manage queries that relate several times the same table
        /// It uses the BaseEntity interface characteristics to access to system value of generic type T
        /// </summary>
        /// <param name="dr">The DataRow from which to read the values</param>
        /// <param name="suffix">The suffix used in the query to distinguish the various relations to the same table</param>
        /// <remarks></remarks>
        public void SetSystemData(DataRow dr, string suffix)
        {
            try
            {
                if (typeof(T).BaseType == typeof(BaseEntityData))
                {
                    if ((Convert.IsDBNull(dr[TablePrefix + "_validityStartDate" + suffix])))
                    {
                    }
                    else {
                        this.validityStartDate = Convert.ToDateTime(dr[TablePrefix + "_validityStartDate" + suffix]);
                    }
                    if ((Convert.IsDBNull(dr[TablePrefix + "_validityEndDate" + suffix])))
                    {
                    }
                    else {
                        this.validityEndDate = Convert.ToDateTime(dr[TablePrefix + "_validityEndDate" + suffix]);
                    }
                    if ((Convert.IsDBNull(dr[TablePrefix + "_lastModifiedBy" + suffix])))
                    {
                    }
                    else {
                        this.lastModifiedBy = Convert.ToInt32(dr[TablePrefix + "_lastModifiedBy" + suffix]);
                    }
                    if ((Convert.IsDBNull(dr[TablePrefix + "_lastModifiedDate" + suffix])))
                    {
                    }
                    else {
                        this.lastModifiedDate = Convert.ToDateTime(dr[TablePrefix + "_lastModifiedDate" + suffix]);
                    }
                    if ((Convert.IsDBNull(dr[TablePrefix + "_deletedDate" + suffix])))
                    {
                    }
                    else {
                        this.deletedDate = Convert.ToDateTime(dr[TablePrefix + "_deletedDate" + suffix]);
                    }
                    if ((Convert.IsDBNull(dr[TablePrefix + "_USER_ID"])))
                    {
                    }
                    else {
                        User user = new User();
                        user.USER_ID_PK = Convert.ToInt32(dr[TablePrefix + "_USER_ID" + suffix]);
                        if ((!Convert.IsDBNull(dr[TablePrefix + "_USER_NAME" + suffix])))
                        {
                            user.USER_NAME = dr[TablePrefix + "_USER_NAME" + suffix].ToString();
                        }
                        if ((!Convert.IsDBNull(dr[TablePrefix + "_USER_PASSWORD" + suffix])))
                        {
                            user.USER_PASSWORD = dr[TablePrefix + "_USER_PASSWORD" + suffix].ToString();
                        }
                        if ((!Convert.IsDBNull(dr[TablePrefix + "_USER_SURNAME" + suffix])))
                        {
                            user.USER_SURNAME = dr[TablePrefix + "_USER_SURNAME" + suffix].ToString();
                        }
                        if ((!Convert.IsDBNull(dr[TablePrefix + "_USER_USERNAME" + suffix])))
                        {
                            user.USER_USERNAME = dr[TablePrefix + "_USER_USERNAME" + suffix].ToString();
                        }
                        this.lastModifiedByUser = user;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region IEditable
        /// <summary>
        /// When a field of the entity changes value, if the entity is not in insert or delete state, the current state is set to edit
        /// </summary>
        /// <param name="caller">The name of the changed field</param>
        internal void OnPropertyChangedWidthStatus([CallerMemberName] string caller = null)
        {
            if (CurrentState != ObjectState.insert & CurrentState != ObjectState.delete)
            {
                CurrentState = ObjectState.edit;
            }
            OnPropertyChanged(caller);
        }

        /// <summary>
        /// Event handler for undo changes
        /// </summary>
        public void CancelEdit()
        {
            if (_inTxn)
            {
                this.entData = BackupData;
                //restore the backup
                _inTxn = false;
                CurrentState = ObjectState.view;
            }
        }

        /// <summary>
        /// Event handler for end of the changes
        /// </summary>
        public void EndEdit()
        {
            //If _inTxn Then
            //    BackupData = New T 'inizializza l'oggetto di backup
            //    '_inTxn = False
            //    'CurrentState = ObjectState.view
            //End If
        }

        /// <summary>
        /// Event handler for begin of the changes
        /// </summary>
        public void BeginEdit()
        {
            if (!_inTxn)
            {
                //creates a backup of the current object
                this.BackupData = (T)((ICloneable)entData).Clone();                
                _inTxn = true;
            }
        }
        #endregion
        #region IBaseEntity
        /// <summary>
        /// identification code of the table in the database. 4 uppercase characters
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string TablePrefix
        {
            get { return _tablePrefix; }
            set { _tablePrefix = value; }
        }

        /// <summary>
        /// In transaction data, not persisted
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool inTxn
        {
            get { return _inTxn; }
            set { _inTxn = value; }
        }
        /// <summary>
        /// Current state of the entity
        /// </summary>
        public ObjectState CurrentState
        {
            get { return _currentState; }
            set { _currentState = value; }
        }

        public bool isValid()
        {
            return deletedDate != null;
        }

        /// <summary>
        /// It resets the state of the entity after database reading.
        /// The field are setted for the initialization not by a change, so the entity state must be reset to view
        /// </summary>
        /// <remarks></remarks>
        public void ResetTransactionState()
        {
            this.CurrentState = ObjectState.view;
            this.inTxn = false;
        }
        /// <summary>
        /// It copy the system value of this object in a new object to have a clone
        /// </summary>
        /// <param name="cloned">The cloned object</param>
        public void CloneSystemData(IBaseEntity cloned)
        {
            cloned.lastModifiedBy = this.lastModifiedBy;
            cloned.lastModifiedDate = this.lastModifiedDate;
            cloned.deletedDate = this.deletedDate;
            cloned.validityEndDate = this.validityEndDate;
            cloned.validityStartDate = this.validityStartDate;
            cloned.lastModifiedByUser = (this.lastModifiedByUser == null ? null : (User)this.lastModifiedByUser.Clone());
            cloned.CurrentState = this.CurrentState;
        }
        #endregion
        #region INotifyPropertyChanged, INotifyPropertyChanging
        protected void OnPropertyChanged([CallerMemberName] String caller = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
        protected void OnPropertyChanging([CallerMemberName] String caller = null)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(caller));
            }
        }
        #endregion
    }
}
