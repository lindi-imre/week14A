using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace FileSystemWatch
{
    class Program
    {
        static List<FileSystemWatcher> watchers;

        static void Main(string[] args)
        {
            watchers = new List<FileSystemWatcher>();

            foreach (FileInfo fil in FoundFiles)
            {
                FileSystemWatcher newWatcher = new FileSystemWatcher(fil.DirectoryName, fil.Name);
                newWatcher.Changed += new FileSystemEventHandler(WatcherChanged);

                newWatcher.EnableRaisingEvents = true;
                watchers.Add(newWatcher);
            }
        }

        static void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
                Console.WriteLine("{0} has been changed!", e.FullPath);
        }
    }
}
