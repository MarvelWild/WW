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
using WildWorld.Util;

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

				playerCharacter.DesiredPosition = Input.GetMousePos();
				Log.Info("playerCharacter.DesiredPosition:" + playerCharacter.DesiredPosition);
			}

			//var ms = Mouse.GetState();
			//Log.Info(ms.ToString());



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

			// todo: diagonal speed
			if (playerCharacter.DesiredPosition.X != playerCharacter.Position.X)
			{
				var directionX = playerCharacter.DesiredPosition.X > playerCharacter.Position.X ? 1 : -1;
				var distanceX = Math.Abs(playerCharacter.DesiredPosition.X - playerCharacter.Position.X);
				var distancePerFrame = Math.Min(distanceX, _speed);
				var xDelta = distancePerFrame * directionX;
				playerCharacter.Position.X += xDelta;
			}

			if (playerCharacter.DesiredPosition.Y != playerCharacter.Position.Y)
			{
				var directionY = playerCharacter.DesiredPosition.Y > playerCharacter.Position.Y ? 1 : -1;
				var distanceY = Math.Abs(playerCharacter.DesiredPosition.Y - playerCharacter.Position.Y);
				var distancePerFrame = Math.Min(distanceY, _speed);
				playerCharacter.Position.Y += distancePerFrame * directionY;
			}

			// GT.Camera.Position = playerCharacter.Position;
			GT.Camera.LookAt(playerCharacter.Position);
		} // Process
	} // PlayerSystem
}
