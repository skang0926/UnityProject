using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Creature
{
    // Start is called before the first frame update

    public MonsterStatComponent statComponent;

    void Awake()
    {
        Init();
    }

    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Init()
    {
        // TODO
        gameObject.AddComponent<MonsterStatComponent>();
        gameObject.AddComponent<SpriteRenderer>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        statComponent = GetComponent<MonsterStatComponent>();
    }

    public override StatComponent GetStatComponent()
    {
        return statComponent;
    }
}
