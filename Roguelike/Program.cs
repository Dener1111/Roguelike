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

            Player player = new Player(10) { Position = new Vector2(5, 4) };

            Utilites u = new Utilites();
            Utilites.u.CurrentMap = map;
            Utilites.u.Collisions.Add('#');

            Renderer mapRenderer = new Renderer();
            Renderer.AddChar(player);
            Renderer.AddChar(new Door(new Vector2(11, 6)) { KeyId = 1 });
            Renderer.AddChar(new FakeWall(new Vector2(16, 13), 1));
            Renderer.AddChar(new Leaver(new Vector2(12, 11), 1));
            Renderer.AddChar(new Enemy('B', "Bandit", 4, 5) { Position = new Vector2(5, 10), Drop = new Gold(10), CurrentWeapon = new Weapon("", 4) });
            Renderer.AddChar(new ItemConteiner(new Vector2(6, 4), new Weapon("Wooden Clab", 2)));
            Renderer.AddChar(new ItemConteiner(new Vector2(7, 13), new Weapon("Iron Sword", 3)));
            Renderer.AddChar(new ItemConteiner(new Vector2(5, 5), new Armor("ChainMail", 2)));
            Renderer.AddChar(new ItemConteiner(new Vector2(25, 14), new Gold(5)));
            Renderer.AddChar(new ItemConteiner(new Vector2(4, 2), new Key(1)));
            Renderer.AddChar(new ItemConteiner(new Vector2(2, 14), new Consumable("Mead", 2)));

            Renderer.Render();
            Renderer.WriteStats();

            Setuper.TestWrite();

            //Setuper.Setup();
            Controller.ControlPlayer();
        }
    }
}
