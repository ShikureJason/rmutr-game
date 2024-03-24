using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Create Item")]
public class ItemSO : ScriptableObject
{
    [SerializeField] private int _id = default;
    [SerializeField] private AssetReference _prefap = default;
    [SerializeField] private AssetReference _icon = default;
    [SerializeField] private LocalizedString _itemName = default;
    [SerializeField] private int _maxStack = default;
    [SerializeField] private LocalizedString _description = default;

    public int Id => _id;
    public AssetReference Prefap => _prefap;
    public AssetReference Icon => _icon;
    public LocalizedString ItemName => _itemName;
    public int MaxStack => _maxStack;
    public LocalizedString Description => _description;
}
