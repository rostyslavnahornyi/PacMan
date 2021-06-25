using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        public static string SelectedMap = "map1";

        private static string[] txtLines;
        public static Entity[,] entitiesArr;

        public static int sizeMapX = 49;
        public static int sizeMapY = 35;

        public static int marginEntity = 1;

        private static int PosLeft;
        private static int PosTop;

        private static int numberGhost = 1;

        Canvas CanvasField;

        public Field(Canvas CanvasField)
        {
            this.CanvasField = CanvasField;

            FillArr();
            Draw();
        }

        public void FillArr()
        {
            txtLines = File.ReadAllLines($"../../Resources/Maps/{SelectedMap}.txt");
            entitiesArr = new Entity[txtLines[0].Length, txtLines.Length];

            for (int i = 0; i < txtLines[0].Length; i++)
            {
                for (int j = 0; j < txtLines.Length; j++)
                {
                    if (txtLines[j][i] == Constants.PacMan)
                    {
                        entitiesArr[i, j] = new Pacman();
                    }
                    if (txtLines[j][i] == Constants.Ghost)
                    {
                        entitiesArr[i, j] = new Ghost(i, j, numberGhost);
                        numberGhost++;
                    }
                    if (txtLines[j][i] == Constants.Wall)
                    {
                        entitiesArr[i, j] = new Wall();
                    }
                    if (txtLines[j][i] == Constants.Coin)
                    {
                        entitiesArr[i, j] = new Coin();
                    }
                    if (txtLines[j][i] == Constants.RandomWall)
                    {
                        entitiesArr[i, j] = new RandomWall();
                    }
                }
            }
            numberGhost = 1;
            PosLeft = (((int)CanvasField.ActualWidth - Entity.Width * sizeMapX - sizeMapX) / 2) + marginEntity;
            PosTop = (((int)CanvasField.ActualHeight - Entity.Height * sizeMapY - sizeMapY) / 2) + marginEntity;
        }

        public void Draw()
        {
            for (int y = 0; y < entitiesArr.GetUpperBound(1) + 1; y++)
            {
                for (int x = 0; x < entitiesArr.GetUpperBound(0) + 1; x++)
                {
                    if (entitiesArr[x, y].ch == Constants.Wall)
                    {
                        if (x == 0 || x == entitiesArr.GetUpperBound(0) || y == 0 || y == entitiesArr.GetUpperBound(1))
                        {
                            Rectangle rectangle = new Rectangle()
                            {
                                Name = "Wall",
                                Width = Entity.Width,
                                Height = Entity.Height,
                                Stroke = Wall.StrokeBackgroundBoundary,
                                StrokeThickness = Wall.Stroke
                            };
                            Canvas.SetLeft(rectangle, PosLeft);
                            Canvas.SetTop(rectangle, PosTop);
                            CanvasField.Children.Add(rectangle);
                        } else
                        {
                            Rectangle rectangle = new Rectangle()
                            {
                                Name = "Wall",
                                Width = Entity.Width,
                                Height = Entity.Height,
                                Stroke = Wall.StrokeBackground,
                                StrokeThickness = Wall.Stroke
                            };
                            Canvas.SetLeft(rectangle, PosLeft);
                            Canvas.SetTop(rectangle, PosTop);
                            CanvasField.Children.Add(rectangle);
                        }                        
                    }
                    else if (entitiesArr[x, y].ch == Constants.RandomWall)
                    {
                        {
                            Rectangle rectangle = new Rectangle()
                            {
                                Name = "RandomWall",
                                Width = Entity.Width,
                                Height = Entity.Height,
                                Stroke = RandomWall.StrokeBackground,
                                StrokeThickness = RandomWall.Stroke
                            };
                            Canvas.SetLeft(rectangle, PosLeft);
                            Canvas.SetTop(rectangle, PosTop);
                            CanvasField.Children.Add(rectangle);
                        }
                    }
                    else if (entitiesArr[x, y].ch == Constants.Coin)
                    {
                        Ellipse ellipse = new Ellipse()
                        {
                            Name = "Coin",
                            Width = Coin._Width,
                            Height = Coin._Height,
                            Fill = Coin.Background
                        };
                        Canvas.SetLeft(ellipse, PosLeft + 6);
                        Canvas.SetTop(ellipse, PosTop + 6);
                        CanvasField.Children.Add(ellipse);
                    }
                    else if (entitiesArr[x, y].ch == Constants.PacMan)
                    {
                        Image image = new Image()
                        {
                            Name = "Pacman",
                            Width = Entity.Width,
                            Height = Entity.Height

                        };

                        string path = Directory.GetCurrentDirectory();
                        AnimationBehavior.SetSourceUri(image, new Uri(path + "/Resources/Images/pacman.gif")); // добавить текущую папку + путь к файл

                        Canvas.SetLeft(image, PosLeft);
                        Canvas.SetTop(image, PosTop);
                        Canvas.SetZIndex(image, 3);
                        CanvasField.Children.Add(image);
                    }
                    else if (entitiesArr[x, y].ch == Constants.Ghost)
                    {
                        Image image = new Image()
                        {
                            Name = $"Ghost{numberGhost}",
                            Width = Entity.Width,
                            Height = Entity.Height,
                        };
                        string path = Directory.GetCurrentDirectory();
                        AnimationBehavior.SetSourceUri(image, new Uri(path + $"/Resources/Images/ghost{numberGhost.ToString()}.gif"));
                        Canvas.SetLeft(image, PosLeft);
                        Canvas.SetTop(image, PosTop);
                        Canvas.SetZIndex(image, 3);
                        CanvasField.Children.Add(image);
                        
                        numberGhost++;
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
                    PosLeft += Entity.Width + marginEntity;
                }
                PosLeft = (((int)CanvasField.ActualWidth - Entity.Width * Field.sizeMapX - Field.sizeMapX) / 2) + marginEntity;
                PosTop += Entity.Height + marginEntity;
            }
            numberGhost = 1;
        }

        public static int[] FindPacmanCoordinates()
        {
            int[] arr = new int[2];
            for (int i = 0; i < Field.entitiesArr.GetUpperBound(1) + 1; i++)
            {
                for (int j = 0; j < Field.entitiesArr.GetUpperBound(0) + 1; j++)
                {
                    if (Field.entitiesArr[j, i].ch == Constants.PacMan)
                    {
                        arr[0] = j;
                        arr[1] = i;
                    }
                }
            }
            return arr;
        }

        public static void FindGhostsCoordinates()
        {
            for (int i = 0; i < Field.entitiesArr.GetUpperBound(1) + 1; i++)
            {
                for (int j = 0; j < Field.entitiesArr.GetUpperBound(0) + 1; j++)
                {                    
                    if (Field.entitiesArr[j, i].ch == Constants.Ghost)
                    {
                        Ghost ghost = (Ghost)Field.entitiesArr[j, i];
                        if (ghost.queue == 1)
                        {
                            Ghost.Ghost1.Item1 = j;
                            Ghost.Ghost1.Item2 = i;
                        }
                        if (ghost.queue == 2)
                        {
                            Ghost.Ghost2.Item1 = j;
                            Ghost.Ghost2.Item2 = i;
                        }
                        if (ghost.queue == 3)
                        {
                            Ghost.Ghost3.Item1 = j;
                            Ghost.Ghost3.Item2 = i;
                        }
                    }
                }
            }
        }
    }
}
