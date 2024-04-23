using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Func/Create Save Data", fileName = "CreateSaveData")]
public class CreateSaveDataEvent : ScriptableObject
{
    public Func<string, int, bool> OnEventRaised;

    public void RaiseEvent(string num1, int num2, out bool num3)
    {
        num3 = OnEventRaised?.Invoke(num1, num2) ?? false;
    }
}
