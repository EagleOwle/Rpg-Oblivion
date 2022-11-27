using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour, IGroundCheck
{
	[SerializeField] private float groundCheckDistance = 0.1f;
	[SerializeField] private bool debugIsGrounded;

    [SerializeField] private Motion motion;
    [SerializeField] private Rotation rotation;
    [SerializeField] private Jumping jumping;
    [SerializeField] private Crouching crouching;

    private void Start()
    {
        motion.Initialise(this as IGroundCheck);
        jumping.Initialise(this as IGroundCheck);
        rotation.Initialise();

        CrouchListener[] crouchListeners = GetComponentsInChildren<CrouchListener>();
        crouching.Initialise(this as IGroundCheck, crouchListeners);
    }

    public void OnJump()
    {
        jumping.Jump();
    }

    public void OnCrouch(bool crouch)
    {
        crouching.OnCrouch(crouch);
    }

    public void OnAcceleration(bool acceleration)
    {
        motion.OnAcceleration(acceleration);
    }

    public void Move(Vector3 moveDirection)
    {
        if (moveDirection.magnitude > 1f) moveDirection.Normalize();
        motion.StartMove(new Vector3(moveDirection.x, 0, moveDirection.y));
    }

    public void Rotation(Vector3 value)
    {
        rotation.StartRotation(value);
    }

    bool IGroundCheck.CheckGroundStatus()
    {
		RaycastHit hitInfo;
#if UNITY_EDITOR
		Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * groundCheckDistance));
#endif
		if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, groundCheckDistance))
		{
			debugIsGrounded = true;
			return true;
		}
		else
		{
			debugIsGrounded = false;
			return false;
		}
	}

    [System.Serializable]
    public class EventBool : UnityEvent<bool> { };

    [System.Serializable]
    public class EventVector3 : UnityEvent<Vector3> { };
}
