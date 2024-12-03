namespace DotEngine.FywwEngine.Drawable
{
    public class RenderManagerInstance
    {
        private static readonly Lazy<RenderManager> instance = new(() => new RenderManager());
        public static RenderManager Instance => instance.Value;

    }
}