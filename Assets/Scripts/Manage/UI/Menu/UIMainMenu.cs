using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class UIMainMenu : MonoBehaviour
{
    [Header("Evemt Listener")]
    [SerializeField] private VoidEvent _startNextSceneEmitter = default;
    private UIView mainMenuView;
    private UIView settingMenuView;
    private UIView choseSaveSlotView;

    private const string mainMenuName = "main_menu";
    private const string settingMenuName = "setting";
    private const string choseSaveSlotName = "chose_slot_save";

    private void OnEnable()
    {
        GetComponent<UIDocumentLocalization>().onCompleted += setupViews;
    }

    private void OnDisable()
    {
        GetComponent<UIDocumentLocalization>().onCompleted -= setupViews;
        MenuView.NewGameEvent.OnEventRaised -= startNewgame;
        MenuView.OpenSettingEvent.OnEventRaised -= openSetting;
        MenuView.ExitEvent.OnEventRaised -= onExit;
        SettingView.CloseSetting.OnEventRaised -= closeSettingMenu;
        ChoseSaveSlotView.SelectSaveEvent.OnEventRaised -= createNewSaveSlot;

    }

    private void Start()
    {
        //setupViews(GetComponent<UIDocument>().rootVisualElement);
        //GetComponent<UIDocumentLocalization>().onCompleted += setupViews;
    }

    private void setupViews(VisualElement root)
    {
        Debug.LogError("Start UI");
        mainMenuView = new MenuView(root.Q<VisualElement>(mainMenuName));
        settingMenuView = new SettingView(root.Q<VisualElement>(settingMenuName));
        choseSaveSlotView = new ChoseSaveSlotView(root.Q<VisualElement>(choseSaveSlotName));

        MenuView.NewGameEvent.OnEventRaised += startNewgame;
        MenuView.OpenSettingEvent.OnEventRaised += openSetting;
        MenuView.ExitEvent.OnEventRaised += onExit;
        SettingView.CloseSetting.OnEventRaised += closeSettingMenu;
        ChoseSaveSlotView.SelectSaveEvent.OnEventRaised += createNewSaveSlot;

        mainMenuView.Show();
    }

    private void startNewgame()
    {
        mainMenuView.Hide();
        choseSaveSlotView.Show();
    }

    private void closeSettingMenu()
    {
        settingMenuView.Hide();
        mainMenuView.Show();
    }

    private void openSetting()
    {
        mainMenuView.Hide();
        settingMenuView.Show();
    }

    private void onExit()
    {
        Application.Quit();
    }

    private void createNewSaveSlot(string name, int slot)
    {
        GameData.Instance.SelectSaveSlot(name, slot);
        _startNextSceneEmitter.RaiseEvent();
    }
}
