using DotEngine.FywwEngine;
using DotEngine.FywwEngine.Audio;
using DotEngine.FywwEngine.Drawable.ASprite;
using DotEngine.FywwEngine.Drawable.Shapes;
using DotEngine.FywwEngine.Window;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Net;
using System.Reflection;

public class Program : AGame
{
    private ARectangle rectangle;

    static AWindow window;
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
        _sprite = new ASprite(new Vector2f(0, 0), texture);
    }


    public override void Update()
    {
        Movement();
    }

    private void Movement()
    {
        _sprite.Position += new Vector2f(0.01f, 0.01f);
        var pos = window.GetWindowPosition();

        if (InputManager.IsKeyPressed(Keyboard.Key.W))
        {
            window.SetWindowPosition(pos += new Vector2i(0, -1));
        }
        if (InputManager.IsKeyPressed(Keyboard.Key.A))
        {
            window.SetWindowPosition(pos += new Vector2i(-1, 0));
        }
        if (InputManager.IsKeyPressed(Keyboard.Key.S))
        {
            window.SetWindowPosition(pos += new Vector2i(0, 1));
        }
        if (InputManager.IsKeyPressed(Keyboard.Key.D))
        {
            window.SetWindowPosition(pos += new Vector2i(1, 0));
        }
    }

}


