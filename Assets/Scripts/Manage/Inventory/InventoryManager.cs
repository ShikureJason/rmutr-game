using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private InventorySO _currentInventory = default;

    [Header("Listening on")]
    [SerializeField] private ItemEvent _cookRecipeEvent = default;
    [SerializeField] private ItemEvent _useItemEvent = default;
    [SerializeField] private ItemEvent _equipItemEvent = default;
    [SerializeField] private ItemEvent _rewardItemEvent = default;
    [SerializeField] private ItemEvent _giveItemEvent = default;
    [SerializeField] private ItemEvent _addItemEvent = default;
    [SerializeField] private ItemEvent _removeItemEvent = default;

    private void OnEnable()
    {
        _useItemEvent.OnEventRaised += UseItemEventRaised;
        _equipItemEvent.OnEventRaised += EquipItemEventRaised;
        _addItemEvent.OnEventRaised += AddItem;
        _removeItemEvent.OnEventRaised += RemoveItem;
        //_rewardItemEvent.OnEventRaised += AddItemStack;
        _giveItemEvent.OnEventRaised += RemoveItem;
    }

    private void OnDisable()
    {
        _useItemEvent.OnEventRaised -= UseItemEventRaised;
        _equipItemEvent.OnEventRaised -= EquipItemEventRaised;
        _addItemEvent.OnEventRaised -= AddItem;
        _removeItemEvent.OnEventRaised -= RemoveItem;
    }

    private void AddItemWithUIUpdate(Item item)
    {
        _currentInventory.Add(item);
        if (_currentInventory.Contains(item))
        {
            ItemStack itemToUpdate = _currentInventory.Items.Find(o => o.Item == item);
        }
    }

    private void RemoveItemWithUIUpdate(Item item)
    {
        ItemStack itemToUpdate = new ItemStack();

        if (_currentInventory.Contains(item))
        {
            itemToUpdate = _currentInventory.Items.Find(o => o.Item == item);
        }

        _currentInventory.Remove(item);

        bool removeItem = _currentInventory.Contains(item);
    }

    private void AddItem(Item item)
    {
        _currentInventory.Add(item);
       // _saveSystem.SaveDataToDisk();
    }

    private void AddItemStack(ItemStack itemStack)
    {
        _currentInventory.Add(itemStack.Item, itemStack.Amount);
       // _saveSystem.SaveDataToDisk();
    }

    private void RemoveItem(Item item)
    {
        _currentInventory.Remove(item);
        //_saveSystem.SaveDataToDisk();
    }

    private void UseItemEventRaised(Item item)
    {
        RemoveItem(item);
    }

    //This empty function is left here for the possibility of adding decorative 3D items
    private void EquipItemEventRaised(Item item)
    {

    }
}

