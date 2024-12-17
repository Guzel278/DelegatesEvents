using System;
namespace Delegates_Events
{
	public class FileSearcher
	{
	   public event EventHandler<FileArgs> FileFound;
           public event EventHandler SearchCancelled;
           public void SearchFiles( string directory)
	   {
            foreach (var file in Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories))
            {
                var args = new FileArgs(file);
                FileFound?.Invoke(this, args);

                if (args.Cancel)
                {
                    SearchCancelled?.Invoke(this, EventArgs.Empty);
                    break;
                }
            }
          }
	}
}

