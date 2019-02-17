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
using Camera;
using MathExtension;

namespace Maze
{
    public partial class Maze : Form
    {
        private MazeKeysController _mazeKeysController;
        private MazeController _mazeController;
        private CameraBase _camera;

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
            _mazeKeysController = new MazeKeysController();
            _camera = new Camera2D();


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
            if (e.KeyCode == Keys.I) MessageBox.Show(_camera.ToString());
            if (e.KeyCode == Keys.Escape) Application.Exit();

            if (e.KeyCode == Keys.W) _mazeKeysController.ActiveKey(Keys.W);
            if (e.KeyCode == Keys.A) _mazeKeysController.ActiveKey(Keys.A);
            if (e.KeyCode == Keys.S) _mazeKeysController.ActiveKey(Keys.S);
            if (e.KeyCode == Keys.D) _mazeKeysController.ActiveKey(Keys.D);
        }

        private void Maze_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) _mazeKeysController.DeactiveKey(Keys.W);
            if (e.KeyCode == Keys.A) _mazeKeysController.DeactiveKey(Keys.A);
            if (e.KeyCode == Keys.S) _mazeKeysController.DeactiveKey(Keys.S);
            if (e.KeyCode == Keys.D) _mazeKeysController.DeactiveKey(Keys.D);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            _camera.UpdateObjectsRelativeToCamera(_mazeController.MazeGenerator.ConvertMazeToICameraObject());

            _mazeController.MazeGenerator.DrawMaze(e.Graphics);

            //e.Graphics.DrawString(_mazeKeysController.GetVectorFromPressedKeys().ToString(), new System.Drawing.Font("Arial", 16), Brushes.Red, new Point(300, 300));
        }

        private void MoveChecker_Tick(object sender, EventArgs e)
        {
            var vector = _mazeKeysController.GetVectorFromPressedKeys();

            _camera.Move(vector);

            Refresher.Instance.Refresh();

        }
    }
}
