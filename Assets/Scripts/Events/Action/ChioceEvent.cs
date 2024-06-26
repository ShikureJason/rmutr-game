using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ChioceEvent", menuName = "Events/Action/Chioce Event")]
public class ChioceEvent : ScriptableObject
{
    public UnityAction<ChoiceDetail> OnEventRaised;

    public void RaiseEvent(ChoiceDetail data) => OnEventRaised?.Invoke(data);
}
