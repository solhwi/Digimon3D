using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDDefine;

namespace Solhwi
{
    public class BattleScene : GameSceneBase
    {
        public override void Initialize()
        {
            MapMgr.Instance.LoadMap(ENUM_MAP_TYPE.FileIsland, null, PlayerSpawnProcess);
        }

        protected override IEnumerator Start()
        {
            while(!IsSceneLoaded)
                yield return null;
        }

        public override void Free()
        {

        }

        private void PlayerSpawnProcess(MapPlayerSpawnArea playerSpawnArea)
		{
            Vector3 playerSpawnPos = playerSpawnArea.GetSpawnPos();
            Quaternion playerSpawnRotation = playerSpawnArea.GetSpawnRotation();

            SpawnData data = new SpawnData(ENUM_DIGIMON_TYPE.Agumon, playerSpawnPos, playerSpawnRotation);
            SpawnMgr.Instance.Spawn(data);
		}
    }


}