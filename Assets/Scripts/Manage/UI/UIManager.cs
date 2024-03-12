using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private GameObject _uiInteract;

    [Header("Event Listener")]
    [SerializeField] private BoolEvent _loadingScreenEventEmitter;
    [SerializeField] private InteractEvent _interacteventEmitter;


    private void OnEnable()
    {

        _loadingScreenEventEmitter.OnEventRaised += loadingScreenActive;
    }

    private void OnDisable()
    {
        _loadingScreenEventEmitter.OnEventRaised -= loadingScreenActive;
    }

    private void OnInteract(InteractType type, bool isInteract)
    {
        _uiInteract.SetActive(isInteract);
    }



    private void loadingScreenActive(bool expression) => _loadingScreen.SetActive(expression);
}
