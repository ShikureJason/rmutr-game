using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "IntegerEvent", menuName = "Events/Action/Integer Event")]
public class IntegerEvent : ScriptableObject
{
    public UnityAction<int> OnEventRaised;

    public void RaiseEvent(int data) => OnEventRaised?.Invoke(data);
}
