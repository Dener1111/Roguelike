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
    public class Player : Character
    {   
        public int Speed { get; set; }
        public int Hp { get; set; }

        public Weapon CurrentWeapon { get; set; }
        //public Armor CurrentArmor { get; set; }

        public List<IItem> Inventory { get; set; }

        public int Gold { get; set; }
        
        public Player()
        {
            CharacterGraphic = '@';
            Position = new Vector2();
            Speed = 1;
            Inventory = new List<IItem>();
            Gold = 0;
        }

        

        public bool Controll(ConsoleKeyInfo button)
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

        void Move(Vector2 v)
        {
            Character ch = Utilites.u.FindCharacter(Position + v);
            if (ch != null)
                Interaction.Interact(this, ch);
            else if (!Utilites.u.CheckCollision(Utilites.u.CurrentMap.Cords(Position + v)))
                Position += v;
        }
    }
}
