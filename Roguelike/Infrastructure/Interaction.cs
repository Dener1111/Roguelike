using Roguelike.Characters;
using Roguelike.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Roguelike.Infrastructure
{
    public class Interaction
    {
        public static void Interact(Character from, Character to)
        {
            if (from == to)
                return;
            if (to is FakeWall wall)
            {
                if (wall.Opened)
                    from.Position = to.Position;
                return;
            }
            if (from is IAttacker)
            {
                if(to is IDamagable dmgbl)
                {
                    int? dmg = to.GetDamage(from);
                    if (dmg != null)
                        Renderer.WriteLog($"{from.Name} Damaged {to.Name} by {dmg}");
                    if (dmgbl.Hp <= 0)
                        to.Die(from);
                }
            }
            if (from is Player player)
            {
                if (to is IActivatable activatable)
                {
                    if (activatable is Door door && !door.Closed)
                        player.Position = door.Position;
                    else
                        Renderer.WriteLog($"{from.Name} {activatable.Activate()} {to.Name}");
                }
                else if (to is ItemConteiner item)
                {
                    if (item.Item is Gold gold)
                        player.Gold += gold.Amount;
                    else
                        player.Inventory.Add(item.Item);
                    player.Position = item.Position;
                    Renderer.RemChar(to);

                    Renderer.WriteLog($"{from.Name} picked up: {item.Item}");
                }
            }
            
            ThreadPool.QueueUserWorkItem(x => Renderer.WriteStats());
        }

    }
}
