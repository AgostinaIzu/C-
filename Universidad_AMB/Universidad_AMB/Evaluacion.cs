using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad_AMB
{
    public class Evaluacion
    {
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public Alumnos Alumno { get; set; }
        public int Nota { get; set; }
    }
}
