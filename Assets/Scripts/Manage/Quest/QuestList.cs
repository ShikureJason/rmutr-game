using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quests/Create List")]
public class QuestList : BaseScriptableObject
{
    [SerializeField] List<QuestBaseSO> _questList;

    public List<QuestBaseSO> List => _questList;
}
