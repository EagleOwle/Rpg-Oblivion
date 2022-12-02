using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Hud : MonoBehaviour
{
    [SerializeField] private HudItems hudItem;
    [SerializeField] private SceneObjectHandler sceneObjectHandler;
    public HudItems HudItems => hudItem;

    public void Initialise()
    {
        hudItem.Initialise();
        sceneObjectHandler.Initialise();
    }

}
