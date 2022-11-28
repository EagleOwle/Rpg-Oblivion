using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    [SerializeField] private UnitSfxManager sfxManager;
    [SerializeField] private CharacterController characterController;
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

    private IEnumerator Moving(Vector3 moveDirection)
    {
        sfxManager.PlayStep();
        while (Vector3.Distance(transform.position, transform.position + moveDirection) > 0.5f)
        {
            yield return WaitForFixedUpdate;
            if (groundCheck.CheckGroundStatus())
            {
                Vector3 direction = moveDirection;
                if (acceleration) direction *= 2;

                characterController.SimpleMove(transform.TransformDirection(direction * speedMove * Time.deltaTime));
            }

            //yield return new WaitForSeconds(0.5f);
            //audioSource.PlayOneShot(stepClip);

        }

        sfxManager.StopPlayStep();
    }

    private float Round(float value)
    {
        value = (float)System.Math.Round(value, 2);

        return value;
    }

    public void Initialise(IGroundCheck groundCheck)
    {
        this.groundCheck = groundCheck;
        WaitForFixedUpdate = new WaitForFixedUpdate();
    }

}
