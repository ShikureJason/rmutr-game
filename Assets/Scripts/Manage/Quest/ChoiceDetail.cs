using UnityEngine;
using UnityEngine.Localization;

public class ChoiceDetail : MonoBehaviour
{
    [SerializeField] private LocalizedString _choiceText;
    [SerializeField] private QuestBaseSO _nextQuest;

    public LocalizedString ChoiceText => _choiceText;
    public QuestBaseSO NextQuest => _nextQuest;
}
