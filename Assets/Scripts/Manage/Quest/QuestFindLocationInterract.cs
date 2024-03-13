using UnityEngine;

public class QuestFindLocationInterract : MonoBehaviour
{
    [SerializeField] private QuestFindLocationSO _questLocation;

    [Header("Event Emitter")]
    [SerializeField] public QuestEvent _questEventEmitter;

    public void QuestTrigger()
    {
        _questEventEmitter.RaiseEvent(_questLocation);
    }
}
