using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public abstract class CharacterMotor : MonoBehaviour
{
	[SerializeField] protected float groundCheckDistance = 0.1f;

	protected new Rigidbody rigidbody;
	protected Animator animator;

	protected bool isGrounded;
	protected bool crouching;
	protected bool acceleration;
	protected Vector3 moveDirection;
	protected Vector3 rotateDirection;

	public void Initialise()
	{
		animator = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody>();

		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

	}

	protected virtual void FixedUpdate()
	{
		CheckGroundStatus();
		Moving();
	}

	protected virtual void Update()
	{
		Rotation();
	}

	protected abstract void Moving();

	protected abstract void Rotation();

	public virtual void Move(Vector2 move, bool crouch, bool jump, bool acceleration)
	{
		if (move.magnitude > 1f) move.Normalize();
		moveDirection = new Vector3(move.x, 0, move.y);
		this.acceleration = acceleration;
	}

	public virtual void Rotate(Vector3 value)
	{
		if (value.magnitude > 1f) value.Normalize();
		rotateDirection = new Vector3(value.y, value.x, value.z);
	}

	protected void CheckGroundStatus()
	{
		RaycastHit hitInfo;
#if UNITY_EDITOR
		Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * groundCheckDistance));
#endif
		if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, groundCheckDistance))
		{
			isGrounded = true;
			animator.applyRootMotion = true;
		}
		else
		{
			isGrounded = false;
			animator.applyRootMotion = false;
		}
	}

}
