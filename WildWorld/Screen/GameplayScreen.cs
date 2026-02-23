using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Screens;
using MonoGame.Extended.ViewportAdapters;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WildWorld.Screen
{
	public class GameplayScreen : GameScreen
	{
		private bool _isContentLoaded = false;
		private Texture2D _bg;

		private OrthographicCamera _camera;
		private Rectangle _bgRectangle;


		public override void Initialize()
		{
			base.Initialize();

			var viewportAdapter = new BoxingViewportAdapter(Game1.Instance.Window, GraphicsDevice, 1200, 720);
			_camera = new OrthographicCamera(viewportAdapter);
			_bg = Game1.Instance.Content.Load<Texture2D>("img/bg1");
			_bgRectangle = new Rectangle(0, 0, _bg.Width, _bg.Height);
			_camera.EnableWorldBounds(_bgRectangle);
			GT.Camera = _camera;
		}


		public override void LoadContent()
		{
			if (_isContentLoaded) return;

			base.LoadContent();

			


			_isContentLoaded = true;
		}

		public GameplayScreen(Game game) : base(game)
		{
		}

		public override void Draw(GameTime gameTime)
		{
			var sb = Game1.Instance.SpriteBatch;

			// Apply camera transformation
			sb.Begin(transformMatrix: _camera.GetViewMatrix());

			Game1.Instance.SpriteBatch.Draw(_bg, _bgRectangle, Color.White);

			GM.Instance.World.Draw(gameTime);
			

			sb.End();




			//sb.Begin();
			//sb.Draw(_player, Vector2.Zero, Color.White);
			////sb.DrawString(Res.MainFont, GameTimer.NowDate, _datePosition, Color.White);
			////sb.DrawString(Res.MainFont, GameTimer.NowTime, _timePosition, Color.White);
			//sb.End();
		}

		public override void Update(GameTime gameTime)
		{
			// _camera.Position = _player.Position;
		}
	}
}
