using SDDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CharacterController : SingletonBehaviour<CharacterController>
{
    protected Digimon controllerTarget;
    protected CameraController cameraController;

	public void SetDigimon(Digimon targetDigimon)
	{
        controllerTarget = targetDigimon;
        controllerTarget.Tr.SetParent(transform);

        GameObject g = new GameObject("Camera Controller");
        cameraController = g.AddComponent<CameraController>();
        cameraController.Init(transform, targetDigimon.transform);
    }

    protected override void OnInit()
    {
        RegisterCommand();
        StartCommanding();
    }

    protected override void OnClear()
    {
        StopCommanding();
        UnregisterCommand();
    }
}