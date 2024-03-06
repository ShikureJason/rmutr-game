using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "StartDialogueEvent", menuName = "Events/StartDialogue")]
public class ShowDialogueEvent : ScriptableObject
{
    public UnityAction<LocalizedString, CharacterDetail> OnEventRaised;

    public void RaiseEvent(LocalizedString dialogue, CharacterDetail name) => OnEventRaised?.Invoke(dialogue, name);
}
