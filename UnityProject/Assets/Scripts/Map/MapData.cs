using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using SDDefine;
using System.Linq;
using UnityEditor;

[Serializable]
public class MapObjectData
{
    public int objId;

    public Vector3 worldPos;

    public ENUM_LAYER_TYPE layerType;
    public ENUM_TAG_TYPE tagType;

    public ENUM_COLLIDER_TYPE colliderType;

    public Bounds bounds;
}

[Serializable]
public class MapData
{
    public List<MapObjectData> MapObjectList = new List<MapObjectData>();
}
