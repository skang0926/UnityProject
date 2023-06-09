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
  
    public virtual void Init()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}