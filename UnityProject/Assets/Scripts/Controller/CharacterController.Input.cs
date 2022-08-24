using SDDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class CharacterController : PlayerInputAction.IKeyBoardActions, PlayerInputAction.IMouseActions
{
    protected Queue<Action> playerCommandQueue = new Queue<Action>();
    protected Coroutine commandingCoroutine = null;

    private void ExecuteCommand()
    {
        if (playerCommandQueue.Count > 0)
        {
            playerCommandQueue.Dequeue()();
        }
        else
        {
            if (character.CurrState != CharacterState.Idle)
                PlayerCommand(CharacterState.Idle);
        }
    }

    private void PlayerCommand(CharacterState nextState, CharacterParam param = null)
    {
        if (character == null)
            return;

        switch (nextState)
        {
            case CharacterState.Idle:
                playerCommandQueue.Enqueue(() =>
                {
                    character.Idle();
                });
                break;
            case CharacterState.Move:
                playerCommandQueue.Enqueue(() =>
                {
                    character.Move(param);
                });
                break;

            case CharacterState.Attack:
                playerCommandQueue.Enqueue(() =>
                {
                    character.Attack(param);
                });
                break;
        }
    }

    protected void StartCommanding()
    {
        if (commandingCoroutine != null)
            StopCoroutine(commandingCoroutine);

        commandingCoroutine = StartCoroutine(Commanding());
    }

    protected void StopCommanding()
    {
        if (commandingCoroutine != null)
            StopCoroutine(commandingCoroutine);
    }

    protected IEnumerator Commanding()
    {
        while (playerCommandQueue != null)
        {
            yield return null;

            ExecuteCommand();
        }
    }

    public void RegisterCommand()
    {
        InputMgr.Instance.RegisterKeyboardAction(this);
        InputMgr.Instance.RegisterMouseAction(this);
    }

    public void UnregisterCommand()
    {
        InputMgr.Instance.UnregisterKeyboardAction(this);
        InputMgr.Instance.UnregisterMouseAction(this);
    }

	public void OnQ(InputAction.CallbackContext context)
	{
	}

	public void OnW(InputAction.CallbackContext context)
	{
	}

	public void OnE(InputAction.CallbackContext context)
	{
	}

	public void OnR(InputAction.CallbackContext context)
	{
	}

	public void OnTab(InputAction.CallbackContext context)
	{
	}

	public void OnMouseLeft(InputAction.CallbackContext context)
	{
	}

	public void OnMouseMiddle(InputAction.CallbackContext context)
	{
	}

	public void OnMouseRight(InputAction.CallbackContext context)
	{
	}

	public void OnMousePosition(InputAction.CallbackContext context)
	{
	}

	public void OnMouseDelta(InputAction.CallbackContext context)
	{
	}
}
