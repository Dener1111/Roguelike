using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Vector2
    {
        public int x { get; set; }
        public int y { get; set; }

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2) => new Vector2(v1.x + v2.x, v1.y + v2.y);
        public static Vector2 operator -(Vector2 v1, Vector2 v2) => new Vector2(v1.x - v2.x, v1.y - v2.y);
        public static bool operator ==(Vector2 v1, Vector2 v2) => v1.x == v2.x && v1.y == v2.y;
        public static bool operator !=(Vector2 v1, Vector2 v2) => !(v1 == v2);

        public static double Distance(Vector2 v1, Vector2 v2)
        {
            return (Math.Pow(v1.x - v2.x, 2) + Math.Pow(v1.y - v2.y, 2));
        }

        public override string ToString() => $"x: {x}, y: {y}";
    }
}
