using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TrabajoIntegrador;

namespace GUI
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class AddPlayerWindow : Window
    {
        public Jugador NewPlayer { get; private set; }
        public AddPlayerWindow()
        {
            InitializeComponent();
        }


        private void Accept(object sender, RoutedEventArgs e)
        {
            if (
                !string.IsNullOrEmpty(NameTxtBox.Text) && !string.IsNullOrEmpty(PositionCBox.Text) && !string.IsNullOrEmpty(TeamTxtBox.Text) &&
                !string.IsNullOrEmpty(BirthDP.Text) && !string.IsNullOrEmpty(NationalityTxtBox.Text) &&
                !string.IsNullOrEmpty(GoalsTxtBox.Text) && !string.IsNullOrEmpty(PassesTxtBox.Text) &&
                !string.IsNullOrEmpty(FoulsTxtBox.Text) && !string.IsNullOrEmpty(AssistsTxtBox.Text) &&
                !string.IsNullOrEmpty(LesionsTxtBox.Text) && !string.IsNullOrEmpty(MarketValueTxtBox.Text)
                )
            {
                if (int.TryParse(GoalsTxtBox.Text,out int goals) && int.TryParse(PassesTxtBox.Text, out int passes) 
                    && int.TryParse(FoulsTxtBox.Text, out int fouls) && int.TryParse(AssistsTxtBox.Text, out int assists)
                    && int.TryParse(LesionsTxtBox.Text, out int lesions) && double.TryParse(MarketValueTxtBox.Text, out double marketvalue))
                {
                    NewPlayer = new Jugador(NameTxtBox.Text,NationalityTxtBox.Text,PositionCBox.Text,TeamTxtBox.Text,
                        DateTime.Parse(BirthDP.Text),goals,assists,passes,fouls,lesions,marketvalue);
                    MessageBox.Show("Añadido!");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Formato de datos incorrecto");
                }
                
            }
            else
            {
                MessageBox.Show("Faltan Datos!");
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
