using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialogue : QuestBaseSO
{
    public QuestDialogue()
    {
        QuestType = QuestType.Dialogue;
    }

    [SerializeField] private DialogueSO _dialogue = default;

    public DialogueSO Dialogue => _dialogue;
}
