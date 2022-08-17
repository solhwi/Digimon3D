using SDDefine;
using ServerLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapLoader : Singleton<MapLoader>
{
    private MapRootObject rootObj = null;
    private Action OnLoadedMap = null;

    private MapDataSO currentMapData = null;
    private ItemSequenceTable spawnItemSequenceTable = null;
    private ItemTable itemTable = null;

    public bool MapLoadDone
    {
        get;
        private set;
    } = false;
    

    public void LoadMap(ENUM_MAP_TYPE mapType, Action OnLoadMap = null)
    {
        MapLoadDone = false;

        OnLoadedMap += OnLoadMap;
        OnLoadedMap += () =>
        {
            MapLoadDone = true;

            currentMapData = ScriptTable.Instance.GetCustomTable<MapDataSO>();
            spawnItemSequenceTable = ScriptTable.Instance.GetTable<ItemSequenceTable>();
            itemTable = ScriptTable.Instance.GetTable<ItemTable>();

            var itemInfos = itemTable.GetItemInfos();
            
            foreach(var itemInfo in itemInfos)
            {
                int itemDdid = itemInfo.key;

                var itemSubType = itemInfo.itemSubType;
                var weaponType = ReflectionUtil.ConvertToEnum<ENUM_EQUIPMENT_WEAPON>(itemSubType);
                // 여기서 문제가 발생할 수 있으나 우선 돌아가도록 작성

                var itemMapPair = spawnItemSequenceTable.GetItemInfo(itemDdid);
                if (itemMapPair == null)
                    continue;

                int objId = itemMapPair.objId;

                var mapObjectData = currentMapData.GetMapObjectData(objId);
                if (mapObjectData == null)
                    continue;

                var go = ObjectPoolMgr.Instance.GetPoolComponent(weaponType, mapObjectData.worldPos, true);
            }
        };

        ResourceMgr.Instance.LoadByAttribute<MapPathTable>(PushObj:
            (table) =>
            {
                if (table == null)
                    return;

                string mapPath = table.GetMapPath((int)mapType);

                rootObj = MonoBehaviour.FindObjectOfType<MapRootObject>();
                if (rootObj == null)
                {
                    var g = new GameObject("Map Root Object");
                    rootObj = g.AddComponent<MapRootObject>();
                }

                ResourceMgr.Instance.LoadMap(mapPath, OnLoadedMap);
            });
    }

    public void UnloadMap()
    {
        if (!MapLoadDone)
            return;

        if (rootObj != null)
            MonoBehaviour.Destroy(rootObj.gameObject);

        MapLoadDone = false;
    }
}
