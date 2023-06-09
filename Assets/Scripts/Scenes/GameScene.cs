using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Define;
using static Utils;

public class GameScene : MonoBehaviour
{
	void Start()
	{
		Managers.Resource.LoadAllAsync<GameObject>("Prefabs", (key, count, totalCount) =>
		{
			Debug.Log($"{key} {count}/{totalCount}");

			if (count == totalCount)
			{
				Managers.Resource.LoadAllAsync<TextAsset>("Data", (key3, count3, totalCount3) =>
				{
					if (count3 == totalCount3)
					{
						StartLoaded();
					}
				});
			}
		});
	}

	CreatureSpawner spawner;

	void StartLoaded()
	{
		//TEMP
		spawner = gameObject.AddComponent<CreatureSpawner>();

		// Data Test
		Managers.Data.Init();

		var player = Managers.Object.Spawn<PlayerController>(CreatureType.Knight);

		Camera.main.GetComponent<CameraController>().Target = player.gameObject;


        foreach (var playerData in Managers.Data.CharacterDic.Values)
        {
            foreach (var skill in playerData.skills)
            {
                Debug.Log($"Skill : {skill}");
            }
        }

    }

	void Update()
	{
		
	}
}
