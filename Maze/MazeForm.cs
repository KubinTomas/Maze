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

namespace Maze
{
    public partial class Maze : Form
    {
        public Maze()
        {
            InitializeComponent();
            InitForm();
        }
        private void InitForm()
        {
            this.Size = MazeFormSetting.WindowSize;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
