using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectoIntegrador.Controllers;

namespace proyectoIntegrador.Views.Attendance
{
    public partial class frmJustification : Form
    {
        private readonly justification_controller _controller = new justification_controller();
        private readonly employee_controller _employeeController = new employee_controller();
        public frmJustification()
        {
            InitializeComponent();
            LoadEmployees(); // Cargar empleados al iniciar
            ConfigureComboBoxes();
        }
        private void LoadEmployees()
        {
            // Asume que tienes un método GetActiveEmployees en tu controlador
            cmbEmployee.DataSource = _employeeController.GetAll();
            cmbEmployee.DisplayMember = "NombreEmpleado";
            cmbEmployee.ValueMember = "IdEmpleado";
        }
        private void ConfigureComboBoxes()
        {
            // Configurar motivo como ENUM
            cmbReason.Items.AddRange(new[] { "Vacaciones", "Salud", "Otro" });
            cmbReason.SelectedIndex = 0;
        }
        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpEndDte_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbReason_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDetail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un empleado");
                return;
            }

            // Obtener valores
            int employeeId = (int)cmbEmployee.SelectedValue;
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDte.Value.Date;
            string reason = cmbReason.SelectedItem.ToString();
            string detail = txtDetail.Text.Trim();

            // Ejecutar
            string result = _controller.JustifyAttendance(
                startDate,
                endDate,
                employeeId,
                reason,
                detail
            );

            MessageBox.Show(result);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
