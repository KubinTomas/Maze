using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Settings
{
    static class TileSetting
    {
        public static Brush WallBrush { get; set; } = Brushes.Black;
        public static Brush LeadingBrush { get; set; } = Brushes.Orange;
        public static Brush RoadBrush { get; set; } = Brushes.LightGray;

        public static Size Size = new Size(50, 50);
    }
}
