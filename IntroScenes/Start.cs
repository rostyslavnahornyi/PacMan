using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Start
    {
        public Start()
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
                    new Introduction().Display();
                    
                    break;
            }
        }
    }
}
