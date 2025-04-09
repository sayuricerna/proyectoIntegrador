using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoIntegrador.Models
{
    public class payroll_model // ▶️ Cambia de class a public class
    {
        public int IdRol { get; set; }
        public int NumRol { get; set; }
        public string Mes { get; set; }
        public int Anio { get; set; }
        public DateTime FechaEmision { get; set; }
        public int IdEmpleado { get; set; }
        public decimal Sueldo { get; set; }
        public decimal HorasSuplementarias { get; set; }
        public decimal HorasExtras { get; set; }
        public decimal DecimotercerSueldo { get; set; }
        public decimal DecimocuartoSueldo { get; set; }
        public decimal FondoReserva { get; set; }
        public decimal AporteIess { get; set; }
        public decimal Anticipos { get; set; }
        public decimal OtrosDescuentos { get; set; }
        public decimal DescuentoTardanzas { get; set; }
        public decimal TotalEgresos { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal NetoPagar { get; set; }




        //vista vista_rol_pago_detallada
        public string NombreEmpleado { get; set; }
        public string Cedula { get; set; }
        public string NombreCargo { get; set; }
        public string NombreDepartamento { get; set; }





    }
}
