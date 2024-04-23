using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private SaveSetting _setting = default;
    [SerializeField] private InventorySO _inventory = default;
    [SerializeField] private QuestDataSO _questData = default;

    [Header("Event Emitter")]
    [SerializeField] private VoidEvent _resetAllDataEmitter = default;

    [Header("Evnet Listener")]
    [SerializeField] private VoidEvent _startNewGameDataListener = default;

    [Header("Data")]

    public SaveData[] SaveData = new SaveData[5];

    private void OnEnable()
    {
        _startNewGameDataListener.OnEventRaised += SetNewData;
    }

    private void OnDisable()
    {
        _startNewGameDataListener.OnEventRaised -= SetNewData;
    }
    /*private void WriteEmtyFile()
    {
        try
        {
            FileManager.WriteFile(_saveFileName + ".dat", "");
            Debug.Log("WriteFile");
        }
        catch (Exception ex)
        {
            Debug.Log($"Can't write file with exception {ex}");
        }
    }*/

    private bool createNewSaveData(int slot, string saveName)
    {
        SaveData[slot] = new SaveData(saveName);
        if(HasSaveData(slot))
        {
            return true;
        }
        return false;
    }

    public bool HasSaveData(int slot)
    {
        try
        {
            //SaveData.QuestListData = _questListData;
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            if (playerObject != null)
            {
                // Access the character's position and rotation
                //SaveData.Rotation = playerObject.transform.rotation;
                //SaveData.Position = playerObject.transform.position;
            }

            foreach (QuestList quest in _questData.QuestList)
            {
                List<SerializedQuestData> data = new List<SerializedQuestData>();
                foreach(QuestBaseSO baseQuest in quest.List)
                {
                    data.Add(new SerializedQuestData(baseQuest.GUID, baseQuest.QuestStatus));
                }
                SaveData[slot].QuestData.Add(new SerializedQuestList(quest.GUID, data));
            }

            foreach (QuestBaseSO quest in _questData.CurrentQuest)
            {
                SaveData[slot].CurrentQuestData.Add(new SerializedQuestData(quest.GUID, quest.QuestStatus));
            }

            foreach (QuestBaseSO quest in _questData.DefaultDialogue)
            {
                SaveData[slot].CurrentDefaultDialogue.Add(new SerializedQuestData(quest.GUID, quest.QuestStatus)); 
            }

            foreach (ItemStack item in _inventory.Items)
            {
                SaveData[slot].ItemData.Add(new SerializedItem(item.GUID, item.Item.Id, item.Amount));
            }


            if (FileManager.MoveFile( SaveData[slot].GUID + ".dat", SaveData[slot].GUID + ".dat.bak"))
            {
                if (FileManager.WriteFile(SaveData[slot].GUID + ".dat", SaveData[0].ToJson()))
                {
                    if (FileManager.WriteFile("Setting.Json", _setting.ToJson()))
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

    public void LoadSettingData()
    {
        try
        {
            if (FileManager.LoadFromFile("Setting.Json", out string result))
            {
                _setting.LoadFromJson(result);
            } else
            {
                //_setting  ;
            }
        }
        catch
        {

        }
    }

    public void SetNewData()
    {
        _resetAllDataEmitter.RaiseEvent();
        //HasSaveData();
    }
}
