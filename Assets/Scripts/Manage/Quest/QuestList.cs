using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quests/Create List")]
public class QuestList : BaseScriptableObject
{
    public readonly string GUID = Guid.NewGuid().ToString();
    [SerializeField] private List<QuestBaseSO> _questList;

    public List<QuestBaseSO> List => _questList;
}
