using VetExample.Common;
using VetExample.DAL;
using VetExample.Entities;
namespace VetExample.BLL
{
    public class UserBLL
    {
        private UserDAL userDal = new UserDAL();

        #region Get
        public bool Login(string userName, string passWord)
        {
            User loggedUser = userDal.Login(userName, passWord);
            if (loggedUser != null)
            {
                CommonData.userLogged = loggedUser;
                return true;
            }
            return false;
        }
        #endregion
    }
}
