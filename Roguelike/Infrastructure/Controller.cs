using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Roguelike.Infrastructure
{
    public class Controller
    {
        static ConsoleKeyInfo input;

        public static void ControlPlayer(Player player)
        {
            while (true)
            {
                input = new ConsoleKeyInfo();

                while (Console.KeyAvailable)
                    input = Console.ReadKey(true);

                if (player.Controll(input)) ;
                //enemys turn

                Thread.Sleep(100);
            }
        }

        public static void ControlInventory()
        {
            Renderer.SelectedItem = 0;
            while (true)
            {
                Renderer.ItemSelect();

                input = Console.ReadKey(true);

                switch (input.Key)
                {
                    case ConsoleKey.W:
                        Renderer.SelectedItem--;
                        break;
                    case ConsoleKey.S:
                        Renderer.SelectedItem++;
                        break;
                    case ConsoleKey.Spacebar:
                        break;
                    case ConsoleKey.Tab:
                        Renderer.WriteStats();
                        return;
                    default:
                        break;
                }
            }
        }

    }
}
