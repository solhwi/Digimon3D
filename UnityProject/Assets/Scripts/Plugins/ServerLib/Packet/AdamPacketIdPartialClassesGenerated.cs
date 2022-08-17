/*

    자동 생성 되는 코드입니다.
    절대 직접 수정하지마세요.

*/

using System;
using System.Collections.Generic;
using Google.Protobuf;

namespace ServerLib
{
    public class PacketAttribute : Attribute
    {
        public ushort Id;
    }

    
    [PacketAttribute(Id = 1)]
    public partial class Ping_RQ : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 1;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            Ping_RQ Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 2)]
    public partial class Ping_RS : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 2;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            Ping_RS Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 3)]
    public partial class GetServerPublicKey_RQ : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 3;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            GetServerPublicKey_RQ Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 4)]
    public partial class GetServerPublicKey_RS : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 4;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            GetServerPublicKey_RS Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 5)]
    public partial class CreateAccount_RQ : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 5;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            CreateAccount_RQ Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 6)]
    public partial class CreateAccount_RS : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 6;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            CreateAccount_RS Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 7)]
    public partial class MatchCompleted_NT : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 7;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            MatchCompleted_NT Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 8)]
    public partial class MatchStart_RQ : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 8;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            MatchStart_RQ Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 9)]
    public partial class MatchStart_RS : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 9;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            MatchStart_RS Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 10)]
    public partial class MatchStop_RQ : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 10;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            MatchStop_RQ Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 11)]
    public partial class MatchStop_RS : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 11;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            MatchStop_RS Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 12)]
    public partial class Login_RQ : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 12;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            Login_RQ Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 13)]
    public partial class Login_RS : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 13;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            Login_RS Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 14)]
    public partial class WaitingRoomCharTransSync_RP : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 14;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            WaitingRoomCharTransSync_RP Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 15)]
    public partial class WaitingRoomCharTransSync_NT : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 15;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            WaitingRoomCharTransSync_NT Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 16)]
    public partial class WaitingRoomCharacterSpawn_RQ : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 16;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            WaitingRoomCharacterSpawn_RQ Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 17)]
    public partial class WaitingRoomCharacterSpawn_RS : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 17;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            WaitingRoomCharacterSpawn_RS Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 18)]
    public partial class WaitingRoomCharacterSpawn_NT : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 18;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            WaitingRoomCharacterSpawn_NT Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 19)]
    public partial class GameRoomObjectInfos_RQ : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 19;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            GameRoomObjectInfos_RQ Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

    [PacketAttribute(Id = 20)]
    public partial class GameRoomObjectInfos_RS : IPacket
    {
        public static JsonFormatter JsonFormatterInstace = new JsonFormatter(JsonFormatter.Settings.Default);
        public const ushort Id = 20;

        public string ToJson()
        {
            return JsonFormatterInstace.Format(this);
        }

        public byte[] Serialize()
        {
            return this.ToByteArray();
        }

        public void Deserialize(byte[] Buff, int Offset, int Size)
        {
            GameRoomObjectInfos_RS Result = Parser.ParseFrom(Buff, Offset, Size);

            MergeFrom(Result);
        }
    }

}

namespace ServerLib
{
    public class PacketToIdConverterGenerated
    {
        public static ushort GetId(IPacket Packet)
        {
            
            if(Packet is Ping_RQ)
                return Ping_RQ.Id;

            else if(Packet is Ping_RS)
                return Ping_RS.Id;

            else if(Packet is GetServerPublicKey_RQ)
                return GetServerPublicKey_RQ.Id;

            else if(Packet is GetServerPublicKey_RS)
                return GetServerPublicKey_RS.Id;

            else if(Packet is CreateAccount_RQ)
                return CreateAccount_RQ.Id;

            else if(Packet is CreateAccount_RS)
                return CreateAccount_RS.Id;

            else if(Packet is MatchCompleted_NT)
                return MatchCompleted_NT.Id;

            else if(Packet is MatchStart_RQ)
                return MatchStart_RQ.Id;

            else if(Packet is MatchStart_RS)
                return MatchStart_RS.Id;

            else if(Packet is MatchStop_RQ)
                return MatchStop_RQ.Id;

            else if(Packet is MatchStop_RS)
                return MatchStop_RS.Id;

            else if(Packet is Login_RQ)
                return Login_RQ.Id;

            else if(Packet is Login_RS)
                return Login_RS.Id;

            else if(Packet is WaitingRoomCharTransSync_RP)
                return WaitingRoomCharTransSync_RP.Id;

            else if(Packet is WaitingRoomCharTransSync_NT)
                return WaitingRoomCharTransSync_NT.Id;

            else if(Packet is WaitingRoomCharacterSpawn_RQ)
                return WaitingRoomCharacterSpawn_RQ.Id;

            else if(Packet is WaitingRoomCharacterSpawn_RS)
                return WaitingRoomCharacterSpawn_RS.Id;

            else if(Packet is WaitingRoomCharacterSpawn_NT)
                return WaitingRoomCharacterSpawn_NT.Id;

            else if(Packet is GameRoomObjectInfos_RQ)
                return GameRoomObjectInfos_RQ.Id;

            else if(Packet is GameRoomObjectInfos_RS)
                return GameRoomObjectInfos_RS.Id;

            else
            {
                string ExceptionStr = $"정의되지 않은 패킷이 들어왔습니다. Packet.ToString(): {Packet.ToString()}";
                AdamLogger.Log(LogLevel.Error, ExceptionStr);
                throw new Exception(ExceptionStr);
            }
        }
    }
}
