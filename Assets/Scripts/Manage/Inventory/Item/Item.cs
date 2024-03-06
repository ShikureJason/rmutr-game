using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Localization;

public class Item : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private AssetReference _icon;
    [SerializeField] private LocalizedString _itemName;
    [SerializeField] private int _maxStack;
    [SerializeField] private LocalizedString _description; 

    public int Id => _id;
    public AssetReference Icon => _icon;
    public LocalizedString ItemName => _itemName;
    public int MaxStack => _maxStack;
    public LocalizedString Description => _description;
}
