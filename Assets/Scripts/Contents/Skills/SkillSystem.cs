using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class SkillSystem : MonoBehaviour
{

    public SkillBase currentSkill;

    public Dictionary<SkillType, SkillBase> skillTable;
  
    public void Factory(SkillType skillType)
    {
        
    }

    public void RegisterSkill(SkillType skillType)
    {
        if (skillTable.ContainsKey(skillType) == false)
        {

        }
    }

    public void UnRegisterSkill(SkillType skillType)
    {

    }
}
