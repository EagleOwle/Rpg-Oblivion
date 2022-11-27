using System.Collections;
using UnityEngine;

public class Motion : MonoBehaviour
{
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private float speedMove = 400;

    private bool crouch;
    private bool acceleration;
    private WaitForFixedUpdate WaitForFixedUpdate;
    private IGroundCheck groundCheck;

    public void OnCrouch(bool crouch)
    {
        this.crouch = crouch;
    }

    public void OnAcceleration(bool acceleration)
    {
        this.acceleration = acceleration;
    }

    public void StartMove(Vector3 moveDirection)
    {
        StopAllCoroutines();
        StartCoroutine(Moving(moveDirection));
    }

    private IEnumerator Moving(Vector3 moveDirection)
    {
        while(transform.position != moveDirection)
        {
            if (groundCheck.CheckGroundStatus())
            {
                Vector3 direction = moveDirection;
                if (acceleration) direction *= 2;

                rigidbody.velocity = transform.TransformDirection(direction * speedMove * Time.deltaTime);
            }

            yield return WaitForFixedUpdate;
        }
    }

    public void Initialise(IGroundCheck groundCheck)
    {
        this.groundCheck = groundCheck;
        WaitForFixedUpdate = new WaitForFixedUpdate();
    }

}