using UnityEngine;

public class Character : MonoBehaviour, IGroundCheck
{
	[SerializeField] private float groundCheckDistance = 0.1f;
	[SerializeField] private Motion motion;
	[SerializeField] private Rotation rotation;

	[SerializeField] private bool debugIsGrounded;

    private void Start()
    {
		motion.Initialise(this as IGroundCheck);

	}

    public void SetMotion(Vector3 move, Vector3 rotate, bool jump, bool crouch, bool acceleration)
    {
		motion.Move(move);
		rotation.Rotate(rotate);
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
}
