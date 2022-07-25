using System;

namespace CameraRendererTest
{
    public class Scene
    {
        public GameWorld _GameWorld;
        public Camera _Camera;

        public Update _Update;

        public delegate void Update();

        public Scene()
        {
            _GameWorld = new GameWorld();
            _Camera = new Camera(this);
        }
    }
}
