using SDDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.AttributeUsage(AttributeTargets.Class)]
public class CharacterAttribute : ResourceAttribute
{
    ENUM_CHARACTER job;

    public CharacterAttribute(ENUM_CHARACTER job, string path) : base(path)
    {
        this.job = job;
    }

    public ENUM_CHARACTER GetJob()
    {
        return job;
    }
}

public class Character : ActiveObject
{
    public virtual void Look(CharacterParam param = null)
	{

	}

}
