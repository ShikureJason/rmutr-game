using UnityEngine;
using UnityEngine.Localization;

public class CharacterDetail : MonoBehaviour
{
    [SerializeField] private CharacterID _characterID;
    [SerializeField] private LocalizedString _characterName;

    public CharacterID CharacterID => _characterID;
    public LocalizedString CharacterName
    {
        get { return _characterName; }
        set { _characterName = value; }
    }
}
