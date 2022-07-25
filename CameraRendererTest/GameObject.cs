using System;

namespace CameraRendererTest
{
    public class GameObject
    {
        public char _symbol { get; set; }
        public int _x { get; set; }
        public int _y { get; set; }

        protected virtual void Update()
        {

        }

        public GameObject(Scene scene)
        {
            scene._GameWorld.AddGameObject(this);
            scene._Update += this.Update;
        }

        public GameObject(Scene scene, int x, int y)
        {
            scene._GameWorld.AddGameObject(this);
            scene._Update += this.Update;

            _x = x;
            _y = y;
        }
    }
}
