namespace DotEngine.FywwEngine.Drawable
{
    public class RenderManager
    {
        public readonly List<IDrawable> drawables = new List<IDrawable>();

        public void AddDrawable(IDrawable drawable)
        {
            drawables.Add(drawable);
        }

    }

}