using SFML.System;

namespace DotEngine.FywwEngine.Collision.Colliders;

public class CircleCollider : ICollider
{
    public Vector2f Position { get; set; }
    public float Radius { get; set; }

    public CircleCollider(Vector2f position, float radius)
    {
        Position = position;
        Radius = radius;
    }

    public bool CheckCollision(ICollider other)
    {
        if (other is CircleCollider circle)
        {
            Vector2f distanceNonNormilized = (circle.Position - this.Position);
            float distance = MathF.Pow(distanceNonNormilized.X, 2) + MathF.Pow(distanceNonNormilized.Y, 2);
            return distance < (this.Radius + circle.Radius);
        }
        else if (other is RectangleCollider rect)
        {
            return rect.CheckCollision(this); // Используем метод прямоугольника
        }

        return false;
    }
}