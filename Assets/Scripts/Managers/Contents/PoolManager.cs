using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

class Pool
{
    GameObject prefab;
    IObjectPool<GameObject> pool;

    Transform root;
    Transform Root
    {
        get
        {
            if (root == null)
            {
                GameObject go = new GameObject() { name = $"{prefab.name}Root" };
                root = go.transform;
            }

            return root;
        }
    }

    public Pool(GameObject prefab)
    {
        this.prefab = prefab;
        pool = new ObjectPool<GameObject>(OnCreate, OnGet, OnRelease, OnDestroy);
    }

    public void Push(GameObject go)
    {
        pool.Release(go);
    }

    public GameObject Pop()
    {
        return pool.Get();
    }

    #region Funcs

    GameObject OnCreate()
    {
        GameObject go = GameObject.Instantiate(prefab);
        go.transform.parent = Root;
        go.name = prefab.name;
        return go;
    }

    void OnGet(GameObject go)
    {
        go.SetActive(true);
    }

    void OnRelease(GameObject go)
    {
        go.SetActive(false);
    }

    void OnDestroy(GameObject go)
    {
        GameObject.Destroy(go);
    }
    #endregion
}

public class PoolManager
{
    Dictionary<string, Pool> pools = new Dictionary<string, Pool>();

    public GameObject Pop(GameObject prefab)
    {
        if (pools.ContainsKey(prefab.name) == false)
            CreatePool(prefab);

        return pools[prefab.name].Pop();
    }

    public bool Push(GameObject go)
    {
        if (pools.ContainsKey(go.name) == false)
            return false;

        pools[go.name].Push(go);
        return true;
    }

    void CreatePool(GameObject prefab)
    {
        Pool pool = new Pool(prefab);
        pools.Add(prefab.name, pool);
    }
}
