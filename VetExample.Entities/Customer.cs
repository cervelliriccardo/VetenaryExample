using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VetExample.Entities.Base;

namespace VetExample.Entities
{
    /// <summary>
    /// Customer entity. Extends BaseEntity with Customer.EntityData table's model. 
    /// Implements ICloneable to give clone functionality and IEquatable to give compare functionality
    /// </summary>
    public class Customer : BaseEntity<Customer.EntityData>
    , ICloneable, IEquatable<Customer>
    {
        /// <summary>
        /// The model for table CUST_CUSTOMER. It extends BaseEntityData so it has the common system fields.
        /// Implements ICloneable to provide functionality to clone itself for backup scope
        /// </summary>
        public class EntityData : BaseEntityData, ICloneable
        {
            internal int _CUST_ID_PK;
            internal string _CUST_NAME;
            internal string _CUST_SURMANE;
            internal string _CUST_TEL_NUM;
            internal List<Animal> _animals = new List<Animal>();

            /// <summary>
            /// This function clones the EntityData for data backup during BeginEdit() of IEditableObject
            /// </summary>
            /// <returns>A new Customer.EntityData</returns>
            public object Clone()
            {
                EntityData res = new EntityData();
                res._CUST_ID_PK = this._CUST_ID_PK;
                res._CUST_NAME = this._CUST_NAME;
                res._CUST_SURMANE = this._CUST_SURMANE;
                res._CUST_TEL_NUM = this._CUST_TEL_NUM;
                res._animals = (this._animals == null ? null : animalsClone());
                this.CloneSystemData(res);
                return res;
            }
            /// <summary>
            /// It clones all the animals entity related to this customer to have a backup of the animals owned
            /// </summary>
            /// <returns>A new List of Animal</returns>
            private List<Animal> animalsClone()
            {
                List<Animal> newAnimals = new List<Animal>();
                foreach (Animal an in this._animals)
                {
                    newAnimals.Add((Animal)an.Clone());
                }
                return newAnimals;
            }
        }

        #region Constructor
        /// <summary>
        /// Constructor for json. The model deserialized from json uses this constructor that passes false as insert parameter to base, so the entity is created in view state
        /// </summary>
        [JsonConstructor]
        protected Customer(int i) : base("CUST", false)
        {

        }
        public Customer() : base("CUST", true)
        { }
        public Customer(bool insert = true) : base("CUST", insert)
        {

        }
        public Customer(int idCustomer, bool insert = true) : base("CUST", insert)
        {
            this.CUST_ID_PK = idCustomer;
            if (insert) this.CurrentState = ObjectState.insert;
            else this.CurrentState = ObjectState.view;
        }
        #endregion
        #region Properties
        public int CUST_ID_PK
        {
            get { return entData._CUST_ID_PK; }
            set
            {
                OnPropertyChanging();
                entData._CUST_ID_PK = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public string CUST_NAME
        {
            get { return entData._CUST_NAME; }
            set
            {
                OnPropertyChanging();
                entData._CUST_NAME = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public string CUST_SURMANE
        {
            get { return entData._CUST_SURMANE; }
            set
            {
                OnPropertyChanging();
                entData._CUST_SURMANE = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public string CUST_TEL_NUM
        {
            get { return entData._CUST_TEL_NUM; }
            set
            {
                OnPropertyChanging();
                entData._CUST_TEL_NUM = value;
                OnPropertyChangedWidthStatus();
            }
        }
        public List<Animal> animals
        {
            get { return entData._animals; }
            set
            {
                OnPropertyChanging();
                entData._animals = value;
                OnPropertyChangedWidthStatus();
            }
        }
        /// <summary>
        /// Transposition of the main customer data in summary form
        /// </summary>
        public string Description
        {
            get
            {
                return entData._CUST_NAME + " " + entData._CUST_SURMANE; 
            }
        }

        /// <summary>
        /// Override the class's string transformer
        /// </summary>
        public override string ToString()
        {
            return this.Description;
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
            Customer objAsUser = other as Customer;
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
            return entData._CUST_ID_PK;
        }

        /// <summary>
        /// Override the equality operator
        /// </summary>
        public bool Equals(Customer other)
        {
            if (other == null)
            {
                return false;
            }
            return (this.CUST_ID_PK.Equals(other.CUST_ID_PK));
        }
        #endregion
        #region ICloneable
        /// <summary>
        /// This function clones the Customer
        /// </summary>
        /// <returns>a new Customer</returns>
        public object Clone()
        {
            Customer res = new Customer();
            res.CUST_ID_PK = this.CUST_ID_PK;
            res.CUST_NAME = this.CUST_NAME;
            res.CUST_SURMANE = this.CUST_SURMANE;
            res.CUST_TEL_NUM = this.CUST_TEL_NUM;
            res.animals = (this.animals == null ? null : animalsClone());
            this.CloneSystemData(res);
            return res;
        }
        /// <summary>
        /// It clones all the animals entity related to this customer to have a backup of the animals owned
        /// </summary>
        /// <returns>A new List of Animal</returns>
        private List<Animal> animalsClone()
        {
            List<Animal> newAnimals = new List<Animal>();
            foreach (Animal an in this.animals)
            {
                newAnimals.Add((Animal)an.Clone());
            }
            return newAnimals;
        }
        #endregion
    }
}
