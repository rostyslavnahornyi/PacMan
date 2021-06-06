using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Win
    {
        public Win()
        {
            Console.ResetColor();
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
                                                                                
 
    You finished this game!
    
    Press ESC to finish
");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
