namespace proyectoIntegrador.Views.Attendance
{
    partial class frmJustification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJustification));
            this.label4 = new System.Windows.Forms.Label();
            this.cmbReason = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEndDte = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(112, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Motivo";
            // 
            // cmbReason
            // 
            this.cmbReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReason.FormattingEnabled = true;
            this.cmbReason.Items.AddRange(new object[] {
            "Vacaciones",
            "Enfermedad"});
            this.cmbReason.Location = new System.Drawing.Point(197, 219);
            this.cmbReason.Name = "cmbReason";
            this.cmbReason.Size = new System.Drawing.Size(366, 33);
            this.cmbReason.TabIndex = 14;
            this.cmbReason.SelectedIndexChanged += new System.EventHandler(this.cmbReason_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(87, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Empleado";
            // 
            // dtpEndDte
            // 
            this.dtpEndDte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDte.Location = new System.Drawing.Point(197, 107);
            this.dtpEndDte.Name = "dtpEndDte";
            this.dtpEndDte.Size = new System.Drawing.Size(366, 30);
            this.dtpEndDte.TabIndex = 12;
            this.dtpEndDte.ValueChanged += new System.EventHandler(this.dtpEndDte_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Fecha Final";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(197, 168);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(366, 33);
            this.cmbEmployee.TabIndex = 10;
            this.cmbEmployee.SelectedIndexChanged += new System.EventHandler(this.cmbEmployee_SelectedIndexChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Location = new System.Drawing.Point(197, 53);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(366, 30);
            this.dtpStartDate.TabIndex = 9;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Fecha Inicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(103, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Dettalle";
            // 
            // txtDetail
            // 
            this.txtDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetail.Location = new System.Drawing.Point(197, 285);
            this.txtDetail.MaxLength = 100;
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(366, 72);
            this.txtDetail.TabIndex = 17;
            this.txtDetail.TextChanged += new System.EventHandler(this.txtDetail_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(326, 399);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(296, 62);
            this.btnCancel.TabIndex = 49;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(24, 399);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(296, 62);
            this.btnSave.TabIndex = 48;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmJustification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(651, 522);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbReason);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpEndDte);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmJustification";
            this.Text = "Justificación";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbReason;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpEndDte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}