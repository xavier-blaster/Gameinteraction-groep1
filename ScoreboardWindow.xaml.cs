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

namespace PuzzelGame
{
    /// <summary>
    /// Interaction logic for ScoreboardWindow.xaml
    /// </summary>
    public partial class ScoreboardWindow : Window
    {

        public ScoreboardWindow()
        {
            InitializeComponent();

            homeknop.Click += homeknopmethode;
           
            uitlegknop.Click += uitlegknopmethode;
        }

        //public ScoreboardWindow(string tijd, string difficulty, string datum)         // tijdsdruk, laat deze stuk weg. Dus Scorebord laat alleen maar een voorbeeld zien.
        //{

        //    // Tekst in het scoreboard zetten
        //    regel1.Text = $"{tijd}        {difficulty}        {datum}";

        //}



        //later vervangen met echt vensternaam,  variabelnaam die zelf kan kiezen,  new + vensternaam.
        private void homeknopmethode(object sender, RoutedEventArgs e)    //homeknopmethode
        {
            MainWindow terugnaarhome = new MainWindow();
            terugnaarhome.Show();
            this.Close();
        }

     


        private void uitlegknopmethode(object sender, RoutedEventArgs e)    // uitlegknopmethode
        {
            HowToPlay terugnaaruitleg = new HowToPlay();
            terugnaaruitleg.Show();
            this.Close();
        }


    }
}
