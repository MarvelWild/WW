using System;
using System.Collections.Generic;
using System.Text;

namespace WildWorld.Screen
{
	public static class Screens
	{
		private static GameplayScreen _gameplayScreen;
		//private static CharacterScreen _characterScreen;

		//public static MainMenuScreen MenuScreen { get; set; }
		public static GameplayScreen GameplayScreen
		{
			get
			{
				if (_gameplayScreen == null)
				{
					_gameplayScreen = new GameplayScreen(Game1.Instance);
				}
				return _gameplayScreen;
			}
			set => _gameplayScreen = value;
		}

		//public static CharacterScreen CharacterScreen
		//{
		//	get
		//	{
		//		if (_characterScreen == null)
		//		{
		//			_characterScreen = new CharacterScreen(Game1.Instance);
		//		}
		//		return _characterScreen;
		//	}
		//	set => _characterScreen = value;
		//}
	}

}
