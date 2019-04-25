using Roguelike.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Characters
{
    interface IDamagable
    {
        int MaxHp { get; set; }
        int Hp { get; set; }
        Armor CurrentArmor { get; set; }
    }
}
