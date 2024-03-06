using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySO : MonoBehaviour
{
    [SerializeField] private List<ItemStack> _items = new List<ItemStack>();
    [SerializeField] private List<ItemStack> _defaultItems = new List<ItemStack>();

    public List<ItemStack> Items => _items;

    public void Init()
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

    public void Add(Item item, int count = 1)
    {
        if (count <= 0)
            return;

        _items.Add(new ItemStack(item, count));
    }

    public void Remove(Item item, int count = 1)
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

    public bool Contains(Item  item)
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

    public int Count(Item item)
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
