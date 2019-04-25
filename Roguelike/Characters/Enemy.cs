using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roguelike.Items;

namespace Roguelike.Characters
{
    class Enemy : Character, IDamagable,  IAttacker
    {
        public int MaxHp { get; set; }
        public int Hp { get; set; }
        public int Speed { get; set; }

        public Weapon CurrentWeapon { get; set; }
        public Armor CurrentArmor { get; set; }

        public int LookRadius { get; set; }

        public IItem Drop { get; set; }

        public Enemy(char graphic, string name, int hp = 1, int look = 5)
        {
            CharacterGraphic = graphic;
            Name = name;
            Speed = 1;
            MaxHp = Hp = hp;
            CurrentWeapon = new Weapon("", 1);
            CurrentArmor = new Armor("", 0);

            LookRadius = look;
            Drop = null;
        }

        public void Move()
        {
            if (LookRadius * LookRadius >= Vector2.Distance(Renderer.Player.Position, Position))
            {
                MoveTo(Renderer.Player);
            }
            else
                MoveRandom();
        }

        void MoveTo(Character p)
        {
            Vector2 moveDir = p.Position - Position;

            if (Math.Abs(moveDir.x) > Math.Abs(moveDir.y))
                Move(new Vector2(Math.Sign(moveDir.x) * Speed, 0));
            else
                Move(new Vector2(0, Math.Sign(moveDir.y) * Speed));
        }

        void MoveRandom()
        {
            Vector2 moveDir = new Vector2(new Random().Next(-Speed, Speed + 1), 0);
            if (moveDir.x == 0)
                moveDir.y = new Random().Next(-Speed, Speed + 1);
            Move(moveDir);
        }
    }
}
