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

namespace proyectoIntegrador.Views
{
    public partial class UCPersonnelM : UserControl
    {
        public UCPersonnelM()
        {
            InitializeComponent();
            LoadGrid(1, "departamento");
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

        public void LoadGrid(int numero, string tipo)
        {
            dgvPosDpt.DataSource = null;
            dgvPosDpt.Rows.Clear();
            dgvPosDpt.Columns.Clear();

            var logicaDepartamento = new department_controller();

            var autoincremento = new DataGridViewTextBoxColumn
            {
                HeaderText = "N.-",
                ReadOnly = true
            };
            dgvPosDpt.Columns.Add(autoincremento);

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
                dgvPosDpt.DataSource = logicaDepartamento.GetAll();
            }
            else
            {
                dgvPosDpt.DataSource = logicaDepartamento.SearchByName(txtSearch.Text.Trim());
            }

            switch (tipo)
            {
                case "departamento":
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

            dgvPosDpt.Columns.Add(btnEditar);
            dgvPosDpt.Columns.Add(btnEliminar);
        }

    }
}
