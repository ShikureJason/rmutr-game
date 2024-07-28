using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/Inventory")]
public class InventorySO : BaseScriptableObject
{
    [SerializeField] private Dictionary<string, ItemStack> _items = new Dictionary<string, ItemStack>();
    [SerializeField] private List<ItemStack> _defaultItems = new List<ItemStack>();

    public Dictionary<string, ItemStack> Items => _items;

    public void Initialize()
    {
        _items.Clear();
        foreach (ItemStack item in _defaultItems)
        {
            _items.Add(Guid.NewGuid().ToString() ,new ItemStack(item));
        }
    }

    public void Add(ItemSO item, int count = 1)
    {
        if (count <= 0)
            return;

        ItemStack currentItem = null;
        string currentKey = null;

        foreach (var keyValue in _items)
        {
            if (keyValue.Value.Item.Equals(item))
            {
                currentItem = keyValue.Value;
                currentKey = keyValue.Key;
                break;
            }
        }

        if (currentItem == null)
        {
            currentItem = new ItemStack(item, 0);
            currentKey = Guid.NewGuid().ToString();
            _items.Add(currentKey, currentItem);
        }

        while (count > 0)
        {
            int addAmount = Math.Min(count, item.MaxStack - currentItem.Amount);

            currentItem.Amount += addAmount;
            count -= addAmount;
            if (count > 0)
            {
                currentItem = new ItemStack(item, Math.Min(count, item.MaxStack));
                currentKey = Guid.NewGuid().ToString();
                _items.Add(currentKey, currentItem);
                count -= Math.Min(count, item.MaxStack);
            }
        }
    }

    public void Remove(ItemSO item, int count = 1)
    {
        if (count <= 0)
            return;

        foreach (var key in new List<string>(_items.Keys))
        {
            ItemStack currentItemStack = _items[key];

            if (currentItemStack.Item == item)
            {
                currentItemStack.Amount -= count;

                if (currentItemStack.Amount <= 0)
                    _items.Remove(key);

                return;
            }
        }
    }

    public bool Contains(ItemSO item)
    {
        foreach (var keyValue in _items)
        {
            if (item == keyValue.Value.Item)
            {
                return true;
            }
        }
        return false;
    }

    public int Count(ItemSO item)
    {
        int totalCount = 0;

        foreach (var keyValue in _items)
        {
            if (item == keyValue.Value.Item)
            {
                totalCount += keyValue.Value.Amount;
            }
        }

        return totalCount;
    }

    public ItemStack GetItemByGuid(string guid)
    {
        if (_items.ContainsKey(guid))
        {
            return _items[guid];
        }

        return null;
    }
}

