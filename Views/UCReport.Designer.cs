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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ReportV_Lista_Datos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnGenReport = new System.Windows.Forms.Button();
            this.btbSearchReport = new System.Windows.Forms.Button();
            this.dataSet1 = new proyectoIntegrador.DataSet1();
            this.vistaempleadosactivosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaempleadosactivosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btbSearchReport);
            this.panel2.Controls.Add(this.btnGenReport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1629, 130);
            this.panel2.TabIndex = 108;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(8, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(550, 33);
            this.comboBox1.TabIndex = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 102;
            this.label1.Text = "Reporte a Generar";
            // 
            // ReportV_Lista_Datos
            // 
            this.ReportV_Lista_Datos.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.vistaempleadosactivosBindingSource;
            this.ReportV_Lista_Datos.LocalReport.DataSources.Add(reportDataSource1);
            this.ReportV_Lista_Datos.LocalReport.ReportEmbeddedResource = "proyectoIntegrador.Views.Reports.Report.rdlc";
            this.ReportV_Lista_Datos.Location = new System.Drawing.Point(0, 130);
            this.ReportV_Lista_Datos.Name = "ReportV_Lista_Datos";
            this.ReportV_Lista_Datos.ServerReport.BearerToken = null;
            this.ReportV_Lista_Datos.Size = new System.Drawing.Size(1629, 635);
            this.ReportV_Lista_Datos.TabIndex = 125;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(287, 75);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1054, 38);
            this.textBox2.TabIndex = 124;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::proyectoIntegrador.Properties.Resources.search_icon;
            this.pictureBox3.Location = new System.Drawing.Point(222, 65);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(60, 55);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 123;
            this.pictureBox3.TabStop = false;
            // 
            // btnGenReport
            // 
            this.btnGenReport.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGenReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenReport.Location = new System.Drawing.Point(564, 18);
            this.btnGenReport.Name = "btnGenReport";
            this.btnGenReport.Size = new System.Drawing.Size(231, 51);
            this.btnGenReport.TabIndex = 122;
            this.btnGenReport.Text = "Generar Reporte";
            this.btnGenReport.UseVisualStyleBackColor = false;
            this.btnGenReport.Click += new System.EventHandler(this.btnGenReport_Click);
            // 
            // btbSearchReport
            // 
            this.btbSearchReport.BackColor = System.Drawing.Color.SeaGreen;
            this.btbSearchReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbSearchReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btbSearchReport.Location = new System.Drawing.Point(1347, 70);
            this.btbSearchReport.Name = "btbSearchReport";
            this.btbSearchReport.Size = new System.Drawing.Size(231, 50);
            this.btbSearchReport.TabIndex = 121;
            this.btbSearchReport.Text = "Buscar";
            this.btbSearchReport.UseVisualStyleBackColor = false;
            this.btbSearchReport.Click += new System.EventHandler(this.btbSearchReport_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vistaempleadosactivosBindingSource
            // 
            this.vistaempleadosactivosBindingSource.DataMember = "vista_empleados_activos";
            this.vistaempleadosactivosBindingSource.DataSource = this.dataSet1;
            // 
            // UCReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ReportV_Lista_Datos);
            this.Controls.Add(this.panel2);
            this.Name = "UCReport";
            this.Size = new System.Drawing.Size(1629, 765);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaempleadosactivosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        public Microsoft.Reporting.WinForms.ReportViewer ReportV_Lista_Datos;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnGenReport;
        private System.Windows.Forms.Button btbSearchReport;
        private System.Windows.Forms.BindingSource vistaempleadosactivosBindingSource;
        private DataSet1 dataSet1;
    }
}
