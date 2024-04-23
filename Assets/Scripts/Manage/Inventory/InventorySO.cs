using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/Inventory")]
public class InventorySO : BaseScriptableObject
{
    [SerializeField] private List<ItemStack> _items = new List<ItemStack>();
    [SerializeField] private List<ItemStack> _defaultItems = new List<ItemStack>();

    public List<ItemStack> Items => _items;

    public void Initialize()
    {
        if (_items == null)
        {
            _items = new List<ItemStack>();
        }
        _items.Clear();
        foreach (ItemStack item in _defaultItems)
        {
            _items.Add(new ItemStack(item));
        }
    }

    public void Add(ItemSO item, int count = 1)
    {
        if (count <= 0)
            return;


        ItemStack currentItem = _items.Find(o => o.Item.Equals(item));
        if (currentItem == null)
        {
            currentItem = new ItemStack(item, 0);
            _items.Add(currentItem);
        }

        while (count > 0)
        {
            int addAmount = Math.Min(count, item.MaxStack - currentItem.Amount);

            currentItem.Amount += addAmount;
            count -= addAmount;
            if (count > 0)
            {
                currentItem = new ItemStack(item, Math.Min(count, item.MaxStack));
                _items.Add(currentItem);
                count -= Math.Min(count, item.MaxStack);
            }
        }
    }

    public void Remove(ItemSO item, int count = 1)
    {
        if (count <= 0)
            return;

        for (int i = 0; i < _items.Count; i++)
        {
            ItemStack currentItemStack = _items[i];

            if (currentItemStack.Item == item)
            {
                currentItemStack.Amount -= count;

                if (currentItemStack.Amount <= 0)
                    _items.Remove(currentItemStack);

                return;
            }
        }
    }

    public bool Contains(ItemSO item)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (item == _items[i].Item)
            {
                return true;
            }
        }
        return false;
    }

    public int Count(ItemSO item)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            ItemStack currentItemStack = _items[i];
            if (item == currentItemStack.Item)
            {
                return currentItemStack.Amount;
            }
        }

        return 0;
    }
}
