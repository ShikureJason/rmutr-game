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

    private void SetVisualElements()
    {
        newgameButton = m_TopElement.Q<Button>("button-new-game");
        settingButton = m_TopElement.Q<Button>("button-setting");
        exitButton = m_TopElement.Q<Button>("button-exit");

        newgameLabel = m_TopElement.Q<Label>("label-new-game");
        settingLabel = m_TopElement.Q<Label>("label-setting");
        exitLabel = m_TopElement.Q<Label>("label-exit");    
    }

    
}
