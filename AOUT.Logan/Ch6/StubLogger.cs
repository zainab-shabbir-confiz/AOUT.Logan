using AOUT.Logan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOUT.Logan.Ch6
{
	public class StubLogger : ILogger
	{
		public void Log(string text)
		{
			//do nothing
		}
	}
}
