﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Items
{
    public class Weapon : IItem
    {
        public string Name { get; set; }

        public int Damage { get; set; }

        public Weapon(string name = "weapon", int damage = 1)
        {
            Name = name;
            Damage = damage;
        }

        public void Use(Player p)
        {
            p.CurrentWeapon = this;
        }

        public override string ToString() => $"{Name}|{Damage} dmg";

    }
}
