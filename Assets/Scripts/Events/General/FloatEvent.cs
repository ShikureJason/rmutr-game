using UnityEngine;
using UnityEngine.Events;

public class FloatEvent : MonoBehaviour
{
    public UnityAction<float> OnEventRaised;

    public void RaiseEvent(float numbers) => OnEventRaised?.Invoke(numbers);
}
