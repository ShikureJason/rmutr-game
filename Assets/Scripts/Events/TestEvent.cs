using UnityEngine;
using UnityEngine.Events;

public class TestEvent
{
    public UnityAction OnEventRaised;

    public void RaiseEvent()
    {
        if (OnEventRaised == null)
        {
            Debug.LogError("Voie NULL");
        }
        OnEventRaised?.Invoke();
    }
}
