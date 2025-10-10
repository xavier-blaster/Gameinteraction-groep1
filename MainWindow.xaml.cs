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

namespace Gameinteraction_groep1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Be able to pickup image
        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            // check if is mouse button is pressed down
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var image = sender as Image;
                if (image != null)
                {
                    DragDrop.DoDragDrop(image, image, DragDropEffects.Move);
                }
            // Anouk: Hier if statement maken voor blokken
            }
        }

        //get location of image and replace with location of dragged image
        private void Image_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Image)))
            {
                var target = sender as Image;
                var source = e.Data.GetData(typeof(Image)) as Image;

                // If placement is invalid do nothing
                if (source == null || target == null || source == target)
                    return;
                
                int sourceRow = Grid.GetRow(source);
                int sourceCol = Grid.GetColumn(source);
                int targetRow = Grid.GetRow(target);
                int targetCol = Grid.GetColumn(target);

                //get original location of image and replace it with target
                Grid.SetRow(source, targetRow);
                Grid.SetColumn(source, targetCol);
                Grid.SetRow(target, sourceRow);
                Grid.SetColumn(target, sourceCol);
            }
        }
    // Nieuwe methode voor timer
    // Nieuwe methode voor als je klaar bent
    // Als je tijd over hebt dan Randomizer methode toevoegen
    }
}

