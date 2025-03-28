using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using proyectoIntegrador.Controllers;
using proyectoIntegrador.Models;
using proyectoIntegrador.Helpers;
using ZstdSharp.Unsafe;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using MySqlX.XDevAPI.Common;

namespace proyectoIntegrador.Views.PersonnelM
{
    public partial class frmEmployee : Form
    {
        public bool modoEdision = false;
        public int id = 0;
        public frmEmployee(string modo)
        {
            InitializeComponent();

            if (modo != "n")
            {
                this.modoEdision = true;
                this.id = int.Parse(modo);
            }
        }
        public void loadDpt()
        {
            var list = new department_controller();
            cmbDpt.DataSource = list.GetAllDepartments();
            cmbDpt.ValueMember = "IdDepartamento";
            cmbDpt.DisplayMember = "NombreDepartamento";
        }
        public void loadPosition()
        {
            var list = new position_controller();
            cmbPosition.DataSource = list.GetAll();
            cmbPosition.ValueMember = "IdCargo";
            //cmbDpt.DisplayMember = "NombreDepartamento";

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtCedula.Text == "" || cmbDpt.SelectedIndex == -1 || cmbPosition.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }

            try
            {
                var employee = new employee_model()
                {
                    //Idempleado foto huella cedula nombreempleado fechanacimiento direccion telefono fechacontratacion iddepartamento idcargo 
                    NombreEmpleado = txtName.Text,
                    Cedula = txtCedula.Text,
                    Telefono = txtPhone.Text,
                    Direccion = txtAdress.Text,
                    FechaNacimiento = dtpBirth.Value,
                    FechaContratacion = dtpContract.Value,
                    IdDepartamento = Convert.ToInt32(cmbDpt.SelectedValue),
                    IdCargo = Convert.ToInt32(cmbPosition.SelectedValue),
                };


                var controller = new employee_controller();

                if (!this.modoEdision)
                {
                    var result = controller.Insert(employee);
                    Console.WriteLine(employee.IdEmpleado);

                    if (result == "ok")
                    {
                        this.Close();
                        MessageBox.Show("empleado guardada con éxito.");
                    }
                    else
                    {
                        MessageBox.Show($"Error al guardar: {result}");
                    }
                }
                else
                {
                    employee.IdEmpleado = this.id;
                    var result = controller.Update(employee);


                    if (result == "ok")
                    {
                        MessageBox.Show("empleado actualizada con éxito.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Error al actualizar: {result}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }

            
        }

        // Método para cargar el grid (si tienes uno para mostrar los empleados)
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            loadDpt();
            loadPosition();

            if (!this.modoEdision)
            {
                lblFrm.Text = "Ingreso Nuevo Empleado";
            }
            else
            {
                lblFrm.Text = "Actualización de Empleado";

                // Cargar datos del empleado cuando estamos en modo de edición
                var employeeController = new employee_controller();
                var employee = employeeController.GetById(this.id); // Método GetById para obtener el empleado por su ID

                if (employee != null)
                {
                    txtName.Text = employee.NombreEmpleado;
                    txtCedula.Text = employee.Cedula;
                    txtPhone.Text = employee.Telefono;
                    txtAdress.Text = employee.Direccion;
                    dtpBirth.Value = employee.FechaNacimiento;
                    dtpContract.Value = employee.FechaContratacion;
                    cmbDpt.SelectedValue = employee.IdDepartamento;
                    cmbPosition.SelectedValue = employee.IdCargo;
                }
                else
                {
                    MessageBox.Show("Empleado no encontrado");
                }
            }
        }

        /* HUELLA **/
        //boton para registrar huella dactila hay un imagebox patr huella en caso sea necesario
        private void btnFingerPrint_Click(object sender, EventArgs e )
        {
            //0 127
            //FingerprintHelper.RegisterFP(6);
            Console.WriteLine("Hellow world");
        }

        private void frmEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        
    }
}