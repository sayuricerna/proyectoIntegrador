using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using proyectoIntegrador.Config;
using proyectoIntegrador.Controllers;
using proyectoIntegrador.Models;

namespace proyectoIntegrador.Views
{
    public partial class UCPayroll : UserControl
    {
        private readonly connection _connection = new connection();
        private readonly employee_controller _employeeController = new employee_controller();

        public UCPayroll()
        {
            InitializeComponent();
            pnlAdvanceP.Enabled = false;
            pnlRoll.Enabled = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Payroll.frmAdvanceP frmAdvanceP = new Payroll.frmAdvanceP();
            //frmAdvanceP.ShowDialog();
        }

        private void UCPayroll_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            LoadGridPayrolls(1); // ▶️ Cambia de 2 a 1 para cargar todos los registros no eliminados
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        //Button save advance
        private void btnSaveDpt_Click(object sender, EventArgs e)
        {

        }

        private void btnGiveAdvance_Click(object sender, EventArgs e)
        {
            pnlAdvanceP.Enabled = true;

        }

        private void btnGenROLL_Click(object sender, EventArgs e)
        {
            pnlRoll.Enabled = true;
        }

        private void btnCancelAdvanceP_Click(object sender, EventArgs e)
        {
            pnlAdvanceP.Enabled = false;

        }

        public void LoadEmployees()
        {
            comboBoxEmployee.DataSource = _employeeController.GetAll();
            comboBoxEmployee.DisplayMember = "NombreEmpleado";
            comboBoxEmployee.ValueMember = "IdEmpleado";
            cmbEmployee.DataSource = _employeeController.GetAll();
            cmbEmployee.DisplayMember = "NombreEmpleado";
            cmbEmployee.ValueMember = "IdEmpleado";
        }
        public int GenerarNumeroRol()
        {
            try
            {
                using (var conn = _connection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT IFNULL(MAX(numRol), 0) + 1 FROM rolpago";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar número de rol: " + ex.Message);
                return 1;
            }
        }

        // generar el rol 
        private void btnSaveRoll_Click(object sender, EventArgs e)

        {
            var controller = new payroll_controller();

            try
            {
                // 🟢 Obtener solo el mes y año con día 1
                DateTime fechaSeleccionada = new DateTime(
                    dateTimePickerMonth.Value.Year,
                    dateTimePickerMonth.Value.Month,1
                );

                if (comboBoxEmployee.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un empleado.");
                    return;
                }

                int employeeId = Convert.ToInt32(comboBoxEmployee.SelectedValue);
                int numRol = GenerarNumeroRol(); // Usa el número incremental

                // 🟢 Llama al controlador pasando la fecha con día 1
                string mensaje = controller.GeneratePayroll(fechaSeleccionada, employeeId, numRol);
                MessageBox.Show(mensaje, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleanRollFields();
                LoadGridPayrolls(1); // Actualiza el grid

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
            
        }

        private void btnCancelRoll_Click(object sender, EventArgs e)
        {
            pnlRoll.Enabled = false;
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerMonth_ValueChanged(object sender, EventArgs e)
        {

        }
        public void cleanRollFields()
        {
            dateTimePickerMonth.Text="";
            comboBoxEmployee.SelectedIndex = -1;
            pnlRoll.Enabled = false;
        }
        public void cleanAdvancePFields()
        {
            txtAmount.Text = "";
            txtReason.Text = "";
            cmbEmployee.SelectedIndex = -1;
        }

        //public void LoadGridPayrolls(int numero)
        //{
        //    dgvPayroll.DataSource = null;
        //    dgvPayroll.Rows.Clear();
        //    dgvPayroll.Columns.Clear();

        //    var logica = new payroll_controller();
        //    var payrollList = (numero == 1) ? logica.GetAll() : logica.Search(txtSearch.Text.Trim());

        //    var autoincremento = new DataGridViewTextBoxColumn
        //    {
        //        HeaderText = "N.-",
        //        ReadOnly = true
        //    };
        //    dgvPayroll.Columns.Add(autoincremento);

        //    var btnEliminar = new DataGridViewButtonColumn
        //    {
        //        HeaderText = "Eliminar",
        //        Text = "Eliminar",
        //        UseColumnTextForButtonValue = true
        //    };

        //    dgvPayroll.DataSource = payrollList;

        //    dgvPayroll.Columns["IdRol"].HeaderText = "ID Rol";
        //    dgvPayroll.Columns["NumRol"].HeaderText = "Número de Rol";
        //    dgvPayroll.Columns["Mes"].HeaderText = "Mes";
        //    dgvPayroll.Columns["Anio"].HeaderText = "Año";
        //    dgvPayroll.Columns["FechaEmision"].HeaderText = "Fecha de Emisión";
        //    dgvPayroll.Columns["IdEmpleado"].HeaderText = "ID Empleado";
        //    dgvPayroll.Columns["Sueldo"].HeaderText = "Sueldo";
        //    // Agregar más columnas según sea necesario

        //    dgvPayroll.Columns.Add(btnEliminar);
        //}


        public void LoadGridPayrolls(int numero)
        {
            dgvPayroll.DataSource = null;
            dgvPayroll.Rows.Clear();
            dgvPayroll.Columns.Clear();

            var logica = new payroll_controller();  // Use the controller for employee

            var autoincremento = new DataGridViewTextBoxColumn
            {
                HeaderText = "N.-",
                ReadOnly = true
            };
            dgvPayroll.Columns.Add(autoincremento);


            var btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };

            // Obtener datos según el tipo solicitado
            if (numero == 1)
            {
                dgvPayroll.DataSource = logica.GetAll(); // Assuming GetAll() gets all employees
            }
            else
            {
                dgvPayroll.DataSource = logica.Search(txtSearch.Text.Trim()); // Assuming SearchByName() searches employees by name
            }

            dgvPayroll.Columns["IdRol"].HeaderText = "ID";
            dgvPayroll.Columns["NumRol"].HeaderText = "NumRolo";
            dgvPayroll.Columns["Mes"].HeaderText = "Mes";
            dgvPayroll.Columns["Anio"].HeaderText = "Anio";
            dgvPayroll.Columns["FechaEmision"].HeaderText = "FechaEmision";


            dgvPayroll.Columns.Add(btnEliminar);
            dgvPayroll.Refresh();


        }
        public void dgvPayroll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvPayroll.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var filaSeleccionada = dgvPayroll.Rows[e.RowIndex];
                var id = filaSeleccionada.Cells["IdRol"].Value;

                if (dgvPayroll.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    Delete((int)id);
                }
            }
        }

        public void Delete(int id)
        {
            DialogResult cuadroDialogo = MessageBox.Show("¿Está seguro de que desea eliminar eeste rol?",
                            "Eliminar ", MessageBoxButtons.YesNo);
            if (cuadroDialogo == DialogResult.Yes)
            {
                var rol = new payroll_controller();
                if (rol.Delete(id))
                {
                    MessageBox.Show("El departamento se ha eliminado con éxito.");
                    this.LoadGridPayrolls(1);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al eliminar.");
                }
            }
            else
            {
                MessageBox.Show("El usuario canceló la eliminación.");
            }
        }

        private void dgvPayroll_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
    }
}
