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
    public class AdamClientPacketHandlerGenerated : AdamPacketHandlerGenerated
    {
        public AdamClientPacketHandlerGenerated(AdamSession InSession) : base(InSession)
        {
        }
 
        

        
        protected sealed override Task<Ping_RS> OnRecvPing_RQ(PacketHeader Header, Ping_RQ Packet)
        {
            if(Header.PacketId != Ping_RQ.Id)   
                throw new Exception("Packet Id Not Matched !");

            throw new NotImplementedException();
        }

        protected override void OnRecvPing_RS(PacketHeader Header, Ping_RS Packet)
        {
            if(Header.PacketId != Ping_RS.Id)   
                throw new Exception("Packet Id Not Matched !");
        }

        protected sealed override Task<GetServerPublicKey_RS> OnRecvGetServerPublicKey_RQ(PacketHeader Header, GetServerPublicKey_RQ Packet)
        {
            if(Header.PacketId != GetServerPublicKey_RQ.Id)   
                throw new Exception("Packet Id Not Matched !");

            throw new NotImplementedException();
        }

        protected override void OnRecvGetServerPublicKey_RS(PacketHeader Header, GetServerPublicKey_RS Packet)
        {
            if(Header.PacketId != GetServerPublicKey_RS.Id)   
                throw new Exception("Packet Id Not Matched !");
        }

        protected sealed override Task<CreateAccount_RS> OnRecvCreateAccount_RQ(PacketHeader Header, CreateAccount_RQ Packet)
        {
            if(Header.PacketId != CreateAccount_RQ.Id)   
                throw new Exception("Packet Id Not Matched !");

            throw new NotImplementedException();
        }

        protected override void OnRecvCreateAccount_RS(PacketHeader Header, CreateAccount_RS Packet)
        {
            if(Header.PacketId != CreateAccount_RS.Id)   
                throw new Exception("Packet Id Not Matched !");
        }

        protected override void OnRecvMatchCompleted_NT(PacketHeader Header, MatchCompleted_NT Packet)
        {
            if(Header.PacketId != MatchCompleted_NT.Id)   
                throw new Exception("Packet Id Not Matched !");
        }

        protected sealed override Task<MatchStart_RS> OnRecvMatchStart_RQ(PacketHeader Header, MatchStart_RQ Packet)
        {
            if(Header.PacketId != MatchStart_RQ.Id)   
                throw new Exception("Packet Id Not Matched !");

            throw new NotImplementedException();
        }

        protected override void OnRecvMatchStart_RS(PacketHeader Header, MatchStart_RS Packet)
        {
            if(Header.PacketId != MatchStart_RS.Id)   
                throw new Exception("Packet Id Not Matched !");
        }

        protected sealed override Task<MatchStop_RS> OnRecvMatchStop_RQ(PacketHeader Header, MatchStop_RQ Packet)
        {
            if(Header.PacketId != MatchStop_RQ.Id)   
                throw new Exception("Packet Id Not Matched !");

            throw new NotImplementedException();
        }

        protected override void OnRecvMatchStop_RS(PacketHeader Header, MatchStop_RS Packet)
        {
            if(Header.PacketId != MatchStop_RS.Id)   
                throw new Exception("Packet Id Not Matched !");
        }

        protected sealed override Task<Login_RS> OnRecvLogin_RQ(PacketHeader Header, Login_RQ Packet)
        {
            if(Header.PacketId != Login_RQ.Id)   
                throw new Exception("Packet Id Not Matched !");

            throw new NotImplementedException();
        }

        protected override void OnRecvLogin_RS(PacketHeader Header, Login_RS Packet)
        {
            if(Header.PacketId != Login_RS.Id)   
                throw new Exception("Packet Id Not Matched !");
        }

        protected sealed override void OnRecvWaitingRoomCharTransSync_RP(PacketHeader Header, WaitingRoomCharTransSync_RP Packet)
        {
            if(Header.PacketId != WaitingRoomCharTransSync_RP.Id)   
                throw new Exception("Packet Id Not Matched !");

            throw new NotImplementedException();
        }

        protected override void OnRecvWaitingRoomCharTransSync_NT(PacketHeader Header, WaitingRoomCharTransSync_NT Packet)
        {
            if(Header.PacketId != WaitingRoomCharTransSync_NT.Id)   
                throw new Exception("Packet Id Not Matched !");
        }

        protected sealed override Task<WaitingRoomCharacterSpawn_RS> OnRecvWaitingRoomCharacterSpawn_RQ(PacketHeader Header, WaitingRoomCharacterSpawn_RQ Packet)
        {
            if(Header.PacketId != WaitingRoomCharacterSpawn_RQ.Id)   
                throw new Exception("Packet Id Not Matched !");

            throw new NotImplementedException();
        }

        protected override void OnRecvWaitingRoomCharacterSpawn_RS(PacketHeader Header, WaitingRoomCharacterSpawn_RS Packet)
        {
            if(Header.PacketId != WaitingRoomCharacterSpawn_RS.Id)   
                throw new Exception("Packet Id Not Matched !");
        }

        protected override void OnRecvWaitingRoomCharacterSpawn_NT(PacketHeader Header, WaitingRoomCharacterSpawn_NT Packet)
        {
            if(Header.PacketId != WaitingRoomCharacterSpawn_NT.Id)   
                throw new Exception("Packet Id Not Matched !");
        }

        protected sealed override Task<GameRoomObjectInfos_RS> OnRecvGameRoomObjectInfos_RQ(PacketHeader Header, GameRoomObjectInfos_RQ Packet)
        {
            if(Header.PacketId != GameRoomObjectInfos_RQ.Id)   
                throw new Exception("Packet Id Not Matched !");

            throw new NotImplementedException();
        }

        protected override void OnRecvGameRoomObjectInfos_RS(PacketHeader Header, GameRoomObjectInfos_RS Packet)
        {
            if(Header.PacketId != GameRoomObjectInfos_RS.Id)   
                throw new Exception("Packet Id Not Matched !");
        }

    }
}
