using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudSlotItem : MonoBehaviour
{
    [SerializeField] private Sprite empty;
    [SerializeField] private Image image;
    [SerializeField] private Button button;

    private int configIndex;

    public bool IsEmpty
    {
        get
        {
            if(configIndex < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public void Initialise()
    {
        configIndex = -1;
        button.onClick.AddListener(OnButton);
    }

    public void ChangeItem(int configIndex)
    {
        if (configIndex < 0)
        {
            Clear();
        }
        else
        {
            this.configIndex = configIndex;
            Sprite sprite = ConfigStorage.Instance.configItem.configsWeapon[configIndex].sprite;
            image.sprite = sprite;
        }
    }

    private void Clear()
    {
        configIndex = -1;
        image.sprite = empty;
    }

    private void OnButton()
    {
        
    }

}
