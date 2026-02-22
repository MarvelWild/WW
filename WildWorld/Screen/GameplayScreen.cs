using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;

using System;
using System.Collections.Generic;
using System.Text;

namespace WildWorld.Screen
{
	public class GameplayScreen : GameScreen
	{
		private Texture2D _player;
		private bool _isContentLoaded = false;
		

		


		public override void LoadContent()
		{
			if (_isContentLoaded) return;

			base.LoadContent();

			_player = Content.Load<Texture2D>("img/human");

			_isContentLoaded = true;
		}

		public GameplayScreen(Game game) : base(game)
		{
		}

		public override void Draw(GameTime gameTime)
		{
			var sb = Game1.Instance.SpriteBatch;
			sb.Begin();
			sb.Draw(_player, Vector2.Zero, Color.White);
			//sb.DrawString(Res.MainFont, GameTimer.NowDate, _datePosition, Color.White);
			//sb.DrawString(Res.MainFont, GameTimer.NowTime, _timePosition, Color.White);
			sb.End();
		}

		public override void Update(GameTime gameTime)
		{
		}
	}
}
