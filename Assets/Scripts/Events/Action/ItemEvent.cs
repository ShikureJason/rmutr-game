using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Item Event", menuName = "Events/Action/Inventory/Create Item Event")]
public class ItemEvent : BaseScriptableObject
{
    public UnityAction<ItemSO, int> OnEventRaised;

    public void RaiseEvent(ItemSO item, int stack) => OnEventRaised.Invoke(item, stack);
}
