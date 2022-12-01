using UnityEngine;
using System.Collections;
using System;

public class LookAtItem : MonoBehaviour
{
    [SerializeField] private SceneObjectHandler sceneObjectHandler;
    [SerializeField] private float lookDistance = 10;
    [SerializeField] private LayerMask itemLayer;
    private RaycastHit hitInfo;
    private Ray ray;

    private void Start()
    {
        StartCoroutine(Look());
    }

    private IEnumerator Look()
    {
        while (true)
        {
            ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, lookDistance, itemLayer))
            {
               if( hitInfo.collider.TryGetComponent(out ItemScene itemScene))
                {
                    sceneObjectHandler.AddSceneObject(itemScene);
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
