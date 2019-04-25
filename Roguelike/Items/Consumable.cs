using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Items
{
    class Consumable : IItem
    {
        public string Name { get; set; }
        public int Hp { get; set; }

        public Consumable(string name, int hp = 1)
        {
            Name = name;
            Hp = hp;
        }

        public void Use(Player p)
        {
            for (int i = 0; i < Hp && p.Hp < p.MaxHp; i++)
                p.Hp++;
            p.Inventory.Remove(this);
        }

        public override string ToString() => $"{Name}|{Hp} hp";
    }
}
