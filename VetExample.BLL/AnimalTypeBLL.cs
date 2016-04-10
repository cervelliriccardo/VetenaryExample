using System;
using System.Collections.Generic;
using VetExample.BLL.Base;
using VetExample.DAL;
using VetExample.Entities;

namespace VetExample.BLL
{
    public class AnimalTypeBLL : BaseBLL<List<AnimalType>>
    {
        public List<AnimalType> animalTypes { get { return _CustomData; } set { _CustomData = value; } }

        #region Get
        public bool GetAnimalType(bool justValid = true)
        {
            try
            {
                animalTypes = AnimalDAL.GetAnimalTypes(justValid);
                return true;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Data modification
        public bool Update(AnimalType currentElement)
        {
            try
            {
                AnimalDAL animalDal = new AnimalDAL();
                return animalDal.UpdateAnimalType(currentElement);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Save(AnimalType currentElement)
        {
            try
            {
                AnimalDAL animalDal = new AnimalDAL();
                return animalDal.InsertAnimalType(currentElement);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Restore(AnimalType currentElement)
        {
            try
            {
                AnimalDAL animalDal = new AnimalDAL();
                return animalDal.RestoreAnimalType(currentElement);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(AnimalType currentElement)
        {
            try
            {
                AnimalDAL animalDal = new AnimalDAL();
                return animalDal.DeleteAnimalType(currentElement);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
