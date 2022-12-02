using System.Collections;
using UnityEngine;

public class Initialiser : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private PlayerControl playerControl;

    private void Start()
    {
        playerControl.Initialise(inputHandler as IMouseInput);
    }

}