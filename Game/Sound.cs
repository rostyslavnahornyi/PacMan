using System;
using System.Collections.Generic;
using System.Media;
using System.Text;

namespace PacMan
{
    class Sound
    {
        private SoundPlayer StartScene = new SoundPlayer(@"../../../Resources/start.wav");
        private SoundPlayer GettingCoins = new SoundPlayer(@"../../../Resources/coins.wav");
        private SoundPlayer EndScene = new SoundPlayer(@"../../../Resources/gettingCoins.wav");

        
        public void ON_StartScene()
        {
            StartScene.Play();
        }

        public void ON_GettedCoins()
        {
            GettingCoins.PlaySync();
        }

        public void ON_EndScene()
        {
            EndScene.Play();
        }
    }
}
