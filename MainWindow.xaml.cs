using System.Collections;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrabajoIntegrador;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Jugador> jugadores = new List<Jugador>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddPlayerBtn(object sender, RoutedEventArgs e)
        {
            AddPlayerWindow dialog = new AddPlayerWindow();

            if (dialog.ShowDialog() == true)
            {
                jugadores.Add(dialog.NewPlayer);
            }
        }
        private void ListButton(object sender, RoutedEventArgs e)
        {
            if(jugadores.Count > 0)
            {
                ListTxTBox.Text = string.Empty;
                ListTxTBox.BorderThickness = new Thickness(1);
                switch (FilterCBox.Text)
                {
                    case "Alfabeticamente":
                        jugadores.Sort((p1, p2) => p1.Nombre.CompareTo(p2.Nombre));
                        break;
                    case "Por equipo":
                        jugadores.Sort((p1, p2) => p1.Equipo.CompareTo(p2.Equipo));
                        break;
                    default:
                        MessageBox.Show("Como hiciste eso?");
                        break;
                       
                }
                foreach (Jugador j in jugadores)
                {
                    ListTxTBox.Text += j;
                }
            }
            else
            {
                MessageBox.Show("No hay jugadores registrados");
            }
        }

        private void GenInformButton(object sender, RoutedEventArgs e)
        {
            double PromedioGoles()
            {
                int cantGoles = 0;
                foreach (Jugador j in jugadores)
                {
                    cantGoles += j.Goles;
                }
                return cantGoles / jugadores.Count;
            }
            double PromedioAsistencias()
            {
                int cantAsists = 0;
                foreach (Jugador j in jugadores)
                {
                    cantAsists += j.Asistencias;
                }
                return cantAsists / jugadores.Count;
            }
            void GolesPorEquipo()
            {
                Dictionary<String, int> GpE = new Dictionary<string, int>();
                int cantGoles = 0;
                foreach (Jugador j in jugadores)
                {
                    if (GpE.ContainsKey(j.Equipo))
                    {
                        GpE[j.Equipo] += j.Goles;
                    }
                    else
                    {
                        GpE.Add(j.Equipo, j.Goles);
                    }
                    cantGoles += j.Goles;

                }
                if (GpE.Count > 0 && cantGoles > 0)
                {
                    foreach (KeyValuePair<String, int> equipo in GpE)
                    {
                        ListTxTBox.Text += $"Porcentaje de goles del equipo '{equipo.Key}' sobre el total = {(double)(equipo.Value * 100 / cantGoles):n2}% con {equipo.Value} goles.";
                    }
                }
            }
            void JugadorMasPases()
            {
                Jugador j = new Jugador(0);
                foreach (Jugador p in jugadores)
                {
                    if (p.PasesTotales >= j.PasesTotales)
                        j = p;

                }
                ListTxTBox.Text += $"El Jugador con más pases es {j.Nombre} del equipo {j.Equipo} con {j.PasesTotales} pases totales.";
            }
            void JugadorMasFaltas()
            {
                Jugador j = new Jugador();
                j.FaltasRecibidas = 0;
                foreach (Jugador p in jugadores)
                {
                    if (p.FaltasRecibidas >= j.FaltasRecibidas)
                        j = p;
                }
                ListTxTBox.Text += $"El Jugador con más faltas es {j.Nombre} del equipo {j.Equipo} con {j.FaltasRecibidas} faltas recibidas.";
            }
            void JugadorMasLesiones()
            {
                Jugador j = new Jugador();
                j.LesionesSufridas = 0;
                foreach (Jugador p in jugadores)
                {
                    if (p.LesionesSufridas >= j.LesionesSufridas)
                        j = p;
                }
                ListTxTBox.Text += $"El Jugador con más lesiones es {j.Nombre} del equipo {j.Equipo} con {j.LesionesSufridas} lesiones sufridas.";
            }
            void JugadorMasCaroYMasBarato()
            {
                Jugador caro = new Jugador(0.0);
                Jugador barato = new Jugador(99999999.0);
                foreach (Jugador j in jugadores)
                {
                    if (j.ValorMercado >= caro.ValorMercado)
                    {
                        caro = j;
                    }
                    if (j.ValorMercado <= barato.ValorMercado)
                    {
                        barato = j;
                    }
                }
                ListTxTBox.Text += $"Jugador más caro = {caro.Nombre} del equipo {caro.Equipo} ==> ${caro.ValorMercado:n2}\n";
                if (!(barato.Nombre == "" || string.IsNullOrEmpty(barato.Nombre)))
                    ListTxTBox.Text += $"Jugador más barato = {barato.Nombre} del equipo {barato.Equipo} ==> ${barato.ValorMercado:n2}\n";
                else
                {
                    ListTxTBox.Text += "No existe un jugador más barato.\n";
                }
            }
            if (jugadores.Count>0)
            {
                ListTxTBox.BorderThickness = new Thickness(1);
                ListTxTBox.Background = new SolidColorBrush(Colors.White);
                ListTxTBox.Text = string.Empty;
                ListTxTBox.Text += $"PROMEDIO DE GOLES POR JUGADOR = {PromedioGoles():n2}\n";
                ListTxTBox.Text += $"PROMEDIO DE ASISTENCIAS POR JUGADOR = {PromedioAsistencias():n2}\n";
                GolesPorEquipo();
                ListTxTBox.Text += "\n";
                JugadorMasPases();
                ListTxTBox.Text += "\n";
                JugadorMasFaltas();
                ListTxTBox.Text += "\n";
                JugadorMasLesiones();
                ListTxTBox.Text += "\n";
                JugadorMasCaroYMasBarato();
                ListTxTBox.Text += "\n";
            }
            else
            {
                MessageBox.Show("No hay jugadores registrados");
            }
        }

    }
}