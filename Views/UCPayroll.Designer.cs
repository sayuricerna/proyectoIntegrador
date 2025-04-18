﻿namespace proyectoIntegrador.Views
{
    partial class UCPayroll
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
            this.pnlAdvanceP = new System.Windows.Forms.Panel();
            this.btnCancelAdvanceP = new System.Windows.Forms.Button();
            this.btnSaveAdvanceP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.pnlRoll = new System.Windows.Forms.Panel();
            this.dateTimePickerMonth = new System.Windows.Forms.DateTimePicker();
            this.btnCancelRoll = new System.Windows.Forms.Button();
            this.btnSaveRoll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxEmployee = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvPayroll = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnGiveAdvance = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnGenROLL = new System.Windows.Forms.Button();
            this.pnlAdvanceP.SuspendLayout();
            this.pnlRoll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAdvanceP
            // 
            this.pnlAdvanceP.BackColor = System.Drawing.Color.White;
            this.pnlAdvanceP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAdvanceP.Controls.Add(this.btnCancelAdvanceP);
            this.pnlAdvanceP.Controls.Add(this.btnSaveAdvanceP);
            this.pnlAdvanceP.Controls.Add(this.label1);
            this.pnlAdvanceP.Controls.Add(this.txtAmount);
            this.pnlAdvanceP.Controls.Add(this.txtReason);
            this.pnlAdvanceP.Controls.Add(this.label4);
            this.pnlAdvanceP.Controls.Add(this.label3);
            this.pnlAdvanceP.Controls.Add(this.cmbEmployee);
            this.pnlAdvanceP.Location = new System.Drawing.Point(19, 37);
            this.pnlAdvanceP.Name = "pnlAdvanceP";
            this.pnlAdvanceP.Size = new System.Drawing.Size(832, 286);
            this.pnlAdvanceP.TabIndex = 117;
            this.pnlAdvanceP.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // btnCancelAdvanceP
            // 
            this.btnCancelAdvanceP.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCancelAdvanceP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelAdvanceP.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelAdvanceP.Location = new System.Drawing.Point(406, 214);
            this.btnCancelAdvanceP.Name = "btnCancelAdvanceP";
            this.btnCancelAdvanceP.Size = new System.Drawing.Size(323, 51);
            this.btnCancelAdvanceP.TabIndex = 105;
            this.btnCancelAdvanceP.Text = "Cancelar";
            this.btnCancelAdvanceP.UseVisualStyleBackColor = false;
            this.btnCancelAdvanceP.Click += new System.EventHandler(this.btnCancelAdvanceP_Click);
            // 
            // btnSaveAdvanceP
            // 
            this.btnSaveAdvanceP.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSaveAdvanceP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAdvanceP.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveAdvanceP.Location = new System.Drawing.Point(67, 214);
            this.btnSaveAdvanceP.Name = "btnSaveAdvanceP";
            this.btnSaveAdvanceP.Size = new System.Drawing.Size(323, 51);
            this.btnSaveAdvanceP.TabIndex = 104;
            this.btnSaveAdvanceP.Text = "Guardar";
            this.btnSaveAdvanceP.UseVisualStyleBackColor = false;
            this.btnSaveAdvanceP.Click += new System.EventHandler(this.btnSaveDpt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(156, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 25);
            this.label1.TabIndex = 103;
            this.label1.Text = "Monto";
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(250, 62);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(397, 30);
            this.txtAmount.TabIndex = 102;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // txtReason
            // 
            this.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReason.Location = new System.Drawing.Point(250, 111);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(397, 77);
            this.txtReason.TabIndex = 101;
            this.txtReason.TextChanged += new System.EventHandler(this.txtReason_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(153, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 25);
            this.label4.TabIndex = 100;
            this.label4.Text = "Motivo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(123, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 99;
            this.label3.Text = "Empleado";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(250, 16);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(397, 33);
            this.cmbEmployee.TabIndex = 98;
            this.cmbEmployee.SelectedIndexChanged += new System.EventHandler(this.cmbEmployee_SelectedIndexChanged);
            // 
            // pnlRoll
            // 
            this.pnlRoll.BackColor = System.Drawing.Color.White;
            this.pnlRoll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRoll.Controls.Add(this.dateTimePickerMonth);
            this.pnlRoll.Controls.Add(this.btnCancelRoll);
            this.pnlRoll.Controls.Add(this.btnSaveRoll);
            this.pnlRoll.Controls.Add(this.label2);
            this.pnlRoll.Controls.Add(this.comboBoxEmployee);
            this.pnlRoll.Controls.Add(this.label5);
            this.pnlRoll.Location = new System.Drawing.Point(857, 37);
            this.pnlRoll.Name = "pnlRoll";
            this.pnlRoll.Size = new System.Drawing.Size(751, 286);
            this.pnlRoll.TabIndex = 118;
            // 
            // dateTimePickerMonth
            // 
            this.dateTimePickerMonth.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerMonth.CustomFormat = "MM/yyyy";
            this.dateTimePickerMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMonth.Location = new System.Drawing.Point(307, 54);
            this.dateTimePickerMonth.Name = "dateTimePickerMonth";
            this.dateTimePickerMonth.ShowUpDown = true;
            this.dateTimePickerMonth.Size = new System.Drawing.Size(303, 30);
            this.dateTimePickerMonth.TabIndex = 104;
            // 
            // btnCancelRoll
            // 
            this.btnCancelRoll.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCancelRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelRoll.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelRoll.Location = new System.Drawing.Point(391, 214);
            this.btnCancelRoll.Name = "btnCancelRoll";
            this.btnCancelRoll.Size = new System.Drawing.Size(323, 51);
            this.btnCancelRoll.TabIndex = 103;
            this.btnCancelRoll.Text = "Cancelar";
            this.btnCancelRoll.UseVisualStyleBackColor = false;
            this.btnCancelRoll.Click += new System.EventHandler(this.btnCancelRoll_Click);
            // 
            // btnSaveRoll
            // 
            this.btnSaveRoll.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSaveRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveRoll.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveRoll.Location = new System.Drawing.Point(52, 214);
            this.btnSaveRoll.Name = "btnSaveRoll";
            this.btnSaveRoll.Size = new System.Drawing.Size(323, 51);
            this.btnSaveRoll.TabIndex = 102;
            this.btnSaveRoll.Text = "Guardar";
            this.btnSaveRoll.UseVisualStyleBackColor = false;
            this.btnSaveRoll.Click += new System.EventHandler(this.btnSaveRoll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(189, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 100;
            this.label2.Text = "Empleado";
            // 
            // comboBoxEmployee
            // 
            this.comboBoxEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEmployee.FormattingEnabled = true;
            this.comboBoxEmployee.Location = new System.Drawing.Point(307, 108);
            this.comboBoxEmployee.Name = "comboBoxEmployee";
            this.comboBoxEmployee.Size = new System.Drawing.Size(303, 33);
            this.comboBoxEmployee.TabIndex = 99;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(173, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 25);
            this.label5.TabIndex = 98;
            this.label5.Text = "Mes y Año";
            // 
            // dgvPayroll
            // 
            this.dgvPayroll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayroll.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPayroll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayroll.Location = new System.Drawing.Point(19, 385);
            this.dgvPayroll.Name = "dgvPayroll";
            this.dgvPayroll.RowHeadersWidth = 51;
            this.dgvPayroll.RowTemplate.Height = 24;
            this.dgvPayroll.Size = new System.Drawing.Size(1589, 519);
            this.dgvPayroll.TabIndex = 119;
            this.dgvPayroll.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPayroll_CellContentClick);
            this.dgvPayroll.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPayroll_DataBindingComplete);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Location = new System.Drawing.Point(901, 329);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(245, 50);
            this.btnSearch.TabIndex = 121;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnGiveAdvance
            // 
            this.btnGiveAdvance.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGiveAdvance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiveAdvance.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGiveAdvance.Location = new System.Drawing.Point(1143, 329);
            this.btnGiveAdvance.Name = "btnGiveAdvance";
            this.btnGiveAdvance.Size = new System.Drawing.Size(231, 50);
            this.btnGiveAdvance.TabIndex = 122;
            this.btnGiveAdvance.Text = "Dar Anticipo";
            this.btnGiveAdvance.UseVisualStyleBackColor = false;
            this.btnGiveAdvance.Click += new System.EventHandler(this.btnGiveAdvance_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::proyectoIntegrador.Properties.Resources.search_icon;
            this.pictureBox4.Location = new System.Drawing.Point(18, 322);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(60, 55);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 123;
            this.pictureBox4.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(84, 334);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(811, 38);
            this.txtSearch.TabIndex = 120;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // btnGenROLL
            // 
            this.btnGenROLL.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGenROLL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenROLL.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGenROLL.Location = new System.Drawing.Point(1377, 329);
            this.btnGenROLL.Name = "btnGenROLL";
            this.btnGenROLL.Size = new System.Drawing.Size(231, 50);
            this.btnGenROLL.TabIndex = 124;
            this.btnGenROLL.Text = "Generar Rol";
            this.btnGenROLL.UseVisualStyleBackColor = false;
            this.btnGenROLL.Click += new System.EventHandler(this.btnGenROLL_Click);
            // 
            // UCPayroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGenROLL);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnGiveAdvance);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvPayroll);
            this.Controls.Add(this.pnlRoll);
            this.Controls.Add(this.pnlAdvanceP);
            this.Name = "UCPayroll";
            this.Size = new System.Drawing.Size(1641, 923);
            this.Load += new System.EventHandler(this.UCPayroll_Load);
            this.pnlAdvanceP.ResumeLayout(false);
            this.pnlAdvanceP.PerformLayout();
            this.pnlRoll.ResumeLayout(false);
            this.pnlRoll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlAdvanceP;
        private System.Windows.Forms.Panel pnlRoll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxEmployee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvPayroll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnGiveAdvance;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnGenROLL;
        private System.Windows.Forms.Button btnCancelAdvanceP;
        private System.Windows.Forms.Button btnSaveAdvanceP;
        private System.Windows.Forms.Button btnCancelRoll;
        private System.Windows.Forms.Button btnSaveRoll;
        private System.Windows.Forms.DateTimePicker dateTimePickerMonth;
    }
}
