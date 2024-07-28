[System.Serializable]
public class SerializedItem 
{
    public string GUID;
    public int ItemId;
    public int ItemAmout;

    public SerializedItem(string GUID, ItemStack item)
    {
        this.GUID = GUID;
        ItemId = item.Item.Id;
        ItemAmout = item.Amount;
    }
}
