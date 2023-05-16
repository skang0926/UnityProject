using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatComponent : StatComponent
{
    public MonsterStatData dataTable;

    void Awake()
    {
        // TODO 
        // How to link ScriptableObject at runtime? 
    }
    public override StatData GetDataTable()
    {
        return dataTable;
    }
}
