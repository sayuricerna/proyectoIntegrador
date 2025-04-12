using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using proyectoIntegrador.Config;
using proyectoIntegrador.Helpers;
using proyectoIntegrador.Models;
using proyectoIntegrador.Views;

namespace proyectoIntegrador.Controllers
{
    class payroll_controller
    {
        private readonly connection _connection = new connection();


        public string GeneratePayroll(DateTime selectedDate, int employeeId, int numRol)
        {
            try
            {
                using (var conn = _connection.GetConnection())
                {
                    conn.Open();

                    // Ejecutar el procedimiento almacenado
                    using (var cmd = new MySqlCommand("generar_rol_pago_completo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Obtener mes y año de la fecha seleccionada
                        string mes = selectedDate.Month.ToString("D2"); // Asegura formato '01', '02', etc.  
                        int anio = selectedDate.Year;

                        // Parámetros del SP
                        cmd.Parameters.AddWithValue("@p_numRol", numRol);
                        cmd.Parameters.AddWithValue("@p_idEmpleado", employeeId);
                        cmd.Parameters.AddWithValue("@p_mes", mes);
                        cmd.Parameters.AddWithValue("@p_anio", anio);

                        cmd.ExecuteNonQuery();

                        // Auditoría: Se registra la acción en el sistema de auditoría
                        AuditHelper.RegistrarAuditoria(
                            conn,
                            Session.IdUsuario, // Usuario que genera el rol de pago
                            "INSERT",
                            "rol_pago",
                            $"Se generó,rol de pago {numRol} para idempleado: {employeeId}, fecha: {mes}/{anio}"
                        );

                        return "Rol de pago generado correctamente.";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error al generar rol de pago: {ex.Message}";
            }
        }
        public List<payroll_model> GetAll()
        {
            var list = new List<payroll_model>();
            using (var connection = _connection.GetConnection())
            {
                // Asegúrate de que la vista incluya 'idRol' (puedes modificar la vista para que seleccione rp.idRol AS idRol)
                string query = "SELECT * FROM vista_rol_pago_detallada";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new payroll_model
                            {
                                IdRol = reader.GetInt32("idRol"), // Asegúrate de que la vista lo incluya
                                NumRol = reader.GetInt32("numRol"),
                                Mes = reader.GetString("mes"),
                                Anio = reader.GetInt32("anio"),
                                FechaEmision = reader.GetDateTime("fechaEmision"),
                                IdEmpleado = reader.GetInt32("idEmpleado"),
                                NombreEmpleado = reader.GetString("nombreEmpleado"),
                                Cedula = reader.GetString("cedula"),
                                NombreCargo = reader.GetString("nombreCargo"),
                                NombreDepartamento = reader.GetString("nombreDepartamento"),
                                Sueldo = reader.GetDecimal("sueldo"),
                                HorasSuplementarias = reader.GetDecimal("horasSuplementarias"),
                                HorasExtras = reader.GetDecimal("horasExtras"),
                                DecimotercerSueldo = reader.GetDecimal("decimotercerSueldo"),
                                DecimocuartoSueldo = reader.GetDecimal("decimocuartoSueldo"),
                                FondoReserva = reader.GetDecimal("fondoReserva"),
                                AporteIess = reader.GetDecimal("aporteIess"),
                                Anticipos = reader.GetDecimal("anticipos"),
                                OtrosDescuentos = reader.GetDecimal("otrosDescuentos"),
                                DescuentoTardanzas = reader.GetDecimal("descuentoTardanzas"),
                                TotalEgresos = reader.GetDecimal("totalEgresos"),
                                TotalIngresos = reader.GetDecimal("totalIngresos"),
                                NetoPagar = reader.GetDecimal("netoPagar")
                            });
                        }
                    }
                }
            }
            return list;
        }

        public List<payroll_model> GetAll2()
        {
            var payrollList = new List<payroll_model>();
            try
            {
                using (var conn = _connection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM rolpago WHERE isDeleted = FALSE";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var payroll = new payroll_model
                                {
                                    IdRol = reader.GetInt32("idRol"),
                                    NumRol = reader.GetInt32("numRol"),
                                    Mes = reader.GetString("mes"),
                                    Anio = reader.GetInt32("anio"),
                                    FechaEmision = reader.GetDateTime("fechaEmision"),
                                    IdEmpleado = reader.GetInt32("idEmpleado"),
                                    Sueldo = reader.GetDecimal("sueldo"),
                                    HorasSuplementarias = reader.GetDecimal("horasSuplementarias"),
                                    HorasExtras = reader.GetDecimal("horasExtras"),
                                    DecimotercerSueldo = reader.GetDecimal("decimotercerSueldo"),
                                    DecimocuartoSueldo = reader.GetDecimal("decimocuartoSueldo"),
                                    FondoReserva = reader.GetDecimal("fondoReserva"),
                                    AporteIess = reader.GetDecimal("aporteIess"),
                                    Anticipos = reader.GetDecimal("anticipos"),
                                    OtrosDescuentos = reader.GetDecimal("otrosDescuentos"),
                                    DescuentoTardanzas = reader.GetDecimal("descuentoTardanzas"),
                                    TotalEgresos = reader.GetDecimal("totalEgresos"),
                                    TotalIngresos = reader.GetDecimal("totalIngresos"),
                                    NetoPagar = reader.GetDecimal("netoPagar")
                                };
                                payrollList.Add(payroll);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los roles de pago: " + ex.Message);
            }
            return payrollList;
        }

        // Método para buscar roles de pago por algún criterio
        public List<payroll_model> Search(string searchText)
        {
            var payrollList = new List<payroll_model>();
            try
            {
                using (var conn = _connection.GetConnection())
                {
                    conn.Open();
                    // La consulta busca por nombre de empleado, número de rol (convertido a cadena) o mes
                    string query = @"
                SELECT * 
                FROM vista_rol_pago_detallada 
                WHERE nombreEmpleado LIKE @search 
                   OR CAST(numRol AS CHAR) LIKE @search 
                   OR mes LIKE @search";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                payrollList.Add(new payroll_model
                                {
                                    IdRol = reader.GetInt32("idRol"),
                                    NumRol = reader.GetInt32("numRol"),
                                    Mes = reader.GetString("mes"),
                                    Anio = reader.GetInt32("anio"),
                                    FechaEmision = reader.GetDateTime("fechaEmision"),
                                    IdEmpleado = reader.GetInt32("idEmpleado"),
                                    NombreEmpleado = reader.GetString("nombreEmpleado"),
                                    Cedula = reader.GetString("cedula"),
                                    NombreCargo = reader.GetString("nombreCargo"),
                                    NombreDepartamento = reader.GetString("nombreDepartamento"),
                                    Sueldo = reader.GetDecimal("sueldo"),
                                    HorasSuplementarias = reader.GetDecimal("horasSuplementarias"),
                                    HorasExtras = reader.GetDecimal("horasExtras"),
                                    DecimotercerSueldo = reader.GetDecimal("decimotercerSueldo"),
                                    DecimocuartoSueldo = reader.GetDecimal("decimocuartoSueldo"),
                                    FondoReserva = reader.GetDecimal("fondoReserva"),
                                    AporteIess = reader.GetDecimal("aporteIess"),
                                    Anticipos = reader.GetDecimal("anticipos"),
                                    OtrosDescuentos = reader.GetDecimal("otrosDescuentos"),
                                    DescuentoTardanzas = reader.GetDecimal("descuentoTardanzas"),
                                    TotalEgresos = reader.GetDecimal("totalEgresos"),
                                    TotalIngresos = reader.GetDecimal("totalIngresos"),
                                    NetoPagar = reader.GetDecimal("netoPagar")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar roles de pago: " + ex.Message);
            }
            return payrollList;
        }


        internal bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
