using Roguelike.Characters;
using Roguelike.Infrastructure;
using Roguelike.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Player : Character, IDamagable, IAttacker
    {   
        public int MaxHp { get; set; }
        public int Hp { get; set; }
        public int Speed { get; set; }

        public Weapon CurrentWeapon { get; set; }
        public Armor CurrentArmor { get; set; }

        public Weapon NoWeapon { get; set; }
        public Armor NoArmor { get; set; }

        public List<IItem> Inventory { get; set; }

        public int Gold { get; set; }

        public Player(int maxHp)
        {
            Name = "You";
            CharacterGraphic = '@';
            Position = new Vector2();
            Inventory = new List<IItem>();
            CurrentWeapon = NoWeapon = new Weapon("Fists", 1);
            CurrentArmor = NoArmor = new Armor("None", 0);

            MaxHp = Hp = maxHp;
            Speed = 1;
            Gold = 0;
        }

        public void DropItem(int num)
        {
            Renderer.AddChar(new ItemConteiner(Position, Inventory[num]));
            if (Inventory[num] is Weapon w && w == CurrentWeapon)
                CurrentWeapon = NoWeapon;
            else if (Inventory[num] is Armor a && a == CurrentArmor)
                CurrentArmor = NoArmor;
            Inventory.RemoveAt(num);
        }

        public bool Control(ConsoleKeyInfo button)
        {
            switch (button.Key)
            {
                case ConsoleKey.W:
                    Move(new Vector2(0, -Speed));
                    break;
                case ConsoleKey.S:
                    Move(new Vector2(0, Speed));
                    break;
                case ConsoleKey.A:
                    Move(new Vector2(-Speed, 0));
                    break;
                case ConsoleKey.D:
                    Move(new Vector2(Speed, 0));
                    break;
                case ConsoleKey.Spacebar:
                    break;
                case ConsoleKey.Tab:
                    Controller.ControlInventory();
                    return false;
                default:
                    return false;
            }
            return true;
        }
    }
}
