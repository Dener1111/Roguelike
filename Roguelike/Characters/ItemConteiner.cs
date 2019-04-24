using Roguelike.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Characters
{
    public class ItemConteiner : Character
    {
        public IItem Item { get; set; }

        public ItemConteiner(Vector2 pos, IItem item)
        {
            CharacterGraphic = '¤';
            Position = pos;
            Item = item;
        }
    }
}
