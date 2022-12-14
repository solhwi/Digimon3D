using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDDefine;

namespace Solhwi
{
    public class EnterScene : GameSceneBase
    { 
        public override bool IsSceneLoaded
        {
            get
            {
                return ScriptTable.Instance.IsLoadDone &&
                        ResourceMgr.Instance.IsLoadDone;
            }
        }

        public override void Initialize()
        {
            singletonDictionary = new SingletonDictionary()
            {
                { SingletonID.ResourceMgr, ResourceMgr.Instance},
                { SingletonID.ScriptTable, ScriptTable.Instance},
                { SingletonID.InputMgr, InputMgr.Instance }
            };
        }

        protected override IEnumerator Start()
        {
            while (!IsSceneLoaded)
            {
                yield return null;
            }

            SceneMgr.Instance.LoadScene(GameScene.Battle);
        }
    }
}
