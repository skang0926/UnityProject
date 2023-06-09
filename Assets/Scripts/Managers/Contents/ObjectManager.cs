using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

using static Define;
public class ObjectManager
{
	public PlayerController Player { get; private set; }
	public HashSet<MonsterController> Monsters { get; } = new HashSet<MonsterController>();
//	public HashSet<ProjectileController> Projectiles { get; } = new HashSet<ProjectileController>();

	public T Spawn<T>(CreatureType creatureType) where T : BaseController
	{
		System.Type type = typeof(T);

		string name;
		GameObject go;

		switch (creatureType)
		{
			case CreatureType.Knight:
		
				go = Managers.Resource.Instantiate("Knight_01.prefab", pooling: true);
				go.name = "Player";

				PlayerController pc = go.GetOrAddComponent<PlayerController>();
				Player = pc;
				return pc as T;

			case CreatureType.Slime:
				name = "Slime_01";
				break;

			case CreatureType.Snake:
				name = "Snake_01";
				break;
			default:
				return null;
		}

		go = Managers.Resource.Instantiate(name + ".prefab", pooling: true);

		MonsterController mc = go.GetOrAddComponent<MonsterController>();
		Monsters.Add(mc);

		return mc as T; ;
	}

	public void Despawn<T>(T obj) where T : BaseController
	{
		System.Type type = typeof(T);

		if (type == typeof(PlayerController))
		{
			// ?
		}
		else if (type == typeof(MonsterController))
		{
			Monsters.Remove(obj as MonsterController);
			Managers.Resource.Destroy(obj.gameObject);
		}
	}
}
