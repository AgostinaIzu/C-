using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Universidad_AMB
{
    public partial class Form1 : Form
    {
        int numD = 1001;
        int numA = 1001;
        Universidad U;
        public Form1()
        {
            InitializeComponent();
            U = new Universidad();

            #region Configuracion Grillas
            dgv_docentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_docentes.MultiSelect = false;
            dgv_materias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_materias.MultiSelect = false;
            dgv_comisiones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_comisiones.MultiSelect = false;
            dgv_alumnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_alumnos.MultiSelect = false;
            #endregion 
        }

        #region Agregar Harcodeados
        private void Agregar_Hardcodeados_Click(object sender, EventArgs e)
        {
            try { 
                U.ListaComisiones.AddRange(new Comision[] { new Comision(1, "A"),
                                                            new Comision(1, "B"),
                                                            new Comision(1, "C"),
                                                            new Comision(2, "A"),
                                                            new Comision(2, "B"),
                                                            new Comision(2, "C"),
                                                            new Comision(3, "A"),
                                                            new Comision(3, "B"),
                                                            new Comision(3, "C")});

                U.ListaAlumnos.AddRange(new Alumnos[] { new Alumnos("MJ-1001", "Alejandro Martinez"),
                                                        new Alumnos("MJ-1002", "Lucia Alvarez"),
                                                        new Alumnos("MJ-1003", "Juan Pablo Mielnez"),
                                                        new Alumnos("MJ-1004", "Andrea Rigtman"),
                                                        new Alumnos("MJ-1005", "Analia Villafañe")});
                numA = +5;

                Materia A, B;
                U.ListaMaterias.Add(A = new Materia("Programacion", 456));
                U.ListaMaterias.Add(B = new Materia("Sistemas", 18));
                U.ListaMaterias.Add(new Materia("Calculo", 132));
                U.ListaMaterias.Add(new Materia("Ingles", 84));

                U.ListaDocentes.AddRange(new Docentes[] {new Docentes("MR-1001", "Alejandro Martinez", A),
                                                         new Docentes("MR-1002", "Lucia Alvarez", B) });
                numA = +2;
                Mostrar_dgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}
        #endregion

        #region Docentes
        private void Agregar_docente_Click(object sender, EventArgs e)
        {
            try
            {
                U.ListaDocentes.Add(new Docentes(
                    "MJ-" + numD.ToString(),
                    Interaction.InputBox("Ingrese nombre completo:"),
                    dgv_materias.SelectedRows[0].DataBoundItem as Materia));
                numD++;
                Mostrar_dgv();
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void Eliminar_docente_Click(object sender, EventArgs e)
        {
            try
            {
                U.ListaDocentes.Remove(this.dgv_docentes.SelectedRows[0].DataBoundItem as Docentes);
                Mostrar_dgv();
            }
            catch (Exception)
            {
                MessageBox.Show("No hay nigun elemento que borrar");
                throw;
            }
        }

        private void Modificar_docente_Click(object sender, EventArgs e)
        {
            try
            {
                Docentes d = dgv_docentes.SelectedRows[0].DataBoundItem as Docentes;
                Docentes aux = U.ListaDocentes.Find(x => x.Legajo == d.Legajo);
                if (aux != null)
                {
                    aux.Nombre_Completo = Interaction.InputBox("Ingrese nuevo nombre: ");
                }
                Mostrar_dgv();
            }
            catch (Exception)
            {
                MessageBox.Show("No hay nigun elemento que borrar");
                throw;
            }
        }
        #endregion
 
        #region Alumnos
        private void Agregar_alumnos_Click(object sender, EventArgs e)
        {
            try
            { 
                U.ListaAlumnos.Add(new Alumnos(
                   "MR-" + numA.ToString(),
                   Interaction.InputBox("Ingrese nombre completo:")));
                numA++;
                Mostrar_dgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Modificar_alumnos_Click(object sender, EventArgs e)
        {
            try
            {
                Alumnos A = dgv_alumnos.SelectedRows[0].DataBoundItem as Alumnos;
                U.ListaAlumnos.Find(x => x.Legajo == A.Legajo);
                if (A != null)
                {
                    A.Nombre_Completo = Interaction.InputBox("Ingrese el nombre:");
                }
                Mostrar_dgv();
            }
            catch (Exception)
            {
                MessageBox.Show("No hay nigun elemento que borrar");
                throw;
            }
        }
        private void Eliminar_alumnos_Click(object sender, EventArgs e)
        {
            try
            {
                U.ListaAlumnos.Remove(dgv_alumnos.SelectedRows[0].DataBoundItem as Alumnos);
                Mostrar_dgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        #endregion

        #region Materias
        private void Agregar_materia_Click(object sender, EventArgs e)
        {
            try
            {
                U.ListaMaterias.Add(new Materia(
                    Interaction.InputBox("Ingrese nombre"),
                    Int32.Parse(Interaction.InputBox("Ingrese numero"))));
                Mostrar_dgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void Eliminar_materia_Click(object sender, EventArgs e) //FALTA ASIGNAR
        {
            try
            {
                U.ListaMaterias.Remove(dgv_materias.SelectedRows[0].DataBoundItem as Materia);
                Mostrar_dgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        #endregion

        #region Comisiones
        private void Agregar_comision_Click(object sender, EventArgs e)
        {
            try
            {
                U.ListaComisiones.Add(new Comision(
                    int.Parse(Interaction.InputBox("Ingrese año")),
                    Interaction.InputBox("Ingrese grupo")));

                Mostrar_dgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Eliminar_comision_Click(object sender, EventArgs e)
        {
            try
            {
                U.ListaComisiones.Remove(dgv_comisiones.SelectedRows[0].DataBoundItem as Comision);
                Mostrar_dgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        #endregion

        #region Asignar/Desvincular
        private void Asignar_comision_Click(object sender, EventArgs e)
        {
            try
            {
                Alumnos A = dgv_alumnos.SelectedRows[0].DataBoundItem as Alumnos;
                Comision C = dgv_comisiones.SelectedRows[0].DataBoundItem as Comision;
                U.AsignarComision(A, C);
                List<string> ListaAlumnos = U.MostrarAlumnos(C);
                
                Mostrar_dgv(); Mostrar_list(ListaAlumnos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Desvincular_comision_Click(object sender, EventArgs e)
        {
            try
            {
                Alumnos A = dgv_alumnos.SelectedRows[0].DataBoundItem as Alumnos;
                U.DesvincularComision(A);

                Comision C = dgv_comisiones.SelectedRows[0].DataBoundItem as Comision;
                List<string> ListaAlumnos = U.MostrarAlumnos(C);
                
                Mostrar_dgv(); Mostrar_list(ListaAlumnos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Asignar_materia_Click(object sender, EventArgs e)
        {
            try
            {
                Alumnos A = dgv_alumnos.SelectedRows[0].DataBoundItem as Alumnos;
                Materia M = dgv_materias.SelectedRows[0].DataBoundItem as Materia;
                U.AsignarMateria(A, M);

                List<string> ListaAlumnos = U.MostrarAlumnos(M);
                Mostrar_list(ListaAlumnos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Desvincular_materia_Click(object sender, EventArgs e)
        {
            try
            {
                Alumnos A = dgv_alumnos.SelectedRows[0].DataBoundItem as Alumnos;
                Materia M = dgv_materias.SelectedRows[0].DataBoundItem as Materia;

                U.DesvincularMateria(A, M);

                List<string> ListaAlumnos = U.MostrarAlumnos(M);
                Mostrar_list(ListaAlumnos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Consultar_materias_Click(object sender, EventArgs e)
        {
            Alumnos A = dgv_alumnos.SelectedRows[0].DataBoundItem as Alumnos;
            List<string> ListaAlumnos = U.MostrarAlumnos(A);
            Mostrar_list(ListaAlumnos);
        }
        #endregion

        #region Mostrar
        private void Mostrar_dgv()
        {
            dgv_docentes.DataSource = null; dgv_docentes.DataSource = U.ListaDocentes;
            dgv_materias.DataSource = null; dgv_materias.DataSource = U.ListaMaterias;
            dgv_comisiones.DataSource = null; dgv_comisiones.DataSource = U.ListaComisiones;
            dgv_alumnos.DataSource = null; dgv_alumnos.DataSource = U.ListaAlumnos;
        }
        private void Mostrar_list(List<string> Lista) 
        { 
            Lista_Alumnos.DataSource = null;
            Lista_Alumnos.DataSource = Lista;
        }

        private void Mostrar_AlumnosxComision_Click(object sender, EventArgs e)
        {
            try
            {
                Comision C = dgv_comisiones.SelectedRows[0].DataBoundItem as Comision;
                List<string> ListaAlumnos = U.MostrarAlumnos(C);

                Mostrar_list(ListaAlumnos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Mostrar_AlumnosxMaterias_Click(object sender, EventArgs e)
        {
            try
            {
                Materia M = dgv_materias.SelectedRows[0].DataBoundItem as Materia;
                List<string> ListaAlumnos = U.MostrarAlumnos(M);

                Mostrar_list(ListaAlumnos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        #endregion
    }
}

