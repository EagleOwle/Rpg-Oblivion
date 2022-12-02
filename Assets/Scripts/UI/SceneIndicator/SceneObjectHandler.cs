using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjectHandler : MonoBehaviour
{
    private List<ScreenObject> screenObjects;

    public void Initialise()
    {
        screenObjects = new List<ScreenObject>();
    }

    public void AddSceneObject(ItemScene itemScene)
    {
        for (int i = 0; i < screenObjects.Count; i++)
        {
            if (screenObjects[i].Item == itemScene)
            {
                screenObjects[i].ReInitialise();
                return;
            }
        }

        ScreenObject screenObject = Instantiate(ConfigStorage.Instance.prefabs.screenObjectPrefab, transform);
        screenObject.eventHide += ScreenObject_eventHide;
        screenObjects.Add(screenObject);
        screenObject.Initialise(itemScene);
    }

    private void ScreenObject_eventHide(ScreenObject screenObject)
    {
        screenObjects.Remove(screenObject);
        Destroy(screenObject.gameObject);
    }

}
