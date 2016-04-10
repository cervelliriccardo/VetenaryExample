using System;
using System.Windows.Forms;
using VetExample.Common;

namespace VetExample.Base
{
    public static class Master
    {
        public static void Main()
        {
            try
            {
                if (LoginForm.CheckLogIn())
                {
                    frmCustomers.ShowCustomers();
                }
                else {
                    Display.ShowError("Login failed");
                    Application.Exit();
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}
