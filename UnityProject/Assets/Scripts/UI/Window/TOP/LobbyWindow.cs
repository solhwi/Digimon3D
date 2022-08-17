using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Window("TOP/LobbyWindow.prefab")]
public class LobbyWindow : UIWindow
{
    ActiveCharacter activeCharacter = null;

    [SerializeField] private GameObject stopMatchObj = null;

    public override void Open(UIParam param = null)
    {
        base.Open();

        ResourceMgr.Instance.Instantiate<Solider>(PushObj: SetCharacter);
    }

    private void SetCharacter(ActiveCharacter c)
    {
        activeCharacter = c;
        activeCharacter.ReplaceObject(new Vector3(3, -3, 0), new Quaternion(0, 90, 0, 1), new Vector3(3, 3, 3));
    }

    public void SetActiveStopMatchBtnObj(bool isActive)
    {
        stopMatchObj?.SetActive(isActive);
    }

    public void OnClickMatchStart()
    {
        if (activeCharacter == null)
            return;

        SDNetwork.TryMatchStart();
    }

    public void OnClickMatchStop()
    {
        if (activeCharacter == null)
            return;

        SDNetwork.TryMatchStop();
    }

    public void OnClickSetting()
    {
        if (activeCharacter == null)
            return;
    }

    public void OnClickExit()
    {
        if (activeCharacter == null)
            return;

        SceneMgr.Instance.LoadScene(SDDefine.GameScene.Battle);
    }

    public void OnClickLeftBtn()
    {
        if (activeCharacter == null)
            return;

        activeCharacter.Rotate(new CharacterRotateParam(Vector3.up * 90f));
    }

    public void OnClickRightBtn()
    {
        if (activeCharacter == null)
            return;

        activeCharacter.Rotate(new CharacterRotateParam(Vector3.down * 90f));
    }
}
