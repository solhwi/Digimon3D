using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;


public abstract class BaseData<DataType, KeyType>
{
    public abstract void Clear();
    public abstract DataType Get(KeyType Key);
}


public abstract class UnityBaseData<DataType, KeyType> : ScriptableObject
{
    public abstract DataType Get(KeyType Key);
    public abstract void Clear();
}

// Example
public class UnityMapDataWrapper : UnityBaseData<MapData, int>
{
    private List<MapData> MapDataList { get; set; }

    public override MapData Get(int Key)
    {
        return MapDataList.Find(Data => Data.ObjId == Key);
    }

    public override void Clear()
    {
        MapDataList.Clear();
    }

}
