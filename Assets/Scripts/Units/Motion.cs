using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    [SerializeField] private UnitSfxManager sfxManager;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speedMove = 200;

    private bool acceleration;
    private IGroundCheck groundCheck;

    private Vector3 moveDirection;
    private bool isMove = false;

    public void Initialise(IGroundCheck groundCheck)
    {
        this.groundCheck = groundCheck;
    }

    public void OnAcceleration(bool acceleration)
    {
        this.acceleration = acceleration;
    }

    public void Move(Vector3 moveDirection)
    {
        this.moveDirection = moveDirection;

        if (isMove == false)
        {
            StartCoroutine(Moving());
        }
    }

    private IEnumerator Moving()
    {
        isMove = true;

        while (true)
        {
            if (groundCheck.OnGround() == false)
            {
                break;
            }

            if (moveDirection.magnitude == 0)
            {
                break;
            }

            Vector3 direction = moveDirection;
            if (acceleration) direction *= 2;

            characterController.Move(transform.TransformDirection(direction * speedMove * Time.deltaTime));

            sfxManager.PlayStep();

            yield return null;
        }

        sfxManager.StopPlayStep();
        isMove = false;
    } 

}
