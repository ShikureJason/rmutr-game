using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class Dialogue : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private LocalizeStringEvent _dialogueText = default;
    [SerializeField] private LocalizeStringEvent _actorText = default;
    [SerializeField] private GameObject _actorPanel = default;

    [Header("Event Listener")]
    [SerializeField] private ObjLocalizeStringEvent _showDialogueWithoutNameEventListener = default;
    [SerializeField] private ShowDialogueEvent _showDialogueWithNameEventListener = default;

    private void OnEnable()
    {
        _showDialogueWithNameEventListener.OnEventRaised += showDialogueWithName;
        _showDialogueWithoutNameEventListener.OnEventRaised += showDialogueWithoutName;
    }

    private void OnDisable()
    {
        _showDialogueWithNameEventListener.OnEventRaised -= showDialogueWithName;
        _showDialogueWithoutNameEventListener.OnEventRaised -= showDialogueWithoutName;
    }

    private void showDialogueWithName(LocalizedString dialogue, LocalizedString name)
    {
        _actorPanel.SetActive(true);
        _dialogueText.StringReference = dialogue;
        _actorText.StringReference = name;
    }

    private void showDialogueWithoutName(LocalizedString dialogue)
    {
        _actorPanel.SetActive(false);
        _dialogueText.StringReference = dialogue;
    }
}