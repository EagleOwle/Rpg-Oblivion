using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPreferencePanel : Menu
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Toggle toggle;

    private GamePreference setting;

    //public void Initialise(GamePreference setting)
    //{
    //    this.setting = setting;
    //    closeButton.onClick.AddListener(OnButtonClose);
    //    toggle.onValueChanged.AddListener(OnToggleChange);
    //    toggle.isOn = setting.applicationSetting.showDebug;
    //}

    public void Initialise()
    {
        closeButton.onClick.AddListener(OnButtonClose);
        //toggle.onValueChanged.AddListener(OnToggleChange);
        // toggle.isOn = setting.applicationSetting.showDebug;
    }

    private void OnToggleChange(bool value)
    {
        setting.applicationSetting.showDebug = value;
    }

    private void OnButtonClose()
    {
        Hide();
    }

}
