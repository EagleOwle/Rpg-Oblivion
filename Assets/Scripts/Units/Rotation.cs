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
    }

    public void StartRotation(Vector3 value)
	{
		StopAllCoroutines();
        rotateDirection = transform.eulerAngles + (new Vector3(value.y, value.x, value.z) * speedRotation);
        StartCoroutine(OnRotation());
	}

    private IEnumerator OnRotation()
    {
        while (Mathf.RoundToInt(transform.eulerAngles.y) != Mathf.RoundToInt(rotateDirection.y))
        {
            transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, rotateDirection, speedRotation * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

            yield return WaitForEndOfFrame;
        }
    }

}
