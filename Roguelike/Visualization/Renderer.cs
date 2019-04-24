using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Roguelike
{
    class Renderer
    {
        public static int MapRenderWidth { get; set; }
        public static int MapRenderHeight { get; set; }
        public static List<Character> Characters { get; set; }
        public static Player Player { get; set; }
        //public static Enemy LastEnemy { get; set; }

        public Renderer()
        {
            MapRenderWidth = 64;
            MapRenderHeight = 32;
            Console.CursorVisible = false;
            Characters = new List<Character>();
        }

        public static void RenderHeandler(object sender, PropertyChangedEventArgs e)
        {//check last enemy
            ThreadPool.QueueUserWorkItem(x => Render());
        }

        public static void Render()
        {
            foreach (var item in Utilites.u.CurrentMap.MapView)
            {
                Console.WriteLine(item);
            }
            foreach (var item in Characters)
            {
                RenderCharacter(item);
            }
            if (Player != null)
                RenderCharacter(Player);
        }

        static void RenderCharacter(Character character)
        {
            Console.SetCursorPosition(character.Position.x, character.Position.y);
            Console.Write(character.CharacterGraphic);
            Console.SetCursorPosition(0, 0);
        }
        
        public static void AddChar(Character character)
        {
            if (character is Player && Player == null)
                Player = character as Player;
            else//if lastenemy
                Characters.Add(character);
            character.PropertyChanged += RenderHeandler;
        }
        public static void RemChar(Character character)
        {
            character.PropertyChanged -= RenderHeandler;
            Characters.Remove(character);
        }
    }
}
