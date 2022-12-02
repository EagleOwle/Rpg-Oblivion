using System.Collections;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] RotateAxis rotateAxisX, rotateAxisY;

    public void Initialise()
    {
        rotateAxisX.Initialise(this);
        rotateAxisY.Initialise(this);
    }

    public void StartRotation(Vector3 value)
    {
        rotateAxisX.Rotation(-value.y);
        rotateAxisY.Rotation(value.x);
    }

}
