using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemListener
{
    public void OnChangeItem(int slotIndex, IItem item);
}

public partial class HudItem : MonoBehaviour, IItemListener
{
    public void OnChangeItem(int slotIndex, IItem item)
    {
        throw new System.NotImplementedException();
    }


}
