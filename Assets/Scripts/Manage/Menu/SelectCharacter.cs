using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Localization;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private CharacterPrefapSO _character;
    [SerializeField] private AssetReference[] _characterPrefap = new AssetReference[3];
    [SerializeField] private LocalizedString[] _characterName = new LocalizedString[3];
    [SerializeField] private Button _selectButton;

    [Header("Event Emiiter")]
    [SerializeField] private VoidEvent _selectCharacterEventEmitter;

    private void Start()
    {
        _selectButton.interactable = false;
    }
    public void CharacterSelect(int index)
    {
        _character.CharacterName = _characterName[index];
        _character.CharacterPrefap = _characterPrefap[index];
        _selectButton.interactable = true;
    }

    public void ConfirmSelect()
    {
        _selectCharacterEventEmitter.OnEventRaised();
    }

}
