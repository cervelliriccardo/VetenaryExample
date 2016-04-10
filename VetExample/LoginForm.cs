using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VetExample.BLL;
using VetExample.Common;

namespace VetExample
{
    public partial class LoginForm : Form
    {
        public bool isLogged { get; set; } = false;
        public LoginForm()
        {
            InitializeComponent();
        }

        public static bool CheckLogIn()
        {
            LoginForm f = new LoginForm();
            f.ShowDialog();
            return f.isLogged;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UserBLL userBLL = new UserBLL();
                if (userBLL.Login(tbUsername.Text, tbPassword.Text))
                {
                    isLogged = true;
                    Close();
                }
                else
                {
                    Display.ShowMessage("Login falied. Retry");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
