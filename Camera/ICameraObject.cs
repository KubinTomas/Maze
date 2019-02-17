using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera
{
    public interface ICameraObject
    {
        Size Size { get; set; }

        Point Position { get; set; }

        Point OriginalPosition { get; set; }

    }
}
