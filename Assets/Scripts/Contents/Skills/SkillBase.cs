using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillBase : MonoBehaviour
{
    public SkillSystem ownerSystem;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Update()
    {

    }
    public virtual void Init()
    {
        gameObject.SetActive(false);
    }
    public virtual void UseSkill()
    {
    }
 }
