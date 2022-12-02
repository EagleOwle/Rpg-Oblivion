using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class ItemStorage : MonoBehaviour, IItemActionListener
{
    public Action<int> actionSetActiveSlot;

    [SerializeField] private int storageCount = 5;
    [SerializeField] private List<StorageSlot> slots;

    private ISlotStorageListener slotListener;

    public void Initialise(ISlotStorageListener slotListener)
    {
        this.slotListener = slotListener;

        foreach (var item in slots)
        {
            item.RemoveItem();
        }


        //int emptySlotIndex;

        //AddItemToEmptySlot(0, out emptySlotIndex);

        //AddItemToEmptySlot(1, out emptySlotIndex);

        //AddItemToEmptySlot(2, out emptySlotIndex);

        //AddItemToEmptySlot(0, out emptySlotIndex);

        //AddItemToEmptySlot(1, out emptySlotIndex);

        //AddItemToEmptySlot(2, out emptySlotIndex);

    }

    public bool Pickup(int configIndex)
    {
        return AddItemToEmptySlot(configIndex, out int emptySlotIndex);
    }

    public void DropActiveItem()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsActive)
            {
                ItemScene prefab = ConfigStorage.Instance.configItem.configsWeapon[slots[i].ConfigItemIndex].itemScenePrefab;
                Vector3 position = Camera.main.transform.TransformDirection(Vector3.forward);
                ItemScene item = Instantiate(prefab, transform.position + position + Vector3.up, Quaternion.identity);
                Rigidbody rigidbody = item.GetComponent<Rigidbody>();

                rigidbody.AddForce(Camera.main.transform.TransformDirection(Vector3.forward + Vector3.up) * 100);
                rigidbody.AddTorque((Vector3.forward + Vector3.up) * 50);

                slots[i].RemoveItem();
                slotListener.OnChangeSlotItem(-1, i);
                actionSetActiveSlot.Invoke(-1);

                return;
            }
        }
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
                slotListener.OnChangeSlotItem(configItemIndex, emptySlotIndex);
                return true;
            }
        }

        return false;
    }

    private void SetActiveSlot(int index)
    {
        if (index >= slots.Count) return;
        if (slots[index].Item == null) return;

        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsActive)
            {
                if(i == index)
                {
                    actionSetActiveSlot.Invoke(-1);
                }

                slots[i].IsActive = false;
            }
            else
            {
                if (i == index)
                {
                    slots[i].IsActive = true;
                    actionSetActiveSlot.Invoke(slots[i].ConfigItemIndex);
                }
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

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            DropActiveItem();
        }
    }

}
