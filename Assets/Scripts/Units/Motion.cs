using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    [SerializeField] private UnitSfxManager sfxManager;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speedMove = 200;

    private bool acceleration;
    private WaitForFixedUpdate WaitForFixedUpdate;
    private WaitForEndOfFrame WaitForLateUpdate;
    private IGroundCheck groundCheck;

    private Vector3 moveDirection;
    private bool isMove = false;

    public void Initialise(IGroundCheck groundCheck)
    {
        this.groundCheck = groundCheck;
        WaitForFixedUpdate = new WaitForFixedUpdate();
        WaitForLateUpdate = new WaitForEndOfFrame();
    }

    public void OnAcceleration(bool acceleration)
    {
        this.acceleration = acceleration;
    }

    public void Move(Vector3 moveDirection)
    {
        this.moveDirection = moveDirection;// transform.position + moveDirection;
        if (isMove == false)
        {
            StartCoroutine(Moving());
        }
    }

    private IEnumerator Moving()
    {
        sfxManager.PlayStep();
        isMove = true;
        while (Vector3.Distance(transform.position, moveDirection) > 0.5f)
        {
            if (groundCheck.CheckGroundStatus())
            {
                Vector3 direction = moveDirection;
                if (acceleration) direction *= 2;

                characterController.SimpleMove(transform.TransformDirection(direction * speedMove * Time.deltaTime));
            }

            yield return WaitForLateUpdate;
        }

        sfxManager.StopPlayStep();
        isMove = false;
    }  

}
