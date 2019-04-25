using Roguelike.Characters;
using Roguelike.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Roguelike
{
    public class Character : INotifyPropertyChanged
    {
        char characterGraphic;
        public char CharacterGraphic
        {
            get => characterGraphic;
            set
            {
                characterGraphic = value;
                NotifyPropertyChanged();
            }
        }
        public string Name { get; set; }

        Vector2 position;
        public Vector2 Position
        {
            get => position;
            set
            {
                position = value;
                NotifyPropertyChanged();
            }
        }
        
        bool dead;
        [JsonIgnore]
        public bool Dead
        {
            get => dead;
            set
            {
                dead = value;
                NotifyPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void Move(Vector2 v)
        {
            Character ch = Utilites.u.FindCharacter(Position + v);
            if (ch != null)
                Interaction.Interact(this, ch);
            else if (!Utilites.u.CheckCollision(Utilites.u.CurrentMap.Cords(Position + v)))
                Position += v;
        }


        public int? GetDamage(Character damager)
        {
            if (this is IDamagable damagable && damager is IAttacker attacker)
            {
                int dmg = attacker.CurrentWeapon.Damage - damagable.CurrentArmor.ArmorClass;
                dmg = dmg > 0 ? dmg : 0;
                damagable.Hp -= dmg;
                return dmg;
            }
            return null;
        }

        public void Die(Character killer)
        {
            Dead = true;
            Renderer.WriteLog($"{killer.Name} killed {Name}");
            if (this is Enemy enemy && enemy.Drop != null)
                Renderer.AddChar(new ItemConteiner(Position, enemy.Drop));
            Renderer.RemChar(this);
        }

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
