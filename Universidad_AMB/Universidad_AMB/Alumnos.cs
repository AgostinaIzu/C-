using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad_AMB
{
    public class Alumnos : Personas
    {
        Comision C;

        public List<Materia> MateriasAlumno { get; set; }
        public Comision ComisionAlumno { set => C = value; }
        public string Comision { get; set; }
        public Alumnos(string legajo, string nombre) : base(legajo, nombre)
        {
            Comision = "s/c";
            MateriasAlumno = new List<Materia>();
            //MessageBox.Show("Se ha creado un nuevo alumno");
        }
    }
}
