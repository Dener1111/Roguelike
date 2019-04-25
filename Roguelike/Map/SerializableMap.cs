using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roguelike.Characters;

namespace Roguelike.MapStuff
{
    class SerializableMap
    {
        public Map CurrentMap { get; set; }
        public List<char> Collisions { get; set; }
        public List<Player> Players { get; set; }
        public List<Enemy> Enemys { get; set; }
        public List<Door> Doors { get; set; }
        public List<FakeWall> FakeWalls { get; set; }
        public List<ItemConteiner> ItemConteiners { get; set; }
        public List<Leaver> Leavers { get; set; }
        public List<Character> Characters { get; set; }
    }
}
