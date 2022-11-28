using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPausePanel : Menu
{
    public event Action<Menu> eventHide;
    public event Action<Menu> eventShow;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button returnButton;
    [SerializeField] private Button preferenceButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private UIPreferencePanel uiPreferencePanel;
    [SerializeField] private UIMenuExit uiMenuExit;

    //public void Initialise(GamePreference setting)
    //{
    //    restartButton.onClick.AddListener(OnButtonRestart);
    //    returnButton.onClick.AddListener(OnButtonReturn);
    //    preferenceButton.onClick.AddListener(OnButtonPreference);
    //    exitButton.onClick.AddListener(OnButtonExit);
    //    uiMenuExit.Initialise();
    //    uiPreferencePanel.Initialise(setting);
    //}

    public void Initialise()
    {
        restartButton.onClick.AddListener(OnButtonRestart);
        returnButton.onClick.AddListener(OnButtonReturn);
        preferenceButton.onClick.AddListener(OnButtonPreference);
        exitButton.onClick.AddListener(OnButtonExit);
        uiMenuExit.Initialise();
        uiPreferencePanel.Initialise();
    }

    private void OnButtonRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnButtonReturn()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        eventHide?.Invoke(this);
        Hide();

    }

    public override void Show()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        base.Show();
    }

    private void OnButtonPreference()
    {
        uiPreferencePanel.Show();
    }

    private void OnButtonExit()
    {
        uiMenuExit.Show();
    }

}
