using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MinimapView : UIView
{
    public MinimapView(VisualElement topElement) : base(topElement)
    {
        Debug.Log("MinimanStart");
    }

    public override void Dispose()
    {
        base.Dispose();
        Hide();
    }
}
