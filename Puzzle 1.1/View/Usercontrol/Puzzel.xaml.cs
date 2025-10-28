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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Puzzle_1._1.View.Usercontrol
{
    /// <summary>
    /// Interaction logic for Puzzel.xaml
    /// </summary>
    public partial class Puzzel : UserControl
    {
        public int[,] mapGrid = new int[4, 4];
        List<int> allNums = new List<int>();
        int[] tempNums = new int[16];
        int[] goal = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, -1};


        public Puzzel()
        {
            InitializeComponent();
        }

        private void Puzzel_Load(object sender, EventArgs e)
        {
            Boolean validGame = false;

            do
            {
                buildList();
            }
            while (!validGame);
            setGrid();
            setPictures();
        }


        private void buildList()
        {
            for (int i = 1; i < 16; i++)
             
            {
                allNums.Add(i);
            }

            allNums.Add(-1);
        }

        private Boolean buildArray()
        {
            Random rndNum = new Random();
            int index = 0;
            int blankRow = 0;
            int inversions = 0;
            int blankIndex = 0;


            ///Ranomizer code
            for (int i = 0; i < 16; i++)
            {
                index = rndNum.Next(0, allNums.Count);
                tempNums[i] = allNums[index];
                allNums.RemoveAt(index);

                if (tempNums[i] == -1)
                {
                    blankIndex = i;
                }

            }
            for (int i = 0; i < tempNums.Length; i++)
            {
                if (tempNums[i] != -1)
                {
                    for (int j = i + 1; j <tempNums.Length; j++)
                    {
                        if (tempNums[j] != -1)
                        {
                            if (tempNums[i] > tempNums[j])
                            {
                                inversions++;
                            }
                        }
                    }
                }

            }

            blankRow = 4 - (blankIndex / 4);
            if ((blankRow % 2 == 0 && inversions % 2 == 1) || (blankRow % 2 == 1 && inversions % 2 == 0)) 
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void setGrid()
        {
            int value = 0;
            int index = 0;

            for(int i =0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    value = tempNums[index];
                    mapGrid[i, j] = value;
                    index++;
                }
            }
        }
        private void setPictures()
        {
                Image[] pics = {Picture1, Picture2, Picture3, 
                Picture4, Picture5, Picture6, Picture7, 
                Picture8, Picture9, Picture10, Picture11, 
                Picture12, Picture13, Picture14, Picture15, Picture16};

            int picIndex = 0;
            int index = 0;
            string imageName = "";
            int value = 0;

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    value = mapGrid[row, col];

                    if (value == -1)
                    {
                        imageName = "blank";
                    }
                    else
                    {
                        imageName = "_" + value.ToString();
                    }
                    pics[index].Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
                    index++;

                    pics[picIndex].Tag = new Point(row, col);
                    pics[picIndex].Click += Tile_Click();
                    picIndex++
                }

            }
        }

        private bool Tile_Click(object sender, EventArgs e)
        {
            int row;
            int newRow;
            int col = 0;
            int newCol = 0;

            PictureBox clickedPic = (PictureBox)sender;
            Point posistion = (Point)clickedPic;
            row = position.X;
            col = position.Y;

            Point[] directions = { new Point(-1, 0), new Point(1, 0), new Point(0, -1), new Point(0, 1) };

            foreach(Point direction in directions)
            {
                newRow = (int)(row + direction.X);
                newCol = (int)(col + direction.Y);

                if (newRow >= 0 && newRow < 4 && newCol >= 0 && newCol <4)
                {
                    if (mapGrid[newRow, newCol] == -1)
                    {
                        mapGrid[newRow, newCol] = mapGrid[row, col];
                        bool v = mapGrid[row, col] == -1;

                        setPictures();
                        checkWin();
                        break;
                    }
                }
            }

        }

        private void checkWin()
        {
            int index = 0;

            for(int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (mapGrid[i, j] != goal[index])
                    {
                        return;
                    }
                    else
                    {
                        index++;
                    }
                }
            }
            MessageBox.Show("You won the game!");
        }
    }
}
