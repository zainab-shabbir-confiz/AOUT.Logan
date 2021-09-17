using AOUT.Logan.Ch3;
using AOUT.Logan.Implementations;
using AOUT.Logan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOUT.Logan
{
	public class LogAnalyzer
	{
		private IExtensionManager manager;
		private ExtensionManagerFactory factory;

		public LogAnalyzer()
		{
			manager = new FileExtensionManager();
			manager = factory.Create();
		}
		public LogAnalyzer(IExtensionManager mgr)
		{
			manager = mgr;
		}
		public bool IsValidLogFileName(string fileName)
		{
			return manager.IsValid(fileName);
		}
	}
}
