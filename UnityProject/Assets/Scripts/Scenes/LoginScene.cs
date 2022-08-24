using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScene : GameSceneBase
{
    protected override void OnEnable()
    {
        Camera.main.gameObject.SetActive(false); // 임시 처리요
    }

    protected override IEnumerator Start()
    {
        yield return null;
    }

    protected override void OnDisable()
    {

    }
}
