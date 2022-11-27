using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private float jumpPower = 5;
    private IGroundCheck groundCheck;

    public void Initialise(IGroundCheck groundCheck)
    {
        this.groundCheck = groundCheck;
    }

    public void Jump()
    {
        if (groundCheck.CheckGroundStatus())
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpPower, rigidbody.velocity.z);
        }
    }
}
