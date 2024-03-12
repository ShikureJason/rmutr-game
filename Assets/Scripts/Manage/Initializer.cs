using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class Initializer : MonoBehaviour
{
    [SerializeField] private SceneSO _mangeScene;
    [SerializeField] private SceneSO _loadNextScene;

    [Header("Event Emitter")]
    [SerializeField] private LoadSceneEvent _loadSceneEventEmitter;
    private void Start()
    {
        _mangeScene.Scene.LoadSceneAsync(LoadSceneMode.Additive, true).Completed += LoadSceneEvent;
    }

    private void LoadSceneEvent(AsyncOperationHandle<SceneInstance> obj)
    {
        _loadSceneEventEmitter.RaiseEvent(_loadNextScene);
        SceneManager.UnloadSceneAsync(0);
    }
}
