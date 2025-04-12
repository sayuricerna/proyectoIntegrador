using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyectoIntegrador.Config;
using proyectoIntegrador.Models;
using proyectoIntegrador.Helpers;
using System.Windows.Forms;

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
                string resultado;
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreDepartamento", department.NombreDepartamento);
                    command.Parameters.AddWithValue("@IsDeleted", department.IsDeleted);
                    resultado = ExecuteCommand(command, connection); // Guarda el resultado en una variable

                }
                AuditHelper.RegistrarAuditoria(
                    connection,
                    Session.IdUsuario,
                    "INSERT",
                    "departamento",
                    $"Se creó el departamento: {department.NombreDepartamento}"
                );
                return resultado; // Finalmente retorna el resultado

            }
        }

        public List<department_model> GetAllDepartments()
        {
            var departmentList = new List<department_model>();
            using (var connection = cn.GetConnection())
            {
                string query = "SELECT * FROM vista_departamento_cargos";
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
                                NombreDepartamento = reader.GetString("NombreDepartamento"),
                                NumeroCargos = reader.GetInt32("numeroCargos")
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
                    string resultado = ExecuteCommand(command, connection);

                    if (resultado == "ok")
                    {
                        AuditHelper.RegistrarAuditoria(
                            connection,
                            Session.IdUsuario,
                            "UPDATE",
                            "departamento",
                            $"Se actualizó el departamento ID {department.IdDepartamento} con nuevo nombre: {department.NombreDepartamento}"
                        );
                    }

                    return resultado;
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
                        AuditHelper.RegistrarAuditoria(
                            connection,
                            Session.IdUsuario,
                            "DELETE",
                            "departamento",
                            $"Se marcó como eliminado el departamento con ID: {id}"
                        );

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
                string query = "SELECT * FROM vista_departamento_cargos WHERE NombreDepartamento LIKE @Name";
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
                                NumeroCargos = reader.GetInt32("numeroCargos")
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
