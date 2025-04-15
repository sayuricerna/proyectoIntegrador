using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoIntegrador.Models
{
    internal class advancep_model
    {
        public int IdAnticipo { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Motivo { get; set; }
        public bool IsDeleted { get; set; }

        public string NombreEmpleado { get; set; }



    }
}
