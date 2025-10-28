using System.Windows;
using System.Windows.Input;

namespace PuzzelGame
{
    public partial class HowToPlay : Window
    {
        public HowToPlay()
        {
            InitializeComponent();

            homeknop.Click += homeknopmethode;
            scoreknop.Click += scoreknopmethode;
        }

        private void homeknopmethode(object sender, RoutedEventArgs e)    //homeknopmethode
        {
            MainWindow terugnaarhome = new MainWindow();
            terugnaarhome.Show();
            this.Close();
        }

        private void scoreknopmethode(object sender, RoutedEventArgs e)    // scoreknopmethode
        {
            ScoreboardWindow terugnaarscore = new ScoreboardWindow();
            terugnaarscore.Show();
            this.Close();
        }
    }
}
