using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CharacterEvent", menuName = "Events/Character Event")]
public class CharacterEvent : ScriptableObject
{
    public UnityAction<CharacterID> OnEventRaised;

    public void RaiseEvent(CharacterID id) => OnEventRaised?.Invoke(id);
}
