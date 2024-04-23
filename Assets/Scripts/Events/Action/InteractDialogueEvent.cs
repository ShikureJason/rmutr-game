
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Character Event", menuName = "Events/Action/Character Event")]
public class InteractDialogueEvent : ScriptableObject
{
    public UnityAction<CharacterID> OnEventRaised;

    public void RaiseEvent(CharacterID data) => OnEventRaised?.Invoke(data);
}

