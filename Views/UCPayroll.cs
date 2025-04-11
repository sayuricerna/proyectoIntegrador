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
using proyectoIntegrador.Views.Payroll;

namespace proyectoIntegrador.Views
{
    public partial class UCPayroll : UserControl
    {
        private readonly connection _connection = new connection();
        private readonly employee_controller _employeeController = new employee_controller();
        private readonly advancep_controller _anticipoController = new advancep_controller();
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
            try
            {
                // Validar que se haya seleccionado un empleado
                if (cmbEmployee.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un empleado.");
                    return;
                }

                int idEmpleado = Convert.ToInt32(cmbEmployee.SelectedValue);
                // Validar y convertir el monto
                if (!decimal.TryParse(txtAmount.Text.Trim(), out decimal monto))
                {
                    MessageBox.Show("Ingrese un monto válido.");
                    return;
                }
                string motivo = txtReason.Text.Trim();
                if (string.IsNullOrEmpty(motivo))
                {
                    MessageBox.Show("Ingrese el motivo del anticipo.");
                    return;
                }

                // Llamar al método del controlador para crear el anticipo
                string mensaje = _anticipoController.CrearAnticipo(idEmpleado, monto, motivo);
                MessageBox.Show(mensaje, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos después de guardar
                cleanAdvancePFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
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
            pnlAdvanceP.Enabled = false;
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
            var btnImprimir = new DataGridViewButtonColumn
            {
                HeaderText = "Imprimir",
                Text = "Imprimir",
                UseColumnTextForButtonValue = true
            };

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

            dgvPayroll.Columns["IdRol"].Visible = false;
            dgvPayroll.Columns["IdEmpleado"].Visible = false;
            dgvPayroll.Columns["Cedula"].Visible = false;
            dgvPayroll.Columns["NombreDepartamento"].Visible = false;

            dgvPayroll.Columns["NumRol"].HeaderText = "#Rol";
            dgvPayroll.Columns["Mes"].HeaderText = "Mes";
            dgvPayroll.Columns["Anio"].HeaderText = "Anio";
            dgvPayroll.Columns["NombreEmpleado"].HeaderText = "Empleado";
            dgvPayroll.Columns["FechaEmision"].HeaderText = "Emisión";
            dgvPayroll.Columns["HorasSuplementarias"].HeaderText = "H.S";
            dgvPayroll.Columns["HorasExtras"].HeaderText = "H.E";
            dgvPayroll.Columns["DecimotercerSueldo"].HeaderText = "13.º";
            dgvPayroll.Columns["DecimocuartoSueldo"].HeaderText = "14.º";
            dgvPayroll.Columns["FondoReserva"].HeaderText = "Fondo.R";
            dgvPayroll.Columns["AporteIess"].HeaderText = "IESS";
            dgvPayroll.Columns["Anticipos"].HeaderText = "Anticipo";
            dgvPayroll.Columns["OtrosDescuentos"].HeaderText = "Falta";
            dgvPayroll.Columns["DescuentoTardanzas"].HeaderText = "Tardanza";
            dgvPayroll.Columns["TotalEgresos"].HeaderText = "Egresos";
            dgvPayroll.Columns["TotalIngresos"].HeaderText = "Ingresos";
            dgvPayroll.Columns["NetoPagar"].HeaderText = "Neto a Pagar";
            dgvPayroll.Columns["NombreCargo"].HeaderText = "Cargo";

            dgvPayroll.Columns["DecimotercerSueldo"].Width = 40;
            dgvPayroll.Columns["DecimocuartoSueldo"].Width = 40;
            dgvPayroll.Columns["AporteIess"].Width = 40;
            dgvPayroll.Columns["NumRol"].Width = 40;
            dgvPayroll.Columns["Mes"].Width = 40;
            dgvPayroll.Columns["Anio"].Width = 40;
            dgvPayroll.Columns["HorasSuplementarias"].Width = 40;
            dgvPayroll.Columns["HorasExtras"].Width = 40;

            dgvPayroll.ColumnHeadersDefaultCellStyle.Font = new Font(dgvPayroll.Font, FontStyle.Bold);
            dgvPayroll.Columns.Add(btnEliminar);
            dgvPayroll.Columns.Add(btnImprimir);

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
            if (dgvPayroll.Columns[e.ColumnIndex].HeaderText == "Imprimir")
            {
                var filaSeleccionada = dgvPayroll.Rows[e.RowIndex];
                int idRol = (int)filaSeleccionada.Cells["IdRol"].Value;
                frmPrintPayroll imprimirRol = new frmPrintPayroll(idRol);
                imprimirRol.ShowDialog();
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
            for (int i = 0; i < dgvPayroll.Rows.Count; i++)
            {
                dgvPayroll.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            LoadGridPayrolls(2);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGridPayrolls(2);

        }
    }
}
