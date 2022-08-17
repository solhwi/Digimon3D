using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignDataCodeGenerator
{
    internal static class CodeGenerator
    {
        private static string UnityProjectDataDirectory = "\\Assets\\Scripts\\Datas\\";
        private static string ServerProjectDataDirectory = "\\GameServer\\Data\\";

        private static string ServerDestination;
        private static  string UnityDestination;

        private static DirectoryInfo ExcelDatasDirectory;
        private static DirectoryInfo JsonDatasDirectory;


        internal static void Generate()
        {
            DirectoryInfo ServerProjectDir = PathHelper.GetServerProjectDirectory();
            ServerDestination = ServerProjectDir.FullName + ServerProjectDataDirectory;
            DirectoryInfo UnityProjectDir = PathHelper.GetUnityProjectDirectory();
            UnityDestination = UnityProjectDir.FullName + UnityProjectDataDirectory;

            DirectoryInfo CommonDirectory = PathHelper.TryGetCommonDirectoryInfo();
            ExcelDatasDirectory = CommonDirectory.GetDirectories("ExcelDatas")[0];
            JsonDatasDirectory = CommonDirectory.GetDirectories("JsonDatas")[0];

            GenerateBaseClasses();
        }

        private static void GenerateBaseClasses()
        {
            string Content = String.Format(
                BaseDesignDataClasses, 
                String.Format(BaseDataClass),
                String.Format(BaseExcelDataClass),
                String.Format(BaseJsonDataClass));

            WriteToUnityProject("BaseDesignDataClasses.cs", Content);
            WriteToServerProject("BaseDesignDataClasses.cs", Content);
        }

        private static void WriteToUnityProject(string FileName, string FileContent)
        {
            string FilePath = Path.Combine(UnityDestination, FileName);
            File.WriteAllText(FilePath, FileContent);
        }

        private static void WriteToServerProject(string FileName, string FileContent)
        {
            string FilePath = Path.Combine(ServerDestination, FileName);
            File.WriteAllText(FilePath, FileContent);
        }

        // 0: BaseData
        // 1: BaseExcelData
        // 2: BaseJsonData
        private static string BaseDesignDataClasses =
@"
/*

    자동 생성 되는 코드입니다.
    절대 직접 수정하지마세요.

*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignData
{{
    {0}

    {1}

    {2}
}}

";

        private static string BaseDataClass =
@"
    public abstract class BaseData<DataType> where DataType : BaseData<DataType>
    {{
        public abstract void Load(List<DataType> Datas);
    }}
";


        private static string UnityBaseDataClass =
@"
    public abstract class BaseData<DataType> : ScriptableObject where DataType : BaseData<DataType>
    {{
        public abstract void Load(List<DataType> Datas);
    }}
";


        private static string BaseExcelDataClass =
@"
    public abstract class BaseExcelData<DataType> : BaseData<DataType> where DataType : BaseExcelData<DataType>
    {{
        public int DDId {{ get; set; }}
        
        protected Dictionary<int /*DDId*/, DataType> Container = new Dictionary<int /*DDId*/, DataType>();

        public override void Load(List<DataType> Datas)
        {{
            Container.Clear();
            foreach(var Data in Datas)
            {{
                Container.Add(Data.DDId, Data);
            }}
        }}

        public DataType Get(int DDId)
        {{
            return Container[DDId];
        }}

        public bool Has(int DDId)
        {{
            return Container.ContainsKey(DDId);
        }}

        public bool Has(Predicate<DataType> Condition)
        {{
            return Container.Any((Pair) => Condition.Invoke(Pair.Value));
        }}

        public Dictionary<int, DataType> Get(Predicate<DataType> Condition)
        {{
            return Container
                    .Where((Pair) => Condition.Invoke(Pair.Value))
                    .Select((Pair) => Pair.Value)
                    .ToDictionary((Value) => Value.DDId);        
        }}
    }}
";

        private static string BaseJsonDataClass =
@"
    public abstract class BaseJsonData<DataType> : BaseData<DataType> where DataType : BaseJsonData<DataType>
    {{
    }}
";
    }
}
