using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Define;
public class CreatureController : BaseController
{
    protected Animator animator;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void TakeDamage(BaseController attacker, int damage)
    {

    }

    public virtual void TakeDamage(BaseController attacker, int damage, SkillData skillData)
    {

    }

    protected virtual void OnDead()
    {

    }
}
