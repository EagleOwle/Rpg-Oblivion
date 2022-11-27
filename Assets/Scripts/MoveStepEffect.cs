using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStepEffect : MonoBehaviour
{
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private bool jiggleUp = true;
    [SerializeField] private bool jiggleRight = true;
    [SerializeField] private float amplitude = 0.1f;
    [SerializeField] private float speed = 1;

    private float defaultPositionY;
    private float defaultPositionX;

    private void Start()
    {
        defaultPositionY = transform.localPosition.y;    
        defaultPositionX = transform.localPosition.x;    
    }

    private void LateUpdate()
    {
        if (rigidbody.velocity.magnitude < 1) return;

        float y = defaultPositionY;
        float x = defaultPositionX;

        if (jiggleUp)
        {
            y = defaultPositionY + Mathf.PingPong(Time.time * speed, amplitude) - amplitude / 2f;
        }

        if (jiggleRight)
        {
            x = defaultPositionX + Mathf.PingPong(Time.time * speed, amplitude) - (-amplitude);
        }

        transform.localPosition = new Vector3(x, y, transform.localPosition.z);

    }


}
