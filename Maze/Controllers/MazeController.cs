using Maze.MazeGenerators;
using Maze.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Controllers
{
    class MazeController
    {
        public MazeGenerator MazeGenerator { get; }

        public MazeController(MazeGenerator mazeGenerator )
        {
            MazeGenerator = mazeGenerator;
        }

        public void GenerateNewMaze()
        {
            MazeGenerator.Generate();

            Refresher.Instance.Refresh();
        }
    }
}
