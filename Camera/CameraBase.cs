﻿using MathExtension;
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

        public Zoom ZoomObj { get; set; }

        public float Speed { get; set; }

        protected bool _cameraWasChanged;

        public abstract void Move(Vector2 vector);

        public abstract void ZoomCamera(Zoom.ZoomStatus zoomStatus);

        public abstract void UpdateObjectsRelativeToCamera(List<ICameraObject> objects);

        protected void ZoomIn()
        {
            ZoomObj.Value += ZoomObj.Speed;
        }
        protected void ZoomOut()
        {
            ZoomObj.Value -= ZoomObj.Speed;
        }

        public bool IsDirty()
        {
            return _cameraWasChanged;
        }

        public static int DefaultZoom = 1;
        public static float DefaultZoomSpeed = 0.05f;

        public static int DefaultSpeed = 10;
        public static Point DefaultPosition = new Point(0,0);
    }
}
