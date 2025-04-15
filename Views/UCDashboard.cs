using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using proyectoIntegrador.Config;
using proyectoIntegrador.Controllers;
using proyectoIntegrador.Models;

namespace proyectoIntegrador.Views
{
    public partial class UCDashboard : UserControl
    {
        private holiday_controller controller = new holiday_controller();
        private advancep_controller controllerAd = new advancep_controller();
        private List<holiday_model> feriados = new List<holiday_model>();
        private List<advancep_model> anticipos = new List<advancep_model>();

        private readonly connection _connection = new connection();

        public UCDashboard()
        {
            InitializeComponent();
            CargarFeriados();
            CargarAnticipos();
        }

        private void CargarAnticipos()
        {
            anticipos = controllerAd.getAll();
            listBoxAdvanced.Items.Clear();
            foreach (var a in anticipos) 
            {
                listBoxAdvanced.Items.Add($"{a.NombreEmpleado}({a.Fecha:dd/MM/yyyy}) - {a.Monto} - {a.Motivo}");
            }
        }
        private void CargarFeriados()
        {
            feriados = controller.getAll();
            listBoxHolidays.Items.Clear();
            foreach (var f in feriados)
            {
                listBoxHolidays.Items.Add($"{f.IdFeriado} - {f.NombreFeriado} ({f.FechaFeriado:dd/MM/yyyy})");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxHolidays.SelectedIndex >= 0)
            {
                var feriado = feriados[listBoxHolidays.SelectedIndex];
                var confirm = MessageBox.Show($"¿Eliminar '{feriado.NombreFeriado}'?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    controller.deleteHoliday(feriado.IdFeriado);
                    CargarFeriados();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listBoxHolidays.SelectedIndex >= 0)
            {
                var feriado = feriados[listBoxHolidays.SelectedIndex];
                string nuevoNombre = txtHoliday.Text.Trim();
                DateTime nuevaFecha = dtpHoliday.Value;

                if (!string.IsNullOrEmpty(nuevoNombre))
                {
                    controller.updateHoliday(feriado.IdFeriado, nuevoNombre, nuevaFecha);
                    CargarFeriados();
                    txtHoliday.Clear();
                }
                else
                {
                    MessageBox.Show("El nombre del feriado no puede estar vacío.");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string nombre = txtHoliday.Text.Trim();
            DateTime fecha = dtpHoliday.Value;
            if (!string.IsNullOrEmpty(nombre))
            {
                controller.addHoliday(nombre, fecha);
                CargarFeriados();
                txtHoliday.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa datos.");
            }            
        }

        private void listBoxHolidays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxHolidays.SelectedItem != null)
            {
                string item = listBoxHolidays.SelectedItem.ToString();
                string[] partes = item.Split('-');
                string nombre = partes[1].Split('(')[0].Trim();
                string fecha = partes[1].Split('(')[1].Replace(")", "").Trim();

                txtHoliday.Text = nombre;
                dtpHoliday.Value = DateTime.ParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }

        private void btnDeleteAd_Click(object sender, EventArgs e)
        {
            if (listBoxAdvanced.SelectedIndex >= 0)
            {
                var anticipo = anticipos[listBoxAdvanced.SelectedIndex];
                var confirm = MessageBox.Show($"¿Eliminar '{anticipo.NombreEmpleado}'?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    controllerAd.deleteAdvance(anticipo.IdAnticipo);
                    CargarAnticipos(); // Esta es la función correcta para recargar los anticipos
                }
            }
        }

    }
}
