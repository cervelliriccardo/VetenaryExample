using Newtonsoft.Json;
using System;
using VetExample.Entities.Base;

namespace VetExample.Entities
{
    /// <summary>
    /// AnimalType entity. Extends BaseEntity with AnimalType.EntityData table's model. 
    /// Implements ICloneable to give clone functionality and IEquatable to give compare functionality
    /// </summary>
    public class AnimalType : BaseEntity<AnimalType.EntityData>
    , ICloneable, IEquatable<AnimalType>
    {
        /// <summary>
        /// The model for table ANMT_ANIMALTYPE. It extends BaseEntityData so it has the common system fields.
        /// Implements ICloneable to provide functionality to clone itself for backup scope
        /// </summary>
        public class EntityData : BaseEntityData, ICloneable
        {
            internal int _ANMT_ID_PK;
            internal string _ANMT_DESCRIPTION;

            /// <summary>
            /// This function clone the EntityData for data backup during BeginEdit() of IEditableObject
            /// </summary>
            /// <returns>A new AnimalType.EntityData</returns>
            public object Clone()
            {
                EntityData res = new EntityData();
                res._ANMT_ID_PK = this._ANMT_ID_PK;
                res._ANMT_DESCRIPTION = this._ANMT_DESCRIPTION;
                return res;
            }
        }

        #region Constructor
        /// <summary>
        /// Constructor for json. The model deserialized from json uses this constructor that passes false as insert parameter to base, so the entity is created in view state
        /// </summary>
        [JsonConstructor]
        protected AnimalType(int i) : base("ANMT", false)
        {
        }
        public AnimalType(bool insert = true) : base("ANMT", insert)
        {
        }
        public AnimalType() : base("ANMT", true)
        { }
        #endregion
        #region Properties
        public int ANMT_ID_PK
        {
            get { return entData._ANMT_ID_PK; }
            set
            {
                OnPropertyChanging();
                entData._ANMT_ID_PK = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public string ANMT_DESCRIPTION
        {
            get { return entData._ANMT_DESCRIPTION; }
            set
            {
                OnPropertyChanging();
                entData._ANMT_DESCRIPTION = value;
                OnPropertyChangedWidthStatus();
            }
        }
        /// <summary>
        /// override the class's string transformer
        /// </summary>
        public override string ToString()
        {
            return this.ANMT_DESCRIPTION;
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
            AnimalType objAsUser = other as AnimalType;
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
            return entData._ANMT_ID_PK;
        }

        /// <summary>
        /// Override the equality operator
        /// </summary>
        public bool Equals(AnimalType other)
        {
            if (other == null)
            {
                return false;
            }
            return (this.ANMT_ID_PK.Equals(other.ANMT_ID_PK));
        }
        #endregion
        #region ICloneable
        /// <summary>
        /// This function clones the AnimalType
        /// </summary>
        /// <returns>A new AnimalType</returns>
        public object Clone()
        {
            AnimalType res = new AnimalType();
            res.ANMT_ID_PK = this.ANMT_ID_PK;
            res.ANMT_DESCRIPTION = this.ANMT_DESCRIPTION;
            res.CurrentState = this.CurrentState;
            return res;
        }
        #endregion
    }
}
