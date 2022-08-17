using ServerLib;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 유니티 싱글 스레드에서 작동하는 패킷 핸들러
/// </summary>

public class SDUnityPacketHandler : SDUnityPacketHandlerGenerated
{
    protected override void OnRecvCreateAccount_RS(CreateAccount_RS Packet)
    {
        DebugUtil.Log("회원가입 성공");
    }

    protected override void OnRecvGameRoomObjectInfos_RS(GameRoomObjectInfos_RS Packet)
    {
    }

    protected override void OnRecvGetServerPublicKey_RS(GetServerPublicKey_RS Packet)
    {
    }

    protected override void OnRecvLogin_RS(Login_RS Packet)
    {
        SceneMgr.Instance.LoadScene(SDDefine.GameScene.Lobby, OnSceneLoaded: () =>
        {
            DebugUtil.Log("OnRecvLogin_RS, 로그인에 성공하여 로비로 이동합니다.");
        });
    }

    protected override void OnRecvMatchCompleted_NT(MatchCompleted_NT Packet)
    {
        SceneMgr.Instance.LoadScene(SDDefine.GameScene.WaitingRoom, OnSceneLoaded: () =>
        {
            DebugUtil.Log("OnRecvMatchCompleted_NT, 매칭할 상대를 발견하여 대기실로 이동함!");
            DebugUtil.Log("-- 아래 간략한 대기실 내 플레이어의 정보 --");
            DebugUtil.Log(Packet.Info.MyPlayerId);
            DebugUtil.Log(Packet.Info.RoomPlayers);
            DebugUtil.Log("-- --- --");
        });
    }

    protected override void OnRecvMatchStart_RS(MatchStart_RS Packet)
    {
        DebugUtil.Log("OnRecvMatchStart_RS, 매칭 스타트!");
    }

    protected override void OnRecvMatchStop_RS(MatchStop_RS Packet)
    {
        DebugUtil.Log("OnRecvMatchStop_RS, 매칭 정지!");
    }

    protected override void OnRecvPing_RS(Ping_RS Packet)
    {
    }

    protected override void OnRecvWaitingRoomCharacterSpawn_NT(WaitingRoomCharacterSpawn_NT Packet)
    {
        DebugUtil.Log("OnRecvWaitingRoomCharacterSpawn_NT, 자신이 스폰되었음");
        DebugUtil.Log("-- 아래 스폰된 자신의 플레이어 정보 --");
        DebugUtil.Log(Packet.Info.CharacterCid);
        DebugUtil.Log(Packet.Info.CharacterTransform);
        DebugUtil.Log("-- --- --");
    }

    protected override void OnRecvWaitingRoomCharacterSpawn_RS(WaitingRoomCharacterSpawn_RS Packet)
    {
    }

    protected override void OnRecvWaitingRoomCharTransSync_NT(WaitingRoomCharTransSync_NT Packet)
    {
        
    }
}
