using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace PacMan_GUI_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private static int xPacman;
        private static int yPacman;



        public MainWindow()
        {
            InitializeComponent();

        }

        private void PacmanLoop(object sender, EventArgs e)
        {

            UIElement pacman = new UIElement();
            foreach (var el in CanvasField.Children.OfType<Image>())
            {
                if (el.Name == "Pacman")
                {
                    pacman = el;
                    break;
                }
            }
            Entity temp;

            void MovingTo(int X, int Y, string direction)
            {
                if (Field.entitiesArr[xPacman, yPacman].ch == Constants.Ghost)
                {
                    Threading.Stop();
                    End.Visibility = Visibility.Visible;
                }
                if (Field.entitiesArr[xPacman + X, yPacman + Y].ch == Constants.Ghost)
                {
                    Threading.Stop();
                    End.Visibility = Visibility.Visible;
                }
                else if (Field.entitiesArr[xPacman + X, yPacman + Y].ch == Constants.Coin)
                {
                    temp = Field.entitiesArr[xPacman, yPacman];
                    Field.entitiesArr[xPacman, yPacman] = new Space();
                    xPacman += X;
                    yPacman += Y;
                    Rectangle rectangle = new Rectangle()
                    {
                        Name = "Space",
                        Width = Entity.Width,
                        Height = Entity.Height,
                        Fill = Space.Background
                    };
                    int x = xPacman * (Entity.Width + Field.marginEntity) + (((int)CanvasField.ActualWidth - Entity.Width * Field.sizeMapX - Field.sizeMapX) / 2) + Field.marginEntity;
                    int y = yPacman * (Entity.Width + Field.marginEntity) + (((int)CanvasField.ActualHeight - Entity.Height * Field.sizeMapY - Field.sizeMapY) / 2) + Field.marginEntity;
                    Canvas.SetLeft(rectangle, x);
                    Canvas.SetTop(rectangle, y);
                    CanvasField.Children.Add(rectangle);
                    Canvas.SetZIndex(rectangle, 2);
                    Field.entitiesArr[xPacman, yPacman] = temp;
                    Scores.currentCoins++;
                    _MovingEntityTo(direction, "Pacman");
                }
                else if (Field.entitiesArr[xPacman + X, yPacman + Y].ch == Constants.Space)
                {
                    temp = Field.entitiesArr[xPacman, yPacman];
                    Field.entitiesArr[xPacman, yPacman] = new Space();
                    xPacman += X;
                    yPacman += Y;
                    Field.entitiesArr[xPacman, yPacman] = temp;
                    _MovingEntityTo(direction, "Pacman");
                }

                int Angle = 0;
                if (direction == "RIGHT")
                {
                    Angle = 0;
                } 
                else if (direction == "LEFT")
                {
                    Angle = -180;
                }
                else if (direction == "UP")
                {
                    Angle = -90;
                }
                else if (direction == "DOWN")
                {
                    Angle = 90;
                }
                pacman.RenderTransform = new RotateTransform(Angle, Entity.Width / 2, Entity.Height / 2);
            }

            if (Pacman.goRight && Field.entitiesArr[xPacman + 1, yPacman].ch != Constants.Wall)
            {
                MovingTo(1, 0, "RIGHT");
            }
            else if (Pacman.goLeft && Field.entitiesArr[xPacman - 1, yPacman].ch != Constants.Wall)
            {
                MovingTo(-1, 0, "LEFT");
            }
            else if (Pacman.goUp && Field.entitiesArr[xPacman, yPacman - 1].ch != Constants.Wall)
            {
                MovingTo(0, -1, "UP");
            }
            else if (Pacman.goDown && Field.entitiesArr[xPacman, yPacman + 1].ch != Constants.Wall)
            {
                MovingTo(0, 1, "DOWN");
            }

            if (Scores.currentCoins == Scores.allCoins)
            {
                Threading.Stop();
                Win.Visibility = Visibility.Visible;
            }
        }
        private void GhostLoop(Ghosts ghost, string numberGhost)
        {
            lock (Util.locker)
            {
                string toGo = ghost.RandomizeNextDirection();
                ghost.direction = toGo;

                void MoveTo(int X, int Y)
                {
                    if (Field.entitiesArr[ghost.x, ghost.y].ch == Constants.PacMan)
                    {
                        Threading.Stop();
                        End.Visibility = Visibility.Visible;
                    }
                    if (Field.entitiesArr[ghost.x + X, ghost.y + Y].ch != Constants.Wall)
                    {
                        if (ghost.tempCell.ch == Constants.Coin)
                        {
                            Ellipse ellipse = new Ellipse()
                            {
                                Name = "Coin",
                                Width = Coin._Width,
                                Height = Coin._Height,
                                Fill = Coin.Background
                            };
                            int x = ghost.x * (Entity.Width + Field.marginEntity) + (((int)CanvasField.ActualWidth - Entity.Width * Field.sizeMapX - Field.sizeMapX) / 2) + Field.marginEntity;
                            int y = ghost.y * (Entity.Width + Field.marginEntity) + (((int)CanvasField.ActualHeight - Entity.Height * Field.sizeMapY - Field.sizeMapY) / 2) + Field.marginEntity;
                            Canvas.SetLeft(ellipse, x + 6);
                            Canvas.SetTop(ellipse, y + 6);
                            CanvasField.Children.Add(ellipse);
                            Canvas.SetZIndex(ellipse, 2);
                        }
                        if (ghost.tempCell.ch == Constants.Space)
                        {
                            Rectangle rectangle = new Rectangle()
                            {
                                Name = "Space",
                                Width = Entity.Width,
                                Height = Entity.Height,
                                Fill = Space.Background
                            };
                            int _x = ghost.x * (Entity.Width + Field.marginEntity) + (((int)CanvasField.ActualWidth - Entity.Width * Field.sizeMapX - Field.sizeMapX) / 2) + Field.marginEntity;
                            int _y = ghost.y * (Entity.Width + Field.marginEntity) + (((int)CanvasField.ActualHeight - Entity.Height * Field.sizeMapY - Field.sizeMapY) / 2) + Field.marginEntity;
                            Canvas.SetLeft(rectangle, _x);
                            Canvas.SetTop(rectangle, _y);
                            CanvasField.Children.Add(rectangle);
                            Canvas.SetZIndex(rectangle, 2);
                        }
                        Entity tempGhost = Field.entitiesArr[ghost.x, ghost.y];
                        Field.entitiesArr[ghost.x, ghost.y] = ghost.tempCell;
                        ghost.x += X;
                        ghost.y += Y;
                        if (Field.entitiesArr[ghost.x + X, ghost.y + Y].ch == Constants.PacMan)
                        {
                            Threading.Stop();
                            End.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            _MovingEntityTo(toGo, $"Ghost{numberGhost}");
                        }
                        ghost.tempCell = Field.entitiesArr[ghost.x, ghost.y];
                        if (ghost.tempCell.ch == Constants.PacMan)
                        {
                            Threading.Stop();
                            End.Visibility = Visibility.Visible;
                        }
                        Field.entitiesArr[ghost.x, ghost.y] = tempGhost;
                    }
                }

                if (Field.entitiesArr[ghost.x, ghost.y].ch != Constants.Wall)
                {
                    if (toGo == "LEFT")
                    {
                        MoveTo(-1, 0);
                    }
                    if (toGo == "RIGHT")
                    {
                        MoveTo(1, 0);
                    }
                    if (toGo == "UP")
                    {
                        MoveTo(0, -1);
                    }
                    if (toGo == "DOWN")
                    {
                        MoveTo(0, 1);

                    }
                }
            }
        }
        private void _MovingEntityTo(string direction, string name)
        {
            UIElement element = new UIElement();
            foreach (var el in CanvasField.Children.OfType<Image>())
            {
                if (el.Name == name)
                {
                    element = el;
                    break;
                }
            }

            if (direction == "RIGHT")
            {
                Canvas.SetLeft(element, Canvas.GetLeft(element) + (Entity.Width + Field.marginEntity));
            }
            if (direction == "LEFT")
            {
                Canvas.SetLeft(element, Canvas.GetLeft(element) - (Entity.Width + Field.marginEntity));
            }
            if (direction == "UP")
            {
                Canvas.SetTop(element, Canvas.GetTop(element) - (Entity.Height + Field.marginEntity));
            }
            if (direction == "DOWN")
            {
                Canvas.SetTop(element, Canvas.GetTop(element) + (Entity.Height + Field.marginEntity));
            }
        }


        void Main()
        {
            xPacman = Field.FindPacmanCoordinates()[0];
            yPacman = Field.FindPacmanCoordinates()[1];
            Threading.pacman.Tick += PacmanLoop;
            Threading.ghost1.Tick += _Ghost1Loop;
            Threading.ghost2.Tick += _Ghost2Loop;
            Threading.ghost3.Tick += _Ghost3Loop;
            Threading.Start();            
        }

        private void _Ghost1Loop(object sender, EventArgs e) 
        {
            Ghosts ghost = (Ghosts)Field.entitiesArr[Field.FindGhostsCoordinates()[0][0], Field.FindGhostsCoordinates()[0][1]];
            GhostLoop(ghost, "1");
        }
        private void _Ghost2Loop(object sender, EventArgs e)
        {
            Ghosts ghost = (Ghosts)Field.entitiesArr[Field.FindGhostsCoordinates()[1][0], Field.FindGhostsCoordinates()[1][1]];
            GhostLoop(ghost, "2");
        }
        private void _Ghost3Loop(object sender, EventArgs e)
        {
            Ghosts ghost = (Ghosts)Field.entitiesArr[Field.FindGhostsCoordinates()[2][0], Field.FindGhostsCoordinates()[2][1]];
            GhostLoop(ghost, "3");
        }

        private void SelectMap1(object sender, RoutedEventArgs e)
        {

        }

        private void SelectMap2(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnStart(object sender, RoutedEventArgs e)
        {
            new Runner(CanvasField);
            Main();
        }

        private void BtnRestart(object sender, RoutedEventArgs e)
        {
            Threading.Stop();
            Threading.pacman.Tick += PacmanLoop;
            Threading.ghost1.Tick -= _Ghost1Loop;
            Threading.ghost2.Tick -= _Ghost2Loop;
            Threading.ghost3.Tick -= _Ghost3Loop;
            int coins = 0;
            int rects = 0;
            foreach (var el in CanvasField.Children.OfType<Rectangle>())
            {
                if (el.Name == "Wall" || el.Name == "Space")
                {
                    rects++;
                }
            }
            foreach (var el in CanvasField.Children.OfType<Ellipse>())
            {
                if (el.Name == "Coin")
                {
                    coins++;
                }
            }

            for (int i = 0; i < coins + rects; i++)
            {
                foreach (var el in CanvasField.Children.OfType<Rectangle>())
                {
                    if (el.Name == "Wall" || el.Name == "Space")
                    {
                        CanvasField.Children.Remove(el);
                        break;
                    }
                }
                foreach (var el in CanvasField.Children.OfType<Ellipse>())
                {
                    if (el.Name == "Coin")
                    {
                        CanvasField.Children.Remove(el);
                        break;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                foreach (var el in CanvasField.Children.OfType<Image>())
                {
                    if (el.Name == "Pacman" || el.Name == "Ghost1" || el.Name == "Ghost2" || el.Name == "Ghost3")
                    {
                        CanvasField.Children.Remove(el);
                        break;
                    }
                }
            }

            Main();
        }

        private void CanvasKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left )
            {
                Pacman.goRight = Pacman.goUp = Pacman.goDown = false;
                Pacman.goLeft = true;
            }

            if (e.Key == Key.Right )
            {
                Pacman.goLeft = Pacman.goUp = Pacman.goDown = false; 
                Pacman.goRight = true; 
            }

            if (e.Key == Key.Up )
            {
                Pacman.goDown = Pacman.goLeft = Pacman.goRight = false;
                Pacman.goUp = true;
            }

            if (e.Key == Key.Down )
            {
                Pacman.goUp = Pacman.goLeft = Pacman.goRight = false;
                Pacman.goDown = true;
            }
        }
    }
}
