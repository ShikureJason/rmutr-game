using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Item Event", menuName = "Events/Inventory/Create Item Event")]
public class ItemEvent : BaseScriptableObject
{
    public UnityAction<Item> OnEventRaised;

    public void RaiseEvent(Item item)
    {
        if (OnEventRaised != null)
            OnEventRaised.Invoke(item);
    }
}
