using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Dot
{

    public class Program : AGame
    {
        static ACircle circle;
        static AWindow window = null;
        private Camera cam;

        public static void Main(string[] args)
        {
            new AWindow(new Program(), new WindowOptions("Test", new Vector2u(800, 600)), ref window);
        }

        public override void BeginPlay()
        {
            circle = new ACircle(10f, Color.Magenta, new Vector2f(0, 0));
            cam = new Camera(new Vector2f(800f, 600f), new Vector2f(800f, 600f));
            window.SetCamera(cam);
        }


        public override void Update()
        {
            circle.Shape.Position += new Vector2f(.01f, 0);

            Console.WriteLine(InputManager?.GetMousePosition());

            if (InputManager.IsKeyPressed(Keyboard.Key.Escape))
            {
                Console.WriteLine(window == null ? "window is null" : "window is initialized");
                window?.Close();
            }
            if (InputManager.IsKeyPressed(Keyboard.Key.W))
            {
                Console.WriteLine("text");
                cam.Rotate(10);
            }
        }

    }
}

