using GUI_App.Interfaces;
using Libreria.Entidades;
using Libreria.Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI_App.Vista
{
    public partial class FormEscobaQuince : Form, IEscobaQuinceForm
    {
        private bool seleccionado;
        private EscobaQuinceServicio juego;
        private SalaCartas sala;


        public FormEscobaQuince()
        {
            InitializeComponent();
            this.btnAbandonar.Click += delegate { EventoAbandonarPartida?.Invoke(this, EventArgs.Empty); };
            this.btnIniciarPartida.Click += delegate { EventoIniciarPartida?.Invoke(this, EventArgs.Empty); }; 
            this.btnEstadisticas.Click += delegate { EventoEstadisticas?.Invoke(this, EventArgs.Empty); }; 

            this.panelHuecoUno.Click += delegate { EventoPanelHuecoUno?.Invoke(this, EventArgs.Empty); };
            this.panelHuecoDos.Click += delegate { EventoPanelHuecoDos?.Invoke(this, EventArgs.Empty); };
            this.panelHuecoTres.Click += delegate { EventoPanelHuecoTres?.Invoke(this, EventArgs.Empty); };
            this.panelHuecoCuatro.Click += delegate { EventoPanelHuecoCuatro?.Invoke(this, EventArgs.Empty); };
            this.panelHuecoCinco.Click += delegate { EventoPanelHuecoCinco?.Invoke(this, EventArgs.Empty); };
            this.panelHuecoSeis.Click += delegate { EventoPanelHuecoSeis?.Invoke(this, EventArgs.Empty); };

            this.panelCartaMesaUno.Click += delegate { EventoPanelMesonUno?.Invoke(this, EventArgs.Empty); };
            this.panelCartaMesaDos.Click += delegate { EventoPanelMesonDos?.Invoke(this, EventArgs.Empty); };
            this.panelCartaMesaTres.Click += delegate { EventoPanelMesonTres?.Invoke(this, EventArgs.Empty); };
            this.panelCartaMesaCuatro.Click += delegate { EventoPanelMesonCuatro?.Invoke(this, EventArgs.Empty); };

            this.panelCartaJugadorUno.Click += delegate { EventoPanelJugadorUno?.Invoke(this, EventArgs.Empty); };
            this.panelCartaJugadorDos.Click += delegate { EventoPanelJugadorDos?.Invoke(this, EventArgs.Empty); };
            this.panelCartaJugadorTres.Click += delegate { EventoPanelJugadorTres?.Invoke(this, EventArgs.Empty); };

            this.btnVerificar.Click += delegate { EventoBotonVerificarCartas?.Invoke(this, EventArgs.Empty); };
            this.btnPasarTurno.Click += delegate { EventoBotonPasarTurno?.Invoke(this, EventArgs.Empty); };

            /// Juego
            /// 


            /*
            juego = new EscobaQuinceServicio();
            sala = new SalaCartas(3, juego, juego);


            sala.IniciarJuego();
            List<Carta> cartas = sala.cartasEnElMesaTest();

            int c = tableLayoutPanel1.GetColumn(this.panelCartaMesaUno);

            TableLayoutPanelCellPosition c2 = tableLayoutPanel1.GetCellPosition(this.panelCartaMesaUno);

            int count = 0;
            foreach (var aux in tableLayoutPanel1.Controls)
            {
               
                
                if (aux is Panel)
                {
                    Panel panel = (Panel)aux;

                  
                    if (panel == this.panelCartaMesaUno)
                    {
                        foreach (Label label in panel.Controls)
                        {
                            foreach (var carta in cartas)
                            {

                                label.Text = "Panel Mesa uno";
                                // if (label is Label)

                            }
                            label.Text = "Panel Mesa uno";
                           // if (label is Label)
                           
                        }
                    }
                    else if (panel == this.panelCartaMesaDos)
                    {
                        foreach (Label label in panel.Controls)
                        {
                            label.Text = "Panel Mesa dos";

                          /*  if (label is Label)
                            {
                                Label lab = (Label)label;
                                lab.Text = "Panel Mesa uno";

                        }
                    }

                    else if (panel == this.panelCartaMesaUno)
                    {
                        foreach (var label in panel.Controls)
                        {

                            if (label is Label)
                            {
                                Label lab = (Label)label;
                                lab.Text = "Panel Mesa uno";

                            }
                        }
                    }

                    else if (panel == this.panelCartaMesaUno)
                    {
                        foreach (var label in panel.Controls)
                        {

                            if (label is Label)
                            {
                                Label lab = (Label)label;
                                lab.Text = "Panel Mesa uno";

                            }
                        }
                    }
                    else
                    {

                        foreach (var label in panel.Controls)
                        {

                            if (label is Label)
                            {
                                Label lab = (Label)label;
                                lab.Text = count.ToString();

                            }
                        }
                    }
                }

                count++;

     
            }
*/
        }

        public event EventHandler EventoIniciarPartida;
        public event EventHandler EventoAbandonarPartida;
        public event EventHandler EventoEstadisticas;
        public event EventHandler EventoPanelHuecoUno;
        public event EventHandler EventoPanelHuecoDos;
        public event EventHandler EventoPanelHuecoTres;
        public event EventHandler EventoPanelHuecoCuatro;
        public event EventHandler EventoPanelHuecoCinco;
        public event EventHandler EventoPanelHuecoSeis;
        public event EventHandler EventoPanelMesonUno;
        public event EventHandler EventoPanelMesonDos;
        public event EventHandler EventoPanelMesonTres;
        public event EventHandler EventoPanelMesonCuatro;
        public event EventHandler EventoBotonVerificarCartas;
        public event EventHandler EventoBotonPasarTurno;
        public event EventHandler EventoPanelJugadorUno;
        public event EventHandler EventoPanelJugadorDos;
        public event EventHandler EventoPanelJugadorTres;

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panelHuecoUno_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panelHuecoUno_Click(object sender, EventArgs e)
        {
            List<String> lista = new List<String>();

            foreach (var label in panelHuecoUno.Controls)
            {
                if (label is Label)
                {
                    lista.Add(((Label)label).Text);
                }
            }


            this.panelHuecoUno.BackColor = seleccionado ? Color.Red : Color.White;
            seleccionado = seleccionado == false ? true : false;
        }

        private void panelCartaMesaUno_Click(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Text = "hola";
            //label.Location = new System.Drawing.Point(18, 18);


            this.panelCartaMesaUno.Controls.Add(label);

            this.panelCartaMesaUno.BackColor = Color.Red;
        }

        private void panelCartaMesaUno_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
