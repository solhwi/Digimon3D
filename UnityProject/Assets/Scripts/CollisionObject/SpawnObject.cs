using SDDefine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : CollisionObject
{
    protected override void Reset()
    {
        LayerType = ENUM_LAYER_TYPE.Environment;
        tagType = ENUM_TAG_TYPE.Spawnable;
    }
}
