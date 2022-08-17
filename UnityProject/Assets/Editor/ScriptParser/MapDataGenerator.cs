using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using SDDefine;
using System.Linq;
using UnityEditor;

#if UNITY_EDITOR

public class MapDataGenerator : Editor
{
    /// <summary>
    /// 아오 일단 이게 제일 나은 듯?
    /// </summary>
    private static Dictionary<ENUM_MAP_TYPE, string> mapPathDictionary =
        new Dictionary<ENUM_MAP_TYPE, string>()
        {
            {ENUM_MAP_TYPE.DummyMap, "Assets/Bundles/Scenes/Stage/DummyMap.unity"}
        };

    private static readonly int MapObjectIDOffset = 1000;

    private static bool IsValidType(ENUM_LAYER_TYPE layerType, ENUM_TAG_TYPE tagType)
    {
        return layerType == ENUM_LAYER_TYPE.Environment &&

            tagType == ENUM_TAG_TYPE.Interactable ||
            tagType == ENUM_TAG_TYPE.Spawnable;
    }

    [MenuItem("Build/Map Data Generate")]
    public static void Save()
    {
        foreach(var mapPair in mapPathDictionary)
        {
            var mapKey = mapPair.Key;
            string mapPath = mapPair.Value;

            string mapName = Path.GetFileNameWithoutExtension(mapPath);

            if(EditorApplication.OpenScene(mapPath))
            {
                var objects = ScriptableObject.FindObjectsOfType<CollisionObject>()
                    .Where(obj => IsValidType(obj.LayerType, obj.tagType))
                    .ToArray();

                MapData mapData = new MapData();
                mapData.MapObjectList.Clear();

                for (int i = 0; i < objects.Length; i++)
                {
                    var colObj = objects[i];
                    colObj.objGuid = i + MapObjectIDOffset; // 충돌체에게 식별 가능한 고유 ID 지정

                    EditorUtility.SetDirty(colObj);

                    var mapObjData = new MapObjectData()
                    {
                        objId = i + MapObjectIDOffset,
                        worldPos = colObj.transform.position,
                        layerType = colObj.LayerType,
                        tagType = colObj.tagType,
                        colliderType = colObj.colliderType,
                        bounds = colObj.GetCollider().bounds
                    };

                    mapData.MapObjectList.Add(mapObjData); 
                }

                string filePath = $"MapDatas/{mapName}.json";

                JsonParserHelper.WriteJson(filePath, mapData);
                JsonParserHelper.GenerateCustomScriptParser<MapData, MapDataSO>(mapData);
               
            }
        }
    }

}


#endif
