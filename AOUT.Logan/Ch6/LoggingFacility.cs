using AOUT.Logan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOUT.Logan.Ch6
{
	public static class LoggingFacility
	{
		public static void Log(string text)
		{
			logger.Log(text);
		}
		private static ILogger logger;
		public static ILogger Logger
		{
			get { return logger; }
			set { logger = value; }
		}
	}
}
