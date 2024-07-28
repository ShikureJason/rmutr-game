using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem
{
    private bool createNewSaveData(int slot, string saveName)
    {
        if (GameData.Instance.SaveDataList.Count < 5 && GameData.Instance.SaveDataList[slot] == null)
        {
            GameData.Instance.SaveDataList[slot] = new SaveData(saveName);
            return true;
        }
        return false;
    }

    internal static bool SaveData(int slot)
    {
        try
        {
            SaveData Save = GameData.Instance.SaveDataList[slot];
            //SaveData.QuestListData = _questListData;
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            if (playerObject != null)
            {
                // Access the character's position and rotation
                //SaveData.Rotation = playerObject.transform.rotation;
                //SaveData.Position = playerObject.transform.position;
            }

            foreach (QuestList quest in GameData.Instance.QuestData.QuestList)
            {
                List<SerializedQuestData> data = new List<SerializedQuestData>();
                foreach(QuestBaseSO baseQuest in quest.List)
                {
                    data.Add(new SerializedQuestData(baseQuest.GUID, baseQuest.QuestStatus));
                }
                Save.QuestData.Add(new SerializedQuestList(quest.GUID, data));
            }

            foreach (QuestBaseSO quest in GameData.Instance.QuestData.CurrentQuest)
            {
                //Debug.Log("Quest = " + quest.GUID);
                Debug.Log("Quse Count = " + Save.CurrentQuestData.Count);
                Save.CurrentQuestData.Add(new SerializedQuestData(quest.GUID, quest.QuestStatus));
            }

            foreach (QuestBaseSO quest in GameData.Instance.QuestData.DefaultDialogue)
            {
                Save.CurrentDefaultDialogue.Add(new SerializedQuestData(quest.GUID, quest.QuestStatus)); 
            }

            foreach (KeyValuePair<string, ItemStack> item in GameData.Instance.InventoryData.Items)
            {
                Save.ItemData.Add(new SerializedItem(item.Key, item.Value));
            }


            if (FileManager.MoveFile( Save.SaveName + ".dat", Save.SaveName + ".dat.bak"))
            {
                if (FileManager.WriteFile(Save.SaveName + ".dat", Save.ToJson()))
                {
                    if (FileManager.WriteFile("Setting.Json", GameData.Instance.SettingData.ToJson()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        catch (Exception ex)
        {
            Debug.Log($"Can't save file with exception {ex}");
            return false;
        }

    }

    internal static bool SaveSettingData()
    {
        try
        {
            if (FileManager.WriteFile("Setting.Json", GameData.Instance.SettingData.ToJson()))
            {
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            return false;
        }
    }

    public static bool LoadSettingData()
    {
        try
        {
            if (FileManager.LoadFromFile("Setting.Json", out string result))
            {
                GameData.Instance.SettingData.LoadFromJson(result);
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            return false;
        }
    }

    public void SetNewData()
    {
        //_resetAllDataEmitter.RaiseEvent();
        //HasSaveData();
    }
}
