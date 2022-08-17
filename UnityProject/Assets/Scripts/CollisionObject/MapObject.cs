using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 콜라이더 서버 체크용
/// </summary>

public class MapObject : CollisionObject
{
    protected override void Reset()
    {
        LayerType = SDDefine.ENUM_LAYER_TYPE.Environment;
        tagType = SDDefine.ENUM_TAG_TYPE.Untagged;
    }
}
