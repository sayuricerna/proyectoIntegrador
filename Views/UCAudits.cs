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
            if (modo == 1)
            {
                dgvAudits.DataSource = controller.GetAll();
            }
            else
            {
                dgvAudits.DataSource = controller.SearchByAction(txtSearch.Text.Trim());
            }

            // idAuditoria tablaAfectada tipoAccion descripcion fechaHora usuarioResponsable rolUsuario

            dgvAudits.Columns["IdAuditoria"].HeaderText = "Id";
            dgvAudits.Columns["tablaAfectada"].HeaderText = "Tabla";
            dgvAudits.Columns["tipoAccion"].HeaderText = "Accion";
            dgvAudits.Columns["fechaHora"].HeaderText = "Fecha";
            dgvAudits.Columns["descripcion"].HeaderText = "Descripción";
            dgvAudits.Columns["usuarioResponsable"].HeaderText = "Usuario";
            dgvAudits.Columns["rolUsuario"].HeaderText = "Rol";
            dgvAudits.ColumnHeadersDefaultCellStyle.Font = new Font(dgvAudits.Font, FontStyle.Bold);
            dgvAudits.Columns["IdAuditoria"].Width = 40;
            dgvAudits.Columns["IdUsuario"].Visible = false;


        }

        private void UCAudits_Load(object sender, EventArgs e)
        {
            LoadGridAudits(1); // Cargar todas las auditorías al iniciar

        }
    }
}
