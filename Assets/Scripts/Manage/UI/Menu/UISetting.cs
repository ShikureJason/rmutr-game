using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
{
    public void SetActiveSetting(bool expression)
    {
        gameObject.SetActive(expression);
    }
}
