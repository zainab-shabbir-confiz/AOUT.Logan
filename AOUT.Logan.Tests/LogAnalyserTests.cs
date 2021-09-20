using AOUT.Logan.Ch3;
using AOUT.Logan.Ch4;
using AOUT.Logan.Implementations;
using AOUT.Logan.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;
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

		[Test]
		public void IsValidFileName_NameShorterThan6CharsButSupportedExtensionFactory_ReturnsFalse()
		{
			StubExtensionManager myFakeManager = new StubExtensionManager();
			ExtensionManagerFactory factoryExtensionManager = new ExtensionManagerFactory();

			factoryExtensionManager.SetManager(myFakeManager);
			//create analyzer and inject stub
			LogAnalyzer log = new LogAnalyzer();
			bool result = log.IsValidLogFileName("shortw.ext");
			Assert.IsFalse(result, "File name with less than 5 chars should have failed the method, even if the extension is supported");
			//Assert logic assuming extension is supported
		}

		[Test]
		public void Analyze_TooShortFileName_CallsWebService()
		{
			MockService mockService = new MockService();
			LogAnalyserMock log = new LogAnalyserMock(mockService);
			string tooShortFileName = "abc.ext";
			log.Analyze(tooShortFileName);
			Assert.AreEqual("Filename too short:abc.ext",
			mockService.LastError);
		}

		[Test]
		public void Analyze_WebServiceThrows_SendsEmail()
		{
			StubService stubService = new StubService();
            stubService.ToThrow = new Exception("fake exception");
			MockEmailService mockEmail = new MockEmailService();
			LogAnalyser2 log = new LogAnalyser2();
			//we use setters instead of
			//constructor parameters for easier coding
			log.Service = stubService;
            log.Email = mockEmail;
			string tooShortFileName = "abc.ext";
			log.Analyze(tooShortFileName);
			Assert.AreEqual("a", mockEmail.To);
			Assert.AreEqual("fake exception", mockEmail.Body);
			Assert.AreEqual("subject", mockEmail.Subject);
		}

		[Test]
		public void Analyze_TooShortFileName_ErrorLoggedToService()
		{
			MockRepository mocks = new MockRepository();
			IWebService simulatedService = mocks.DynamicMock<IWebService>();
			using (mocks.Record())
			{
		   //we expected "Filename too short:abc.ext"
				simulatedService.LogError("bad string");
			}
			LogAnalyserMock log = new LogAnalyserMock(simulatedService);
			string tooShortFileName = "abc.ext";
			log.Analyze(tooShortFileName);
			mocks.VerifyAll();
		}

		[Test]
		public void Analyze_TooShortFileName_ErrorLoggedToService1()
		{
			MockRepository mocks = new MockRepository();
			IWebService simulatedService =
			mocks.StrictMock<IWebService>();
			using (mocks.Record())
			{
				simulatedService
				.LogError("Filename too short:abc.ext");
			}
			LogAnalyserMock log =
			new LogAnalyserMock(simulatedService);
			string tooShortFileName = "abc.ext";
			log.Analyze(tooShortFileName);
			mocks.Verify(simulatedService);
		}

		[Test]
		public void ReturnResultsFromMock()
		{
			MockRepository mocks = new MockRepository();
			IGetResults resultGetter = mocks.DynamicMock<IGetResults>();
            using (mocks.Record())
			{
				resultGetter.GetSomeNumber("a");
				LastCall.Return(1);
				resultGetter.GetSomeNumber("a");
				LastCall.Return(2);
				resultGetter.GetSomeNumber("b");
				LastCall.Return(3);
			}
			int result = resultGetter.GetSomeNumber("b");
			Assert.AreEqual(3, result);
			int result2 = resultGetter.GetSomeNumber("a");
			Assert.AreEqual(1, result2);
			int result3 = resultGetter.GetSomeNumber("a");
			Assert.AreEqual(2, result3);
		}

		[TearDown]
		public void TearDown()
		{
			m_analyzer = null;
		}
	}
}
