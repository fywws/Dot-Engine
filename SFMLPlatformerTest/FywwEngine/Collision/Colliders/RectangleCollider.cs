using SFML.System;

namespace DotEngine.FywwEngine.Collision.Colliders;

public class RectangleCollider : ICollider
{
    public Vector2f Position { get; set; } // Верхний левый угол
    public Vector2f Size { get; set; }

    public RectangleCollider(Vector2f position, Vector2f size)
    {
        Position = position;
        Size = size;
    }

    public bool CheckCollision(ICollider other)
    {
        if (other is RectangleCollider rect)
        {
            return this.Position.X < rect.Position.X + rect.Size.X &&
                   this.Position.X + this.Size.X > rect.Position.X &&
                   this.Position.Y < rect.Position.Y + rect.Size.Y &&
                   this.Position.Y + this.Size.Y > rect.Position.Y;
        }
        else if (other is CircleCollider circle)
        {
            Vector2f closestPoint = new Vector2f(
                Math.Clamp(circle.Position.X, this.Position.X, this.Position.X + this.Size.X),
                Math.Clamp(circle.Position.Y, this.Position.Y, this.Position.Y + this.Size.Y)
            );

            Vector2f distanceNonNormilized = (closestPoint - circle.Position);
            float distance = MathF.Pow(distanceNonNormilized.X, 2) + MathF.Pow(distanceNonNormilized.Y, 2);
            
            return distance < circle.Radius;
        }

        return false;
    }
}