using System;
using System.Collections.Generic;
using System.Text;

namespace WildWorld.Util
{
	public class Logger : MW.Core.CoreLog
	{
		protected override string FormatMessage(string level, string msg)
		{
			if (Game1.Instance != null)
			{
				return string.Concat(
					Game1.Instance.FrameNumber, " ", base.FormatMessage(level, msg));
			}
			else
			{
				return base.FormatMessage(level, msg);
			}
		}
	}
}
