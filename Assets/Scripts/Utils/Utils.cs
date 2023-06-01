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

	struct Shell<T>
    {
		public int intValue;
		public T Enum;
    }

    public static int EnumToInt<T>(T enumType) where T : struct
    {
		Shell<T> s;

		s.Enum = enumType;

        unsafe
        {
			int* pi = &s.intValue;
			pi += 1;
			return *pi;
        }
    }

	public static T IntToEnum<T>(int value) where T : struct
    {
		var s = new Shell<T>();
        unsafe
        {
			int* pi = &s.intValue;
			pi += 1;
			*pi = value;
        }

		return s.Enum;
    }
}

