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

		private OrthographicCamera _camera;


		public override void Initialize()
		{
			base.Initialize();

			var viewportAdapter = new BoxingViewportAdapter(Game1.Instance.Window, GraphicsDevice, 1200, 720);
			_camera = new OrthographicCamera(viewportAdapter);
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
