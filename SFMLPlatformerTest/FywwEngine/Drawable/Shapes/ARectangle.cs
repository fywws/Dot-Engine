using SFML.Graphics;
using SFML.System;

namespace Dot
{

    public class ARectangle : IDrawable
    {
        private RectangleShape rect = new RectangleShape();

        public ARectangle(Vector2f size, Color color, Vector2f position)
        {
            RenderManagerInstance.Instance.AddDrawable(this);
            rect.Size = size;
            rect.FillColor = color;
            rect.Position = position;
            Shape = rect;
        }

        public Vector2f Position
        {
            get => rect.Position;
            set => rect.Position = value;
        }

        public Vector2f Size
        {
            get => rect.Size;
            set => rect.Size = value;
        }

        public Color FillColor
        {
            get => rect.FillColor;
            set => rect.FillColor = value;
        }

    }
}