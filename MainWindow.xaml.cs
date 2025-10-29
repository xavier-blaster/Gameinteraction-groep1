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
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            DifficultyWindow DifficultyWindow = new DifficultyWindow();
            DifficultyWindow.Show();
            this.Close();
        }

        private void Scoreboard_Click(object sender, RoutedEventArgs e)
        {
            ScoreboardWindow ScoreboardWindow = new ScoreboardWindow();
            ScoreboardWindow.Show();
            this.Close();
        }
    }
}