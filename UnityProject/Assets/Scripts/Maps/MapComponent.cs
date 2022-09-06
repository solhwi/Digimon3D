using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapComponent : MonoBehaviour
{
	public int mapIndex = -1;

	private void Reset()
	{
		mapIndex = GetInstanceID();
	}
}
