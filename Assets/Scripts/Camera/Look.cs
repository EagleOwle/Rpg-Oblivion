using UnityEngine;
using System.Collections;

public class Look : MonoBehaviour
{
    [SerializeField] private bool onlyHideCursor;

    [SerializeField] private float speedRotation = 50;
    [SerializeField] private float minimumX = -360f;
    [SerializeField] private float maximumX = 360f;
    [SerializeField] private float minimumY = -45f;
    [SerializeField] private float maximumY = 45f;

    private Vector2 inputValue;
    private Vector2 rotateDirection;

    public void Initialise(IMouseInput IMouseInput)
    {
        IMouseInput.EventOnMouseAxis += IMouseInput_EventOnMouseAxis;
    }

    private void IMouseInput_EventOnMouseAxis(Vector2 value)
    {
        inputValue = value;
        StartRotation(value);
    }

    public void StartRotation(Vector3 value)
    {
        value = new Vector3(value.y, value.x, value.z);
        rotateDirection = transform.eulerAngles + (value * speedRotation);
        //if (isRotation == false)
            //StartCoroutine(OnRotation());
    }

    bool isRotation = false;
    private IEnumerator OnRotation()
    {
        isRotation = true;
        while (Round(transform.eulerAngles.y) != Round(rotateDirection.y))
        {
           Vector3 rotation = Vector3.MoveTowards(transform.eulerAngles, rotateDirection, speedRotation * Time.deltaTime);
            rotation.x = ClampAngle(rotation.x, minimumX, maximumX);
            rotation.y = ClampAngle(rotation.y, minimumY, maximumY);
            transform.rotation = Quaternion.Euler(rotation.x, 0, 0);

            yield return new WaitForEndOfFrame();
        }
        isRotation = false;
    }

    private float ClampAngle(float angle, float min, float max)
    {
        angle = angle % 360;
        if ((angle >= -360f) && (angle <= 360f))
        {
            if (angle < -360f)
            {
                angle += 360f;
            }
            if (angle > 360f)
            {
                angle -= 360f;
            }
        }
        return Mathf.Clamp(angle, min, max);
    }

    private float Round(float value)
    {
        value = (float)System.Math.Round(value, 4);

        return value;
    }

}
