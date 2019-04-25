using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Characters
{
    class Door : Character, IActivatable
    {
        public char Graphic1 { get; set; }
        public char Graphic2 { get; set; }

        public bool Vertical { get; set; }

        public bool Closed { get; set; }
        public int KeyId { get; set; }

        public Door(Vector2 pos, bool vertical = true, bool closed = true, int keyId = 0)
        {
            Name = "Door";
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

        public string Activate()
        {
            if (KeyId == 0)
            {
                Open();
                return "opened the";
            }
            else
            {
                if (Utilites.u.FindKey(KeyId))
                {
                    KeyId = 0;
                    return "unlocked the";
                }
                return "can't unlock the";
            }
        }

        void Open()
        {
            CharacterGraphic = CharacterGraphic == Graphic1 ? Graphic2 : Graphic1;
            Closed = false;
        }
    }
}
