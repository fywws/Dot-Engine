using SFML.Graphics;
using SFML.System;

namespace DotEngine.FywwEngine.Drawable.ASprite;

public class ASprite : IDrawable
{
    private Sprite _sprite = new Sprite();

    public ASprite(Vector2f position, Texture texture)
    {
        RenderManagerInstance.Instance.AddDrawable(this);
        this.Position = position;
        this.Texture = texture;

    }

    public ASprite(Vector2f position, Texture texture, Vector2f size)
    {
        RenderManagerInstance.Instance.AddDrawable(this);
        this.Position = position;
        this.Texture = texture;
        this.Size = size;
    }

    public override void Draw(RenderWindow window)
    {
        //_sprite.Color = this.FillColor;
        _sprite.Position = this.Position;
        _sprite.Texture = this.Texture;
        _sprite.Scale = this.Size;

        window.Draw(_sprite);
    }


    public Vector2f Position
    {
        get => _sprite.Position;
        set => _sprite.Position = value;
    }

    public Vector2f Size
    {
        get => _sprite.Scale;
        set => _sprite.Scale = value;
    }

    public Color FillColor
    {
        get => _sprite.Color;
        set => _sprite.Color = value;
    }
}