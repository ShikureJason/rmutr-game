using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader = default;
    [SerializeField] private CharacterSO _character = default;

    [Header("Event Listener")]
    [SerializeField] private SceneTypeEvent _switchInputEventListener = default;
    [SerializeField] private InteractEvent _switchInteractionEventListener = default;

    private void OnEnable()
    {
        _switchInputEventListener.OnEventRaised += switchInputReader;
    }

    private void OnDisable()
    {
        _switchInputEventListener.OnEventRaised -= switchInputReader;
    }

    private void interractDetect(InteractType interact, bool hasInterract)
    {
        
    }

    private void switchInputReader(SceneType Type)
    {
        switch (Type)
        {
            case SceneType.Main:
                _inputReader.EnableGameplay();
                break;
            default:
                _inputReader.DisableAllInput();
                break;
        }
    }
}
