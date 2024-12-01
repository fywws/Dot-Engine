using SFML.Graphics;
namespace Dot
{
    public abstract class IDrawable
    {
        public Shape Shape { get; protected set; }
    }
}