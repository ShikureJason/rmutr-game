using UnityEngine;

[CreateAssetMenu(menuName = "Quest/Find Location")]
public class QuestFindLocation : QuestBaseSO
{
    public QuestFindLocation()
    {
        QuestType = QuestType.FindLocation;
    }
}
