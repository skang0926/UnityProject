using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;


public class SkillSystem : MonoBehaviour
{

    public GameObject currentSkill;

    public Dictionary<SkillType, GameObject> skillTable;

    public CreatureController ownerController;


    void Awake()
    {
        Init();
    }

    private void Init()
    {
        ownerController = gameObject.GetComponent<CreatureController>();

        skillTable = new Dictionary<SkillType, GameObject>();
    }

    public void Factory(SkillType skillType)
    {
        string name;

        switch(skillType)
        {
            case SkillType.BasicAtk:
                name = "BasicAtk";
                break;
            case SkillType.TestSkill:
                name = "TestSkill";
                break;
            default:
                name = "None";
                break;
        }

        GameObject skill = Managers.Resource.Instantiate(name + ".prefab", null, true);

        skill.GetComponent<SkillBase>().ownerSystem = this; 
        skillTable.Add(skillType, skill);

    }

    public void RegisterSkill(SkillType skillType)
    {
        if (skillTable.ContainsKey(skillType) == false)
        {
            Factory(skillType);
        }
    }

    public void UnRegisterSkill(SkillType skillType)
    {
        if (skillTable.ContainsKey(skillType) == false)
        {
            return;
        }

        skillTable.Remove(skillType);
    }

    //TEMP
    public void SetCurrentSkill(SkillType skillType)
    {
        if (skillTable.ContainsKey(skillType))
        {
            currentSkill = skillTable.GetValueOrDefault(skillType);
        }
    }

    //TEMP

    public void UseCurrentSkill()
    {
        var skill = currentSkill.GetComponent<SkillBase>();
        skill.UseSkill();
    }
}
