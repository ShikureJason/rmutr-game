
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Character Event", menuName = "Events/Character Event")]
public class InteractDialogueEvent : ScriptableObject
{
    public UnityAction<CharacterID> OnEventRaised;

    public void RaiseEvent(CharacterID data) => OnEventRaised?.Invoke(data);
}

