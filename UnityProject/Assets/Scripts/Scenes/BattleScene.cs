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
            MapMgr.Instance.LoadMap(ENUM_MAP_TYPE.FileIsland, null, SpawnProcess);
        }

        protected override IEnumerator Start()
        {
            while(!IsSceneLoaded)
                yield return null;
        }

        public override void Free()
        {

        }

        private void SpawnProcess(Vector3 pos, Quaternion rot)
		{
            SpawnData data = new SpawnData(ENUM_DIGIMON_TYPE.Agumon, pos, rot);
            SpawnMgr.Instance.Spawn(data);
		}
    }


}