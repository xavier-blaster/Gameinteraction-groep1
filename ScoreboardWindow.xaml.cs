using System;
using System.Windows;

namespace Gameinteraction_groep1
{
    public partial class ScoreboardWindow : Window
    {

        public ScoreboardWindow()
        {
            InitializeComponent();

            homeknop.Click += homeknopmethode;
            scoreknop.Click += scoreknopmethode;
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
            menuwindow terugnaarhome = new menuwindow;
            terugnaarhome.Show();
            this.Close();
        }

        private void scoreknopmethode(object sender, RoutedEventArgs e)    // scoreknopmethode
        {
            scorewindow terugnaarscore = new scorewindow;
            terugnaarscore.Show();
            this.Close();
        }


        private void uitlegknopmethode(object sender, RoutedEventArgs e)    // uitlegknopmethode
        {
            uitlegwindow terugnaaruitleg = new uitlegwindow;
            terugnaaruitleg.Show();
            this.Close();
        }


    }
}
