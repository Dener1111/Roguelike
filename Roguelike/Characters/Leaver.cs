using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Characters
{
    public class Leaver : Character, IActivatable
    {
        [JsonIgnore]
        public char Graphic1 { get; set; }
        [JsonIgnore]
        public char Graphic2 { get; set; }

        public int WallId { get; set; }

        public Leaver(Vector2 pos, int wId)
        {
            Name = "Leaver";
            Graphic1 = '/';
            Graphic2 = '\\';
            Position = pos;
            WallId = wId;

            CharacterGraphic = Graphic1;
        }

        public string Activate()
        {
            Renderer.FindWallId(WallId)?.Activate();
            CharacterGraphic = CharacterGraphic == Graphic1 ? Graphic2 : Graphic1;
            return "pulled";
        }
    }
}
