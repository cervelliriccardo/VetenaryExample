using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetExample.BLL.Base;
using VetExample.DAL;
using VetExample.Entities;

namespace VetExample.BLL
{
    public class TreatmentTypeBLL : BaseBLL<List<TreatmentType>>
    {
        public List<TreatmentType> treatmentTypes { get { return _CustomData; } set { _CustomData = value; } }

        #region Get
        public bool GetTreatmentType(bool justValid = true)
        {
            try
            {
                treatmentTypes = TreatmentDAL.GetTreatmentTypes(justValid);
                return true;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        #region Data modification
        public bool Update(TreatmentType currentElement)
        {
            try
            {
                TreatmentDAL treatDal = new TreatmentDAL();
                return treatDal.UpdateTreatmentType(currentElement);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Save(TreatmentType currentElement)
        {
            try
            {
                TreatmentDAL treatDal = new TreatmentDAL();
                return treatDal.InsertTreatmentType(currentElement);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Restore(TreatmentType currentElement)
        {
            try
            {
                TreatmentDAL treatDal = new TreatmentDAL();
                return treatDal.RestoreTreatmentType(currentElement);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(TreatmentType currentElement)
        {
            try
            {
                TreatmentDAL treatDal = new TreatmentDAL();
                return treatDal.DeleteTreatmentType(currentElement);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
