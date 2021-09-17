using AOUT.Logan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOUT.Logan.Implementations
{
	public class StubExtensionManager: IExtensionManager
	{
		public bool ShouldExtensionBeValid;

		public bool IsValid(string fileName)
		{
			return ShouldExtensionBeValid;
		}
	}
}
