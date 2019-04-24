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
    class Player : Character
    {   
        public int Speed { get; set; }
        public int Hp { get; set; }

        public Weapon CurrentWeapon { get; set; }

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
            switch (button.KeyChar)
            {
                case 'w':
                    Move(new Vector2(0, -Speed));
                    break;
                case 's':
                    Move(new Vector2(0, Speed));
                    break;
                case 'a':
                    Move(new Vector2(-Speed, 0));
                    break;
                case 'd':
                    Move(new Vector2(Speed, 0));
                    break;
                case ' ':
                    break;
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
