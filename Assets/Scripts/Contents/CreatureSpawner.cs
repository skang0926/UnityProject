using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utils;
using static Define;

//TEMP Script
public class CreatureSpawner : MonoBehaviour
{
	float spawnInterval = 0.1f;
	int maxMonsterCount = 100;
	Coroutine coUpdateSpawningPool;

	
	void Start()
	{
		coUpdateSpawningPool = StartCoroutine(CoUpdateSpawningPool());
	}

	IEnumerator CoUpdateSpawningPool()
	{
		while (true)
		{
			TrySpawn();
			yield return new WaitForSeconds(spawnInterval);
		}
	}

	void TrySpawn()
	{
		int monsterCount = Managers.Object.Monsters.Count;
		if (monsterCount >= maxMonsterCount)
			return;

		// TEMP
		MonsterController mc = Managers.Object.Spawn<MonsterController>(IntToEnum<CreatureType>(Random.Range(1, 3)));
		float spawnPos = Managers.Object.Player.transform.position.x + Random.Range(-10, 10);
		mc.transform.position = new Vector2(spawnPos, 0);
	}
}
