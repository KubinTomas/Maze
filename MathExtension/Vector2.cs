using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtension
{
    public class Vector2 : Vector
    {
        private Point point;

        public int X
        {
            get { return point.X; }
            set { point.X = value; }
        }
        public int Y
        {
            get { return point.Y; }
            set { point.Y = value; }
        }

        public Vector2()
        {
            point = new Point(0, 0);
        }
        public Vector2(int x, int y)
        {
            point = new Point(x, y);
        }
        /* Static methods */
        public static Vector2 Zero()
        {
            return new Vector2(0, 0);
        }
        public static Vector2 Up()
        {
            return new Vector2(0, 1);
        }
        public static Vector2 Down()
        {
            return new Vector2(0, -1);
        }
        public static Vector2 Left()
        {
            return new Vector2(-1, 0);
        }
        public static Vector2 Right()
        {
            return new Vector2(1, 0);
        }
    }
}
