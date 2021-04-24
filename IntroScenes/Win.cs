using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Win
    {
        public Win()
        {
            Settings.Flag = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine(@"
  /$$$$$$$$/$$                        /$$             /$$     /$$               
 |__  $$__| $$                       | $$            |  $$   /$$/               
    | $$  | $$$$$$$  /$$$$$$ /$$$$$$$| $$   /$$       \  $$ /$$/$$$$$$ /$$   /$$
    | $$  | $$__  $$|____  $| $$__  $| $$  /$$/        \  $$$$/$$__  $| $$  | $$
    | $$  | $$  \ $$ /$$$$$$| $$  \ $| $$$$$$/          \  $$| $$  \ $| $$  | $$
    | $$  | $$  | $$/$$__  $| $$  | $| $$_  $$           | $$| $$  | $| $$  | $$
    | $$  | $$  | $|  $$$$$$| $$  | $| $$ \  $$          | $$|  $$$$$$|  $$$$$$/
    |__/  |__/  |__/\_______|__/  |__|__/  \__/          |__/ \______/ \______/ 
                                                                                
 
 You finished this game!");
            Console.ReadKey();
        }
    }
}
