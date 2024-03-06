using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InteractQuestEvent", menuName = "Events/Character Interact Quest Event")]
public class InteractQuestEvent : ScriptableObject
{
    public UnityAction<CharacterID> OnEventRaised;

    public void RaiseEvent(CharacterID data) => OnEventRaised?.Invoke(data);
}
