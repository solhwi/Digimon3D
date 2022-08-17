using ProtobufSourceGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SDClientPacketHandlerGenerator
{

    internal class SDClientPacketHandlerGenerator
    {
        enum ENUM_PACKETTYPE
        {
            RESPONSE, REQUEST, NOTIFY, REPORT
        }

        private static Dictionary<XmlNode, ENUM_PACKETTYPE> PacketTypes = new Dictionary<XmlNode, ENUM_PACKETTYPE>();

        internal static void Generate(XmlDocument Doc)
        {
            GenerateSDClientPacketHandler(Doc);
        }

        private static void GenerateSDClientPacketHandler(XmlDocument Doc)
        {
            StringBuilder SbOnRecvVirtualFuncs = new StringBuilder();
            StringBuilder SbInitRegisterStatements = new StringBuilder();

            XmlNode PacketsNode = Doc.ChildNodes[0];

            foreach (XmlNode ClassNode in PacketsNode.SelectNodes("Class"))
            {
                foreach (XmlNode PacketNode in ClassNode.ChildNodes)
                {
                    string PacketType = PacketNode.Name;

                    ENUM_PACKETTYPE Type;
                    switch (PacketType)
                    {
                        case "Response":
                        {
                            Type = ENUM_PACKETTYPE.RESPONSE;
                            break;
                        }
                        case "Request":
                        {
                            Type = ENUM_PACKETTYPE.REQUEST;
                            break;
                        }
                        case "Notify":
                        {
                            Type = ENUM_PACKETTYPE.NOTIFY;
                            break;
                        }
                        case "Report":
                        {
                            Type = ENUM_PACKETTYPE.REPORT;
                            break;
                        }
                        default:
                        {
                            Console.WriteLine($"정의되지않은 패킷타입입니다. PacketType: {PacketType}");
                            Environment.Exit(999);
                            return;
                        }
                    }

                    PacketTypes.Add(PacketNode, Type);
                }
            }

            foreach (XmlNode ClassNode in PacketsNode.SelectNodes("Class"))
            {
                string ClassName = ClassNode.Attributes["name"].Value;

                foreach (XmlNode PacketNode in ClassNode.ChildNodes)
                {
                    string PacketType = PacketNode.Name;
                    string PacketClassName = PacketHelper.MakePacketClassName(ClassName, PacketType);

                    if (PacketType == "Response")
                    {
                        string OnRecvFunc = String.Format(OnRecvResponseFuncFormat, PacketClassName);
                        SbOnRecvVirtualFuncs.Append(OnRecvFunc);
                        string InitRegisterStatement = String.Format(InitRegisterStatements, PacketClassName, PacketType);
                        SbInitRegisterStatements.Append(InitRegisterStatement);
                    }
                    else if (PacketType == "Notify")
                    {
                        string OnRecvFunc = String.Format(OnRecvNotifyFuncFormat, PacketClassName);
                        SbOnRecvVirtualFuncs.Append(OnRecvFunc);
                        string InitRegisterStatement = String.Format(InitRegisterStatements, PacketClassName, PacketType);
                        SbInitRegisterStatements.Append(InitRegisterStatement);
                    }
                    else if (PacketType != "Request" && PacketType != "Report")
                    {
                        Console.WriteLine($"들어오면 안되는 PacketType: {PacketType}");
                        Environment.Exit(999);
                        return;
                    }
                }
            }
            string AdamNetworkHandlerContent = String.Format(
                SDClientPacketHandlerFormat, 
                SbOnRecvVirtualFuncs.ToString(),
                SbInitRegisterStatements.ToString());

            DirectoryInfo SolutionDir = PathManager.TryGetSDProjectRootDirectoryInfo();
            string FilePath = Path.Combine(SolutionDir.FullName, "UnityProject", "Assets", "Scripts", "Network", "ClientLib", "SDClientPacketHandlerGenerated.cs");
            File.WriteAllText(FilePath, AdamNetworkHandlerContent);
        }


        // 0: OnRecv
        // 1: OnRecvEvent Registering
        private static string SDClientPacketHandlerFormat =
@"/*

    자동 생성 되는 코드입니다.
    절대 직접 수정하지마세요.

*/

using System;
using Google.Protobuf;
using ServerLib;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace ServerLib
{{
    public class SDClientPacketHandlerGenerated : AdamClientPacketHandlerGenerated
    {{
        public ConcurrentQueue<KeyValuePair<PacketHeader, IPacket>> PacketQueue {{ get; }} = new ConcurrentQueue<KeyValuePair<PacketHeader, IPacket>>();

        public SDClientPacketHandlerGenerated(AdamSession InSession) : base(InSession)
        {{
            {1}
        }}
    
        {0}
    }}
}}
";

        // 0: Protobuf 자동생성클래스 타입
        // 1: PacketType
        private static string InitRegisterStatements =
@"
            Register(new NetworkEventListener<{0}>(), (PacketHeader Header, {0} {1}) => {{  PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, {1})); }});
";

        // 0: Protobuf 자동생성클래스 타입
        private static string OnRecvResponseFuncFormat =
@"
        protected override void OnRecv{0}(PacketHeader Header, {0} Response)
        {{
            PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Response));
        }}
";

        // 0: Protobuf 자동생성클래스 타입
        private static string OnRecvNotifyFuncFormat =
@"
        protected override void OnRecv{0}(PacketHeader Header, {0} Notify)
        {{
            PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Notify));
        }}
";


    }
}
