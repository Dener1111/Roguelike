using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Items
{
    public class Armor : IItem
    {
        public string Name { get; set; }
        public int ArmorClass { get; set; }

        public Armor(string name, int ac = 1)
        {
            Name = name;
            ArmorClass = ac;
        }

        public void Use(Player p)
        {
            p.CurrentArmor = this;
        }

        public override string ToString() => $"{Name}|{ArmorClass} ac";
    }
}
