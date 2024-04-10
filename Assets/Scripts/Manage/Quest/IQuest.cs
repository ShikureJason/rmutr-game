using System.Collections.Generic;

namespace RMUTR.Quest
{
    public interface IQuest
    {
        CharacterID CharacterID { get; }
        QuestStatus QuestStatus { get; set; }
        QuestType QuestType { get; }
        QuestList Condition { get; }
        QuestList NextQuest { get; }

        List<RewardItemSO> RewardItem { get; }
        bool FirstQuest {  get; }
    }
}

