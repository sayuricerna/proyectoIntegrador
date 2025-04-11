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
using proyectoIntegrador.Helpers;
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

            pnlDpt.Enabled = false;
            pnlPosition.Enabled = false;
            pnlUser.Enabled = false;

        }
        private void UCPersonnelM_Load(object sender, EventArgs e)
        {
            LoadGridDpt(1);
            LoadGridPosition(1);
            LoadGridUsers(1);

            var logic = new employee_controller();
            dgvEmployee.DataSource = "";
            dgvEmployee.DataSource = logic.GetAll();
            this.LoadGridEmployee(1);
        }

        /********************************************************** DEPARTMENT **********************************************************/

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

            if (numero == 1)
            {
                dgvDpt.DataSource = logica.GetAllDepartments();
            }
            else
            {
                dgvDpt.DataSource = logica.SearchByName(txtSearchDpt.Text.Trim());
            }
            dgvDpt.Columns["idDepartamento"].HeaderText = "ID";
            dgvDpt.Columns["nombreDepartamento"].HeaderText = "Departamento";
            dgvDpt.Columns["numeroCargos"].HeaderText = "# Cargos";
            dgvDpt.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDpt.Font, FontStyle.Bold);

            autoincremento.Width = 40;

            dgvDpt.Columns["idDepartamento"].Width = 65;
            dgvDpt.Columns["isDeleted"].Visible = false;
            dgvDpt.Columns["numeroCargos"].Width = 140;
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
        
        //Search Department
        private void button2_Click(object sender, EventArgs e)
        {
            LoadGridDpt(2);
        }
        //Save Department
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
        
        //Button Cancel DPT
        private void btnCancelDpt_Click_1(object sender, EventArgs e)
        {
            pnlDpt.Enabled = false;
            txtDpt.Text = "";
            this.editMode = false;
            this.id = 0;
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


        /********************************************************** POSITION **********************************************************/
        public void LoadGridPosition(int numero)
        {
            loadDepartments();
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
                dgvPosition.DataSource = logica.SearchByName(txtSearchPos.Text.Trim());
            }

            dgvPosition.Columns["IdCargo"].Visible = false;
            dgvPosition.Columns["IdDepartamento"].Visible = false;
            dgvPosition.Columns["NombreDepartamento"].HeaderText = "Departamento";
            dgvPosition.Columns["Salario"].HeaderText = "Salario";
            dgvPosition.Columns["NombreCargo"].HeaderText = "Cargo";
            dgvPosition.Columns["IsDeleted"].Visible = false;
            dgvPosition.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDpt.Font, FontStyle.Bold);

            autoincremento.Width = 50;

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


        /********************************************************** EMPLOYEE **********************************************************/
        private void button5_Click(object sender, EventArgs e)
        {
            PersonnelM.frmEmployee frm = new PersonnelM.frmEmployee("n");
            frm.Text = "Formulario de Empleado";
            frm.ShowDialog();
        }

        public void EditEmployee(int id)
        {
            PersonnelM.frmEmployee frm = new PersonnelM.frmEmployee(id.ToString());
            frm.ShowDialog();
            this.LoadGridEmployee(1);
        }
        public void DeleteEmployee(int id)
        {
            DialogResult cuadroDialogo = MessageBox.Show("¿Está seguro de que desea eliminar esta inscripción?",
                "Eliminar Inscripción", MessageBoxButtons.YesNo);
            if (cuadroDialogo == DialogResult.Yes)
            {
                var employee = new employee_controller();
                if (employee.Delete(id))
                {
                    MessageBox.Show("El empleado se ha eliminado con éxito.");
                    this.LoadGridEmployee(1);
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
        public void LoadGridEmployee(int numero)
        {
            dgvEmployee.DataSource = null;
            dgvEmployee.Rows.Clear();
            dgvEmployee.Columns.Clear();
            loadEmployees();

            var logica = new employee_controller();

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

            if (numero == 1)
            {
                dgvEmployee.DataSource = logica.GetAll();
            }
            else
            {
                dgvEmployee.DataSource = logica.SearchByName(txtSearchEmployee.Text.Trim());
            }
            dgvEmployee.Columns["NombreEmpleado"].HeaderText = "Empleado";
            dgvEmployee.Columns["Cedula"].HeaderText = "Cédula";
            dgvEmployee.Columns["Direccion"].HeaderText = "Dirección";
            dgvEmployee.Columns["huellaRegistrada"].HeaderText = "Huella";
            dgvEmployee.Columns["FechaNacimiento"].HeaderText = "Nacimiento";
            dgvEmployee.Columns["Telefono"].HeaderText = "Teléfono";
            dgvEmployee.Columns["FechaContratacion"].HeaderText = "Contratación";
            dgvEmployee.Columns["nombreDepartamento"].HeaderText = "Departamento";
            dgvEmployee.Columns["nombreCargo"].HeaderText = "Cargo";
            dgvEmployee.Columns["foto"].Visible = false;
            dgvEmployee.Columns["IdEmpleado"].Visible = false;
            dgvEmployee.Columns["Huella"].Visible = false;
            dgvEmployee.Columns["IdDepartamento"].Visible = false;
            dgvEmployee.Columns["IdCargo"].Visible = false;
            dgvEmployee.Columns["IsDeleted"].Visible = false;

            dgvEmployee.ColumnHeadersDefaultCellStyle.Font = new Font(dgvEmployee.Font, FontStyle.Bold);
            dgvEmployee.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            autoincremento.Width = 30;

            dgvEmployee.Columns["HuellaRegistrada"].Width = 60;
            dgvEmployee.Columns["Estado"].Width = 60;

            dgvEmployee.Columns.Add(btnEditar);
            dgvEmployee.Columns.Add(btnEliminar);
        }


        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvEmployee.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var filaSeleccionada = dgvEmployee.Rows[e.RowIndex];
                var id = filaSeleccionada.Cells["IdEmpleado"].Value;
                if (dgvEmployee.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    EditEmployee((int)id);
                }
                if (dgvEmployee.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    DeleteEmployee((int)id);
                }
            }
        }
        private void dgvEmployee_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvEmployee.Rows.Count; i++)
            {
                dgvEmployee.Rows[i].Cells[0].Value = i + 1;
            }
        }

        /********************************************************** USER **********************************************************/

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvUser.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var filaSeleccionada = dgvUser.Rows[e.RowIndex];
                var id = filaSeleccionada.Cells["IdUsuario"].Value;
                if (dgvUser.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    EditUser((int)id);
                }
                if (dgvUser.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    DeleteUser((int)id);
                }
            }
        }
        private void dgvUser_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvUser.Rows.Count; i++)
            {
                dgvUser.Rows[i].Cells[0].Value = i + 1;
            }
        }
        public void LoadGridUsers(int numero)
        {
            dgvUser.DataSource = null;
            dgvUser.Rows.Clear();
            dgvUser.Columns.Clear();

            var logica = new user_controler();

            var autoincremento = new DataGridViewTextBoxColumn
            {
                HeaderText = "N.-",
                ReadOnly = true
            };
            dgvUser.Columns.Add(autoincremento);

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

            if (numero == 1)
            {
                dgvUser.DataSource = logica.GetAll();
            }
            else
            {
                dgvUser.DataSource = logica.SearchByName(txtSearchUser.Text.Trim());
            }

            dgvUser.Columns["IdUsuario"].Visible = false;
            dgvUser.Columns["NombreUsuario"].HeaderText = "Usuario";
            dgvUser.Columns["Contrasenia"].Visible = false;
            dgvUser.Columns["NombreEmpleado"].HeaderText = "Empleado";
            dgvUser.Columns["EstadoString"].HeaderText = "Estado";

            dgvUser.Columns["RolUsuario"].HeaderText = "Rol";
            dgvUser.Columns["Estado"].Visible = false;
            dgvUser.Columns["IsDeleted"].Visible = false;
            dgvUser.Columns["IdEmpleado"].Visible = false;
            dgvUser.ColumnHeadersDefaultCellStyle.Font = new Font(dgvUser.Font, FontStyle.Bold);
            dgvUser.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            autoincremento.Width = 30;
            dgvUser.Columns.Add(btnEditar);
            dgvUser.Columns.Add(btnEliminar);
        }
        public void EditUser(int id)
        {
            try
            {
                var controller = new user_controler();
                var user = controller.GetById(id);
                loadEmployees();
                if (user != null)
                {
                    txtUserName.Text = user.NombreUsuario;
                    txtPassword.Text = "*****"; //NO SE PUEDE MOSTRAR LA CONTRASENIA
                    cmbRole.SelectedItem = user.RolUsuario;
                    chkActive.Checked = user.Estado;
                    this.id = user.IdUsuario;
                    pnlUser.Enabled = true;
                    this.editMode = true;
                }
                else
                {
                    MessageBox.Show("No se encontró el usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar el usuario: {ex.Message}");
            }
        }
        public void DeleteUser(int id)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este usuario?", "Eliminar Usuario", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var controller = new user_controler();
                    bool deleted = controller.Delete(id);

                    if (deleted)
                    {
                        MessageBox.Show("Usuario eliminado con éxito.");
                        LoadGridUsers(1);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al eliminar el usuario.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}");
                }
            }
        }
        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "" || cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            try
            {                
                encryptP encrypt = new encryptP();

                string hashedPassword = encrypt.HashPassword(txtPassword.Text); // Genera el hash

                var user = new user_model()
                {
                    NombreUsuario = txtUserName.Text,
                    Contrasenia = hashedPassword, // <- Aquí va el HASH, no el texto plano
                    RolUsuario = cmbRole.SelectedItem.ToString(),
                    IdEmpleado = (int)cmbEmployee.SelectedValue,
                    Estado = chkActive.Checked
                };

                var controller = new user_controler();

                if (!this.editMode)
                {
                    var result = controller.Insert(user);
                    if (result == "ok")
                    {
                        MessageBox.Show("Usuario guardado con éxito");
                        ClearUserFields();
                        LoadGridUsers(1);
                    }
                    else
                    {
                        MessageBox.Show($"Error al guardar: {result}");
                    }
                }
                else
                {
                    user.IdUsuario = this.id;

                    if (!string.IsNullOrWhiteSpace(txtPassword.Text) && txtPassword.Text != "*****")
                    {
                        user.Contrasenia = encrypt.HashPassword(txtPassword.Text); // Nueva contraseña
                    }
                    else
                    {
                        user.Contrasenia = controller.GetById(user.IdUsuario).Contrasenia; // Mantener anterior
                    }

                    var result = controller.Update(user);
                    if (result == "ok")
                    {
                        MessageBox.Show("Usuario actualizado con éxito");
                        ClearUserFields();
                        LoadGridUsers(1);
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
        private void ClearUserFields()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            cmbRole.SelectedIndex = -1;
            chkActive.Checked = false;
            pnlUser.Enabled = false;
            this.editMode = false;
            this.id = 0;
        }
        //add
        private void button7_Click(object sender, EventArgs e)
        {
            pnlUser.Enabled = true;
            LoadGridUsers(1);

        }
        //search 
        private void button14_Click(object sender, EventArgs e)
        {
            LoadGridUsers(2);

        }
        //cancel
        private void btnCancelUser_Click(object sender, EventArgs e)
        {
            ClearUserFields();
            pnlUser.Enabled = false;
            LoadGridUsers(1);
        }

        public void loadEmployees()
        {
            var list = new employee_controller();
            cmbEmployee.DataSource = list.GetAll();
            cmbEmployee.ValueMember = "IdEmpleado";   // Aquí asegúrate que este sea el nombre correcto del campo
            cmbEmployee.DisplayMember = "nombreEmpleado";  // Aquí pon el nombre correcto que quieras mostrar
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

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



        private void button1_Click(object sender, EventArgs e)
        {
            LoadGridEmployee(1);
        }

        private void pnlUser_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            PersonnelM.frmEmployee frm = new PersonnelM.frmEmployee("n");
            frm.Text = "Formulario de Empleado";
            frm.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            this.LoadGridEmployee(2);

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.LoadGridEmployee(2);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGridPosition(2);
        }

        private void txtSearchDpt_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.LoadGridDpt(2);

        }

        private void txtSearchPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            LoadGridPosition(2);

        }

        private void txtSearchUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            LoadGridUsers(2);

        }
    }
}