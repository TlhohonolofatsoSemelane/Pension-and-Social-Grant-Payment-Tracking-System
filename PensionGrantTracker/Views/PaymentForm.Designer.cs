namespace PensionGrantTracker.Views
{
    partial class PaymentForm
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
            this.lblFilter = new System.Windows.Forms.Label();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnCreateMonth = new System.Windows.Forms.Button();
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.lblPaidDate = new System.Windows.Forms.Label();
            this.dtpPaidDate = new System.Windows.Forms.DateTimePicker();
            this.btnMarkPaid = new System.Windows.Forms.Button();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnMarkDelayed = new System.Windows.Forms.Button();
            this.btnMarkPending = new System.Windows.Forms.Button();
            this.btnDeletePayment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
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
            this.lblFilter.Location = new System.Drawing.Point(210, 23);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(50, 15);
            this.lblFilter.TabIndex = 2;
            this.lblFilter.AutoSize = true;
            this.lblFilter.Text = "Status";
            this.cboFilter.Location = new System.Drawing.Point(260, 20);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(120, 23);
            this.cboFilter.TabIndex = 3;
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Items.AddRange(new object[] { "All", "Pending", "Paid", "Delayed" });
            this.btnShow.Location = new System.Drawing.Point(400, 18);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(90, 28);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            this.btnCreateMonth.Location = new System.Drawing.Point(500, 18);
            this.btnCreateMonth.Name = "btnCreateMonth";
            this.btnCreateMonth.Size = new System.Drawing.Size(230, 28);
            this.btnCreateMonth.TabIndex = 5;
            this.btnCreateMonth.Text = "Create Payments for Month";
            this.btnCreateMonth.UseVisualStyleBackColor = true;
            this.btnCreateMonth.Click += new System.EventHandler(this.btnCreateMonth_Click);
            this.dgvPayments.Location = new System.Drawing.Point(20, 60);
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.Size = new System.Drawing.Size(860, 330);
            this.dgvPayments.TabIndex = 6;
            this.dgvPayments.AllowUserToAddRows = false;
            this.dgvPayments.AllowUserToDeleteRows = false;
            this.dgvPayments.ReadOnly = true;
            this.dgvPayments.MultiSelect = false;
            this.dgvPayments.RowHeadersVisible = false;
            this.dgvPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPayments_CellClick);
            this.lblPaidDate.Location = new System.Drawing.Point(20, 417);
            this.lblPaidDate.Name = "lblPaidDate";
            this.lblPaidDate.Size = new System.Drawing.Size(70, 15);
            this.lblPaidDate.TabIndex = 7;
            this.lblPaidDate.AutoSize = true;
            this.lblPaidDate.Text = "Paid date";
            this.dtpPaidDate.Location = new System.Drawing.Point(100, 414);
            this.dtpPaidDate.Name = "dtpPaidDate";
            this.dtpPaidDate.Size = new System.Drawing.Size(130, 23);
            this.dtpPaidDate.TabIndex = 8;
            this.dtpPaidDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.btnMarkPaid.Location = new System.Drawing.Point(245, 412);
            this.btnMarkPaid.Name = "btnMarkPaid";
            this.btnMarkPaid.Size = new System.Drawing.Size(110, 28);
            this.btnMarkPaid.TabIndex = 9;
            this.btnMarkPaid.Text = "Mark as Paid";
            this.btnMarkPaid.UseVisualStyleBackColor = true;
            this.btnMarkPaid.Click += new System.EventHandler(this.btnMarkPaid_Click);
            this.lblReason.Location = new System.Drawing.Point(380, 417);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(50, 15);
            this.lblReason.TabIndex = 10;
            this.lblReason.AutoSize = true;
            this.lblReason.Text = "Reason";
            this.txtReason.Location = new System.Drawing.Point(440, 414);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(240, 23);
            this.txtReason.TabIndex = 11;
            this.btnMarkDelayed.Location = new System.Drawing.Point(690, 412);
            this.btnMarkDelayed.Name = "btnMarkDelayed";
            this.btnMarkDelayed.Size = new System.Drawing.Size(110, 28);
            this.btnMarkDelayed.TabIndex = 12;
            this.btnMarkDelayed.Text = "Mark Delayed";
            this.btnMarkDelayed.UseVisualStyleBackColor = true;
            this.btnMarkDelayed.Click += new System.EventHandler(this.btnMarkDelayed_Click);
            this.btnMarkPending.Location = new System.Drawing.Point(20, 455);
            this.btnMarkPending.Name = "btnMarkPending";
            this.btnMarkPending.Size = new System.Drawing.Size(150, 28);
            this.btnMarkPending.TabIndex = 13;
            this.btnMarkPending.Text = "Change to Pending";
            this.btnMarkPending.UseVisualStyleBackColor = true;
            this.btnMarkPending.Click += new System.EventHandler(this.btnMarkPending_Click);
            this.btnDeletePayment.Location = new System.Drawing.Point(180, 455);
            this.btnDeletePayment.Name = "btnDeletePayment";
            this.btnDeletePayment.Size = new System.Drawing.Size(130, 28);
            this.btnDeletePayment.TabIndex = 14;
            this.btnDeletePayment.Text = "Delete Payment";
            this.btnDeletePayment.UseVisualStyleBackColor = true;
            this.btnDeletePayment.Click += new System.EventHandler(this.btnDeletePayment_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.dtpMonth);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cboFilter);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnCreateMonth);
            this.Controls.Add(this.dgvPayments);
            this.Controls.Add(this.lblPaidDate);
            this.Controls.Add(this.dtpPaidDate);
            this.Controls.Add(this.btnMarkPaid);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.btnMarkDelayed);
            this.Controls.Add(this.btnMarkPending);
            this.Controls.Add(this.btnDeletePayment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monthly Payments";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnCreateMonth;
        private System.Windows.Forms.DataGridView dgvPayments;
        private System.Windows.Forms.Label lblPaidDate;
        private System.Windows.Forms.DateTimePicker dtpPaidDate;
        private System.Windows.Forms.Button btnMarkPaid;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnMarkDelayed;
        private System.Windows.Forms.Button btnMarkPending;
        private System.Windows.Forms.Button btnDeletePayment;
    }
}
