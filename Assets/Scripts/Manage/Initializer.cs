using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class Initializer : MonoBehaviour
{
    [SerializeField] private SceneSO _mangeScene;
    [SerializeField] private SceneSO _introScene;
    [SerializeField] private SceneSO _loadNextScene;

    [Header("Event Emitter")]
    [SerializeField] private AssetReference _loadSceneEventEmitter;

    [Header("Event Listener")]
    [SerializeField] private AssetReference _initailizeStartManageEventEmitter = default;
    [SerializeField] private AssetReference _introHasFinishEventListener = default;

    private void OnDisable()
    {
    }

    private void Start()
    {
        _initailizeStartManageEventEmitter.LoadAssetAsync<VoidEvent>().Completed += (AsyncOperationHandle<VoidEvent> obj) =>
        {
            obj.Result.OnEventRaised += LoadSceneFinish;
        };
        _mangeScene.Scene.LoadSceneAsync(LoadSceneMode.Additive, true).Completed += LoadSceneEvent;
        _introScene.Scene.LoadSceneAsync(LoadSceneMode.Additive, true).Completed += A;
        
        
        
    }

    private void A(AsyncOperationHandle<SceneInstance> obj)
    {
        Debug.LogError("Intro");
        _introHasFinishEventListener.LoadAssetAsync<VoidEvent>().Completed += (AsyncOperationHandle<VoidEvent> obj) =>
        {
            obj.Result.OnEventRaised += unloadIntro;
        };
    }

    private void LoadSceneEvent(AsyncOperationHandle<SceneInstance> obj)
    {

    }

    private void LoadSceneFinish()
    {
        _loadSceneEventEmitter.LoadAssetAsync<SceneEvent>().Completed += (AsyncOperationHandle<SceneEvent> obj) =>
        {
            obj.Result.RaiseEvent(_loadNextScene);
        };
        SceneManager.UnloadSceneAsync(0);
    }

    private void unloadIntro()
    {
        _introScene.Scene.UnLoadScene();
        Debug.LogError("Loaddd");
    }
        
}
