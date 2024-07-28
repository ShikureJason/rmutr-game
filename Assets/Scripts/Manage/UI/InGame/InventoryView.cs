
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
public class InventoryView : UIView
{
    private const string inventoryName = "";
    private const string slotContainerName = "";
    private const string slotItemName = "slot_inventory";

    public List<InventorySlot> InventoryItems = new List<InventorySlot>();
    private VisualElement slotItem;

    public InventoryView(VisualElement topElement) : base(topElement)
    {
        InventoryManager.OnInventoryChanged += updateUI;
    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        slotItem = m_TopElement.Q<VisualElement>(slotItemName);
        initializeInventory();
    }

    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();
    }

    public override void Dispose()
    {
        base.Dispose();
        Hide();
    }

    private void initializeInventory()
    {
        for (int i = 0; i < 12; i++) 
        {
            InventorySlot slot = new InventorySlot();
            InventoryItems.Add(slot);
            slotItem.Add(slot);
        }
    }

    private void updateUI(string[] itemGuid)
    {
        //Loop through each item and if it has been picked up, add it to the next empty slot
        foreach (string item in itemGuid)
        {
            var emptySlot = InventoryItems.FirstOrDefault(o => o.ItemGuid.Equals(""));

            if (emptySlot != null)
            {
                emptySlot.Add(GameData.Instance.InventoryData.GetItemByGuid(item), item);
            }
        }
    }


}
