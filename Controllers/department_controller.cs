using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyectoIntegrador.Config;
using proyectoIntegrador.Models;

namespace proyectoIntegrador.Controllers
{
     class department_controller
    {
        private readonly connection cn = new connection();
       
        // Insertar un nuevo departamento
        public string Insert(department_model department)
        {
            using (var connection = cn.GetConnection())
            {
                string query = "INSERT INTO departamento (NombreDepartamento, isDeleted) VALUES (@NombreDepartamento, @IsDeleted)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreDepartamento", department.NombreDepartamento);
                    command.Parameters.AddWithValue("@IsDeleted", department.IsDeleted);
                    return ExecuteCommand(command, connection);
                }
            }
        }
        
        // Obtener todos los departamentos y crgos activos
        public List<department_model> GetAll()
        {
            var departmentList = new List<department_model>();
            using (var connection = cn.GetConnection())
            {
                string query = "SELECT Salario, Cargo, Departamento FROM vwPosDpt";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            departmentList.Add(new department_model
                            {
                                Salario = reader.GetDecimal("Salario"),
                                Cargo = reader.GetString("Cargo"),
                                Departamento = reader.GetString("Departamento")
                            });
                        }
                    }
                }
            }
            return departmentList;
        }
        // Obtener todos los departamentos activos para ComboBox
        public List<department_model> GetAllDepartments()
        {
            var departmentList = new List<department_model>();
            using (var connection = cn.GetConnection())
            {
                string query = "SELECT IdDepartamento, NombreDepartamento FROM departamento WHERE isDeleted = 0";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            departmentList.Add(new department_model
                            {
                                IdDepartamento = reader.GetInt32("IdDepartamento"),
                                NombreDepartamento = reader.GetString("NombreDepartamento")
                            });
                        }
                    }
                }
            }
            return departmentList;
        }

        // Obtener un departamento por ID
        public department_model GetById(int id)
        {
            using (var connection = cn.GetConnection())
            {
                string query = "SELECT * FROM departamento WHERE IdDepartamento = @IdDepartamento";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdDepartamento", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new department_model
                            {
                                IdDepartamento = reader.GetInt32("IdDepartamento"),
                                NombreDepartamento = reader.GetString("NombreDepartamento"),
                                IsDeleted = reader.GetBoolean("isDeleted")
                            };
                        }
                        return null;
                    }
                }
            }
        }
        
        
        // Actualizar un departamento
        public string Update(department_model department)
        {
            using (var connection = cn.GetConnection())
            {
                string query = "UPDATE departamento SET NombreDepartamento = @NombreDepartamento WHERE IdDepartamento = @IdDepartamento";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdDepartamento", department.IdDepartamento);
                    command.Parameters.AddWithValue("@NombreDepartamento", department.NombreDepartamento);
                    return ExecuteCommand(command, connection);
                }
            }
        }
        
        // Eliminar un departamento (soft delete)
        public bool Delete(int id)
        {
            using (var connection = cn.GetConnection())
            {
                string query = "UPDATE departamento SET isDeleted = 1 WHERE IdDepartamento = @IdDepartamento";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdDepartamento", id);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }
        
        // Buscar departamentos por nombre
        public List<department_model> SearchByName(string name)
        {
            var departmentList = new List<department_model>();
            using (var connection = cn.GetConnection())
            {
                string query = "SELECT * FROM departamento WHERE NombreDepartamento LIKE @Name AND isDeleted = 0";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", "%" + name + "%");
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            departmentList.Add(new department_model
                            {
                                IdDepartamento = reader.GetInt32("IdDepartamento"),
                                NombreDepartamento = reader.GetString("NombreDepartamento"),
                                IsDeleted = reader.GetBoolean("isDeleted")
                            });
                        }
                    }
                }
            }
            return departmentList;
        }
        
        // Ejecutar el comando SQL (INSERT, UPDATE, DELETE)
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
                return e.Message;
            }
        }
    }
}
