using System.Threading;

namespace CameraRendererTest
{
    public class GameLoop
    {
        public void Start()
        {
            while (true)
            {
                Timing();
                UserInput();
                Update();
                Render();
            }
        }

        private void Timing()
        {
            Thread.Sleep(100);
        }

        protected virtual void UserInput()
        {

        }

        protected virtual void Update()
        {

        }

        protected virtual void Render()
        {

        }
    }
}
