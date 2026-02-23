using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using System;
using System.Windows.Forms;
using WildWorld.Screen;
using WildWorld.Service;
using Keys = Microsoft.Xna.Framework.Input.Keys;


namespace WildWorld
{
    public class Game1 : Game
    {
		public static Game1 Instance;

		private bool _isFullScreen = false;
		private int _windowedWidth;
		private int _windowedHeight;

		private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
		private readonly ScreenManager _screenManager;
		private long _frameNumber;

		public long FrameNumber { get => _frameNumber; }
		public SpriteBatch SpriteBatch { get => _spriteBatch; set => _spriteBatch = value; }
		public ScreenManager ScreenManager => _screenManager;

		public Game1()
        {
			Instance = this;

			_graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
			_screenManager = new ScreenManager();
			Components.Add(_screenManager);

			Window.AllowUserResizing = true;
			Window.ClientSizeChanged += OnResize;
		}

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

			GM.Instance = new GM();
			GM.Instance.NewGame();

			_screenManager.ShowScreen(Screens.GameplayScreen);
		}

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
			_frameNumber++;
			Input.Update();

			if (Input.Kb.WasKeyPressed(Keys.F12))
			{
				ToggleFullScreen();
			}

			GM.Instance.Update(gameTime);

			base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

		private void ToggleFullScreen()
		{
			// Toggle between fullscreen and windowed, preserving the previous windowed size.
			if (!_isFullScreen)
			{
				// Save current windowed size before switching
				_windowedWidth = _graphics.PreferredBackBufferWidth;
				_windowedHeight = _graphics.PreferredBackBufferHeight;

				// Switch to fullscreen using the display's current resolution

				_graphics.IsFullScreen = true;
				_graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
				_graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
			}
			else
			{
				// Restore previously saved windowed size
				_graphics.IsFullScreen = false;
				_graphics.PreferredBackBufferWidth = _windowedWidth;
				_graphics.PreferredBackBufferHeight = _windowedHeight;
			}

			_graphics.ApplyChanges();
			_isFullScreen = !_isFullScreen;
		}

		public void OnResize(Object sender, EventArgs e)
		{

			if ((_graphics.PreferredBackBufferWidth != _graphics.GraphicsDevice.Viewport.Width) ||
				(_graphics.PreferredBackBufferHeight != _graphics.GraphicsDevice.Viewport.Height))
			{
				_graphics.PreferredBackBufferWidth = _graphics.GraphicsDevice.Viewport.Width;
				_graphics.PreferredBackBufferHeight = _graphics.GraphicsDevice.Viewport.Height;
				_graphics.ApplyChanges();
			}
		}
	} // Game1
}
