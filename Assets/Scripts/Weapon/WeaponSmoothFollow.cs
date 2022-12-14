using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSmoothFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float damping = 2.0f;

    public void LateUpdate()
    {
        if (!target) return;

        transform.position = Vector3.Lerp(transform.position, target.position, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, damping * Time.deltaTime);

    }

    //public void OnAnimatorMove()
    //{
    //    if (!target) return;

    //    transform.position = Vector3.Lerp(transform.position, target.position, damping * Time.deltaTime);
    //    transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, damping * Time.deltaTime);

    //}
}
