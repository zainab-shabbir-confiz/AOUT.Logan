using AOUT.Logan.Ch6;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOUT.Logan.Tests
{
	[TestFixture]
	class ConfigurationManagerTests : BaseTestClass
	{
		[Test]
		public void Analyze_EmptyFile_ThrowsException()
		{
			ConfigurationManager cm = new ConfigurationManager();
			bool configured = cm.IsConfigured("something");
			//rest of test
		}
	}
}
