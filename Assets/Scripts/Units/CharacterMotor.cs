using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private bool useGravity;

    private void FixedUpdate()
    {
        if (useGravity == false) return;

        characterController.SimpleMove(Vector3.zero);
    }

}
