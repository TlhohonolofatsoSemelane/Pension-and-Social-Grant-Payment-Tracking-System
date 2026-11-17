using System;
using System.Windows.Forms;
using PensionGrantTracker.Controllers;

namespace PensionGrantTracker.Views
{
    public partial class PaymentHistoryForm : Form
    {
        public PaymentHistoryForm(int beneficiaryId, string name)
        {
            InitializeComponent();
            lblTitle.Text = "Payment history of " + name;
            try
            {
                PaymentController controller = new PaymentController();
                dgvHistory.DataSource = controller.GetByBeneficiary(beneficiaryId);
                if (dgvHistory.Columns["BeneficiaryId"] != null)
                {
                    dgvHistory.Columns["BeneficiaryId"].Visible = false;
                }
                if (dgvHistory.Columns["Id"] != null)
                {
                    dgvHistory.Columns["Id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load data: " + ex.Message);
            }
        }
    }
}
