using UnityEngine;

public class QuestFindLocationInterract : MonoBehaviour
{
    [SerializeField] private QuestFindLocation _questLocation;

    [Header("Event Emitter")]
    [SerializeField] public QuestEvent _questGUIDEventEmitter;

    public void QuestTrigger()
    {
        _questGUIDEventEmitter.RaiseEvent(_questLocation);
    }
}
