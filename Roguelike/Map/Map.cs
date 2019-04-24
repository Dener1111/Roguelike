using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Map
    {
        public ObservableCollection<string> MapView { get; set; }

        public Map()
        {
            MapView = new ObservableCollection<string>();
        }

        public char Cords(Vector2 v2)
        {
            return MapView[v2.y][v2.x];
        }

        public void LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                string[] tmpMap = File.ReadAllLines(fileName).ToArray();
                foreach (var item in tmpMap)
                    MapView.Add(item);
            }
        }
    }
}
