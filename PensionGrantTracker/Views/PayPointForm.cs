using System;
using System.Windows.Forms;
using PensionGrantTracker.Controllers;
using PensionGrantTracker.Models;

namespace PensionGrantTracker.Views
{
    public partial class PayPointForm : Form
    {
        private PayPointController controller = new PayPointController();
        private int selectedId = 0;

        public PayPointForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvPayPoints.DataSource = null;
                dgvPayPoints.DataSource = controller.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load data: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtDistrict.Text = "";
            selectedId = 0;
        }

        private bool ReadFields(PayPoint p)
        {
            if (txtName.Text.Trim() == "" || txtDistrict.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the name and the district.");
                return false;
            }
            p.Name = txtName.Text.Trim();
            p.District = txtDistrict.Text.Trim();
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PayPoint p = new PayPoint();
            if (!ReadFields(p))
            {
                return;
            }
            try
            {
                controller.Add(p);
                MessageBox.Show("Pay point added.");
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
                MessageBox.Show("Select a pay point from the list first.");
                return;
            }
            PayPoint p = new PayPoint();
            if (!ReadFields(p))
            {
                return;
            }
            p.Id = selectedId;
            try
            {
                controller.Update(p);
                MessageBox.Show("Pay point updated.");
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
                MessageBox.Show("Select a pay point from the list first.");
                return;
            }
            try
            {
                if (controller.HasBeneficiaries(selectedId))
                {
                    MessageBox.Show("This pay point still has beneficiaries assigned to it, so it cannot be deleted.");
                    return;
                }
                DialogResult answer = MessageBox.Show("Delete this pay point?", "Confirm", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    controller.Delete(selectedId);
                    MessageBox.Show("Pay point deleted.");
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

        private void dgvPayPoints_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgvPayPoints.Rows[e.RowIndex];
            selectedId = Convert.ToInt32(row.Cells["Id"].Value);
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtDistrict.Text = row.Cells["District"].Value.ToString();
        }
    }
}
