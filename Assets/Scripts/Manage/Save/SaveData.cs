using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public string SaveName;
    public readonly string GUID;
    public CharacterPrefapSO _currentCharacter;
    public SceneSO CurrentScene;
    [Header("Player Location")]
    public Vector3 Position;
    public Quaternion Rotation;

    public List<SerializedItem> ItemData;
    public List<SerializedQuestList> QuestData;
    public List<SerializedQuestData> CurrentQuestData;
    public List<SerializedQuestData> CurrentDefaultDialogue;

    public SaveData(string SaveName)
    {
        this.SaveName = SaveName;
        GUID = Guid.NewGuid().ToString();
    }

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }


}
