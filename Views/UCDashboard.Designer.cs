namespace proyectoIntegrador.Views
{
    partial class UCDashboard
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listBoxHolidays = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHoliday = new System.Windows.Forms.TextBox();
            this.dtpHoliday = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dataSet4 = new proyectoIntegrador.DataSet4();
            this.vwsueldospagadosmensualBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBoxAdvanced = new System.Windows.Forms.ListBox();
            this.btnDeleteAd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwsueldospagadosmensualBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.SeaGreen;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(376, 631);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(257, 56);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.SeaGreen;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.Location = new System.Drawing.Point(642, 631);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(257, 56);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Actualizar";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAdd.Location = new System.Drawing.Point(905, 631);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(257, 56);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listBoxHolidays
            // 
            this.listBoxHolidays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxHolidays.FormattingEnabled = true;
            this.listBoxHolidays.ItemHeight = 25;
            this.listBoxHolidays.Location = new System.Drawing.Point(376, 421);
            this.listBoxHolidays.Name = "listBoxHolidays";
            this.listBoxHolidays.Size = new System.Drawing.Size(786, 204);
            this.listBoxHolidays.TabIndex = 7;
            this.listBoxHolidays.SelectedIndexChanged += new System.EventHandler(this.listBoxHolidays_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(371, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nombre y Fecha de la Festividad";
            // 
            // txtHoliday
            // 
            this.txtHoliday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoliday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoliday.Location = new System.Drawing.Point(376, 385);
            this.txtHoliday.Name = "txtHoliday";
            this.txtHoliday.Size = new System.Drawing.Size(453, 30);
            this.txtHoliday.TabIndex = 9;
            // 
            // dtpHoliday
            // 
            this.dtpHoliday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoliday.Location = new System.Drawing.Point(835, 385);
            this.dtpHoliday.Name = "dtpHoliday";
            this.dtpHoliday.Size = new System.Drawing.Size(327, 30);
            this.dtpHoliday.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 773);
            this.panel1.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1336, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(262, 773);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // dataSet4
            // 
            this.dataSet4.DataSetName = "DataSet4";
            this.dataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vwsueldospagadosmensualBindingSource
            // 
            this.vwsueldospagadosmensualBindingSource.DataMember = "vw_sueldos_pagados_mensual";
            this.vwsueldospagadosmensualBindingSource.DataSource = this.dataSet4;
            // 
            // listBoxAdvanced
            // 
            this.listBoxAdvanced.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAdvanced.FormattingEnabled = true;
            this.listBoxAdvanced.ItemHeight = 25;
            this.listBoxAdvanced.Location = new System.Drawing.Point(376, 93);
            this.listBoxAdvanced.Name = "listBoxAdvanced";
            this.listBoxAdvanced.Size = new System.Drawing.Size(786, 204);
            this.listBoxAdvanced.TabIndex = 16;
            // 
            // btnDeleteAd
            // 
            this.btnDeleteAd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnDeleteAd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAd.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDeleteAd.Location = new System.Drawing.Point(905, 303);
            this.btnDeleteAd.Name = "btnDeleteAd";
            this.btnDeleteAd.Size = new System.Drawing.Size(257, 56);
            this.btnDeleteAd.TabIndex = 13;
            this.btnDeleteAd.Text = "Eliminar";
            this.btnDeleteAd.UseVisualStyleBackColor = false;
            this.btnDeleteAd.Click += new System.EventHandler(this.btnDeleteAd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(371, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(297, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Seleccionar que anticipo eliminar";
            // 
            // UCDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.listBoxHolidays);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listBoxAdvanced);
            this.Controls.Add(this.btnDeleteAd);
            this.Controls.Add(this.dtpHoliday);
            this.Controls.Add(this.txtHoliday);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UCDashboard";
            this.Size = new System.Drawing.Size(1598, 773);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwsueldospagadosmensualBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox listBoxHolidays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHoliday;
        private System.Windows.Forms.DateTimePicker dtpHoliday;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.BindingSource vwsueldospagadosmensualBindingSource;
        private DataSet4 dataSet4;
        private System.Windows.Forms.ListBox listBoxAdvanced;
        private System.Windows.Forms.Button btnDeleteAd;
        private System.Windows.Forms.Label label3;
    }
}
