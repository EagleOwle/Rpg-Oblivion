using UnityEngine;

public class Rotation : MonoBehaviour
{
	[SerializeField] private new Rigidbody rigidbody;

	[SerializeField] private float speedRotation = 400;
	private Vector3 rotateDirection;

	private Vector3 rotation;

	public void Rotate(Vector3 value)
	{
		if (value.magnitude > 1f) value.Normalize();
		rotateDirection = new Vector3(value.y, value.x, value.z);
	}

	private void Update()
	{
		OnRotation();
	}

	private void OnRotation()
	{
		rotation += rotateDirection * speedRotation * Time.deltaTime;
		transform.rotation = Quaternion.Euler(0, rotation.y, 0);
	}
}
