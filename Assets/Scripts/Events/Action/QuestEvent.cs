using RMUTR.Quest;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ChioceEvent", menuName = "Events/Action/Quest Event")]
public class QuestEvent : ScriptableObject
{
    public UnityAction<QuestBaseSO> OnEventRaised;

    public void RaiseEvent(QuestBaseSO data) => OnEventRaised?.Invoke(data);
}
