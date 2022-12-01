using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjectHandler : MonoBehaviour
{
    [SerializeField] private ScreenObject screenObjectPrefab;
    private List<ScreenObject> screenObjects =  new List<ScreenObject>();

    private void Initialise()
    {
        screenObjects = new List<ScreenObject>();
    }

    public void AddSceneObject(ItemScene itemScene)
    {
        ScreenObject screenObject = Instantiate(screenObjectPrefab, transform);
        screenObject.itemScene = itemScene;
        screenObjects.Add(screenObject);
        screenObject.gameObject.SetActive(true);
    }

}
