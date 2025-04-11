using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using proyectoIntegrador.Config;
using System.Data;
using proyectoIntegrador.Helpers;

namespace proyectoIntegrador.Views.Payroll
{
     class PayrollClass
    {
        public static void showPayrollforPrint(frmPrintPayroll F_Reporte_Lista, int idRol)
        {
            try
            {
                connection conn = new connection();
                using (MySqlConnection conectarBD = conn.GetConnection())
                {
                    conectarBD.Open();
                    string consulta = "CALL sp_obtenerRolPagoCompletoPorId(@idRol)";
                    MySqlCommand cmd = new MySqlCommand(consulta, conectarBD);
                    cmd.Parameters.AddWithValue("@idRol", idRol);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    ReportDataSource reporte = new ReportDataSource("PayrollForPrint", ds.Tables[0]);
                    F_Reporte_Lista.reportViewerPayroll.LocalReport.DataSources.Clear();
                    F_Reporte_Lista.reportViewerPayroll.LocalReport.DataSources.Add(reporte);
                    F_Reporte_Lista.reportViewerPayroll.LocalReport.ReportEmbeddedResource = "proyectoIntegrador.Views.Payroll.ReportPayroll.rdlc";
                    // ⬇️ Agregamos los dos parámetros
                    ReportParameter[] parametros = new ReportParameter[]
                    {
                        new ReportParameter("pNombreUsuario", Session.NombreUsuario),
                        new ReportParameter("pNombreEmpleado", Session.NombreEmpleado)
                    };
                    F_Reporte_Lista.reportViewerPayroll.LocalReport.SetParameters(parametros);



                    F_Reporte_Lista.reportViewerPayroll.LocalReport.Refresh();
                    F_Reporte_Lista.reportViewerPayroll.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
