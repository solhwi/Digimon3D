/*

    자동 생성 되는 코드입니다.
    절대 직접 수정하지마세요.

*/

using System;
using Google.Protobuf;

namespace ServerLib
{
    public static class AdamBitConverterGenerated
    {
        public enum EDeserializeResult
        {
            Success,
            PacketFragmentation,
            PacketCorrupted,
        }

        public static byte[] Serialize(PacketHeader Header)
        {
			byte[] buff = new byte[PacketHeader.Size];

			byte[] packetSizeBuff = BitConverter.GetBytes(Header.PacketSize);
			Array.Copy(packetSizeBuff, 0, buff, 0, sizeof(ushort));
			byte[] packetIdBuff = BitConverter.GetBytes(Header.PacketId);
			Array.Copy(packetIdBuff, 0, buff, sizeof(ushort), sizeof(ushort));

			return buff;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, out PacketHeader Header)
        {
            if(Buff.Count < PacketHeader.Size)
			{
				Header = new PacketHeader();
				return EDeserializeResult.PacketFragmentation;
			}

			Header = new PacketHeader();
			Header.PacketSize = BitConverter.ToUInt16(Buff.Array, Buff.Offset);
			Header.PacketId = BitConverter.ToUInt16(Buff.Array, Buff.Offset + sizeof(ushort));

			return EDeserializeResult.Success;
        }

        public static int SizeOf(PacketHeader Header)
        {
            return PacketHeader.Size;
        }

        public static byte[] Serialize(IPacket Data)
        {
            switch(PacketToIdConverterGenerated.GetId(Data))
            {
                
                case Ping_RQ.Id:
                {
                    return Serialize((Ping_RQ)Data);
                }

                case Ping_RS.Id:
                {
                    return Serialize((Ping_RS)Data);
                }

                case GetServerPublicKey_RQ.Id:
                {
                    return Serialize((GetServerPublicKey_RQ)Data);
                }

                case GetServerPublicKey_RS.Id:
                {
                    return Serialize((GetServerPublicKey_RS)Data);
                }

                case CreateAccount_RQ.Id:
                {
                    return Serialize((CreateAccount_RQ)Data);
                }

                case CreateAccount_RS.Id:
                {
                    return Serialize((CreateAccount_RS)Data);
                }

                case MatchCompleted_NT.Id:
                {
                    return Serialize((MatchCompleted_NT)Data);
                }

                case MatchStart_RQ.Id:
                {
                    return Serialize((MatchStart_RQ)Data);
                }

                case MatchStart_RS.Id:
                {
                    return Serialize((MatchStart_RS)Data);
                }

                case MatchStop_RQ.Id:
                {
                    return Serialize((MatchStop_RQ)Data);
                }

                case MatchStop_RS.Id:
                {
                    return Serialize((MatchStop_RS)Data);
                }

                case Login_RQ.Id:
                {
                    return Serialize((Login_RQ)Data);
                }

                case Login_RS.Id:
                {
                    return Serialize((Login_RS)Data);
                }

                case WaitingRoomCharTransSync_RP.Id:
                {
                    return Serialize((WaitingRoomCharTransSync_RP)Data);
                }

                case WaitingRoomCharTransSync_NT.Id:
                {
                    return Serialize((WaitingRoomCharTransSync_NT)Data);
                }

                case WaitingRoomCharacterSpawn_RQ.Id:
                {
                    return Serialize((WaitingRoomCharacterSpawn_RQ)Data);
                }

                case WaitingRoomCharacterSpawn_RS.Id:
                {
                    return Serialize((WaitingRoomCharacterSpawn_RS)Data);
                }

                case WaitingRoomCharacterSpawn_NT.Id:
                {
                    return Serialize((WaitingRoomCharacterSpawn_NT)Data);
                }

                case GameRoomObjectInfos_RQ.Id:
                {
                    return Serialize((GameRoomObjectInfos_RQ)Data);
                }

                case GameRoomObjectInfos_RS.Id:
                {
                    return Serialize((GameRoomObjectInfos_RS)Data);
                }

                default: 
                {
                    string ExceptionStr = $"정의되지 않은 패킷이 들어왔습니다. Data.ToString(): {Data.ToString()}";
                    AdamLogger.Log(LogLevel.Error, ExceptionStr);
                    throw new Exception(ExceptionStr);
                }
            }
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out IPacket Data)
        {
            switch(Header.PacketId)
            {
                
                case Ping_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out Ping_RQ PacketData);
                    Data = PacketData;
                    return Result;
                }

                case Ping_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out Ping_RS PacketData);
                    Data = PacketData;
                    return Result;
                }

                case GetServerPublicKey_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out GetServerPublicKey_RQ PacketData);
                    Data = PacketData;
                    return Result;
                }

                case GetServerPublicKey_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out GetServerPublicKey_RS PacketData);
                    Data = PacketData;
                    return Result;
                }

                case CreateAccount_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out CreateAccount_RQ PacketData);
                    Data = PacketData;
                    return Result;
                }

                case CreateAccount_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out CreateAccount_RS PacketData);
                    Data = PacketData;
                    return Result;
                }

                case MatchCompleted_NT.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out MatchCompleted_NT PacketData);
                    Data = PacketData;
                    return Result;
                }

                case MatchStart_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out MatchStart_RQ PacketData);
                    Data = PacketData;
                    return Result;
                }

                case MatchStart_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out MatchStart_RS PacketData);
                    Data = PacketData;
                    return Result;
                }

                case MatchStop_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out MatchStop_RQ PacketData);
                    Data = PacketData;
                    return Result;
                }

                case MatchStop_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out MatchStop_RS PacketData);
                    Data = PacketData;
                    return Result;
                }

                case Login_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out Login_RQ PacketData);
                    Data = PacketData;
                    return Result;
                }

                case Login_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out Login_RS PacketData);
                    Data = PacketData;
                    return Result;
                }

                case WaitingRoomCharTransSync_RP.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out WaitingRoomCharTransSync_RP PacketData);
                    Data = PacketData;
                    return Result;
                }

                case WaitingRoomCharTransSync_NT.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out WaitingRoomCharTransSync_NT PacketData);
                    Data = PacketData;
                    return Result;
                }

                case WaitingRoomCharacterSpawn_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out WaitingRoomCharacterSpawn_RQ PacketData);
                    Data = PacketData;
                    return Result;
                }

                case WaitingRoomCharacterSpawn_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out WaitingRoomCharacterSpawn_RS PacketData);
                    Data = PacketData;
                    return Result;
                }

                case WaitingRoomCharacterSpawn_NT.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out WaitingRoomCharacterSpawn_NT PacketData);
                    Data = PacketData;
                    return Result;
                }

                case GameRoomObjectInfos_RQ.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out GameRoomObjectInfos_RQ PacketData);
                    Data = PacketData;
                    return Result;
                }

                case GameRoomObjectInfos_RS.Id:
                {
                    EDeserializeResult Result = Deserialize(Buff, Header, out GameRoomObjectInfos_RS PacketData);
                    Data = PacketData;
                    return Result;
                }

                default: 
                {
                    string ExceptionStr = $"정의되지 않은 패킷이 들어왔습니다. Header.PacketId: {Header.PacketId}";
                    AdamLogger.Log(LogLevel.Error, ExceptionStr);
                    throw new Exception(ExceptionStr);
                }
            }
        }


        public static int SizeOf(IPacket Data)
        {
            switch(PacketToIdConverterGenerated.GetId(Data))
            {
                
                case Ping_RQ.Id:
                {
                    return SizeOf((Ping_RQ)Data);
                }

                case Ping_RS.Id:
                {
                    return SizeOf((Ping_RS)Data);
                }

                case GetServerPublicKey_RQ.Id:
                {
                    return SizeOf((GetServerPublicKey_RQ)Data);
                }

                case GetServerPublicKey_RS.Id:
                {
                    return SizeOf((GetServerPublicKey_RS)Data);
                }

                case CreateAccount_RQ.Id:
                {
                    return SizeOf((CreateAccount_RQ)Data);
                }

                case CreateAccount_RS.Id:
                {
                    return SizeOf((CreateAccount_RS)Data);
                }

                case MatchCompleted_NT.Id:
                {
                    return SizeOf((MatchCompleted_NT)Data);
                }

                case MatchStart_RQ.Id:
                {
                    return SizeOf((MatchStart_RQ)Data);
                }

                case MatchStart_RS.Id:
                {
                    return SizeOf((MatchStart_RS)Data);
                }

                case MatchStop_RQ.Id:
                {
                    return SizeOf((MatchStop_RQ)Data);
                }

                case MatchStop_RS.Id:
                {
                    return SizeOf((MatchStop_RS)Data);
                }

                case Login_RQ.Id:
                {
                    return SizeOf((Login_RQ)Data);
                }

                case Login_RS.Id:
                {
                    return SizeOf((Login_RS)Data);
                }

                case WaitingRoomCharTransSync_RP.Id:
                {
                    return SizeOf((WaitingRoomCharTransSync_RP)Data);
                }

                case WaitingRoomCharTransSync_NT.Id:
                {
                    return SizeOf((WaitingRoomCharTransSync_NT)Data);
                }

                case WaitingRoomCharacterSpawn_RQ.Id:
                {
                    return SizeOf((WaitingRoomCharacterSpawn_RQ)Data);
                }

                case WaitingRoomCharacterSpawn_RS.Id:
                {
                    return SizeOf((WaitingRoomCharacterSpawn_RS)Data);
                }

                case WaitingRoomCharacterSpawn_NT.Id:
                {
                    return SizeOf((WaitingRoomCharacterSpawn_NT)Data);
                }

                case GameRoomObjectInfos_RQ.Id:
                {
                    return SizeOf((GameRoomObjectInfos_RQ)Data);
                }

                case GameRoomObjectInfos_RS.Id:
                {
                    return SizeOf((GameRoomObjectInfos_RS)Data);
                }

                default: 
                {
                    string ExceptionStr = $"정의되지 않은 패킷이 들어왔습니다. Data.ToString(): {Data.ToString()}";
                    AdamLogger.Log(LogLevel.Error, ExceptionStr);
                    throw new Exception(ExceptionStr);
                }
            }
        }


        
        public static byte[] Serialize(Ping_RQ Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(Ping_RS Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(GetServerPublicKey_RQ Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(GetServerPublicKey_RS Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(CreateAccount_RQ Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(CreateAccount_RS Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(MatchCompleted_NT Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(MatchStart_RQ Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(MatchStart_RS Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(MatchStop_RQ Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(MatchStop_RS Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(Login_RQ Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(Login_RS Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(WaitingRoomCharTransSync_RP Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(WaitingRoomCharTransSync_NT Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(WaitingRoomCharacterSpawn_RQ Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(WaitingRoomCharacterSpawn_RS Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(WaitingRoomCharacterSpawn_NT Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(GameRoomObjectInfos_RQ Data)
        {
            return Data.Serialize();
        }

        public static byte[] Serialize(GameRoomObjectInfos_RS Data)
        {
            return Data.Serialize();
        }


        
        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out Ping_RQ Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new Ping_RQ();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out Ping_RS Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new Ping_RS();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out GetServerPublicKey_RQ Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new GetServerPublicKey_RQ();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out GetServerPublicKey_RS Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new GetServerPublicKey_RS();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out CreateAccount_RQ Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new CreateAccount_RQ();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out CreateAccount_RS Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new CreateAccount_RS();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out MatchCompleted_NT Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new MatchCompleted_NT();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out MatchStart_RQ Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new MatchStart_RQ();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out MatchStart_RS Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new MatchStart_RS();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out MatchStop_RQ Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new MatchStop_RQ();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out MatchStop_RS Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new MatchStop_RS();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out Login_RQ Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new Login_RQ();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out Login_RS Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new Login_RS();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out WaitingRoomCharTransSync_RP Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new WaitingRoomCharTransSync_RP();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out WaitingRoomCharTransSync_NT Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new WaitingRoomCharTransSync_NT();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out WaitingRoomCharacterSpawn_RQ Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new WaitingRoomCharacterSpawn_RQ();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out WaitingRoomCharacterSpawn_RS Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new WaitingRoomCharacterSpawn_RS();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out WaitingRoomCharacterSpawn_NT Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new WaitingRoomCharacterSpawn_NT();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out GameRoomObjectInfos_RQ Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new GameRoomObjectInfos_RQ();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }

        public static EDeserializeResult Deserialize(ArraySegment<byte> Buff, PacketHeader Header, out GameRoomObjectInfos_RS Data)
        {
            if(Buff.Count < Header.PacketSize)
            {
                Data = null;
                return EDeserializeResult.PacketFragmentation;
            }

            Data = new GameRoomObjectInfos_RS();
            Data.Deserialize(Buff.Array, Buff.Offset, Header.PacketSize);
            return EDeserializeResult.Success;
        }


        
        public static int SizeOf(Ping_RQ Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(Ping_RS Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(GetServerPublicKey_RQ Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(GetServerPublicKey_RS Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(CreateAccount_RQ Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(CreateAccount_RS Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(MatchCompleted_NT Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(MatchStart_RQ Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(MatchStart_RS Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(MatchStop_RQ Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(MatchStop_RS Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(Login_RQ Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(Login_RS Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(WaitingRoomCharTransSync_RP Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(WaitingRoomCharTransSync_NT Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(WaitingRoomCharacterSpawn_RQ Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(WaitingRoomCharacterSpawn_RS Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(WaitingRoomCharacterSpawn_NT Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(GameRoomObjectInfos_RQ Data)
        {
            return Data.Serialize().Length;
        }

        public static int SizeOf(GameRoomObjectInfos_RS Data)
        {
            return Data.Serialize().Length;
        }

    }
}
