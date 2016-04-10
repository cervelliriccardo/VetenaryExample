using Newtonsoft.Json;
using System;
using VetExample.Entities.Base;

namespace VetExample.Entities
{
    /// <summary>
    /// User entity. Extends BaseEntity with User.EntityData table's model. 
    /// Implements ICloneable to give clone functionality and IEquatable to give compare functionality
    /// </summary>
    public class User : BaseEntity<User.EntityData>
    , ICloneable, IEquatable<User>
    {
        /// <summary>
        /// The model for table ANIM_ANIMAL. It DON'T EXTENDS BaseEntityData so it HASN'T the common system fields.
        /// Implements ICloneable to provide functionality to clone itself for backup scope
        /// </summary>
        public class EntityData : ICloneable
        {
            internal int _USER_ID_PK;
            internal string _USER_USERNAME;
            internal string _USER_PASSWORD;
            internal string _USER_NAME;
            internal string _USER_SURNAME;

            /// <summary>
            /// This function clones the EntityData for data backup during BeginEdit() of IEditableObject
            /// </summary>
            /// <returns>A new User.EntityData</returns>
            public object Clone()
            {
                EntityData res = new EntityData();
                res._USER_ID_PK = this._USER_ID_PK;
                res._USER_USERNAME = this._USER_USERNAME;
                res._USER_PASSWORD = this._USER_PASSWORD;
                res._USER_NAME = this._USER_NAME;
                res._USER_SURNAME = this._USER_SURNAME;
                return res;
            }
        }

        #region Constructor
        /// <summary>
        /// Constructor for json. The model deserialized from json uses this constructor that passes false as insert parameter to base, so the entity is created in view state
        /// </summary>
        [JsonConstructor]
        protected User(int i) : base("USER", false)
        {

        }
        public User(bool insert = true) : base("USER", insert)
        {
            
        }
        #endregion
        #region Properties
        public int USER_ID_PK
        {
            get { return entData._USER_ID_PK; }
            set
            {
                OnPropertyChanging();
                entData._USER_ID_PK = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public string USER_NAME
        {
            get { return entData._USER_NAME; }
            set
            {
                OnPropertyChanging();
                entData._USER_NAME = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public string USER_PASSWORD
        {
            get { return entData._USER_PASSWORD; }
            set
            {
                OnPropertyChanging();
                entData._USER_PASSWORD = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public string USER_SURNAME
        {
            get { return entData._USER_SURNAME; }
            set
            {
                OnPropertyChanging();
                entData._USER_SURNAME = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public string USER_USERNAME
        {
            get { return entData._USER_USERNAME; }
            set
            {
                OnPropertyChanging();
                entData._USER_USERNAME = value;
                OnPropertyChangedWidthStatus();
            }
        }
        /// <summary>
        /// Transposition of the main user data in summary form
        /// </summary>
        public string Descrizione
        {
            get
            {
                return entData._USER_NAME + " " + entData._USER_SURNAME;
            }
        }

        /// <summary>
        /// Override the class's string transformer
        /// </summary>
        public override string ToString()
        {
            return this.Descrizione;
        }
        #endregion
        #region IEquatable
        /// <summary>
        /// Override the equality operator
        /// </summary>
        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }
            User objAsUser = other as User;
            if (objAsUser == null)
            {
                return false;
            }
            else {
                return Equals(objAsUser);
            }
        }

        /// <summary>
        /// It returns a HashCode corresponding to the identification data necessary
        /// for implementation purposes of the interface standard for IEquatable
        /// the comparison and search operations
        /// </summary>
        public override int GetHashCode()
        {
            return entData._USER_ID_PK;
        }

        /// <summary>
        /// Override the equality operator
        /// </summary>
        public bool Equals(User other)
        {
            if (other == null)
            {
                return false;
            }
            return (this.USER_ID_PK.Equals(other.USER_ID_PK));
        }
        #endregion
        #region ICloneable
        /// <summary>
        /// This function clones the User
        /// </summary>
        /// <returns>a new User</returns>
        public object Clone()
        {
            User res = new User();
            res.USER_ID_PK = this.USER_ID_PK;
            res.USER_NAME = this.USER_NAME;
            res.USER_PASSWORD  = this.USER_PASSWORD;
            res.USER_SURNAME = this.USER_SURNAME;
            res.USER_USERNAME = this.USER_USERNAME;            
            res.CurrentState = this.CurrentState;
            return res;
        }
        #endregion
    }
}
