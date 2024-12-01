using SFML.Graphics;
using SFML.System;

namespace Dot
{
    public class Camera
    {
        private readonly View _view;

        public Camera(Vector2f center, Vector2f size)
        {
            _view = new View(center, size);
        }

        public Vector2f Center
        {
            get => _view.Center;
            set => _view.Center = value;
        }

        public Vector2f Size
        {
            get => _view.Size;
            set => _view.Size = value;
        }

        public float Rotation
        {
            get => _view.Rotation;
            set => _view.Rotation = value;
        }

        public float ZoomFactor { get; private set; } = 1.0f;

        public void Move(Vector2f offset)
        {
            _view.Move(offset);
        }

        public void Zoom(float factor)
        {
            ZoomFactor *= factor;
            _view.Zoom(factor);
        }

        public void Rotate(float angle)
        {
            _view.Rotate(angle);
        }

        public View GetView() => _view;
    }
}