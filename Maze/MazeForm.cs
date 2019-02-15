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

namespace Maze
{
    public partial class Maze : Form
    {
        private MazeGenerator _mazeGenerator;

        public Maze()
        {
            InitializeComponent();
            InitForm();

            _mazeGenerator = new BasicMazeGenerator(MazeSetting.MazeSize);

        }
        private void InitForm()
        {
            this.Size = MazeFormSetting.WindowSize;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Maze_Paint(object sender, PaintEventArgs e)
        {
            _mazeGenerator.DrawMaze(e.Graphics);
        }

        private void Maze_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G) _mazeGenerator.Generate();
            if (e.KeyCode == Keys.R) this.Refresh();

        }
    }
}
