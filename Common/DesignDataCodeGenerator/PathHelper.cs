using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignDataCodeGenerator
{
    internal static class PathHelper
    {
        internal static DirectoryInfo GetSDProjectDirectory()
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("ignore.conf").Any())
            {
                directory = directory.Parent;
            }

            return directory;
        }

        internal static DirectoryInfo GetServerProjectDirectory()
        {
            var directory = GetSDProjectDirectory();
            directory = directory.GetDirectories("Server")[0];
            directory = directory.GetDirectories("AdamServer")[0];

            return directory;
        }

        internal static DirectoryInfo GetUnityProjectDirectory()
        {
            var directory = GetSDProjectDirectory();
            directory = directory.GetDirectories("UnityProject")[0];

            return directory;
        }

        internal static DirectoryInfo TryGetSolutionDirectoryInfo()
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory;
        }

        internal static DirectoryInfo TryGetCommonDirectoryInfo()
        {
            var directory = GetSDProjectDirectory();
            directory = directory.GetDirectories("Common")[0];

            return directory;
        }
    }
}
