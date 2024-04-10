using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveSystem", menuName = "GameManager/SaveSystem")]
public class SaveDataSO : BaseScriptableObject
{

    [SerializeField] private string _saveFileName = default;


    [Header("Event Emitter")]
    [SerializeField] private VoidEvent _resetAllDataEmitter = default;

    [Header("Evnet Listener")]
    [SerializeField] private VoidEvent _startNewGameDataListener = default;

    public SaveData SaveData = new SaveData();

    private void OnEnable()
    {
        _startNewGameDataListener.OnEventRaised += SetNewData;
    }

    private void OnDisable()
    {
        _startNewGameDataListener.OnEventRaised -= SetNewData;
    }
    private void WriteEmtyFile()
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

    }

    public bool HasSaveData()
    {
        try
        {
            //SaveData.QuestListData = _questListData;
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            if (playerObject != null)
            {
                // Access the character's position and rotation
                SaveData.Rotation = playerObject.transform.rotation;
                SaveData.Position = playerObject.transform.position;
            }


            if (FileManager.MoveFile(_saveFileName + ".dat", _saveFileName + ".dat.bak"))
            {
                if (FileManager.WriteFile(_saveFileName + ".dat", SaveData.ToJson()))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        catch (Exception ex)
        {
            Debug.Log($"Can't save file with exception {ex}");
            return false;
        }

    }

    public bool LoadData()
    {
        if (FileManager.LoadFromFile(_saveFileName + ".dat", out var json))
        {
            SaveData.LoadFromJson(json);
            return true;
        }
        return false;
    }

    public void SetNewData()
    {
        WriteEmtyFile();
        _resetAllDataEmitter.RaiseEvent();
        HasSaveData();
    }
}
