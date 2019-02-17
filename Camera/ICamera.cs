using MathExtension;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera
{
    interface ICamera
    {
        void Move(Vector2 vector);
    }
}
