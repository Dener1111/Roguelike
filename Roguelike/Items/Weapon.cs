using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Items
{
    class Weapon : IItem
    {
        public string Name { get; set; }

        public int Damage { get; set; }

        public Weapon(string name = "weapon", int damage = 1)
        {
            Name = name;
            Damage = damage;
        }

        public override string ToString() => $"{Name}  {Damage}dmg";
    }
}
