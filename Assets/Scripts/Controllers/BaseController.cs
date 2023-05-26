using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class BaseController : MonoBehaviour
{
    public ObjectType ObjectType { get; protected set; }

    void Awake()
    {
        Init();
    }

    bool init = false;
    public virtual bool Init()
    {
        if (init)
            return false;

        init = true;
        return true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}