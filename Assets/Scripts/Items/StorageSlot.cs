[System.Serializable]
public partial class StorageSlot
{
    public string name;
    private IItem item;
    public IItem Item => item;
    public readonly int index;

    public void AddItem(IItem value)
    {
        item = value;
        name = item.GetName();
    }

}

