using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Define;

public class PlayerController : CreatureController
{

    //TEMP
    Vector2 moveDir = Vector2.zero;
    public UnityEditor.U2D.Animation.CharacterData data;

    float speed = 5.0f;

    public Data.CharacterData stat;

    public SkillSystem skillSystem;

    public override void Init()
    {
        if (Managers.Data.CharacterDic.ContainsKey(0) == true)
        {
            var characterData = Managers.Data.CharacterDic.GetValueOrDefault(0);

            Debug.Log(characterData.atk);

            stat = characterData.DeepCopy();

            Debug.Log(stat.atk);
            skillSystem = Utils.GetOrAddComponent<SkillSystem>(gameObject);

            if (skillSystem)
            {
                foreach (var skill in stat.skills)
                {
                    skillSystem.RegisterSkill(skill);
                }
            }
        }

        skillSystem.SetCurrentSkill(SkillType.BasicAtk);

    }


    public Vector2 MoveDir
    {
        get { return moveDir; }
        set { moveDir = value.normalized; }
    }

    void Start()
    {
        Managers.Game.OnMoveDirChanged += HandleOnMoveDirChanged;
    }
    void OnDestroy()
    {
        if (Managers.Game != null)
            Managers.Game.OnMoveDirChanged -= HandleOnMoveDirChanged;
    }

    void HandleOnMoveDirChanged(Vector2 dir)
    {
        moveDir = dir;
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {

        //TEMP

        if (Input.touchCount <= 0)
            return;

        float xScreenHalfSize = Screen.width * 0.5f;
        Vector2 touchPos = Input.GetTouch(0).position;

        if (xScreenHalfSize <= touchPos.x)
        {      
            moveDir = new Vector2(1, 0);
        }
        else
        {
            skillSystem.UseCurrentSkill();
        }

        Vector3 dir = moveDir * speed * Time.deltaTime;
        transform.position += dir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MonsterController target = collision.gameObject.GetComponent<MonsterController>();
        if (target == null)
            return;

        target.TakeDamage(this, 10000);
    }

    public override void TakeDamage(BaseController attacker, int damage)
    {
        base.TakeDamage(attacker, damage);

//        animator.SetInteger("Hp", hp);

//        Debug.Log($"TakeDamage !{ hp }");
    }
}
