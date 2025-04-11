using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using proyectoIntegrador.Config;
using proyectoIntegrador.Helpers;

namespace proyectoIntegrador.Views.Reports
{
    internal class ReportClass
    {

        public static void Lista_personal(UCReport F_Reporte_Lista)
        {
            try
            {
                connection conn = new connection();
                using (MySqlConnection conectarBD = conn.GetConnection())
                {
                    conectarBD.Open(); 

                    string consulta = "SELECT * FROM vista_empleados_activos";
                    MySqlDataAdapter da = new MySqlDataAdapter(consulta, conectarBD);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    ReportDataSource reporte = new ReportDataSource("DataSet1", ds.Tables[0]);
                    F_Reporte_Lista.ReportV_Lista_Datos.LocalReport.DataSources.Clear();
                    F_Reporte_Lista.ReportV_Lista_Datos.LocalReport.DataSources.Add(reporte);
                    F_Reporte_Lista.ReportV_Lista_Datos.LocalReport.ReportEmbeddedResource = "proyectoIntegrador.Views.Reports.Report.rdlc";
                    // ⬇️ Agregamos los dos parámetros
                    ReportParameter[] parametros = new ReportParameter[]
                    {
                        new ReportParameter("pNombreUsuario", Session.NombreUsuario),
                        new ReportParameter("pNombreEmpleado", Session.NombreEmpleado)
                    };
                    F_Reporte_Lista.ReportV_Lista_Datos.LocalReport.SetParameters(parametros);



                    F_Reporte_Lista.ReportV_Lista_Datos.LocalReport.Refresh();
                    F_Reporte_Lista.ReportV_Lista_Datos.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Lista_asistencia(UCReport F_Reporte)
        {
            try
            {
                connection conn = new connection();
                using (MySqlConnection conectarBD = conn.GetConnection())
                {
                    conectarBD.Open();

                    string consulta = "SELECT * FROM vista_asistencia_diaria";
                    MySqlDataAdapter da = new MySqlDataAdapter(consulta, conectarBD);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    ReportDataSource reporte = new ReportDataSource("DataSet2", ds.Tables[0]);
                    F_Reporte.ReportV_Lista_Datos.LocalReport.DataSources.Clear();
                    F_Reporte.ReportV_Lista_Datos.LocalReport.DataSources.Add(reporte);
                    F_Reporte.ReportV_Lista_Datos.LocalReport.ReportEmbeddedResource = "proyectoIntegrador.Views.Reports.Report1.rdlc";
                    // ⬇️ Agregamos los dos parámetros
                    ReportParameter[] parametros = new ReportParameter[]
                    {
                        new ReportParameter("pNombreUsuario", Session.NombreUsuario),
                        new ReportParameter("pNombreEmpleado", Session.NombreEmpleado)
                    };
                    F_Reporte.ReportV_Lista_Datos.LocalReport.SetParameters(parametros);



                    F_Reporte.ReportV_Lista_Datos.LocalReport.Refresh();
                    F_Reporte.ReportV_Lista_Datos.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}