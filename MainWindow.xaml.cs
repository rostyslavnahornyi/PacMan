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

namespace PacMan_GUI_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
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
        }

        private void BtnRestart(object sender, RoutedEventArgs e)
        {

        }

        private void KeyDownCanvas(object sender, KeyEventArgs e)
        {

        }
    }
}
