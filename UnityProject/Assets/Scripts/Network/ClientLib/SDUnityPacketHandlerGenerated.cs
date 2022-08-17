/*

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
{
    public static class SDNetworkExtension
    {
        
        public static void Bind(this NetworkEventListener<Ping_RS> Listener, Action<Ping_RS> Callback)
        {
            SDNetwork.Handler?.Register(Listener, Callback);
        }

        public static void Unbind(this NetworkEventListener<Ping_RS> Listener)
        {
            SDNetwork.Handler?.Unregister(Listener);
        }

        public static void Bind(this NetworkEventListener<GetServerPublicKey_RS> Listener, Action<GetServerPublicKey_RS> Callback)
        {
            SDNetwork.Handler?.Register(Listener, Callback);
        }

        public static void Unbind(this NetworkEventListener<GetServerPublicKey_RS> Listener)
        {
            SDNetwork.Handler?.Unregister(Listener);
        }

        public static void Bind(this NetworkEventListener<CreateAccount_RS> Listener, Action<CreateAccount_RS> Callback)
        {
            SDNetwork.Handler?.Register(Listener, Callback);
        }

        public static void Unbind(this NetworkEventListener<CreateAccount_RS> Listener)
        {
            SDNetwork.Handler?.Unregister(Listener);
        }

        public static void Bind(this NetworkEventListener<MatchCompleted_NT> Listener, Action<MatchCompleted_NT> Callback)
        {
            SDNetwork.Handler?.Register(Listener, Callback);
        }

        public static void Unbind(this NetworkEventListener<MatchCompleted_NT> Listener)
        {
            SDNetwork.Handler?.Unregister(Listener);
        }

        public static void Bind(this NetworkEventListener<MatchStart_RS> Listener, Action<MatchStart_RS> Callback)
        {
            SDNetwork.Handler?.Register(Listener, Callback);
        }

        public static void Unbind(this NetworkEventListener<MatchStart_RS> Listener)
        {
            SDNetwork.Handler?.Unregister(Listener);
        }

        public static void Bind(this NetworkEventListener<MatchStop_RS> Listener, Action<MatchStop_RS> Callback)
        {
            SDNetwork.Handler?.Register(Listener, Callback);
        }

        public static void Unbind(this NetworkEventListener<MatchStop_RS> Listener)
        {
            SDNetwork.Handler?.Unregister(Listener);
        }

        public static void Bind(this NetworkEventListener<Login_RS> Listener, Action<Login_RS> Callback)
        {
            SDNetwork.Handler?.Register(Listener, Callback);
        }

        public static void Unbind(this NetworkEventListener<Login_RS> Listener)
        {
            SDNetwork.Handler?.Unregister(Listener);
        }

        public static void Bind(this NetworkEventListener<WaitingRoomCharTransSync_NT> Listener, Action<WaitingRoomCharTransSync_NT> Callback)
        {
            SDNetwork.Handler?.Register(Listener, Callback);
        }

        public static void Unbind(this NetworkEventListener<WaitingRoomCharTransSync_NT> Listener)
        {
            SDNetwork.Handler?.Unregister(Listener);
        }

        public static void Bind(this NetworkEventListener<WaitingRoomCharacterSpawn_RS> Listener, Action<WaitingRoomCharacterSpawn_RS> Callback)
        {
            SDNetwork.Handler?.Register(Listener, Callback);
        }

        public static void Unbind(this NetworkEventListener<WaitingRoomCharacterSpawn_RS> Listener)
        {
            SDNetwork.Handler?.Unregister(Listener);
        }

        public static void Bind(this NetworkEventListener<WaitingRoomCharacterSpawn_NT> Listener, Action<WaitingRoomCharacterSpawn_NT> Callback)
        {
            SDNetwork.Handler?.Register(Listener, Callback);
        }

        public static void Unbind(this NetworkEventListener<WaitingRoomCharacterSpawn_NT> Listener)
        {
            SDNetwork.Handler?.Unregister(Listener);
        }

        public static void Bind(this NetworkEventListener<GameRoomObjectInfos_RS> Listener, Action<GameRoomObjectInfos_RS> Callback)
        {
            SDNetwork.Handler?.Register(Listener, Callback);
        }

        public static void Unbind(this NetworkEventListener<GameRoomObjectInfos_RS> Listener)
        {
            SDNetwork.Handler?.Unregister(Listener);
        }

    }

    public abstract class SDUnityPacketHandlerGenerated
    {
        SDClientPacketHandlerGenerated ClientPacketHandler = null;

        public virtual void Init(AdamSession session)
        {
            ClientPacketHandler = new SDClientPacketHandlerGenerated(session);
        }

        public virtual void Run()
        {
            if(ClientPacketHandler.PacketQueue.Count == 0)
                return;

            while(ClientPacketHandler.PacketQueue.IsEmpty == false)
            {
                if(ClientPacketHandler.PacketQueue.TryDequeue(out KeyValuePair<PacketHeader, IPacket> Pair))
                {
                    OnRecv(Pair.Key, Pair.Value);
                }
                else
                {
                    return;
                }
            }
        }

        
        private Dictionary<NetworkEventListener<Ping_RS>, Action<Ping_RS>> Ping_RS_Registration 
            = new Dictionary<NetworkEventListener<Ping_RS>, Action<Ping_RS>>();

        private Dictionary<NetworkEventListener<Ping_RS>, Action<Ping_RS>> Ping_RS_ErrorRegistration 
            = new Dictionary<NetworkEventListener<Ping_RS>, Action<Ping_RS>>();

        private Dictionary<NetworkEventListener<GetServerPublicKey_RS>, Action<GetServerPublicKey_RS>> GetServerPublicKey_RS_Registration 
            = new Dictionary<NetworkEventListener<GetServerPublicKey_RS>, Action<GetServerPublicKey_RS>>();

        private Dictionary<NetworkEventListener<GetServerPublicKey_RS>, Action<GetServerPublicKey_RS>> GetServerPublicKey_RS_ErrorRegistration 
            = new Dictionary<NetworkEventListener<GetServerPublicKey_RS>, Action<GetServerPublicKey_RS>>();

        private Dictionary<NetworkEventListener<CreateAccount_RS>, Action<CreateAccount_RS>> CreateAccount_RS_Registration 
            = new Dictionary<NetworkEventListener<CreateAccount_RS>, Action<CreateAccount_RS>>();

        private Dictionary<NetworkEventListener<CreateAccount_RS>, Action<CreateAccount_RS>> CreateAccount_RS_ErrorRegistration 
            = new Dictionary<NetworkEventListener<CreateAccount_RS>, Action<CreateAccount_RS>>();

        private Dictionary<NetworkEventListener<MatchCompleted_NT>, Action<MatchCompleted_NT>> MatchCompleted_NT_Registration 
            = new Dictionary<NetworkEventListener<MatchCompleted_NT>, Action<MatchCompleted_NT>>();

        private Dictionary<NetworkEventListener<MatchStart_RS>, Action<MatchStart_RS>> MatchStart_RS_Registration 
            = new Dictionary<NetworkEventListener<MatchStart_RS>, Action<MatchStart_RS>>();

        private Dictionary<NetworkEventListener<MatchStart_RS>, Action<MatchStart_RS>> MatchStart_RS_ErrorRegistration 
            = new Dictionary<NetworkEventListener<MatchStart_RS>, Action<MatchStart_RS>>();

        private Dictionary<NetworkEventListener<MatchStop_RS>, Action<MatchStop_RS>> MatchStop_RS_Registration 
            = new Dictionary<NetworkEventListener<MatchStop_RS>, Action<MatchStop_RS>>();

        private Dictionary<NetworkEventListener<MatchStop_RS>, Action<MatchStop_RS>> MatchStop_RS_ErrorRegistration 
            = new Dictionary<NetworkEventListener<MatchStop_RS>, Action<MatchStop_RS>>();

        private Dictionary<NetworkEventListener<Login_RS>, Action<Login_RS>> Login_RS_Registration 
            = new Dictionary<NetworkEventListener<Login_RS>, Action<Login_RS>>();

        private Dictionary<NetworkEventListener<Login_RS>, Action<Login_RS>> Login_RS_ErrorRegistration 
            = new Dictionary<NetworkEventListener<Login_RS>, Action<Login_RS>>();

        private Dictionary<NetworkEventListener<WaitingRoomCharTransSync_NT>, Action<WaitingRoomCharTransSync_NT>> WaitingRoomCharTransSync_NT_Registration 
            = new Dictionary<NetworkEventListener<WaitingRoomCharTransSync_NT>, Action<WaitingRoomCharTransSync_NT>>();

        private Dictionary<NetworkEventListener<WaitingRoomCharacterSpawn_RS>, Action<WaitingRoomCharacterSpawn_RS>> WaitingRoomCharacterSpawn_RS_Registration 
            = new Dictionary<NetworkEventListener<WaitingRoomCharacterSpawn_RS>, Action<WaitingRoomCharacterSpawn_RS>>();

        private Dictionary<NetworkEventListener<WaitingRoomCharacterSpawn_RS>, Action<WaitingRoomCharacterSpawn_RS>> WaitingRoomCharacterSpawn_RS_ErrorRegistration 
            = new Dictionary<NetworkEventListener<WaitingRoomCharacterSpawn_RS>, Action<WaitingRoomCharacterSpawn_RS>>();

        private Dictionary<NetworkEventListener<WaitingRoomCharacterSpawn_NT>, Action<WaitingRoomCharacterSpawn_NT>> WaitingRoomCharacterSpawn_NT_Registration 
            = new Dictionary<NetworkEventListener<WaitingRoomCharacterSpawn_NT>, Action<WaitingRoomCharacterSpawn_NT>>();

        private Dictionary<NetworkEventListener<GameRoomObjectInfos_RS>, Action<GameRoomObjectInfos_RS>> GameRoomObjectInfos_RS_Registration 
            = new Dictionary<NetworkEventListener<GameRoomObjectInfos_RS>, Action<GameRoomObjectInfos_RS>>();

        private Dictionary<NetworkEventListener<GameRoomObjectInfos_RS>, Action<GameRoomObjectInfos_RS>> GameRoomObjectInfos_RS_ErrorRegistration 
            = new Dictionary<NetworkEventListener<GameRoomObjectInfos_RS>, Action<GameRoomObjectInfos_RS>>();


        
        private Action<Ping_RS> OnRecvEventPing_RS;

        private Action<Ping_RS> OnRecvErrorEventPing_RS;

        private Action<GetServerPublicKey_RS> OnRecvEventGetServerPublicKey_RS;

        private Action<GetServerPublicKey_RS> OnRecvErrorEventGetServerPublicKey_RS;

        private Action<CreateAccount_RS> OnRecvEventCreateAccount_RS;

        private Action<CreateAccount_RS> OnRecvErrorEventCreateAccount_RS;

        private Action<MatchCompleted_NT> OnRecvEventMatchCompleted_NT;

        private Action<MatchStart_RS> OnRecvEventMatchStart_RS;

        private Action<MatchStart_RS> OnRecvErrorEventMatchStart_RS;

        private Action<MatchStop_RS> OnRecvEventMatchStop_RS;

        private Action<MatchStop_RS> OnRecvErrorEventMatchStop_RS;

        private Action<Login_RS> OnRecvEventLogin_RS;

        private Action<Login_RS> OnRecvErrorEventLogin_RS;

        private Action<WaitingRoomCharTransSync_NT> OnRecvEventWaitingRoomCharTransSync_NT;

        private Action<WaitingRoomCharacterSpawn_RS> OnRecvEventWaitingRoomCharacterSpawn_RS;

        private Action<WaitingRoomCharacterSpawn_RS> OnRecvErrorEventWaitingRoomCharacterSpawn_RS;

        private Action<WaitingRoomCharacterSpawn_NT> OnRecvEventWaitingRoomCharacterSpawn_NT;

        private Action<GameRoomObjectInfos_RS> OnRecvEventGameRoomObjectInfos_RS;

        private Action<GameRoomObjectInfos_RS> OnRecvErrorEventGameRoomObjectInfos_RS;


        

        
        protected abstract void OnRecvPing_RS(Ping_RS Packet);

        protected virtual void OnRecvErrorPing_RS(Ping_RS Packet)
        {
               // OpenUI 처리할 것
        }

        protected abstract void OnRecvGetServerPublicKey_RS(GetServerPublicKey_RS Packet);

        protected virtual void OnRecvErrorGetServerPublicKey_RS(GetServerPublicKey_RS Packet)
        {
               // OpenUI 처리할 것
        }

        protected abstract void OnRecvCreateAccount_RS(CreateAccount_RS Packet);

        protected virtual void OnRecvErrorCreateAccount_RS(CreateAccount_RS Packet)
        {
               // OpenUI 처리할 것
        }

        protected abstract void OnRecvMatchCompleted_NT(MatchCompleted_NT Packet);

        protected abstract void OnRecvMatchStart_RS(MatchStart_RS Packet);

        protected virtual void OnRecvErrorMatchStart_RS(MatchStart_RS Packet)
        {
               // OpenUI 처리할 것
        }

        protected abstract void OnRecvMatchStop_RS(MatchStop_RS Packet);

        protected virtual void OnRecvErrorMatchStop_RS(MatchStop_RS Packet)
        {
               // OpenUI 처리할 것
        }

        protected abstract void OnRecvLogin_RS(Login_RS Packet);

        protected virtual void OnRecvErrorLogin_RS(Login_RS Packet)
        {
               // OpenUI 처리할 것
        }

        protected abstract void OnRecvWaitingRoomCharTransSync_NT(WaitingRoomCharTransSync_NT Packet);

        protected abstract void OnRecvWaitingRoomCharacterSpawn_RS(WaitingRoomCharacterSpawn_RS Packet);

        protected virtual void OnRecvErrorWaitingRoomCharacterSpawn_RS(WaitingRoomCharacterSpawn_RS Packet)
        {
               // OpenUI 처리할 것
        }

        protected abstract void OnRecvWaitingRoomCharacterSpawn_NT(WaitingRoomCharacterSpawn_NT Packet);

        protected abstract void OnRecvGameRoomObjectInfos_RS(GameRoomObjectInfos_RS Packet);

        protected virtual void OnRecvErrorGameRoomObjectInfos_RS(GameRoomObjectInfos_RS Packet)
        {
               // OpenUI 처리할 것
        }


        
        protected void OnRecv(PacketHeader Header, IPacket Packet)
        {
            switch(Header.PacketId)
            {
                
                case Ping_RS.Id:
                {
                    Ping_RS Response = (Ping_RS)Packet;
                    OnRecvPing_RS(Response);
                    OnRecvEventPing_RS?.Invoke(Response);
                    break;
                }

                case GetServerPublicKey_RS.Id:
                {
                    GetServerPublicKey_RS Response = (GetServerPublicKey_RS)Packet;
                    OnRecvGetServerPublicKey_RS(Response);
                    OnRecvEventGetServerPublicKey_RS?.Invoke(Response);
                    break;
                }

                case CreateAccount_RS.Id:
                {
                    CreateAccount_RS Response = (CreateAccount_RS)Packet;
                    OnRecvCreateAccount_RS(Response);
                    OnRecvEventCreateAccount_RS?.Invoke(Response);
                    break;
                }

                case MatchCompleted_NT.Id:
                {
                    MatchCompleted_NT Notify = (MatchCompleted_NT)Packet;
                    OnRecvMatchCompleted_NT(Notify);
                    OnRecvEventMatchCompleted_NT?.Invoke(Notify);
                    break;
                }

                case MatchStart_RS.Id:
                {
                    MatchStart_RS Response = (MatchStart_RS)Packet;
                    OnRecvMatchStart_RS(Response);
                    OnRecvEventMatchStart_RS?.Invoke(Response);
                    break;
                }

                case MatchStop_RS.Id:
                {
                    MatchStop_RS Response = (MatchStop_RS)Packet;
                    OnRecvMatchStop_RS(Response);
                    OnRecvEventMatchStop_RS?.Invoke(Response);
                    break;
                }

                case Login_RS.Id:
                {
                    Login_RS Response = (Login_RS)Packet;
                    OnRecvLogin_RS(Response);
                    OnRecvEventLogin_RS?.Invoke(Response);
                    break;
                }

                case WaitingRoomCharTransSync_NT.Id:
                {
                    WaitingRoomCharTransSync_NT Notify = (WaitingRoomCharTransSync_NT)Packet;
                    OnRecvWaitingRoomCharTransSync_NT(Notify);
                    OnRecvEventWaitingRoomCharTransSync_NT?.Invoke(Notify);
                    break;
                }

                case WaitingRoomCharacterSpawn_RS.Id:
                {
                    WaitingRoomCharacterSpawn_RS Response = (WaitingRoomCharacterSpawn_RS)Packet;
                    OnRecvWaitingRoomCharacterSpawn_RS(Response);
                    OnRecvEventWaitingRoomCharacterSpawn_RS?.Invoke(Response);
                    break;
                }

                case WaitingRoomCharacterSpawn_NT.Id:
                {
                    WaitingRoomCharacterSpawn_NT Notify = (WaitingRoomCharacterSpawn_NT)Packet;
                    OnRecvWaitingRoomCharacterSpawn_NT(Notify);
                    OnRecvEventWaitingRoomCharacterSpawn_NT?.Invoke(Notify);
                    break;
                }

                case GameRoomObjectInfos_RS.Id:
                {
                    GameRoomObjectInfos_RS Response = (GameRoomObjectInfos_RS)Packet;
                    OnRecvGameRoomObjectInfos_RS(Response);
                    OnRecvEventGameRoomObjectInfos_RS?.Invoke(Response);
                    break;
                }


                default:
                {
                    AdamLogger.Log(LogLevel.Error, $"정의되지 않은 패킷이 들어왔습니다. {Packet.GetType()}");
                    break;
                }
            }
        }


        
        public bool Register(NetworkEventListener<Ping_RS> EL, Action<Ping_RS> OnRecv, bool bErrorRegistration = false)
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

        public bool Register(NetworkEventListener<GetServerPublicKey_RS> EL, Action<GetServerPublicKey_RS> OnRecv, bool bErrorRegistration = false)
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

        public bool Register(NetworkEventListener<CreateAccount_RS> EL, Action<CreateAccount_RS> OnRecv, bool bErrorRegistration = false)
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

        public bool Register(NetworkEventListener<MatchCompleted_NT> EL, Action<MatchCompleted_NT> OnRecv)
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

        public bool Register(NetworkEventListener<MatchStart_RS> EL, Action<MatchStart_RS> OnRecv, bool bErrorRegistration = false)
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

        public bool Register(NetworkEventListener<MatchStop_RS> EL, Action<MatchStop_RS> OnRecv, bool bErrorRegistration = false)
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

        public bool Register(NetworkEventListener<Login_RS> EL, Action<Login_RS> OnRecv, bool bErrorRegistration = false)
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

        public bool Register(NetworkEventListener<WaitingRoomCharTransSync_NT> EL, Action<WaitingRoomCharTransSync_NT> OnRecv)
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

        public bool Register(NetworkEventListener<WaitingRoomCharacterSpawn_RS> EL, Action<WaitingRoomCharacterSpawn_RS> OnRecv, bool bErrorRegistration = false)
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

        public bool Register(NetworkEventListener<WaitingRoomCharacterSpawn_NT> EL, Action<WaitingRoomCharacterSpawn_NT> OnRecv)
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

        public bool Register(NetworkEventListener<GameRoomObjectInfos_RS> EL, Action<GameRoomObjectInfos_RS> OnRecv, bool bErrorRegistration = false)
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


        
        public bool Unregister(NetworkEventListener<Ping_RS> EL, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;
            
            if(bErrorRegistration == false)
            {
                if(Ping_RS_Registration.ContainsKey(EL) == true)
                {
                    Action<Ping_RS> OnRecv = Ping_RS_Registration[EL];
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
                    Action<Ping_RS> OnRecv = Ping_RS_ErrorRegistration[EL];
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

        public bool Unregister(NetworkEventListener<GetServerPublicKey_RS> EL, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;
            
            if(bErrorRegistration == false)
            {
                if(GetServerPublicKey_RS_Registration.ContainsKey(EL) == true)
                {
                    Action<GetServerPublicKey_RS> OnRecv = GetServerPublicKey_RS_Registration[EL];
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
                    Action<GetServerPublicKey_RS> OnRecv = GetServerPublicKey_RS_ErrorRegistration[EL];
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

        public bool Unregister(NetworkEventListener<CreateAccount_RS> EL, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;
            
            if(bErrorRegistration == false)
            {
                if(CreateAccount_RS_Registration.ContainsKey(EL) == true)
                {
                    Action<CreateAccount_RS> OnRecv = CreateAccount_RS_Registration[EL];
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
                    Action<CreateAccount_RS> OnRecv = CreateAccount_RS_ErrorRegistration[EL];
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
                Action<MatchCompleted_NT> OnRecv = MatchCompleted_NT_Registration[EL];
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

        public bool Unregister(NetworkEventListener<MatchStart_RS> EL, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;
            
            if(bErrorRegistration == false)
            {
                if(MatchStart_RS_Registration.ContainsKey(EL) == true)
                {
                    Action<MatchStart_RS> OnRecv = MatchStart_RS_Registration[EL];
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
                    Action<MatchStart_RS> OnRecv = MatchStart_RS_ErrorRegistration[EL];
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

        public bool Unregister(NetworkEventListener<MatchStop_RS> EL, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;
            
            if(bErrorRegistration == false)
            {
                if(MatchStop_RS_Registration.ContainsKey(EL) == true)
                {
                    Action<MatchStop_RS> OnRecv = MatchStop_RS_Registration[EL];
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
                    Action<MatchStop_RS> OnRecv = MatchStop_RS_ErrorRegistration[EL];
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

        public bool Unregister(NetworkEventListener<Login_RS> EL, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;
            
            if(bErrorRegistration == false)
            {
                if(Login_RS_Registration.ContainsKey(EL) == true)
                {
                    Action<Login_RS> OnRecv = Login_RS_Registration[EL];
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
                    Action<Login_RS> OnRecv = Login_RS_ErrorRegistration[EL];
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

        public bool Unregister(NetworkEventListener<WaitingRoomCharTransSync_NT> EL)
        {
            if (EL == null)
                return false;
            
            if(WaitingRoomCharTransSync_NT_Registration.ContainsKey(EL) == true)
            {
                Action<WaitingRoomCharTransSync_NT> OnRecv = WaitingRoomCharTransSync_NT_Registration[EL];
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

        public bool Unregister(NetworkEventListener<WaitingRoomCharacterSpawn_RS> EL, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;
            
            if(bErrorRegistration == false)
            {
                if(WaitingRoomCharacterSpawn_RS_Registration.ContainsKey(EL) == true)
                {
                    Action<WaitingRoomCharacterSpawn_RS> OnRecv = WaitingRoomCharacterSpawn_RS_Registration[EL];
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
                    Action<WaitingRoomCharacterSpawn_RS> OnRecv = WaitingRoomCharacterSpawn_RS_ErrorRegistration[EL];
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
                Action<WaitingRoomCharacterSpawn_NT> OnRecv = WaitingRoomCharacterSpawn_NT_Registration[EL];
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

        public bool Unregister(NetworkEventListener<GameRoomObjectInfos_RS> EL, bool bErrorRegistration = false)
        {
            if (EL == null)
                return false;
            
            if(bErrorRegistration == false)
            {
                if(GameRoomObjectInfos_RS_Registration.ContainsKey(EL) == true)
                {
                    Action<GameRoomObjectInfos_RS> OnRecv = GameRoomObjectInfos_RS_Registration[EL];
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
                    Action<GameRoomObjectInfos_RS> OnRecv = GameRoomObjectInfos_RS_ErrorRegistration[EL];
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

    }
}
