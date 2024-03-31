using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Localization;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Create Item")]
public class ItemSO : BaseScriptableObject
{
    [SerializeField] private int _id = default;
    [SerializeField] private AssetReference _prefap = default;
    [SerializeField] private Sprite _icon = default;
    [SerializeField] private LocalizedString _itemName = default;
    [SerializeField] private int _maxStack = default;
    [SerializeField] private LocalizedString _description = default;
    private Guid guid = Guid.NewGuid();

    public Guid GUID => guid;
    public int Id => _id;
    public AssetReference Prefap => _prefap;
    public Sprite Icon => _icon;
    public LocalizedString ItemName => _itemName;
    public int MaxStack => _maxStack;
    public LocalizedString Description => _description;
}
