using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float jumpTime = 20;
    [SerializeField] private float jumpPower = 20;
    [SerializeField] private AnimationCurve jumpCurve;
    private IGroundCheck groundCheck;
    private float capsuleHeight;
    private Vector3 capsuleCenter;

    public void Initialise(IGroundCheck groundCheck)
    {
        this.groundCheck = groundCheck;
        capsuleHeight = characterController.height;
        capsuleCenter = characterController.center;
    }

    float verticalVelocity;
    public void Jump()
    {
        if (groundCheck.CheckGroundStatus() == true && ObstacleFromAbove() == false)
        {
            StartCoroutine(JumpRoutine());
        }
    }

    float jumpTimer;
    private IEnumerator JumpRoutine()
    {
        jumpTimer = 0;
        while (jumpTimer < jumpCurve.length)
        {
            yield return null;
            characterController.Move(new Vector3(0, jumpCurve.Evaluate(jumpTimer) * jumpPower, 0));
            jumpTimer += jumpTime * Time.deltaTime;
        }
    }

    private bool ObstacleFromAbove()
    {
        float radius = characterController.radius;
        Ray ray = new Ray(transform.position + Vector3.up * radius * 0.5f, Vector3.up);
        float length = capsuleHeight - radius * 0.5f;
        if (Physics.SphereCast(ray, radius * 0.5f, length, Physics.AllLayers, QueryTriggerInteraction.Ignore))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
