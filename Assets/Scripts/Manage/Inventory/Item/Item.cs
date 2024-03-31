using UnityEngine;

public class Item : MonoBehaviour
{ 
    [SerializeField] private ItemSO _item = default;
    [SerializeField] private int itemStack = default;

    [Header("Event Emitter")]
    [SerializeField] private TriggerDetectEvent _triggerDetectEventEmitter = default;

    [Header("Event Emitter")]
    [SerializeField] private ItemEvent _addItemEventEmitter = default;
    public void Interract()
    {
        _addItemEventEmitter.OnEventRaised(_item, itemStack);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        _triggerDetectEventEmitter.RaiseEvent(false, gameObject);
    }
}
