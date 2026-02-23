using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using MonoGame.Extended.Input;
using System;
using System.Collections.Generic;
using System.Text;
using WildWorld.Component;
using WildWorld.Service;

namespace WildWorld.System
{
	internal class PlayerSystem : EntityProcessingSystem
	{
		private ComponentMapper<Character> _characterMapper;

		private int _speed = 1;

		public PlayerSystem() : base(Aspect.All(typeof(Player))) { }

		public override void Initialize(IComponentMapperService mapperService)
		{
			_characterMapper = mapperService.GetMapper<Character>();
		}

		public override void Process(GameTime gameTime, int entityId)
		{
			Character playerCharacter = _characterMapper.Get(entityId);

			if (Input.Mouse.WasButtonPressed(MouseButton.Left))
			{
				// todo: mouse to world coord transform (when cam implemented)
				
				playerCharacter.DesiredPosition = Input.Mouse.Position.ToVector2();
			}

			if (Input.Kb.IsKeyDown(Keys.Left))
			{
				playerCharacter.Position.X -= _speed;
			}

			if (Input.Kb.IsKeyDown(Keys.Right))
			{
				playerCharacter.Position.X += _speed;
			}

			if (Input.Kb.IsKeyDown(Keys.Up))
			{
				playerCharacter.Position.Y -= _speed;
			}

			if (Input.Kb.IsKeyDown(Keys.Down))
			{
				playerCharacter.Position.Y += _speed;
			}
		}
	}
}
