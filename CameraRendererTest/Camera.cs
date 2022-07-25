using System.Drawing;
using System;

namespace CameraRendererTest
{
    public class Camera
    {
        private Point _position;
        private Size _size;

        private Rectangle _viewport;
        private GameWorld _world;

        public Camera(Scene scene)
        {
            scene._Update += this.Movement;

            _position = new Point(0, 0);
            _size = new Size(Screen._viewportWidth, Screen._viewportHeight);

            _world = scene._GameWorld;
            _viewport = new Rectangle(_position, _size);
        }

        public bool[,] GetShot()
        {
            bool[,] data = new bool[_viewport.Height, _viewport.Width];
            for (int i = 0; i < _viewport.Height; i++)
            {
                for (int j = 0; j < _viewport.Width; j++)
                {
                    foreach (GameObject gameObject in _world._gameObjects)
                    {
                        if (gameObject._x == j && gameObject._y == i)
                        {
                            data[i, j] = true;
                        }
                    }
                }
            }

            return data;
        }

        public void Movement()
        {
            switch (Input._key)
            {
                case ConsoleKey.UpArrow:
                    _position.Y++;
                    _viewport.Location = _position;
                    break;
                case ConsoleKey.DownArrow:
                    _position.Y--;
                    _viewport.Location = _position;
                    break;
                case ConsoleKey.LeftArrow:
                    _position.X--;
                    _viewport.Location = _position;
                    break;
                case ConsoleKey.RightArrow:
                    _position.X++;
                    _viewport.Location = _position;
                    break;
                default:
                    break;
            }
        }
    }
}
