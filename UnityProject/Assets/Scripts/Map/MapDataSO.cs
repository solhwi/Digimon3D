using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CustomScriptParser("MapData.asset")]
public class MapDataSO : CustomScriptParser
{
    private MapData mapData;

    public List<MapObjectData> mapDataList =
        new List<MapObjectData>();

    [System.Serializable]
    public class MapDataDictionary : SerializableDictionary<int, MapObjectData> { }
    public MapDataDictionary mapDataDictionary = new MapDataDictionary();

    public override void CustomParser()
    {
        if (mapData == null ||
            mapData.MapObjectList == null)
            return;

        mapDataList.Clear();
        mapDataList = mapData.MapObjectList;

        mapDataDictionary.Clear();
        mapDataList.ForEach(mapObjectData => mapDataDictionary.Add(mapObjectData.objId, mapObjectData));
    }

    public MapObjectData GetMapObjectData(int id)
    {
        MapObjectData data = null;

        if (mapDataDictionary.TryGetValue(id, out data))
        {
            return data;
        }

        return null;
    }
}