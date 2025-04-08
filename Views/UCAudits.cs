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

namespace proyectoIntegrador.Views.Administration
{
    public partial class UCAudits : UserControl
    {
        public UCAudits()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)  // txtSearch es el buscador
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadGridAudits(2); // Buscar por acción
            }
            else
            {
                LoadGridAudits(1); // Mostrar todo si el campo está vacío
            }
        }

        private void dgvAudits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadGridAudits(int modo)
        {
            dgvAudits.DataSource = null;
            dgvAudits.Rows.Clear();
            dgvAudits.Columns.Clear();

            var controller = new audit_controller();

            var autoincremento = new DataGridViewTextBoxColumn
            {
                HeaderText = "N.-",
                ReadOnly = true
            };
            dgvAudits.Columns.Add(autoincremento);

            if (modo == 1)
            {
                dgvAudits.DataSource = controller.GetAll();
            }
            else
            {
                dgvAudits.DataSource = controller.SearchByAction(txtSearch.Text.Trim());
            }

            // Cambiar encabezados para que se vean mejor
            dgvAudits.Columns["IdAuditoria"].HeaderText = "ID";
            dgvAudits.Columns["TipoAccion"].HeaderText = "ACCIÓN";
            dgvAudits.Columns["FechaHora"].HeaderText = "FECHA Y HORA";
            dgvAudits.Columns["IdUsuario"].HeaderText = "USUARIO";
            dgvAudits.Columns["Descripcion"].HeaderText = "DESCRIPCIÓN";
        }

        private void UCAudits_Load(object sender, EventArgs e)
        {
            LoadGridAudits(1); // Cargar todas las auditorías al iniciar

        }
    }
}
