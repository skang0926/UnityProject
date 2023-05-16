using System.Collections;
using System.Collections.Generic;
using UnityEngine;


////////////////////////
/// Base Class
////////////////////////

public abstract class StatComponent : MonoBehaviour
{
    void Awake()
    {

    }

    public abstract StatData GetDataTable();
}

