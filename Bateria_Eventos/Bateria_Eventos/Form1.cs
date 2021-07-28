using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bateria_Eventos
{
    public partial class Form1 : Form
    {
        Bateria B;
        Cargador C;

        public Form1()
        {
            InitializeComponent();
            B = new Bateria();
            C = new Cargador();

            progressBar1.Value = B.Nivel_de_Carga;
        }

        private void Boton_Usar_Click(object sender, EventArgs e)
        {
            try
            {
                B.Bateria_baja += FuncionAlertaCarga; //Suscripciones a eventos
                B.Bateria_agotada += FuncionApagado;

                B.Nivel_de_Carga -= 10;
                progressBar1.Value = B.Nivel_de_Carga;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                B.Bateria_baja -= FuncionAlertaCarga; //Desafecciones a eventos
                B.Bateria_agotada += FuncionApagado;
            }
        }

        private void Boton_Cargar_Click(object sender, EventArgs e)
        {
            try
            {
                C.Cargar(B);
                progressBar1.Value = B.Nivel_de_Carga;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Boton_OnOff_Click(object sender, EventArgs e)
        {
            try
            {
                if (Boton_Usar.Enabled == false) { FuncionEncendido(this, null); }
                else { FuncionApagado(this, null); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FuncionAlertaCarga(object sender, Bateria_bajaEvenArgs e) //Metodo evento Bateria_baja
        {
            MessageBox.Show("Nivel de bateria: " + e.NivelBateria + "% \n Bateria baja, cargue su dispositivo");
        }
        private void FuncionApagado(object sender, EventArgs e) //Metodo evento Bateria_agotada
        {
            Boton_Usar.Enabled = false;
            Boton_OnOff.Text = "Encender";
        }
        private void FuncionEncendido(object sender, EventArgs e)
        {
            if (B.Nivel_de_Carga > 0)
            {
                Boton_Usar.Enabled = true;
                Boton_OnOff.Text = "Apagar";
            }
            else { MessageBox.Show("Cargue su dispositivo"); }
        }
    }

    public class Bateria
    {
        int Carga;

        public event EventHandler<Bateria_bajaEvenArgs> Bateria_baja;
        public event EventHandler Bateria_agotada;

        public int Nivel_de_Carga
        {
            get => Carga;
            set
            {
                Carga = value;
                if (value <= 10)
                {
                    if (value == 10)
                    {
                        //DESENCADENAMIENTO DEL EVENTO
                        Bateria_baja?.Invoke(this, new Bateria_bajaEvenArgs(value));
                    }
                    else { Bateria_agotada?.Invoke(this, null); }
                }
            }
        }
        public Bateria() { Nivel_de_Carga = 50; }
    }
    public class Bateria_bajaEvenArgs : EventArgs
    {
        int B;
        public int NivelBateria { get => B; }

        public Bateria_bajaEvenArgs(int nivelbateria) //Constructor
        {
            B = nivelbateria;
        }
    }
    public class Cargador
    {
        public void Cargar(Bateria B)
        {
            if (B.Nivel_de_Carga < 100) { B.Nivel_de_Carga = 100; }
            else { MessageBox.Show("Bateria cargada. Desconecte el cargador"); }
        }
    }
}
