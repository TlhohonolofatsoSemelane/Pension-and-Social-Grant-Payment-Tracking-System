using System;
using System.Windows.Forms;
using PensionGrantTracker.Controllers;

namespace PensionGrantTracker.Views
{
    public partial class ChangePasswordForm : Form
    {
        private AuthController authController = new AuthController();
        private string username;

        public ChangePasswordForm(string user)
        {
            InitializeComponent();
            username = user;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text == "" || txtNewPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            if (txtNewPassword.Text.Length < 6)
            {
                MessageBox.Show("The new password must have at least 6 characters.");
                return;
            }
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("The new password and the confirmation do not match.");
                return;
            }
            try
            {
                if (authController.ChangePassword(username, txtOldPassword.Text, txtNewPassword.Text))
                {
                    MessageBox.Show("Password changed.");
                    Close();
                }
                else
                {
                    MessageBox.Show("The old password is wrong.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
