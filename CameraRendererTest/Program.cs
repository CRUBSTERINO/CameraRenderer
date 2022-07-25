using System;

namespace CameraRendererTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Screen._viewportWidth, Screen._viewportHeight);
            Console.SetBufferSize(Screen._viewportWidth, Screen._viewportHeight);
            Console.CursorVisible = false;

            var game = new HomeworkGame();
        }
    }

    public class HomeworkGame : GameLoop
    {
        Scene _currentScene;
        public HomeworkGame()
        {
            var gameScene = new Scene();
            _currentScene = gameScene;

            var player = new Player(gameScene);

            Start();
        }

        protected override void UserInput()
        {
            var keyInfo = Console.ReadKey();

            if (keyInfo != null)
            {
                Input._key = keyInfo.Key;
            }
        }

        protected override void Update()
        {
            _currentScene._Update.Invoke();
        }

        protected override void Render()
        {
            char[,] worldSource = _currentScene._GameWorld.World();
            bool[,] shotResult = _currentScene._Camera.GetShot();

            char[] outputChar = new char[Screen._viewportWidth * Screen._viewportHeight];
                 
            for (int y = 0; y < Screen._viewportHeight; y++)
            {
                for (int x = 0; x < Screen._viewportWidth; x++)
                {
                    if (shotResult[y, x] == true)
                    {
                        outputChar[y * Screen._viewportWidth + x] = worldSource[y, x];
                    }
                    else
                    {
                        outputChar[y * Screen._viewportWidth + x] = ' ';
                    }
                }
            }
            string output = new string(outputChar);

            Console.WriteLine(output);
        }
    }

    public class Player : GameObject
    {
        public Player(Scene scene) : base(scene)
        {
            _x = Screen._viewportWidth / 2;
            _y = Screen._viewportHeight / 2;
            _symbol = DisplaySymbols._player;
        }

        protected override void Update()
        {
            Movement(Input._key);
        }

        public void Movement (ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W:
                    _y--;
                    break;
                case ConsoleKey.S:
                    _y++;
                    break;
                case ConsoleKey.A:
                    _x--;
                    break;
                case ConsoleKey.D:
                    _x++;
                    break;
            }
        }
    }
}
