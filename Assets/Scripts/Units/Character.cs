using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour, IGroundCheck
{
	[SerializeField] private float groundCheckDistance = 0.15f;
	[SerializeField] private bool debugIsGrounded;

    [SerializeField] private CharacterController characterController;

    [SerializeField] private Motion motion;
    [SerializeField] private Rotation rotation;
    [SerializeField] private Jumping jumping;
    [SerializeField] private Crouching crouching;
    [SerializeField] private ItemStorage itemStorage;
    [SerializeField] private HudItem hudItem;

    private void Start()
    {
        motion.Initialise(this as IGroundCheck);
        jumping.Initialise(this as IGroundCheck);
        rotation.Initialise();
        itemStorage.Initialise(hudItem as IItemListener);

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
        return CapsuleObstacleFromBelow();
    }

    private bool CapsuleObstacleFromBelow()
    {
        float radius = characterController.radius;
        Ray ray = new Ray(transform.position + Vector3.up, Vector3.down);

        if (Physics.SphereCast(ray, radius, groundCheckDistance, Physics.AllLayers, QueryTriggerInteraction.Ignore))
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

    bool LineObstacleFromBelow()
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
