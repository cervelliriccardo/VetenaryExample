using Newtonsoft.Json;
using System;
using VetExample.Entities.Base;

namespace VetExample.Entities
{
    /// <summary>
    /// Treatment entity. Extends BaseEntity with Treatment.EntityData table's model. 
    /// Implements ICloneable to give clone functionality and IEquatable to give compare functionality
    /// </summary>
    public class Treatment : BaseEntity<Treatment.EntityData>
    , ICloneable, IEquatable<Treatment>
    {
        /// <summary>
        /// The model for table TREA_TREATMENT. It extends BaseEntityData so it has the common system fields.
        /// Implements ICloneable to provide functionality to clone itself for backup scope
        /// </summary>
        public class EntityData : BaseEntityData, ICloneable
        {
            internal int _TREA_ANIM_ID_PK;
            internal Animal _animal;
            internal int _TREA_TRET_ID_PK;
            internal TreatmentType _treatmentType;
            internal DateTime _TREA_TREATDATE_PK = DateTime.Now;
            internal int _TREA_PERFORMEDBY;
            internal User _treatmentPerformedByUser;
            internal string _TREA_NOTE;

            /// <summary>
            /// This function clone the EntityData for data backup during BeginEdit() of IEditableObject
            /// </summary>
            /// <returns>A new Treatment.EntityData</returns>
            public object Clone()
            {
                EntityData res = new EntityData();
                res._TREA_ANIM_ID_PK = this._TREA_ANIM_ID_PK;
                res._animal = (this._animal == null ? null : (Animal)this._animal.Clone());
                res._TREA_TRET_ID_PK = this._TREA_TRET_ID_PK;
                res._treatmentType = (this._treatmentType == null ? null : (TreatmentType)this._treatmentType.Clone());
                res._TREA_TREATDATE_PK = this._TREA_TREATDATE_PK;
                res._TREA_PERFORMEDBY = this._TREA_PERFORMEDBY;
                res._treatmentPerformedByUser = (this._treatmentPerformedByUser == null ? null : (User)this._treatmentPerformedByUser.Clone());
                res._TREA_NOTE = this._TREA_NOTE;
                this.CloneSystemData(res);
                return res;
            }
        }

        #region Constructor
        /// <summary>
        /// Constructor for json. The model deserialized from json uses this constructor that passes false as insert parameter to base, so the entity is created in view state
        /// </summary>
        [JsonConstructor]
        protected Treatment(int i) : base("TREA", false)
        {

        }
        public Treatment(bool insert = true) : base("TREA", insert)
        {

        }
        public Treatment() : base("TREA", true)
        { }
        #endregion
        #region Properties
        public int TREA_ANIM_ID_PK
        {
            get { return entData._TREA_ANIM_ID_PK; }
            set
            {
                OnPropertyChanging();
                entData._TREA_ANIM_ID_PK = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public Animal animal
        {
            get { return entData._animal; }
            set
            {
                OnPropertyChanging();
                entData._animal = value;
                if (value != null)
                    entData._TREA_ANIM_ID_PK = value.ANIM_ID_PK;
                OnPropertyChangedWidthStatus();
            }
        }
        public int TREA_TRET_ID_PK
        {
            get { return entData._TREA_TRET_ID_PK; }
            set
            {
                OnPropertyChanging();
                entData._TREA_TRET_ID_PK = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public TreatmentType treatmentType
        {
            get { return entData._treatmentType; }
            set
            {
                OnPropertyChanging();
                entData._treatmentType = value;
                if (value != null)
                    entData._TREA_TRET_ID_PK = value.TRET_ID_PK;
                OnPropertyChangedWidthStatus();
            }
        }
        public DateTime TREA_TREATDATE_PK
        {
            get { return entData._TREA_TREATDATE_PK; }
            set
            {
                OnPropertyChanging();
                entData._TREA_TREATDATE_PK = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public int TREA_PERFORMEDBY
        {
            get { return entData._TREA_PERFORMEDBY; }
            set
            {
                OnPropertyChanging();
                entData._TREA_PERFORMEDBY = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public User treatmentPerformedByUser
        {
            get { return entData._treatmentPerformedByUser; }
            set
            {
                OnPropertyChanging();
                entData._treatmentPerformedByUser = value;
                if (value != null)
                    entData._TREA_PERFORMEDBY = value.USER_ID_PK;
                OnPropertyChangedWidthStatus();
            }
        }
        public string TREA_NOTE
        {
            get { return entData._TREA_NOTE; }
            set
            {
                OnPropertyChanging();
                entData._TREA_NOTE = value;
                OnPropertyChangedWidthStatus();
            }
        }
        /// <summary>
        /// Override the class's string transformer
        /// </summary>
        public override string ToString()
        {
            return this.treatmentType.ToString() + " " + this.TREA_TREATDATE_PK.ToString() ;
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
            Treatment objAsUser = other as Treatment;
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
            return int.Parse(TREA_ANIM_ID_PK.ToString() + TREA_TRET_ID_PK.ToString() + TREA_TREATDATE_PK.DayOfYear.ToString() + TREA_TREATDATE_PK.Hour.ToString() + TREA_TREATDATE_PK.Minute.ToString());
        }

        /// <summary>
        /// Override the equality operator
        /// </summary>
        public bool Equals(Treatment other)
        {
            if (other == null)
            {
                return false;
            }
            return (this.GetHashCode().Equals(other.GetHashCode()));
        }
        #endregion
        #region ICloneable
        /// <summary>
        /// This function clones the Treatment
        /// </summary>
        /// <returns>a new Treatment</returns>
        public object Clone()
        {
            Treatment res = new Treatment();
            res.TREA_ANIM_ID_PK = this.TREA_ANIM_ID_PK;
            res.animal = (this.animal == null ? null : (Animal)this.animal.Clone());
            res.TREA_NOTE = this.TREA_NOTE;
            res.TREA_PERFORMEDBY = this.TREA_PERFORMEDBY;
            res.treatmentPerformedByUser = (this.treatmentPerformedByUser == null ? null : (User)this.treatmentPerformedByUser.Clone());
            res.TREA_TREATDATE_PK = this.TREA_TREATDATE_PK;
            res.TREA_TRET_ID_PK = this.TREA_TRET_ID_PK;
            res.treatmentType = (this.treatmentType == null ? null : (TreatmentType)this.treatmentType.Clone());
            this.CloneSystemData(res);
            return res;
        }
        #endregion
    }
}
