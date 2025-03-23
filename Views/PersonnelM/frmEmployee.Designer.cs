namespace proyectoIntegrador.Views.PersonnelM
{
    partial class frmEmployee
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbDpt = new System.Windows.Forms.ComboBox();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpContract = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.btnRegistrarHuella = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFrm = new System.Windows.Forms.Label();
            this.btnFingerPrint = new System.Windows.Forms.Button();
            this.Arduino = new System.IO.Ports.SerialPort(this.components);
            this.txtFPCheck = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(643, 99);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 171);
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(441, 579);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(341, 63);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbDpt
            // 
            this.cmbDpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDpt.FormattingEnabled = true;
            this.cmbDpt.Location = new System.Drawing.Point(268, 420);
            this.cmbDpt.Name = "cmbDpt";
            this.cmbDpt.Size = new System.Drawing.Size(342, 33);
            this.cmbDpt.TabIndex = 46;
            // 
            // cmbPosition
            // 
            this.cmbPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(268, 471);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(342, 33);
            this.cmbPosition.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(164, 475);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 25);
            this.label10.TabIndex = 44;
            this.label10.Text = "Cargo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(95, 423);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 25);
            this.label9.TabIndex = 43;
            this.label9.Text = "Departamento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 377);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(210, 25);
            this.label7.TabIndex = 42;
            this.label7.Text = "Fecha de Contratacion";
            // 
            // dtpContract
            // 
            this.dtpContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpContract.Location = new System.Drawing.Point(268, 372);
            this.dtpContract.Name = "dtpContract";
            this.dtpContract.Size = new System.Drawing.Size(342, 30);
            this.dtpContract.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(141, 322);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 25);
            this.label8.TabIndex = 40;
            this.label8.Text = "Telefono";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(268, 322);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(342, 30);
            this.txtPhone.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(137, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 25);
            this.label6.TabIndex = 38;
            this.label6.Text = "Direccion";
            // 
            // txtAdress
            // 
            this.txtAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdress.Location = new System.Drawing.Point(268, 251);
            this.txtAdress.Multiline = true;
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(342, 51);
            this.txtAdress.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 25);
            this.label5.TabIndex = 36;
            this.label5.Text = "Fecha de Nacimiento";
            // 
            // dtpBirth
            // 
            this.dtpBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBirth.Location = new System.Drawing.Point(268, 207);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(342, 30);
            this.dtpBirth.TabIndex = 35;
            // 
            // btnRegistrarHuella
            // 
            this.btnRegistrarHuella.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarHuella.Location = new System.Drawing.Point(643, 276);
            this.btnRegistrarHuella.Name = "btnRegistrarHuella";
            this.btnRegistrarHuella.Size = new System.Drawing.Size(181, 38);
            this.btnRegistrarHuella.TabIndex = 34;
            this.btnRegistrarHuella.Text = "Subir Foto";
            this.btnRegistrarHuella.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(155, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 31;
            this.label2.Text = "Cedula";
            // 
            // txtCedula
            // 
            this.txtCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.Location = new System.Drawing.Point(268, 116);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(342, 30);
            this.txtCedula.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 25);
            this.label3.TabIndex = 29;
            this.label3.Text = "Nombre y Apellido";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(268, 157);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(342, 30);
            this.txtName.TabIndex = 28;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(94, 579);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(341, 63);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFrm
            // 
            this.lblFrm.AutoSize = true;
            this.lblFrm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrm.Location = new System.Drawing.Point(396, 24);
            this.lblFrm.Name = "lblFrm";
            this.lblFrm.Size = new System.Drawing.Size(79, 29);
            this.lblFrm.TabIndex = 49;
            this.lblFrm.Text = "label1";
            // 
            // btnFingerPrint
            // 
            this.btnFingerPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFingerPrint.Location = new System.Drawing.Point(643, 377);
            this.btnFingerPrint.Name = "btnFingerPrint";
            this.btnFingerPrint.Size = new System.Drawing.Size(181, 38);
            this.btnFingerPrint.TabIndex = 52;
            this.btnFingerPrint.Text = "Registrar Huella";
            this.btnFingerPrint.UseVisualStyleBackColor = true;
            this.btnFingerPrint.Click += new System.EventHandler(this.btnFingerPrint_Click);
            // 
            // Arduino
            // 
            this.Arduino.PortName = "COM3";
            this.Arduino.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Arduino_DataReceived);
            // 
            // txtFPCheck
            // 
            this.txtFPCheck.Enabled = false;
            this.txtFPCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFPCheck.Location = new System.Drawing.Point(643, 341);
            this.txtFPCheck.Name = "txtFPCheck";
            this.txtFPCheck.Size = new System.Drawing.Size(181, 30);
            this.txtFPCheck.TabIndex = 53;
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 680);
            this.Controls.Add(this.txtFPCheck);
            this.Controls.Add(this.btnFingerPrint);
            this.Controls.Add(this.lblFrm);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbDpt);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpContract);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAdress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpBirth);
            this.Controls.Add(this.btnRegistrarHuella);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSave);
            this.Name = "frmEmployee";
            this.Text = "frmEmployee";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEmployee_FormClosing);
            this.Load += new System.EventHandler(this.frmEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbDpt;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpContract;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAdress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.Button btnRegistrarHuella;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFrm;
        private System.Windows.Forms.Button btnFingerPrint;
        private System.IO.Ports.SerialPort Arduino;
        private System.Windows.Forms.TextBox txtFPCheck;
    }
}