using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class UIChoice : MonoBehaviour
{
    [SerializeField] private GameObject _buttonPrefab = default;

    [Header("Event Emitter")]
    [SerializeField] private QuestEvent _questReceiveEventEmitter = default;


    public void SetChioce(List<ChoiceDetail> chioceData)
    {
        foreach (ChoiceDetail chioce in chioceData)
        {
            GameObject newChoiceButton = Instantiate(_buttonPrefab, gameObject.transform);
            newChoiceButton.GetComponentInChildren<LocalizeStringEvent>().StringReference = chioce.ChoiceText;
            newChoiceButton.GetComponent<Button>().onClick.AddListener(() => SelectChoice(chioce.NextQuest));
        }
    }

    private void SelectChoice(QuestSO nextDialogue)
    {
        gameObject.SetActive(false);
        _questReceiveEventEmitter.RaiseEvent(nextDialogue);
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
