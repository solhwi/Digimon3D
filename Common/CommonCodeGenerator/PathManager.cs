using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PathManager
{
    public static DirectoryInfo TryGetSolutionDirectoryInfo()
    {
        var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
        while (directory != null && !directory.GetFiles("*.sln").Any())
        {
            directory = directory.Parent;
        }
        return directory;
    }

    public static DirectoryInfo TryGetProjectDirectoryInfo()
    {
        var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
        while (directory != null && !directory.GetFiles("*.csproj").Any())
        {
            directory = directory.Parent;
        }
        return directory;
    }

    public static DirectoryInfo TryGetSDProjectRootDirectoryInfo()
    {
        var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
        while (directory != null && !directory.GetFiles("ignore.conf").Any())
        {
            directory = directory.Parent;
        }

        return directory;
    }

    internal static DirectoryInfo GetClientCommonDirectory()
    {
        DirectoryInfo Directory = TryGetSDProjectRootDirectoryInfo();

        Directory = Directory
                    .GetDirectories("UnityProject")[0]
                    .GetDirectories("Assets")[0]
                    .GetDirectories("Scripts")[0]
                    .GetDirectories("Common")[0];

        return Directory;
    }

    internal static DirectoryInfo GetServerCommonDirectory()
    {
        DirectoryInfo Directory = TryGetSDProjectRootDirectoryInfo();

        Directory = Directory
                    .GetDirectories("Server")[0]
                    .GetDirectories("AdamServer")[0]
                    .GetDirectories("GameServer")[0]
                    .GetDirectories("Common")[0];

        return Directory;
    }

    internal static DirectoryInfo GetCommonDirectory()
    {
        DirectoryInfo Directory = TryGetSDProjectRootDirectoryInfo();

        DirectoryInfo CommonDirectory = Directory.GetDirectories().FirstOrDefault((Dir) => { return Dir.Name == "Common"; });

        return CommonDirectory;
    }

    internal static DirectoryInfo GetCommonDataDirectory()
    {
        DirectoryInfo Directory = GetCommonDirectory();

        DirectoryInfo DataDirectory = Directory.GetDirectories().FirstOrDefault((Dir) => { return Dir.Name == "Data"; });

        return DataDirectory;
    }
}