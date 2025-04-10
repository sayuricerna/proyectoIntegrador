using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoIntegrador.Models
{
    class department_model
    {

        //department_model idDepartamento nombreDepartamento isDeleted 
        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public bool IsDeleted { get; set; }



        //Desde View posDpt ver en grid
        public int NumeroCargos { get; set; }

    }
}
