using SDDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerCharacter : PlayerInputAction.IKeyBoardActions, PlayerInputAction.IMouseActions
{
    protected Queue<Action> playerCommandQueue = new Queue<Action>();
    protected IMicroCoroutine commandingCoroutine = null;

    private void ExecuteCommand()
    {
        if (playerCommandQueue.Count > 0)
        {
            playerCommandQueue.Dequeue()();
        }
        else // 다른 명령어가 없는 경우로만 제한
        {
            if (dirVec == Vector3.zero)
            {
                if (activeCharacter.CurrState != CharacterState.Idle)
                    PlayerCommand(CharacterState.Idle);
            }
            else
            {
                PlayerCommand(CharacterState.Move, new CharacterMoveParam(dirVec, isShift));
            }
        }
    }

    private void PlayerCommand(CharacterState nextState, CharacterParam param = null)
    {
        if (activeCharacter == null)
            return;

        switch (nextState)
        {
            case CharacterState.Idle:
                playerCommandQueue.Enqueue(() =>
                {
                    activeCharacter.Idle();
                });
                break;
            case CharacterState.Move:
                playerCommandQueue.Enqueue(() =>
                {
                    activeCharacter.Move(param);
                });
                break;

            case CharacterState.Reload:
                playerCommandQueue.Enqueue(() =>
                {
                    activeCharacter.Reload();
                });
                break;

            case CharacterState.Attack:
                playerCommandQueue.Enqueue(() =>
                {
                    activeCharacter.Attack(param);
                });
                break;

            case CharacterState.Interact:
                playerCommandQueue.Enqueue(() =>
                {
                    activeCharacter.Interact(param);
                });
                break;
        }
    }

    protected void StartCommanding()
    {
        if (commandingCoroutine != null)
            this.StopCoroutine(commandingCoroutine);

        commandingCoroutine = this.StartUpdateCoroutine(Commanding());
    }

    protected void StopCommanding()
    {
        if (commandingCoroutine != null)
            this.StopCoroutine(commandingCoroutine);
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


    public void OnMoveSet(InputAction.CallbackContext context)
    {
        if (!IsPlayerCharacterLoaded)
            return;

        Vector2 vec = InputMgr.MoveSetVector2D;
        dirVec = new Vector3(vec.x, 0, vec.y);
    }

    public void OnShift(InputAction.CallbackContext context)
    {
        if (!IsPlayerCharacterLoaded)
            return;

        if (context.performed)
        {
            isShift = true;
        }
        else if (context.canceled)
        {
            isShift = false;
        }
    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (!IsPlayerCharacterLoaded)
            return;
    }

    public void OnR(InputAction.CallbackContext context)
    {
        if (!IsPlayerCharacterLoaded)
            return;

        if (!context.started)
            return;

        PlayerCommand(CharacterState.Reload);
    }

    public void OnG(InputAction.CallbackContext context)
    {
        if (!IsPlayerCharacterLoaded)
            return;

        if (!context.started)
            return;

        var window = UIMgr.Instance.GetUI<InteractionUI>();
        bool bInteractionUIOpen = window != null && window.IsOpen;

        if (bInteractionUIOpen && targetObject is InteractableObject)
        {
            PlayerCommand(CharacterState.Interact, new CharacterInteractParam(targetObject as InteractableObject));
        }
    }

    public void OnMouseLeft(InputAction.CallbackContext context)
    {
        if (!IsPlayerCharacterLoaded)
            return;

        PlayerCommand(CharacterState.Attack, new CharacterAttackParam(playerCamera.CamRayVec));
    }

    public void OnMouseMiddle(InputAction.CallbackContext context)
    {
        if (!IsPlayerCharacterLoaded)
            return;
    }

    public void OnMouseRight(InputAction.CallbackContext context)
    {
        if (!IsPlayerCharacterLoaded)
            return;

        if (context.performed)
        {
            characterRotateLock = true;
        }
        else if (context.canceled)
        {
            characterRotateLock = false;
            this.StartUpdateCoroutine(ComebackRotate());
        }
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        if (!IsPlayerCharacterLoaded)
            return;

        SearchForward(InputMgr.MouseScreenPos);
    }

    public void OnMouseDelta(InputAction.CallbackContext context)
    {
        if (!IsPlayerCharacterLoaded)
            return;

        LookAt(InputMgr.MouseScreenDelta);
    }

    public void OnTab(InputAction.CallbackContext context)
    {

    }
}
