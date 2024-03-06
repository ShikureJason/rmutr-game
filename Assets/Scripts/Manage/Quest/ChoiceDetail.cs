using UnityEngine;
using UnityEngine.Localization;

public class ChoiceDetail : MonoBehaviour
{
    [SerializeField] private LocalizedString _choiceText;
    [SerializeField] private QuestSO _nextQuest;

    public LocalizedString ChoiceText => _choiceText;
    public QuestSO NextQuest => _nextQuest;
}
