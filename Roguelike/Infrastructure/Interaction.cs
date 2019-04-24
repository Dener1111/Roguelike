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
            if (from is Player player)
            {
                if (to is Door door)
                {
                    if (door.Closed)
                        door.Unlock();
                    else
                        player.Position = door.Position;
                }
                else if (to is ItemConteiner item)
                {
                    if (item.Item is Gold gold)
                        player.Gold += gold.Amount;
                    else
                        player.Inventory.Add(item.Item);
                    player.Position = item.Position;
                    Renderer.RemChar(to);

                    Renderer.WriteLog($"You picked up: {item.Item}");
                }
            }

            ThreadPool.QueueUserWorkItem(x => Renderer.WriteStats());
        }

    }
}
