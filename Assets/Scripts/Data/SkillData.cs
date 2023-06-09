using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SkillData", order = 1)]
public class SkillData : ScriptableObject
{
    public int atkCoefficient;
    public float coolTime;
    public float widthRange;
    public float heightRange;      
    public GameObject skillPrefab;
    public Sprite sprite;
}

