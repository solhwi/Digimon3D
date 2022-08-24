using SDDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public enum ENUM_KEYBOARD_INPUT
{
    Q,
    W,
    E,
    R,
    Tab,
    MAX
}

public enum ENUM_MOUSE_INPUT
{
    MouseLeft,
    MouseMiddle,
    MouseRight,
    MousePosition,
    MouseDelta,

    MAX
}

public sealed class InputMgr : Singleton<InputMgr>
{
    private bool isLoadDone = false;
    public override bool IsLoadDone
    {
        get
        {
            return isLoadDone;
        }
    }

    public enum InputType
    {
        Keyboard = 0,
        Mouse = 1,

        MAX
    }
    private PlayerInputAction playerInputActions;

    public InputActionMap KeyboardMap
	{
        get { return playerInputActions.KeyBoard; }
	}

    public InputActionMap MouseMap
	{
		get { return playerInputActions.Mouse; }
	}

    public InputActionAsset Asset
    {
        get
        {
            if (playerInputActions == null)
                playerInputActions = new PlayerInputAction();

            return playerInputActions.asset;
        }
    }

    public static Vector2 MouseScreenPos
    {
        get
        {
            float x = Mouse.current.position.x.ReadValue();
            float y = Mouse.current.position.y.ReadValue();

            return new Vector2(x, y);
        }
    }

    public static Vector2 MouseScreenDelta
    {
        get
        {
            float x = Mouse.current.delta.x.ReadValue();
            float y = Mouse.current.delta.y.ReadValue();

            return new Vector2(x, y);
        }
    }

    protected override void OnInit() 
    {
        base.OnInit();

        if(playerInputActions == null)
            playerInputActions = new PlayerInputAction();

        playerInputActions.Enable();

        isLoadDone = true;
    }

	protected override void OnClear()
	{
		base.OnClear();

        playerInputActions.Disable();
        isLoadDone = false;
    }


    public void RegisterKeyboardAction(ENUM_KEYBOARD_INPUT keyboardType, Action<InputAction.CallbackContext> OnStarted = null, Action<InputAction.CallbackContext> OnPerformed = null, Action<InputAction.CallbackContext> OnCanceled = null)
    {
        if (keyboardType == ENUM_KEYBOARD_INPUT.MAX)
            return;

        string actionKey = keyboardType.ToString();
        var action = KeyboardMap.FindAction(actionKey);

        if (OnStarted != null)
            action.started += OnStarted;

        if (OnPerformed != null)
            action.performed += OnPerformed;

        if (OnCanceled != null)
            action.canceled += OnCanceled;

        if(!action.enabled)
            action.Enable();
    }

    public void UnregisterKeyboardAction(ENUM_KEYBOARD_INPUT keyboardType, Action<InputAction.CallbackContext> OnStarted = null, Action<InputAction.CallbackContext> OnPerformed = null, Action<InputAction.CallbackContext> OnCanceled = null)
    {
        if (keyboardType == ENUM_KEYBOARD_INPUT.MAX)
            return;

        string actionKey = keyboardType.ToString();
        var action = KeyboardMap.FindAction(actionKey);

        if (OnStarted != null)
            action.started -= OnStarted;

        if (OnPerformed != null)
            action.performed -= OnPerformed;

        if (OnCanceled != null)
            action.canceled -= OnCanceled;
    }

    public void RegisterKeyboardAction(PlayerInputAction.IKeyBoardActions owner)
    {
        playerInputActions.KeyBoard.SetCallbacks(owner);
    }
    public void UnregisterKeyboardAction(PlayerInputAction.IKeyBoardActions owner)
    {

    }

    public void RegisterMouseAction(PlayerInputAction.IMouseActions owner)
    {
        playerInputActions.Mouse.SetCallbacks(owner);
    }

    public void UnregisterMouseAction(PlayerInputAction.IMouseActions owner)
    {

    }
}
