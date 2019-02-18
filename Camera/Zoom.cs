using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera
{
    public class Zoom
    {
        public float Value { get; set; }

        public float Speed { get; set; }

        public enum ZoomStatus { ZoomIn, ZoomOut, Nothing };

        public Zoom()
        {
            Value = CameraBase.DefaultZoom;
            Speed = CameraBase.DefaultZoomSpeed;
        }
    }
}
