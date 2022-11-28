using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIMenuController : MonoBehaviour
{
    [SerializeField] private UIMainMenu uiMainMenu;
    [SerializeField] private Menu background;

    public UnityAction eventStartMatch;

    public void Initialise()
    {
        uiMainMenu.eventOnButtonStart += StartMatch;
        uiMainMenu.Initialise();
        uiMainMenu.Show();
        background.Show();
    }

    private void StartMatch()
    {
        eventStartMatch.Invoke();
        background.Hide();
    }

}
