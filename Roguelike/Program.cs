using Roguelike.Characters;
using Roguelike.Infrastructure;
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
            ItemConteiner item3 = new ItemConteiner(new Vector2(3,4), new Weapon("Wooden Clab", 1));

            Renderer mapRenderer = new Renderer();
            Renderer.AddChar(player);
            Renderer.AddChar(door1);
            Renderer.AddChar(item1);
            Renderer.AddChar(item2);
            Renderer.AddChar(item3);

            Renderer.Render();
            Renderer.WriteStats();
            
            Controller.ControlPlayer(player);
        }
    }
}
