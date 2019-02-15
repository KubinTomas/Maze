using Maze.Settings;
using Maze.Tiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.MazeGenerators
{
    /// <summary>
    /// Basic maze generator, prepare 2D array with basic border wall and grid with helping {LeadingTile}
    /// Select random LeadingTile and generate wall in random direction
    /// </summary>
    public class BasicMazeGenerator : MazeGenerator
    {

        private Random _random;

        public BasicMazeGenerator(Size mazeSize)
        {
            _mazeSize = mazeSize;

            _random = new Random();

            Maze = new Tile[_mazeSize.Width, _mazeSize.Height];
        }

        public override void Generate()
        {
            ClearMaze();

            InitMazeArray();
        }
        /// <summary>
        /// This method create border with walls and init ours LeadingTile
        /// </summary>
        private void InitMazeArray()
        {
            for (int y = 0; y < Maze.GetLength(1); y++)
            {
                for (int x = 0; x < Maze.GetLength(0); x++)
                {
                    var position = new Point(x, y);

                    if (IsPostionWall(position))
                        AddWall(position);
                    else if (LeadingTile.CanCreateLeadingTile(position, new Point(Maze.GetLength(0) - 1, Maze.GetLength(1) - 1), Maze))
                        AddLeadingTile(position);
                    else
                        AddRoadTile(position);

                }
            }
        }
        /// <summary>
        /// Check if current position in array is wall
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private bool IsPostionWall(Point position)
        {
            // Check top horizontal wall
            if (position.Y == 0) return true;

            // Check right vertical wall
            if (position.X == Maze.GetLength(0) - 1) return true;

            // Check bottom horizontal wall
            if (position.Y == Maze.GetLength(1) - 1) return true;

            // Check left vertical wall
            if (position.X == 0) return true;

            return false;
        }

        private void AddWall(Point position)
        {
            var wall = new Wall(position, TileSetting.Size, TileSetting.WallBrush);

            Maze[position.X, position.Y] = wall;
        }
        private void AddLeadingTile(Point position)
        {
            var leadingTile = new LeadingTile(position, TileSetting.Size, TileSetting.LeadingBrush);

            Maze[position.X, position.Y] = leadingTile;
        }
        private void AddRoadTile(Point position)
        {
            var roadTile = new RoadTile(position, TileSetting.Size, TileSetting.RoadBrush);

            Maze[position.X, position.Y] = roadTile;
        }
    }
}
