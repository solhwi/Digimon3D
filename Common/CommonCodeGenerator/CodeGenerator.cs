using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CommonCodeGenerator
{
    public static class CodeGenerator
    {
        public static void Generate()
        {
            CopyAllCSFiles();
            GenerateCommonEnum();
        }

        public static void CopyAllCSFiles()
        {
            DirectoryInfo SolutionDirInfo = PathManager.TryGetProjectDirectoryInfo();
            DirectoryInfo CommonDirInfo = SolutionDirInfo.GetDirectories("Common")[0];
            FileInfo[] CommonCSFiles = CommonDirInfo.GetFiles("*.cs");

            foreach(FileInfo CommonCSFile in CommonCSFiles)
            {
                string FileContent = File.ReadAllText(CommonCSFile.FullName, Encoding.UTF8);
                GenerateCSFileToClient(CommonCSFile.Name, FileContent);
                GenerateCSFileToServer(CommonCSFile.Name, FileContent);
            }
        }

        public static void GenerateCommonEnum()
        {
            DirectoryInfo SolutionDirInfo = PathManager.TryGetProjectDirectoryInfo();
            DirectoryInfo CommonDirInfo = SolutionDirInfo.GetDirectories("Common")[0];
            FileInfo[] CommonFiles = CommonDirInfo.GetFiles("Common*.xml");

            FileInfo CommonEnumFile = CommonFiles.FirstOrDefault(File => File.Name == "CommonEnum.xml");

            if (CommonEnumFile == null)
                return;

            XmlDocument CommonEnumDoc = new XmlDocument();
            CommonEnumDoc.Load(CommonEnumFile.FullName);

            XmlNode EnumsNode = CommonEnumDoc.ChildNodes[0];
            StringBuilder SbEnums= new StringBuilder();
            foreach (XmlNode EnumNode in EnumsNode.ChildNodes)
            {
                string EnumClassName = EnumNode.Name;

                StringBuilder SbEnumMembers = new StringBuilder();
                foreach(XmlNode EnumMemberNode in EnumNode.ChildNodes)
                {
                    string EnumMemberName = EnumMemberNode.Name;

                    XmlNode AttrNode = EnumMemberNode.Attributes.GetNamedItem("value");
                    if(AttrNode != null)
                    {
                        if(int.TryParse(AttrNode.Value, out int EnumValue))
                            SbEnumMembers.AppendFormat(CommonEnumMemberWithValueFormat, EnumMemberName, EnumValue);
                        else
                            SbEnumMembers.AppendFormat(CommonEnumMemberFormat, EnumMemberName);
                    }
                    else
                    {
                        SbEnumMembers.AppendFormat(CommonEnumMemberFormat, EnumMemberName);
                    }
                }

                SbEnums.AppendFormat(CommonEnumFormat, EnumClassName, SbEnumMembers.ToString());
            }

            string FileContent = String.Format(CommonEnumFileFormat, SbEnums.ToString());
            GenerateCSFileToClient("CommonEnum.cs", FileContent);
            GenerateCSFileToServer("CommonEnum.cs", FileContent);
            GenerateCSFileToCommonGen("CommonEnum.cs", FileContent);
        }

        public static void GenerateCSFileToClient(string FileName, string FileContent)
        {
            string FilePath = PathManager.GetClientCommonDirectory().FullName;
            File.WriteAllText(Path.Combine(FilePath, FileName), FileContent);
        }

        public static void GenerateCSFileToServer(string FileName, string FileContent)
        {
            string FilePath = PathManager.GetServerCommonDirectory().FullName;
            File.WriteAllText(Path.Combine(FilePath, FileName), FileContent);
        }

        public static void GenerateCSFileToCommonGen(string FileName, string FileContent)
        {
            DirectoryInfo ProjDirInfo = PathManager.TryGetProjectDirectoryInfo();
            DirectoryInfo CommonGenDirInfo = ProjDirInfo.GetDirectories("CommonGen")[0];

            string FilePath = CommonGenDirInfo.FullName;
            File.WriteAllText(Path.Combine(FilePath, FileName), FileContent);
        }

        // 0: enum 들
        private static string CommonEnumFileFormat = 
@"
    namespace Common
    {{
        {0}
    }}
";

        // enum 이름
        // enum 멤버이름
        private static string CommonEnumFormat =
@"
        public enum {0}
        {{
            {1}
        }}
";

        // 0: 이름
        private static string CommonEnumMemberFormat =
@"
            {0},
";

        // 0: 이름
        // 1: 값
        private static string CommonEnumMemberWithValueFormat =
@"
            {0} = {1},
";
    }
}
