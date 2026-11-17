using System;
using System.Windows.Forms;
using PensionGrantTracker.Controllers;

namespace PensionGrantTracker.Views
{
    public partial class LoginForm : Form
    {
        private AuthController authController = new AuthController();
        public string LoggedInUser = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (authController.Login(txtUsername.Text.Trim(), txtPassword.Text))
                {
                    LoggedInUser = txtUsername.Text.Trim();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Wrong username or password.");
                    txtPassword.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not log in: " + ex.Message);
            }
        }
    }
}
