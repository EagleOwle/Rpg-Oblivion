using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float rotationSpeedMouse = 5;
    [SerializeField] private float zoomSpeedMouse = 10;
    [SerializeField] private Vector3 targetOffset;

    private const float _smoothness = 0.5f;
    private const float _maxToClampMouse = 10;

    private Vector2 mouseAxis;
    private float scroll;
    private Vector3 cameraOffset;
    private float _zoomAmountMouse = 0;

    public void Initialise(IMouseInput IMouseInput)
    {
        IMouseInput.EventOnMouseAxis += IMouseInput_EventOnMouseAxis;
        IMouseInput.EventOnMouseScroll += IMouseInput_EventOnMouseScroll;
        cameraOffset = transform.position - target.position;
        transform.LookAt(target);
    }

    private void Update()
    {
        RotationX(mouseAxis.y);
        RotationY(mouseAxis.x);
    }

    private void IMouseInput_EventOnMouseAxis(Vector2 value)
    {
        mouseAxis = value;
    }

    private void IMouseInput_EventOnMouseScroll(float value)
    {
        scroll = value;
        Zoom();
    }

    private void RotationY(float axisX)
    {
        Quaternion camAngle = Quaternion.AngleAxis(axisX * rotationSpeedMouse, Vector3.up);

        Vector3 newPos = target.position + cameraOffset;
        cameraOffset = camAngle * cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, _smoothness);
        transform.LookAt(target.position + targetOffset);
    }

    private void RotationX(float axisY)
    {
        Quaternion camAngle = Quaternion.AngleAxis(axisY * rotationSpeedMouse, Vector3.left);

        Vector3 newPos = target.position + cameraOffset;
        cameraOffset = camAngle * cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, _smoothness);
        transform.LookAt(target.position + targetOffset);
    }

    private void Zoom()
    {
        _zoomAmountMouse += scroll;
        _zoomAmountMouse = Mathf.Clamp(_zoomAmountMouse, -_maxToClampMouse, _maxToClampMouse);

        var translate = Mathf.Min(Mathf.Abs(scroll), _maxToClampMouse - Mathf.Abs(_zoomAmountMouse));
        transform.Translate(0, 0, translate * zoomSpeedMouse * Mathf.Sign(scroll));

        cameraOffset = transform.position - target.position;
    }

}
