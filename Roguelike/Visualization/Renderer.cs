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

        static int selectedItem;
        public static int SelectedItem
        {
            get => selectedItem;
            set
            {
                if(value > -1 && value < Player?.Inventory.Count)
                    selectedItem = value;
            }
        }

        static object lockOn = new object();

        public Renderer()
        {
            MapRenderWidth = 64;
            MapRenderHeight = 32;
            Console.CursorVisible = false;
            Characters = new List<Character>();

            Console.BufferHeight = Console.WindowHeight = MapRenderHeight + 1;
            Console.BufferWidth = Console.WindowWidth = MapRenderWidth + 20;
        }

        public static void RenderHeandler(object sender, PropertyChangedEventArgs e)
        {//check last enemy
            ThreadPool.QueueUserWorkItem(x => Render());
        }

        public static void Render()
        {
            lock (lockOn)
            {
                int i = 0;
                foreach (var item in Utilites.u.CurrentMap.MapView)
                {
                    if (item.Length > MapRenderWidth)
                        Console.WriteLine(item.Remove(MapRenderWidth - 1));
                    else
                        Console.WriteLine(item);

                    if (++i >= MapRenderHeight)
                        break;
                }
                foreach (var item in Characters)
                {
                    if (item.Position.x < MapRenderWidth && item.Position.y < MapRenderHeight)
                        RenderCharacter(item);
                }
                if (Player != null)
                    RenderCharacter(Player);
            }
        }

        static void RenderCharacter(Character character)
        {
            Console.SetCursorPosition(character.Position.x, character.Position.y);
            Console.Write(character.CharacterGraphic);
            Console.SetCursorPosition(0, 0);
        }

        public static void WriteLog(string s)
        {
            lock (lockOn)
            {
                Vector2 pos = new Vector2(Console.CursorLeft, Console.CursorTop);

                Console.SetCursorPosition(0, MapRenderHeight - 1);
                Console.Write(s + new string(' ', MapRenderWidth - s.Length - 1));

                Console.SetCursorPosition(pos.x, pos.y);
            }
        }
        public static void WriteStats()
        {
            lock (lockOn)
            {
                Vector2 pos = new Vector2(Console.CursorLeft, Console.CursorTop);

                int i = 0;
                Console.SetCursorPosition(MapRenderWidth, i);
                Console.Write($"HP: {Player.Hp} Gold: {Player.Gold}");

                Console.SetCursorPosition(MapRenderWidth, i = 2);
                Console.Write($"Armor:");
                Console.SetCursorPosition(MapRenderWidth, i = 3);
                Console.Write($" ArmorPlaceHolder");

                Console.SetCursorPosition(MapRenderWidth, i = 5);
                Console.Write($"Weapon:");
                Console.SetCursorPosition(MapRenderWidth, i = 6);
                Console.Write($" {Player.CurrentWeapon}");

                Console.SetCursorPosition(MapRenderWidth, i = 8);
                Console.Write($"Inventory:");


                foreach (var item in Player.Inventory)
                {
                    Console.SetCursorPosition(MapRenderWidth, ++i);
                    Console.Write($" {item}");
                }

                Console.SetCursorPosition(pos.x, pos.y);
            }
        }
        public static void ItemSelect()
        {
            lock (lockOn)
            {
                WriteStats();

                Vector2 pos = new Vector2(Console.CursorLeft, Console.CursorTop);

                Console.SetCursorPosition(MapRenderWidth, SelectedItem + 9);
                Console.Write($">");
                Console.SetCursorPosition(pos.x, pos.y);
            }
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
