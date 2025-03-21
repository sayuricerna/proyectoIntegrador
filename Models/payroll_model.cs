using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoIntegrador.Models
{
    internal class payroll_model
    {
        public int IdRol { get; set; }
        public int NumRol { get; set; }
        public bool IsDeleted { get; set; }
        public string Mes { get; set; }
        public int Anio { get; set; }
        public DateTime FechaEmision { get; set; }
        public int IdEmpleado { get; set; }
        // Ingresos
        public decimal Sueldo { get; set; }
        public decimal HorasSuplementarias { get; set; }
        public decimal HorasExtras { get; set; }
        public decimal DecimotercerSueldo { get; set; }
        public decimal DecimocuartoSueldo { get; set; }
        public decimal FondoReserva { get; set; }
        // Egresos
        public decimal AporteIess { get; set; }
        public decimal TotalEgresos { get; set; }
        // Totales
        public decimal TotalIngresos => Sueldo + HorasSuplementarias + HorasExtras + DecimotercerSueldo + DecimocuartoSueldo + FondoReserva;
        public decimal NetoPagar => TotalIngresos - TotalEgresos;
    }
}
