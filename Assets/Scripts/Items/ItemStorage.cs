using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class ItemStorage : MonoBehaviour
{
    public Action<int> InitSetActive;

    [SerializeField] private int storageCount = 5;
    [SerializeField] private List<StorageSlot> slots;

    private IItemListener itemListener;

    public void Initialise(IItemListener itemListener)
    {
        this.itemListener = itemListener;

        //int indexConfig = UnityEngine.Random.Range(0, ConfigStorage.Instance.configItem.configsWeapon.Count);

        int emptySlotIndex;

        AddItemToEmptySlot(0, out emptySlotIndex);

        AddItemToEmptySlot(1, out emptySlotIndex);

        AddItemToEmptySlot(2, out emptySlotIndex);
    }

    private bool AddItemToEmptySlot(int configItemIndex, out int emptySlotIndex)
    {
        emptySlotIndex = -1;
        for (int i = 0; i < slots.Count; i++)
        {
            if(slots[i].Item == null)
            {
                emptySlotIndex = i;
                slots[i].AddItem(configItemIndex);
                itemListener.OnChangeItem(configItemIndex, emptySlotIndex);
                return true;
            }
        }

        return false;
    }

    private void SetActiveSlot(int index)
    {
        if (slots.Count <= index) return;
        if (slots[index].Item == null) return;

        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsActive)
            {
                if(i == index)
                {
                    InitSetActive.Invoke(-1);
                }

                slots[i].IsActive = false;
            }
            else
            {
                slots[index].IsActive = true;
                InitSetActive.Invoke(slots[index].ConfigItemIndex);
            }
        } 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetActiveSlot(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetActiveSlot(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetActiveSlot(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetActiveSlot(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetActiveSlot(4);
        }
    }

}
