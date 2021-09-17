using AOUT.Logan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOUT.Logan.Ch4
{
	public class MockEmailService : IEmailService
	{
		public string To;
		public string Subject;
		public string Body;
		public void SendEmail(string to,
		string subject,
		string body)
		{
			To = to;
			Subject = subject;
			Body = body;
		}
	}
}
