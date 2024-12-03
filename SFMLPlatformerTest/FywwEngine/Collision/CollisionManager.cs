namespace DotEngine.FywwEngine.Collision;

public class CollisionManager
{
    private List<ICollider> colliders = new List<ICollider>();

    public void AddCollider(ICollider collider)
    {
        colliders.Add(collider);
    }

    public void CheckCollisions()
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            for (int j = i + 1; j < colliders.Count; j++)
            {
                if (colliders[i].CheckCollision(colliders[j]))
                {
                    Console.WriteLine($"Collision detected between {colliders[i]} and {colliders[j]}");
                }
            }
        }
    }
}
