using Maze.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Maze.MazeGenerators;
using Maze.Singletons;
using Maze.Controllers;

namespace Maze
{
    public partial class Maze : Form
    {
        private MazeController _mazeController;

        public Maze()
        {
            InitializeComponent();

            Init();
        }
        private void Init()
        {
            InitForm();
            InitCanvas();

            Refresher.Instance.SetCanvas(this.canvas);

            _mazeController = new MazeController(new BasicMazeGenerator(MazeSetting.MazeSize));

            _mazeController.GenerateNewMaze();
            Refresher.Instance.Refresh();
        }
        private void InitCanvas()
        {
            this.canvas.Size = MazeFormSetting.WindowSize;
            this.canvas.Location = MazeFormSetting.CanvasPosition;
        }
        private void InitForm()
        {
            this.Size = MazeFormSetting.WindowSize;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Maze_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G) _mazeController.MazeGenerator.Generate();
            if (e.KeyCode == Keys.N) _mazeController.GenerateNewMaze();
            if (e.KeyCode == Keys.R) Refresher.Instance.Refresh();


        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            _mazeController.MazeGenerator.DrawMaze(e.Graphics);
        }
    }
}
