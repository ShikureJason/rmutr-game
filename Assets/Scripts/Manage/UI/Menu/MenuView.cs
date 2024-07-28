using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuView : UIView
{
    public static VoidEvent NewGameEvent;
    public static VoidEvent OpenSettingEvent;
    public static VoidEvent ExitEvent;


    private const string newgameName = "button_new_game";
    private const string settingName = "button_setting";
    private const string exitName = "button_exit";

    private const string exitLabelName = "label_exit";

    private Button newgameButton;
    private Button buttonSetting;
    private Button exitButton;

    private Label labelExit;

    public MenuView(VisualElement topElement) : base(topElement)
    {
        NewGameEvent = ScriptableObject.CreateInstance<VoidEvent>();
        OpenSettingEvent = ScriptableObject.CreateInstance<VoidEvent>();
        ExitEvent = ScriptableObject.CreateInstance<VoidEvent>();
    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        newgameButton = m_TopElement.Q<Button>(newgameName);
        buttonSetting = m_TopElement.Q<Button>(settingName);
        exitButton = m_TopElement.Q<Button>(exitName);
        labelExit = m_TopElement.Q<Label>(exitLabelName);
    }

    protected override void RegisterButtonCallbacks() 
    {
        base.RegisterButtonCallbacks();
        newgameButton.RegisterCallback<ClickEvent>(newGame);
        buttonSetting.RegisterCallback<ClickEvent>(openSetting);
        exitButton.RegisterCallback<ClickEvent>(exit);

    }

    public override void Dispose()
    {
        base.Dispose();
        newgameButton.UnregisterCallback<ClickEvent>(newGame);
        buttonSetting.UnregisterCallback<ClickEvent>(openSetting);
        exitButton.UnregisterCallback<ClickEvent>(exit);
    }

    private void newGame(ClickEvent evt)
    {
        NewGameEvent.RaiseEvent();
    }

    private void openSetting(ClickEvent evt)
    {
        OpenSettingEvent.RaiseEvent();
    }

    private void exit(ClickEvent evt)
    {
        ExitEvent.RaiseEvent();
    }

}
