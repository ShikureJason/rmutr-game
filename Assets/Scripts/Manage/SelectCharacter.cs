using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Localization;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private CharacterPrefapSO _character;
    [SerializeField] private AssetReference[] _characterPrefap;
    [SerializeField] private LocalizedString[] _characterName;

    [Header("Event Emiiter")]
    [SerializeField] private VoidEvent _selectCharacterEventEmitter;

    public void OnCharacterSelect(int index)
    {
        _character.CharacterName = _characterName[index];
        _character.CharacterPrefap = _characterPrefap[index];
        _selectCharacterEventEmitter.OnEventRaised();
    }

}
