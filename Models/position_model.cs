using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoIntegrador.Models
{
    internal class position_model
    {
        public int IdCargo { get; set; }
        public string NombreCargo { get; set; }
        public decimal Salario { get; set; }
        public int IdDepartamento { get; set; }
        public bool IsDeleted { get; set; }
    }
}
