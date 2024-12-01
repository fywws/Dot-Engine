using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Dot
{
    public struct WindowOptions
    {
        public string Title { get; }
        public Vector2u Size { get; }
        public WindowOptions(string title = "Not specified", Vector2u size = default)
        {
            Title = title;
            Size = size;
        }
    }

    public class AWindow
    {
        private RenderWindow? _win;
        private readonly WindowOptions _options;
        private readonly AGame _game;
        private readonly InputManager _inputManager = new();
        private readonly InputAccess _inputAccess;

        public AWindow(AGame game, WindowOptions windowOptions)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            _options = windowOptions;

            _inputAccess = new InputAccess(_inputManager);

            try
            {

                InitializeWindow();
                _game.SetInputManager(_inputManager);
                AttachEventHandlers();
                Start();
                Render();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Window initialization failed: {ex.Message}");
                throw;
            }
        }

        public AWindow(AGame game, WindowOptions windowOptions, ref AWindow window)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            _options = windowOptions;
            window = this;

            _inputAccess = new InputAccess(_inputManager);

            try
            {
                InitializeWindow();
                _game.SetInputManager(_inputManager);
                AttachEventHandlers();
                Start();
                Render();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Window initialization failed: {ex.Message}");
                throw;
            }
        }

        public void SetCamera(Camera camera) { 
            _win?.SetView(camera.GetView());
        }

        private void InitializeWindow()
        {
            _win = new RenderWindow(
                new VideoMode((uint)_options.Size.X, (uint)_options.Size.Y),
                _options.Title
            );
        }

        private void AttachEventHandlers()
        {
            if (_win == null)
                throw new InvalidOperationException("Window has not been initialized.");

            // Привязка событий
            _win.KeyPressed += (sender, e) => _inputAccess.HandleKeyPressed(e);
            _win.KeyReleased += (sender, e) => _inputAccess.HandleKeyReleased(e);
            _win.MouseButtonPressed += (sender, e) => _inputAccess.HandleMouseButtonPressed(e);
            _win.MouseButtonReleased += (sender, e) => _inputAccess.HandleMouseButtonReleased(e);
            _win.MouseMoved += (sender, e) => _inputAccess.UpdateMousePosition(new Vector2i(e.X, e.Y));

            _win.Resized += (sender, e) =>
            {
                float aspectRatio = (float)e.Width / e.Height;
                var view = new View(new FloatRect(0, 0, 800, 800 / aspectRatio));
                _win.SetView(view);
            };
            _win.Closed += (sender, e) => Close();
        }

        public InputManager GetInputManager() => _inputManager;

        public void Start()
        {
            _game?.BeginPlay();
        }

        public void Render()
        {
            if (_win == null)
                throw new InvalidOperationException("Window has not been initialized.");

            while (_win.IsOpen)
            {
                _win.DispatchEvents();
                _game?.Update();
                _win.Clear(Color.Black);

                var renderManager = RenderManagerInstance.Instance;
                if (renderManager?.drawables != null)
                {
                    foreach (var drawable in renderManager.drawables)
                    {
                        _win.Draw(drawable.Shape);
                    }
                }

                _win.Display();
            }
        }

        public void Close()
        {
            if (_win is { IsOpen: true })
            {
                _win.Close();
            }
        }
    }
}