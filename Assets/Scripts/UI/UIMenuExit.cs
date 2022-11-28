using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuExit : Menu
{
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    public void Initialise()
    {
        yesButton.onClick.AddListener(OnButtonYes);
        noButton.onClick.AddListener(OnButtonNo);
    }

    private void OnButtonYes()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID
        Application.Quit();
#elif UNITY_IOS
         Application.Quit();
#endif
    }

    private void OnButtonNo()
    {
        Hide();
    }

}
