using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    [Header("Data")]
    [SerializeField] public List<SaveData> SaveDataList = new List<SaveData>();
    [SerializeField] public InventorySO InventoryData = default;
    [SerializeField] public QuestDataSO QuestData = default;
    [SerializeField] public SettingDataSO SettingData = default;

    public SaveData CurrentSave = default;

    [Header("Event Listener")]

    [SerializeField] private VoidEvent _initializeManageEventListener = default;

    private const int maxSaveSlot = 5;
    private void OnEnable()
    {
        _initializeManageEventListener.OnEventRaised += initailizeSaveData;
        _initializeManageEventListener.OnEventRaised += initailizeSettingData;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void initailizeSaveData()
    {
        Debug.Log("Initlize SaveData");
        for (int i = 0; i < maxSaveSlot; i++)
        {
            SaveDataList.Add(null);
        }
        Debug.Log(SaveDataList.Count);

        var getFileName = FileManager.GetFileNames("", ".jt");
        if (getFileName != null)
        {
            for (int i = 0; i < getFileName.Length; i++) 
            {
                if (FileManager.LoadFromFile(getFileName[i], out string data))
                {
                    SaveDataList[i].LoadFromJson(data);
                }
            }
        }
    }

    public void SelectSaveSlot(string name, int slot)
    {
        if (SaveDataList != null)
        {
            Debug.Log(SaveDataList.Count);

            if (SaveDataList[slot] != null)
            {


            }
        }
        SaveDataList[slot] = new SaveData(name);
        CurrentSave = SaveDataList[slot];
    }

    public void initailizeInventory()
    {

    }

    public void initailizeQuestData()
    {

    }

    public void initailizeSettingData()
    {
        Debug.Log("Initlize Setting");
        if (!SaveSystem.LoadSettingData())
        {
            Debug.Log("Start Initlize Setting");
            SettingData.Initialize();
        }
    }
}
