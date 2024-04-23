using System.Collections.Generic;

[System.Serializable]
public class SerializedQuestList
{
    public string GUID;
    public List<SerializedQuestData> QuestData;

    public SerializedQuestList(string GUID, List<SerializedQuestData> QuestData)
    {
        this.GUID = GUID;
        this.QuestData = QuestData;
    }
}
