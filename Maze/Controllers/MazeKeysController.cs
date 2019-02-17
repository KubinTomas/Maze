using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze.Controllers
{
    public class MazeKeysController
    {
        private Dictionary<Keys, bool> _pressedKeys;

        public MazeKeysController()
        {
            _pressedKeys = new Dictionary<Keys, bool>();
        }
        public void AddKey(Keys key)
        {
            if (!ContainsKey(key))
                _pressedKeys.Add(key, true);
        }
        public void RemoveKey(Keys key)
        {
            
            if (ContainsKey(key))
                _pressedKeys.Remove(key);
        }
        private bool ContainsKey(Keys key)
        {
            return _pressedKeys.ContainsKey(key);
        }
    }
}
