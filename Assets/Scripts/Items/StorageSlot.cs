using UnityEngine;

[System.Serializable]
public partial class StorageSlot
{
    [SerializeField] private string name;

    private IItem item;
    public IItem Item => item;

    private int configItemIndex;
    public int ConfigItemIndex => configItemIndex;

    private bool isActive;
    public bool IsActive
    {
        get
        {
            return isActive;
        }

        set
        {
            isActive = value;
        }
    }

    public void AddItem(int configItemIndex)
    {
        this.configItemIndex = configItemIndex;
        item = ConfigStorage.Instance.configItem.configsWeapon[configItemIndex].weaponPrefab as IItem;
        name = item.GetName();
    }

    public void RemoveItem()
    {
        configItemIndex = -1;
        isActive = false;
        item = null;
        name = "None";
    }

}

