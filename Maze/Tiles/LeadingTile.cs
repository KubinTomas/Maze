using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Tiles
{
    public class LeadingTile : Tile
    {
        private static readonly int minOffsetFromWall = 2;

        public LeadingTile(Point arrayPosition, Size size, Brush color) : base(arrayPosition, size, color)
        { }

        public static bool CanCreateLeadingTile(Point arrayPosition, Point arrayMaxSize, Tile[,] maze)
        {
            if (!IsWallDistanceBigEnough(arrayPosition, arrayMaxSize) || !HasSpaceAround(arrayPosition, arrayMaxSize, maze)) 
                return false;

            return true;
        }
        /// <summary>
        /// Check if is distanced enough from wall
        /// </summary>
        /// <param name="arrayPosition"></param>
        /// <returns></returns>
        private static bool IsWallDistanceBigEnough(Point arrayPosition, Point arrayMaxSize)
        {
            if (arrayPosition.X >= minOffsetFromWall
                 && arrayPosition.X + minOffsetFromWall <= arrayMaxSize.X
                 && arrayPosition.Y >= minOffsetFromWall
                 && arrayPosition.Y + minOffsetFromWall <= arrayMaxSize.Y
                )
                return true;

            return false;
        }
        /// <summary>
        /// Check square around position, size of square is 1
        /// </summary>
        /// <param name="arrayPosition"></param>
        /// <param name="arrayMaxSize"></param>
        /// <param name="maze"></param>
        /// <returns></returns>
        private static bool HasSpaceAround(Point arrayPosition, Point arrayMaxSize, Tile[,] maze)
        {
            var hasSpace = true;

            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    var newPosition = new Point(arrayPosition.X + x, arrayPosition.Y + y);

                    if (!AreCoordinatesInArray(newPosition, arrayMaxSize)
                        || (AreCoordinatesInArray(newPosition, arrayMaxSize) && !TileIsAvailable(newPosition, maze)))
                        hasSpace = false;
                }
            }

            return hasSpace;
        }
        /// <summary>
        /// If tile is not a wall or Leading tile -> is empty
        /// </summary>
        /// <param name="arrayPosition"></param>
        /// <param name="arrayMaxSize"></param>
        /// <returns></returns>
        private static bool TileIsAvailable(Point arrayPosition, Tile[,] maze)
        {
            if (maze[arrayPosition.X, arrayPosition.Y] == null || maze[arrayPosition.X, arrayPosition.Y] is RoadTile) return true;

            return false;
        }
        private static bool AreCoordinatesInArray(Point arrayPosition, Point arrayMaxSize)
        {
            if (arrayPosition.X > 0 && arrayPosition.X <= arrayMaxSize.X
                && arrayPosition.Y > 0 && arrayPosition.Y <= arrayMaxSize.Y)
                return true;

            return false;
        }
        public static bool IsLeadingTile(Tile tile)
        {
            return tile is LeadingTile;
        }
    }
}
