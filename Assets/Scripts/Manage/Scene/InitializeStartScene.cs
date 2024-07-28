using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class InitializeStartScene : MonoBehaviour
{
    [SerializeField] private SceneSO _localScene;
#if UNITY_EDITOR
    [SerializeField] private SceneSO _gameManageScene;
#endif
    [Header("Event Emitter")]
    [SerializeField] private SceneEvent _loadSceneEventEditorEmitter;
    [SerializeField] private VoidEvent _initializeStartSceneEmitter;
    [SerializeField] private VoidEvent _initializeStartSceneHasLoadedFinshEmitter;

    [Header("Event Listener")]
    [SerializeField] private VoidEvent _startInitlizeSceneEventEmitter;


    private void OnEnable()
    {
        _startInitlizeSceneEventEmitter.OnEventRaised += initializedStart;
    }

    private void OnDisable()
    {
        _startInitlizeSceneEventEmitter.OnEventRaised -= initializedStart;
    }

#if UNITY_EDITOR

    public IEnumerator Start()
    {
        var loc = Addressables.LoadResourceLocationsAsync(_gameManageScene.Scene);
        yield return loc;
        var result = loc.Result;
        if(!SceneManager.GetSceneByPath(result[0].InternalId).isLoaded)
        {
            _gameManageScene.Scene.LoadSceneAsync(LoadSceneMode.Additive, true).Completed += LoadSceneEvent;
        }
    }
#endif

    private void initializedStart()
    {
        Debug.LogError("Scene Initilize Finish");
        bool tt = _localScene.SceneType != SceneType.Menu;
        Debug.Log("Scene type = " + tt);
        if (_localScene.SceneType != SceneType.Menu)
        {
            Debug.Log("TTTTTTTTTTTT");
            _initializeStartSceneEmitter.RaiseEvent();
        }
        
        _initializeStartSceneHasLoadedFinshEmitter.RaiseEvent();
    }

    private void LoadSceneEvent(AsyncOperationHandle<SceneInstance> obj)
    {
        Debug.LogError("Scene Initilize Load");
        _loadSceneEventEditorEmitter.RaiseEvent(_localScene);
    }

}
