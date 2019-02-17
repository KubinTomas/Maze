using Camera;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Tiles
{
    public abstract class Tile : ICameraObject
    {
        public Point ArrayPosition { get; protected set; }

        protected Size OriginalSize { get; set; }
        public Size Size { get; set; }

        public Point OriginalPosition { get; set; }

        public Point Position { get; set; }

        protected Brush Color { get; set; }

        public Tile(Point arrayPosition, Size size, Brush color)
        {
            ArrayPosition = arrayPosition;
            Color = color;

            OriginalSize = size;
            Size = size;

            OriginalPosition = new Point(ArrayPosition.X * Size.Width, ArrayPosition.Y * Size.Height);
            Position = new Point(ArrayPosition.X * Size.Width, ArrayPosition.Y * Size.Height);
        }
        protected Rectangle GetRectangle()
        {
           return new Rectangle(Position, Size);
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
