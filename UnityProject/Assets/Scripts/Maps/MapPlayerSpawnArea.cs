using SDDefine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawnArea : MapComponent
{
	public Vector3 GetSpawnPos()
	{
		return transform.position;
	}
}

public class MapPlayerSpawnArea : MapSpawnArea
{
	public readonly ENUM_LAYER_TYPE layerType = ENUM_LAYER_TYPE.PlayerSpawn;


}
