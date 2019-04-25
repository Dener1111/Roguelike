using Roguelike.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Characters
{
    interface IAttacker
    {
        Weapon CurrentWeapon { get; set; }
    }
}
