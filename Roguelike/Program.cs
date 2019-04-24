using Roguelike.Characters;
using Roguelike.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Roguelike
{
    class Program
    {
        public static IItem Item { get; private set; }

        static void Main(string[] args)
        {
            Map map = new Map();
            map.LoadFromFile(@"testmap.txt");

            Utilites u = new Utilites();
            Utilites.u.CurrentMap = map;
            Utilites.u.Collisions.Add('#');

            Player player = new Player { Position = new Vector2(5, 5) };

            Door door1 = new Door(new Vector2(11, 5));

            ItemConteiner item1 = new ItemConteiner(new Vector2(4,4), new Weapon("Iron Sword", 2));
            ItemConteiner item2 = new ItemConteiner(new Vector2(6,4), new Gold(5));

            Renderer mapRenderer = new Renderer();
            Renderer.AddChar(player);
            Renderer.AddChar(door1);
            Renderer.AddChar(item1);
            Renderer.AddChar(item2);

            ThreadPool.QueueUserWorkItem(x => Renderer.Render());

            ConsoleKeyInfo input;
            while (true)
            {
                input = new ConsoleKeyInfo();

                while(Console.KeyAvailable)
                    input = Console.ReadKey(true);

                if (player.Controll(input));
                    //enemys turn

                Thread.Sleep(100);
            }
        }
    }
}
