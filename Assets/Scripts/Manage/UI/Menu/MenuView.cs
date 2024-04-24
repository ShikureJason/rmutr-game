using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuView : UIView
{
    private Button newgameButton;
    private Button settingButton;
    private Button exitButton;

    private Label newgameLabel;
    private Label settingLabel;
    private Label exitLabel;

    public MenuView(VisualElement topElement) : base(topElement)
    {

    }

    protected override void SetVisualElements()
    {
        newgameButton = m_TopElement.Q<Button>("button_new_game");
        /*settingButton = m_TopElement.Q<Button>("button-setting");
        exitButton = m_TopElement.Q<Button>("button-exit");

        newgameLabel = m_TopElement.Q<Label>("label-new-game");
        settingLabel = m_TopElement.Q<Label>("label-setting");
        exitLabel = m_TopElement.Q<Label>("label-exit");  */  
    }

    protected override void RegisterButtonCallbacks() 
    {
        base.RegisterButtonCallbacks();
        Debug.Log(newgameButton);
        newgameButton.RegisterCallback<ClickEvent>(newGame);
        Debug.Log("Init");
    }

    private void newGame(ClickEvent evnt)
    {
        Debug.Log("pass");
    }



}
