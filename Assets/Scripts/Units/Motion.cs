using System.Collections;
using UnityEngine;

public class Motion : MonoBehaviour
{
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private new CharacterController characterController;
    [SerializeField] private float speedMove = 400;

    private bool acceleration;
    private WaitForFixedUpdate WaitForFixedUpdate;
    private IGroundCheck groundCheck;   

    public void OnAcceleration(bool acceleration)
    {
        this.acceleration = acceleration;
    }

    public void StartMove(Vector3 moveDirection)
    {
        StopAllCoroutines();
        StartCoroutine(Moving(moveDirection));
    }
    private void FixedUpdate()
    {
        characterController.SimpleMove(Vector3.zero);
    }

    private IEnumerator Moving(Vector3 moveDirection)
    {
        while(transform.position != moveDirection)
        {
            yield return WaitForFixedUpdate;
            if (groundCheck.CheckGroundStatus())
            {
                Vector3 direction = moveDirection;
                if (acceleration) direction *= 2;

                characterController.SimpleMove(transform.TransformDirection(direction * speedMove * Time.deltaTime));
            }
        }
    }

    public void Initialise(IGroundCheck groundCheck)
    {
        this.groundCheck = groundCheck;
        WaitForFixedUpdate = new WaitForFixedUpdate();
    }

}
