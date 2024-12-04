using SFML.Graphics;
using SFML.System;

namespace DotEngine.FywwEngine.Drawable.Shapes
{

    public class ACircle : IDrawable
    {
        private CircleShape circle = new CircleShape();

        public ACircle(float radius, Color color, Vector2f position)
        {
            RenderManagerInstance.Instance.AddDrawable(this);
            circle.Radius = radius;
            circle.FillColor = color;
            circle.Position = position;
        }

        public override void Draw(RenderWindow window)
        {
            window.Draw(circle);
        }


        public Vector2f Position
        {
            get => circle.Position;
            set => circle.Position = value;
        }

        public float Radius
        {
            get => circle.Radius;
            set => circle.Radius = value;
        }

        public Color FillColor
        {
            get => circle.FillColor;
            set => circle.FillColor = value;
        }

    }
}