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
        {
        }

        public static bool CanCreateLeadingTile(Point arrayPosition, Point arrayMaxSize)
        {
            if (!IsWallDistanceBigEnough(arrayPosition, arrayMaxSize))
                return false;



            return false;
        }
        /// <summary>
        /// Check if is distanced enough from wall
        /// </summary>
        /// <param name="arrayPosition"></param>
        /// <returns></returns>
        private static bool IsWallDistanceBigEnough(Point arrayPosition, Point arrayMaxSize)
        {
            if (arrayPosition.X < minOffsetFromWall
                || arrayPosition.Y < minOffsetFromWall
                || arrayPosition.X + minOffsetFromWall >= arrayMaxSize.X
                || arrayPosition.Y + minOffsetFromWall >= arrayMaxSize.Y
                || !HasSpaceAround(arrayPosition, arrayMaxSize)
                )
                return false;

            return true;
        }
        /// <summary>
        /// Check if around him in every direction, lenght 1 is alone
        /// </summary>
        /// <param name="arrayPosition"></param>
        /// <param name="arrayMaxSize"></param>
        /// <returns></returns>
        private static bool HasSpaceAround(Point arrayPosition, Point arrayMaxSize)
        {


            return true;
        }
    }
}
