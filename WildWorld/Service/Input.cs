using MonoGame.Extended.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace WildWorld.Service
{
	public static class Input
	{
		public static KeyboardStateExtended Kb;
		public static MouseStateExtended Mouse;
		public static void Update()
		{
			KeyboardExtended.Update();
			MouseExtended.Update();

			Kb = KeyboardExtended.GetState();
			Mouse = MouseExtended.GetState();
		}

		public static void Clear()
		{
			Kb = new KeyboardStateExtended();
			Mouse = new MouseStateExtended();
		}
	}
}
