using SFML.Graphics;
using SFML.System;

namespace DotEngine.FywwEngine.Drawable
{
    public abstract class IDrawable
    {
        public virtual void Draw(RenderWindow window){}
        
        public Vector2f Position { get; set; }
        
        public Vector2f Size { get; set; }
        
        public Color Color { get; set; }
        
        public Texture Texture { get; set; }
        
    }
}