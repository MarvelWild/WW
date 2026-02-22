using MonoGame.Extended.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace WildWorld.Service
{
	public static class Input
	{
		public static KeyboardStateExtended Kb;
		public static void Update()
		{
			KeyboardExtended.Update();
			Kb = KeyboardExtended.GetState();
		}

		public static void Clear()
		{
			Kb = new KeyboardStateExtended();
		}
	}
}
