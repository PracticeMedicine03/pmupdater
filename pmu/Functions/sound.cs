using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace PMU.Functions
{
    internal class Sound
    {
        internal class Music
        {
            public static void Music_Play()
            {
                // TODO: make music shit functional
            }

            public static void Music_Stop()
            {
                // TODO: make music shit functional
            }
        }

        internal class UI
        {
            public static void UI_OnHover()
            {
                SoundPlayer player = new SoundPlayer("resource\\ui\\ui_hover.wav");
                player.Play();
            }
            public static void UI_OnPressed()
            {
                SoundPlayer player = new SoundPlayer("resource\\ui\\ui_click.wav");
                player.Play();
            }
        }
    }
}
    

