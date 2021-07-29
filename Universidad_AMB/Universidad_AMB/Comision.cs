using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Universidad_AMB
{
    public class Comision
    {
        int Vaño;
        string Vgrupo;

        public List<Alumnos> ListaAlumnos { get; set; }
        public int Año
        {
            set
            {
                try
                {
                    if (Vaño <= 6 && Vaño > 0) { Vaño = value; }
                }
                catch (Exception)
                {
                    MessageBox.Show("Año invalido");
                    throw;
                }
            }
        }
        public string Grupo
        {
            set
            {
                try
                {
                    if ((Vgrupo == "a") || (Vgrupo == "b") || (Vgrupo == "c"))
                    {
                        Vgrupo = value;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Año invalido");
                    throw;
                }
            }
        }
        public string Codigo
        {
            get
            {
                string cod = Vaño.ToString() + "-" + Vgrupo.ToString();
                return cod;
            }
        }
        public Comision(int año, string grupo)
        {
            Año = año;
            Grupo = grupo;
            ListaAlumnos = new List<Alumnos>();
            Vaño = año;
            Vgrupo = grupo;
        }
    }
}
