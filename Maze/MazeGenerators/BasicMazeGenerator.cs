using Maze.Controllers;
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

        private List<LeadingTile> _leadingTiles;


        public BasicMazeGenerator(Size mazeSize)
        {
            _mazeSize = mazeSize;
            _leadingTiles = new List<LeadingTile>();

            _random = new Random();

            Maze = new Tile[_mazeSize.Width, _mazeSize.Height];
        }

        public override void Generate()
        {
            ClearMaze();

            InitMazeArray();

            BuildWalls();
        }
        private void BuildWalls()
        {
            while(_leadingTiles.Count > 0)
            {
                var leadingTile = GetRandomLeadingTile();

                var wallBuildDirection = GetRandomWallBuildDirection();

                BuildWall(leadingTile.ArrayPosition, wallBuildDirection);
            }
        }
        private void BuildWall(Point arrayPosition, DirectionController.WallBuildDirection direction)
        {
            HandleLeadingTile(arrayPosition);

            if (Maze[arrayPosition.X, arrayPosition.Y] != null && Maze[arrayPosition.X, arrayPosition.Y] is Wall)
                return;

            var wall = new Wall(arrayPosition, TileSetting.Size, TileSetting.WallBrush);

            Maze[arrayPosition.X, arrayPosition.Y] = wall;

            BuildWall(DirectionController.GetNextDirection(arrayPosition, direction), direction);
        }
        private DirectionController.WallBuildDirection GetRandomWallBuildDirection()
        {
            var randomValue = _random.Next(0, 4);

            if(randomValue == 0) return DirectionController.WallBuildDirection.Up;
            if(randomValue == 1) return DirectionController.WallBuildDirection.Right;
            if(randomValue == 2) return DirectionController.WallBuildDirection.Down;
            if(randomValue == 3) return DirectionController.WallBuildDirection.Left;

            return DirectionController.WallBuildDirection.Up;
        }
        private LeadingTile GetRandomLeadingTile()
        {
            return _leadingTiles.ElementAt(_random.Next(0, _leadingTiles.Count));
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

            _leadingTiles.Add(leadingTile);
        }
        private void AddRoadTile(Point position)
        {
            var roadTile = new RoadTile(position, TileSetting.Size, TileSetting.RoadBrush);

            Maze[position.X, position.Y] = roadTile;
        }

        /// <summary>
        /// Check if is leading tile on current possition
        /// If leading tile exist, remove it from list
        /// </summary>
        /// <param name="arrayPosition"></param>
        private void HandleLeadingTile(Point arrayPosition)
        {
            var tile = Maze[arrayPosition.X, arrayPosition.Y];

            if (LeadingTile.IsLeadingTile(tile))
                RemoveLeadingTile(tile as LeadingTile);

        }
        private void RemoveLeadingTile(LeadingTile tile)
        {
            _leadingTiles.Remove(tile);
        }
     
    }
}
