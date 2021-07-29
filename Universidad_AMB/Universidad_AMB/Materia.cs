using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad_AMB
{
    public class Materia
    {
        public string Nombre { get; set; }
        public int Codigo { get; set; }

//        public List<Docentes> ListaDocentes = new List<Docentes>();
        public List<Alumnos> ListaAlumnos { get; set; }

        public Materia(string nombre, int codigo) 
        { 
            Nombre = nombre; 
            Codigo = codigo;
            ListaAlumnos = new List<Alumnos>();
        }
    }
}
