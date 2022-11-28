using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameMenuManager : MonoBehaviour
{
    //[SerializeField] private GamePreference setting;
    //[SerializeField] private UIGameTopPanel topPanel;
    //[SerializeField] private UIGameButtomPanel buttomPanel;
    [SerializeField] private UIPausePanel pausePanel;
    //[SerializeField] private UIMessagePanel messagePanel;
    [SerializeField] private TextMeshProUGUI supportText;

    //public void Initialise(IPlayerGetData playerData, IGlobalMessage globalMessage)
    //{
    //    messagePanel.Initialise(globalMessage);
    //    topPanel.Initialise(playerData);
    //    pauseButton.onClick.AddListener(OnButtonPause);
    //    pausePanel.Initialise(setting);
    //}

    private void Start()
    {
        pausePanel.Initialise();
        pausePanel.eventHide += PausePanel_eventHide;
    }

    private void PausePanel_eventHide(Menu obj)
    {
        supportText.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.isActiveAndEnabled)
            {
                return;
            }
            else
            {
                pausePanel.Show();
                supportText.gameObject.SetActive(false);
            }
            
        }
    }


}
