using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace Universidad_AMB
{
    public class Universidad
    {
        public List<Materia> ListaMaterias { get; set; }
        public List<Docentes> ListaDocentes { get; set; }
        public List<Alumnos> ListaAlumnos { get; set; }
        public List<Comision> ListaComisiones { get; set; }
        public Universidad()
        {
            ListaMaterias = new List<Materia>();
            ListaDocentes = new List<Docentes>();
            ListaAlumnos = new List<Alumnos>();
            ListaComisiones = new List<Comision>();
        }
        public void AsignarComision(Alumnos a, Comision c)
        {
            try
            {
                Alumnos auxA = ListaAlumnos.Find(x => x.Legajo == a.Legajo);
                Comision auxC = ListaComisiones.Find(x => x.Codigo == c.Codigo);
                if (auxA.Comision == "s/c")
                {
                    auxA.ComisionAlumno = auxC;
                    auxA.Comision = auxC.Codigo;
                    auxC.ListaAlumnos.Add(auxA);
                }
                else MessageBox.Show("El alumno ya posee una comision asignada");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            } 
        }
        public void DesvincularComision(Alumnos a)
        {
            try
            {
                Alumnos auxA = ListaAlumnos.Find(x => x.Legajo == a.Legajo);
                Comision auxC = ListaComisiones.Find(x => x.Codigo == a.Comision);
                if (auxA.Comision != "s/c")
                {
                    auxA.Comision = "s/c";
                    auxC.ListaAlumnos.Remove(auxA);
                }
                else MessageBox.Show("El alumno no pertenece a niguna comision");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        public void AsignarMateria(Alumnos a, Materia m) 
        {
            try
            {
                Alumnos auxA = ListaAlumnos.Find(x => x.Legajo == a.Legajo);
                Materia auxM = ListaMaterias.Find(x => x.Codigo == m.Codigo);
                
                Materia aux = auxA.MateriasAlumno.Find(x => x.Codigo == m.Codigo);

                if (aux == null)
                {
                    auxA.MateriasAlumno.Add(auxM);
                    auxM.ListaAlumnos.Add(auxA);
                }
                else { MessageBox.Show("El alumno ya esta inscripto en la materia"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }   
        }
        public void DesvincularMateria(Alumnos a, Materia m) 
        {
            try
            {
                Alumnos A = ListaAlumnos.Find(x => x.Legajo == a.Legajo);
                Materia M = ListaMaterias.Find(x => x.Codigo == m.Codigo);

                Alumnos auxA = M.ListaAlumnos.Find(x => x.Legajo == a.Legajo);
                Materia auxM = A.MateriasAlumno.Find(x => x.Codigo == m.Codigo);

                if (auxA != null && auxM != null)
                {
                    A.MateriasAlumno.Remove(M);
                    M.ListaAlumnos.Remove(A);
                }
                else { MessageBox.Show("El alumno no esta inscripto en la materia seleccionada"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }           
        }
        public List<string> MostrarAlumnos(Alumnos A)
        {
            List<string> MateriasAux = new List<string>();

            foreach (Materia m in A.MateriasAlumno)
            {
                MateriasAux.Add(m.Nombre);
            }
            return MateriasAux;
        }
        public List<string> MostrarAlumnos(Materia M)
        {
            List<string> AlumnosAux = new List<string>();

            foreach (Alumnos a in M.ListaAlumnos)
            {
                AlumnosAux.Add(a.Nombre_Completo);
            }
            return AlumnosAux;
        }
        public List<string> MostrarAlumnos(Comision C) 
        {
            List<string> AlumnosAux = new List<string>();

            foreach (Alumnos a in C.ListaAlumnos)
            {
                AlumnosAux.Add(a.Nombre_Completo);
            }

            return AlumnosAux;
        }
    }
}
