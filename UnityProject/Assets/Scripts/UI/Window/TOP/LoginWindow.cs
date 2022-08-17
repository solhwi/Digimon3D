using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

[Window("TOP/LoginWindow.prefab")]
public class LoginWindow : UIWindow
{
    public enum InputFieldType
    {
        ID = 0,
        PASSWORD = 1,
    }

    InputFieldType currFocusField = InputFieldType.ID;

    [SerializeField] TMP_InputField[] inputField = new TMP_InputField[(int)InputFieldType.PASSWORD + 1];

    public override void Open(UIParam param = null)
    {
        base.Open();

        inputField[(int)InputFieldType.ID].text = string.Empty;
        inputField[(int)InputFieldType.PASSWORD].text = string.Empty;

        InputMgr.Instance.RegisterKeyboardAction(ENUM_KEYBOARD_INPUT.Tab, OnStarted: OnTab);
    }

    public override void Close()
    {
        InputMgr.Instance.UnregisterKeyboardAction(ENUM_KEYBOARD_INPUT.Tab, OnStarted: OnTab);

        base.Close();
    }

    public void OnClickLogin()
    {
        string nickname = inputField[(int)InputFieldType.ID].text;
        string password = inputField[(int)InputFieldType.PASSWORD].text;

        SDNetwork.TryLogin(nickname, password);
    }

    public void OnClickCreateAccount()
    {
        string nickname = inputField[(int)InputFieldType.ID].text;
        string password = inputField[(int)InputFieldType.PASSWORD].text;

        SDNetwork.TryCreateAccount(nickname, password);
    }

    public void OnClickGoToLobby()
    {
        SceneMgr.Instance.LoadScene(SDDefine.GameScene.Lobby);
    }

    public void OnTab(InputAction.CallbackContext context)
    {
        int nextFocus = ((int)currFocusField + 1) % ((int)InputFieldType.PASSWORD + 1);
        currFocusField = (InputFieldType)nextFocus;

        inputField[(int)currFocusField].Select();
    }
}
