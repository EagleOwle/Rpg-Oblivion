using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    abstract void  Attack();
}

public abstract class Weapon : MonoBehaviour, IWeapon
{
    public abstract void Attack();
}

public class Sword : Weapon
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

    public override void Attack()
    {
        animator.SetTrigger(attack);
    }

}
