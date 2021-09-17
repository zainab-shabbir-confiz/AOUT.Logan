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
		public LogAnalyzer()
		{
			manager = new FileExtensionManager();
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
