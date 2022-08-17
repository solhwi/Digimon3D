using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDDefine;

namespace Solhwi
{
    public class EnterScene : GameSceneBase
    { 
        public bool IsSceneEnded
        {
            get
            {
                return ScriptTable.Instance.IsLoadDone &&
                        ResourceMgr.Instance.IsLoadDone;
            }
        }

        protected override void OnEnable()
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
            while (!IsSceneEnded)
            {
                yield return null;
            }

            SceneMgr.Instance.LoadScene(GameScene.Login);
        }
    }

   
}
