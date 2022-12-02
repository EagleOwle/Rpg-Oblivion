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

    private ItemScene currentItemScene;
    private IItemActionListener itemActionListener;

    public void Initialise(IItemActionListener itemActionListener)
    {
        this.itemActionListener = itemActionListener;
        StartCoroutine(Look());
    }

    private IEnumerator Look()
    {
        while (true)
        {
            ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, lookDistance, itemLayer))
            {
                if (hitInfo.collider.TryGetComponent(out ItemScene itemScene))
                {
                    itemScene.Wakeup(itemActionListener);
                    sceneObjectHandler.AddSceneObject(itemScene);
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SetCurrentItem(ItemScene itemScene)
    {
        if (currentItemScene == itemScene) return;

        currentItemScene = itemScene;
        sceneObjectHandler.AddSceneObject(itemScene);

    }

}
