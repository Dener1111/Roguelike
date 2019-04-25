using Roguelike.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Utilites
    {
        public static Utilites u;

        public Map CurrentMap { get; set; }
        public Player Player { get; set; }

        public List<char> Collisions { get; set; }

        public Utilites()
        {
            if(u == null)
                u = this;
            Collisions = new List<char>();
        }

        public Character FindCharacter(Vector2 v)
        {
            foreach (var item in Renderer.Characters)
                if (item.Position == v)
                    return item;
            return null;            
        }

        public bool CheckCollision(char ch) => Collisions.Contains(ch);

        public bool FindKey(int id)
        {
            foreach (var item in Player.Inventory)
            {
                if (item is Key key)
                {
                    if (key.KeyId == id)
                    {
                        Player.Inventory.Remove(item);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
