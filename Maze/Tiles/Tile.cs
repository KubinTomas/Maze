using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Tiles
{
    public abstract class Tile
    {
        public Point ArrayPosition { get; protected set; }

        protected Size Size { get; set; }

        protected Brush Color { get; set; }

        public Tile(Point arrayPosition, Size size, Brush color)
        {
            ArrayPosition = arrayPosition;
            Size = size;
            Color = color;

        }
        protected Rectangle GetRectangle()
        {
           return new Rectangle(GetPosition(), Size);
        }
        private Point GetPosition()
        {
            return new Point(ArrayPosition.X * Size.Width, ArrayPosition.Y * Size.Height);
        }
        public void Draw(Graphics graphics)
        {
            graphics.FillRectangle(Color, GetRectangle());
        }
    }
}
