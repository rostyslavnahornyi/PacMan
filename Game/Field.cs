using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;
using XamlAnimatedGif;

namespace PacMan_GUI_WPF
{
    class Field
    {
        private int sizeMapX = 49;
        private int sizeMapY = 35;

        public static string SelectedMap = "map1";

        private static string[] txtLines;
        public static char[,] entitiesArr;

        private static double PosLeft;
        private static int PosTop;

        private static int number = 1;

        Canvas CanvasField;

        public Field(Canvas CanvasField)
        {
            this.CanvasField = CanvasField;

            FillArr();
            Draw();
        }


        private void Draw()
        {
            for (int y = entitiesArr.GetUpperBound(1); y >= 0; y--)
            {
                for (int x = 0; x < entitiesArr.GetUpperBound(0) + 1; x++)
                {
                    if (entitiesArr[x, y] == Constants.Wall)
                    {
                        Rectangle rectangle = new Rectangle()
                        {
                            Name = "Wall",
                            Width = Wall.Width,
                            Height = Wall.Height,
                            Stroke = Wall.StrokeBackground,
                            StrokeThickness = Wall.Stroke
                        };
                        Canvas.SetLeft(rectangle, PosLeft);
                        Canvas.SetTop(rectangle, PosTop);
                        CanvasField.Children.Add(rectangle);
                    }else  if (entitiesArr[x, y] == Constants.Coin)
                    {
                        Ellipse ellipse = new Ellipse()
                        {
                            Name = "Coin",
                            Width = Coin.Width,
                            Height = Coin.Height,
                            Fill = Coin.Background
                        };
                        Canvas.SetLeft(ellipse, PosLeft + 4);
                        Canvas.SetTop(ellipse, PosTop + 4);
                        CanvasField.Children.Add(ellipse);
                    }
                    else if (entitiesArr[x, y] == Constants.PacMan)
                    {
                        Image image = new Image()
                        {
                            Name = "Pacman",
                            Width = Pacman.Width,
                            Height = Pacman.Height

                        };
                        string url = "C:/Users/Rostyslav/Desktop/GIT/PacMan/Resources/Images/pacman.gif";
                        AnimationBehavior.SetSourceUri(image, new Uri(url));
                        Canvas.SetLeft(image, PosLeft);
                        Canvas.SetTop(image, PosTop);
                        CanvasField.Children.Add(image);
                    }else  if (entitiesArr[x, y] == Constants.Ghost)
                    {
                        Image image = new Image()
                        {
                            Name = "Pacman",
                            Width = Pacman.Width,
                            Height = Pacman.Height

                        };
                        string url = $"C:/Users/Rostyslav/Desktop/GIT/PacMan/Resources/Images/ghost{number.ToString()}.gif";
                        AnimationBehavior.SetSourceUri(image, new Uri(url));
                        Canvas.SetLeft(image, PosLeft);
                        Canvas.SetTop(image, PosTop);
                        CanvasField.Children.Add(image);

                        number++;
                    }
                    else
                    {
                        Rectangle rectangle = new Rectangle()
                        {
                            Name = "Space",
                            Width = Wall.Width,
                            Height = Wall.Height,
                            Stroke = Brushes.Black,
                            StrokeThickness = Wall.Stroke
                        };
                        Canvas.SetLeft(rectangle, PosLeft);
                        Canvas.SetTop(rectangle, PosTop);
                        CanvasField.Children.Add(rectangle);
                    }
                    PosLeft += Wall.Width + 1;
                }
                PosLeft = (((int)CanvasField.ActualWidth - Wall.Width * sizeMapX - sizeMapX) / 2) + 1;
                PosTop += Wall.Height + 1;
            }
            number = 1;
        }

        private void FillArr()
        {
            txtLines = File.ReadAllLines($"../../Resources/Maps/{SelectedMap}.txt");
            entitiesArr =  new char[txtLines[0].Length, txtLines.Length];

            for (int i = 0; i < txtLines[0].Length; i++)
            {
                for (int j = 0; j < txtLines.Length; j++)
                {
                    entitiesArr[i, j] = txtLines[j][i];
                }
            }

            PosLeft = (((int)CanvasField.ActualWidth - Wall.Width * sizeMapX - sizeMapX) / 2) + 1;
            PosTop = (((int)CanvasField.ActualHeight - Wall.Height * sizeMapY - sizeMapY) / 2) + 1;
        }

        public void Clear()
        {

        }
    }
}
