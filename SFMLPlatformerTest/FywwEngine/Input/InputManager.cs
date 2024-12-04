using SFML.System;
using SFML.Window;

namespace DotEngine.FywwEngine.Input
{

    public class InputManager
    {
        private readonly HashSet<Keyboard.Key> _pressedKeys = new();
        private readonly HashSet<Keyboard.Key> _previousPressedKeys = new();
        private readonly HashSet<Mouse.Button> _pressedMouseButtons = new();
        private readonly HashSet<Mouse.Button> _previousMousePressedButtons = new();

        private Vector2i _mousePosition;

        public bool IsKeyPressed(Keyboard.Key key) => _pressedKeys.Contains(key);

        public bool IsKeyJustPressed(Keyboard.Key key)
        {
            return _pressedKeys.Contains(key) && !_previousPressedKeys.Contains(key);
        }

        public bool IsKeyJustReleased(Keyboard.Key key)
        {
            return !_pressedKeys.Contains(key) && _previousPressedKeys.Contains(key);
        }

        public bool IsMouseButtonJustPressed(Mouse.Button button)
        {
            return _pressedMouseButtons.Contains(button) && !_previousMousePressedButtons.Contains(button);
        }

        public bool IsMouseButtonJustReleased(Mouse.Button button)
        {
            return !_pressedMouseButtons.Contains(button) && _previousMousePressedButtons.Contains(button);
        }

        
        public bool IsMouseButtonPressed(Mouse.Button button) => _pressedMouseButtons.Contains(button);

        public Vector2i GetMousePosition() => _mousePosition;

        public void SetMousePosition(Vector2i position) => Mouse.SetPosition(position);

        internal void HandleKeyPressed(KeyEventArgs key) => _pressedKeys.Add(key.Code);

        internal void HandleKeyReleased(KeyEventArgs key) => _pressedKeys.Remove(key.Code);

        internal void HandleMouseButtonPressed(MouseButtonEventArgs button) => _pressedMouseButtons.Add(button.Button);

        internal void HandleMouseButtonReleased(MouseButtonEventArgs button) => _pressedMouseButtons.Remove(button.Button);

        internal void UpdateMousePosition(Vector2i position) => _mousePosition = position;

        public void UpdateKeys()
        {
            _previousPressedKeys.Clear();
            foreach (var key in _pressedKeys)
            {
                _previousPressedKeys.Add(key);
            }

            _previousMousePressedButtons.Clear();
            foreach (var key in _pressedMouseButtons)
            {
                _previousMousePressedButtons.Add(key);
            }
        }

    }

    public class InputAccess
    {
        private readonly InputManager _inputManager;

        public InputAccess(InputManager inputManager)
        {
            _inputManager = inputManager;
        }

        public void HandleKeyPressed(KeyEventArgs key)
        {
            _inputManager.HandleKeyPressed(key);
        }

        public void HandleKeyReleased(KeyEventArgs key)
        {
            _inputManager.HandleKeyReleased(key);
        }

        public void HandleMouseButtonPressed(MouseButtonEventArgs button)
        {
            _inputManager.HandleMouseButtonPressed(button);
        }

        public void HandleMouseButtonReleased(MouseButtonEventArgs button)
        {
            _inputManager.HandleMouseButtonReleased(button);
        }

        public void UpdateMousePosition(Vector2i position)
        {
            _inputManager.UpdateMousePosition(position);
        }
    }

}
