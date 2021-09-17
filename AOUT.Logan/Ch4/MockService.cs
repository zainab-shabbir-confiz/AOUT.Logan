using AOUT.Logan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOUT.Logan.Ch4
{
	public class MockService: IWebService
	{
		public string LastError;
		public void LogError(string message)
		{
			LastError = message;
		}
	}
}
