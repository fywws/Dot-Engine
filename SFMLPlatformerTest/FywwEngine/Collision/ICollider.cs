using SFML.System;

namespace DotEngine.FywwEngine.Collision;

public interface ICollider
{
    bool CheckCollision(ICollider other);
    Vector2f Position { get; set; }
}

public static class Vector2fExtensions
{
    public static float Magnitude(this Vector2f vector)
    {
        return (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
    }
}
