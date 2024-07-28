using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenuView : UIView
{
    public static VoidEvent ExitToMainMenuEvent;
    public static VoidEvent ResumeEvent;
    public static BoolEvent OnSettingPopupChange;

    private const string menuName = "menu";
    private const string settingName = "setting";
    private const string buttonResumeName = "button_resume";
    private const string buttonSettingName = "button_setting";
    private const string buttonExitName = "button_exit";

    VisualElement menuView;

    UIView settingView;

    Button buttonResume;
    Button buttonSetting;
    Button buttonExit;

    public PauseMenuView(VisualElement topElement) : base(topElement)
    {
        SettingView.CloseSetting.OnEventRaised += closeSetting;
        UIIngame.SettingPopupEvent.OnEventRaised += closeSetting;
        ExitToMainMenuEvent = ScriptableObject.CreateInstance<VoidEvent>();
        ResumeEvent = ScriptableObject.CreateInstance<VoidEvent>();
        OnSettingPopupChange = ScriptableObject.CreateInstance<BoolEvent>();
    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        settingView = new SettingView(m_TopElement.Q<VisualElement>(settingName));
        menuView = m_TopElement.Q<VisualElement>(menuName);
        buttonResume = m_TopElement.Q<Button>(buttonResumeName);
        buttonSetting = m_TopElement.Q<Button>(buttonSettingName);
        buttonExit = m_TopElement.Q<Button>(buttonExitName);
    }

    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();
        buttonResume.RegisterCallback<ClickEvent>(resumeGame);
        buttonSetting.RegisterCallback<ClickEvent>(openSetting);
        buttonExit.RegisterCallback<ClickEvent>(exitToMainMenu);
    }

    public override void Dispose()
    {
        base.Dispose();
        buttonResume.UnregisterCallback<ClickEvent>(resumeGame);
        buttonSetting.UnregisterCallback<ClickEvent>(openSetting);
        buttonExit.UnregisterCallback<ClickEvent>(exitToMainMenu);
        settingView.Dispose();
        Hide();
    }

    protected override void SetInitialize()
    {
        base.SetInitialize();
        menuView.style.display = DisplayStyle.Flex;
    }

    private void resumeGame(ClickEvent evt)
    {
        Hide();
        ResumeEvent.RaiseEvent();
    }

    private void openSetting(ClickEvent evt)
    {
        OnSettingPopupChange.RaiseEvent(true);
        menuView.style.display = DisplayStyle.None;
        settingView.Show();
    }

    public void closeSetting()
    {
        OnSettingPopupChange.RaiseEvent(false);
        settingView.Hide();
        menuView.style.display = DisplayStyle.Flex;
    }

    private void exitToMainMenu(ClickEvent evt)
    {
        ExitToMainMenuEvent.RaiseEvent();
    }
}
