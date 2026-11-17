using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PensionGrantTracker.Controllers;
using PensionGrantTracker.Models;

namespace PensionGrantTracker.Views
{
    public partial class BeneficiaryForm : Form
    {
        private BeneficiaryController controller = new BeneficiaryController();
        private PayPointController payPointController = new PayPointController();
        private int selectedId = 0;

        public BeneficiaryForm()
        {
            InitializeComponent();
            cboStatus.SelectedIndex = 0;
            LoadPayPoints();
            LoadData();
        }

        private void LoadPayPoints()
        {
            try
            {
                cboPayPoint.DataSource = payPointController.GetAll();
                cboPayPoint.DisplayMember = "Name";
                cboPayPoint.ValueMember = "Id";
                cboPayPoint.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load pay points: " + ex.Message);
            }
        }

        private void ShowList(List<Beneficiary> list)
        {
            dgvBeneficiaries.DataSource = null;
            dgvBeneficiaries.DataSource = list;
            if (dgvBeneficiaries.Columns["PayPointId"] != null)
            {
                dgvBeneficiaries.Columns["PayPointId"].Visible = false;
            }
            selectedId = 0;
        }

        private void LoadData()
        {
            try
            {
                ShowList(controller.GetAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load data: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtFullName.Text = "";
            txtNationalId.Text = "";
            txtPhone.Text = "";
            txtDistrict.Text = "";
            txtVillage.Text = "";
            cboGrantType.SelectedIndex = -1;
            txtMonthlyAmount.Text = "";
            cboStatus.SelectedIndex = 0;
            cboPayPoint.SelectedIndex = -1;
            selectedId = 0;
        }

        private bool ReadFields(Beneficiary b)
        {
            if (txtFullName.Text.Trim() == "" || txtNationalId.Text.Trim() == "" || txtDistrict.Text.Trim() == "" || txtVillage.Text.Trim() == "" || txtMonthlyAmount.Text.Trim() == "" || cboGrantType.SelectedIndex == -1 || cboStatus.SelectedIndex == -1 || cboPayPoint.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields. Only the phone number is optional.");
                return false;
            }
            decimal amount;
            if (!decimal.TryParse(txtMonthlyAmount.Text, out amount))
            {
                MessageBox.Show("Monthly amount must be a number.");
                return false;
            }
            if (amount <= 0)
            {
                MessageBox.Show("Monthly amount must be more than zero.");
                return false;
            }
            string phone = txtPhone.Text.Trim();
            foreach (char c in phone)
            {
                if (!char.IsDigit(c) && c != '+')
                {
                    MessageBox.Show("The phone number can only have digits and the plus sign.");
                    return false;
                }
            }
            b.FullName = txtFullName.Text.Trim();
            b.NationalId = txtNationalId.Text.Trim();
            b.Phone = phone;
            b.District = txtDistrict.Text.Trim();
            b.Village = txtVillage.Text.Trim();
            b.GrantType = cboGrantType.SelectedItem.ToString();
            b.MonthlyAmount = amount;
            b.Status = cboStatus.SelectedItem.ToString();
            b.PayPointId = Convert.ToInt32(cboPayPoint.SelectedValue);
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Beneficiary b = new Beneficiary();
            if (!ReadFields(b))
            {
                return;
            }
            try
            {
                if (controller.NationalIdExists(b.NationalId, 0))
                {
                    MessageBox.Show("A beneficiary with this national ID already exists.");
                    return;
                }
                controller.Add(b);
                MessageBox.Show("Beneficiary added.");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Select a beneficiary from the list first.");
                return;
            }
            Beneficiary b = new Beneficiary();
            if (!ReadFields(b))
            {
                return;
            }
            b.Id = selectedId;
            try
            {
                if (controller.NationalIdExists(b.NationalId, selectedId))
                {
                    MessageBox.Show("Another beneficiary already has this national ID.");
                    return;
                }
                controller.Update(b);
                MessageBox.Show("Beneficiary updated.");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Select a beneficiary from the list first.");
                return;
            }
            try
            {
                if (controller.HasPayments(selectedId))
                {
                    MessageBox.Show("This beneficiary has payment records and cannot be deleted. Set the status to Inactive instead.");
                    return;
                }
                DialogResult answer = MessageBox.Show("Delete this beneficiary?", "Confirm", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    controller.Delete(selectedId);
                    MessageBox.Show("Beneficiary deleted.");
                    LoadData();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Select a beneficiary from the list first.");
                return;
            }
            PaymentHistoryForm form = new PaymentHistoryForm(selectedId, txtFullName.Text);
            form.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "")
            {
                LoadData();
                return;
            }
            try
            {
                ShowList(controller.Search(txtSearch.Text.Trim()));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadData();
        }

        private void dgvBeneficiaries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgvBeneficiaries.Rows[e.RowIndex];
            selectedId = Convert.ToInt32(row.Cells["Id"].Value);
            txtFullName.Text = row.Cells["FullName"].Value.ToString();
            txtNationalId.Text = row.Cells["NationalId"].Value.ToString();
            txtPhone.Text = row.Cells["Phone"].Value.ToString();
            txtDistrict.Text = row.Cells["District"].Value.ToString();
            txtVillage.Text = row.Cells["Village"].Value.ToString();
            cboGrantType.SelectedItem = row.Cells["GrantType"].Value.ToString();
            txtMonthlyAmount.Text = row.Cells["MonthlyAmount"].Value.ToString();
            cboStatus.SelectedItem = row.Cells["Status"].Value.ToString();
            cboPayPoint.SelectedValue = Convert.ToInt32(row.Cells["PayPointId"].Value);
        }
    }
}
