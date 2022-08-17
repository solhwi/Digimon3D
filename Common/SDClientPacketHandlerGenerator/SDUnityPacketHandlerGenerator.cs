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

    internal class SDUnityPacketHandlerGenerator
    {
        private static Dictionary<XmlNode, PacketType> PacketTypes = new Dictionary<XmlNode, PacketType>();

        internal static void Generate(XmlDocument Doc)
        {
            GenerateAdamPacketHandler(Doc);
        }

        private static void GenerateAdamPacketHandler(XmlDocument Doc)
        {
            StringBuilder SbActionMembers = new StringBuilder();
            StringBuilder SbOnRecvVirtualFuncs = new StringBuilder();
            StringBuilder SbOnRecvEnqueueVirtualFuncs = new StringBuilder();
            StringBuilder SbOnRecvSwitchCases = new StringBuilder();
            StringBuilder SbRegisterFuncs = new StringBuilder();
            StringBuilder SbUnregisterFuncs = new StringBuilder();
            StringBuilder SbRegistrationDictionaries = new StringBuilder();

            XmlNode PacketsNode = Doc.ChildNodes[0];

            List<PacketClassNode> PacketClassNodes = PacketXmlReader.GetPacketRawData();

            foreach (PacketClassNode ClassNode in PacketClassNodes)
            {
                foreach (var Pair in ClassNode.Packets)
                {
                    PacketType Type = Pair.Key;
                    PacketTypes.Add(Pair.Value.Node, Type);
                }
            }

            foreach (PacketClassNode ClassNode in PacketClassNodes)
            {
                string ClassName = ClassNode.Name;

                foreach (var Pair in ClassNode.Packets)
                {
                    PacketType Type = Pair.Key;
                    string PacketClassName = PacketHelper.MakePacketClassName(ClassName, Type);

                    if(Type == PacketType.Notify || Type == PacketType.Response)
                    {
                        string OnRecvActionEvent = String.Format(OnRecvActionFormat, PacketClassName);
                        SbActionMembers.Append(OnRecvActionEvent);
                        if (Type == PacketType.Response)
                        {
                            string OnRecvErrorActionEvent = String.Format(OnRecvErrorActionFormat, PacketClassName);
                            SbActionMembers.Append(OnRecvErrorActionEvent);
                        }
                        string OnRecvSwitchCase = String.Format(GetTypeSwitchCaseFormat, PacketClassName, Type);
                        SbOnRecvSwitchCases.Append(OnRecvSwitchCase);
                        string OnRecvFunc = String.Format(Type == PacketType.Notify ? OnRecvNotifyFuncFormat : OnRecvResponseFuncFormat, PacketClassName);
                        SbOnRecvVirtualFuncs.Append(OnRecvFunc);

                        if (Type == PacketType.Response)
                        {
                            SbRegisterFuncs.Append(String.Format(RegisterFuncFormatWithError, PacketClassName));
                            SbUnregisterFuncs.Append(String.Format(UnregisterFuncFormatV2WithError, PacketClassName));
                        }
                        else if(Type == PacketType.Notify)
                        {
                            SbRegisterFuncs.Append(String.Format(RegisterFuncFormat, PacketClassName));
                            SbUnregisterFuncs.Append(String.Format(UnregisterFuncFormatV2, PacketClassName));
                        }

                        SbRegistrationDictionaries.Append(String.Format(RegistrationDictionaryFormat, PacketClassName, Type));
                        if (Type == PacketType.Response)
                            SbRegistrationDictionaries.Append(String.Format(ErrorRegistrationDictionaryFormat, PacketClassName, Type));
                    }
                    else if (Type != PacketType.Report && Type != PacketType.Request)
                    {
                        Console.WriteLine($"들어오면 안되는 PacketType: {Type}");
                        Environment.Exit(999);
                        return;
                    }
                }
            }
            string AdamNetworkHandlerContent = String.Format(
                AdamPacketHandlerFormat, 
                SbActionMembers.ToString(),
                SbOnRecvEnqueueVirtualFuncs.ToString(),
                SbOnRecvVirtualFuncs.ToString(),
                String.Format(OnRecvFuncFormat, SbOnRecvSwitchCases.ToString()),
                SbRegisterFuncs.ToString(),
                SbUnregisterFuncs.ToString(),
                SbRegistrationDictionaries.ToString());

            DirectoryInfo SolutionDir = PathManager.TryGetSDProjectRootDirectoryInfo();
            string FilePath = Path.Combine(SolutionDir.FullName, "UnityProject", "Assets", "Scripts", "Network", "ClientLib", "SDUnityPacketHandlerGenerated.cs");
            File.WriteAllText(FilePath, AdamNetworkHandlerContent);
        }


        // 0: Action들
        // 1: OnRecvEnqueue
        // 2: OnRecv
        // 3: OnRecv SwitchCase
        // 4: Register Funcs
        // 5: Unregister Funcs
        // 6: Registration Dictionaries
        private static string AdamPacketHandlerFormat =
@"/*

    자동 생성 되는 코드입니다.
    절대 직접 수정하지마세요.

*/

using System;
using UnityEngine;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ServerLib;
using System.Net;
using System.Threading.Tasks;

namespace ServerLib
{{
    public class SDUnityPacketHandlerGenerated : Singleton<SDUnityPacketHandlerGenerated>
    {{
        SDClientPacketHandlerGenerated ClientPacketHandler = null;

        public virtual void Init(AdamSession session)
        {{
            ClientPacketHandler = new SDClientPacketHandlerGenerated(session);
        }}

        public virtual void Run()
        {{
            if(ClientPacketHandler.PacketQueue.Count == 0)
                return;

            while(ClientPacketHandler.PacketQueue.IsEmpty == false)
            {{
                if(ClientPacketHandler.PacketQueue.TryDequeue(out KeyValuePair<PacketHeader, IPacket> Pair))
                {{
                    OnRecv(Pair.Key, Pair.Value);
                }}
                else
                {{
                    return;
                }}
            }}
        }}

        {6}

        {0}

        {1}

        {2}

        {3}

        {4}

        {5}
    }}
}}
";

        // 0: Protobuf 자동생성클래스 타입
        private static string OnRecvResponseFuncFormat =
@"
        protected virtual void OnRecv{0}({0} Packet)
        {{
        }}

        protected virtual void OnRecvError{0}({0} Packet)
        {{
        }}
";


        // 0: Protobuf 자동생성클래스 타입
        private static string OnRecvNotifyFuncFormat =
@"
        protected virtual void OnRecv{0}({0} Packet)
        {{
        }}
";

        // 0: case문들
        private static string OnRecvFuncFormat =
@"
        protected virtual void OnRecv(PacketHeader Header, IPacket Packet)
        {{
            switch(Header.PacketId)
            {{
                {0}

                default:
                {{
                    AdamLogger.Log(LogLevel.Error, $""정의되지 않은 패킷이 들어왔습니다. {{Packet.GetType()}}"");
                    break;
                }}
            }}
        }}
";


        // 0: Packet 클래스 이름
        private static string RegisterFuncFormat =
@"
        public bool Register(NetworkEventListener<{0}> EL, Action<{0}> OnRecv)
        {{
            if (EL == null)
                return false;

            // 중복 등록..
            if({0}_Registration.ContainsKey(EL) == true)
            {{
                return false;
            }}
            else
            {{
                {0}_Registration.Add(EL, OnRecv);
                OnRecvEvent{0} += OnRecv;
                return true;
            }}
        }}
";

        // 0: Packet 클래스 이름
        private static string RegisterFuncFormatWithError =
@"
        public bool Register(NetworkEventListener<{0}> EL, Action<{0}> OnRecv, bool bErrorRegistration = false)
        {{
            if (EL == null)
                return false;

            if(bErrorRegistration == false)
            {{
                // 중복 등록..
                if({0}_Registration.ContainsKey(EL) == true)
                {{
                    return false;
                }}
                else
                {{
                    {0}_Registration.Add(EL, OnRecv);
                    OnRecvEvent{0} += OnRecv;
                    return true;
                }}
            }}
            else
            {{
                // 중복 등록..
                if({0}_ErrorRegistration.ContainsKey(EL) == true)
                {{
                    return false;
                }}
                else
                {{
                    {0}_ErrorRegistration.Add(EL, OnRecv);
                    OnRecvErrorEvent{0} += OnRecv;
                    return true;
                }}
            }}

        }}
";

        // 0: Packet 클래스 이름
        private static string UnregisterFuncFormatV2 =
@"
        public bool Unregister(NetworkEventListener<{0}> EL)
        {{
            if (EL == null)
                return false;
            
            if({0}_Registration.ContainsKey(EL) == true)
            {{
                Action<{0}> OnRecv = {0}_Registration[EL];
                OnRecvEvent{0} -= OnRecv;
                {0}_Registration.Remove(EL);
                return true;
            }}
            // 등록된게 없는데..
            else
            {{
                return false;
            }}
        }}
";

        // 0: Packet 클래스 이름
        private static string UnregisterFuncFormatV2WithError =
@"
        public bool Unregister(NetworkEventListener<{0}> EL, bool bErrorRegistration = false)
        {{
            if (EL == null)
                return false;
            
            if(bErrorRegistration == false)
            {{
                if({0}_Registration.ContainsKey(EL) == true)
                {{
                    Action<{0}> OnRecv = {0}_Registration[EL];
                    OnRecvEvent{0} -= OnRecv;
                    {0}_Registration.Remove(EL);
                    return true;
                }}
                // 등록된게 없는데..
                else
                {{
                    return false;
                }}
            }}
            else
            {{
                if({0}_ErrorRegistration.ContainsKey(EL) == true)
                {{
                    Action<{0}> OnRecv = {0}_ErrorRegistration[EL];
                    OnRecvErrorEvent{0} -= OnRecv;
                    {0}_ErrorRegistration.Remove(EL);
                    return true;
                }}
                // 등록된게 없는데..
                else
                {{
                    return false;
                }}
            }}

        }}
";


        // 0: Protobuf 자동생성클래스 타입
        // 1: 패킷 타입
        private static string GetTypeSwitchCaseFormat =
@"
                case {0}.Id:
                {{
                    {0} {1} = ({0})Packet;
                    OnRecv{0}({1});
                    OnRecvEvent{0}?.Invoke({1});
                    break;
                }}
";

        /// <summary>
        /// Client가 Response를 받을때 Error에 따라 분기
        /// </summary>
        // 0: Protobuf 자동생성클래스 타입
        // 1: 패킷 타입
        // 2: ClassName
        private static string GetTypeSwitchCaseErrorFormat =
@"
                case {0}.Id:
                {{
                    {0} {1} = ({0})Packet;
                    if({1}.Error == {0}.Types.{2}_Error.None)
                    {{
                        OnRecv{0}({1});
                        OnRecvEvent{0}?.Invoke({1});
                    }}
                    else
                    {{
                        OnRecvError{0}({1});
                        OnRecvErrorEvent{0}?.Invoke({1});
                    }}
                    break;
                }}
";

        // 0: Packet 클래스 이름
        private static string RegistrationDictionaryFormat =
@"
        private Dictionary<NetworkEventListener<{0}>, Action<{0}>> {0}_Registration 
            = new Dictionary<NetworkEventListener<{0}>, Action<{0}>>();
";

        // 0: Packet 클래스 이름
        private static string ErrorRegistrationDictionaryFormat =
@"
        private Dictionary<NetworkEventListener<{0}>, Action<{0}>> {0}_ErrorRegistration 
            = new Dictionary<NetworkEventListener<{0}>, Action<{0}>>();
";

        // 0: Protobuf 자동생성클래스 타입
        private static string OnRecvActionFormat =
@"
        private Action<{0}> OnRecvEvent{0};
";

        // 0: Protobuf 자동생성클래스 타입
        private static string OnRecvErrorActionFormat =
@"
        private Action<{0}> OnRecvErrorEvent{0};
";


    }
}
