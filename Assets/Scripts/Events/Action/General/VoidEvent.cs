using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Event",menuName = "Events/Action/Void Event")]
public class VoidEvent : ScriptableObject
{
    public UnityAction OnEventRaised;

    public void RaiseEvent() => OnEventRaised?.Invoke();
}
