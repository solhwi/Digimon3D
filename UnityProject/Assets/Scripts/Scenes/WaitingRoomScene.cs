using SDDefine;
using ServerLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingRoomScene : GameSceneBase
{
    public override bool IsSceneLoaded
    {
        get
        {
            return ObjectPoolMgr.Instance.IsLoadDone;
        }
    }

    NetworkEventListener<WaitingRoomCharacterSpawn_NT> characterSpawnPacketListener
        = new NetworkEventListener<WaitingRoomCharacterSpawn_NT>();

    protected override void OnEnable()
    {
        singletonDictionary = new SingletonDictionary()
        {
            { SingletonID.InputMgr, InputMgr.Instance },
            { SingletonID.ObjectPoolMgr, ObjectPoolMgr.Instance},
        };

        Camera.main.gameObject.SetActive(false); // 임시 처리요
    }
    protected override IEnumerator Start()
    {
        while (!IsSceneLoaded)
            yield return null;

        MapLoader.Instance.LoadMap(ENUM_MAP_TYPE.DummyMap, TrySpawnCharacter);

        characterSpawnPacketListener.Bind(OnRecvPacket);
    }

    public void OnRecvPacket(WaitingRoomCharacterSpawn_NT packet)
    {
        if (packet == null)
            return;

        SpawnCharacter(packet.Info);
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        MapLoader.Instance.UnloadMap();
        characterSpawnPacketListener.Unbind();
    }

    private void TrySpawnCharacter()
    {
        SDNetwork.TryToSpawnCharacterOnWaitingRoom();
    }

    private void SpawnCharacter(CharacterSpawnInfo spawnInfo)
    {
        if (spawnInfo == null)
            return;

        int id = spawnInfo.CharacterCid;
        var transformInfo = spawnInfo.CharacterTransform;

        if (transformInfo == null)
            return;

        var serverPos = transformInfo.Position;
        var serverRot = transformInfo.Rotation;

        Vector3 pos = new Vector3(serverPos.X, serverPos.Y, serverPos.Z);
        Vector3 rot = new Vector3(serverRot.X, serverRot.Y, serverRot.Z);

        PlayerCharacter.Instance.Init(id);
        PlayerCharacter.Instance.Spawn(pos, rot);
    }    
}
