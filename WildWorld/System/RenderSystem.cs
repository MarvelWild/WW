using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using System;
using System.Collections.Generic;
using System.Text;
using WildWorld.Component;

namespace WildWorld.System
{
	internal class RenderSystem : EntityDrawSystem
	{
		private SpriteBatch _spriteBatch;
		private ComponentMapper<Texture2D> _textureMapper;
		private ComponentMapper<Character> _characterMapper;

		public RenderSystem(SpriteBatch spriteBatch)
			: base(Aspect.All(typeof(Texture2D), typeof(Player)))
		{
			_spriteBatch = spriteBatch;
		}
		public override void Draw(GameTime gameTime)
		{
			//_spriteBatch.Begin();

			foreach (var entityId in ActiveEntities)
			{
				var texture = _textureMapper.Get(entityId);
				var character = _characterMapper.Get(entityId);
				_spriteBatch.Draw(texture, new Rectangle((int)character.Position.X, (int)character.Position.Y, texture.Width, texture.Height), Color.White);
			}

			//_spriteBatch.End();
		}

		public override void Initialize(IComponentMapperService mapperService)
		{
			_textureMapper = mapperService.GetMapper<Texture2D>();
			_characterMapper = mapperService.GetMapper<Character>();
		}
	}
}
