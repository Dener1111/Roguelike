using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Items
{
    public interface IItem
    {
        string Name { get; set; }

        void Use(Player p);
    }
}
