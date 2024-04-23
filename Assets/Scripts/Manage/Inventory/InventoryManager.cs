using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private InventorySO _currentInventory = default;
    [SerializeField] private SaveData _saveData = default;

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

    private void AddItemWithUIUpdate(ItemSO item)
    {
        _currentInventory.Add(item);
        if (_currentInventory.Contains(item))
        {
            ItemStack itemToUpdate = _currentInventory.Items.Find(o => o.Item == item);
        }
    }

    private void RemoveItemWithUIUpdate(ItemSO item)
    {
        ItemStack itemToUpdate = new ItemStack();

        if (_currentInventory.Contains(item))
        {
            itemToUpdate = _currentInventory.Items.Find(o => o.Item == item);
        }

        _currentInventory.Remove(item);

        bool removeItem = _currentInventory.Contains(item);
    }

    private void AddItem(ItemSO item, int stack)
    {
        _currentInventory.Add(item, stack);
       // _saveSystem.SaveDataToDisk();
    }

    private void RemoveItem(ItemSO item, int stack)
    {
        _currentInventory.Remove(item, stack);
    }

    /*private void UseItemEventRaised(ItemSO item)
    {
        RemoveItem(item);
    }*/

    //This empty function is left here for the possibility of adding decorative 3D items
    private void EquipItemEventRaised(ItemSO item)
    {

    }
}

