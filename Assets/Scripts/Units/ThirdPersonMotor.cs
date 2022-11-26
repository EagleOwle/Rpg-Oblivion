using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]

public class ThirdPersonMotor : CharacterMotor
{
	[SerializeField] private  float animSpeedMultiplier = 1;
	[SerializeField] private  float moveSpeedMultiplier = 1;
	private const string animForward = "Forward";
	private const string animTurn = "Turn";
	private const string animCrouch = "Crouch";
	private const string animOnGround = "OnGround";
	private const string animOnJump = "Jump";

	public override void Move(Vector2 move, bool crouch, bool jump, bool acceleration)
	{
		base.Move(move, crouch, jump, acceleration);

		UpdateAnimator(move);
	}

	private void UpdateAnimator(Vector3 move)
	{
		animator.SetFloat(animForward, move.y, 0.1f, Time.deltaTime);
		animator.SetFloat(animTurn, move.x, 0.1f, Time.deltaTime);
		animator.SetBool(animCrouch, crouching);
		animator.SetBool(animOnGround, isGrounded);

		if (!isGrounded)
		{
			animator.SetFloat(animOnJump, rigidbody.velocity.y);
		}

		if (isGrounded && move.magnitude > 0)
		{
			animator.speed = animSpeedMultiplier;
		}
		else
		{
			animator.speed = 1;
		}
	}

	public void OnAnimatorMove()
	{
		if (isGrounded && Time.deltaTime > 0)
		{
			Vector3 velocity = (animator.deltaPosition * moveSpeedMultiplier) / Time.deltaTime;

			velocity.y = rigidbody.velocity.y;
			rigidbody.velocity = velocity;
		}
	}

    protected override void Moving()
    {
        throw new System.NotImplementedException();
    }

    protected override void Rotation()
    {
        throw new System.NotImplementedException();
    }
}
