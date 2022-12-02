using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouching : MonoBehaviour
{
    public event Action<bool> eventOnCrouch;
    [SerializeField] private CharacterController characterController;
    private IGroundCheck groundCheck;
    private float capsuleHeight;
    private Vector3 capsuleCenter;

    public void Initialise(IGroundCheck groundCheck, CrouchListener[] crouchListeners)
    {
        this.groundCheck = groundCheck;
        capsuleHeight = characterController.height;
        capsuleCenter = characterController.center;

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
            if (groundCheck.OnGround() == false) return;

            StopAllCoroutines();
            characterController.height = characterController.height / 2f;
            characterController.center = characterController.center / 2f;
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

        characterController.height = capsuleHeight;
        characterController.center = capsuleCenter;
        eventOnCrouch.Invoke(false);
    }

    private bool ObstacleFromAbove()
    {
        float radius = characterController.radius;
        Ray crouchRay = new Ray(transform.position + Vector3.up * radius * 0.5f, Vector3.up);
        float crouchRayLength = capsuleHeight - radius * 0.5f;
        if (Physics.SphereCast(crouchRay, radius * 0.5f, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
