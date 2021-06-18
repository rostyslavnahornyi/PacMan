using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class IntroScenes
    {
        public static void Introduction()
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
            Console.WriteLine("\nВведите скорость игры в диапазоне 1-3: ");
            Settings.EnemySpeed = 2000 - (Convert.ToInt32(Console.ReadLine()) * 500);
            Console.WriteLine("\nВведите имя игрока: ");
            Console.ReadLine();
            Console.WriteLine("Press Enter to start!");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter)
            {
                Runner.StartGame();
            }
        }

        public static void Start()
        {
            Console.ResetColor();
            Console.Clear();
            new Sound().ON_StartScene();
            Console.WriteLine(@"




            $$$$$$$\                           $$\      $$\                     
            $$  __$$\                          $$$\    $$$ |                    
            $$ |  $$ |$$$$$$\   $$$$$$$\       $$$$\  $$$$ | $$$$$$\  $$$$$$$\  
            $$$$$$$  |\____$$\ $$  _____|      $$\$$\$$ $$ | \____$$\ $$  __$$\ 
            $$  ____/ $$$$$$$ |$$ /            $$ \$$$  $$ | $$$$$$$ |$$ |  $$ |
            $$ |     $$  __$$ |$$ |            $$ |\$  /$$ |$$  __$$ |$$ |  $$ |
            $$ |     \$$$$$$$ |\$$$$$$$\       $$ | \_/ $$ |\$$$$$$$ |$$ |  $$ |
            \__|      \_______| \_______|      \__|     \__| \_______|\__|  \__|
                                                                     
                                                                   
                                ──▒▒▒▒▒────▄████▄─────
                                ─▒─▄▒─▄▒──███▄█▀──────
                                ─▒▒▒▒▒▒▒─▐████──█──█──
                                ─▒▒▒▒▒▒▒──█████▄──────
                                ─▒─▒─▒─▒───▀████▀─────          

                                Press ENTER to start
");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Enter:
                    IntroScenes.Introduction();

                    break;
            }
        }

        public static void End()
        {
            Settings.MovingGhosts = false;
            new Sound().ON_EndScene();
            Console.ResetColor();
            Console.Clear();
            Console.SetWindowSize(100, 20);

            Console.WriteLine(@"

                ▓██   ██▓ ▒█████   █    ██    ▓█████▄  ██▓▓█████ ▓█████▄ 
                 ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▒██▀ ██▌▓██▒▓█   ▀ ▒██▀ ██▌
                  ▒██ ██░▒██░  ██▒▓██  ▒██░   ░██   █▌▒██▒▒███   ░██   █▌
                  ░ ▐██▓░▒██   ██░▓▓█  ░██░   ░▓█▄   ▌░██░▒▓█  ▄ ░▓█▄   ▌
                  ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░▒████▓ ░██░░▒████▒░▒████▓ 
                   ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒     ▒▒▓  ▒ ░▓  ░░ ▒░ ░ ▒▒▓  ▒ 
                 ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░     ░ ▒  ▒  ▒ ░ ░ ░  ░ ░ ▒  ▒ 
                 ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░     ░ ░  ░  ▒ ░   ░    ░ ░  ░ 
                 ░ ░         ░ ░     ░           ░     ░     ░  ░   ░    
                 ░ ░                           ░                  ░      


                               Thanks for the game!
                               
                               Press ESC to close the game
");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.Spacebar:
                    break;
            }
        }

        public static void Win()
        {
            Settings.MovingGhosts = false;
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
