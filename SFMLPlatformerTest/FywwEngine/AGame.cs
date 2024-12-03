using DotEngine.FywwEngine.Input;

namespace DotEngine.FywwEngine
{
    public class AGame
    {
        protected InputManager? InputManager;

        public void SetInputManager(InputManager inputManager)
        {
            InputManager = inputManager;
        }

        public virtual void BeginPlay() { }
        public virtual void Update() { }
    }
}