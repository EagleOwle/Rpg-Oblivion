using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
   
    [SerializeField] private float jumpPower = 0.5f;
    [SerializeField] private AnimationCurve jumpCurve;
    private IGroundCheck groundCheck;
    private float capsuleHeight;
    private Vector3 capsuleCenter;
    private const float jumpTime = 30;

    public void Initialise(IGroundCheck groundCheck)
    {
        this.groundCheck = groundCheck;
        capsuleHeight = characterController.height;
        capsuleCenter = characterController.center;
    }

    public void Jump()
    {
        if (groundCheck.OnGround() == true && ObstacleFromAbove() == false)
        {
            StartCoroutine(JumpRoutine());
        }
    }

    private IEnumerator JumpRoutine()
    {
        float currentTime = 0;
        while (currentTime < jumpCurve.length)
        {
            currentTime += jumpTime * Time.deltaTime;
            characterController.Move(Vector3.up * jumpCurve.Evaluate(currentTime) * jumpPower);
            yield return null;
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
