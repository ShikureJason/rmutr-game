using System;
using UnityEngine;
using UnityEngine.UIElements;

public class InventorySlot : VisualElement
{
    [SerializeField] private Image _icon = default;
    [SerializeField] private string _itemGuid = default;

    public InventorySlot()
    {
        _icon = new Image();
        Add(_icon);

        _icon.AddToClassList("slotIcon");
        AddToClassList("slotContainer");
    }

    public void HoldItem(ItemSO item)
    {
        _icon.image = item.Icon.texture;
        _itemGuid = item.GUID.ToString();
    }

    public void DropItem()
    {
        _itemGuid = "";
        _icon.image = null;
    }
}
