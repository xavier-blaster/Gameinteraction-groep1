using PuzzelGame;
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

namespace PuzzelGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            scoreknop.Click += scoreknopmethode;
            uitlegknop.Click += uitlegknopmethode;

        }
        private void scoreknopmethode(object sender, RoutedEventArgs e)    // scoreknopmethode
        {
            ScoreboardWindow terugnaarscore = new ScoreboardWindow();
            terugnaarscore.Show();
            this.Close();
        }


        private void uitlegknopmethode(object sender, RoutedEventArgs e)    // uitlegknopmethode
        {
            HowToPlay terugnaaruitleg = new HowToPlay();
            terugnaaruitleg.Show();
            this.Close();
        }

        private void Play_Click(object sender, MouseButtonEventArgs e)
        {
            DifficultyWindow window = new DifficultyWindow();
            window.Show(); // lowercase 'w'
            this.Close();  // closes Startscherm
        }

    }
}