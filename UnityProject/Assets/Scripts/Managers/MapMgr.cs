using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_MAP_TYPE
{
	FileIsland = 0,
}

public class MapMgr : SingletonBehaviour<MapMgr>
{
	MapRoot currMapRoot = null;

	public override bool IsLoadDone
	{
		get
		{
			return isMapLoaded;
		}
	}

	private bool isMapLoaded = false;

	public void LoadMap(ENUM_MAP_TYPE mapType, Action OnLoadMap, Action<Vector3, Quaternion> OnLoadMapForSpawn)
	{
		ResourceMgr.Instance.LoadMap(mapType, () => 
		{
			SetMapRoot();
			isMapLoaded = true;

			OnLoadMap?.Invoke();

			MapPlayerSpawnArea playerSpawnArea = currMapRoot.GetMapComponent<MapPlayerSpawnArea>();
			Vector3 playerSpawnPos = playerSpawnArea.GetSpawnPos();
			Quaternion playerSpawnRotation = playerSpawnArea.GetSpawnRotation();

			OnLoadMapForSpawn?.Invoke(playerSpawnPos, playerSpawnRotation);
		});
	}

	private void SetMapRoot()
	{
		currMapRoot = FindObjectOfType<MapRoot>();
		if (currMapRoot == null)
			return;

		currMapRoot.transform.SetParent(transform, true);
		currMapRoot.Init();
	}
}
