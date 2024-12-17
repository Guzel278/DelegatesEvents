using System;
namespace Delegates_Events
{
	public class FileArgs :EventArgs
	{
		public string FileName { get; set; }
		public bool Cancel { get; set; } = false;
        public FileArgs(string fileName)
        {
            FileName = fileName;
        }
    }
}

