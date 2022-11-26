using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMouseInput
{
    event Action<Vector2> EventOnMouseAxis;
    event Action<Vector2> EventOnKeyboardAxis;
    event Action<float> EventOnMouseScroll;
    event Action<bool> EventOnAcceleration;
    event Action EventOnJump;
    event Action<bool> EventOnCrouch;
}

public class InputHandler : MonoBehaviour, IMouseInput
{
    public event Action<Vector2> EventOnMouseAxis;
    public event Action<Vector2> EventOnKeyboardAxis;
    public event Action<float> EventOnMouseScroll;
    public event Action EventOnJump;
    public event Action<bool> EventOnCrouch;
    public event Action<bool> EventOnAcceleration;

    private Vector2 mouseAxis;
    private Vector2 MouseAxis
    {
        set
        {
            if (mouseAxis != value)
            {
                mouseAxis = value;
                EventOnMouseAxis.Invoke(value);
            }
        }
    }

    private Vector2 keyboardAxis;
    private Vector2 KeyboardAxis
    {
        set
        {
            if (keyboardAxis != value)
            {
                keyboardAxis = value;
                EventOnKeyboardAxis.Invoke(value);
            }
        }
    }

    private float scroll;
    private float Scroll
    {
        set
        {
            if (scroll != value)
            {
                scroll = value;
                EventOnMouseScroll.Invoke(scroll);
            }

        }
    }

    private void Initialise()
    {
    }

    private void Update()
    {
        MouseAxis = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Scroll = Input.GetAxis("Mouse ScrollWheel");
        KeyboardAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetButtonDown("Jump"))
        {
            EventOnJump.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            EventOnAcceleration.Invoke(true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            EventOnAcceleration.Invoke(false);
        }


        if (Input.GetKeyDown(KeyCode.C))
        {
            EventOnCrouch.Invoke(true);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            EventOnCrouch.Invoke(false);
        }
    }


}
