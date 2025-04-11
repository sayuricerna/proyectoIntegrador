namespace proyectoIntegrador.Views
{
    partial class UCReport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbSelectedReport = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenReport = new System.Windows.Forms.Button();
            this.ReportV_Lista_Datos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbSelectedReport);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnGenReport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1629, 124);
            this.panel2.TabIndex = 108;
            // 
            // cmbSelectedReport
            // 
            this.cmbSelectedReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSelectedReport.FormattingEnabled = true;
            this.cmbSelectedReport.Location = new System.Drawing.Point(282, 54);
            this.cmbSelectedReport.Name = "cmbSelectedReport";
            this.cmbSelectedReport.Size = new System.Drawing.Size(828, 33);
            this.cmbSelectedReport.TabIndex = 103;
            this.cmbSelectedReport.SelectedIndexChanged += new System.EventHandler(this.cmbSelectedReport_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(277, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 102;
            this.label1.Text = "Reporte a Generar";
            // 
            // btnGenReport
            // 
            this.btnGenReport.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGenReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenReport.Location = new System.Drawing.Point(1116, 44);
            this.btnGenReport.Name = "btnGenReport";
            this.btnGenReport.Size = new System.Drawing.Size(231, 51);
            this.btnGenReport.TabIndex = 122;
            this.btnGenReport.Text = "Generar Reporte";
            this.btnGenReport.UseVisualStyleBackColor = false;
            this.btnGenReport.Click += new System.EventHandler(this.btnGenReport_Click);
            // 
            // ReportV_Lista_Datos
            // 
            this.ReportV_Lista_Datos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportV_Lista_Datos.LocalReport.ReportEmbeddedResource = "proyectoIntegrador.Views.Reports.Report.rdlc";
            this.ReportV_Lista_Datos.Location = new System.Drawing.Point(282, 124);
            this.ReportV_Lista_Datos.Name = "ReportV_Lista_Datos";
            this.ReportV_Lista_Datos.ServerReport.BearerToken = null;
            this.ReportV_Lista_Datos.Size = new System.Drawing.Size(1065, 641);
            this.ReportV_Lista_Datos.TabIndex = 125;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 124);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(282, 641);
            this.flowLayoutPanel1.TabIndex = 127;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1347, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 641);
            this.panel1.TabIndex = 128;
            // 
            // UCReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ReportV_Lista_Datos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Name = "UCReport";
            this.Size = new System.Drawing.Size(1629, 765);
            this.Load += new System.EventHandler(this.UCReport_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbSelectedReport;
        private System.Windows.Forms.Label label1;
        public Microsoft.Reporting.WinForms.ReportViewer ReportV_Lista_Datos;
        private System.Windows.Forms.Button btnGenReport;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}
