using Maze.Tiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.MazeGenerators
{
    public  abstract class MazeGenerator
    {
        public Tile[,] Maze { get; protected set; }
        protected Size _mazeSize;

        public abstract void Generate();

        public void ClearMaze()
        {
            Maze = Maze = new Tile[_mazeSize.Width, _mazeSize.Height];
        }
        public void DrawMaze(Graphics graphics)
        {
            for (int y = 0; y < Maze.GetLength(0); y++)
            {
                for (int x = 0; x < Maze.GetLength(1); x++)
                {
                    DrawMaze(Maze[x, y], graphics);
                }
            }
        }
        private void DrawMaze(Tile tile, Graphics graphics)
        {
            if (tile == null) return;
            tile.Draw(graphics);
        }
    }
}
