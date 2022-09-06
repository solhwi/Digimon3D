using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDDefine;

namespace Solhwi
{
    public class BattleScene : GameSceneBase
    {
        protected override void OnEnable()
        {
            MapMgr.Instance.LoadMap(ENUM_MAP_TYPE.FileIsland);
        }

        protected override IEnumerator Start()
        {
            while(!IsSceneLoaded)
                yield return null;
        }

        protected override void OnDisable()
        {
        }
    }


}