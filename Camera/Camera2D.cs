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
            Position.X = Position.X + (int)(vector.X * Speed);
            Position.Y = Position.Y + (int)(vector.Y * Speed);

            _cameraWasChanged = true;
        }
        public override string ToString()
        {
            return "PosX:" + Position.X + "PosY:" + Position.Y + "Speed:" + Speed + "Zoom:" + Zoom;
        }

        public override void UpdateObjectsRelativeToCamera(List<ICameraObject> objects)
        {
            foreach (var obj in objects)
            {
                obj.Position = new Point(obj.OriginalPosition.X + Position.X, +obj.OriginalPosition.Y + Position.Y);
            }
        }


    }
}
