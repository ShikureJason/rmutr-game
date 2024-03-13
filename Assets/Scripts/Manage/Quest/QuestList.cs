using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Name", menuName = "Quests/Create Quest Character")]
public class QuestList : ScriptableObject
{
    [SerializeField] List<QuestBaseSO> _questList;

    public List<QuestBaseSO> List => _questList;
}
