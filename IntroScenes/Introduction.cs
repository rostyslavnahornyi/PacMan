using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Introduction
    {
        public void Display()
        {
            Console.Clear();
            Console.WriteLine(@"
Pac-Man (с англ. — «Пакман») — аркадная видеоигра, разработанная японской
компанией и вышедшая в 1980 году. Задача игрока — управляя Пакманом, съесть
все точки в лабиринте, избегая встречи с привидениями, которые гоняются за героем.

Движение пакмана - стрелочками.

Игровые элементы:
");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("@");
            Console.ResetColor();
            Console.Write(" - Pacman");
            Console.WriteLine("\n");
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write("A");
            Console.ResetColor();
            Console.Write(" - Ghost");
            Console.WriteLine("\n");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("#");
            Console.ResetColor();
            Console.Write(" - Wall");
            Console.WriteLine("\n");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("R");
            Console.ResetColor();
            Console.Write(" - Random teleport");
            Console.WriteLine("\nВведите имя игрока: ");
            Console.Read();
            Console.WriteLine("Press Enter to start!");
        }
    }
}
