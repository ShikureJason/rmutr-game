using UnityEngine;

public class QuestFindLocationInterract : MonoBehaviour
{
    [SerializeField] private QuestSO _questLocation;

    [Header("Event Emitter")]
    [SerializeField] public StringEvent _questGUIDEventEmitter;

    public void QuestTrigger()
    {
        _questGUIDEventEmitter.RaiseEvent(_questLocation.GUID);
    }
}
