using System;
using NLua;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

class Program
{
    static void Main(string[] args)
    {
        // Create the main window
        RenderWindow window = new RenderWindow(new VideoMode(800, 600), "SFML Window");

        // Create a new Lua instance
        Lua lua = new Lua();

        // Load the Lua script
        lua.DoFile("script.lua");

        // Run the main loop
        while (window.IsOpen)
        {
            // Process events
            window.DispatchEvents();

            // Call the Lua function and get the cursor position
            LuaFunction setCursorPosition = lua["set_cursor_position"] as LuaFunction;
            object[] result = setCursorPosition.Call(400, 300); // Example coordinates

            int x = Convert.ToInt32(result[0]);
            int y = Convert.ToInt32(result[1]);

            // Set the cursor position
            Mouse.SetPosition(new Vector2i(x, y), window);

            // Clear the window
            window.Clear();

            // Display the window content
            window.Display();
        }
    }
}
