using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public abstract void Init();

    public abstract StatComponent GetStatComponent();
}
