using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectoIntegrador.Views.Reports;

namespace proyectoIntegrador.Views
{
    public partial class UCReport : UserControl
    {
        public UCReport()
        {
            InitializeComponent();
        }

        private void btnGenReport_Click(object sender, EventArgs e)
        {
            cmbSelectedReport_SelectedIndexChanged(null, null);

        }

        private void btbSearchReport_Click(object sender, EventArgs e)
        {

        }

        private void cmbSelectedReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcionSeleccionada = cmbSelectedReport.SelectedItem.ToString();

            switch (opcionSeleccionada)
            {
                case "Reporte de Empleados":
                    ReportClass.Lista_personal(this);
                    break;

                case "Reporte de Sueldos Mensuales":
                    ReportClass.Lista_sueldos(this); // Este sería otro método similar en tu ReportClass
                    break;

                case "Reporte de Asistencias":
                    ReportClass.Lista_asistencia(this); 
                    break;

                default:
                    MessageBox.Show("Seleccione un reporte válido.");
                    break;
            }
        }

        private void UCReport_Load(object sender, EventArgs e)
        {
            cmbSelectedReport.Items.Clear();
            cmbSelectedReport.Items.Add("Reporte de Empleados");
            cmbSelectedReport.Items.Add("Reporte de Sueldos Mensuales");
            cmbSelectedReport.Items.Add("Reporte de Asistencias");
            cmbSelectedReport.SelectedIndex = 0;
        }
    }
}
