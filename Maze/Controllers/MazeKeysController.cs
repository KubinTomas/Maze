using MathExtension;
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

        public void ActiveKey(Keys key)
        {
            if (ContainsKey(key))
                _pressedKeys[key] = true;
            else
                AddKey(key);
        }
        public void DeactiveKey(Keys key)
        {
            if (ContainsKey(key))
                _pressedKeys[key] = false;
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
        public Vector2 GetVectorFromPressedKeys()
        {
            return ConstructMoveVector();
        }
        private Vector2 ConstructMoveVector()
        {
            int x = 0;
            int y = 0;

            if (ContainsKey(Keys.A) && _pressedKeys[Keys.A]) x -= 1;
            if (ContainsKey(Keys.D) && _pressedKeys[Keys.D]) x += 1;

            if (ContainsKey(Keys.W) && _pressedKeys[Keys.W]) y -= 1;
            if (ContainsKey(Keys.S) && _pressedKeys[Keys.S]) y += 1;

            return new Vector2(x, y);
        }
    }
}
