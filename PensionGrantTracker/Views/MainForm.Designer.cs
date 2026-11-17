namespace PensionGrantTracker.Views
{
    partial class MainForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnPayPoints = new System.Windows.Forms.Button();
            this.btnBeneficiaries = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.lblTitle.Location = new System.Drawing.Point(60, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(360, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Text = "Pension and Social Grant\nPayment Tracking System";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblUser.Location = new System.Drawing.Point(140, 85);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(200, 15);
            this.lblUser.TabIndex = 1;
            this.lblUser.AutoSize = true;
            this.lblUser.Text = "Signed in as:";
            this.btnPayPoints.Location = new System.Drawing.Point(140, 120);
            this.btnPayPoints.Name = "btnPayPoints";
            this.btnPayPoints.Size = new System.Drawing.Size(200, 40);
            this.btnPayPoints.TabIndex = 2;
            this.btnPayPoints.Text = "Pay Points";
            this.btnPayPoints.UseVisualStyleBackColor = true;
            this.btnPayPoints.Click += new System.EventHandler(this.btnPayPoints_Click);
            this.btnBeneficiaries.Location = new System.Drawing.Point(140, 170);
            this.btnBeneficiaries.Name = "btnBeneficiaries";
            this.btnBeneficiaries.Size = new System.Drawing.Size(200, 40);
            this.btnBeneficiaries.TabIndex = 3;
            this.btnBeneficiaries.Text = "Beneficiaries";
            this.btnBeneficiaries.UseVisualStyleBackColor = true;
            this.btnBeneficiaries.Click += new System.EventHandler(this.btnBeneficiaries_Click);
            this.btnPayments.Location = new System.Drawing.Point(140, 220);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(200, 40);
            this.btnPayments.TabIndex = 4;
            this.btnPayments.Text = "Monthly Payments";
            this.btnPayments.UseVisualStyleBackColor = true;
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            this.btnReports.Location = new System.Drawing.Point(140, 270);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(200, 40);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            this.btnChangePassword.Location = new System.Drawing.Point(140, 320);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(200, 40);
            this.btnChangePassword.TabIndex = 6;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            this.btnLogout.Location = new System.Drawing.Point(140, 370);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 40);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 440);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnPayPoints);
            this.Controls.Add(this.btnBeneficiaries);
            this.Controls.Add(this.btnPayments);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pension and Social Grant Payment Tracking System";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnPayPoints;
        private System.Windows.Forms.Button btnBeneficiaries;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnLogout;
    }
}
