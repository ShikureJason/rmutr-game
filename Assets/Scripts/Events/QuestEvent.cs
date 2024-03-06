using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ChioceEvent", menuName = "Events/Quest Event")]
public class QuestEvent : MonoBehaviour
{
    public UnityAction<QuestSO> OnEventRaised;

    public void RaiseEvent(QuestSO data) => OnEventRaised?.Invoke(data);
}
