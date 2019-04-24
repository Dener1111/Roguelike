using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Characters
{
    class Door : Character
    {
        char Graphic1 { get; set; }
        char Graphic2 { get; set; }

        public bool Vertical { get; set; }

        public bool Closed { get; set; }
        public int KeyId { get; set; }

        public Door(Vector2 pos, bool vertical = true, bool closed = true, int keyId = 0)
        {
            Graphic1 = '│';
            Graphic2 = '─';
            Position = pos;
            Vertical = vertical;
            Closed = closed;
            KeyId = keyId;

            if ((vertical && Closed) || (!vertical && !Closed))
                CharacterGraphic = Graphic1;
            else
                CharacterGraphic = Graphic2;
        }

        public void Unlock()
        {
            Open();
        }

        void Open()
        {
            CharacterGraphic = CharacterGraphic == Graphic1 ? Graphic2 : Graphic1;
            Closed = false;
        }
    }
}
