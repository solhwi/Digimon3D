using SDDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CharacterController : SingletonBehaviour<CharacterController>
{
    protected Character character;
    protected CameraController camController;

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