using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "StringEvent", menuName = "Events/String Event")]
public class StringEvent : ScriptableObject
{
    public UnityAction<string> OnEventRaised;

    public void RaiseEvent(string data) => OnEventRaised?.Invoke(data);
}
