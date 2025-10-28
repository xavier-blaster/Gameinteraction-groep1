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

namespace Gameinteraction_groep1
{
    /// <summary>
    /// DifficultyWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DifficultyWindow : Window
    {
        public DifficultyWindow()
        {
            InitializeComponent();

            knop3x3.Click += knop3x3methode;               // verbind knopen aan methoden, zodat je op deze knop klikt, wordt deze methode gestart.
            knop4x4.Click += knop4x4methode;


            homeknop.Click += homeknopmethode;
            scoreknop.Click += scoreknopmethode;
            uitlegknop.Click += uitlegknopmethode;

        }

        private void knop3x3methode (object sender, RoutedEventArgs e)    //knop3x3methode
        {
            MainWindow game3x3 = new MainWindow ();         // GameWindow3x3 later vervangen met echt vensternaam,  variabelnaam die zelf kan kiezen,  new + vensternaam.
            game3x3.Show();               // opent dat venster
            this.Close ();
        }

        private void knop4x4methode(object sender, RoutedEventArgs e)    //knop4x4methode
        {
            GameWindow4x4 game4x4 = new GameWindow4x4();         
            game4x4.Show();
            this.Close();
        }


        private void homeknopmethode (object sender, RoutedEventArgs e)    //homeknopmethode
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
