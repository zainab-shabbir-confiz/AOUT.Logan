using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOUT.Logan.Ch6
{
	public class ConfigurationManager
	{
		public bool IsConfigured(string configName)
		{
			LoggingFacility.Log("checking " + configName);
			return true;
			//return result;
		}
	}
}
