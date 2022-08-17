/*

    자동 생성 되는 코드입니다.
    절대 직접 수정하지마세요.

*/

using System;
using Google.Protobuf;
using System.Net;
using System.Threading.Tasks;

namespace ServerLib
{
    public static class AdamPacketHelper
    {
        public static ushort ConvertPacketNameToPacketId(string PacketName)
        {
            switch(PacketName)
            {
                
            case "Ping_RQ":
            {
                return Ping_RQ.Id;
            }

            case "Ping_RS":
            {
                return Ping_RS.Id;
            }

            case "GetServerPublicKey_RQ":
            {
                return GetServerPublicKey_RQ.Id;
            }

            case "GetServerPublicKey_RS":
            {
                return GetServerPublicKey_RS.Id;
            }

            case "CreateAccount_RQ":
            {
                return CreateAccount_RQ.Id;
            }

            case "CreateAccount_RS":
            {
                return CreateAccount_RS.Id;
            }

            case "MatchCompleted_NT":
            {
                return MatchCompleted_NT.Id;
            }

            case "MatchStart_RQ":
            {
                return MatchStart_RQ.Id;
            }

            case "MatchStart_RS":
            {
                return MatchStart_RS.Id;
            }

            case "MatchStop_RQ":
            {
                return MatchStop_RQ.Id;
            }

            case "MatchStop_RS":
            {
                return MatchStop_RS.Id;
            }

            case "Login_RQ":
            {
                return Login_RQ.Id;
            }

            case "Login_RS":
            {
                return Login_RS.Id;
            }

            case "WaitingRoomCharTransSync_RP":
            {
                return WaitingRoomCharTransSync_RP.Id;
            }

            case "WaitingRoomCharTransSync_NT":
            {
                return WaitingRoomCharTransSync_NT.Id;
            }

            case "WaitingRoomCharacterSpawn_RQ":
            {
                return WaitingRoomCharacterSpawn_RQ.Id;
            }

            case "WaitingRoomCharacterSpawn_RS":
            {
                return WaitingRoomCharacterSpawn_RS.Id;
            }

            case "WaitingRoomCharacterSpawn_NT":
            {
                return WaitingRoomCharacterSpawn_NT.Id;
            }

            case "GameRoomObjectInfos_RQ":
            {
                return GameRoomObjectInfos_RQ.Id;
            }

            case "GameRoomObjectInfos_RS":
            {
                return GameRoomObjectInfos_RS.Id;
            }

                default:
                    throw new Exception($"정의되지않은 패킷 이름입니다. PacketName: {PacketName}");
            }
        }

        public static IPacket ConvertJsonToPacket(ushort PacketId, string JsonString)
        {
            switch(PacketId)
            {
                
            case Ping_RQ.Id:
            {
                return Ping_RQ.Parser.ParseJson(JsonString);
            }

            case Ping_RS.Id:
            {
                return Ping_RS.Parser.ParseJson(JsonString);
            }

            case GetServerPublicKey_RQ.Id:
            {
                return GetServerPublicKey_RQ.Parser.ParseJson(JsonString);
            }

            case GetServerPublicKey_RS.Id:
            {
                return GetServerPublicKey_RS.Parser.ParseJson(JsonString);
            }

            case CreateAccount_RQ.Id:
            {
                return CreateAccount_RQ.Parser.ParseJson(JsonString);
            }

            case CreateAccount_RS.Id:
            {
                return CreateAccount_RS.Parser.ParseJson(JsonString);
            }

            case MatchCompleted_NT.Id:
            {
                return MatchCompleted_NT.Parser.ParseJson(JsonString);
            }

            case MatchStart_RQ.Id:
            {
                return MatchStart_RQ.Parser.ParseJson(JsonString);
            }

            case MatchStart_RS.Id:
            {
                return MatchStart_RS.Parser.ParseJson(JsonString);
            }

            case MatchStop_RQ.Id:
            {
                return MatchStop_RQ.Parser.ParseJson(JsonString);
            }

            case MatchStop_RS.Id:
            {
                return MatchStop_RS.Parser.ParseJson(JsonString);
            }

            case Login_RQ.Id:
            {
                return Login_RQ.Parser.ParseJson(JsonString);
            }

            case Login_RS.Id:
            {
                return Login_RS.Parser.ParseJson(JsonString);
            }

            case WaitingRoomCharTransSync_RP.Id:
            {
                return WaitingRoomCharTransSync_RP.Parser.ParseJson(JsonString);
            }

            case WaitingRoomCharTransSync_NT.Id:
            {
                return WaitingRoomCharTransSync_NT.Parser.ParseJson(JsonString);
            }

            case WaitingRoomCharacterSpawn_RQ.Id:
            {
                return WaitingRoomCharacterSpawn_RQ.Parser.ParseJson(JsonString);
            }

            case WaitingRoomCharacterSpawn_RS.Id:
            {
                return WaitingRoomCharacterSpawn_RS.Parser.ParseJson(JsonString);
            }

            case WaitingRoomCharacterSpawn_NT.Id:
            {
                return WaitingRoomCharacterSpawn_NT.Parser.ParseJson(JsonString);
            }

            case GameRoomObjectInfos_RQ.Id:
            {
                return GameRoomObjectInfos_RQ.Parser.ParseJson(JsonString);
            }

            case GameRoomObjectInfos_RS.Id:
            {
                return GameRoomObjectInfos_RS.Parser.ParseJson(JsonString);
            }

                default:
                    return null;
            }

        }
    
        public static string ConvertPacketToJson(ushort PacketId, IPacket Packet)
        {
            switch(PacketId)
            {
                
            case Ping_RQ.Id:
            {
                return ((Ping_RQ)Packet).ToJson();
            }

            case Ping_RS.Id:
            {
                return ((Ping_RS)Packet).ToJson();
            }

            case GetServerPublicKey_RQ.Id:
            {
                return ((GetServerPublicKey_RQ)Packet).ToJson();
            }

            case GetServerPublicKey_RS.Id:
            {
                return ((GetServerPublicKey_RS)Packet).ToJson();
            }

            case CreateAccount_RQ.Id:
            {
                return ((CreateAccount_RQ)Packet).ToJson();
            }

            case CreateAccount_RS.Id:
            {
                return ((CreateAccount_RS)Packet).ToJson();
            }

            case MatchCompleted_NT.Id:
            {
                return ((MatchCompleted_NT)Packet).ToJson();
            }

            case MatchStart_RQ.Id:
            {
                return ((MatchStart_RQ)Packet).ToJson();
            }

            case MatchStart_RS.Id:
            {
                return ((MatchStart_RS)Packet).ToJson();
            }

            case MatchStop_RQ.Id:
            {
                return ((MatchStop_RQ)Packet).ToJson();
            }

            case MatchStop_RS.Id:
            {
                return ((MatchStop_RS)Packet).ToJson();
            }

            case Login_RQ.Id:
            {
                return ((Login_RQ)Packet).ToJson();
            }

            case Login_RS.Id:
            {
                return ((Login_RS)Packet).ToJson();
            }

            case WaitingRoomCharTransSync_RP.Id:
            {
                return ((WaitingRoomCharTransSync_RP)Packet).ToJson();
            }

            case WaitingRoomCharTransSync_NT.Id:
            {
                return ((WaitingRoomCharTransSync_NT)Packet).ToJson();
            }

            case WaitingRoomCharacterSpawn_RQ.Id:
            {
                return ((WaitingRoomCharacterSpawn_RQ)Packet).ToJson();
            }

            case WaitingRoomCharacterSpawn_RS.Id:
            {
                return ((WaitingRoomCharacterSpawn_RS)Packet).ToJson();
            }

            case WaitingRoomCharacterSpawn_NT.Id:
            {
                return ((WaitingRoomCharacterSpawn_NT)Packet).ToJson();
            }

            case GameRoomObjectInfos_RQ.Id:
            {
                return ((GameRoomObjectInfos_RQ)Packet).ToJson();
            }

            case GameRoomObjectInfos_RS.Id:
            {
                return ((GameRoomObjectInfos_RS)Packet).ToJson();
            }

                default:
                    return "";
            }

        }
    
    }
}
