using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouching : MonoBehaviour
{
    public event Action<bool> eventOnCrouch;
    [SerializeField] private CapsuleCollider capsule;
    private IGroundCheck groundCheck;
    private float capsuleHeight;
    private Vector3 capsuleCenter;

    public void Initialise(IGroundCheck groundCheck, CrouchListener[] crouchListeners)
    {
        this.groundCheck = groundCheck;
        capsuleHeight = capsule.height;
        capsuleCenter = capsule.center;

        foreach (var item in crouchListeners)
        {
            item.Initialise(ref eventOnCrouch);
        }

    }

    public void OnCrouch(bool crouch)
    {
        Crouch(crouch);
    }

    public void Crouch(bool crouch)
    {
        if (crouch == true)
        {
            if (groundCheck.CheckGroundStatus() == false) return;

            StopAllCoroutines();
            capsule.height = capsule.height / 2f;
            capsule.center = capsule.center / 2f;
            eventOnCrouch.Invoke(true);
        }
        else
        {
            StartCoroutine(WaitForStandUp());
        }
    }

    private IEnumerator WaitForStandUp()
    {
        while(ObstacleFromAbove() == true)
        {
            yield return null;
        }

        capsule.height = capsuleHeight;
        capsule.center = capsuleCenter;
        eventOnCrouch.Invoke(false);
    }

    private bool ObstacleFromAbove()
    {
        Ray crouchRay = new Ray(transform.position + Vector3.up * capsule.radius * 0.5f, Vector3.up);
        float crouchRayLength = capsuleHeight - capsule.radius * 0.5f;
        if (Physics.SphereCast(crouchRay, capsule.radius * 0.5f, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
