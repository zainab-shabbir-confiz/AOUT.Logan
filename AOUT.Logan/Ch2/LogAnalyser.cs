using System;

namespace AOUT.Logan
{
	public class LogAnalyser
	{
		private bool wasLastFileNameValid;
		public bool WasLastFileNameValid
		{
			get { return wasLastFileNameValid; }
			set { wasLastFileNameValid = value; }
		}
		public bool IsValidLogFileName(string fileName)
		{
			if (!fileName.ToLower().EndsWith(".slf"))
			{
				wasLastFileNameValid = false;
				return false;
			}
			wasLastFileNameValid = true;
			return true;
		}

		public bool IsValidLogFileNamewithException(string fileName)
		{
			if (String.IsNullOrEmpty(fileName))
			{
				throw new ArgumentException("No filename provided!");
			}
			if (!fileName.EndsWith(".SLF"))
			{
		    return false;
			}
			return true;
		}
	}
}
