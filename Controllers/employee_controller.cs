﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using proyectoIntegrador.Config;
using proyectoIntegrador.Helpers;
using proyectoIntegrador.Models;

namespace proyectoIntegrador.Controllers
{
    internal class employee_controller
    {
        private readonly connection _cn = new connection();
        public List<employee_model> GetAll()
        {
            var employeeList = new List<employee_model>();
            using (var connection = _cn.GetConnection())
            {
                string query = "SELECT * FROM vista_empleados_gestion";  // Usando la vista

                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employeeList.Add(new employee_model
                            {
                                IdEmpleado = reader.GetInt32("IdEmpleado"),
                                NombreEmpleado = reader.GetString("NombreEmpleado"),
                                Cedula = reader.GetString("Cedula"),
                                Direccion = reader.GetString("Direccion"),
                                Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString("Telefono"),
                                FechaNacimiento = reader.GetDateTime("FechaNacimiento"),
                                FechaContratacion = reader.GetDateTime("FechaContratacion"),
                                IdDepartamento = reader.GetInt32("IdDepartamento"),
                                IdCargo = reader.GetInt32("IdCargo"),
                                Huella = reader.GetInt32("Huella"),
                                HuellaRegistrada = reader.GetString("HuellaRegistrada"),  // Valor calculado
                                Estado = reader.GetString("Estado"),  // Valor calculado
                                NombreDepartamento = reader.GetString("nombreDepartamento"),  // Recuperado de la vista
                                NombreCargo = reader.GetString("nombreCargo")
                            });
                        }
                    }

                }
            }
            return employeeList;
        }


        public employee_model GetById(int id)
        {
            employee_model employee = null;
            using (var connection = _cn.GetConnection())
            {
                //string query = "SELECT IdEmpleado, NombreEmpleado, Cedula, Direccion,Telefono, FechaNacimiento, FechaContratacion, IdDepartamento, IdCargo FROM empleado WHERE IdEmpleado = @IdEmpleado AND isDeleted = 0";
                string query = "SELECT IdEmpleado, NombreEmpleado, Cedula, Direccion, Telefono, FechaNacimiento, FechaContratacion, IdDepartamento, IdCargo, Huella FROM empleado WHERE IdEmpleado = @IdEmpleado AND isDeleted = 0";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdEmpleado", id);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employee = new employee_model
                            {
                                IdEmpleado = reader.GetInt32("IdEmpleado"),
                                NombreEmpleado = reader.GetString("NombreEmpleado"),
                                Cedula = reader.GetString("Cedula"),
                                Direccion = reader.GetString("Direccion"),
                                Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString("Telefono"),
                                FechaNacimiento = reader.GetDateTime("FechaNacimiento"),
                                FechaContratacion = reader.GetDateTime("FechaContratacion"),
                                IdDepartamento = reader.GetInt32("IdDepartamento"),
                                IdCargo = reader.GetInt32("IdCargo"),
                                Huella = reader.GetInt32("Huella") // Add this line

                            };
                        }
                    }
                }
            }
            return employee;
        }

        // Insertar
        public string Insert(employee_model employee)
        {
            using (var connection = _cn.GetConnection())
            {
                string query = @"INSERT INTO empleado (NombreEmpleado, Cedula, Direccion,Telefono, FechaNacimiento, FechaContratacion, IdDepartamento, IdCargo, Huella) 
                                 VALUES (@NombreEmpleado, @Cedula, @Direccion,@Telefono, @FechaNacimiento, @FechaContratacion, @IdDepartamento, @IdCargo,@Huella)";
                string resultado;

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreEmpleado", employee.NombreEmpleado);
                    command.Parameters.AddWithValue("@Cedula", employee.Cedula);
                    command.Parameters.AddWithValue("@Direccion", employee.Direccion);
                    command.Parameters.AddWithValue("@Telefono", employee.Telefono ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@FechaNacimiento", employee.FechaNacimiento);
                    command.Parameters.AddWithValue("@FechaContratacion", employee.FechaContratacion);
                    command.Parameters.AddWithValue("@IdDepartamento", employee.IdDepartamento);
                    command.Parameters.AddWithValue("@IdCargo", employee.IdCargo);
                    command.Parameters.AddWithValue("@Huella", employee.Huella);

                    resultado = ExecuteCommand(command, connection); // Ejecuta el comando y guarda el resultado
                }
                if (resultado == "ok")
                {
                    AuditHelper.RegistrarAuditoria(
                        connection,
                        Session.IdUsuario,
                        "INSERT",
                        "empleado",
                        $"Se insertó un nuevo empleado: {employee.NombreEmpleado}, cédula: {employee.Cedula}"
                    );
                }

                return resultado;
            }
        }

        // Actualizar
        public string Update(employee_model employee)
        {
            using (var connection = _cn.GetConnection())
            {
                string query = @"UPDATE empleado 
                 SET NombreEmpleado = @NombreEmpleado, 
                     Cedula = @Cedula, 
                     Direccion = @Direccion,
                     Telefono = @Telefono, 
                     FechaNacimiento = @FechaNacimiento, 
                     FechaContratacion = @FechaContratacion, 
                     IdDepartamento = @IdDepartamento, 
                     IdCargo = @IdCargo,
                     Huella = @Huella
                 WHERE IdEmpleado = @IdEmpleado";
                string resultado;

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdEmpleado", employee.IdEmpleado);
                    command.Parameters.AddWithValue("@NombreEmpleado", employee.NombreEmpleado);
                    command.Parameters.AddWithValue("@Cedula", employee.Cedula);
                    command.Parameters.AddWithValue("@Direccion", employee.Direccion);

                    command.Parameters.AddWithValue("@Telefono", employee.Telefono ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@FechaNacimiento", employee.FechaNacimiento);
                    command.Parameters.AddWithValue("@FechaContratacion", employee.FechaContratacion);
                    command.Parameters.AddWithValue("@IdDepartamento", employee.IdDepartamento);
                    command.Parameters.AddWithValue("@IdCargo", employee.IdCargo);
                    command.Parameters.AddWithValue("@Huella", employee.Huella);
                    resultado = ExecuteCommand(command, connection);
                }
                if (resultado == "ok")
                {
                    AuditHelper.RegistrarAuditoria(
                        connection,
                        Session.IdUsuario,
                        "UPDATE",
                        "empleado",
                        $"Se actualizó el empleado con ID: {employee.IdEmpleado}"
                    );
                }

                return resultado;
            }
        }

        // Eliminar con isdelete
        /*
        public string Delete(int id)
        {
            using (var connection = _cn.GetConnection())
            {
                string query = "UPDATE empleado SET isDeleted = 1 WHERE IdEmpleado = @IdEmpleado";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdEmpleado", id);
                    return ExecuteCommand(command, connection);
                }
            }
        }
        */
        public bool Delete(int id)
        {
            using (var connection = _cn.GetConnection())
            {
                string query = "UPDATE empleado SET isDeleted = 1 WHERE IdEmpleado = @IdEmpleado";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdEmpleado", id);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            AuditHelper.RegistrarAuditoria(
                                connection,
                                Session.IdUsuario,
                                "DELETE",
                                "empleado",
                                $"Se eliminó (isDeleted = 1) el empleado con ID: {id}"
                            );
                            return true;
                        }

                        return false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error al eliminar el empleado: " + e.Message);
                        return false;
                    }
                }
            }
        }
        public List<employee_model> SearchByName(string name)
        {
            var employeeList = new List<employee_model>();

            using (var connection = _cn.GetConnection())
            {
                //string query = "SELECT idEmpleado, nombreEmpleado, cedula, direccion, telefono, fechaNacimiento, fechaContratacion, idDepartamento, idCargo FROM empleado where isDeleted = 0 AND nombreEmpleado LIKE @Nombre";
                string query = "SELECT * FROM vista_empleados_gestion WHERE nombreEmpleado LIKE @Nombre";  // Usando la vista

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", "%" + name + "%");

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employeeList.Add(new employee_model
                            {
                                IdEmpleado = reader.GetInt32("idEmpleado"),
                                NombreEmpleado = reader.GetString("nombreEmpleado"),
                                Cedula = reader.GetString("cedula"),
                                Direccion = reader.GetString("direccion"),
                                Telefono = reader.IsDBNull(reader.GetOrdinal("telefono")) ? null : reader.GetString("telefono"),
                                FechaNacimiento = reader.GetDateTime("fechaNacimiento"),
                                FechaContratacion = reader.GetDateTime("fechaContratacion"),
                                IdDepartamento = reader.GetInt32("idDepartamento"),
                                IdCargo = reader.GetInt32("idCargo"),
                                NombreCargo = reader.GetString("nombreCargo"),
                                Huella = reader.GetInt32("Huella"),
                                HuellaRegistrada = reader.GetString("HuellaRegistrada"),  // Valor calculado
                                Estado = reader.GetString("Estado"),  // Valor calculado
                                NombreDepartamento = reader.GetString("nombreDepartamento")

                            });
                        }
                    }
                }
            }
            return employeeList;
        }

        // NO BORRAR SINO NO FUNCIONA!!!! (INSERT, UPDATE, DELETE)
        private string ExecuteCommand(MySqlCommand command, MySqlConnection connection)
        {
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return "ok";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
        }
        public int GenerateFingerprintID()
        {
            for (int id = 1; id <= 127; id++)
            {
                if (!FingerprintExists(id))
                {
                    return id;
                }
            }
            throw new Exception("No hay ID de huella digital disponible.");
        }

        public bool FingerprintExists(int id)
        {
            using (var connection = _cn.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM empleado WHERE Huella = @id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }
        public string InsertFP(employee_model employee)
        {
            using (var connection = _cn.GetConnection())
            {
                string query = @"INSERT INTO empleado (Huella) 
                                 VALUES (@Huella) WHERE IdEmpleador = @idEmpleado";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Huella", employee.Huella);
                    return ExecuteCommand(command, connection);
                }
            }
        }



    }
}

