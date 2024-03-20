using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Item Event", menuName = "Events/Inventory/Create Item Event")]
public class ItemEvent : BaseScriptableObject
{
    public UnityAction<ItemSO> OnEventRaised;

    public void RaiseEvent(ItemSO item) => OnEventRaised.Invoke(item);
}
