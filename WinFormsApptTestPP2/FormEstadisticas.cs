using Libreria.Entidades;
using Modelo.Entidades;
using Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApptTestPP2
{
    public partial class FormEstadisticas : Form
    {

        private PartidaRepositorio repositorioPartida;
        private JugadorRepositorio repositorioJugador;

        public FormEstadisticas()
        {
            this.repositorioPartida = new PartidaRepositorio();
            this.repositorioJugador = new JugadorRepositorio();

            InitializeComponent();
            CargarTablaTop15();
        }

        private void FormEstadisticas_Load(object sender, EventArgs e)
        {
            this.comboBoxPartidas.DataSource = this.repositorioPartida.obtenerTodo();
            CargarTabla();
        }
        public void CargarTabla()
        {
            if (this.comboBoxPartidas.SelectedIndex == -1)
            {
                return;
            }

            Partida partida = (Partida) this.comboBoxPartidas.Items[this.comboBoxPartidas.SelectedIndex];

            this.dataGridViewJugadores.DataSource = null;
            this.dataGridViewJugadores.Rows.Clear();

            foreach (var aux in partida.Jugadores)
            {

                int indice = this.dataGridViewJugadores.Rows.Add();
                this.dataGridViewJugadores.Rows[indice].Cells[0].Value = aux.Id;
                this.dataGridViewJugadores.Rows[indice].Cells[1].Value = aux.Nombre;
                this.dataGridViewJugadores.Rows[indice].Cells[2].Value = aux.Alias; // crucero
                this.dataGridViewJugadores.Rows[indice].Cells[3].Value = aux.Estadisticas.PartidasGanadas ; // fecha de viaje
                this.dataGridViewJugadores.Rows[indice].Cells[4].Value = aux.Estadisticas.PartidasPerdidas; // Estado
                this.dataGridViewJugadores.Rows[indice].Cells[5].Value = aux.Estadisticas.PartidasAbandonadas; // Estado
                this.dataGridViewJugadores.Rows[indice].Cells[6].Value = aux.Estadisticas.PartidasTotales; // Estado
            }

        }

        public void CargarTablaTop15()
        {

            List<Jugador> listaJugadores = this.repositorioPartida.ConsultarPorPartidasGanadas_Top(); 
            this.dataGridView2.DataSource = null;
            this.dataGridView2.Rows.Clear();

            int posicion = 0;
            foreach (var aux in listaJugadores)
            {
                posicion++;
                int indice = this.dataGridView2.Rows.Add();
                this.dataGridView2.Rows[indice].Cells[0].Value = posicion;
                this.dataGridView2.Rows[indice].Cells[1].Value = aux.Nombre;
                this.dataGridView2.Rows[indice].Cells[2].Value = aux.Alias; // crucero
                this.dataGridView2.Rows[indice].Cells[3].Value = aux.Estadisticas.PartidasGanadas;
            }
        }


        private void comboBoxPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTabla();
        }

        private void btnSalirEstadistica_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
