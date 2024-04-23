using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader = default;
    [SerializeField] private CharacterSO _character = default;

    [Header("Event Emitter")]
    [SerializeField] private VoidEvent _initializeManageEventEmitter = default;
    [SerializeField] private VoidEvent _initailizeManageFinsihEventEmitter = default;

    [Header("Event Listener")]
    [SerializeField] private SceneTypeEvent _switchInputEventListener = default;
    [SerializeField] private InteractEvent _switchInteractionEventListener = default;
    [SerializeField] private BoolEvent _dialogueEventListener = default;

    private SceneType currentSceneType;


    private void OnEnable()
    {
        _switchInputEventListener.OnEventRaised += switchInputReaderWithSceneType;
        _switchInputEventListener.OnEventRaised += setCurrentSceneType;
        _dialogueEventListener.OnEventRaised += setInputDialogue;
    }

    private void OnDisable()
    {
        _switchInputEventListener.OnEventRaised -= switchInputReaderWithSceneType;
        _switchInputEventListener.OnEventRaised -= setCurrentSceneType;
        _dialogueEventListener.OnEventRaised -= setInputDialogue;
    }

    private async void Start()
    {
        Task task = Task.Run(() => _initializeManageEventEmitter.RaiseEvent());
        await Task.WhenAll(task);

        Debug.Log("Load Finish");
        _initailizeManageFinsihEventEmitter.RaiseEvent();
        

    }

    private void setInputDialogue(bool expression)
    {
        if (expression)
        {
            _inputReader.DisableAllInput();
            _inputReader.EnableDialogue();
        } 
        else 
        {
            setCurrentInputReader();
        }
    }
      
    private void switchInputReaderWithSceneType(SceneType type)
    {
        switch (type)
        {
            case SceneType.Main:
                _inputReader.EnableGameplay();
                break;
            default:
                _inputReader.DisableAllInput();
                break;
        }
    }

    private void setCurrentInputReader() => switchInputReaderWithSceneType(currentSceneType);

    private void setCurrentSceneType(SceneType type) => currentSceneType = type;
}
