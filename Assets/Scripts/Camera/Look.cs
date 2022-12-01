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
    private Vector2 rotation;

    public void Initialise(IMouseInput IMouseInput)
    {
        IMouseInput.EventOnMouseAxis += IMouseInput_EventOnMouseAxis;
    }

    private void IMouseInput_EventOnMouseAxis(Vector2 value)
    {
        inputValue = value;
    }

    private void Update()
    {
        if (onlyHideCursor && Cursor.visible == true) return;

        //rotation = Vector3.Lerp(rotation, rotation + inputValue, speedRotation * Time.deltaTime);
        rotation += inputValue * speedRotation * Time.deltaTime;
        rotation.x = ClampAngle(rotation.x, minimumX, maximumX);
        rotation.y = ClampAngle(rotation.y, minimumY, maximumY);
        transform.localRotation = Quaternion.Euler(-rotation.y, rotation.x, 0f);

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



}
