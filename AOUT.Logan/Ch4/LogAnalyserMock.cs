using AOUT.Logan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOUT.Logan.Ch4
{
	public class LogAnalyserMock
	{
		private IWebService service;
		public LogAnalyserMock(IWebService service)
		{
			this.service = service;
		}
		public void Analyze(string fileName)
		{
			if (fileName.Length < 8)
			{
				service.LogError("Filename too short:"
				+ fileName);
			}

		}
	}
}
