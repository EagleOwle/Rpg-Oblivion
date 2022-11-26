using UnityEngine;

public class Motion : MonoBehaviour
{
	[SerializeField] private new Rigidbody rigidbody;
	[SerializeField] private float speedMove = 400;
	private bool crouching;
	private bool acceleration;
	private Vector3 moveDirection;

	private IGroundCheck groundCheck;

	public void Initialise(IGroundCheck groundCheck)
    {
		this.groundCheck = groundCheck;
	}

	private void FixedUpdate()
	{
		Moving();
	}

	public void Move(Vector2 move)
	{
		if (move.magnitude > 1f) move.Normalize();
		moveDirection = new Vector3(move.x, 0, move.y);
	}

	public void Move(Vector2 move, bool crouch, bool jump, bool acceleration)
	{
		if (move.magnitude > 1f) move.Normalize();
		moveDirection = new Vector3(move.x, 0, move.y);
		this.acceleration = acceleration;
	}

	private void Moving()
	{
		Vector3 direction = moveDirection;
		if (acceleration) direction *= 2;
		if (groundCheck.CheckGroundStatus() && Time.deltaTime > 0)
		{
			rigidbody.velocity = transform.TransformDirection(direction * speedMove * Time.deltaTime);
		}
	}
}
