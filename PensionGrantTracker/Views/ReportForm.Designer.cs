namespace PensionGrantTracker.Views
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMonth = new System.Windows.Forms.Label();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPaid = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.lblDelayed = new System.Windows.Forms.Label();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.lblAmountToPay = new System.Windows.Forms.Label();
            this.lblWaiting = new System.Windows.Forms.Label();
            this.dgvNotPaid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotPaid)).BeginInit();
            this.SuspendLayout();
            this.lblMonth.Location = new System.Drawing.Point(20, 23);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(50, 15);
            this.lblMonth.TabIndex = 0;
            this.lblMonth.AutoSize = true;
            this.lblMonth.Text = "Month";
            this.dtpMonth.Location = new System.Drawing.Point(80, 20);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.Size = new System.Drawing.Size(110, 23);
            this.dtpMonth.TabIndex = 1;
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.CustomFormat = "yyyy-MM";
            this.dtpMonth.ShowUpDown = true;
            this.btnShowReport.Location = new System.Drawing.Point(210, 18);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(120, 28);
            this.btnShowReport.TabIndex = 2;
            this.btnShowReport.Text = "Show Report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            this.lblTotal.Location = new System.Drawing.Point(20, 70);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 15);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.AutoSize = true;
            this.lblTotal.Text = "Total payments: 0";
            this.lblPaid.Location = new System.Drawing.Point(20, 95);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(100, 15);
            this.lblPaid.TabIndex = 4;
            this.lblPaid.AutoSize = true;
            this.lblPaid.Text = "Paid: 0";
            this.lblPending.Location = new System.Drawing.Point(20, 120);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(100, 15);
            this.lblPending.TabIndex = 5;
            this.lblPending.AutoSize = true;
            this.lblPending.Text = "Pending: 0";
            this.lblDelayed.Location = new System.Drawing.Point(20, 145);
            this.lblDelayed.Name = "lblDelayed";
            this.lblDelayed.Size = new System.Drawing.Size(100, 15);
            this.lblDelayed.TabIndex = 6;
            this.lblDelayed.AutoSize = true;
            this.lblDelayed.Text = "Delayed: 0";
            this.lblAmountPaid.Location = new System.Drawing.Point(300, 70);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(150, 15);
            this.lblAmountPaid.TabIndex = 7;
            this.lblAmountPaid.AutoSize = true;
            this.lblAmountPaid.Text = "Amount already paid: 0";
            this.lblAmountToPay.Location = new System.Drawing.Point(300, 95);
            this.lblAmountToPay.Name = "lblAmountToPay";
            this.lblAmountToPay.Size = new System.Drawing.Size(150, 15);
            this.lblAmountToPay.TabIndex = 8;
            this.lblAmountToPay.AutoSize = true;
            this.lblAmountToPay.Text = "Amount still to be paid: 0";
            this.lblWaiting.Location = new System.Drawing.Point(20, 185);
            this.lblWaiting.Name = "lblWaiting";
            this.lblWaiting.Size = new System.Drawing.Size(200, 20);
            this.lblWaiting.TabIndex = 9;
            this.lblWaiting.AutoSize = true;
            this.lblWaiting.Text = "Payments not yet paid";
            this.lblWaiting.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.dgvNotPaid.Location = new System.Drawing.Point(20, 215);
            this.dgvNotPaid.Name = "dgvNotPaid";
            this.dgvNotPaid.Size = new System.Drawing.Size(760, 265);
            this.dgvNotPaid.TabIndex = 10;
            this.dgvNotPaid.AllowUserToAddRows = false;
            this.dgvNotPaid.AllowUserToDeleteRows = false;
            this.dgvNotPaid.ReadOnly = true;
            this.dgvNotPaid.MultiSelect = false;
            this.dgvNotPaid.RowHeadersVisible = false;
            this.dgvNotPaid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotPaid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.dtpMonth);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblPaid);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.lblDelayed);
            this.Controls.Add(this.lblAmountPaid);
            this.Controls.Add(this.lblAmountToPay);
            this.Controls.Add(this.lblWaiting);
            this.Controls.Add(this.dgvNotPaid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monthly Report";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotPaid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPaid;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label lblDelayed;
        private System.Windows.Forms.Label lblAmountPaid;
        private System.Windows.Forms.Label lblAmountToPay;
        private System.Windows.Forms.Label lblWaiting;
        private System.Windows.Forms.DataGridView dgvNotPaid;
    }
}
