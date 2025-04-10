using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoIntegrador.Models
{
    internal class user_model
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public string RolUsuario { get; set; } // "Administrador" o "Empleado"
        public bool Estado { get; set; }
        public bool IsDeleted { get; set; }
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string EstadoString { get; internal set; }
    }
}
