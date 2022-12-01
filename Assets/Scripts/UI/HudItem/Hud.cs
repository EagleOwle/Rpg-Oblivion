using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Hud : MonoBehaviour
{
    [SerializeField] private HudItems hudItem;
    public HudItems HudItems => hudItem;

    public void Initialise()
    {
        hudItem.Initialise();
    }

}
