using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "New Character", menuName = "Character/Create Prefap")]
public class CharacterPrefapSO : ScriptableObject
{
    [SerializeField] private CharacterID _characterID;
    [SerializeField] private AssetReference _characterPrefap;
    [SerializeField] private LocalizedString _characterName;

    public CharacterID CharacterID => _characterID;
    public LocalizedString CharacterName => _characterName;
    public AssetReference CharacterPrefap
    {
        get { return _characterPrefap; }
        set { _characterPrefap = value; }
    }
}
