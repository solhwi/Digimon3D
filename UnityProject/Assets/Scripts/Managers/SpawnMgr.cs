using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDDefine;

public class SpawnData
{
	public ENUM_DIGIMON_TYPE digimonType;
	public Vector3 spawnPos;
}

public class SpawnMgr : SingletonBehaviour<SpawnMgr>
{
	public Digimon Spawn(SpawnData data)
	{
		if (data.digimonType == ENUM_DIGIMON_TYPE.Agumon)
		{
			ResourceMgr.Instance.Instantiate<Agumon>(data.spawnPos, new Quaternion(0,0,0,1));
		}

		return null;
	}
}
