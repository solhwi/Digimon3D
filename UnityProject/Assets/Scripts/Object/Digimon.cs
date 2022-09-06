using SDDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.AttributeUsage(AttributeTargets.Class)]
public class DigimonAttribute : ResourceAttribute
{
    ENUM_DIGIMON_TYPE job;

    public DigimonAttribute(ENUM_DIGIMON_TYPE job) : base($"Assets/Bundles/Prefabs/Digimon/{job}.prefab")
    {
        this.job = job;
    }

    public ENUM_DIGIMON_TYPE GetJob()
    {
        return job;
    }
}

public class Digimon : ActiveObject
{
    protected int index = -1;

    public void Spawn(Vector3 pos)
	{
        ReplaceObject(pos);
    }

    public virtual void Look(StateParam param = null)
	{

	}

}
