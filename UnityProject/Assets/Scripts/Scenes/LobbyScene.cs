using SDDefine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : GameSceneBase
{
    protected override void OnEnable()
    {
        UIMgr.Instance.OpenUI<LobbyWindow>();
    }

    protected override IEnumerator Start()
    {
        yield return null;
    }

    protected override void OnDisable()
    {
       UIMgr.Instance.CloseUI<LobbyWindow>();
    }
}
