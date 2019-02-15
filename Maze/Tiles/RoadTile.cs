using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Tiles
{
    public class RoadTile : Tile
    {
        public RoadTile(Point arrayPosition, Size size, Brush color) : base(arrayPosition, size, color)
        {
        }
    }
}
