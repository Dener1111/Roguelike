using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Characters
{
    public class FakeWall : Character, IActivatable
    {
        public char Graphic1 { get; set; }
        public char Graphic2 { get; set; }
        
        public bool Opened { get; set; }

        public FakeWall(Vector2 pos)
        {
            Name = "Wall";
            Graphic1 = '#';
            Graphic2 = ' ';
            Position = pos;

            CharacterGraphic = Graphic1;
        }

        public string Activate()
        {
            CharacterGraphic = CharacterGraphic == Graphic1 ? Graphic2 : Graphic1;
            Opened = !Opened;
            return "";
        }
    }
}
