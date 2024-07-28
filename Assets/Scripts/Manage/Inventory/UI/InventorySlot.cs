using UnityEngine.UIElements;
using UnityEngine;

public class InventorySlot : VisualElement
{
    public Image Icon;
    public string ItemGuid = "";
    public int itemCount = 0;
    private VisualElement countItem;
    private Label countItemLabel;


    public InventorySlot()
    {
        Icon = new Image();
        countItem = new VisualElement();
        countItemLabel = new Label();
        
        Add(Icon);

        Icon.AddToClassList("inventory-slot  Icon");
        AddToClassList("inventory-slotContainer");

        Add(countItem);
        countItemLabel.AddToClassList("inventory-slotItemCountText");
        countItem.AddToClassList("inventory-slotItemCount");
        countItem.Add(countItemLabel);
        countItem.style.display = DisplayStyle.None;

        updateUI();

    }

    public void Add(ItemStack item, string guid)
    {
        Icon.image = item.Item.Icon.texture;
        ItemGuid = guid;
        itemCount = item.Amount;
        UpdateItemCount(item.Amount);
    }

    public void DropItem()
    {
        ItemGuid = "";
        Icon.image = null;
    }

    public void UpdateItemCount(int count)
    {
        if (count > 2 && itemCount < 2) 
        {
            if (countItem == null)
                return;

            countItem.style.display = DisplayStyle.None;
            return;
        }
        else
        {
            itemCount += count;
            if (countItem.style.display == DisplayStyle.None)
            {
                Debug.Log("Show");
                countItem.style.display = DisplayStyle.Flex;
            }
            updateUI();

        }
    }
    
    private void updateUI()
    {
        countItemLabel.text = itemCount.ToString();
    }
}
