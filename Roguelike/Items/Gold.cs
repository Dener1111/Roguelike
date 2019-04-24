using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Items
{
    class Gold : IItem
    {
        public string Name { get; set; }
        public int Amount { get; set; }

        public Gold(int amount  = 1)
        {
            Name = "Gold";
            Amount = amount;
        }

        public override string ToString() => $"{Amount} {Name}";
    }
}
