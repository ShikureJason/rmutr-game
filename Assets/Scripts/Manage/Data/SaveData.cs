using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    internal string SaveName;
    internal readonly string GUID;
    internal CharacterPrefapSO CurrentCharacter;
    internal SceneSO CurrentScene;
    [Header("Player Location")]
    internal Vector3 Position;
    internal Quaternion Rotation;

    internal List<SerializedItem> ItemData = new List<SerializedItem>();
    internal List<SerializedQuestList> QuestData = new List<SerializedQuestList>();
    internal List<SerializedQuestData> CurrentQuestData = new List<SerializedQuestData>();
    internal List<SerializedQuestData> CurrentDefaultDialogue = new List<SerializedQuestData>();

    internal SaveData(string SaveName)
    {
        ItemData = new List<SerializedItem>();
        QuestData = new List<SerializedQuestList>();
        CurrentQuestData = new List<SerializedQuestData>();
        CurrentDefaultDialogue = new List<SerializedQuestData>();
        this.SaveName = SaveName;
        GUID = Guid.NewGuid().ToString();
    }

    internal string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    internal void LoadFromJson(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }

}
