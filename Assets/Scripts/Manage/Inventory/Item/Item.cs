using UnityEngine;

public class Item : MonoBehaviour
{ 
    [SerializeField] private ItemSO _item = default;

    [Header("Event Emitter")]
    [SerializeField] private ItemEvent _addItemEventEmitter = default;
    public void GetItem()
    {
        _addItemEventEmitter.OnEventRaised(_item);
        Destroy(gameObject);
    }
}
