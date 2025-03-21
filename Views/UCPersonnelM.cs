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
using proyectoIntegrador.Models;

namespace proyectoIntegrador.Views
{
    public partial class UCPersonnelM : UserControl
    {
        public bool editMode = false;
        public int id = 0;
        public UCPersonnelM()
        {
            InitializeComponent();
            LoadGridDpt(1);
            LoadGridPosition(1);

            pnlDpt.Enabled = false;
            pnlPosition.Enabled = false;
            pnlUser.Enabled = false;

        }
        /* Departments */
        public void LoadGridDpt(int numero)
        {
            dgvDpt.DataSource = null;
            dgvDpt.Rows.Clear();
            dgvDpt.Columns.Clear();

            var logica = new department_controller();

            var autoincremento = new DataGridViewTextBoxColumn
            {
                HeaderText = "N.-",
                ReadOnly = true
            };
            dgvDpt.Columns.Add(autoincremento);

            var btnEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "Editar",
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
                dgvDpt.DataSource = logica.GetAllDepartments();
            }
            else
            {
                dgvDpt.DataSource = logica.SearchByName(txtSearch.Text.Trim());
            }
            dgvDpt.Columns["idDepartamento"].HeaderText = "ID";
            dgvDpt.Columns["nombreDepartamento"].HeaderText = "Nombre del Departamento";
            dgvDpt.Columns["isDeleted"].HeaderText = "is deleted";
            /*
            switch (tipo)
            {
                case "departamento":
                    //idDepartamento nombreDepartamento isDeleted 
                    dgvDpt.Columns["nombreDepartamento"].HeaderText = "Nombre del Departamento";
                    dgvDpt.Columns["isDeleted"].HeaderText = "is deleted";

                    break;
                case "cargo":
                    //idDepartamento nombreDepartamento isDeleted 
                    dgvPosDpt.Columns["idDepartamento"].Visible = false;
                    dgvPosDpt.Columns["nombreDepartamento"].Visible = false;
                    dgvPosDpt.Columns["isDeleted"].Visible = false;

                    dgvPosDpt.Columns["Departamento"].HeaderText = "Nombre del Departamento";
                    dgvPosDpt.Columns["Cargo"].HeaderText = "Cargo";
                    dgvPosDpt.Columns["Salario"].HeaderText = "Salario";

                    break;

                case "empleado":
                    dgvPosDpt.Columns["Cargo"].HeaderText = "Cargo";
                    dgvPosDpt.Columns["Salario"].HeaderText = "Salario";
                    dgvPosDpt.Columns["NombreDepartamento"].HeaderText = "Departamento";
                    break;

                case "usuario":
                    dgvPosDpt.Columns["Usuario"].HeaderText = "Usuario";
                    dgvPosDpt.Columns["Rol"].HeaderText = "Rol";
                    break;
            }
            */
            dgvDpt.Columns.Add(btnEditar);
            dgvDpt.Columns.Add(btnEliminar);
        }

        private void dgvDpt_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvDpt.Rows.Count; i++)
            {
                dgvDpt.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void dgvDpt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvDpt.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var filaSeleccionada = dgvDpt.Rows[e.RowIndex];
                var id = filaSeleccionada.Cells["IdDepartamento"].Value;
                if (dgvDpt.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    EditDpt((int)id);
                }
                if (dgvDpt.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    DeleteDpt((int)id);
                }
            }
        }

        //BUSCAR DPT
        private void button2_Click(object sender, EventArgs e)
        {

        }
        //GUARDAR DPT
        private void btnSaveDpt_Click_1(object sender, EventArgs e)
        {

            if (txtDpt.Text == "")
            {
                MessageBox.Show("Por favor, complete el campo requerido");
                return;
            }

            try
            {
                var Department = new department_model()
                {
                    NombreDepartamento = txtDpt.Text
                };

                var controller = new department_controller();

                if (!this.editMode)
                {
                    var result = controller.Insert(Department);
                    if (result == "ok")
                    {
                        MessageBox.Show("Departamento guardado con éxito");
                        txtDpt.Text = ""; // Borra el campo de texto
                        pnlDpt.Enabled = false; // Desactiva el panel
                        this.editMode = false; // Resetea el modo de edición
                        this.id = 0; // Reinicia el ID
                    }
                    else
                    {
                        MessageBox.Show($"Error al guardar: {result}");
                    }
                    LoadGridDpt(1);

                }
                else
                {
                    Department.IdDepartamento = this.id;
                    var result = controller.Update(Department);
                    if (result == "ok")
                    {
                        MessageBox.Show("Departamento actualizado con éxito");
                    }
                    else
                    {
                        MessageBox.Show($"Error al actualizar: {result}");
                    }
                    LoadGridDpt(1);
                    pnlDpt.Enabled = false;
                    txtDpt.Text = ""; // Borra el campo de texto
                    this.editMode = false; // Resetea el modo de edición
                    this.id = 0; // Reinicia el ID

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }


        }
        //CANCELAR DPT
        private void btnCancelDpt_Click_1(object sender, EventArgs e)
        {
            pnlDpt.Enabled = false;
            txtDpt.Text = ""; // Borra el campo de texto
            this.editMode = false; // Resetea el modo de edición
            this.id = 0; // Reinicia el ID
        }

        private void btnAddDpt_Click_1(object sender, EventArgs e)
        {
            pnlDpt.Enabled = true;

        }

        public void EditDpt(int id)
        {
            try
            {
                var controller = new department_controller();
                var department = controller.GetById(id);
                if (department != null)
                {
                    txtDpt.Text = department.NombreDepartamento;
                    this.id = department.IdDepartamento;
                    pnlDpt.Enabled = true;
                    this.editMode = true;
                    
                }
                else
                {
                    MessageBox.Show("No se encontró el departamento.");
                }
                LoadGridDpt(1);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar el departamento: {ex.Message}");
            }
        }

        public void DeleteDpt(int id)
        {
            DialogResult cuadroDialogo = MessageBox.Show("¿Está seguro de que desea eliminar este departamento?",
                "Eliminar Departamento", MessageBoxButtons.YesNo);
            if (cuadroDialogo == DialogResult.Yes)
            {
                var Position = new department_controller();
                if (Position.Delete(id))
                {
                    MessageBox.Show("El departamento se ha eliminado con éxito.");
                    this.LoadGridDpt(1);
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


        /* POSITIONS */
        public void LoadGridPosition(int numero)
        {
            dgvPosition.DataSource = null;
            dgvPosition.Rows.Clear();
            dgvPosition.Columns.Clear();

            var logica = new position_controller();

            var autoincremento = new DataGridViewTextBoxColumn
            {
                HeaderText = "N.-",
                ReadOnly = true
            };
            dgvPosition.Columns.Add(autoincremento);

            var btnEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "Editar",
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
                dgvPosition.DataSource = logica.GetAll();
            }
            else
            {
                dgvPosition.DataSource = logica.SearchByName(txtSearch.Text.Trim());
            }

            dgvPosition.Columns["IdCargo"].HeaderText = "ID";
            dgvPosition.Columns["NombreCargo"].HeaderText = "Nombre del Cargo";
            dgvPosition.Columns["Salario"].HeaderText = "Salario";
            dgvPosition.Columns["IdDepartamento"].HeaderText = "ID Departamento";
            dgvPosition.Columns["IsDeleted"].HeaderText = "Eliminado";

            dgvPosition.Columns.Add(btnEditar);
            dgvPosition.Columns.Add(btnEliminar);
        }
        private void dgvPosition_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvPosition.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var filaSeleccionada = dgvPosition.Rows[e.RowIndex];
                var id = filaSeleccionada.Cells["IdCargo"].Value;
                if (dgvPosition.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    EditPosition((int)id);
                }
                if (dgvPosition.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    DeletePosition((int)id);
                }
            }
        }
        private void dgvPosition_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvPosition.Rows.Count; i++)
            {
                dgvPosition.Rows[i].Cells[0].Value = i + 1;
            }
        }
        public void EditPosition(int id)
        {
            try
            {
                var controller = new position_controller();
                var position = controller.GetById(id); // Obtener el cargo a editar
                loadDepartments(); // Cargar los departamentos

                if (position != null)
                {
                    txtPosition.Text = position.NombreCargo; // Rellenar el nombre del cargo
                    txtSalary.Text = position.Salario.ToString(); // Rellenar el salario

                    // Establecer el departamento en el ComboBox
                    for (int i = 0; i < cmbDpt.Items.Count; i++)
                    {
                        var department = (department_model)cmbDpt.Items[i]; // Obtener cada departamento
                        if (department.IdDepartamento == position.IdDepartamento)
                        {
                            cmbDpt.SelectedIndex = i; // Establecer el índice seleccionado
                            break;
                        }
                    }

                    this.id = position.IdCargo;
                    pnlPosition.Enabled = true;
                    this.editMode = true;

                }
                else
                {
                    MessageBox.Show("No se encontró el cargo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar el cargo: {ex.Message}");
            }


        }

        public void DeletePosition(int id)
        {
            DialogResult cuadroDialogo = MessageBox.Show("¿Está seguro de que desea eliminar este cargo?",
                "Eliminar Cargo", MessageBoxButtons.YesNo);

            if (cuadroDialogo == DialogResult.Yes)
            {
                try
                {
                    var controller = new position_controller();
                    bool result = controller.Delete(id); // Llamar al controlador para eliminar el cargo

                    if (result)
                    {
                        MessageBox.Show("El cargo se ha eliminado con éxito.");
                        LoadGridPosition(1); // Recargar la grilla de posiciones
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al eliminar el cargo.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("El usuario canceló la eliminación.");
            }
            cleanPositionFields();
        }

        private void btnCancelPosition_Click(object sender, EventArgs e)
        {
            pnlPosition.Enabled = false;
            txtPosition.Text = "";
            txtSalary.Text = "";
            cmbDpt.Text = "";
            cmbDpt.SelectedIndex = -1;
            this.editMode = false;
            this.id = 0;
        }



        private void btnAddPosition_Click(object sender, EventArgs e)
        {
            pnlPosition.Enabled = true;
            LoadGridPosition(1);
        }

        public void loadDepartments()
        {
            var listaDepartamentos = new department_controller();
            cmbDpt.DataSource = listaDepartamentos.GetAllDepartments();
            cmbDpt.ValueMember = "IdDepartamento";
            cmbDpt.DisplayMember = "NombreDepartamento";
        }

        //IdCargo NombreCargo Salario IdDepartamento IsDeleted

        private void btnSavePosition_Click(object sender, EventArgs e)
        {
            if (txtPosition.Text == "" || txtSalary.Text == "" || cmbDpt.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }

            try
            {
                var position = new position_model()
                {
                    NombreCargo = txtPosition.Text,
                    Salario = Convert.ToDecimal(txtSalary.Text),
                    IdDepartamento = Convert.ToInt32(cmbDpt.SelectedValue)
                };

                var controller = new position_controller();

                if (!this.editMode)
                {
                    var result = controller.Insert(position);
                    if (result == "ok")
                    {
                        MessageBox.Show("Cargo guardado con éxito");
                        txtPosition.Text = ""; // Borra el campo de cargo
                        txtSalary.Text = ""; // Borra el campo de salario
                        cmbDpt.SelectedIndex = -1; // Resetea la selección del combo
                        pnlPosition.Enabled = false; // Desactiva el panel
                        this.editMode = false; // Resetea el modo de edición
                        this.id = 0; // Reinicia el ID
                        LoadGridPosition(1); // Recargar la grilla

                    }
                    else
                    {
                        MessageBox.Show($"Error al guardar: {result}");
                    }
                    LoadGridDpt(1);
                }
                else
                {
                    position.IdCargo = this.id;
                    var result = controller.Update(position);
                    if (result == "ok")
                    {
                        MessageBox.Show("Cargo actualizado con éxito");
                        cleanPositionFields(); // Limpiar los campos después de la edición
                        LoadGridPosition(1); // Recargar la grilla
                    }
                    else
                    {
                        MessageBox.Show($"Error al actualizar: {result}");
                        cleanPositionFields(); // Limpiar los campos después de la edición
                        LoadGridPosition(1); // Recargar la grilla
                    }
                    LoadGridDpt(1);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }


        private void cleanPositionFields()
        {
            txtPosition.Text = "";
            txtSalary.Text = "";
            cmbDpt.SelectedIndex = -1; // Resetea el combo de departamentos
            pnlPosition.Enabled = false;
            this.editMode = false; // Resetea el modo de edición
            this.id = 0; // Reinicia el ID
        }

        /* EMPLOYEES */

        public void LoadGridEmployee(int numero)
        {
            dgvEmployee.DataSource = null;
            dgvEmployee.Rows.Clear();
            dgvEmployee.Columns.Clear();

            var logica = new employee_controller();  // Use the controller for employee

            var autoincremento = new DataGridViewTextBoxColumn
            {
                HeaderText = "N.-",
                ReadOnly = true
            };
            dgvEmployee.Columns.Add(autoincremento);

            var btnEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "Editar",
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
                dgvEmployee.DataSource = logica.GetAll(); // Assuming GetAll() gets all employees
            }
            else
            {
                dgvEmployee.DataSource = logica.SearchByName(txtSearch.Text.Trim()); // Assuming SearchByName() searches employees by name
            }

            dgvEmployee.Columns["IdEmpleado"].HeaderText = "ID";
            dgvEmployee.Columns["NombreEmpleado"].HeaderText = "Nombre del Empleado";
            dgvEmployee.Columns["Cedula"].HeaderText = "Cédula";
            dgvEmployee.Columns["FechaNacimiento"].HeaderText = "Fecha de Nacimiento";
            dgvEmployee.Columns["Telefono"].HeaderText = "Teléfono";
            dgvEmployee.Columns["FechaContratacion"].HeaderText = "Fecha de Contratación";
            dgvEmployee.Columns["IdDepartamento"].HeaderText = "ID Departamento";
            dgvEmployee.Columns["IdCargo"].HeaderText = "ID Cargo";
            dgvEmployee.Columns["IsDeleted"].HeaderText = "Eliminado";

            dgvEmployee.Columns.Add(btnEditar);
            dgvEmployee.Columns.Add(btnEliminar);
        }


        /* USERS */



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            PersonnelM.frmEmployee frmemployee = new PersonnelM.frmEmployee();
            frmemployee.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
                
        private void button7_Click(object sender, EventArgs e)
        {

        }

    }
}
