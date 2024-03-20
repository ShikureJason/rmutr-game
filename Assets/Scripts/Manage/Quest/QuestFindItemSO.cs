using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quests/Find Item")]
public class QuestFindItemSO : QuestBaseSO
{
    [SerializeField] private List<ItemSO> _item;
}
