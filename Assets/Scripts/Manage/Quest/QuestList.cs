using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quests/Create List")]
public class QuestList : BaseScriptableObject
{
    [SerializeField] List<QuestSO> _questList;

    public List<QuestSO> List => _questList;
}
