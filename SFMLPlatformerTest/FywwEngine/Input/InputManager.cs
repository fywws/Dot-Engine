﻿using SFML.System;
using SFML.Window;

namespace Dot
{

    public class InputManager
    {
        private readonly HashSet<Keyboard.Key> _pressedKeys = new();
        private readonly HashSet<Mouse.Button> _pressedMouseButtons = new();
        private Vector2i _mousePosition;

        // Методы для проверки состояния
        public bool IsKeyPressed(Keyboard.Key key) => _pressedKeys.Contains(key);

        public bool IsMouseButtonPressed(Mouse.Button button) => _pressedMouseButtons.Contains(button);

        public Vector2i GetMousePosition() => _mousePosition;

        // Методы изменения состояния (теперь internal)
        internal void HandleKeyPressed(KeyEventArgs key) => _pressedKeys.Add(key.Code);

        internal void HandleKeyReleased(KeyEventArgs key) => _pressedKeys.Remove(key.Code);

        internal void HandleMouseButtonPressed(MouseButtonEventArgs button) => _pressedMouseButtons.Add(button.Button);

        internal void HandleMouseButtonReleased(MouseButtonEventArgs button) => _pressedMouseButtons.Remove(button.Button);

        internal void UpdateMousePosition(Vector2i position) => _mousePosition = position;
    }

    public class InputAccess
    {
        private readonly InputManager _inputManager;

        public InputAccess(InputManager inputManager)
        {
            _inputManager = inputManager;
        }

        public void HandleKeyPressed(KeyEventArgs key) => _inputManager.HandleKeyPressed(key);

        public void HandleKeyReleased(KeyEventArgs key) => _inputManager.HandleKeyReleased(key);

        public void HandleMouseButtonPressed(MouseButtonEventArgs button) => _inputManager.HandleMouseButtonPressed(button);

        public void HandleMouseButtonReleased(MouseButtonEventArgs button) => _inputManager.HandleMouseButtonReleased(button);

        public void UpdateMousePosition(Vector2i position) => _inputManager.UpdateMousePosition(position);
    }

}