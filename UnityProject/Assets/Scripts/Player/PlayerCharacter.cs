using SDDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerCharacter : SingletonBehaviour<PlayerCharacter>
{
    protected ActiveCharacter activeCharacter;
    protected PlayerCamera playerCamera;

    protected int playerId = -1;

    protected CollisionObject targetObject;

    protected bool IsPlayerCharacterLoaded = false;

    protected Vector3 dirVec = Vector3.zero;
    protected bool isShift = false;

    protected bool characterRotateLock = false;
    private bool cameraRotateLock = false;

    protected override void OnInit()
    {
        Init(0);
        RegisterCommand();
    }

    protected override void OnClear()
    {
        StopCommanding();
        StopReport();
        UnregisterCommand();
    }

    public void Init(int id)
    {
        playerId = id;
    }

	public void Spawn(Vector3 pos = new Vector3(), Vector3 rot = new Vector3())
    {
        Spawn(pos, new Quaternion(rot.x, rot.y, rot.z, 1), new Vector3(1, 1, 1));
    }

    public void Spawn(Vector3 pos, Quaternion rot, Vector3 scal)
    {
        LoadCharacterAndCamera(pos, rot, scal,
            () =>
            {
                // RegisterReport();
                // StartReport();

                StartCommanding();

                IsPlayerCharacterLoaded = true;
            });
    }

    private void LoadCharacterAndCamera(Vector3 pos, Quaternion rot, Vector3 scal, Action OnLoadCharacter)
    {
        ResourceMgr.Instance.Instantiate<Solider>(OnLoadCharacter,
            (character) =>
            {
                activeCharacter = character;
                activeCharacter.Init();

                activeCharacter.transform.SetParent(transform);
                activeCharacter.ReplaceObject(pos, rot, scal);

                GameObject g = new GameObject("Player Camera");
                playerCamera = g.AddComponent<PlayerCamera>();
                playerCamera.Init(transform, activeCharacter.transform);
            });
    }

    private IEnumerator ComebackRotate()
    {
        cameraRotateLock = true;

        var charRotation = activeCharacter.Rotation;
        float angle = Quaternion.Angle(charRotation, playerCamera.CamArmRotation);

        while (angle > 0f)
        {
            yield return null;
            playerCamera.CamArmRotation = Quaternion.Lerp(playerCamera.CamArmRotation, charRotation, Time.deltaTime * 20.0f);

            angle = Quaternion.Angle(charRotation, playerCamera.CamArmRotation);
        }

        cameraRotateLock = false;
    }

    
    private void SearchForward(Vector2 mousePos)
    {
        var currObj = playerCamera.GetForwardObjectWithRay(mousePos);
        var currInteractableObj = currObj as InteractableObject;

        if (currInteractableObj != null)
        {
            currInteractableObj.SetInteractable();
        }
        else
        {
            var _prevInteractableObj = targetObject as InteractableObject;
            _prevInteractableObj?.UnsetInteractable();
        }

        targetObject = currObj;
    }

    private void LookAt(Vector2 MouseDelta)
    {
        Vector3 camAngle = playerCamera.ArmAngle;

        float x = camAngle.x - MouseDelta.y;
        float y = camAngle.y + MouseDelta.x;

        if (x < 180f) // 상, 하 각도 제한
            x = Mathf.Clamp(x, 0.0f, 25.0f);
        else
            x = Mathf.Clamp(x, 335.0f, 360.0f);

        if (!characterRotateLock)
            activeCharacter.Look(new CharacterRotateParam(new Vector3(0, y, 0)));
        
        if(!cameraRotateLock)
            playerCamera.ArmAngle = new Vector3(x, y, camAngle.z);
    }


}