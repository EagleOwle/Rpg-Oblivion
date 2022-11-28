using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIMainMenu : Menu
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    public UnityAction eventOnButtonStart;

    public void Initialise()
    {
        startButton.onClick.AddListener(OnButtonStart);
        quitButton.onClick.AddListener(OnButtonQuit);
    }

    private void OnButtonStart()
    {
        eventOnButtonStart.Invoke();
        Hide();
    }

    private void OnButtonQuit()
    {
        QuitApplication();
    }

    private void QuitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID
        Application.Quit();
          //AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
          //       activity.Call<bool>("moveTaskToBack", true);
#elif UNITY_IOS
         Application.Quit();
#else
         Application.Quit();
#endif
    }
}
