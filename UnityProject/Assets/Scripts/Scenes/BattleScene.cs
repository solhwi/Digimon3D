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
            Camera.main.gameObject.SetActive(false); // 임시 처리요
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