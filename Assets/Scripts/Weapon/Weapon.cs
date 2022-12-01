using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IItem
{
    [SerializeField] protected bool onlyHideCursor = true;
    [SerializeField] protected Animator animator;

    protected const string attack = "Attack";

    protected virtual void Update()
    {
        if (onlyHideCursor && Cursor.visible == true) return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    public virtual void Attack()
    {
        animator.SetTrigger(attack);
    }

    public string GetName()
    {
        return name;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}

