/*

    자동 생성 되는 코드입니다.
    절대 직접 수정하지마세요.

*/

using System;
using Google.Protobuf;
using System.Net;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.Generic;

namespace ServerLib
{
    public class NetworkEventListener<PacketType> where PacketType : IPacket { }

    public abstract class AdamPacketHandlerGenerated
    {
        protected AdamSession Session;
        public AdamPacketHandlerGenerated(AdamSession InSession)
        {
            Session = InSession;
            Session.OnRecvEvent += (PacketHeader InHeader, IPacket InPacket) => { OnRecv(InHeader, InPacket); };
            Session.OnConnectEvent += () => { OnConnect(); };
            Session.OnDisconnectEvent += () => { OnDisconnect(); };
            Session.OnSendEvent += (int SendSize) => { OnSend(SendSize); };
            Session.OnPreSendEvent += (PacketHeader Header, IPacket Packet) => { OnPreSend(Header, Packet); };
        }

        public void Send(IPacket Packet)
        {
            Session.Send(Packet);
        }

        
        private Dictionary<NetworkEventListener<Ping_RQ>, Action<PacketHeader, Ping_RQ>> Ping_RQ_Registration 
            = new Dictionary<NetworkEventListener<Ping_RQ>, Action<PacketHeader, Ping_RQ>>();

        private Dictionary<NetworkEventListener<Ping_RS>, Action<PacketHeader, Ping_RS>> Ping_RS_Registration 
            = new Dictionary<NetworkEventListener<Ping_RS>, Action<PacketHeader, Ping_RS>>();

        private Dictionary<NetworkEventListener<Ping_RS>, Action<PacketHeader, Ping_RS>> Ping_RS_ErrorRegistration 
            = new Dictionary<NetworkEventListener<Ping_RS>, Action<PacketHeader, Ping_RS>>();

        private Dictionary<NetworkEventListener<GetServerPublicKey_RQ>, Action<PacketHeader, GetServerPublicKey_RQ>> GetServerPublicKey_RQ_Registration 
            = new Dictionary<NetworkEventListener<GetServerPublicKey_RQ>, Action<PacketHeader, GetServerPublicKey_RQ>>();

        private Dictionary<NetworkEventListener<GetServerPublicKey_RS>, Action<PacketHeader, GetServerPublicKey_RS>> GetServerPublicKey_RS_Registration 
            = new Dictionary<NetworkEventListener<GetServerPublicKey_RS>, Action<PacketHeader, GetServerPublicKey_RS>>();

        private Dictionary<NetworkEventListener<GetServerPublicKey_RS>, Action<PacketHeader, GetServerPublicKey_RS>> GetServerPublicKey_RS_ErrorRegistration 
            = new Dictionary<NetworkEventListener<GetServerPublicKey_RS>, Action<PacketHeader, GetServerPublicKey_RS>>();

        private Dictionary<NetworkEventListener<CreateAccount_RQ>, Action<PacketHeader, CreateAccount_RQ>> CreateAccount_RQ_Registration 
            = new Dictionary<NetworkEventListener<CreateAccount_RQ>, Action<PacketHeader, CreateAccount_RQ>>();

        private Dictionary<NetworkEventListener<CreateAccount_RS>, Action<PacketHeader, CreateAccount_RS>> CreateAccount_RS_Registration 
            = new Dictionary<NetworkEventListener<CreateAccount_RS>, Action<PacketHeader, CreateAccount_RS>>();

        private Dictionary<NetworkEventListener<CreateAccount_RS>, Action<PacketHeader, CreateAccount_RS>> CreateAccount_RS_ErrorRegistration 
            = new Dictionary<NetworkEventListener<CreateAccount_RS>, Action<PacketHeader, CreateAccount_RS>>();

        private Dictionary<NetworkEventListener<MatchCompleted_NT>, Action<PacketHeader, MatchCompleted_NT>> MatchCompleted_NT_Registration 
            = new Dictionary<NetworkEventListener<MatchCompleted_NT>, Action<PacketHeader, MatchCompleted_NT>>();

        private Dictionary<NetworkEventListener<MatchStart_RQ>, Action<PacketHeader, MatchStart_RQ>> MatchStart_RQ_Registration 
            = new Dictionary<NetworkEventListener<MatchStart_RQ>, Action<PacketHeader, MatchStart_RQ>>();

        private Dictionary<NetworkEventListener<MatchStart_RS>, Action<PacketHeader, MatchStart_RS>> MatchStart_RS_Registration 
            = new Dictionary<NetworkEventListener<MatchStart_RS>, Action<PacketHeader, MatchStart_RS>>();

        private Dictionary<NetworkEventListener<MatchStart_RS>, Action<PacketHeader, MatchStart_RS>> MatchStart_RS_ErrorRegistration 
            = new Dictionary<NetworkEventListener<MatchStart_RS>, Action<PacketHeader, MatchStart_RS>>();

        private Dictionary<NetworkEventListener<MatchStop_RQ>, Action<PacketHeader, MatchStop_RQ>> MatchStop_RQ_Registration 
            = new Dictionary<NetworkEventListener<MatchStop_RQ>, Action<PacketHeader, MatchStop_RQ>>();

        private Dictionary<NetworkEventListener<MatchStop_RS>, Action<PacketHeader, MatchStop_RS>> MatchStop_RS_Registration 
            = new Dictionary<NetworkEventListener<MatchStop_RS>, Action<PacketHeader, MatchStop_RS>>();

        private Dictionary<NetworkEventListener<MatchStop_RS>, Action<PacketHeader, MatchStop_RS>> MatchStop_RS_ErrorRegistration 
            = new Dictionary<NetworkEventListener<MatchStop_RS>, Action<PacketHeader, MatchStop_RS>>();

        private Dictionary<NetworkEventListener<Login_RQ>, Action<PacketHeader, Login_RQ>> Login_RQ_Registration 
            = new Dictionary<NetworkEventListener<Login_RQ>, Action<PacketHeader, Login_RQ>>();

        private Dictionary<NetworkEventListener<Login_RS>, Action<PacketHeader, Login_RS>> Login_RS_Registration 
            = new Dictionary<NetworkEventListener<Login_RS>, Action<PacketHeader, Login_RS>>();

        private Dictionary<NetworkEventListener<Login_RS>, Action<PacketHeader, Login_RS>> Login_RS_ErrorRegistration 
            = new Dictionary<NetworkEventListener<Login_RS>, Action<PacketHeader, Login_RS>>();

        private Dictionary<NetworkEventListener<WaitingRoomCharTransSync_RP>, Action<PacketHeader, WaitingRoomCharTransSync_RP>> WaitingRoomCharTransSync_RP_Registration 
            = new Dictionary<NetworkEventListener<WaitingRoomCharTransSync_RP>, Action<PacketHeader, WaitingRoomCharTransSync_RP>>();

        private Dictionary<NetworkEventListener<WaitingRoomCharTransSync_NT>, Action<PacketHeader, WaitingRoomCharTransSync_NT>> WaitingRoomCharTransSync_NT_Registration 
            = new Dictionary<NetworkEventListener<WaitingRoomCharTransSync_NT>, Action<PacketHeader, WaitingRoomCharTransSync_NT>>();

        private Dictionary<NetworkEventListener<WaitingRoomCharacterSpawn_RQ>, Action<PacketHeader, WaitingRoomCharacterSpawn_RQ>> WaitingRoomCharacterSpawn_RQ_Registration 
            = new Dictionary<NetworkEventListener<WaitingRoomCharacterSpawn_RQ>, Action<PacketHeader, WaitingRoomCharacterSpawn_RQ>>();

        private Dictionary<NetworkEventListener<WaitingRoomCharacterSpawn_RS>, Action<PacketHeader, WaitingRoomCharacterSpawn_RS>> WaitingRoomCharacterSpawn_RS_Registration 
            = new Dictionary<NetworkEventListener<WaitingRoomCharacterSpawn_RS>, Action<PacketHeader, WaitingRoomCharacterSpawn_RS>>();

        private Dictionary<NetworkEventListener<WaitingRoomCharacterSpawn_RS>, Action<PacketHeader, WaitingRoomCharacterSpawn_RS>> WaitingRoomCharacterSpawn_RS_ErrorRegistration 
            = new Dictionary<NetworkEventListener<WaitingRoomCharacterSpawn_RS>, Action<PacketHeader, WaitingRoomCharacterSpawn_RS>>();

        private Dictionary<NetworkEventListener<WaitingRoomCharacterSpawn_NT>, Action<PacketHeader, WaitingRoomCharacterSpawn_NT>> WaitingRoomCharacterSpawn_NT_Registration 
            = new Dictionary<NetworkEventListener<WaitingRoomCharacterSpawn_NT>, Action<PacketHeader, WaitingRoomCharacterSpawn_NT>>();

        private Dictionary<NetworkEventListener<GameRoomObjectInfos_RQ>, Action<PacketHeader, GameRoomObjectInfos_RQ>> GameRoomObjectInfos_RQ_Registration 
            = new Dictionary<NetworkEventListener<GameRoomObjectInfos_RQ>, Action<PacketHeader, GameRoomObjectInfos_RQ>>();

        private Dictionary<NetworkEventListener<GameRoomObjectInfos_RS>, Action<PacketHeader, GameRoomObjectInfos_RS>> GameRoomObjectInfos_RS_Registration 
            = new Dictionary<NetworkEventListener<GameRoomObjectInfos_RS>, Action<PacketHeader, GameRoomObjectInfos_RS>>();

        private Dictionary<NetworkEventListener<GameRoomObjectInfos_RS>, Action<PacketHeader, GameRoomObjectInfos_RS>> GameRoomObjectInfos_RS_ErrorRegistration 
            = new Dictionary<NetworkEventListener<GameRoomObjectInfos_RS>, Action<PacketHeader, GameRoomObjectInfos_RS>>();

    
        
        protected Action<PacketHeader, Ping_RQ> OnRecvEventPing_RQ { get; set; }

        protected Action<PacketHeader, Ping_RS> OnRecvEventPing_RS { get; set; }

        protected Action<PacketHeader, Ping_RS> OnRecvErrorEventPing_RS { get; set; }

        protected Action<PacketHeader, GetServerPublicKey_RQ> OnRecvEventGetServerPublicKey_RQ { get; set; }

        protected Action<PacketHeader, GetServerPublicKey_RS> OnRecvEventGetServerPublicKey_RS { get; set; }

        protected Action<PacketHeader, GetServerPublicKey_RS> OnRecvErrorEventGetServerPublicKey_RS { get; set; }

        protected Action<PacketHeader, CreateAccount_RQ> OnRecvEventCreateAccount_RQ { get; set; }

        protected Action<PacketHeader, CreateAccount_RS> OnRecvEventCreateAccount_RS { get; set; }

        protected Action<PacketHeader, CreateAccount_RS> OnRecvErrorEventCreateAccount_RS { get; set; }

        protected Action<PacketHeader, MatchCompleted_NT> OnRecvEventMatchCompleted_NT { get; set; }

        protected Action<PacketHeader, MatchStart_RQ> OnRecvEventMatchStart_RQ { get; set; }

        protected Action<PacketHeader, MatchStart_RS> OnRecvEventMatchStart_RS { get; set; }

        protected Action<PacketHeader, MatchStart_RS> OnRecvErrorEventMatchStart_RS { get; set; }

        protected Action<PacketHeader, MatchStop_RQ> OnRecvEventMatchStop_RQ { get; set; }

        protected Action<PacketHeader, MatchStop_RS> OnRecvEventMatchStop_RS { get; set; }

        protected Action<PacketHeader, MatchStop_RS> OnRecvErrorEventMatchStop_RS { get; set; }

        protected Action<PacketHeader, Login_RQ> OnRecvEventLogin_RQ { get; set; }

        protected Action<PacketHeader, Login_RS> OnRecvEventLogin_RS { get; set; }

        protected Action<PacketHeader, Login_RS> OnRecvErrorEventLogin_RS { get; set; }

        protected Action<PacketHeader, WaitingRoomCharTransSync_RP> OnRecvEventWaitingRoomCharTransSync_RP { get; set; }

        protected Action<PacketHeader, WaitingRoomCharTransSync_NT> OnRecvEventWaitingRoomCharTransSync_NT { get; set; }

        protected Action<PacketHeader, WaitingRoomCharacterSpawn_RQ> OnRecvEventWaitingRoomCharacterSpawn_RQ { get; set; }

        protected Action<PacketHeader, WaitingRoomCharacterSpawn_RS> OnRecvEventWaitingRoomCharacterSpawn_RS { get; set; }

        protected Action<PacketHeader, WaitingRoomCharacterSpawn_RS> OnRecvErrorEventWaitingRoomCharacterSpawn_RS { get; set; }

        protected Action<PacketHeader, WaitingRoomCharacterSpawn_NT> OnRecvEventWaitingRoomCharacterSpawn_NT { get; set; }

        protected Action<PacketHeader, GameRoomObjectInfos_RQ> OnRecvEventGameRoomObjectInfos_RQ { get; set; }

        protected Action<PacketHeader, GameRoomObjectInfos_RS> OnRecvEventGameRoomObjectInfos_RS { get; set; }

        protected Action<PacketHeader, GameRoomObjectInfos_RS> OnRecvErrorEventGameRoomObjectInfos_RS { get; set; }


        
        private async void OnRecvPing_RQ_Implementation(PacketHeader Header, Ping_RQ Request)
        {
            if (OnRecvEventPing_RQ != null && OnRecvEventPing_RQ.GetInvocationList().Length > 0)
                return;
 
             Ping_RS Response = await OnRecvPing_RQ(Header, Request);
             if(Response == null)
                throw new Exception("Try To Send Null Packet");

             Session.Send(Response);
        }

        protected virtual Task<Ping_RS> OnRecvPing_RQ(PacketHeader Header, Ping_RQ Request)
        {
            return Task.FromResult(new Ping_RS() { Error = Ping_RS.Types.Ping_Error.NotImplemented });
        }

        private void OnRecvPing_RS_Implementation(PacketHeader Header, Ping_RS Response)
        {
             OnRecvPing_RS(Header, Response);
        }

        protected virtual void OnRecvPing_RS(PacketHeader Header, Ping_RS Response)
        {
        }

        private void OnRecvErrorPing_RS_Implementation(PacketHeader Header, Ping_RS Response)
        {
             OnRecvErrorPing_RS(Header, Response);
        }

        protected virtual void OnRecvErrorPing_RS(PacketHeader Header, Ping_RS Response)
        {
        }

        private async void OnRecvGetServerPublicKey_RQ_Implementation(PacketHeader Header, GetServerPublicKey_RQ Request)
        {
            if (OnRecvEventGetServerPublicKey_RQ != null && OnRecvEventGetServerPublicKey_RQ.GetInvocationList().Length > 0)
                return;
 
             GetServerPublicKey_RS Response = await OnRecvGetServerPublicKey_RQ(Header, Request);
             if(Response == null)
                throw new Exception("Try To Send Null Packet");

             Session.Send(Response);
        }

        protected virtual Task<GetServerPublicKey_RS> OnRecvGetServerPublicKey_RQ(PacketHeader Header, GetServerPublicKey_RQ Request)
        {
            return Task.FromResult(new GetServerPublicKey_RS() { Error = GetServerPublicKey_RS.Types.GetServerPublicKey_Error.NotImplemented });
        }

        private void OnRecvGetServerPublicKey_RS_Implementation(PacketHeader Header, GetServerPublicKey_RS Response)
        {
             OnRecvGetServerPublicKey_RS(Header, Response);
        }

        protected virtual void OnRecvGetServerPublicKey_RS(PacketHeader Header, GetServerPublicKey_RS Response)
        {
        }

        private void OnRecvErrorGetServerPublicKey_RS_Implementation(PacketHeader Header, GetServerPublicKey_RS Response)
        {
             OnRecvErrorGetServerPublicKey_RS(Header, Response);
        }

        protected virtual void OnRecvErrorGetServerPublicKey_RS(PacketHeader Header, GetServerPublicKey_RS Response)
        {
        }

        private async void OnRecvCreateAccount_RQ_Implementation(PacketHeader Header, CreateAccount_RQ Request)
        {
            if (OnRecvEventCreateAccount_RQ != null && OnRecvEventCreateAccount_RQ.GetInvocationList().Length > 0)
                return;
 
             CreateAccount_RS Response = await OnRecvCreateAccount_RQ(Header, Request);
             if(Response == null)
                throw new Exception("Try To Send Null Packet");

             Session.Send(Response);
        }

        protected virtual Task<CreateAccount_RS> OnRecvCreateAccount_RQ(PacketHeader Header, CreateAccount_RQ Request)
        {
            return Task.FromResult(new CreateAccount_RS() { Error = CreateAccount_RS.Types.CreateAccount_Error.NotImplemented });
        }

        private void OnRecvCreateAccount_RS_Implementation(PacketHeader Header, CreateAccount_RS Response)
        {
             OnRecvCreateAccount_RS(Header, Response);
        }

        protected virtual void OnRecvCreateAccount_RS(PacketHeader Header, CreateAccount_RS Response)
        {
        }

        private void OnRecvErrorCreateAccount_RS_Implementation(PacketHeader Header, CreateAccount_RS Response)
        {
             OnRecvErrorCreateAccount_RS(Header, Response);
        }

        protected virtual void OnRecvErrorCreateAccount_RS(PacketHeader Header, CreateAccount_RS Response)
        {
        }

        private void OnRecvMatchCompleted_NT_Implementation(PacketHeader Header, MatchCompleted_NT Notify)
        {
             OnRecvMatchCompleted_NT(Header, Notify);
        }

        protected virtual void OnRecvMatchCompleted_NT(PacketHeader Header, MatchCompleted_NT Notify)
        {
        }

        private async void OnRecvMatchStart_RQ_Implementation(PacketHeader Header, MatchStart_RQ Request)
        {
            if (OnRecvEventMatchStart_RQ != null && OnRecvEventMatchStart_RQ.GetInvocationList().Length > 0)
                return;
 
             MatchStart_RS Response = await OnRecvMatchStart_RQ(Header, Request);
             if(Response == null)
                throw new Exception("Try To Send Null Packet");

             Session.Send(Response);
        }

        protected virtual Task<MatchStart_RS> OnRecvMatchStart_RQ(PacketHeader Header, MatchStart_RQ Request)
        {
            return Task.FromResult(new MatchStart_RS() { Error = MatchStart_RS.Types.MatchStart_Error.NotImplemented });
        }

        private void OnRecvMatchStart_RS_Implementation(PacketHeader Header, MatchStart_RS Response)
        {
             OnRecvMatchStart_RS(Header, Response);
        }

        protected virtual void OnRecvMatchStart_RS(PacketHeader Header, MatchStart_RS Response)
        {
        }

        private void OnRecvErrorMatchStart_RS_Implementation(PacketHeader Header, MatchStart_RS Response)
        {
             OnRecvErrorMatchStart_RS(Header, Response);
        }

        protected virtual void OnRecvErrorMatchStart_RS(PacketHeader Header, MatchStart_RS Response)
        {
        }

        private async void OnRecvMatchStop_RQ_Implementation(PacketHeader Header, MatchStop_RQ Request)
        {
            if (OnRecvEventMatchStop_RQ != null && OnRecvEventMatchStop_RQ.GetInvocationList().Length > 0)
                return;
 
             MatchStop_RS Response = await OnRecvMatchStop_RQ(Header, Request);
             if(Response == null)
                throw new Exception("Try To Send Null Packet");

             Session.Send(Response);
        }

        protected virtual Task<MatchStop_RS> OnRecvMatchStop_RQ(PacketHeader Header, MatchStop_RQ Request)
        {
            return Task.FromResult(new MatchStop_RS() { Error = MatchStop_RS.Types.MatchStop_Error.NotImplemented });
        }

        private void OnRecvMatchStop_RS_Implementation(PacketHeader Header, MatchStop_RS Response)
        {
             OnRecvMatchStop_RS(Header, Response);
        }

        protected virtual void OnRecvMatchStop_RS(PacketHeader Header, MatchStop_RS Response)
        {
        }

        private void OnRecvErrorMatchStop_RS_Implementation(PacketHeader Header, MatchStop_RS Response)
        {
             OnRecvErrorMatchStop_RS(Header, Response);
        }

        protected virtual void OnRecvErrorMatchStop_RS(PacketHeader Header, MatchStop_RS Response)
        {
        }

        private async void OnRecvLogin_RQ_Implementation(PacketHeader Header, Login_RQ Request)
        {
            if (OnRecvEventLogin_RQ != null && OnRecvEventLogin_RQ.GetInvocationList().Length > 0)
                return;
 
             Login_RS Response = await OnRecvLogin_RQ(Header, Request);
             if(Response == null)
                throw new Exception("Try To Send Null Packet");

             Session.Send(Response);
        }

        protected virtual Task<Login_RS> OnRecvLogin_RQ(PacketHeader Header, Login_RQ Request)
        {
            return Task.FromResult(new Login_RS() { Error = Login_RS.Types.Login_Error.NotImplemented });
        }

        private void OnRecvLogin_RS_Implementation(PacketHeader Header, Login_RS Response)
        {
             OnRecvLogin_RS(Header, Response);
        }

        protected virtual void OnRecvLogin_RS(PacketHeader Header, Login_RS Response)
        {
        }

        private void OnRecvErrorLogin_RS_Implementation(PacketHeader Header, Login_RS Response)
        {
             OnRecvErrorLogin_RS(Header, Response);
        }

        protected virtual void OnRecvErrorLogin_RS(PacketHeader Header, Login_RS Response)
        {
        }

        private void OnRecvWaitingRoomCharTransSync_RP_Implementation(PacketHeader Header, WaitingRoomCharTransSync_RP Report)
        {
             OnRecvWaitingRoomCharTransSync_RP(Header, Report);
        }

        protected virtual void OnRecvWaitingRoomCharTransSync_RP(PacketHeader Header, WaitingRoomCharTransSync_RP Report)
        {
        }

        private void OnRecvWaitingRoomCharTransSync_NT_Implementation(PacketHeader Header, WaitingRoomCharTransSync_NT Notify)
        {
             OnRecvWaitingRoomCharTransSync_NT(Header, Notify);
        }

        protected virtual void OnRecvWaitingRoomCharTransSync_NT(PacketHeader Header, WaitingRoomCharTransSync_NT Notify)
        {
        }

        private async void OnRecvWaitingRoomCharacterSpawn_RQ_Implementation(PacketHeader Header, WaitingRoomCharacterSpawn_RQ Request)
        {
            if (OnRecvEventWaitingRoomCharacterSpawn_RQ != null && OnRecvEventWaitingRoomCharacterSpawn_RQ.GetInvocationList().Length > 0)
                return;
 
             WaitingRoomCharacterSpawn_RS Response = await OnRecvWaitingRoomCharacterSpawn_RQ(Header, Request);
             if(Response == null)
                throw new Exception("Try To Send Null Packet");

             Session.Send(Response);
        }

        protected virtual Task<WaitingRoomCharacterSpawn_RS> OnRecvWaitingRoomCharacterSpawn_RQ(PacketHeader Header, WaitingRoomCharacterSpawn_RQ Request)
        {
            return Task.FromResult(new WaitingRoomCharacterSpawn_RS() { Error = WaitingRoomCharacterSpawn_RS.Types.WaitingRoomCharacterSpawn_Error.NotImplemented });
        }

        private void OnRecvWaitingRoomCharacterSpawn_RS_Implementation(PacketHeader Header, WaitingRoomCharacterSpawn_RS Response)
        {
             OnRecvWaitingRoomCharacterSpawn_RS(Header, Response);
        }

        protected virtual void OnRecvWaitingRoomCharacterSpawn_RS(PacketHeader Header, WaitingRoomCharacterSpawn_RS Response)
        {
        }

        private void OnRecvErrorWaitingRoomCharacterSpawn_RS_Implementation(PacketHeader Header, WaitingRoomCharacterSpawn_RS Response)
        {
             OnRecvErrorWaitingRoomCharacterSpawn_RS(Header, Response);
        }

        protected virtual void OnRecvErrorWaitingRoomCharacterSpawn_RS(PacketHeader Header, WaitingRoomCharacterSpawn_RS Response)
        {
        }

        private void OnRecvWaitingRoomCharacterSpawn_NT_Implementation(PacketHeader Header, WaitingRoomCharacterSpawn_NT Notify)
        {
             OnRecvWaitingRoomCharacterSpawn_NT(Header, Notify);
        }

        protected virtual void OnRecvWaitingRoomCharacterSpawn_NT(PacketHeader Header, WaitingRoomCharacterSpawn_NT Notify)
        {
        }

        private async void OnRecvGameRoomObjectInfos_RQ_Implementation(PacketHeader Header, GameRoomObjectInfos_RQ Request)
        {
            if (OnRecvEventGameRoomObjectInfos_RQ != null && OnRecvEventGameRoomObjectInfos_RQ.GetInvocationList().Length > 0)
                return;
 
             GameRoomObjectInfos_RS Response = await OnRecvGameRoomObjectInfos_RQ(Header, Request);
             if(Response == null)
                throw new Exception("Try To Send Null Packet");

             Session.Send(Response);
        }

        protected virtual Task<GameRoomObjectInfos_RS> OnRecvGameRoomObjectInfos_RQ(PacketHeader Header, GameRoomObjectInfos_RQ Request)
        {
            return Task.FromResult(new GameRoomObjectInfos_RS() { Error = GameRoomObjectInfos_RS.Types.GameRoomObjectInfos_Error.NotImplemented });
        }

        private void OnRecvGameRoomObjectInfos_RS_Implementation(PacketHeader Header, GameRoomObjectInfos_RS Response)
        {
             OnRecvGameRoomObjectInfos_RS(Header, Response);
        }

        protected virtual void OnRecvGameRoomObjectInfos_RS(PacketHeader Header, GameRoomObjectInfos_RS Response)
        {
        }

        private void OnRecvErrorGameRoomObjectInfos_RS_Implementation(PacketHeader Header, GameRoomObjectInfos_RS Response)
        {
             OnRecvErrorGameRoomObjectInfos_RS(Header, Response);
        }

        protected virtual void OnRecvErrorGameRoomObjectInfos_RS(PacketHeader Header, GameRoomObjectInfos_RS Response)
        {
        }


        protected virtual void OnSend() 
        {
        }

        protected virtual void OnConnect() 
        {
        }
        protected virtual void OnSend(int SendSize) 
        {
        }
        protected virtual void OnPreSend(PacketHeader Header, IPacket Packet) 
        {
        }

        protected virtual void OnDisconnect() 
        {
        }

        protected virtual void OnRecvError(PacketHeader Header, IPacket ErrorPacket, string ErrorEnumString, string PacketJsonString)
        {
        }

        
        public bool Register(NetworkEventListener<Ping_RQ> EL, Action<PacketHeader, Ping_RQ> OnRecv)
        {
            if (EL == null)
                return false;

            // 중복 등록..
            if(Ping_RQ_Registration.ContainsKey(EL) == true)
            {
                return false;
            }
            else
            {
                Ping_RQ_Registration.Add(EL, OnRecv);
                OnRecvEventPing_RQ += OnRecv;
                return true;
            }
        }

        public bool Register(NetworkEventListener<Ping_RS> EL, Action<PacketHeader, Ping_RS> OnRecv, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;

            if(bErrorRegistration == false)
            {
                // 중복 등록..
                if(Ping_RS_Registration.ContainsKey(EL) == true)
                {
                    return false;
                }
                else
                {
                    Ping_RS_Registration.Add(EL, OnRecv);
                    OnRecvEventPing_RS += OnRecv;
                    return true;
                }
            }
            else
            {
                // 중복 등록..
                if(Ping_RS_ErrorRegistration.ContainsKey(EL) == true)
                {
                    return false;
                }
                else
                {
                    Ping_RS_ErrorRegistration.Add(EL, OnRecv);
                    OnRecvErrorEventPing_RS += OnRecv;
                    return true;
                }
            }

        }

        public bool Register(NetworkEventListener<GetServerPublicKey_RQ> EL, Action<PacketHeader, GetServerPublicKey_RQ> OnRecv)
        {
            if (EL == null)
                return false;

            // 중복 등록..
            if(GetServerPublicKey_RQ_Registration.ContainsKey(EL) == true)
            {
                return false;
            }
            else
            {
                GetServerPublicKey_RQ_Registration.Add(EL, OnRecv);
                OnRecvEventGetServerPublicKey_RQ += OnRecv;
                return true;
            }
        }

        public bool Register(NetworkEventListener<GetServerPublicKey_RS> EL, Action<PacketHeader, GetServerPublicKey_RS> OnRecv, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;

            if(bErrorRegistration == false)
            {
                // 중복 등록..
                if(GetServerPublicKey_RS_Registration.ContainsKey(EL) == true)
                {
                    return false;
                }
                else
                {
                    GetServerPublicKey_RS_Registration.Add(EL, OnRecv);
                    OnRecvEventGetServerPublicKey_RS += OnRecv;
                    return true;
                }
            }
            else
            {
                // 중복 등록..
                if(GetServerPublicKey_RS_ErrorRegistration.ContainsKey(EL) == true)
                {
                    return false;
                }
                else
                {
                    GetServerPublicKey_RS_ErrorRegistration.Add(EL, OnRecv);
                    OnRecvErrorEventGetServerPublicKey_RS += OnRecv;
                    return true;
                }
            }

        }

        public bool Register(NetworkEventListener<CreateAccount_RQ> EL, Action<PacketHeader, CreateAccount_RQ> OnRecv)
        {
            if (EL == null)
                return false;

            // 중복 등록..
            if(CreateAccount_RQ_Registration.ContainsKey(EL) == true)
            {
                return false;
            }
            else
            {
                CreateAccount_RQ_Registration.Add(EL, OnRecv);
                OnRecvEventCreateAccount_RQ += OnRecv;
                return true;
            }
        }

        public bool Register(NetworkEventListener<CreateAccount_RS> EL, Action<PacketHeader, CreateAccount_RS> OnRecv, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;

            if(bErrorRegistration == false)
            {
                // 중복 등록..
                if(CreateAccount_RS_Registration.ContainsKey(EL) == true)
                {
                    return false;
                }
                else
                {
                    CreateAccount_RS_Registration.Add(EL, OnRecv);
                    OnRecvEventCreateAccount_RS += OnRecv;
                    return true;
                }
            }
            else
            {
                // 중복 등록..
                if(CreateAccount_RS_ErrorRegistration.ContainsKey(EL) == true)
                {
                    return false;
                }
                else
                {
                    CreateAccount_RS_ErrorRegistration.Add(EL, OnRecv);
                    OnRecvErrorEventCreateAccount_RS += OnRecv;
                    return true;
                }
            }

        }

        public bool Register(NetworkEventListener<MatchCompleted_NT> EL, Action<PacketHeader, MatchCompleted_NT> OnRecv)
        {
            if (EL == null)
                return false;

            // 중복 등록..
            if(MatchCompleted_NT_Registration.ContainsKey(EL) == true)
            {
                return false;
            }
            else
            {
                MatchCompleted_NT_Registration.Add(EL, OnRecv);
                OnRecvEventMatchCompleted_NT += OnRecv;
                return true;
            }
        }

        public bool Register(NetworkEventListener<MatchStart_RQ> EL, Action<PacketHeader, MatchStart_RQ> OnRecv)
        {
            if (EL == null)
                return false;

            // 중복 등록..
            if(MatchStart_RQ_Registration.ContainsKey(EL) == true)
            {
                return false;
            }
            else
            {
                MatchStart_RQ_Registration.Add(EL, OnRecv);
                OnRecvEventMatchStart_RQ += OnRecv;
                return true;
            }
        }

        public bool Register(NetworkEventListener<MatchStart_RS> EL, Action<PacketHeader, MatchStart_RS> OnRecv, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;

            if(bErrorRegistration == false)
            {
                // 중복 등록..
                if(MatchStart_RS_Registration.ContainsKey(EL) == true)
                {
                    return false;
                }
                else
                {
                    MatchStart_RS_Registration.Add(EL, OnRecv);
                    OnRecvEventMatchStart_RS += OnRecv;
                    return true;
                }
            }
            else
            {
                // 중복 등록..
                if(MatchStart_RS_ErrorRegistration.ContainsKey(EL) == true)
                {
                    return false;
                }
                else
                {
                    MatchStart_RS_ErrorRegistration.Add(EL, OnRecv);
                    OnRecvErrorEventMatchStart_RS += OnRecv;
                    return true;
                }
            }

        }

        public bool Register(NetworkEventListener<MatchStop_RQ> EL, Action<PacketHeader, MatchStop_RQ> OnRecv)
        {
            if (EL == null)
                return false;

            // 중복 등록..
            if(MatchStop_RQ_Registration.ContainsKey(EL) == true)
            {
                return false;
            }
            else
            {
                MatchStop_RQ_Registration.Add(EL, OnRecv);
                OnRecvEventMatchStop_RQ += OnRecv;
                return true;
            }
        }

        public bool Register(NetworkEventListener<MatchStop_RS> EL, Action<PacketHeader, MatchStop_RS> OnRecv, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;

            if(bErrorRegistration == false)
            {
                // 중복 등록..
                if(MatchStop_RS_Registration.ContainsKey(EL) == true)
                {
                    return false;
                }
                else
                {
                    MatchStop_RS_Registration.Add(EL, OnRecv);
                    OnRecvEventMatchStop_RS += OnRecv;
                    return true;
                }
            }
            else
            {
                // 중복 등록..
                if(MatchStop_RS_ErrorRegistration.ContainsKey(EL) == true)
                {
                    return false;
                }
                else
                {
                    MatchStop_RS_ErrorRegistration.Add(EL, OnRecv);
                    OnRecvErrorEventMatchStop_RS += OnRecv;
                    return true;
                }
            }

        }

        public bool Register(NetworkEventListener<Login_RQ> EL, Action<PacketHeader, Login_RQ> OnRecv)
        {
            if (EL == null)
                return false;

            // 중복 등록..
            if(Login_RQ_Registration.ContainsKey(EL) == true)
            {
                return false;
            }
            else
            {
                Login_RQ_Registration.Add(EL, OnRecv);
                OnRecvEventLogin_RQ += OnRecv;
                return true;
            }
        }

        public bool Register(NetworkEventListener<Login_RS> EL, Action<PacketHeader, Login_RS> OnRecv, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;

            if(bErrorRegistration == false)
            {
                // 중복 등록..
                if(Login_RS_Registration.ContainsKey(EL) == true)
                {
                    return false;
                }
                else
                {
                    Login_RS_Registration.Add(EL, OnRecv);
                    OnRecvEventLogin_RS += OnRecv;
                    return true;
                }
            }
            else
            {
                // 중복 등록..
                if(Login_RS_ErrorRegistration.ContainsKey(EL) == true)
                {
                    return false;
                }
                else
                {
                    Login_RS_ErrorRegistration.Add(EL, OnRecv);
                    OnRecvErrorEventLogin_RS += OnRecv;
                    return true;
                }
            }

        }

        public bool Register(NetworkEventListener<WaitingRoomCharTransSync_RP> EL, Action<PacketHeader, WaitingRoomCharTransSync_RP> OnRecv)
        {
            if (EL == null)
                return false;

            // 중복 등록..
            if(WaitingRoomCharTransSync_RP_Registration.ContainsKey(EL) == true)
            {
                return false;
            }
            else
            {
                WaitingRoomCharTransSync_RP_Registration.Add(EL, OnRecv);
                OnRecvEventWaitingRoomCharTransSync_RP += OnRecv;
                return true;
            }
        }

        public bool Register(NetworkEventListener<WaitingRoomCharTransSync_NT> EL, Action<PacketHeader, WaitingRoomCharTransSync_NT> OnRecv)
        {
            if (EL == null)
                return false;

            // 중복 등록..
            if(WaitingRoomCharTransSync_NT_Registration.ContainsKey(EL) == true)
            {
                return false;
            }
            else
            {
                WaitingRoomCharTransSync_NT_Registration.Add(EL, OnRecv);
                OnRecvEventWaitingRoomCharTransSync_NT += OnRecv;
                return true;
            }
        }

        public bool Register(NetworkEventListener<WaitingRoomCharacterSpawn_RQ> EL, Action<PacketHeader, WaitingRoomCharacterSpawn_RQ> OnRecv)
        {
            if (EL == null)
                return false;

            // 중복 등록..
            if(WaitingRoomCharacterSpawn_RQ_Registration.ContainsKey(EL) == true)
            {
                return false;
            }
            else
            {
                WaitingRoomCharacterSpawn_RQ_Registration.Add(EL, OnRecv);
                OnRecvEventWaitingRoomCharacterSpawn_RQ += OnRecv;
                return true;
            }
        }

        public bool Register(NetworkEventListener<WaitingRoomCharacterSpawn_RS> EL, Action<PacketHeader, WaitingRoomCharacterSpawn_RS> OnRecv, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;

            if(bErrorRegistration == false)
            {
                // 중복 등록..
                if(WaitingRoomCharacterSpawn_RS_Registration.ContainsKey(EL) == true)
                {
                    return false;
                }
                else
                {
                    WaitingRoomCharacterSpawn_RS_Registration.Add(EL, OnRecv);
                    OnRecvEventWaitingRoomCharacterSpawn_RS += OnRecv;
                    return true;
                }
            }
            else
            {
                // 중복 등록..
                if(WaitingRoomCharacterSpawn_RS_ErrorRegistration.ContainsKey(EL) == true)
                {
                    return false;
                }
                else
                {
                    WaitingRoomCharacterSpawn_RS_ErrorRegistration.Add(EL, OnRecv);
                    OnRecvErrorEventWaitingRoomCharacterSpawn_RS += OnRecv;
                    return true;
                }
            }

        }

        public bool Register(NetworkEventListener<WaitingRoomCharacterSpawn_NT> EL, Action<PacketHeader, WaitingRoomCharacterSpawn_NT> OnRecv)
        {
            if (EL == null)
                return false;

            // 중복 등록..
            if(WaitingRoomCharacterSpawn_NT_Registration.ContainsKey(EL) == true)
            {
                return false;
            }
            else
            {
                WaitingRoomCharacterSpawn_NT_Registration.Add(EL, OnRecv);
                OnRecvEventWaitingRoomCharacterSpawn_NT += OnRecv;
                return true;
            }
        }

        public bool Register(NetworkEventListener<GameRoomObjectInfos_RQ> EL, Action<PacketHeader, GameRoomObjectInfos_RQ> OnRecv)
        {
            if (EL == null)
                return false;

            // 중복 등록..
            if(GameRoomObjectInfos_RQ_Registration.ContainsKey(EL) == true)
            {
                return false;
            }
            else
            {
                GameRoomObjectInfos_RQ_Registration.Add(EL, OnRecv);
                OnRecvEventGameRoomObjectInfos_RQ += OnRecv;
                return true;
            }
        }

        public bool Register(NetworkEventListener<GameRoomObjectInfos_RS> EL, Action<PacketHeader, GameRoomObjectInfos_RS> OnRecv, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;

            if(bErrorRegistration == false)
            {
                // 중복 등록..
                if(GameRoomObjectInfos_RS_Registration.ContainsKey(EL) == true)
                {
                    return false;
                }
                else
                {
                    GameRoomObjectInfos_RS_Registration.Add(EL, OnRecv);
                    OnRecvEventGameRoomObjectInfos_RS += OnRecv;
                    return true;
                }
            }
            else
            {
                // 중복 등록..
                if(GameRoomObjectInfos_RS_ErrorRegistration.ContainsKey(EL) == true)
                {
                    return false;
                }
                else
                {
                    GameRoomObjectInfos_RS_ErrorRegistration.Add(EL, OnRecv);
                    OnRecvErrorEventGameRoomObjectInfos_RS += OnRecv;
                    return true;
                }
            }

        }


        
        public bool Unregister(NetworkEventListener<Ping_RQ> EL)
        {
            if (EL == null)
                return false;
            
            if(Ping_RQ_Registration.ContainsKey(EL) == true)
            {
                Action<PacketHeader, Ping_RQ> OnRecv = Ping_RQ_Registration[EL];
                OnRecvEventPing_RQ -= OnRecv;
                Ping_RQ_Registration.Remove(EL);
                return true;
            }
            // 등록된게 없는데..
            else
            {
                return false;
            }
        }

        public bool Unregister(NetworkEventListener<Ping_RS> EL, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;
            
            if(bErrorRegistration == false)
            {
                if(Ping_RS_Registration.ContainsKey(EL) == true)
                {
                    Action<PacketHeader, Ping_RS> OnRecv = Ping_RS_Registration[EL];
                    OnRecvEventPing_RS -= OnRecv;
                    Ping_RS_Registration.Remove(EL);
                    return true;
                }
                // 등록된게 없는데..
                else
                {
                    return false;
                }
            }
            else
            {
                if(Ping_RS_ErrorRegistration.ContainsKey(EL) == true)
                {
                    Action<PacketHeader, Ping_RS> OnRecv = Ping_RS_ErrorRegistration[EL];
                    OnRecvErrorEventPing_RS -= OnRecv;
                    Ping_RS_ErrorRegistration.Remove(EL);
                    return true;
                }
                // 등록된게 없는데..
                else
                {
                    return false;
                }
            }

        }

        public bool Unregister(NetworkEventListener<GetServerPublicKey_RQ> EL)
        {
            if (EL == null)
                return false;
            
            if(GetServerPublicKey_RQ_Registration.ContainsKey(EL) == true)
            {
                Action<PacketHeader, GetServerPublicKey_RQ> OnRecv = GetServerPublicKey_RQ_Registration[EL];
                OnRecvEventGetServerPublicKey_RQ -= OnRecv;
                GetServerPublicKey_RQ_Registration.Remove(EL);
                return true;
            }
            // 등록된게 없는데..
            else
            {
                return false;
            }
        }

        public bool Unregister(NetworkEventListener<GetServerPublicKey_RS> EL, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;
            
            if(bErrorRegistration == false)
            {
                if(GetServerPublicKey_RS_Registration.ContainsKey(EL) == true)
                {
                    Action<PacketHeader, GetServerPublicKey_RS> OnRecv = GetServerPublicKey_RS_Registration[EL];
                    OnRecvEventGetServerPublicKey_RS -= OnRecv;
                    GetServerPublicKey_RS_Registration.Remove(EL);
                    return true;
                }
                // 등록된게 없는데..
                else
                {
                    return false;
                }
            }
            else
            {
                if(GetServerPublicKey_RS_ErrorRegistration.ContainsKey(EL) == true)
                {
                    Action<PacketHeader, GetServerPublicKey_RS> OnRecv = GetServerPublicKey_RS_ErrorRegistration[EL];
                    OnRecvErrorEventGetServerPublicKey_RS -= OnRecv;
                    GetServerPublicKey_RS_ErrorRegistration.Remove(EL);
                    return true;
                }
                // 등록된게 없는데..
                else
                {
                    return false;
                }
            }

        }

        public bool Unregister(NetworkEventListener<CreateAccount_RQ> EL)
        {
            if (EL == null)
                return false;
            
            if(CreateAccount_RQ_Registration.ContainsKey(EL) == true)
            {
                Action<PacketHeader, CreateAccount_RQ> OnRecv = CreateAccount_RQ_Registration[EL];
                OnRecvEventCreateAccount_RQ -= OnRecv;
                CreateAccount_RQ_Registration.Remove(EL);
                return true;
            }
            // 등록된게 없는데..
            else
            {
                return false;
            }
        }

        public bool Unregister(NetworkEventListener<CreateAccount_RS> EL, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;
            
            if(bErrorRegistration == false)
            {
                if(CreateAccount_RS_Registration.ContainsKey(EL) == true)
                {
                    Action<PacketHeader, CreateAccount_RS> OnRecv = CreateAccount_RS_Registration[EL];
                    OnRecvEventCreateAccount_RS -= OnRecv;
                    CreateAccount_RS_Registration.Remove(EL);
                    return true;
                }
                // 등록된게 없는데..
                else
                {
                    return false;
                }
            }
            else
            {
                if(CreateAccount_RS_ErrorRegistration.ContainsKey(EL) == true)
                {
                    Action<PacketHeader, CreateAccount_RS> OnRecv = CreateAccount_RS_ErrorRegistration[EL];
                    OnRecvErrorEventCreateAccount_RS -= OnRecv;
                    CreateAccount_RS_ErrorRegistration.Remove(EL);
                    return true;
                }
                // 등록된게 없는데..
                else
                {
                    return false;
                }
            }

        }

        public bool Unregister(NetworkEventListener<MatchCompleted_NT> EL)
        {
            if (EL == null)
                return false;
            
            if(MatchCompleted_NT_Registration.ContainsKey(EL) == true)
            {
                Action<PacketHeader, MatchCompleted_NT> OnRecv = MatchCompleted_NT_Registration[EL];
                OnRecvEventMatchCompleted_NT -= OnRecv;
                MatchCompleted_NT_Registration.Remove(EL);
                return true;
            }
            // 등록된게 없는데..
            else
            {
                return false;
            }
        }

        public bool Unregister(NetworkEventListener<MatchStart_RQ> EL)
        {
            if (EL == null)
                return false;
            
            if(MatchStart_RQ_Registration.ContainsKey(EL) == true)
            {
                Action<PacketHeader, MatchStart_RQ> OnRecv = MatchStart_RQ_Registration[EL];
                OnRecvEventMatchStart_RQ -= OnRecv;
                MatchStart_RQ_Registration.Remove(EL);
                return true;
            }
            // 등록된게 없는데..
            else
            {
                return false;
            }
        }

        public bool Unregister(NetworkEventListener<MatchStart_RS> EL, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;
            
            if(bErrorRegistration == false)
            {
                if(MatchStart_RS_Registration.ContainsKey(EL) == true)
                {
                    Action<PacketHeader, MatchStart_RS> OnRecv = MatchStart_RS_Registration[EL];
                    OnRecvEventMatchStart_RS -= OnRecv;
                    MatchStart_RS_Registration.Remove(EL);
                    return true;
                }
                // 등록된게 없는데..
                else
                {
                    return false;
                }
            }
            else
            {
                if(MatchStart_RS_ErrorRegistration.ContainsKey(EL) == true)
                {
                    Action<PacketHeader, MatchStart_RS> OnRecv = MatchStart_RS_ErrorRegistration[EL];
                    OnRecvErrorEventMatchStart_RS -= OnRecv;
                    MatchStart_RS_ErrorRegistration.Remove(EL);
                    return true;
                }
                // 등록된게 없는데..
                else
                {
                    return false;
                }
            }

        }

        public bool Unregister(NetworkEventListener<MatchStop_RQ> EL)
        {
            if (EL == null)
                return false;
            
            if(MatchStop_RQ_Registration.ContainsKey(EL) == true)
            {
                Action<PacketHeader, MatchStop_RQ> OnRecv = MatchStop_RQ_Registration[EL];
                OnRecvEventMatchStop_RQ -= OnRecv;
                MatchStop_RQ_Registration.Remove(EL);
                return true;
            }
            // 등록된게 없는데..
            else
            {
                return false;
            }
        }

        public bool Unregister(NetworkEventListener<MatchStop_RS> EL, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;
            
            if(bErrorRegistration == false)
            {
                if(MatchStop_RS_Registration.ContainsKey(EL) == true)
                {
                    Action<PacketHeader, MatchStop_RS> OnRecv = MatchStop_RS_Registration[EL];
                    OnRecvEventMatchStop_RS -= OnRecv;
                    MatchStop_RS_Registration.Remove(EL);
                    return true;
                }
                // 등록된게 없는데..
                else
                {
                    return false;
                }
            }
            else
            {
                if(MatchStop_RS_ErrorRegistration.ContainsKey(EL) == true)
                {
                    Action<PacketHeader, MatchStop_RS> OnRecv = MatchStop_RS_ErrorRegistration[EL];
                    OnRecvErrorEventMatchStop_RS -= OnRecv;
                    MatchStop_RS_ErrorRegistration.Remove(EL);
                    return true;
                }
                // 등록된게 없는데..
                else
                {
                    return false;
                }
            }

        }

        public bool Unregister(NetworkEventListener<Login_RQ> EL)
        {
            if (EL == null)
                return false;
            
            if(Login_RQ_Registration.ContainsKey(EL) == true)
            {
                Action<PacketHeader, Login_RQ> OnRecv = Login_RQ_Registration[EL];
                OnRecvEventLogin_RQ -= OnRecv;
                Login_RQ_Registration.Remove(EL);
                return true;
            }
            // 등록된게 없는데..
            else
            {
                return false;
            }
        }

        public bool Unregister(NetworkEventListener<Login_RS> EL, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;
            
            if(bErrorRegistration == false)
            {
                if(Login_RS_Registration.ContainsKey(EL) == true)
                {
                    Action<PacketHeader, Login_RS> OnRecv = Login_RS_Registration[EL];
                    OnRecvEventLogin_RS -= OnRecv;
                    Login_RS_Registration.Remove(EL);
                    return true;
                }
                // 등록된게 없는데..
                else
                {
                    return false;
                }
            }
            else
            {
                if(Login_RS_ErrorRegistration.ContainsKey(EL) == true)
                {
                    Action<PacketHeader, Login_RS> OnRecv = Login_RS_ErrorRegistration[EL];
                    OnRecvErrorEventLogin_RS -= OnRecv;
                    Login_RS_ErrorRegistration.Remove(EL);
                    return true;
                }
                // 등록된게 없는데..
                else
                {
                    return false;
                }
            }

        }

        public bool Unregister(NetworkEventListener<WaitingRoomCharTransSync_RP> EL)
        {
            if (EL == null)
                return false;
            
            if(WaitingRoomCharTransSync_RP_Registration.ContainsKey(EL) == true)
            {
                Action<PacketHeader, WaitingRoomCharTransSync_RP> OnRecv = WaitingRoomCharTransSync_RP_Registration[EL];
                OnRecvEventWaitingRoomCharTransSync_RP -= OnRecv;
                WaitingRoomCharTransSync_RP_Registration.Remove(EL);
                return true;
            }
            // 등록된게 없는데..
            else
            {
                return false;
            }
        }

        public bool Unregister(NetworkEventListener<WaitingRoomCharTransSync_NT> EL)
        {
            if (EL == null)
                return false;
            
            if(WaitingRoomCharTransSync_NT_Registration.ContainsKey(EL) == true)
            {
                Action<PacketHeader, WaitingRoomCharTransSync_NT> OnRecv = WaitingRoomCharTransSync_NT_Registration[EL];
                OnRecvEventWaitingRoomCharTransSync_NT -= OnRecv;
                WaitingRoomCharTransSync_NT_Registration.Remove(EL);
                return true;
            }
            // 등록된게 없는데..
            else
            {
                return false;
            }
        }

        public bool Unregister(NetworkEventListener<WaitingRoomCharacterSpawn_RQ> EL)
        {
            if (EL == null)
                return false;
            
            if(WaitingRoomCharacterSpawn_RQ_Registration.ContainsKey(EL) == true)
            {
                Action<PacketHeader, WaitingRoomCharacterSpawn_RQ> OnRecv = WaitingRoomCharacterSpawn_RQ_Registration[EL];
                OnRecvEventWaitingRoomCharacterSpawn_RQ -= OnRecv;
                WaitingRoomCharacterSpawn_RQ_Registration.Remove(EL);
                return true;
            }
            // 등록된게 없는데..
            else
            {
                return false;
            }
        }

        public bool Unregister(NetworkEventListener<WaitingRoomCharacterSpawn_RS> EL, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;
            
            if(bErrorRegistration == false)
            {
                if(WaitingRoomCharacterSpawn_RS_Registration.ContainsKey(EL) == true)
                {
                    Action<PacketHeader, WaitingRoomCharacterSpawn_RS> OnRecv = WaitingRoomCharacterSpawn_RS_Registration[EL];
                    OnRecvEventWaitingRoomCharacterSpawn_RS -= OnRecv;
                    WaitingRoomCharacterSpawn_RS_Registration.Remove(EL);
                    return true;
                }
                // 등록된게 없는데..
                else
                {
                    return false;
                }
            }
            else
            {
                if(WaitingRoomCharacterSpawn_RS_ErrorRegistration.ContainsKey(EL) == true)
                {
                    Action<PacketHeader, WaitingRoomCharacterSpawn_RS> OnRecv = WaitingRoomCharacterSpawn_RS_ErrorRegistration[EL];
                    OnRecvErrorEventWaitingRoomCharacterSpawn_RS -= OnRecv;
                    WaitingRoomCharacterSpawn_RS_ErrorRegistration.Remove(EL);
                    return true;
                }
                // 등록된게 없는데..
                else
                {
                    return false;
                }
            }

        }

        public bool Unregister(NetworkEventListener<WaitingRoomCharacterSpawn_NT> EL)
        {
            if (EL == null)
                return false;
            
            if(WaitingRoomCharacterSpawn_NT_Registration.ContainsKey(EL) == true)
            {
                Action<PacketHeader, WaitingRoomCharacterSpawn_NT> OnRecv = WaitingRoomCharacterSpawn_NT_Registration[EL];
                OnRecvEventWaitingRoomCharacterSpawn_NT -= OnRecv;
                WaitingRoomCharacterSpawn_NT_Registration.Remove(EL);
                return true;
            }
            // 등록된게 없는데..
            else
            {
                return false;
            }
        }

        public bool Unregister(NetworkEventListener<GameRoomObjectInfos_RQ> EL)
        {
            if (EL == null)
                return false;
            
            if(GameRoomObjectInfos_RQ_Registration.ContainsKey(EL) == true)
            {
                Action<PacketHeader, GameRoomObjectInfos_RQ> OnRecv = GameRoomObjectInfos_RQ_Registration[EL];
                OnRecvEventGameRoomObjectInfos_RQ -= OnRecv;
                GameRoomObjectInfos_RQ_Registration.Remove(EL);
                return true;
            }
            // 등록된게 없는데..
            else
            {
                return false;
            }
        }

        public bool Unregister(NetworkEventListener<GameRoomObjectInfos_RS> EL, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;
            
            if(bErrorRegistration == false)
            {
                if(GameRoomObjectInfos_RS_Registration.ContainsKey(EL) == true)
                {
                    Action<PacketHeader, GameRoomObjectInfos_RS> OnRecv = GameRoomObjectInfos_RS_Registration[EL];
                    OnRecvEventGameRoomObjectInfos_RS -= OnRecv;
                    GameRoomObjectInfos_RS_Registration.Remove(EL);
                    return true;
                }
                // 등록된게 없는데..
                else
                {
                    return false;
                }
            }
            else
            {
                if(GameRoomObjectInfos_RS_ErrorRegistration.ContainsKey(EL) == true)
                {
                    Action<PacketHeader, GameRoomObjectInfos_RS> OnRecv = GameRoomObjectInfos_RS_ErrorRegistration[EL];
                    OnRecvErrorEventGameRoomObjectInfos_RS -= OnRecv;
                    GameRoomObjectInfos_RS_ErrorRegistration.Remove(EL);
                    return true;
                }
                // 등록된게 없는데..
                else
                {
                    return false;
                }
            }

        }


        protected virtual void OnRecv(PacketHeader Header, IPacket Packet)
        {
            switch(Header.PacketId)
            {
               
                case Ping_RQ.Id:
                {
                    Ping_RQ Request = (Ping_RQ)Packet;
                    OnRecvEventPing_RQ?.Invoke(Header, Request);
                    OnRecvPing_RQ_Implementation(Header, Request);
                    break;
                }

                case Ping_RS.Id:
                {
                    Ping_RS Response = (Ping_RS)Packet;
                    if(Response.Error == Ping_RS.Types.Ping_Error.None)
                    {
                        OnRecvEventPing_RS?.Invoke(Header, Response);
                        OnRecvPing_RS_Implementation(Header, Response);
                    }
                    else
                    {
                        OnRecvErrorEventPing_RS?.Invoke(Header, Response);
                        OnRecvErrorPing_RS_Implementation(Header, Response);
                        OnRecvError(Header, Response, Response.Error.ToString(), Response.ToJson());
                    }
                    break;
                }

                case GetServerPublicKey_RQ.Id:
                {
                    GetServerPublicKey_RQ Request = (GetServerPublicKey_RQ)Packet;
                    OnRecvEventGetServerPublicKey_RQ?.Invoke(Header, Request);
                    OnRecvGetServerPublicKey_RQ_Implementation(Header, Request);
                    break;
                }

                case GetServerPublicKey_RS.Id:
                {
                    GetServerPublicKey_RS Response = (GetServerPublicKey_RS)Packet;
                    if(Response.Error == GetServerPublicKey_RS.Types.GetServerPublicKey_Error.None)
                    {
                        OnRecvEventGetServerPublicKey_RS?.Invoke(Header, Response);
                        OnRecvGetServerPublicKey_RS_Implementation(Header, Response);
                    }
                    else
                    {
                        OnRecvErrorEventGetServerPublicKey_RS?.Invoke(Header, Response);
                        OnRecvErrorGetServerPublicKey_RS_Implementation(Header, Response);
                        OnRecvError(Header, Response, Response.Error.ToString(), Response.ToJson());
                    }
                    break;
                }

                case CreateAccount_RQ.Id:
                {
                    CreateAccount_RQ Request = (CreateAccount_RQ)Packet;
                    OnRecvEventCreateAccount_RQ?.Invoke(Header, Request);
                    OnRecvCreateAccount_RQ_Implementation(Header, Request);
                    break;
                }

                case CreateAccount_RS.Id:
                {
                    CreateAccount_RS Response = (CreateAccount_RS)Packet;
                    if(Response.Error == CreateAccount_RS.Types.CreateAccount_Error.None)
                    {
                        OnRecvEventCreateAccount_RS?.Invoke(Header, Response);
                        OnRecvCreateAccount_RS_Implementation(Header, Response);
                    }
                    else
                    {
                        OnRecvErrorEventCreateAccount_RS?.Invoke(Header, Response);
                        OnRecvErrorCreateAccount_RS_Implementation(Header, Response);
                        OnRecvError(Header, Response, Response.Error.ToString(), Response.ToJson());
                    }
                    break;
                }

                case MatchCompleted_NT.Id:
                {
                    MatchCompleted_NT Notify = (MatchCompleted_NT)Packet;
                    OnRecvEventMatchCompleted_NT?.Invoke(Header, Notify);
                    OnRecvMatchCompleted_NT_Implementation(Header, Notify);
                    break;
                }

                case MatchStart_RQ.Id:
                {
                    MatchStart_RQ Request = (MatchStart_RQ)Packet;
                    OnRecvEventMatchStart_RQ?.Invoke(Header, Request);
                    OnRecvMatchStart_RQ_Implementation(Header, Request);
                    break;
                }

                case MatchStart_RS.Id:
                {
                    MatchStart_RS Response = (MatchStart_RS)Packet;
                    if(Response.Error == MatchStart_RS.Types.MatchStart_Error.None)
                    {
                        OnRecvEventMatchStart_RS?.Invoke(Header, Response);
                        OnRecvMatchStart_RS_Implementation(Header, Response);
                    }
                    else
                    {
                        OnRecvErrorEventMatchStart_RS?.Invoke(Header, Response);
                        OnRecvErrorMatchStart_RS_Implementation(Header, Response);
                        OnRecvError(Header, Response, Response.Error.ToString(), Response.ToJson());
                    }
                    break;
                }

                case MatchStop_RQ.Id:
                {
                    MatchStop_RQ Request = (MatchStop_RQ)Packet;
                    OnRecvEventMatchStop_RQ?.Invoke(Header, Request);
                    OnRecvMatchStop_RQ_Implementation(Header, Request);
                    break;
                }

                case MatchStop_RS.Id:
                {
                    MatchStop_RS Response = (MatchStop_RS)Packet;
                    if(Response.Error == MatchStop_RS.Types.MatchStop_Error.None)
                    {
                        OnRecvEventMatchStop_RS?.Invoke(Header, Response);
                        OnRecvMatchStop_RS_Implementation(Header, Response);
                    }
                    else
                    {
                        OnRecvErrorEventMatchStop_RS?.Invoke(Header, Response);
                        OnRecvErrorMatchStop_RS_Implementation(Header, Response);
                        OnRecvError(Header, Response, Response.Error.ToString(), Response.ToJson());
                    }
                    break;
                }

                case Login_RQ.Id:
                {
                    Login_RQ Request = (Login_RQ)Packet;
                    OnRecvEventLogin_RQ?.Invoke(Header, Request);
                    OnRecvLogin_RQ_Implementation(Header, Request);
                    break;
                }

                case Login_RS.Id:
                {
                    Login_RS Response = (Login_RS)Packet;
                    if(Response.Error == Login_RS.Types.Login_Error.None)
                    {
                        OnRecvEventLogin_RS?.Invoke(Header, Response);
                        OnRecvLogin_RS_Implementation(Header, Response);
                    }
                    else
                    {
                        OnRecvErrorEventLogin_RS?.Invoke(Header, Response);
                        OnRecvErrorLogin_RS_Implementation(Header, Response);
                        OnRecvError(Header, Response, Response.Error.ToString(), Response.ToJson());
                    }
                    break;
                }

                case WaitingRoomCharTransSync_RP.Id:
                {
                    WaitingRoomCharTransSync_RP Report = (WaitingRoomCharTransSync_RP)Packet;
                    OnRecvEventWaitingRoomCharTransSync_RP?.Invoke(Header, Report);
                    OnRecvWaitingRoomCharTransSync_RP_Implementation(Header, Report);
                    break;
                }

                case WaitingRoomCharTransSync_NT.Id:
                {
                    WaitingRoomCharTransSync_NT Notify = (WaitingRoomCharTransSync_NT)Packet;
                    OnRecvEventWaitingRoomCharTransSync_NT?.Invoke(Header, Notify);
                    OnRecvWaitingRoomCharTransSync_NT_Implementation(Header, Notify);
                    break;
                }

                case WaitingRoomCharacterSpawn_RQ.Id:
                {
                    WaitingRoomCharacterSpawn_RQ Request = (WaitingRoomCharacterSpawn_RQ)Packet;
                    OnRecvEventWaitingRoomCharacterSpawn_RQ?.Invoke(Header, Request);
                    OnRecvWaitingRoomCharacterSpawn_RQ_Implementation(Header, Request);
                    break;
                }

                case WaitingRoomCharacterSpawn_RS.Id:
                {
                    WaitingRoomCharacterSpawn_RS Response = (WaitingRoomCharacterSpawn_RS)Packet;
                    if(Response.Error == WaitingRoomCharacterSpawn_RS.Types.WaitingRoomCharacterSpawn_Error.None)
                    {
                        OnRecvEventWaitingRoomCharacterSpawn_RS?.Invoke(Header, Response);
                        OnRecvWaitingRoomCharacterSpawn_RS_Implementation(Header, Response);
                    }
                    else
                    {
                        OnRecvErrorEventWaitingRoomCharacterSpawn_RS?.Invoke(Header, Response);
                        OnRecvErrorWaitingRoomCharacterSpawn_RS_Implementation(Header, Response);
                        OnRecvError(Header, Response, Response.Error.ToString(), Response.ToJson());
                    }
                    break;
                }

                case WaitingRoomCharacterSpawn_NT.Id:
                {
                    WaitingRoomCharacterSpawn_NT Notify = (WaitingRoomCharacterSpawn_NT)Packet;
                    OnRecvEventWaitingRoomCharacterSpawn_NT?.Invoke(Header, Notify);
                    OnRecvWaitingRoomCharacterSpawn_NT_Implementation(Header, Notify);
                    break;
                }

                case GameRoomObjectInfos_RQ.Id:
                {
                    GameRoomObjectInfos_RQ Request = (GameRoomObjectInfos_RQ)Packet;
                    OnRecvEventGameRoomObjectInfos_RQ?.Invoke(Header, Request);
                    OnRecvGameRoomObjectInfos_RQ_Implementation(Header, Request);
                    break;
                }

                case GameRoomObjectInfos_RS.Id:
                {
                    GameRoomObjectInfos_RS Response = (GameRoomObjectInfos_RS)Packet;
                    if(Response.Error == GameRoomObjectInfos_RS.Types.GameRoomObjectInfos_Error.None)
                    {
                        OnRecvEventGameRoomObjectInfos_RS?.Invoke(Header, Response);
                        OnRecvGameRoomObjectInfos_RS_Implementation(Header, Response);
                    }
                    else
                    {
                        OnRecvErrorEventGameRoomObjectInfos_RS?.Invoke(Header, Response);
                        OnRecvErrorGameRoomObjectInfos_RS_Implementation(Header, Response);
                        OnRecvError(Header, Response, Response.Error.ToString(), Response.ToJson());
                    }
                    break;
                }


                default:
                {
                    AdamLogger.Log(LogLevel.Error, $"정의되지 않은 패킷이 들어왔습니다. {Packet.GetType()}");
                    break;
                }
            }
        }
    }
}
