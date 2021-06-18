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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PrintSpace(int X, int Y)
        {
            Rectangle rectangle = new Rectangle()
            {
                Name = "Space",
                Width = Entity.Width,
                Height = Entity.Height,
                Fill = Space.Background
            };
            int x = X * (Entity.Width + Field.marginEntity) + (((int)CanvasField.ActualWidth - Entity.Width * Field.sizeMapX - Field.sizeMapX) / 2) + Field.marginEntity;
            int y = Y * (Entity.Width + Field.marginEntity) + (((int)CanvasField.ActualHeight - Entity.Height * Field.sizeMapY - Field.sizeMapY) / 2) + Field.marginEntity;
            Canvas.SetLeft(rectangle, x);
            Canvas.SetTop(rectangle, y);
            CanvasField.Children.Add(rectangle);
            Canvas.SetZIndex(rectangle, 2);
        }

        private void PrintCoin(int X, int Y)
        {
            Ellipse ellipse = new Ellipse()
            {
                Name = "Coin",
                Width = Coin._Width,
                Height = Coin._Height,
                Fill = Coin.Background
            };
            int x = X * (Entity.Width + Field.marginEntity) + (((int)CanvasField.ActualWidth - Entity.Width * Field.sizeMapX - Field.sizeMapX) / 2) + Field.marginEntity;
            int y = Y * (Entity.Width + Field.marginEntity) + (((int)CanvasField.ActualHeight - Entity.Height * Field.sizeMapY - Field.sizeMapY) / 2) + Field.marginEntity;
            Canvas.SetLeft(ellipse, x + 6);
            Canvas.SetTop(ellipse, y + 6);
            CanvasField.Children.Add(ellipse);
            Canvas.SetZIndex(ellipse, 2);
        }

        private void PacmanLoop(object sender, EventArgs e)
        {
            UIElement pacman = null;
            foreach (var el in CanvasField.Children.OfType<Image>())
            {
                if (el.Name == "Pacman")
                {
                    pacman = el;
                    break;
                }
            }

            if (Pacman.direction == "RIGHT" && Field.entitiesArr[Pacman.x + 1, Pacman.y].ch != Constants.Wall)
            {
                MovingTo(1, 0, "RIGHT");
            }
            else if (Pacman.direction == "LEFT" && Field.entitiesArr[Pacman.x - 1, Pacman.y].ch != Constants.Wall)
            {
                MovingTo(-1, 0, "LEFT");
            }
            else if (Pacman.direction == "UP" && Field.entitiesArr[Pacman.x, Pacman.y - 1].ch != Constants.Wall)
            {
                MovingTo(0, -1, "UP");
            }
            else if (Pacman.direction == "DOWN" && Field.entitiesArr[Pacman.x, Pacman.y + 1].ch != Constants.Wall)
            {
                MovingTo(0, 1, "DOWN");
            }

            void MovingTo(int X, int Y, string direction)
            {       
                if (Field.entitiesArr[Pacman.x + X, Pacman.y + Y].ch == Constants.Ghost)
                {
                    Threading.Stop();
                    End.Visibility = Visibility.Visible;
                    Settings.gameIsStarted = false;
                    ButtonRestart.IsEnabled = true;
                    ButtonSetting.IsEnabled = true;
                }
                else if (Field.entitiesArr[Pacman.x + X, Pacman.y + Y].ch == Constants.Coin)
                {
                    Field.entitiesArr[Pacman.x, Pacman.y] = new Space();
                    Pacman.x += X;
                    Pacman.y += Y;
                    PrintSpace(Pacman.x, Pacman.y);
                    Field.entitiesArr[Pacman.x, Pacman.y] = new Pacman();

                    Scores.currentCoins++;
                    LabelCoins.Content = $"Coins : {Scores.allCoins - Scores.currentCoins}";
                    LabelScore.Content = $"Score : {Scores.currentCoins}";

                    MovingEntityTo(direction, "Pacman");
                }
                else if (Field.entitiesArr[Pacman.x + X, Pacman.y + Y].ch == Constants.Space)
                {
                    Field.entitiesArr[Pacman.x, Pacman.y] = new Space();
                    Pacman.x += X;
                    Pacman.y += Y;
                    Field.entitiesArr[Pacman.x, Pacman.y] = new Pacman();
                    MovingEntityTo(direction, "Pacman");
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

                Scores.steps++;
                LabelSteps.Content = $"Steps : {Scores.steps}";
            }            

            if (Scores.currentCoins == Scores.allCoins)
            {
                Threading.Stop();
                Win.Visibility = Visibility.Visible;
                Win.LoadedBehavior = MediaState.Manual;
                Win.Play();
                Settings.gameIsStarted = false;
                ButtonRestart.IsEnabled = true;
                ButtonSetting.IsEnabled = true;
            }
        }
        private void GhostLoop(Ghost ghost, string numberGhost)
        {
            lock (Util.locker)
            {
                string toGo = ghost.RandomizeNextDirection();
                ghost.direction = toGo;

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

                void MoveTo(int X, int Y)
                {
                    if (Field.entitiesArr[ghost.x + X, ghost.y + Y].ch != Constants.Wall)
                    {
                        if (ghost.previousCell.ch == Constants.Coin)
                        {
                            PrintCoin(ghost.x, ghost.y);
                        }
                        if (ghost.previousCell.ch == Constants.Space)
                        {
                            PrintSpace(ghost.x, ghost.y);
                        }
                        Entity currentGhost = Field.entitiesArr[ghost.x, ghost.y];
                        Field.entitiesArr[ghost.x, ghost.y] = ghost.previousCell;

                        ghost.x += X;
                        ghost.y += Y;

                        if (Field.entitiesArr[ghost.x + X, ghost.y + Y].ch == Constants.PacMan)
                        {
                            Threading.Stop();
                            End.Visibility = Visibility.Visible;
                            Settings.gameIsStarted = false;
                            ButtonRestart.IsEnabled = true;
                            ButtonSetting.IsEnabled = true;
                        }
                        else
                        {
                            MovingEntityTo(toGo, $"Ghost{numberGhost}");
                        }
                        ghost.previousCell = Field.entitiesArr[ghost.x, ghost.y];
                        Field.entitiesArr[ghost.x, ghost.y] = currentGhost;
                    }
                }                
            }
        }        
        void Start()
        {
            Pacman.x = Field.FindPacmanCoordinates()[0];
            Pacman.y = Field.FindPacmanCoordinates()[1];

            Threading.timer.Tick += dtTicker;
            Threading.pacman.Tick += PacmanLoop;
            Threading.ghost1.Tick += _Ghost1Loop;
            Threading.ghost2.Tick += _Ghost2Loop;
            Threading.ghost3.Tick += _Ghost3Loop;

            Threading.Start();

            LabelCoins.Content = $"Coins : {Scores.allCoins}";
            LabelScore.Content = $"Score : {Scores.currentCoins}";
            ButtonStart.IsEnabled = false;
        }

        private void _Ghost1Loop(object sender, EventArgs e) 
        {
            Ghost ghost = (Ghost)Field.entitiesArr[Field.FindGhostsCoordinates()[0][0], Field.FindGhostsCoordinates()[0][1]];
            GhostLoop(ghost, "1");
        }
        private void _Ghost2Loop(object sender, EventArgs e)
        {
            Ghost ghost = (Ghost)Field.entitiesArr[Field.FindGhostsCoordinates()[1][0], Field.FindGhostsCoordinates()[1][1]];
            GhostLoop(ghost, "2");
        }
        private void _Ghost3Loop(object sender, EventArgs e)
        {
            Ghost ghost = (Ghost)Field.entitiesArr[Field.FindGhostsCoordinates()[2][0], Field.FindGhostsCoordinates()[2][1]];
            GhostLoop(ghost, "3");
        }

        private void BtnStart(object sender, RoutedEventArgs e)
        {
            new Runner(CanvasField);
            Scores.secondsTimer = 0;
            Scores.minutesTimer = 0;
            Start();
            ButtonStart.IsEnabled = false;
            ButtonSetting.IsEnabled = false;
            LabelAttempts.Content = $"Attempts : {Settings.attempts}";
        }
        private void dtTicker(object sender, EventArgs e)
        {
            Scores.secondsTimer++;
            if (Scores.secondsTimer > 60)
            {
                Scores.minutesTimer++;
                Scores.secondsTimer = 0;
            }
            if (Scores.secondsTimer < 10)
            {
                LabelTime.Content = $"Time: 0{Scores.minutesTimer}:0{Scores.secondsTimer}";
            } else
            {
                LabelTime.Content = $"Time: 0{Scores.minutesTimer}:{Scores.secondsTimer}";
            }
        }
        private void BtnRestart(object sender, RoutedEventArgs e)
        {
            Threading.Stop();
            Pacman.direction = "STOP";

            Threading.timer.Tick -= dtTicker;
            Threading.pacman.Tick -= PacmanLoop;
            Threading.ghost1.Tick -= _Ghost1Loop;
            Threading.ghost2.Tick -= _Ghost2Loop;
            Threading.ghost3.Tick -= _Ghost3Loop;

            ClearElementsCanvas();

            if (Win.IsVisible == true) Win.Visibility = Visibility.Hidden;
            if (End.IsVisible == true) End.Visibility = Visibility.Hidden;

            new Runner(CanvasField);
            Scores.secondsTimer = 0;
            Scores.minutesTimer = 0;
            Start();
            Scores.FindAllCoins();
            ButtonRestart.IsEnabled = false;
            ButtonSetting.IsEnabled = false;
            Settings.attempts++;
            LabelAttempts.Content = $"Attempts : {Settings.attempts}";
        }
        private void BtnSetting(object sender, RoutedEventArgs e)
        {
            if (Settings.settingPoppupEnabled == false && Settings.gameIsStarted == false)
            {
                Threading.Stop();

                ButtonStart.IsEnabled = false;

                BlackBG.IsEnabled = true;
                BlackBG.Opacity = 0.5;

                BlackBGCanvas.IsEnabled = true;
                BlackBGCanvas.Opacity = 1;

                SettingsPoppup.IsEnabled = true;
                SettingsPoppup.Opacity = 1;

                ButtonRestart.IsEnabled = false;

                End.Visibility = Visibility.Hidden;
                Win.Visibility = Visibility.Hidden;

                Settings.settingPoppupEnabled = true;

            } else if (Settings.settingPoppupEnabled == true)
            {
                if (ButtonRestart.IsEnabled == true)
                {
                    ButtonRestart.IsEnabled = true;
                }

                ButtonStart.IsEnabled = true;

                BlackBG.IsEnabled = false;
                BlackBG.Opacity = 0;

                BlackBGCanvas.IsEnabled = false;
                BlackBGCanvas.Opacity = 0;

                SettingsPoppup.IsEnabled = false;
                SettingsPoppup.Opacity = 0;

                End.Visibility = Visibility.Hidden;
                Win.Visibility = Visibility.Hidden;

                Settings.settingPoppupEnabled = false;
                Threading.Start();
            }

            if (CheckboxDiffEasy.IsChecked == true)
            {
                Settings.speedGhosts = 1000;
            }
            if (CheckboxDiffMedium.IsChecked == true)
            {
                Settings.speedGhosts = 500;
            }
            if (CheckboxDiffHard.IsChecked == true)
            {
                Settings.speedGhosts = 250;
            }

            if (CheckboxBlue.IsChecked == true)
            {
                Wall.StrokeBackground = Brushes.Navy;
            }
            if (CheckboxRed.IsChecked == true)
            {
                Wall.StrokeBackground = Brushes.DarkRed;
            }
            if (CheckboxGreen.IsChecked == true)
            {
                Wall.StrokeBackground = Brushes.DarkGreen;
            }
            if (CheckboxArrow.IsChecked == true)
            {
                Settings.hotkeysMovingArrows = true;
                Settings.hotkeysMovingWasd = false;
            }
            if (CheckboxWasd.IsChecked == true)
            {
                Settings.hotkeysMovingArrows = false;
                Settings.hotkeysMovingWasd = true;
            }
        }
        private void BtnFAQ(object sender, RoutedEventArgs e)
        {
            if (Settings.FAQPoppupEnabled == false && Settings.settingPoppupEnabled == false)
            {
                Threading.Stop();
                BlackBG.IsEnabled = true;
                BlackBG.Opacity = 0.5;

                BlackBGCanvas.IsEnabled = true;
                BlackBGCanvas.Opacity = 1;

                FAQPoppup.IsEnabled = true;
                FAQPoppup.Opacity = 1;

                Settings.gameIsStarted = false;
                Settings.FAQPoppupEnabled = true;

            }
            else if (Settings.FAQPoppupEnabled == true)
            {
                BlackBG.IsEnabled = false;
                BlackBG.Opacity = 0;

                BlackBGCanvas.IsEnabled = false;
                BlackBGCanvas.Opacity = 0;

                FAQPoppup.IsEnabled = false;
                FAQPoppup.Opacity = 0;

                Settings.gameIsStarted = true;
                Settings.FAQPoppupEnabled = false;
                Threading.Start();
            }
        }
        private void BtnClose(object sender, RoutedEventArgs e)
        {
            if (Settings.gameIsStarted == true)
            {
                this.Close();
            }
        }


        private void ClearElementsCanvas()
        {
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
        }
        private void MovingEntityTo(string direction, string name)
        {
            UIElement element = null;
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
        private void CanvasKeyDown(object sender, KeyEventArgs e)
        {
            if (Settings.hotkeysMovingArrows == true)
            {
                if (e.Key == Key.Left)
                {
                    Pacman.direction = "LEFT";
                }
                if (e.Key == Key.Right)
                {
                    Pacman.direction = "RIGHT";
                }
                if (e.Key == Key.Up)
                {
                    Pacman.direction = "UP";
                }
                if (e.Key == Key.Down)
                {
                    Pacman.direction = "DOWN";
                }
            }

            if (Settings.hotkeysMovingWasd == true)
            {
                if (e.Key == Key.A)
                {
                    Pacman.direction = "LEFT";
                }
                if (e.Key == Key.D)
                {
                    Pacman.direction = "RIGHT";
                }
                if (e.Key == Key.W)
                {
                    Pacman.direction = "UP";
                }
                if (e.Key == Key.S)
                {
                    Pacman.direction = "DOWN";
                }
            }
        }
    }
}
