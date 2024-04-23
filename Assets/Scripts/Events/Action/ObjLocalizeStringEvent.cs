using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

[CreateAssetMenu(fileName = "LocalizeStringEvent", menuName = "Events/Action/LocalizeString Event")]
public class ObjLocalizeStringEvent : ScriptableObject
{
    public UnityAction<LocalizedString> OnEventRaised;

    public void RaiseEvent(LocalizedString data) => OnEventRaised?.Invoke(data);
}
