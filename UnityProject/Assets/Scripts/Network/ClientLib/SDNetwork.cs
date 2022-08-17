using System.Collections.Generic;
using UnityEngine;
using ServerLib;
using System;
using System.Collections;

/// <summary>
/// 핸들러에게 이벤트 리스너를 등록할 수 있도록 함
/// 세션에게 패킷을 등록할 수 있도록 함
/// </summary>
/// 

public class SDNetwork : SingletonBehaviour<SDNetwork>
{
    private SDSession session = null;
    private SDConnector connector = null;

    private SDUnityPacketHandler handler = null;

    public static SDUnityPacketHandler Handler
    {
        get
        {
            return Instance.handler;
        }
    }

    public static bool IsValid
    {
        get
        {
            return Instance.session.isConnected;
        }
    }

    private IMicroCoroutine packetCoroutine = null;

    protected void Awake()
    {
        Connect();
    }

    protected void Start()
    {
        StartRunningPacket();
    }

    protected override void OnClear()
    {
        Disconnect();
    }

    public void Connect()
    {
        session = new SDSession();
        connector = new SDConnector();

        connector.Connect(OnConnect);
    }

    /// <summary>
    /// 서브 스레드에서 수행되므로 주의할 것!!!
    /// </summary>
    /// <returns></returns>

    private AdamSession OnConnect()
    {
        session.isConnected = true;

        handler = new SDUnityPacketHandler();
        handler.Init(session);

        return session;
    }

    public void Disconnect()
    {
        StopRunningPacket();
    }

    private void StartRunningPacket()
    {
        if (packetCoroutine != null)
            this.StopCoroutine(packetCoroutine);

        packetCoroutine = this.StartUpdateCoroutine(RunningPacket());
    }

    private void StopRunningPacket()
    {
        if (packetCoroutine != null)
            this.StopCoroutine(packetCoroutine);
    }

    private IEnumerator RunningPacket()
    {
        while(true)
        {
            yield return null;

            if(IsValid)
            {
                handler?.Run();
            }
        }
    }

    public static void TryLogin(string nickname, string password)
    {
        Login_RQ request = new Login_RQ()
        {
            Nickname = nickname,
            Password = password,
        };

        Instance.session.Send(request);
    }

    public static void TryCreateAccount(string nickname, string password)
    {
        CreateAccount_RQ request = new CreateAccount_RQ()
        { 
            Nickname = nickname,
            Password = password,
        };

        Instance.session.Send(request);
    }

    public static void TryMatchStart()
    {
        MatchStart_RQ request = new MatchStart_RQ()
        {
            RoomPlayerNum = 2
        };

        Instance.session.Send(request);
    }

    public static void TryMatchStop()
    {
        MatchStop_RQ request = new MatchStop_RQ();

        Instance.session.Send(request);
    }

    public static void TryToSpawnCharacterOnWaitingRoom()
    {
        WaitingRoomCharacterSpawn_RQ request = new WaitingRoomCharacterSpawn_RQ();

        Instance.session.Send(request);
    }

    public static void ReportCharacterTransform(Vector3 pos, Vector3 rot)
    {
        WaitingRoomCharTransSync_RP report = new WaitingRoomCharTransSync_RP()
        {
            Position = new SDVector3D()
            {
                X = pos.x,
                Y = pos.y,
                Z = pos.z
            },

            Rotation = new SDRotation3D()
            {
                X = rot.x,
                Y = rot.y,
                Z = rot.z
            },
        };
        
        Instance.session.Send(report);
    }
}
