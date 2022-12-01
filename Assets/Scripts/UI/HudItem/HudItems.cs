using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IItemListener
{
    void OnChangeItem(int configIndex, int slotIndex);
}

public partial class HudItems : MonoBehaviour, IItemListener
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

    public void OnChangeItem(int configIndex, int slotIndex)
    {
        slotImage[slotIndex].ChangeItem(configIndex);
    }

}
