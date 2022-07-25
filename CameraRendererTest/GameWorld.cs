using System.Collections.Generic;

namespace CameraRendererTest
{
    public class GameWorld
    {
        public List<GameObject> _gameObjects;

        public GameWorld()
        {
            _gameObjects = new List<GameObject>();
        }

        public void AddGameObject(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        public char[,] World()
        {
            char[,] data = new char[Screen._mapHeight, Screen._mapWidth];

            foreach (GameObject gameObject in _gameObjects)
            {
                data[gameObject._y, gameObject._x] = gameObject._symbol;
            }

            return data;
        }
    }
}
