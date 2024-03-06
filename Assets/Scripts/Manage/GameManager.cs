using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader;

    [Header("Event Listener")]
    [SerializeField] private SceneTypeEvent _switchInputEventListener;

    private void OnEnable()
    {
        _switchInputEventListener.OnEventRaised += switchInputReader;
    }

    private void OnDisable()
    {
        _switchInputEventListener.OnEventRaised -= switchInputReader;
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
