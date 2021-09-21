using AOUT.Logan.Ch4;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOUT.Logan.Tests
{
	[TestFixture]
	class BaseClassLogAnalyserTests: BaseTestClass

	{
		[Test]
		public void Analyze_EmptyFile_ThrowsException()
		{
			LogAnalyser2 la = new LogAnalyser2();
			la.Analyze("myemptyfile.txt");
			//rest of test
		}
	}
}
