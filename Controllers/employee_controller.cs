﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using proyectoIntegrador.Config;
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
                string query = "SELECT IdEmpleado, NombreEmpleado, Cedula, Direccion, Telefono, FechaNacimiento, FechaContratacion, IdDepartamento, IdCargo FROM empleado WHERE isDeleted = 0";
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
                                IdCargo = reader.GetInt32("IdCargo")
                            });
                        }
                    }
                }
            }
            return employeeList;
        }

        // pal id
        public employee_model GetById(int id)
        {
            employee_model employee = null;
            using (var connection = _cn.GetConnection())
            {
                string query = "SELECT IdEmpleado, NombreEmpleado, Cedula, Direccion,Telefono, FechaNacimiento, FechaContratacion, IdDepartamento, IdCargo FROM empleado WHERE IdEmpleado = @IdEmpleado AND isDeleted = 0";
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
                                IdCargo = reader.GetInt32("IdCargo")
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

                    return ExecuteCommand(command, connection);
                }
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
                                     IdCargo = @IdCargo
                                 WHERE IdEmpleado = @IdEmpleado";

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

                    return ExecuteCommand(command, connection);
                }
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
                        return rowsAffected > 0; // Si se afectó al menos una fila, retorna true
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
                string query = "SELECT IdEmpleado, NombreEmpleado, Cedula, Direccion, Telefono, FechaNacimiento, FechaContratacion, IdDepartamento, IdCargo " +
                               "FROM empleado WHERE isDeleted = 0 AND NombreEmpleado LIKE @Nombre";

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
                                IdEmpleado = reader.GetInt32("IdEmpleado"),
                                NombreEmpleado = reader.GetString("Nombre"),
                                Cedula = reader.GetString("Cedula"),
                                Direccion = reader.GetString("Direccion"),
                                Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString("Telefono"),
                                FechaNacimiento = reader.GetDateTime("FechaNacimiento"),
                                FechaContratacion = reader.GetDateTime("FechaContratacion"),
                                IdDepartamento = reader.GetInt32("IdDepartamento"),
                                IdCargo = reader.GetInt32("IdCargo")
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
        /*
        public bool HuellaExiste(int huellaId)
        {
            using (var connection = _cn.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM empleado WHERE Huella = @Huella AND isDeleted = 0";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Huella", huellaId);
                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public bool ActualizarHuella(int empleadoId, int nuevaHuella)
        {
            using (var connection = _cn.GetConnection())
            {
                string query = "UPDATE empleado SET Huella = @Huella WHERE IdEmpleado = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Huella", nuevaHuella);
                    command.Parameters.AddWithValue("@Id", empleadoId);

                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }*/
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

        private bool FingerprintExists(int id)
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

    }
}

