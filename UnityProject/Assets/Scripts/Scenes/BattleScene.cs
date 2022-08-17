using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDDefine;

namespace Solhwi
{
    public class BattleScene : GameSceneBase
    {
        public override bool IsSceneLoaded
        {
            get
            {
                return ObjectPoolMgr.Instance.IsLoadDone;
            }
        }

        protected override void OnEnable()
        {
            singletonDictionary = new SingletonDictionary()
            {
                { SingletonID.ObjectPoolMgr, ObjectPoolMgr.Instance},
            };

            Camera.main.gameObject.SetActive(false); // 임시 처리요
        }

        protected override IEnumerator Start()
        {
            while(!IsSceneLoaded)
                yield return null;

            MapLoader.Instance.LoadMap(ENUM_MAP_TYPE.DummyMap);

            PlayerCharacter.Instance.Spawn();
        }

        protected override void OnDisable()
        {
            MapLoader.Instance.UnloadMap();
        }
    }


}