using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Bool Event", menuName = "Events/Bool Event")]
public class BoolEvent : ScriptableObject
{
    public UnityAction<bool> OnEventRaised;

    public void RaiseEvent(bool expression) => OnEventRaised?.Invoke(expression);
}
