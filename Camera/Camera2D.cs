using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExtension;

namespace Camera
{
    public class Camera2D : CameraBase
    {
        public Camera2D()
        {
            InitCamera();
        }
        private void InitCamera()
        {
            Position = CameraBase.DefaultPosition;
            Speed = CameraBase.DefaultSpeed;
            Zoom = CameraBase.DefaultZoom;
        }
        public override void Move(Vector2 vector)
        {
            Position.X += (int)(vector.X * Speed);
            Position.Y += (int)(vector.Y * Speed);
        }
        public override string ToString()
        {
            return "PosX:" + Position.X + "PosY:" + Position.Y + "Speed:" + Speed + "Zoom:" + Zoom;
        }
    }
}
