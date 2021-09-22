using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOUT.Logan.Ch7
{
	public class LogAnalyzerPractice
	{
		public bool IsValid(string fileName)
		{
			if (fileName.Length < 8)
			{
				return true;
			}
			return false;
		}
	}
}
