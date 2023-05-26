using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
	static Managers s_instance;
	static bool s_init = false;

	#region Contents
	GameManager gameManager = new GameManager();
	ObjectManager objectManager = new ObjectManager();
	PoolManager poolManager = new PoolManager();
	public static GameManager Game { get { return Instance?.gameManager; } }
	public static ObjectManager Object { get { return Instance?.objectManager; } }
	public static PoolManager Pool { get { return Instance?.poolManager; } }
	#endregion

	#region Core
	DataManager dataManager = new DataManager();
	ResourceManager resourceManager = new ResourceManager();
	SceneManager sceneManager = new SceneManager();
	SoundManager soundManager = new SoundManager();
	UIManager uiManager = new UIManager();
	public static DataManager Data { get { return Instance?.dataManager; } }
	public static ResourceManager Resource { get { return Instance?.resourceManager; } }
	public static SceneManager Scene { get { return Instance?.sceneManager; } }
	public static SoundManager Sound { get { return Instance?.soundManager; } }
	public static UIManager UI { get { return Instance?.uiManager; } }
	#endregion

	public static Managers Instance
	{
		get
		{
			if (s_init == false)
			{
				s_init = true;

				GameObject go = GameObject.Find("@Managers");
				if (go == null)
				{
					go = new GameObject() { name = "@Managers" };
					go.AddComponent<Managers>();
				}

				DontDestroyOnLoad(go);
				s_instance = go.GetComponent<Managers>();
			}

			return s_instance;
		}
	}
}
