using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Characters
{
    public class Leaver : Character, IActivatable
    {
        public char Graphic1 { get; set; }
        public char Graphic2 { get; set; }

        public FakeWall Wall { get; set; }

        public Leaver(Vector2 pos, FakeWall wall = null)
        {
            Name = "Leaver";
            Graphic1 = '/';
            Graphic2 = '\\';
            Position = pos;
            Wall = wall;

            CharacterGraphic = Graphic1;
        }

        public string Activate()
        {
            if (Wall != null)
                Wall.Activate();
            CharacterGraphic = CharacterGraphic == Graphic1 ? Graphic2 : Graphic1;
            return "pulled";
        }
    }
}
