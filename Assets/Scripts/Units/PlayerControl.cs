using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private bool onlyHideCursor = true;
    private Vector3 move;
    private Vector3 rotate;
    private bool acceleration;
    private bool jump;
    private bool crouch;


    public void Initialise(IMouseInput IMouseInput)
    {
        //IMouseInput.EventOnMouseAxis += IMouseInput_EventOnMouseAxis;
        //IMouseInput.EventOnKeyboardAxis += IMouseInput_EventOnKeyboardAxis;
        //IMouseInput.EventOnJump += IMouseInput_EventOnJump;
        //IMouseInput.EventOnCrouch += IMouseInput_EventOnCrouch;
        //IMouseInput.EventOnAcceleration += IMouseInput_EventOnAcceleration;
    }

    private void IMouseInput_EventOnMouseAxis(Vector2 value)
    {
        if (onlyHideCursor && Cursor.visible == true) return;

        rotate = value;
        character.Rotation(value);
    }

    private void IMouseInput_EventOnAcceleration(bool value)
    {
        if (onlyHideCursor && Cursor.visible == true) return;

        acceleration = value;
        character.OnAcceleration(value);
    }

    private void IMouseInput_EventOnCrouch(bool value)
    {
        if (onlyHideCursor && Cursor.visible == true) return;

        crouch = value;
        character.OnCrouch(value);
    }

    private void IMouseInput_EventOnJump()
    {
        if (onlyHideCursor && Cursor.visible == true) return;

        jump = true;
        character.OnJump();
        Invoke(nameof(DebugClearJump), 0.1f);
    }

    private void IMouseInput_EventOnKeyboardAxis(Vector2 value)
    {
        if (onlyHideCursor && Cursor.visible == true) return;

        move = value;
        character.Move(value);
    }

    private void DebugClearJump()
    {
        if (onlyHideCursor && Cursor.visible == true) return;

        jump = false;
    }

    private void Update()
    {
        if (onlyHideCursor && Cursor.visible == true) return;

        Vector2 MouseAxis = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        character.Rotation(MouseAxis);

        //Scroll = Input.GetAxis("Mouse ScrollWheel");
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        character.Move(move);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            character.OnJump();
            Invoke(nameof(DebugClearJump), 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            acceleration = true;
            character.OnAcceleration(true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            acceleration = false;
            character.OnAcceleration(false);
        }


        if (Input.GetKeyDown(KeyCode.C))
        {
            crouch = true;
            character.OnCrouch(true);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            crouch = false;
            character.OnCrouch(false);
        }
    }


}
