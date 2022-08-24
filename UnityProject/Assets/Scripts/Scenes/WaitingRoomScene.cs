using SDDefine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingRoomScene : GameSceneBase
{

    protected override void OnEnable()
    {

    }
    protected override IEnumerator Start()
    {
        while (!IsSceneLoaded)
            yield return null;

    }
}
