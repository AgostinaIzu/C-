using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad_AMB
{
    public class Docentes : Personas
    {
        Materia M;
        public Materia Materia_Enseñada { set => M = value; }
        public string Materia { get => M.Nombre; }
        public Docentes(string legajo, string nombre, Materia materia) : base(legajo, nombre)
        {
            Materia_Enseñada = materia;
            //MessageBox.Show("Se ha creado un nuevo docente"); 
        }

        public event EventHandler TomarExamen;
    }
}
