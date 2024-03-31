using UnityEngine;
using UnityEngine.Localization.Components;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen = default;
    [Header("UI Interract")]
    [SerializeField] private GameObject _uiInteract = default;
    [SerializeField] private LocalizeStringEvent _uiInteractText = default;
    [SerializeField] private InteractTextUISO _interractText = default;

    [SerializeField] private GameObject _uiDialogue = default;

    [Header("Event Listener")]
    [SerializeField] private BoolEvent _dialogueEventListener = default;
    [SerializeField] private BoolEvent _loadingScreenEventListener = default;
    [SerializeField] private InteractEvent _interacteventListener = default;


    private void OnEnable()
    {

        _loadingScreenEventListener.OnEventRaised += loadingScreenActive;
        _interacteventListener.OnEventRaised += interact;
        _dialogueEventListener.OnEventRaised += dialogue;
    }

    private void OnDisable()
    {
        _loadingScreenEventListener.OnEventRaised -= loadingScreenActive;
        _interacteventListener.OnEventRaised -= interact;
        _dialogueEventListener.OnEventRaised -= dialogue;
    }

    private void interact(InteractType type, bool isInteract)
    {
        _uiInteract.SetActive(isInteract);
        _uiInteractText.StringReference = _interractText.InteractText[_interractText.InteractText.FindIndex(o => o.InteractType == type)].InterractText;
    }



    private void loadingScreenActive(bool expression) => _loadingScreen.SetActive(expression);

    private void dialogue(bool expression) => _uiDialogue.SetActive(expression);
}
