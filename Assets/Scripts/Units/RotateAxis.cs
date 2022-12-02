using System.Collections;
using UnityEngine;

public enum Axis
{
    X,
    Y,
    Disable
}

[System.Serializable]
public class RotateAxis
{
    [SerializeField] private Axis axis;
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float minimum = -360f;
    [SerializeField] private float maximum = 360f;

    private MonoBehaviour mono;
    private float ratateValue;
    private bool isRotate = false;
    private WaitForEndOfFrame waitForEndOfFrame;

    public void Initialise(MonoBehaviour mono)
    {
        this.mono = mono;
        this.waitForEndOfFrame = new WaitForEndOfFrame();
    }

    public void Rotation(float value)
    {
        switch (axis)
        {
            case Axis.X:
                ratateValue = target.eulerAngles.x + value;
                if(isRotate == false) mono.StartCoroutine(RotateX());
                break;

            case Axis.Y:
                ratateValue = target.eulerAngles.y + value;
                if (isRotate == false) mono.StartCoroutine(RotateY());
                break;
            default:
                break;
        }

    }

    private IEnumerator RotateX()
    {
        isRotate = true;
        while (Round(target.eulerAngles.x) != Round(ratateValue))
        {
            float tmp = Mathf.MoveTowards(target.eulerAngles.x, ratateValue, speed * Time.deltaTime);
            tmp = ClampAngle(tmp, minimum, maximum);

            target.rotation = Quaternion.Euler(tmp, target.eulerAngles.y, target.eulerAngles.z);
            yield return waitForEndOfFrame;
        }

        isRotate = false;
    }

    private IEnumerator RotateY()
    {
        isRotate = true;
        while (Round(target.eulerAngles.y) != Round(ratateValue))
        {
            float tmp = Mathf.MoveTowards(target.eulerAngles.y, ratateValue, speed * Time.deltaTime);
            tmp = ClampAngle(tmp, minimum, maximum);
            target.rotation = Quaternion.Euler(target.eulerAngles.x, tmp, target.eulerAngles.z);
            yield return waitForEndOfFrame;
        }

        isRotate = false;
    }

    private float ClampAngle(float angle, float from, float to)
    {
        if (angle < 0f) angle = 360 + angle;
        if (angle > 180f) return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    }

    private float Round(float value)
    {
        value = (float)System.Math.Round(value, 2);

        return value;
    }

    #region Debug
    //public void Update()
    //{
    //    switch (axis)
    //    {
    //        case Axis.X:
    //            UpdateRotateX();
    //            break;

    //        case Axis.Y:
    //            UpdateRotateY();
    //            break;
    //        default:
    //            break;
    //    }
    //}

    //private void UpdateRotateX()
    //{
    //    float tmp = Mathf.MoveTowards(target.eulerAngles.x, ratateValue, speed * Time.deltaTime);
    //    tmp = ClampAngle(tmp, minimum, maximum);
    //    target.rotation = Quaternion.Euler(tmp, target.eulerAngles.y, target.eulerAngles.z);
    //}

    //private void UpdateRotateY()
    //{
    //    float tmp = Mathf.MoveTowards(target.eulerAngles.y, ratateValue, speed * Time.deltaTime);
    //    tmp = ClampAngle(tmp, minimum, maximum);
    //    target.rotation = Quaternion.Euler(target.eulerAngles.x, tmp, target.eulerAngles.z);
    //}

    #endregion

}