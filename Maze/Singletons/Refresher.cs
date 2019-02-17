using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Camera;

namespace Maze.Singletons
{
    /// <summary>
    /// Class responsive for repaiting 
    /// </summary>
    class Refresher
    {
        private static Refresher instance;

        private PictureBox _canvas;
        private CameraBase _camera;

        private Refresher() { }

        public static Refresher Instance
        {
            get
            {
                if (instance == null)
                    instance = new Refresher();
                return instance;
            }
        }
        public void SetCanvas(PictureBox canvas)
        {
            _canvas = canvas;
        }
        public void SetCamera(CameraBase camera)
        {
            _camera = camera;
        }
        public void Refresh()
        {
            _canvas.Refresh();
        }
        public void RefreshWithCam()
        {
            Refresh();

        }
    }
}
