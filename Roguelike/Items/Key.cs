using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Items
{
    public class Key : IItem
    {
        public string Name { get; set; }

        public int KeyId { get; set; }

        public Key(int kId)
        {
            Name = "Key";
            KeyId = kId;
        }

        public void Use(Player p)
        {
            Renderer.WriteLog("Key to open Doors");
        }

        public override string ToString() => $"Key";

    }
}
