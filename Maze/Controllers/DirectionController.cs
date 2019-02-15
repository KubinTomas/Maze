using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Controllers
{
    public static class DirectionController
    {
        public enum WallBuildDirection { Up, Right, Down, Left };

        public static Point GetNextDirection(Point currentArrayPosition, WallBuildDirection direction)
        {
            if (direction == WallBuildDirection.Up) return new Point(currentArrayPosition.X, currentArrayPosition.Y - 1);
            if (direction == WallBuildDirection.Right) return new Point(currentArrayPosition.X + 1, currentArrayPosition.Y);
            if (direction == WallBuildDirection.Down) return new Point(currentArrayPosition.X, currentArrayPosition.Y + 1);
            if (direction == WallBuildDirection.Left) return new Point(currentArrayPosition.X - 1, currentArrayPosition.Y);

            return currentArrayPosition;
        }
    }
}
