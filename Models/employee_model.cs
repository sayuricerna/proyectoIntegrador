using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoIntegrador.Models
{
    internal class employee_model
    {
        public int IdEmpleado { get; set; }
        public byte[] Foto { get; set; }
        public byte[] Huella { get; set; }
        public string Cedula { get; set; }
        public string NombreEmpleado { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaContratacion { get; set; }
        public int IdDepartamento { get; set; }
        public int IdCargo { get; set; }
        public bool IsDeleted { get; set; }
    }
}
