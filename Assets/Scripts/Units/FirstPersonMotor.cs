using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMotor : CharacterMotor
{
	[SerializeField] private float speedMove = 400;
	[SerializeField] private float speedRotation = 400;

	private Vector3 rotation;

	protected override void Moving()
    {
		Vector3 direction = moveDirection;
		if (acceleration) direction *= 2;
		if (isGrounded && Time.deltaTime > 0)
		{
			rigidbody.velocity = transform.TransformDirection(direction * speedMove * Time.deltaTime);
		}
	}

    protected override void Rotation()
	{
		rotation += rotateDirection * speedRotation * Time.deltaTime;
		rigidbody.rotation = Quaternion.Euler(0, rotation.y, 0);
	}

}
