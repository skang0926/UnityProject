using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    public PlayerStatComponent statComponent;


    // Start is called before the first frame update

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
        gameObject.AddComponent<PlayerStatComponent>();
        gameObject.AddComponent<SpriteRenderer>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        statComponent = GetComponent<PlayerStatComponent>();
    }

    public override StatComponent GetStatComponent()
    {
        return statComponent;
    }
}
