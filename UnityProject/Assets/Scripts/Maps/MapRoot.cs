using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapRoot : MonoBehaviour
{
	public MapComponent[] mapComponents = null;

	public void Init()
	{
		mapComponents = GetComponentsInChildren<MapComponent>();
	}

	public T[] GetMapComponents<T>() where T : MapComponent
	{
		return mapComponents
			.Where(comp => comp.GetType() == typeof(T))
			.Select(comp=> comp as T)
			.ToArray();
	}

	public T GetMapComponent<T>() where T : MapComponent
	{
		var components = GetMapComponents<T>();
		if (components == null || components.Length <= 0)
			return null;

		return components[0];
	}
}
