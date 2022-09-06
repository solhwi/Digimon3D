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

	protected override void OnInit()
	{
		base.OnInit();
	}

	protected override void OnClear()
	{
		base.OnClear();
	}

	public void LoadMap(ENUM_MAP_TYPE mapType)
	{
		ResourceMgr.Instance.LoadMap(mapType, SetMapRoot);
	}

	private void SetMapRoot()
	{
		currMapRoot = FindObjectOfType<MapRoot>();
		if (currMapRoot == null)
			return;

		currMapRoot.transform.SetParent(transform, true);
		currMapRoot.Init();

		isMapLoaded = true;
	}
}
