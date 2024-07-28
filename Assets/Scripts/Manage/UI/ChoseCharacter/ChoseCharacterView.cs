using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChoseCharacterView : UIView
{
    public static IntegerEvent ChoseCharacterEvent = new IntegerEvent();

    private const string buttonConfirmCharacterOneName = "button-confirm-character-one";
    private const string buttonConfirmCharacterTwoName = "button-confirm-character-two";
    private const string buttonConfirmCharacterThreeName = "button-confirm-character-three";

    private Button buttonConfirmCharacterOne;
    private Button buttonConfirmCharacterTwo;
    private Button buttonConfirmCharacterThree;
    public ChoseCharacterView(VisualElement topElement) : base(topElement)
    {
        Debug.LogError("Character");
    }
    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        buttonConfirmCharacterOne = m_TopElement.Q<Button>(buttonConfirmCharacterOneName);
        buttonConfirmCharacterTwo = m_TopElement.Q<Button>(buttonConfirmCharacterTwoName);
        buttonConfirmCharacterThree = m_TopElement.Q<Button>(buttonConfirmCharacterThreeName);
    }

    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();
        buttonConfirmCharacterOne.RegisterCallback<ClickEvent>(evt => ChoseCharacterEvent.RaiseEvent(0));
        buttonConfirmCharacterTwo.RegisterCallback<ClickEvent>(evt => ChoseCharacterEvent.RaiseEvent(1));
        buttonConfirmCharacterThree.RegisterCallback<ClickEvent>(evt => ChoseCharacterEvent.RaiseEvent(2));
        /*buttonConfirmCharacterOne.RegisterCallback<ClickEvent>(evt => Debug.Log("asd"));
        buttonConfirmCharacterTwo.RegisterCallback<ClickEvent>(evt => Debug.Log("asd"));
        buttonConfirmCharacterThree.RegisterCallback<ClickEvent>(evt => Debug.Log("asd"));*/
        Debug.LogError("Set");
    }
}
