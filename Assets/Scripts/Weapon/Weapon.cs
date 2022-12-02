using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IItem
{
    [SerializeField] protected bool onlyHideCursor = true;
    [SerializeField] protected Animator animator;

    protected const string attack = "Attack";

    public virtual void Attack()
    {
        animator.SetTrigger(attack);
    }

    public string GetName()
    {
        return name;
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

}

