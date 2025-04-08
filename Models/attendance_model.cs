using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoIntegrador.Models
{
    internal class attendance_model
    {
        public int IdAsistencia { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan? HoraEntrada { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public decimal? HorasTrabajadas { get; set; }
        public bool Justificado { get; set; }
        public int? IdJustificacion { get; set; }
        public bool IsDeleted { get; set; }
        public string MotivoJustificacion { get; internal set; }
    }
}
