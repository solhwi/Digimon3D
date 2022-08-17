using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using static ServerLib.AdamBitConverterGenerated;

namespace ServerLib
{
    public abstract class AdamSession
    {
        Socket Sock;
        AdamRecvBuffer RecvBuffer = new AdamRecvBuffer(ServerConstData.RecvBufferSize);
        AdamSendBuffer SendBuffer = new AdamSendBuffer(ServerConstData.SendBufferSize);
        Queue<IPacket> SendQueue = new Queue<IPacket>();
        object SendLock = new object();
        int Disconnected = 0;

        public RSAManager MyRSAManager = new RSAManager();

        public Action<PacketHeader, IPacket> OnRecvEvent;
        protected virtual void OnRecv(PacketHeader Header, IPacket Packet) { OnRecvEvent?.Invoke(Header, Packet); }
        public Action<PacketHeader, IPacket> OnPreSendEvent;
        protected virtual void OnPreSend(PacketHeader Header, IPacket Packet) { OnPreSendEvent?.Invoke(Header, Packet); }
        public Action<int> OnSendEvent;
        protected virtual void OnSend(int SendSize) { OnSendEvent?.Invoke(SendSize); }
        public Action OnConnectEvent;
        public virtual void OnConnect(EndPoint EndPoint) { OnConnectEvent?.Invoke(); }
        public Action OnDisconnectEvent;
        protected virtual void OnDisconnect() { OnDisconnectEvent?.Invoke(); }

        public virtual void Start(Socket InSock)
        {
            Sock = InSock;

            MyRSAManager.Init();

            JobTimer SendTimer = new JobTimer(SendTimerExecute, 500);

            BeginRecv();
        }

        public virtual void Disconnect()
        {
            // 이미 disconnect됐음
            if (Interlocked.Exchange(ref Disconnected, 1) == 1)
                return;

            OnDisconnect();

            try
            {
                if (Sock != null)
                {
                    Sock.Shutdown(SocketShutdown.Both);
                    Sock.Close();
                }
            }
            catch (ObjectDisposedException)
            {
                AdamLogger.Log(LogLevel.Warning, $"This Socket is already disposed but you tried to disconnect with it.");
            }
            catch (Exception Ex)
            {
                AdamLogger.Log(LogLevel.Error, $"Socket Disconnect Exception: {Ex.ToString()}");
            }
        }

        public virtual void Send(IPacket Packet)
        {
            lock (SendLock)
            {
                SendQueue.Enqueue(Packet);
            }

        }

        private void SendTimerExecute()
        {
            lock (SendLock)
            {
                if(SendQueue.Count > 0)
                {
                    BeginSend(SendQueue.ToList());
                    SendQueue.Clear();
                }
            }
        }

        private void BeginSend(List<IPacket> PacketsToSend)
        {
            try
            {
                int PacketSizeSum = 0;
                List<byte[]> Buffs = new List<byte[]>();
                foreach(IPacket Packet in PacketsToSend)
                {
                    AdamLogger.Log(LogLevel.Temp, $"[Send::{Packet.GetType().Name}] {Packet.ToJson()}");

                    PacketHeader Header = new PacketHeader(Packet);
                    byte[] PacketHeaderBuff = AdamBitConverterGenerated.Serialize(Header);
                    byte[] PacketBodyBuff = AdamBitConverterGenerated.Serialize(Packet);
                    Buffs.Add(PacketHeaderBuff);
                    Buffs.Add(PacketBodyBuff);
                    PacketSizeSum += PacketHeaderBuff.Length;
                    PacketSizeSum += PacketBodyBuff.Length;

                    OnPreSend(Header, Packet);
                }

                ArraySegment<byte> SendBufferOpen = SendBufferHelper.Open(PacketSizeSum);
                int cursor = 0;
                foreach (byte[] Buff in Buffs)
                {
                    Array.Copy(Buff, 0, SendBufferOpen.Array, SendBufferOpen.Offset + cursor, Buff.Length);
                    cursor += Buff.Length;
                }
                SendBufferHelper.Close(PacketSizeSum);

                SocketError SockError;
                Sock.BeginSend(SendBufferOpen.Array, SendBufferOpen.Offset, SendBufferOpen.Count, SocketFlags.None, out SockError, new AsyncCallback(SendCallback), null);

                if (SockError != SocketError.Success)
                    throw new Exception($"BeginSend Error: {SockError.ToString()}");
            }
            catch(Exception e)
            {
                AdamLogger.Log(LogLevel.Error, $"{e.Message}");
                Disconnect();
            }

        }

        private void SendCallback(IAsyncResult Ar)
        {
            try
            {
                int SendSize = Sock.EndSend(Ar);

                if (SendSize == 0)
                    throw new Exception($"Send Size is Zero");

                OnSend(SendSize);
            }
            catch (Exception e)
            {
                AdamLogger.Log(LogLevel.Error, $"{e.Message}");
                Disconnect();
            }
        }

        private void BeginRecv()
        {
            try 
            {
                RecvBuffer.Clean();
                SocketError SockError;
                ArraySegment<byte> WriteSegment = RecvBuffer.WriteSegment;
                if (WriteSegment.Array == null)
                    throw new Exception("WriteSegment of Recv Buffer is Null");

                Sock.BeginReceive(WriteSegment.Array, WriteSegment.Offset, WriteSegment.Count, SocketFlags.None, out SockError, new AsyncCallback(RecvCallback), null);
            }
            catch (SocketException se)
            {
                AdamLogger.Log(LogLevel.Error, $"{se.Message}");
            }
            catch (Exception e)
            {
                AdamLogger.Log(LogLevel.Error, $"{e.Message}");
                Disconnect();
            }
        }

        private void RecvCallback(IAsyncResult ar)
        {
            try
            {
                int ReceivedSize = Sock.EndReceive(ar);

                if (ReceivedSize == 0)
                {
                    Disconnect();
                    return;
                }

                if (ReceivedSize <= 0)
                    throw new Exception("Recved Size is Zero");

                if(!RecvBuffer.OnWrite(ReceivedSize))
                    throw new Exception("Recv Buffer OnWrite Failed");

                while (ReceivedSize > 0)
                {
                    ArraySegment<byte> ReadSegment = RecvBuffer.ReadSegment;

                    int DesereializeSize = 0;
                    // Header Deserialize
                    EDeserializeResult HeaderResult = AdamBitConverterGenerated.Deserialize(ReadSegment, out PacketHeader Header);
                    if (HeaderResult != EDeserializeResult.Success) 
                    {
                        BeginRecv();
                        return;
                    }

                    DesereializeSize += AdamBitConverterGenerated.SizeOf(Header);
                    ReadSegment = new ArraySegment<byte>(
                        ReadSegment.Array,
                        ReadSegment.Offset + AdamBitConverterGenerated.SizeOf(Header), 
                        ReadSegment.Count - AdamBitConverterGenerated.SizeOf(Header)); 

                    // Packet Body Deserialize
                    EDeserializeResult PacketBodyResult = AdamBitConverterGenerated.Deserialize(ReadSegment, Header, out IPacket PacketBody);
                    if (PacketBodyResult != EDeserializeResult.Success)
                    {
                        BeginRecv();
                        return;
                    }

                    DesereializeSize += AdamBitConverterGenerated.SizeOf(PacketBody);

                    if (!RecvBuffer.OnRead(DesereializeSize))
                        throw new Exception("Recv Buffer OnRead Failed");

                    AdamLogger.Log(LogLevel.Temp, $"[Recv::{PacketBody.GetType().Name}] {PacketBody.ToJson()}");
                    OnRecv(Header, PacketBody);

                    ReceivedSize -= DesereializeSize;

                    if (ReceivedSize < 0)
                    {
                        AdamLogger.Log(LogLevel.Error, "Deserialize Error : receivedSize < 0");
                    }
                }

                BeginRecv();
            }
            catch (SocketException se)
            {
                AdamLogger.Log(LogLevel.Error, $"{se.Message}");
                Disconnect();
            }
            catch (Exception e)
            {
                AdamLogger.Log(LogLevel.Error, $"{e.Message}");
                Disconnect();
            }
        }
    }
}
