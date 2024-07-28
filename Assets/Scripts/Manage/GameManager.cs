using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class GameManager : MonoBehaviour
{
    internal static GameManager Instance;
    [SerializeField] private InputReaderSO _inputReader = default;
    [SerializeField] private CharacterSO _character = default;
    [SerializeField] private SceneSO _mainMenuScene = default;

    [Header("Event Emitter")]
    [SerializeField] private VoidEvent _initializeManageEventEmitter = default;
    [SerializeField] private VoidEvent _initializeManageStartEventListener = default;
    [SerializeField] private SceneEvent _loadSceneEventEmitter = default;
    [SerializeField] private VoidEvent _initailizeManageFinishEventEmitter = default;

    [Header("Event Listener")]
    [SerializeField] private SceneTypeEvent _switchInputEventListener = default;
    [SerializeField] private InteractEvent _switchInteractionEventListener = default;
    [SerializeField] private BoolEvent _dialogueEventListener = default;

    public SceneType CurrentSceneType;

    private bool isPause = false;


    private void OnEnable()
    {
        //_inputReader.EscapeEvent += PauseMenu;
        _switchInputEventListener.OnEventRaised += switchInputReaderWithSceneType;
        _dialogueEventListener.OnEventRaised += setInputDialogue;
    }

    private void OnDisable()
    {
        //_inputReader.EscapeEvent -= PauseMenu;
        _switchInputEventListener.OnEventRaised -= switchInputReaderWithSceneType;
        _dialogueEventListener.OnEventRaised -= setInputDialogue;
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

    private void Start()
    {
        initilize();
    }

    private void initilize()
    {
        Debug.Log("Initlize Data");
        _initializeManageEventEmitter.RaiseEvent();
        Debug.Log("Initlize Manage");
        _initializeManageStartEventListener.RaiseEvent();
        Debug.Log("Initlize Finish");
        _initailizeManageFinishEventEmitter.RaiseEvent();
    }

    private void setInputDialogue(bool expression)
    {
        if (expression)
        {
            _inputReader.DisableAllInput();
            _inputReader.EnableDialogue();
        } 
        else 
        {
            setCurrentInputReader();
        }
    }
    public void AdjustGameTime(bool isPause)
    {
        
        if (isPause)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
      
    private void switchInputReaderWithSceneType(SceneType type)
    { 
        switch (type)
        {
            case SceneType.Main:
                _inputReader.EnableGameplay();
                break;
            default:
                _inputReader.DisableAllInput();
                Debug.Log("No Input Type");
                break;
        }
    }

    private void setCurrentInputReader() => switchInputReaderWithSceneType(CurrentSceneType);

    public void SetCurrentSceneType(SceneType type) => CurrentSceneType = type;

    public static void SetSetting()
    {
        SettingDataSO settingData = GameData.Instance.SettingData;
        Debug.Log(settingData.ResolutionIndex);
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[settingData.LocalIndex];
        QualitySettings.SetQualityLevel(settingData.QualityIndex);
        Debug.Log("Screen Count = " + Screen.resolutions + " and index = " + settingData.ResolutionIndex);
        if (settingData.ResolutionIndex > -1)
        {
            Screen.SetResolution(Screen.resolutions[settingData.ResolutionIndex].width, Screen.resolutions[settingData.ResolutionIndex].height, settingData.IsFullscreen);
        }
       
        AudioManage.Instance.SetGroupVolume("MasterVolume", settingData.MasterVolume);
        AudioManage.Instance.SetGroupVolume("MusicVolume", settingData.MusicVolume);
        AudioManage.Instance.SetGroupVolume("SFXVolume", settingData.SFXVolume);
        Debug.LogError("Set SettingSucess");
        if (SaveSystem.SaveSettingData())
        {
            Debug.LogError("Can't save data setting");
        }
        Debug.LogError("Save Setting");
    }

    public void BackToMainMenu()
    {
        _inputReader.DisableAllInput();
        SaveData();
        AdjustGameTime(false);
        _loadSceneEventEmitter.RaiseEvent(_mainMenuScene);
    }

    public static bool SaveData() => SaveSystem.SaveData(GameData.Instance.SaveDataList.IndexOf(GameData.Instance.CurrentSave));
}
