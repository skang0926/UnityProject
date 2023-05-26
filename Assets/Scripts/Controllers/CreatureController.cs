using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : BaseController
{
    protected float speed = 1.0f;
    public int hp { get; set; } = 100;
    public int maxHp { get; set; } = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void TakeDamage(BaseController attacker, int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            OnDead();
        }
    }

    protected virtual void OnDead()
    {

    }
}
