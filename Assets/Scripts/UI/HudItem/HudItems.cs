using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class HudItems : MonoBehaviour, ISlotStorageListener
{
    [SerializeField] private HudSlotItem[] slotImage;

    public void Initialise()
    {
        slotImage = GetComponentsInChildren<HudSlotItem>();
        foreach (var item in slotImage)
        {
            item.Initialise();
        }
    }

    public void OnChangeSlotItem(int configIndex, int slotIndex)
    {
        slotImage[slotIndex].ChangeItem(configIndex);
    }

}
