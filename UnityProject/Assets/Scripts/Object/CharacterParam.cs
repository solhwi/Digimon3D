using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터의 스테이트를 변경하기 위해 사용하는 파라미터 목록
/// </summary>
/// 

public class CharacterParam { }

public class CharacterMoveParam : CharacterParam
{
    public Vector3 inputVec;
    public bool isRun;
    public float speed;
    
    public CharacterMoveParam(Vector3 inputVec, bool isRun)
    {
        this.inputVec = inputVec;
        this.isRun = isRun;
    }
}

public class CharacterRotateParam : CharacterParam
{
    public Vector3 rotateVec;

    public CharacterRotateParam(Vector3 inputVec)
    {
        this.rotateVec = inputVec;
    }
}

public class CharacterAttackParam : CharacterParam
{
    public Vector3 targetPos;
    public float damage;

    public CharacterAttackParam(Vector3 targetPos, float damage = 10.0f)
    {
        this.targetPos = targetPos;
        this.damage = damage;
    }
}