using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoIntegrador.Models
{
    internal class justification_model
    {
        public int IdJustificacion { get; set; }
        public string Motivo { get; set; } // "Vacaciones", "Salud", "Otro"
        public string Detalle { get; set; }
        public bool IsDeleted { get; set; }
    }
}
