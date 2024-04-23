using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InteractEvent", menuName = "Events/Action/Interact Event")]
public class InteractEvent : ScriptableObject
{
    public UnityAction<InteractType, bool> OnEventRaised;

    public void RaiseEvent(InteractType type, bool isInteract) => OnEventRaised?.Invoke(type, isInteract);
}
