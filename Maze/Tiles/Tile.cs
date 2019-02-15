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
        public Point Position { get; set; }

        public Size Size { get; set; }

        public Color Color { get; set; }
    }
}
