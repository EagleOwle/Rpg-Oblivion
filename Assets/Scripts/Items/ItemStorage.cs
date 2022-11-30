using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class ItemStorage : MonoBehaviour
{
    public event Action InitItemStorage;

    [SerializeField] private int storageCount = 5;
    [SerializeField] private List<StorageSlot> slots;

    private IItemListener itemListener;

    public void Initialise(IItemListener itemListener)
    {
        this.itemListener = itemListener;
        AddItem(PrefabsStorage.Instance.sword as IItem);
    }

    public bool AddItem(IItem value)
    {
        if (GetEmptySlot(out StorageSlot emptySlot))
        {
            emptySlot.AddItem(value);
            itemListener.OnChangeItem(emptySlot.index, value);
            return true;
        }

        return false;
    }

    private bool GetEmptySlot(out StorageSlot emptySlot)
    {
        emptySlot = null;

        for (int i = 0; i < slots.Count; i++)
        {
            if(slots[i].Item == null)
            {
                emptySlot = slots[i];
                return true;
            }
        }

        return false;
    }

}
