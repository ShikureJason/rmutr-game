using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
public class DialogueDetail
{
    [SerializeField] private CharacterID _characterID;
    [SerializeField] private List<LocalizedString> _textDialogue;

    public CharacterID CharacterID => _characterID;
    public List<LocalizedString> TextDialogue => _textDialogue;
}
