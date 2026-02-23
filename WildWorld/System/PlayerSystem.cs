using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using System;
using System.Collections.Generic;
using System.Text;
using WildWorld.Component;
using WildWorld.Service;

namespace WildWorld.System
{
	internal class PlayerSystem : EntityProcessingSystem
	{
		private ComponentMapper<Character> _playerMapper;

		private int _speed = 1;

		public PlayerSystem() : base(Aspect.All(typeof(Player))) { }

		public override void Initialize(IComponentMapperService mapperService)
		{
			_playerMapper = mapperService.GetMapper<Character>();
		}

		public override void Process(GameTime gameTime, int entityId)
		{
			Character player = _playerMapper.Get(entityId);

			if (Input.Kb.IsKeyDown(Keys.Left))
			{
				player.Position.X -= _speed;
			}

			if (Input.Kb.IsKeyDown(Keys.Right))
			{
				player.Position.X += _speed;
			}

			if (Input.Kb.IsKeyDown(Keys.Up))
			{
				player.Position.Y -= _speed;
			}

			if (Input.Kb.IsKeyDown(Keys.Down))
			{
				player.Position.Y += _speed;
			}
		}
	}
}
