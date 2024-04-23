using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "FloatEvent", menuName = "Events/Action/Float Event")]
public class FloatEvent : MonoBehaviour
{
    public UnityAction<float> OnEventRaised;

    public void RaiseEvent(float numbers) => OnEventRaised?.Invoke(numbers);
}
