using DotEngine.FywwEngine;
using DotEngine.FywwEngine.Audio;
using DotEngine.FywwEngine.Content;
using DotEngine.FywwEngine.Drawable.ASprite;
using DotEngine.FywwEngine.Drawable.Shapes;
using DotEngine.FywwEngine.Window;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

    public class Program : AGame
    {
        private ARectangle rectangle;
        
        static AWindow window = null;
        private ASprite _sprite;
        private AudioFile file;
        private AudioPlayer Player;
        
        public static void Main(string[] args)
        {
            new AWindow(new Program(), new WindowOptions("Test", new Vector2u(800, 600)), ref window);
        }

        public override void BeginPlay()
        {
            var texture = new Texture("C:\\Users\\kovma\\source\\repos\\SFMLPlatformerTest\\SFMLPlatformerTest\\player.jpg");
            
            _sprite = new ASprite(new Vector2f(0,0), texture);
        }


        public override void Update()
        {
            if (InputManager.IsKeyPressed(Keyboard.Key.A))
            {
                _sprite.Position -= new Vector2f(0.01f, 0f);
            }
            if (InputManager.IsKeyPressed(Keyboard.Key.W))
            {
                _sprite.Position -= new Vector2f(0f, 0.01f);
            }
            if (InputManager.IsKeyPressed(Keyboard.Key.S))
            {
                _sprite.Position += new Vector2f(0f, 0.01f);
            }
            if (InputManager.IsKeyPressed(Keyboard.Key.D))
            {
                _sprite.Position += new Vector2f(0.01f, 0f);
            }
        }

    }


