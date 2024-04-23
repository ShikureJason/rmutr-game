[System.Serializable]
public class SerializedItem 
{
    public string GUID;
    public int ItemId;
    public int ItemAmout;

    public SerializedItem(string GUID, int ItemId, int ItemAmout)
    {
        this.GUID = GUID;
        this.ItemId = ItemId;
        this.ItemAmout = ItemAmout;
    }
}
