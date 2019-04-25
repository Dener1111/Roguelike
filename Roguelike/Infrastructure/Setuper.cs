using Newtonsoft.Json;
using Roguelike.Characters;
using Roguelike.MapStuff;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Infrastructure
{
    class Setuper
    {
        public static void Setup()
        {
            string setupFile = "setup.txt";
            string startMap = "";

            if (File.Exists(setupFile))
                startMap = File.ReadAllLines(setupFile)[0];
            else
                Environment.Exit(0);

            Utilites u = new Utilites();
            Renderer mapRenderer = new Renderer();

            Load(startMap);

            Renderer.Render();
            Renderer.WriteStats();
        }

        static void Load(string fileName)
        {
            SerializableMap map = new SerializableMap();
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader file = File.OpenText(fileName))
                {
                    using (JsonReader reader = new JsonTextReader(file))
                    {
                        map = serializer.Deserialize<SerializableMap>(reader);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("can't load map");
            }
                Utilites.u.CurrentMap = map.CurrentMap;
                Utilites.u.Collisions = map.Collisions;
                foreach (var item in map.Players)
                    Renderer.AddChar(item);
                foreach (var item in map.Enemys)
                    Renderer.AddChar(item);
                foreach (var item in map.Doors)
                    Renderer.AddChar(item);
                foreach (var item in map.FakeWalls)
                    Renderer.AddChar(item);
                foreach (var item in map.ItemConteiners)
                    Renderer.AddChar(item);
                foreach (var item in map.Leavers)
                    Renderer.AddChar(item);
                foreach (var item in map.Characters)
                    Renderer.AddChar(item);
        }

        public static void TestWrite()
        {
            SerializableMap map = new SerializableMap()
            {
                CurrentMap = Utilites.u.CurrentMap,
                Collisions = Utilites.u.Collisions
            };
            map.Players = new List<Player>();
            map.Enemys = new List<Enemy>();
            map.Doors = new List<Door>();
            map.FakeWalls = new List<FakeWall>();
            map.ItemConteiners = new List<ItemConteiner>();
            map.Leavers = new List<Leaver>();
            map.Characters = new List<Character>();
            foreach (var item in Renderer.Characters)
            {
                if (item is Player p)
                    map.Players.Add(p);
                else if (item is Enemy e)
                    map.Enemys.Add(e);
                else if (item is Door d)
                    map.Doors.Add(d);
                else if (item is FakeWall f)
                    map.FakeWalls.Add(f);
                else if (item is ItemConteiner i)
                    map.ItemConteiners.Add(i);
                else if (item is Leaver l)
                    map.Leavers.Add(l);
                else
                    map.Characters.Add(item);
            }

            using (StreamWriter file = File.CreateText(@"Example.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, map); 
            }
        }
    }
}
