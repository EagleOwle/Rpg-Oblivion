using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjectHanter : MonoBehaviour
{
    [SerializeField] private SceneObjectHandler sceneObjectHandler;

    private void OnTriggerEnter(Collider other)
    {
        ////Debug.Log(gameObject.name + " OnTriggerEnter: " + other.gameObject.name);

        //if (other.TryGetComponent(out ISceneObject itemScene))
        //{
        //    sceneObjectHandler.AddSceneObject(itemScene);
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        ////Debug.Log(gameObject.name + " OnTriggerExit: " + other.gameObject.name);
        //if (other.TryGetComponent(out ISceneObject itemScene))
        //{
        //    //sceneObjectHandler.RemoveSceneObject(itemScene);
        //}

    }
}
