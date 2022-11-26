using System.Collections;
using UnityEngine;

public class Initialiser : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private Look cameraLook;
    [SerializeField] private PlayerControl playerControl;

    private void Start()
    {
        cameraLook.Initialise(inputHandler as IMouseInput);
        playerControl.Initialise(inputHandler as IMouseInput);
    }

}