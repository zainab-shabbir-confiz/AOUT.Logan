using AOUT.Logan.Ch6;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOUT.Logan.Tests
{
	class BaseTestClass
	{
		[SetUp]
		public void Setup()
		{
			Console.WriteLine("in setup");
			LoggingFacility.Logger = new StubLogger();
		}
	}
}
