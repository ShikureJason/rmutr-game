using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PopupInGameView : UIView
{
    private static string interractName = "interract";

    private VisualElement interractElement;

    public PopupInGameView(VisualElement topElement) : base(topElement)
    {
        UIIngame.OnInteractChanged.OnEventRaised += Setinterract;
    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        interractElement = m_TopElement.Q<VisualElement>(interractName);
    }

    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();
    }

    public override void Dispose()
    {
        base.Dispose();
        UIIngame.OnInteractChanged.OnEventRaised -= Setinterract;
        Hide();
    }

    protected override void SetInitialize()
    {
        interractElement.style.display = DisplayStyle.None;
    }

    public void Setinterract(bool expression)
    {
        if (expression)
        {
            interractElement.style.display = DisplayStyle.Flex;
        }
        else
        {
            interractElement.style.display = DisplayStyle.None;
        }
    }
}
