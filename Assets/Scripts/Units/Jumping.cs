using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    [SerializeField] private CapsuleCollider capsule;
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private float jumpPower = 5;
    private IGroundCheck groundCheck;
    private float capsuleHeight;
    private Vector3 capsuleCenter;

    public void Initialise(IGroundCheck groundCheck)
    {
        this.groundCheck = groundCheck;
        capsuleHeight = capsule.height;
        capsuleCenter = capsule.center;
    }

    public void Jump()
    {
        if (groundCheck.CheckGroundStatus() == true && ObstacleFromAbove() == false)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpPower, rigidbody.velocity.z);
        }
    }

    private bool ObstacleFromAbove()
    {
        Ray ray = new Ray(transform.position + Vector3.up * capsule.radius * 0.5f, Vector3.up);
        float length = capsuleHeight - capsule.radius * 0.5f;
        if (Physics.SphereCast(ray, capsule.radius * 0.5f, length, Physics.AllLayers, QueryTriggerInteraction.Ignore))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
