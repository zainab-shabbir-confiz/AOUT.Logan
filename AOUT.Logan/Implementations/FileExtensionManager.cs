using AOUT.Logan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOUT.Logan.Implementations
{
	class FileExtensionManager : IExtensionManager
	{
		public bool IsValid(string fileName)
		{
			return true;
		}
	}
}
