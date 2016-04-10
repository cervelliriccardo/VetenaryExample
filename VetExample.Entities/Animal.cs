using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VetExample.Entities.Base;

namespace VetExample.Entities
{
    /// <summary>
    /// Animal entity. Extends BaseEntity with Animal.EntityData table's model. 
    /// Implements ICloneable to give clone functionality and IEquatable to give compare functionality
    /// </summary>
    public class Animal : BaseEntity<Animal.EntityData>
    , ICloneable, IEquatable<Animal>
    {
        /// <summary>
        /// The model for table ANIM_ANIMAL. It extends BaseEntityData so it has the common system fields.
        /// Implements ICloneable to provide functionality to clone itself for backup scope
        /// </summary>
        public class EntityData : BaseEntityData, ICloneable
        {
            internal int _ANIM_ID_PK;
            internal int _ANIM_CUST_ID;
            internal Customer _customer;
            internal string _ANIM_NAME;
            internal int _ANIM_ANMT_ID;
            internal AnimalType _animalType;
            internal DateTime? _ANIM_BIRTHDATE;
            internal List<Treatment> _treatments = new List<Treatment>();

            /// <summary>
            /// This function clones the EntityData for data backup during BeginEdit() of IEditableObject
            /// </summary>
            /// <returns>A new Animal.EntityData</returns>
            public object Clone()
            {
                EntityData res = new EntityData();
                res._ANIM_ID_PK = this._ANIM_ID_PK;
                res._ANIM_CUST_ID = this._ANIM_CUST_ID;
                res._customer = (this._customer == null ? null : (Customer)this._customer.Clone());
                res._ANIM_NAME = this._ANIM_NAME;
                res._ANIM_ANMT_ID = this._ANIM_ANMT_ID;
                res._animalType = (this._animalType == null ? null : (AnimalType)this._animalType.Clone());
                res._ANIM_BIRTHDATE = this._ANIM_BIRTHDATE;
                res._treatments = (this._treatments == null ? null : treatmentsClone());
                this.CloneSystemData(res);
                return res;
            }
            /// <summary>
            /// It clones all the treatments entity related to this animal to have a backup of the treatments done
            /// </summary>
            /// <returns>A new List of Treatment</returns>
            private List<Treatment> treatmentsClone()
            {
                List<Treatment> newTreatments = new List<Treatment>();
                foreach (Treatment tr in this._treatments)
                {
                    newTreatments.Add((Treatment)tr.Clone());
                }
                return newTreatments;
            }
        }

        #region Constructor
        /// <summary>
        /// Constructor for json. The model deserialized from json uses this constructor that passes false as insert parameter to base, so the entity is created in view state
        /// </summary>
        [JsonConstructor]
        protected Animal(int i) : base("ANIM", false)
        {

        }
        public Animal(bool insert = true) : base("ANIM", insert)
        {

        }
        public Animal() : base("ANIM", true)
        { }
        public Animal(int animalId, int customerId, bool insert = true) : base("ANIM", insert)
        {
            this.ANIM_ID_PK = animalId;
            this.ANIM_CUST_ID = customerId;
            if (insert) this.CurrentState = ObjectState.insert;
            else this.CurrentState = ObjectState.view;
        }
        #endregion
        #region Properties
        public int ANIM_ID_PK
        {
            get { return entData._ANIM_ID_PK; }
            set
            {
                OnPropertyChanging();
                entData._ANIM_ID_PK = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public int ANIM_CUST_ID
        {
            get { return entData._ANIM_CUST_ID; }
            set
            {
                OnPropertyChanging();
                entData._ANIM_CUST_ID = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public Customer customer
        {
            get { return entData._customer; }
            set
            {
                OnPropertyChanging();
                entData._customer = value;
                if (value != null)
                    entData._ANIM_CUST_ID = value.CUST_ID_PK;
                OnPropertyChangedWidthStatus();
            }
        }
        public string ANIM_NAME
        {
            get { return entData._ANIM_NAME; }
            set
            {
                OnPropertyChanging();
                entData._ANIM_NAME = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public int ANIM_ANMT_ID
        {
            get { return entData._ANIM_ANMT_ID; }
            set
            {
                OnPropertyChanging();
                entData._ANIM_ANMT_ID = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public AnimalType animalType
        {
            get { return entData._animalType; }
            set
            {
                OnPropertyChanging();
                entData._animalType = value;
                if (value != null)
                    entData._ANIM_ANMT_ID = value.ANMT_ID_PK;
                OnPropertyChangedWidthStatus();
            }
        }
        public DateTime? ANIM_BIRTHDATE
        {
            get { return entData._ANIM_BIRTHDATE; }
            set
            {
                OnPropertyChanging();
                entData._ANIM_BIRTHDATE = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public List<Treatment> treatments
        {
            get { return entData._treatments; }
            set
            {
                OnPropertyChanging();
                entData._treatments = value;
                OnPropertyChangedWidthStatus();
            }
        }
        /// <summary>
        /// Override the class's string transformer
        /// </summary>
        public override string ToString()
        {
            return this.ANIM_NAME;
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
            Animal objAsUser = other as Animal;
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
            return entData._ANIM_ID_PK;
        }

        /// <summary>
        /// Override the equality operator
        /// </summary>
        public bool Equals(Animal other)
        {
            if (other == null)
            {
                return false;
            }
            return (this.ANIM_ID_PK.Equals(other.ANIM_ID_PK));
        }
        #endregion
        #region ICloneable
        /// <summary>
        /// This function clones the Animal
        /// </summary>
        /// <returns>a new Animal</returns>
        public object Clone()
        {
            Animal res = new Animal();
            res.ANIM_ID_PK = this.ANIM_ID_PK;
            res.ANIM_CUST_ID = this.ANIM_CUST_ID;
            res.customer = (this.customer == null ? null : (Customer)this.customer.Clone());
            res.ANIM_NAME = this.ANIM_NAME;
            res.ANIM_ANMT_ID = this.ANIM_ANMT_ID;
            res.animalType = (this.animalType == null ? null : (AnimalType)this.animalType.Clone());
            res.ANIM_BIRTHDATE = this.ANIM_BIRTHDATE;
            res.treatments = (this.treatments == null ? null : treatmentsClone());
            this.CloneSystemData(res);
            return res;
        }
        /// <summary>
        /// It clones all the treatments entity related to this animal to have a backup of the treatments done
        /// </summary>
        /// <returns>A new List of Treatment</returns>
        private List<Treatment> treatmentsClone()
        {
            List<Treatment> newTreatments = new List<Treatment>();
            foreach (Treatment tr in this.treatments)
            {
                newTreatments.Add((Treatment)tr.Clone());
            }
            return newTreatments;
        }
        #endregion
    }
}
