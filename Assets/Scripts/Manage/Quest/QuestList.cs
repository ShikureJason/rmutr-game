using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quests/Create List")]
public class QuestList : ScriptableObject
{
    [SerializeField] List<QuestSO> _questList;

    public List<QuestSO> List => _questList;
}
