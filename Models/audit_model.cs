using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoIntegrador.Models
{
    internal class audit_model
    {
        public int IdAuditoria { get; set; }
        public string TablaAfectada { get; set; }
        public string TipoAccion { get; set; } // "INSERT", "UPDATE", "DELETE"
        public string Descripcion { get; set; }
        public DateTime FechaHora { get; set; }
        public int IdUsuario { get; set; }
    }
}
