using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using WildWorld.Component;
using WildWorld.System;

namespace WildWorld
{
	/// <summary>
	/// Game master. Handles logic.
	/// </summary>
	internal class GM
	{
		public static GM Instance;

		private World _world;
		private Entity _playerEntity;
		private Character _playerCharacter;

		public World World { get { return _world; } }
		

		public void NewGame()
		{
			// todo: new game world

			_world = new WorldBuilder()
				.AddSystem(new PlayerSystem())
				.AddSystem(new RenderSystem(Game1.Instance.SpriteBatch))
				.Build();

			_playerEntity = _world.CreateEntity();
			_playerEntity.Attach(Game1.Instance.Content.Load<Texture2D>("img/human"));

			var characterComponent = new Character();
			characterComponent.Position = new Vector2(100, 120);
			_playerEntity.Attach(characterComponent);

			var playerComponent = new Player();
			_playerEntity.Attach(playerComponent);



		}

		public void Update(GameTime gameTime)
		{
			_world.Update(gameTime);
		}

	}
}
