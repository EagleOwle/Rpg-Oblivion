using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
	[SerializeField] private float rotationSpeed = 300;
	[SerializeField] private float rotationSpeedMultiplier = 2;
	private Vector2 rotationInput;
	private Vector2 rotation;

	public Vector2 Rotation
	{
		set
		{
			rotationInput = value * rotationSpeedMultiplier;
		}
	}

	private void Update()
	{
		rotation = Vector3.Lerp(rotation, rotation + rotationInput, rotationSpeed * Time.deltaTime);
		transform.rotation = Quaternion.Euler(0, rotation.x, 0);
	}


}
