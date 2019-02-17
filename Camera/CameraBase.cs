using MathExtension;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera
{
    public abstract class CameraBase : ICamera
    {
        public Point Position;

        public float Zoom { get; set; }

        public float Speed { get; set; }

        public abstract void Move(Vector2 vector);

        public static int DefaultZoom = 1;
        public static int DefaultSpeed;
        public static Point DefaultPosition = new Point(0,0);
    }
}
