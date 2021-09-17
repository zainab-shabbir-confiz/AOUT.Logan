using AOUT.Logan.Implementations;
using NUnit.Framework;
using System;

namespace AOUT.Logan.Tests
{
	[TestFixture]
	public class LogAnalyserTests
	{

		private LogAnalyser m_analyzer = null;
		private Calculator calc = null;

		[SetUp]
		public void Setup()
		{
			m_analyzer = new LogAnalyser();
			calc = new Calculator();
		}
		[Test]
		public void IsValidFileName_validFile_ReturnsTrue()
		{
			//arrange
			LogAnalyser analyzer = new LogAnalyser();

			//act
			bool result = m_analyzer.IsValidLogFileName("whatever.slf");
			//assert
			Assert.IsTrue(result, "filename should be valid!");
			// Assert.IsTrue(log.WasLastFileNameValid);

		}

		[Test]
		public void Sum_NoAddCalls_DefaultsToZero()
		{
			int lastSum = calc.Sum();
			Assert.AreEqual(0, lastSum);
		}

		[Test]
		public void Add_CalledOnce_SavesNumberForSum()
		{
			calc.Add(1);
			int lastSum = calc.Sum();
			Assert.AreEqual(1, lastSum);
		}

		[Test]
		[Ignore("there is a problem with this test")]

		//[ExpectedException(typeof(ArgumentException),ExpectedMessage = "No filename provided!")]
		public void IsValidFileName_EmptyFileName_ThrowsException()
		{
			m_analyzer.IsValidLogFileName(string.Empty);
		}

		[Test]
		public void IsValidFileName_NameShorterThan6CharsButSupportedExtension_ReturnsFalse()
		{
			StubExtensionManager myFakeManager = new StubExtensionManager();
			myFakeManager.ShouldExtensionBeValid = true;
			//create analyzer and inject stub
			LogAnalyzer log = new LogAnalyzer(myFakeManager);

			//Assert logic assuming extension is supported
			bool result = log.IsValidLogFileName("shortw.ext");
			Assert.IsFalse(result, "File name with less than 5 chars should have failed the method, even if the extension is supported");
        }

		[TearDown]
		public void TearDown()
		{
			m_analyzer = null;
		}
	}
}
