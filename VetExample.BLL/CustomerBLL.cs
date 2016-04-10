using System;
using System.Collections.Generic;
using VetExample.BLL.Base;
using VetExample.DAL;
using VetExample.Entities;

namespace VetExample.BLL
{
    public class CustomerBLL : BaseBLL<List<Customer>>
    {
        public List<Customer> customers { get { return _CustomData; } set { _CustomData = value; } }
        #region Get
        public bool GetAllCustomersFull(bool justValid)
        {            
            try
            {
                customers = CustomerDAL.GetAllCustomers(justValid);
                return true;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Data modification
        public bool UpdateFull(Customer currentElement)
        {
            try
            {
                CustomerDAL cusDal = new CustomerDAL();
                return cusDal.UpdateCustomerFull(currentElement);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveFull(Customer currentElement)
        {
            try
            {
                CustomerDAL cusDal = new CustomerDAL();
                return cusDal.InsertCustomerFull(currentElement);
            }
            catch (Exception ex)
            {
                throw ex;             
            }
        }

        public bool Restore(Customer currentElement)
        {
            try
            {
                CustomerDAL cusDal = new CustomerDAL();
                return cusDal.RestoreCustomer(currentElement);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(Customer currentElement)
        {
            try
            {
                CustomerDAL cusDal = new CustomerDAL();
                return cusDal.DeleteCustomer(currentElement);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
