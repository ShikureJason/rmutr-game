using System.Linq;
using UnityEngine;


public delegate void OnInventoryChangedDelegate(string[] itemGuid);

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private InventorySO _currentInventory = default;

    //[Header("Event Emitter")]
    public static event OnInventoryChangedDelegate OnInventoryChanged = delegate { };

    [Header("Listening on")]
    [SerializeField] private ItemEvent _useItemEventListener = default;
    [SerializeField] private ItemEvent _equipItemEventListener = default;
    [SerializeField] private ItemStackEvent _rewardItemEventListener = default;
    [SerializeField] private ItemEvent _giveItemEventListener = default;
    [SerializeField] private ItemEvent _addItemEventListener = default;
    [SerializeField] private ItemEvent _removeItemEventListener = default;
    [SerializeField] private VoidEvent _initializeManageEventListener = default;
    

    private void OnEnable()
    {
        //_equipItemEventListener.OnEventRaised += EquipItemEventRaised;
        _addItemEventListener.OnEventRaised += AddItem;
        // _removeItemEventListener.OnEventRaised += RemoveItem;
        //_giveItemEventListener.OnEventRaised += RemoveItem;
        _initializeManageEventListener.OnEventRaised += Initialize;
    }

    private void OnDisable()
    {
        //_equipItemEventListener.OnEventRaised -= EquipItemEventRaised;
        _addItemEventListener.OnEventRaised -= AddItem;
        //_removeItemEventListener.OnEventRaised -= RemoveItem;
        //_giveItemEventListener.OnEventRaised = RemoveItem;
        _initializeManageEventListener.OnEventRaised -= Initialize;
    }
    private void Initialize()
    {
        _currentInventory.Initialize();
    }

    private void AddItem(ItemSO item, int stack)
    {
        _currentInventory.Add(item, stack);
        OnInventoryChanged.Invoke(_currentInventory.Items.Keys.ToArray());
       // _saveSystem.SaveDataToDisk();
    }

    private void RemoveItem(ItemSO item, int stack)
    {
        _currentInventory.Remove(item, stack);
    }
}

