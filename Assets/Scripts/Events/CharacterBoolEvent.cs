using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CharacterEvent", menuName = "Events/Character Quest Event")]
public class CharacterBoolEvent : MonoBehaviour
{
    public UnityAction<CharacterID, bool> OnEventRaised;
    public void RaiseEvent(CharacterID id, bool hasQuest) => OnEventRaised?.Invoke(id, hasQuest);
}
