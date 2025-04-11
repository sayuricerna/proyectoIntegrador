namespace proyectoIntegrador.Views.Payroll
{
    partial class frmPrintPayroll
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewerPayroll = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerPayroll
            // 
            this.reportViewerPayroll.Location = new System.Drawing.Point(23, 58);
            this.reportViewerPayroll.Name = "reportViewerPayroll";
            this.reportViewerPayroll.ServerReport.BearerToken = null;
            this.reportViewerPayroll.Size = new System.Drawing.Size(878, 603);
            this.reportViewerPayroll.TabIndex = 0;
            // 
            // frmPrintPayroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 684);
            this.Controls.Add(this.reportViewerPayroll);
            this.Name = "frmPrintPayroll";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmPrintPayroll_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewerPayroll;
    }
}