using System.Collections;
using UnityEngine;

public class Rotation : MonoBehaviour
{
	[SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private float speedRotation = 150;

    private WaitForEndOfFrame WaitForEndOfFrame;
    private Vector3 rotateDirection;

    public void Initialise()
    {
        WaitForEndOfFrame = new WaitForEndOfFrame();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX |
                                RigidbodyConstraints.FreezeRotationY |
                                RigidbodyConstraints.FreezeRotationZ;
    }

    public void StartRotation(Vector3 value)
	{
		StopAllCoroutines();
        rotateDirection = transform.eulerAngles + (new Vector3(value.y, value.x, value.z) * speedRotation);
        StartCoroutine(OnRotation());
	}

    private IEnumerator OnRotation()
    {
        while (Round(transform.eulerAngles.y) != Round(rotateDirection.y))
        {
            transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, rotateDirection, speedRotation * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

            yield return WaitForEndOfFrame;
        }
    }

    private float Round(float value)
    {
        value = (float)System.Math.Round(value, 2);

        return value;
    }

}
