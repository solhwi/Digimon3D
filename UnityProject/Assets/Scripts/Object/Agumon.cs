using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDDefine;

[Digimon(ENUM_DIGIMON_TYPE.Agumon)]
public class Agumon : Digimon
{
	public override void Init()
	{
		base.Init();

		tagType = ENUM_TAG_TYPE.Untagged;
	}
}
