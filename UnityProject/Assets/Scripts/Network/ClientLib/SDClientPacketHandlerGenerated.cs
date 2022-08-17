/*

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
{
    public class SDClientPacketHandlerGenerated : AdamClientPacketHandlerGenerated
    {
        public ConcurrentQueue<KeyValuePair<PacketHeader, IPacket>> PacketQueue { get; } = new ConcurrentQueue<KeyValuePair<PacketHeader, IPacket>>();

        public SDClientPacketHandlerGenerated(AdamSession InSession) : base(InSession)
        {
            
            Register(new NetworkEventListener<Ping_RS>(), (PacketHeader Header, Ping_RS Response) => {  PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Response)); });

            Register(new NetworkEventListener<GetServerPublicKey_RS>(), (PacketHeader Header, GetServerPublicKey_RS Response) => {  PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Response)); });

            Register(new NetworkEventListener<CreateAccount_RS>(), (PacketHeader Header, CreateAccount_RS Response) => {  PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Response)); });

            Register(new NetworkEventListener<MatchCompleted_NT>(), (PacketHeader Header, MatchCompleted_NT Notify) => {  PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Notify)); });

            Register(new NetworkEventListener<MatchStart_RS>(), (PacketHeader Header, MatchStart_RS Response) => {  PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Response)); });

            Register(new NetworkEventListener<MatchStop_RS>(), (PacketHeader Header, MatchStop_RS Response) => {  PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Response)); });

            Register(new NetworkEventListener<Login_RS>(), (PacketHeader Header, Login_RS Response) => {  PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Response)); });

            Register(new NetworkEventListener<WaitingRoomCharTransSync_NT>(), (PacketHeader Header, WaitingRoomCharTransSync_NT Notify) => {  PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Notify)); });

            Register(new NetworkEventListener<WaitingRoomCharacterSpawn_RS>(), (PacketHeader Header, WaitingRoomCharacterSpawn_RS Response) => {  PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Response)); });

            Register(new NetworkEventListener<WaitingRoomCharacterSpawn_NT>(), (PacketHeader Header, WaitingRoomCharacterSpawn_NT Notify) => {  PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Notify)); });

            Register(new NetworkEventListener<GameRoomObjectInfos_RS>(), (PacketHeader Header, GameRoomObjectInfos_RS Response) => {  PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Response)); });

        }
    
        
        protected override void OnRecvPing_RS(PacketHeader Header, Ping_RS Response)
        {
            PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Response));
        }

        protected override void OnRecvGetServerPublicKey_RS(PacketHeader Header, GetServerPublicKey_RS Response)
        {
            PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Response));
        }

        protected override void OnRecvCreateAccount_RS(PacketHeader Header, CreateAccount_RS Response)
        {
            PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Response));
        }

        protected override void OnRecvMatchCompleted_NT(PacketHeader Header, MatchCompleted_NT Notify)
        {
            PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Notify));
        }

        protected override void OnRecvMatchStart_RS(PacketHeader Header, MatchStart_RS Response)
        {
            PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Response));
        }

        protected override void OnRecvMatchStop_RS(PacketHeader Header, MatchStop_RS Response)
        {
            PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Response));
        }

        protected override void OnRecvLogin_RS(PacketHeader Header, Login_RS Response)
        {
            PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Response));
        }

        protected override void OnRecvWaitingRoomCharTransSync_NT(PacketHeader Header, WaitingRoomCharTransSync_NT Notify)
        {
            PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Notify));
        }

        protected override void OnRecvWaitingRoomCharacterSpawn_RS(PacketHeader Header, WaitingRoomCharacterSpawn_RS Response)
        {
            PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Response));
        }

        protected override void OnRecvWaitingRoomCharacterSpawn_NT(PacketHeader Header, WaitingRoomCharacterSpawn_NT Notify)
        {
            PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Notify));
        }

        protected override void OnRecvGameRoomObjectInfos_RS(PacketHeader Header, GameRoomObjectInfos_RS Response)
        {
            PacketQueue.Enqueue(new KeyValuePair<PacketHeader, IPacket>(Header, Response));
        }

    }
}
