using AOUT.Logan.Implementations;
using AOUT.Logan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOUT.Logan.Ch3
{
	public class ExtensionManagerFactory
	{
		private IExtensionManager customManager=null;
		public IExtensionManager Create()
		{
			if(customManager != null)
              return customManager;
			return new FileExtensionManager();
		}
		public void SetManager(IExtensionManager mgr)
		{
			customManager = mgr;
		}
	}
}
