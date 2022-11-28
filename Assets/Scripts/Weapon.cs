using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private bool onlyHideCursor = true;
    [SerializeField] private Animator animator;

    private const string attack = "Attack";

    private void Update()
    {
        if (onlyHideCursor && Cursor.visible == true) return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    public void Attack()
    {
        animator.SetTrigger(attack);
    }
}

