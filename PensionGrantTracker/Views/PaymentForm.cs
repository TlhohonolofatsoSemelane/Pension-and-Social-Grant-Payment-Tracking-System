using System;
using System.Windows.Forms;
using PensionGrantTracker.Controllers;

namespace PensionGrantTracker.Views
{
    public partial class PaymentForm : Form
    {
        private PaymentController controller = new PaymentController();
        private int selectedId = 0;

        public PaymentForm()
        {
            InitializeComponent();
            cboFilter.SelectedIndex = 0;
            LoadData();
        }

        private string GetMonth()
        {
            return dtpMonth.Value.ToString("yyyy-MM");
        }

        private void LoadData()
        {
            try
            {
                dgvPayments.DataSource = null;
                dgvPayments.DataSource = controller.GetByMonth(GetMonth(), cboFilter.SelectedItem.ToString());
                if (dgvPayments.Columns["BeneficiaryId"] != null)
                {
                    dgvPayments.Columns["BeneficiaryId"].Visible = false;
                }
                selectedId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load data: " + ex.Message);
            }
        }

        private bool PaymentSelected()
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Select a payment from the list first.");
                return false;
            }
            return true;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCreateMonth_Click(object sender, EventArgs e)
        {
            try
            {
                int count = controller.CreateForMonth(GetMonth());
                if (count == 0)
                {
                    MessageBox.Show("No new payments were created. They may already exist for " + GetMonth() + ", or there are no Active beneficiaries.");
                }
                else
                {
                    MessageBox.Show(count + " payments created for " + GetMonth() + ".");
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnMarkPaid_Click(object sender, EventArgs e)
        {
            if (!PaymentSelected())
            {
                return;
            }
            try
            {
                controller.MarkPaid(selectedId, dtpPaidDate.Value.Date);
                txtReason.Text = "";
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnMarkDelayed_Click(object sender, EventArgs e)
        {
            if (!PaymentSelected())
            {
                return;
            }
            if (txtReason.Text.Trim() == "")
            {
                MessageBox.Show("Please write the reason for the delay.");
                return;
            }
            try
            {
                controller.MarkDelayed(selectedId, txtReason.Text.Trim());
                txtReason.Text = "";
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnMarkPending_Click(object sender, EventArgs e)
        {
            if (!PaymentSelected())
            {
                return;
            }
            try
            {
                controller.MarkPending(selectedId);
                txtReason.Text = "";
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDeletePayment_Click(object sender, EventArgs e)
        {
            if (!PaymentSelected())
            {
                return;
            }
            DialogResult answer = MessageBox.Show("Delete this payment?", "Confirm", MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                try
                {
                    controller.Delete(selectedId);
                    txtReason.Text = "";
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dgvPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgvPayments.Rows[e.RowIndex];
            selectedId = Convert.ToInt32(row.Cells["Id"].Value);
            txtReason.Text = row.Cells["DelayReason"].Value.ToString();
        }
    }
}
