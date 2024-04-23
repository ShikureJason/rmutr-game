using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quests/QuestData")]
public class QuestDataSO : BaseScriptableObject
{
    [SerializeField] private List<QuestList> _questList = default;

    [Header("Data")]
    [SerializeField] private List<QuestBaseSO> _currentQuest = default;
    [SerializeField] private List<QuestDialogue> _defaultDialogue = default;

    public List<QuestList> QuestList => _questList;
    public List<QuestBaseSO> CurrentQuest
    {
        get { return _currentQuest; }
        set { _currentQuest = value; }
    }
    public List<QuestDialogue> DefaultDialogue
    { 
        get { return _defaultDialogue; }
        set { _defaultDialogue = value; }
    }
    public void Initialize()
    {
        _questList.Clear();
        _currentQuest.Clear();
        _defaultDialogue.Clear();
    }
}
