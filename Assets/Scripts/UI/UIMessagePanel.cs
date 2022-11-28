using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMessagePanel : Menu
{
    [SerializeField] protected float _hidefadeTime = 0.2f;

    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button okButton;

    private List<string> queue = new List<string>();

    public void Initialise(IGlobalMessage globalMessage)
    {
        okButton.onClick.AddListener(OnButtonOk);
        globalMessage.message += GlobalMessage_message;
    }

    private void GlobalMessage_message(object sender, string e)
    {
        queue.Add(e);
        if (gameObject.activeSelf == false)
        {
            ShowNext();
        }
    }

    private void OnButtonOk()
    {
        ShowNext();
    }

    private void ShowNext()
    {
        if (queue.Count > 0)
        {
            Show(queue[0]);
            queue.RemoveAt(0);
           // if (queue.Count > 0) Debug.Log("queue count= " + queue.Count);
        }
        else
        {
            Hide();
        }
    }

    public void Show(string message)
    {
        base.Show();
        messageText.text = message;
        Time.timeScale = 0;
    }

    public override void Hide()
    {
        Time.timeScale = 1;
        base.Hide(_hidefadeTime);
    }

}
