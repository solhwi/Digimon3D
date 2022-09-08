using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDDefine;

public class SpawnData
{
	public ENUM_DIGIMON_TYPE digimonType;
	public Vector3 spawnPos;
	public Quaternion spawnRot;

	public SpawnData(ENUM_DIGIMON_TYPE digimonType, Vector3 spawnPos, Quaternion spawnRot)
	{
		this.digimonType = digimonType;
		this.spawnPos = spawnPos;
		this.spawnRot = spawnRot;
	}
}

public class SpawnMgr : SingletonBehaviour<SpawnMgr>
{
	Digimon spawnedDigimon;

	public void Spawn(SpawnData data)
	{
		if (data.digimonType == ENUM_DIGIMON_TYPE.Agumon)
		{
			ResourceMgr.Instance.Instantiate<Agumon>(data.spawnPos, data.spawnRot, true, InitializeDigimon);
		}
	}

	private void InitializeDigimon(Digimon digimon)
	{
		spawnedDigimon = digimon;
		spawnedDigimon.Init();
		spawnedDigimon.LayerType = ENUM_LAYER_TYPE.Player;

		CharacterController.Instance.SetDigimon(digimon);
	}
}
