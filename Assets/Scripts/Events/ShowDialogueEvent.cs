using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "StartDialogueEvent", menuName = "Events/Show Dialogue")]
public class ShowDialogueEvent : ScriptableObject
{
    public UnityAction<LocalizedString, LocalizedString> OnEventRaised;

    public void RaiseEvent(LocalizedString dialogue, LocalizedString name) => OnEventRaised?.Invoke(dialogue, name);
}
