using Newtonsoft.Json;
using System;
using VetExample.Entities.Base;

namespace VetExample.Entities
{
    /// <summary>
    /// TreatmentType entity. Extends BaseEntity with TreatmentType.EntityData table's model. 
    /// Implements ICloneable to give clone functionality and IEquatable to give compare functionality
    /// </summary>
    public class TreatmentType : BaseEntity<TreatmentType.EntityData>
    , ICloneable, IEquatable<TreatmentType>
    {
        /// <summary>
        /// The model for table TRET_TREATMENTTYPE. It extends BaseEntityData so it has the common system fields.
        /// Implements ICloneable to provide functionality to clone itself for backup scope
        /// </summary>
        public class EntityData : BaseEntityData, ICloneable
        {
            internal int _TRET_ID_PK;
            internal string _TRET_DESCRIPTION;

            /// <summary>
            /// This function clones the EntityData for data backup during BeginEdit() of IEditableObject
            /// </summary>
            /// <returns>A new TreatmentType.EntityData</returns>
            public object Clone()
            {
                EntityData res = new EntityData();
                res._TRET_ID_PK = this._TRET_ID_PK;
                res._TRET_DESCRIPTION = this._TRET_DESCRIPTION;
                return res;
            }
        }

        #region Constructor
        /// <summary>
        /// Constructor for json. The model deserialized from json uses this constructor that passes false as insert parameter to base, so the entity is created in view state
        /// </summary>
        [JsonConstructor]
        protected TreatmentType(int i) : base("TRET", false)
        {            
        }
        public TreatmentType(bool insert = true) : base("TRET", insert)
        {
        }
        public TreatmentType() : base("TRET", true)
        { }
        #endregion
        #region Properties
        public int TRET_ID_PK
        {
            get { return entData._TRET_ID_PK; }
            set
            {
                OnPropertyChanging();
                entData._TRET_ID_PK = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public string TRET_DESCRIPTION
        {
            get { return entData._TRET_DESCRIPTION; }
            set
            {
                OnPropertyChanging();
                entData._TRET_DESCRIPTION = value;
                OnPropertyChangedWidthStatus();
            }
        }
        /// <summary>
        /// Override the class's string transformer
        /// </summary>
        public override string ToString()
        {
            return this.TRET_DESCRIPTION;
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
            TreatmentType objAsUser = other as TreatmentType;
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
            return entData._TRET_ID_PK;
        }

        /// <summary>
        /// Override the equality operator
        /// </summary>
        public bool Equals(TreatmentType other)
        {
            if (other == null)
            {
                return false;
            }
            return (this.TRET_ID_PK.Equals(other.TRET_ID_PK));
        }
        #endregion
        #region ICloneable
        /// <summary>
        /// This function clones the TreatmentType
        /// </summary>
        /// <returns>a new TreatmentType</returns>
        public object Clone()
        {
            TreatmentType res = new TreatmentType();
            res.TRET_ID_PK = this.TRET_ID_PK;
            res.TRET_DESCRIPTION = this.TRET_DESCRIPTION;
            res.CurrentState = this.CurrentState;
            return res;
        }
        #endregion
    }
}
