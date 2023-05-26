using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CreatureController
{
    Vector2 moveDir = Vector2.zero;

    float speed = 5.0f;

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
            GetComponent<SpriteRenderer>().flipX = true;

            moveDir = new Vector2(1, 0);
        }
        else
        {
            moveDir = new Vector2(-1, 0);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        Vector3 dir = moveDir * speed * Time.deltaTime;
        transform.position += dir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MonsterController target = collision.gameObject.GetComponent<MonsterController>();
        if (target == null)
            return;

        //TEMP
        target.TakeDamage(this, 10000);
    }

    public override void TakeDamage(BaseController attacker, int damage)
    {
        base.TakeDamage(attacker, damage);

        Debug.Log($"TakeDamage !{ hp }");
    }
}
