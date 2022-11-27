using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchListener : MonoBehaviour
{
    private Vector3 originalPosition;

    public void Initialise(ref Action<bool> eventOnCrouch)
    {
        originalPosition = transform.localPosition;
        eventOnCrouch += OnCrouch;
    }

    private void OnCrouch(bool crouch)
    {
        if (crouch == true)
        {
            transform.localPosition = originalPosition / 2;
        }
        else
        {
            transform.localPosition = originalPosition;
        }
    }
}
