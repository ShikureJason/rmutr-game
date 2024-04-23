using UnityEngine;
using UnityEngine.Events;

public class ShowInteractEvent : MonoBehaviour
{
    public UnityAction<InteractType, bool> OnEventRaised;

    public void RaiseEvent(InteractType type, bool isInteract) => OnEventRaised?.Invoke(type, isInteract);
}
