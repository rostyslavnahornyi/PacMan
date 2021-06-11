using System.Windows.Controls;
using System.Windows.Shapes;
namespace PacMan_GUI_WPF
{
    class Runner
    {
        public Runner(Canvas CanvasField)
        {
            new Field(CanvasField);
            Scores.FindAllCoins();
        }
    }
}
