using SFML.Graphics;
using SFML.System;

namespace DotEngine.FywwEngine.Drawable.Shapes
{

    public class ARectangle : IDrawable
    {
        private RectangleShape rect = new RectangleShape();

        public ARectangle(Vector2f size, Color color, Vector2f position)
        {
            RenderManagerInstance.Instance.AddDrawable(this);
            this.Size = size;
            this.FillColor = color;
            this.Position = position;
        }

        public override void Draw(RenderWindow window)
        {
            rect.Size = this.Size;
            rect.FillColor = this.FillColor;
            rect.Position = this.Position;

            window.Draw(rect);
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