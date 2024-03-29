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

    private void OnEnable()
    {
        _useItemEventListener.OnEventRaised += UseItemEventRaised;
        _equipItemEventListener.OnEventRaised += EquipItemEventRaised;
        _addItemEventListener.OnEventRaised += AddItem;
        _removeItemEventListener.OnEventRaised += RemoveItem;
        _rewardItemEventListener.OnEventRaised += AddItemStack;
        _giveItemEventListener.OnEventRaised += RemoveItem;
    }

    private void OnDisable()
    {
        _useItemEventListener.OnEventRaised -= UseItemEventRaised;
        _equipItemEventListener.OnEventRaised -= EquipItemEventRaised;
        _addItemEventListener.OnEventRaised -= AddItem;
        _removeItemEventListener.OnEventRaised -= RemoveItem;
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

    private void AddItem(ItemSO item)
    {
        _currentInventory.Add(item);
       // _saveSystem.SaveDataToDisk();
    }

    private void AddItemStack(ItemStack itemStack)
    {
        _currentInventory.Add(itemStack.Item, itemStack.Amount);
       // _saveSystem.SaveDataToDisk();
    }

    private void RemoveItem(ItemSO item)
    {
        _currentInventory.Remove(item);
        //_saveSystem.SaveDataToDisk();
    }

    private void UseItemEventRaised(ItemSO item)
    {
        RemoveItem(item);
    }

    //This empty function is left here for the possibility of adding decorative 3D items
    private void EquipItemEventRaised(ItemSO item)
    {

    }
}

