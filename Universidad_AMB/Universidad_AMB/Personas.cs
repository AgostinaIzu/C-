using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad_AMB
{
    public class Personas
    {
        public string Legajo { get; set; }
        public string Nombre_Completo { get; set; }
        public Personas(string legajo, string nombre)
        {
            Legajo = legajo;
            Nombre_Completo = nombre;
        }
    }
}
