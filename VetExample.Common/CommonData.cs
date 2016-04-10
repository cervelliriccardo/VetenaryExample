using System;
using System.Configuration;
using VetExample.Entities;

namespace VetExample.Common
{
    /// <summary>
    /// Information available at the Application Context level
    /// </summary>
    public static class CommonData
    {        
        /// <summary>
        /// Connection String
        /// </summary>
        public static string connectionString = ConfigurationManager.ConnectionStrings["VetExampleConnection"].ToString();
        
        /// <summary>
        /// Logged user
        /// </summary>
        public static User userLogged;

        public static void Refresh()
        {
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["VetExampleConnection"].ToString();
                userLogged = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
