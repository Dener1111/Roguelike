using Roguelike.Characters;
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

        public static void ControlPlayer()
        {
            if (Renderer.Player != null)
            {
                while (true)
                {
                    input = new ConsoleKeyInfo();

                    while (Console.KeyAvailable)
                        input = Console.ReadKey(true);

                    if (Renderer.Player.Control(input))
                        foreach (var item in Renderer.Characters)
                            if (item is Enemy enemy)
                                enemy.Move();

                    Thread.Sleep(100);
                }
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
                    case ConsoleKey.Q:
                        Renderer.Player.DropItem(Renderer.SelectedItem);
                        break;
                    case ConsoleKey.W:
                        Renderer.SelectedItem--;
                        break;
                    case ConsoleKey.S:
                        Renderer.SelectedItem++;
                        break;
                    case ConsoleKey.Spacebar:
                        Renderer.Player.Inventory[Renderer.SelectedItem].Use(Renderer.Player);
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
