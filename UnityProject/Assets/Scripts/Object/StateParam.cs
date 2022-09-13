using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터의 스테이트를 변경하기 위해 사용하는 파라미터 목록
/// </summary>
/// 

public class StateParam { }

public class MoveParam : StateParam
{
	public Vector3 targetPos = default;

	public MoveParam(Vector3 targetPos)
	{
		this.targetPos = targetPos;
	}
}

public class RotateParam : StateParam
{

}

public class AttackParam : StateParam
{

}