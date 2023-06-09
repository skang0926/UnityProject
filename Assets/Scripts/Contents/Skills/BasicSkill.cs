using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSkill : SkillBase
{
    // Start is called before the first frame update
    public SkillData skillData;
    public BoxCollider2D colliderBox;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    private void Awake()
    {

    }

    void Start()
    {
        Init();
    }

    void Update()
    {

    }
    public override void Init()
    {
        base.Init();
        sprite = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(skillData.widthRange, skillData.heightRange, 1);
    }

    public override void UseSkill()
    {
        if (coWaitSkillTime != null) return;

        transform.position = ownerSystem.transform.position + new Vector3(skillData.widthRange * 0.5f, skillData.heightRange * 0.25f);

        sprite.enabled = true;
        gameObject.SetActive(true);

        if (coWaitSkillTime == null)
        {
            coWaitSkillTime = StartCoroutine(WaitSkillTime());
        }


        OverlapBoxAll();
    } 

    private void OverlapBoxAll()
    {
        Vector2 ownerPosition = ownerSystem.transform.position;
        Vector2 center = new Vector2(ownerPosition.x + skillData.widthRange * 0.5f, ownerPosition.y + skillData.heightRange * 0.25f);
        Vector2 size = new Vector2(skillData.widthRange * 0.8f, skillData.heightRange * 0.4f);
        Collider2D[] colliders = Physics2D.OverlapBoxAll(center, size, 0);

        foreach (var collider in colliders)
        {
            var target = collider.gameObject.GetComponent<CreatureController>();
            if ((target != null) && (target != ownerSystem.ownerController))
            {
                //TEMP
                target.TakeDamage(ownerSystem.ownerController, skillData.atkCoefficient*1000);
            }
        }
    }

    Coroutine coWaitSkillTime;
    IEnumerator WaitSkillTime()
    {
        yield return new WaitForSeconds(0.1f);

        sprite.enabled = false;
        StartCoroutine(WaitSkillCoolTime());
    }

    IEnumerator WaitSkillCoolTime()
    {
        yield return new WaitForSeconds(skillData.coolTime);
        gameObject.SetActive(false);
        coWaitSkillTime = null;
    }
}
