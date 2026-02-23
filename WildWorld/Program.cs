using WildWorld.Util;
using System;
using System.Runtime.InteropServices;
using WildWorld;

namespace WildWorld
{
	public static class Program
	{
		public static void Main(string[] args)
		{
#if DEBUG
			AllocConsole();
			Console.WriteLine("Debug mode.");
#endif
			try
			{
				using var game = new Game1();
				game.Run();
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString());
#if DEBUG
				//Console.ReadLine();
				throw;
#endif

			}
		} // main

#if DEBUG
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool AllocConsole();
#endif
	}


}
