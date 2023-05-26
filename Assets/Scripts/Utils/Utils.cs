using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
public class Utils
{
	public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
	{
		T component = go.GetComponent<T>();
		if (component == null)
			component = go.AddComponent<T>();
		return component;
	}

	public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
	{
		Transform transform = FindChild<Transform>(go, name, recursive);
		if (transform == null)
			return null;

		return transform.gameObject;
	}

	public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
	{
		if (go == null)
			return null;

		if (recursive == false)
		{
			for (int i = 0; i < go.transform.childCount; i++)
			{
				Transform transform = go.transform.GetChild(i);
				if (string.IsNullOrEmpty(name) || transform.name == name)
				{
					T component = transform.GetComponent<T>();
					if (component != null)
						return component;
				}
			}
		}
		else
		{
			foreach (T component in go.GetComponentsInChildren<T>())
			{
				if (string.IsNullOrEmpty(name) || component.name == name)
					return component;
			}
		}

		return null;
	}

	public static CreatureType IntToCreatureType(int num)
    {
		CreatureType ct;

		switch(num)
        {
			case 0:
				ct = CreatureType.Goblin;
				break;
			case 1:
				ct = CreatureType.Slime;
				break;
			case 2:
				ct = CreatureType.Snake;
				break;
			default:
				ct = CreatureType.None;
				break;
        }

		return ct;
    }

	public static int CreatureTypeToInt(CreatureType ct)
    {
		return (int)ct;
    }
}

