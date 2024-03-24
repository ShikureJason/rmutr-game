using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ItemStackEvent", menuName = "Events/Item Stack Event")]
public class ItemStackEvent : ScriptableObject
{
    public UnityAction<ItemStack> OnEventRaised;

    public void RaiseEvent(ItemStack item) => OnEventRaised?.Invoke(item);
}
