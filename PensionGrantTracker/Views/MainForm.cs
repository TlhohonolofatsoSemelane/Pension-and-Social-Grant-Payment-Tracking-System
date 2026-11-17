using System;
using System.Windows.Forms;

namespace PensionGrantTracker.Views
{
    public partial class MainForm : Form
    {
        public bool LoggedOut = false;
        private string username;

        public MainForm(string user)
        {
            InitializeComponent();
            username = user;
            lblUser.Text = "Signed in as: " + username;
        }

        private void btnPayPoints_Click(object sender, EventArgs e)
        {
            PayPointForm form = new PayPointForm();
            form.ShowDialog();
        }

        private void btnBeneficiaries_Click(object sender, EventArgs e)
        {
            BeneficiaryForm form = new BeneficiaryForm();
            form.ShowDialog();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            PaymentForm form = new PaymentForm();
            form.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportForm form = new ReportForm();
            form.ShowDialog();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm form = new ChangePasswordForm(username);
            form.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoggedOut = true;
            Close();
        }
    }
}
