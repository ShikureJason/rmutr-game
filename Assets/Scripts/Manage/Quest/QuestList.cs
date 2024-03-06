using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Name", menuName = "Quests/Create Quest Character")]
public class QuestList : ScriptableObject
{
    [SerializeField] private CharacterID _characterID;
    [SerializeField] List<QuestSO> _questList;

    public CharacterID CharacterID => _characterID;
    public List<QuestSO> List => _questList;
}
