using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Channels;

namespace WildWorld.Util
{
    public static class Log
    {
        private static Logger _logger;
		static Log()
        { 
            _logger = new Logger();
        }


        public static void Info(string msg)
        {
			_logger.Info(msg);
		}

        public static void Info(string channel, string msg)
        {
			_logger.Info(channel, msg);
		}

        public static void Warn(string msg)
        {
			_logger.Warn(msg);
		}

        public static void Error(string msg)
        {
           _logger.Error(msg);
        }

    } // Log
} // namespace Novel.Client.Util