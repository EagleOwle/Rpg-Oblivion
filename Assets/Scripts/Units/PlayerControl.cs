using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Character character;

    private Vector3 move;
    private Vector3 rotate;
    private bool acceleration;
    private bool jump;
    private bool crouch;

    public void Initialise(IMouseInput IMouseInput)
    {
        IMouseInput.EventOnMouseAxis += IMouseInput_EventOnMouseAxis;
        IMouseInput.EventOnKeyboardAxis += IMouseInput_EventOnKeyboardAxis;
        IMouseInput.EventOnJump += IMouseInput_EventOnJump;
        IMouseInput.EventOnCrouch += IMouseInput_EventOnCrouch;
        IMouseInput.EventOnAcceleration += IMouseInput_EventOnAcceleration;
    }

    private void IMouseInput_EventOnMouseAxis(Vector2 value)
    {
        rotate = value;
        character.Rotation(value);
    }

    private void IMouseInput_EventOnAcceleration(bool value)
    {
        acceleration = value;
        character.OnAcceleration(value);
    }

    private void IMouseInput_EventOnCrouch(bool value)
    {
        crouch = value;
        character.OnCrouch(value);
    }

    private void IMouseInput_EventOnJump()
    {
        jump = true;
        character.OnJump();
        Invoke(nameof(DebugClearJump), 0.1f);
    }

    private void IMouseInput_EventOnKeyboardAxis(Vector2 value)
    {
        move = value;
        character.Move(value);
    }

    private void DebugClearJump()
    {
        jump = false;
    }

}
