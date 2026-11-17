using System;
using System.Windows.Forms;
using PensionGrantTracker.Controllers;
using PensionGrantTracker.Models;

namespace PensionGrantTracker.Views
{
    public partial class ReportForm : Form
    {
        private PaymentController paymentController = new PaymentController();
        private ReportController reportController = new ReportController();

        public ReportForm()
        {
            InitializeComponent();
            ShowReport();
        }

        private void HideColumn(string name)
        {
            if (dgvNotPaid.Columns[name] != null)
            {
                dgvNotPaid.Columns[name].Visible = false;
            }
        }

        private void ShowReport()
        {
            try
            {
                string month = dtpMonth.Value.ToString("yyyy-MM");
                MonthSummary s = reportController.GetSummary(month);
                lblTotal.Text = "Total payments: " + s.Total;
                lblPaid.Text = "Paid: " + s.Paid;
                lblPending.Text = "Pending: " + s.Pending;
                lblDelayed.Text = "Delayed: " + s.Delayed;
                lblAmountPaid.Text = "Amount already paid: " + s.AmountPaid.ToString("N2");
                lblAmountToPay.Text = "Amount still to be paid: " + s.AmountToPay.ToString("N2");
                dgvNotPaid.DataSource = null;
                dgvNotPaid.DataSource = paymentController.GetNotPaid(month);
                HideColumn("Id");
                HideColumn("BeneficiaryId");
                HideColumn("PaymentMonth");
                HideColumn("PaidDate");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load the report: " + ex.Message);
            }
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            ShowReport();
        }
    }
}
