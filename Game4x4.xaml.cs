using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace PuzzelGame
{
    public partial class game4x4 : Window
    {
        public DispatcherTimer dispatcherTimer;
        public int elapsedSeconds = 0;
        public Random random = new Random();

        public game4x4()
        {
            InitializeComponent();
            RandomizeImages();
            StartTimer();
        }
        private void StartTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            elapsedSeconds++;
            int minutes = elapsedSeconds / 60;
            int seconds = elapsedSeconds % 60;
            Timer.Content = $"{minutes:00}:{seconds:00}";
        }
        private void RandomizeImages()
        {
            var images = new List<Image>
            {
                Image1, Image2, Image3, Image4,
                Image5, Image6, Image7, Image8, 
                Image9, Image10, Image11, Image12, 
                Image13, Image14, Image15, Image0,
            };

            // Randomizer dmv Fisher-Yates Algo
            for (int i = images.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var temp = images[i];
                images[i] = images[j];
                images[j] = temp;
            }

            int index = 0;
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Grid.SetRow(images[index], row);
                    Grid.SetColumn(images[index], col);
                    index++;
                }
            }
        }

        private Image GetImageAt(int row, int col)
        {
            foreach (var child in PuzzleGrid.Children)
            {
                if (child is Image SortImages)
                {
                    if (Grid.GetRow(SortImages) == row && Grid.GetColumn(SortImages) == col)
                    {
                        return SortImages;
                    }
                }
            }
            return null;
        }

        private bool IsComplete()
        {
            string[] correctOrder = { "Image1", "Image2", "Image3", "Image4", "Image5", "Image6", "Image7", "Image8", "Image9", "Image10", "Image11", "Image12", "Image13", "Image14", "Image15", "Image0" };

            int index = 0;
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Image image = GetImageAt(row, col);
                    if (image == null || image.Name != correctOrder[index])
                    {
                        return false;
                    }
                    index++;
                }
            }

            return true;
        }


        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var image = sender as Image;
                if (image != null)
                {
                    DragDrop.DoDragDrop(image, image, DragDropEffects.Move);
                }
            }
        }

        private void Image_Drop(object sender, DragEventArgs e)
        {
            var target = sender as Image;
            var source = e.Data.GetData(typeof(Image)) as Image;

            if (source == null || target == null || source == target)
            {
                return;
            }

            int sourceRow = Grid.GetRow(source);
            int sourceCol = Grid.GetColumn(source);
            int targetRow = Grid.GetRow(target);
            int targetCol = Grid.GetColumn(target);

            bool isValid =
                (sourceRow == targetRow && Math.Abs(sourceCol - targetCol) == 1) ||
                (sourceCol == targetCol && Math.Abs(sourceRow - targetRow) == 1);

            if (!isValid)
                return;

            Grid.SetRow(source, targetRow);
            Grid.SetColumn(source, targetCol);
            Grid.SetRow(target, sourceRow);
            Grid.SetColumn(target, sourceCol);

            if (IsComplete())
            {
                dispatcherTimer.Stop();
                MessageBox.Show($"Puzzle Complete! Time: {Timer.Content}");
            }
        }
    }
}