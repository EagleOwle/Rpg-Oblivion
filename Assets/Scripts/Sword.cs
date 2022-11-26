using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Attack();
}

public class Sword : MonoBehaviour, IWeapon
{
    [SerializeField] private Animator animator;

    private const string attack = "Attack";

    private void Update()
    {
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
