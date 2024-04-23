[System.Serializable]
public class SerializedQuestData
{
    public string GUID;
    public QuestStatus QuestStatus;

    public SerializedQuestData(string GUID, QuestStatus QuestStatus)
    {
        this.GUID = GUID;
        this.QuestStatus = QuestStatus;
    }
}
