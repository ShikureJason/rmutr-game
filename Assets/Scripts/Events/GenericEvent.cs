using UnityEngine;
using UnityEngine.Events;

public class GenericEvent<T> : ScriptableObject
{
    public UnityAction<T> OnEventRaised;

    public void RaiseEvent(T data) => OnEventRaised?.Invoke(data);
}
